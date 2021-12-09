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
using static ZegoCsharpWinformDemo.ZegoUtil;

namespace ZegoCsharpWinformDemo.Examples
{
    public partial class VideoTalk : UserControl
    {
        private ZegoExpressEngine engine;
        private ZegoUser user = new ZegoUser();
        private string room_id = "";
        private string publish_stream_id = "";
        private string play_stream_id = "";
        private string play_stream_user_id = "";
        private ZegoRoomState room_state = ZegoRoomState.Disconnected;
        private ZegoPublisherState publisher_state = ZegoPublisherState.NoPublish;
        private SynchronizationContext context;
        private Common.ZegoEventHandlerWithLog event_handler_with_log = new Common.ZegoEventHandlerWithLog();
        private Common.ZegoEventHandler event_handler = new Common.ZegoEventHandler();
        private List<ZegoDeviceInfo> video_device_list = new List<ZegoDeviceInfo>();
        private List<ZegoDeviceInfo> microphone_device_list = new List<ZegoDeviceInfo>();
        private List<ZegoStream> room_stream_list = new List<ZegoStream>();

        public VideoTalk()
        {
            InitializeComponent();
        }

        private void VideoTalk_Load(object sender, EventArgs e)
        {
            context = SynchronizationContext.Current;

            ZegoUtil.InitLogViewControl(richTextBox_LogView);
            ZegoUtil.InitRoomStateControl(label_RoomState);

            CreateEngine();

            InitConfig();
        }

        public void InitConfig()
        {
            user.userID = ZegoUtil.DeviceName() + new Random().Next(0, 99999); ;
            user.userName = user.userID;
            room_id = "0001";
            publish_stream_id = "s_" + user.userID;

            textBox_RoomID.Text = room_id;
            textBox_UserID.Text = user.userID;
            textBox_PublishStreamID.Text = publish_stream_id;
            ZegoUtil.SetRoomState(room_state);
        }

        public void OnRoomStateUpdate(string roomID, ZegoRoomState state, int errorCode, string extendedData)
        {
            ZegoUtil.SetRoomState(state);
            room_state = state;

            if (errorCode != 0)
            {
                PrintLogToView(string.Format("Room state error, errorCode:{0}, errorMsg:{1}", errorCode, extendedData));
                tabControl1.SelectedIndex = 0;
                LogoutRoom();
                DestroyEngine();
                return;
            }

            if (state == ZegoRoomState.Connecting)
            {
                button_LoginRoom.Enabled = false;
                label_RoomID.Text = "";
            }
            else
            {
                button_LoginRoom.Enabled = true;
                if (state == ZegoRoomState.Connected)
                {
                    label_RoomID.Text = room_id;

                    tabControl1.SelectedIndex = 1;

                    // Start publish stream
                    StartPreview();
                    StartPublishStream();
                }
                else if (state == ZegoRoomState.Disconnected)
                {
                    label_RoomID.Text = "";
                    label_StreamID.Text = "";
                }
            }
        }

        public void OnPublisherStateUpdate(string streamID, ZegoPublisherState state, int errorCode, string extendedData)
        {
            publisher_state = state;
            label_StreamID.Text = "";

            if (errorCode != 0)
            {
                PrintLogToView(string.Format("OnPublisherStateUpdate, errorCode:{0}, errorMsg:{1}", errorCode, extendedData));
                tabControl1.SelectedIndex = 0;
                LogoutRoom();
                DestroyEngine();
                return;
            }


            if (state == ZegoPublisherState.PublishRequesting)
            {
            }
            else
            {

                if (state == ZegoPublisherState.NoPublish)
                {
                }
                else if (state == ZegoPublisherState.Publishing)
                {
                    label_StreamID.Text = publish_stream_id;
                }
            }
        }

