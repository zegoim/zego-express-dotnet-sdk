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
using System.Diagnostics;

namespace ZegoCsharpWinformDemo.Examples
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
        private Common.ZegoEventHandler event_handler_with_log = new Common.ZegoEventHandler();
        private List<ZegoDeviceInfo> video_device_list = new List<ZegoDeviceInfo>();
        private List<ZegoDeviceInfo> microphone_device_list = new List<ZegoDeviceInfo>();

        public Publishing()
        {
            InitializeComponent();
        }

        public void InitConfig()
        {
            user.userID = ZegoUtil.UserID();
            user.userName = user.userID;
            room_id = "0002";
            publish_stream_id = "0002";

            List<string> mirrorModeList = new List<string>
            {
                /** The mirror image only for previewing locally. This mode is used by default. */
                "OnlyPreviewMirror",
                /** Both the video previewed locally and the far end playing the stream will see mirror image. */
                "BothMirror",
                /** Both the video previewed locally and the far end playing the stream will not see mirror image. */
                "NoMirror",
                /** The mirror image only for far end playing the stream. */
                "OnlyPublishMirror"
            };

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
            textBox_PublishStreamID.Text = publish_stream_id;
            ZegoUtil.SetRoomState(room_state);

            comboBox_MirrorMode.SelectedIndexChanged -= comboBox_MirrorMode_SelectedIndexChanged;
            comboBox_MirrorMode.DataSource = mirrorModeList;
            comboBox_MirrorMode.SelectedIndexChanged += comboBox_MirrorMode_SelectedIndexChanged;

            comboBox_ViewMode.SelectedIndexChanged -= comboBox_ViewMode_SelectedIndexChanged;
            comboBox_ViewMode.DataSource = viewModeList;
            comboBox_ViewMode.SelectedIndexChanged += comboBox_ViewMode_SelectedIndexChanged;

            // camera list
            if (engine!=null)
            {
                var video_device = engine.GetVideoDeviceList();
                List<string> video_device_name_list = new List<string>();
                foreach(var device in video_device)
                {
                    video_device_list.Add(device);
                    video_device_name_list.Add(device.deviceName);
                }

                comboBox_SwitchCamera.SelectedIndexChanged -= comboBox_SwitchCamera_SelectedIndexChanged;
                comboBox_SwitchCamera.DataSource = video_device_name_list;
                comboBox_SwitchCamera.SelectedIndexChanged += comboBox_SwitchCamera_SelectedIndexChanged;

                var audio_input_device = engine.GetAudioDeviceList(ZegoAudioDeviceType.Input);
                List<string> microphone_name_list = new List<string>();
                foreach(var device in audio_input_device)
                {
                    microphone_device_list.Add(device);
                    microphone_name_list.Add(device.deviceName);
                }

                comboBox_SwitchMicrophone.SelectedIndexChanged -= comboBox_SwitchMicrophone_SelectedIndexChanged;
                comboBox_SwitchMicrophone.DataSource = microphone_name_list;
                comboBox_SwitchMicrophone.SelectedIndexChanged += comboBox_SwitchMicrophone_SelectedIndexChanged;
            }

            checkBox_Camera.CheckedChanged -= checkBox_Camera_CheckedChanged;
            checkBox_Camera.Checked = true;
            checkBox_Camera.CheckedChanged += checkBox_Camera_CheckedChanged;

            checkBox_Microphone.CheckedChanged -= checkBox_Microphone_CheckedChanged;
            checkBox_Microphone.Checked = true;
            checkBox_Microphone.CheckedChanged += checkBox_Microphone_CheckedChanged;

        }

        public void OnRoomStateUpdate(string roomID, ZegoRoomState state, int errorCode, string extendedData)
        {
            ZegoUtil.SetRoomState(state);
            room_state = state;
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
                    button_LoginRoom.Text = "Logout Room";
                }
                else if(state == ZegoRoomState.Disconnected)
                {
                    label_RoomID.Text = "";
                    button_LoginRoom.Text = "Login Room";
                    button_StartPublishing.Text = "Start Publishing";
                    label_StreamID.Text = "";
                }
            }
        }

        public void OnPublisherStateUpdate(string streamID, ZegoPublisherState state, int errorCode, string extendedData)
        {
            publisher_state = state;
            label_StreamID.Text = "";

            if (state == ZegoPublisherState.PublishRequesting)
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
                    label_StreamID.Text = publish_stream_id;
                }
            }
        }

        public void CreateEngine()
        {
            if(engine == null)
            {
                ZegoEngineProfile engine_profile = new ZegoEngineProfile();
                engine_profile.appID = ZegoUtil.AppID();
                engine_profile.appSign = ZegoUtil.AppSign();
                engine_profile.scenario = ZegoScenario.General;

                ZegoUtil.PrintLogToView(string.Format("CreateEngine, appID:{0}, appSign:{1}, scenario:{2}", engine_profile.appID, engine_profile.appSign, engine_profile.scenario));
                engine = ZegoExpressEngine.CreateEngine(engine_profile, context);

                event_handler_with_log.onRoomStateUpdate = OnRoomStateUpdate;
                event_handler_with_log.onPublisherStateUpdate = OnPublisherStateUpdate;
                event_handler_with_log.SetZegoEventHandler(engine);
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
            user.userID = textBox_UserID.Text;
            user.userName = user.userID;

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
            // set view mode before preview
            canvas.viewMode = (ZegoViewMode)comboBox_ViewMode.SelectedIndex;

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
            else
            {
                LogoutRoom();
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
            
            if(publisher_state == ZegoPublisherState.NoPublish)
            {
                StartPreview();
                StartPublishStream();
            }
            else
            {
                StopPreview();
                StopPublishStream();
            }
        }

        private void comboBox_ViewMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            ZegoUtil.PrintLogToView(string.Format("Set view mode, mode:{0}", (ZegoViewMode)comboBox_ViewMode.SelectedIndex));
        }

        private void comboBox_MirrorMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            ZegoUtil.PrintLogToView(string.Format("SetVideoMirrorMode, mode:{0}", (ZegoVideoMirrorMode)comboBox_MirrorMode.SelectedIndex));
            engine.SetVideoMirrorMode((ZegoVideoMirrorMode)comboBox_MirrorMode.SelectedIndex);
        }

        private void comboBox_SwitchCamera_SelectedIndexChanged(object sender, EventArgs e)
        {
            ZegoUtil.PrintLogToView(string.Format("UseVideoDevice: {0}", comboBox_SwitchCamera.SelectedItem.ToString()));
            engine.UseVideoDevice(video_device_list.ElementAt(comboBox_SwitchCamera.SelectedIndex).deviceID);
        }

        private void comboBox_SwitchMicrophone_SelectedIndexChanged(object sender, EventArgs e)
        {
            ZegoUtil.PrintLogToView(string.Format("UseAudioDevice: {0}", comboBox_SwitchMicrophone.SelectedItem.ToString()));
            engine.UseAudioDevice(ZegoAudioDeviceType.Input, microphone_device_list.ElementAt(comboBox_SwitchMicrophone.SelectedIndex).deviceID);
        }

        private void checkBox_Camera_CheckedChanged(object sender, EventArgs e)
        {
            ZegoUtil.PrintLogToView(string.Format("EnableCamera: {0}", checkBox_Camera.Checked));
            engine.EnableCamera(checkBox_Camera.Checked);
        }

        private void checkBox_Microphone_CheckedChanged(object sender, EventArgs e)
        {
            ZegoUtil.PrintLogToView(string.Format("MuteMicrophone,{0}", !checkBox_Microphone.Checked));
            engine.MuteMicrophone(!checkBox_Microphone.Checked);
        }
    }
}
