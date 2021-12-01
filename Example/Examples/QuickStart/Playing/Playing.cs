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

namespace ZegoCsharpWinformDemo.Examples.QuickStart.Playing
{
    public partial class Playing : UserControl
    {
        private ZegoExpressEngine engine;
        private ZegoUser user = new ZegoUser();
        private string room_id = "";
        private string play_stream_id = "";
        private ZegoRoomState room_state = ZegoRoomState.Disconnected;
        private bool start_play = false;
        private SynchronizationContext context;
        private Common.ZegoEventHandlerWithLog event_handler_with_log = new Common.ZegoEventHandlerWithLog();
        private Common.ZegoEventHandler event_handler = new Common.ZegoEventHandler();

        public Playing()
        {
            InitializeComponent();
        }

        private void Playing_Load(object sender, EventArgs e)
        {
            context = SynchronizationContext.Current;

            ZegoUtil.InitLogViewControl(richTextBox_LogView);
            ZegoUtil.InitRoomStateControl(label_RoomState);

            CreateEngine();

            InitConfig();
        }

        public void InitConfig()
        {
            user.userID = ZegoUtil.DeviceName();
            user.userName = user.userID;
            room_id = "0003";
            play_stream_id = "0003";

            List<string> viewModeList = new List<string>
            {
                /** The proportional scaling up, there may be black borders */
                "AspectFit",
                /** The proportional zoom fills the entire View and may be partially cut */
                "AspectFill",
                /** Fill the entire view, the image may be stretched */
                "ScaleToFill"
            };

            textBox_RoomID.Text = room_id;
            textBox_UserID.Text = user.userID;
            textBox_PlayStreamID.Text = play_stream_id;
            ZegoUtil.SetRoomState(room_state);

            comboBox_ViewMode.SelectedIndexChanged -= comboBox_ViewMode_SelectedIndexChanged;
            comboBox_ViewMode.DataSource = viewModeList;
            comboBox_ViewMode.SelectedIndexChanged += comboBox_ViewMode_SelectedIndexChanged;

            checkBox_Video.CheckedChanged -= checkBox_Video_CheckedChanged;
            checkBox_Video.Checked = true;
            checkBox_Video.CheckedChanged += checkBox_Video_CheckedChanged;

            checkBox_Audio.CheckedChanged -= checkBox_Audio_CheckedChanged;
            checkBox_Audio.Checked = true;
            checkBox_Audio.CheckedChanged += checkBox_Audio_CheckedChanged;

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
                else if (state == ZegoRoomState.Disconnected)
                {
                    label_RoomID.Text = "";
                    button_LoginRoom.Text = "Login Room";
                    button_StartPlaying.Text = "Start Publishing";
                    label_StreamID.Text = "";
                }
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
                event_handler.onPlayerStateUpdate = OnPlayerStateUpdate;
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

            ZegoUtil.PrintLogToView(string.Format("LoginRoom, roomID:{0}, userID:{1}, userName:{2}", room_id, user.userID, user.userName));
            engine.LoginRoom(room_id, user);
        }

        private void LogoutRoom()
        {
            ZegoUtil.PrintLogToView("LogoutRoom");
            engine.LogoutRoom();
        }

        private void StartPlayStream()
        {
            play_stream_id = textBox_PlayStreamID.Text;

            ZegoUtil.PrintLogToView(string.Format("StartPlayingStream, streamID:{0}", play_stream_id));
            ZegoCanvas canvas = new ZegoCanvas();
            canvas.view = pictureBox1.Handle;
            canvas.viewMode = (ZegoViewMode)comboBox_ViewMode.SelectedIndex;
            engine.StartPlayingStream(play_stream_id, canvas);
        }
        private void StopPlayStream()
        {
            ZegoUtil.PrintLogToView(string.Format("StopPlayingStream, streamID:{0}", play_stream_id));
            engine.StopPlayingStream(play_stream_id);
            play_stream_id = "";
        }

        public void OnPlayerStateUpdate(string streamID, ZegoPlayerState state, int errorCode, string extendedData)
        {

        }

        private void button_LoginRoom_Click(object sender, EventArgs e)
        {
            if (room_state == ZegoRoomState.Disconnected)
            {
                LoginRoom();
            }
            else if (room_state == ZegoRoomState.Connected)
            {
                LogoutRoom();
            }
            else
            {
                ZegoUtil.PrintLogToView(string.Format("Invalid room state:{0}", room_state));
            }
        }

        private void comboBox_ViewMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            ZegoUtil.PrintLogToView(string.Format("Set view mode to:{0}", (ZegoViewMode)comboBox_ViewMode.SelectedIndex));
        }

        private void checkBox_Video_CheckedChanged(object sender, EventArgs e)
        {
            ZegoUtil.PrintLogToView(string.Format("MutePlayStreamVideo, streamID:{0}, mute:{1}", play_stream_id, !checkBox_Video.Checked));
            engine.MutePlayStreamVideo(play_stream_id, !checkBox_Video.Checked);
        }

        private void checkBox_Audio_CheckedChanged(object sender, EventArgs e)
        {
            ZegoUtil.PrintLogToView(string.Format("MutePlayStreamAudio, streamID:{0}, mute:{1}", play_stream_id, !checkBox_Audio.Checked));
            engine.MutePlayStreamAudio(play_stream_id, !checkBox_Audio.Checked);
        }

        private void button_StartPlaying_Click(object sender, EventArgs e)
        {
            if (start_play == false)
            {
                start_play = true;
                button_StartPlaying.Text = "Stop Playing";

                StartPlayStream();
            }
            else
            {
                start_play = false;
                button_StartPlaying.Text = "Start Playing";

                StopPlayStream();
            }
        }
    }
}