        public void OnRoomStreamUpdate(string roomID, ZegoUpdateType updateType, List<ZegoStream> streamList, string extendedData)
        {
            streamList.ForEach((stream) => {
                if (updateType == ZegoUpdateType.Add)
                {
                    room_stream_list.Add(stream);
                }
                else
                {
                    for (int i = 0; i < room_stream_list.Count; i++)
                    {
                        if (room_stream_list[i].streamID == stream.streamID)
                        {
                            room_stream_list.RemoveAt(i);
                            i--;
                        }
                    }
                }
            });

            if(play_stream_id.Length != 0)
            {
                StopPlayStream();
            }

            if(room_stream_list.Count > 0)
            {
                // Play the latest stream
                var current_play_stream = room_stream_list.ElementAt(room_stream_list.Count - 1);
                play_stream_id = current_play_stream.streamID;
                play_stream_user_id = current_play_stream.user.userID;
                StartPlayStream();
            }
        }

        public void OnPlayerStateUpdate(string streamID, ZegoPlayerState state, int errorCode, string extendedData)
        {
            if(errorCode != 0)
            {
                return;
            }

            label_RemoteStreamID.Text = "";
            label_RemoteUserID.Text = "";

            if(state == ZegoPlayerState.Playing)
            {
                label_RemoteStreamID.Text = streamID;
                if(streamID == play_stream_id)
                {
                    label_RemoteUserID.Text = play_stream_user_id;
                }
            }
            else if(state == ZegoPlayerState.PlayRequesting)
            {

            }
            else if(state == ZegoPlayerState.NoPlay)
            {

            }
        }

        public void OnRoomUserUpdate(string roomID, ZegoUpdateType updateType, List<ZegoUser> userList, uint userCount)
        {
            if(updateType == ZegoUpdateType.Add)
            {

            }
            else if(updateType == ZegoUpdateType.Delete)
            {

            }
        }

        public void CreateEngine()
        {
            if (engine == null)
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
                event_handler.onRoomStreamUpdate = OnRoomStreamUpdate;
                event_handler.onPlayerStateUpdate = OnPlayerStateUpdate;
                event_handler.onRoomUserUpdate = OnRoomUserUpdate;
            }
        }

        private void DestroyEngine()
        {
            if (engine != null)
            {
                engine = null;
                ZegoExpressEngine.DestroyEngine();
            }
        }

        private void LoginRoom()
        {
            room_id = textBox_RoomID.Text;
            user.userID = textBox_UserID.Text;
            user.userName = user.userID;
            ZegoRoomConfig config = new ZegoRoomConfig();
            config.isUserStatusNotify = true;

            ZegoUtil.PrintLogToView(string.Format("LoginRoom, roomID:{0}, userID:{1}, userName:{2}", room_id, user.userID, user.userName));
            engine.LoginRoom(room_id, user, config);
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
            canvas.view = pictureBox_Local.Handle;

            ZegoUtil.PrintLogToView(string.Format("StartPreview"));
            engine.StartPreview(canvas);
        }

        private void StopPreview()
        {
            ZegoUtil.PrintLogToView(string.Format("StopPreview"));
            engine.StopPreview();
        }

        private void StartPlayStream()
        {
            //play_stream_id = textBox_PlayStreamID.Text;

            ZegoUtil.PrintLogToView(string.Format("StartPlayingStream, streamID:{0}", play_stream_id));
            ZegoCanvas canvas = new ZegoCanvas();
            canvas.view = pictureBox_Remote.Handle;
            ZegoPlayerConfig config = new ZegoPlayerConfig();
            engine.StartPlayingStream(play_stream_id, canvas, config);
        }
        private void StopPlayStream()
        {
            ZegoUtil.PrintLogToView(string.Format("StopPlayingStream, streamID:{0}", play_stream_id));
            engine.StopPlayingStream(play_stream_id);
            play_stream_id = "";
            play_stream_user_id = "";
        }


        private void button_LoginRoom_Click(object sender, EventArgs e)
        {
            CreateEngine();
            LoginRoom();
        }

        private void button_Stop_Click(object sender, EventArgs e)
        {
            StopPreview();

            StopPublishStream();

            StopPlayStream();

            LogoutRoom();
            DestroyEngine();

            tabControl1.SelectedIndex = 0;
        }
    }
}
