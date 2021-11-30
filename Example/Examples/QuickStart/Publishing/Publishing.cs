using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using ZEGO;

namespace ZegoCsharpWinformDemo.Examples.QuickStart.Publishing
{
    public partial class Publishing : UserControl
    {
        private ZegoExpressEngine engine;
        private ZegoUser user = new ZegoUser();
        private string room_id = "";
        private string publish_stream_id = "";
        private ZegoRoomState room_state = ZegoRoomState.Disconnected;
        private ZegoPublisherState publisher_state = ZegoPublisherState.NoPublish;
        private SynchronizationContext context;
        private Common.ZegoEventHandlerWithLog event_handler_with_log = new Common.ZegoEventHandlerWithLog();
        private Common.ZegoEventHandler event_handler = new Common.ZegoEventHandler();

        public Publishing()
        {
            InitializeComponent();
        }

        public void InitConfig()
        {
            user.userID = ZegoUtil.DeviceName();
            user.userName = user.userID;
            room_id = "0002";
            publish_stream_id = "0002";

            textBox_RoomID.Text = room_id;
            textBox_UserID.Text = user.userID;
            textBox_PublishStreamID.Text = publish_stream_id;
            ZegoUtil.SetRoomState(room_state);
        }

        public void OnRoomStateUpdate(string roomID, ZegoRoomState state, int errorCode, string extendedData)
        {
            ZegoUtil.SetRoomState(state);
            room_state = state;
            if (state == ZegoRoomState.Connecting)
            {
                button_LoginRoom.Enabled = false;
                button_LoginRoom.Text = "";
            }
            else
            {
                button_LoginRoom.Enabled = true;
                if (state == ZegoRoomState.Connected)
                {
                    label_RoomID.Text = room_id;
                    button_LoginRoom.Text = "Logout Room";
                }
                else if(state == ZegoRoomState.Disconnected)
                {
                    label_RoomID.Text = "";
                    button_LoginRoom.Text = "Login Room";
                    button_StartPublishing.Text = "Start Publishing";
                }
            }
        }

        public void OnPublisherStateUpdate(string streamID, ZegoPublisherState state, int errorCode, string extendedData)
        {
            publisher_state = state;

            if(state == ZegoPublisherState.PublishRequesting)
            {
                button_StartPublishing.Enabled = false;
            }
            else
            {
                button_StartPublishing.Enabled = true;

                if(state == ZegoPublisherState.NoPublish)
                {
                    button_StartPublishing.Text = "Start Publishing";
                }
                else if(state == ZegoPublisherState.Publishing)
                {
                    button_StartPublishing.Text = "Stop Publishing";
                }
            }
        }

        public void CreateEngine()
        {
            if(engine == null)
            {
                ZegoEngineProfile engine_profile = new ZegoEngineProfile();
                engine_profile.appID = KeyCenter.appID();
                engine_profile.appSign = KeyCenter.appSign();
                engine_profile.scenario = ZegoScenario.General;

                ZegoUtil.PrintLogToView(string.Format("CreateEngine, appID:{0}, appSign:{1}, scenario:{2}", engine_profile.appID, engine_profile.appSign, engine_profile.scenario));
                engine = ZegoExpressEngine.CreateEngine(engine_profile, context);

                event_handler_with_log.SetZegoEventHandler(engine, event_handler);

                event_handler.onRoomStateUpdate = OnRoomStateUpdate;
                event_handler.onPublisherStateUpdate = OnPublisherStateUpdate;
            }
        }

        private void DestroyEngine()
        {
            if(engine != null)
            {
                engine = null;
                ZegoExpressEngine.DestroyEngine();
            }
        }

        private void LoginRoom()
        {
            room_id = textBox_RoomID.Text;

            ZegoUtil.PrintLogToView(string.Format("LoginRoom, roomID:{0}, userID:{1}, userName:{2}", room_id, user.userID, user.userName));
            engine.LoginRoom(room_id, user);
        }

        private void LogoutRoom()
        {
            ZegoUtil.PrintLogToView("LogoutRoom");
            engine.LogoutRoom();
        }

        private void StartPublishStream()
        {
            publish_stream_id = textBox_PublishStreamID.Text;

            ZegoUtil.PrintLogToView(string.Format("StartPublishingStream, streamID:{0}", publish_stream_id));
            engine.StartPublishingStream(publish_stream_id);
        }
        private void StopPublishStream()
        {
            publish_stream_id = "";

            ZegoUtil.PrintLogToView(string.Format("StopPublishingStream"));
            engine.StopPublishingStream();
        }

        private void StartPreview()
        {
            ZegoCanvas canvas = new ZegoCanvas();
            canvas.view = pictureBox1.Handle;

            ZegoUtil.PrintLogToView(string.Format("StartPreview"));
            engine.StartPreview(canvas);
        }

        private void StopPreview()
        {
            ZegoUtil.PrintLogToView(string.Format("StopPreview"));
            engine.StopPreview();
        }


        private void button_LoginRoom_Click(object sender, EventArgs e)
        {
            if(room_state == ZegoRoomState.Disconnected)
            {
                LoginRoom();
            }
            else if(room_state == ZegoRoomState.Connected)
            {
                LogoutRoom();
            }
            else
            {
                ZegoUtil.PrintLogToView(string.Format("Invalid room state:{0}", room_state));
            }
        }

        private void Publishing_Load(object sender, EventArgs e)
        {
            context = SynchronizationContext.Current;

            ZegoUtil.InitLogViewControl(richTextBox_LogView);
            ZegoUtil.InitRoomStateControl(label_RoomState);

            CreateEngine();

            InitConfig();
        }

        private void button_StartPublishing_Click(object sender, EventArgs e)
        {
            if(publisher_state == ZegoPublisherState.Publishing)
            {
                StopPreview();
                StopPublishStream();
            }
            else if(publisher_state == ZegoPublisherState.NoPublish)
            {
                StartPreview();
                StartPublishStream();
            }
            else
            {
                ZegoUtil.PrintLogToView(string.Format("Invalid publish state:{0}", publisher_state));
            }
        }
    }
}
