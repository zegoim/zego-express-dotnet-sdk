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

namespace ZegoCsharpWinformDemo.Examples
{
    public partial class MultipleRooms : UserControl
    {
        private class RoomStream{
            public string room_id;
            public ZegoStream stream;
        };
        private ZegoExpressEngine engine;
        private ZegoUser user = new ZegoUser();
        private string room_id_1 = "";
        private string room_id_2 = "";
        private string publish_room_id = "";
        private string publish_stream_id = "";
        private string play_stream_id = "";
        private bool is_login_room_1 = false;
        private bool is_login_room_2 = false;
        private bool is_publish = false;
        private ZegoRoomState room_1_state = ZegoRoomState.Disconnected;
        private ZegoRoomState room_2_state = ZegoRoomState.Disconnected;
        private ZegoPublisherState publisher_state = ZegoPublisherState.NoPublish;
        private SynchronizationContext context;
        private Common.ZegoEventHandlerWithLog event_handler_with_log = new Common.ZegoEventHandlerWithLog();
        private Common.ZegoEventHandler event_handler = new Common.ZegoEventHandler();
        private List<RoomStream> room_stream_list = new List<RoomStream>();
        private bool need_update = false;

        public MultipleRooms()
        {
            InitializeComponent();
        }

        private void MultipleRooms_Load(object sender, EventArgs e)
        {
            context = SynchronizationContext.Current;

            ZegoUtil.InitLogViewControl(richTextBox_LogView);
            ZegoUtil.InitRoomStateControl(label_RoomState);

            ZegoExpressEngine.SetRoomMode(ZegoRoomMode.MultiRoom);

            CreateEngine();

            InitConfig();
        }

        public void InitConfig()
        {
            user.userID = ZegoUtil.DeviceName();
            user.userName = user.userID;
            room_id_1 = "00291";
            room_id_2 = "00292";
            publish_room_id = "00291";
            publish_stream_id = "0029";

            textBox_RoomID1.Text = room_id_1;
            textBox_RoomID2.Text = room_id_2;
            textBox_PublishRoomID.Text = publish_room_id;
            textBox_PublishStreamID.Text = publish_stream_id;
            ZegoUtil.SetRoomState(room_1_state);
        }

        public void OnRoomStateUpdate(string roomID, ZegoRoomState state, int errorCode, string extendedData)
        {
            ZegoUtil.SetRoomState(state);
            if(roomID == room_id_1)
            {
                room_1_state = state;
            }
            else if(roomID == room_id_2)
            {
                room_2_state = state;
            }

            if (state == ZegoRoomState.Connecting)
            {
                if(roomID == room_id_1)
                {
                    button_LoginRoom1.Enabled = false;
                }
                else if(roomID == room_id_2)
                {
                    button_LoginRoom2.Enabled = false;
                }
            }
            else
            {
                if (roomID == room_id_1)
                {
                    button_LoginRoom1.Enabled = true;
                }
                else if (roomID == room_id_2)
                {
                    button_LoginRoom2.Enabled = true;
                }

                if (state == ZegoRoomState.Connected)
                {
                    label_StreamID.Text = roomID;

                    if (roomID == room_id_1)
                    {
                        button_LoginRoom1.Text = "Logout Room 1";
                    }
                    else if (roomID == room_id_2)
                    {
                        button_LoginRoom2.Text = "Logout Room 2";
                    }

                }
                else if (state == ZegoRoomState.Disconnected)
                {
                    if (roomID == room_id_1)
                    {
                        button_LoginRoom1.Text = "Login Room 1";
                    }
                    else if (roomID == room_id_2)
                    {
                        button_LoginRoom2.Text = "Login Room 2";
                    }

                    for (int i=0;i<room_stream_list.Count;i++)
                    {
                        if(room_stream_list[i].room_id == roomID)
                        {
                            need_update = true;
                            room_stream_list.RemoveAt(i);
                            i--;
                        }
                    }
                    if(need_update)
                    {
                        need_update = false;
                        listBox_RoomStreams.Items.Clear();
                        room_stream_list.ForEach((stream) => {
                            listBox_RoomStreams.Items.Add("roomID: " + stream.room_id + " streamID: " + stream.stream.streamID);
                        });
                    }
                }
            }
        }

        public void OnPublisherStateUpdate(string streamID, ZegoPublisherState state, int errorCode, string extendedData)
        {
            publisher_state = state;

            if (state == ZegoPublisherState.PublishRequesting)
            {
                label_StreamID.Text = "";
                button_StartPublishing.Enabled = false;
            }
            else
            {
                button_StartPublishing.Enabled = true;
                if (state == ZegoPublisherState.NoPublish)
                {
                    label_StreamID.Text = "";
                    button_StartPublishing.Text = "Start Publishing";
                }
                else if (state == ZegoPublisherState.Publishing)
                {
                    label_StreamID.Text = publish_stream_id;
                    button_StartPublishing.Text = "Stop Publishing";
                }
            }
        }

        public void OnRoomStreamUpdate(string roomID, ZegoUpdateType updateType, List<ZegoStream> streamList, string extendedData)
        {
            streamList.ForEach((stream)=> {
                if (updateType == ZegoUpdateType.Add)
                {
                    RoomStream room_stream = new RoomStream();
                    room_stream.room_id = roomID;
                    room_stream.stream = stream;
                    room_stream_list.Add(room_stream);
                }
                else
                {
                    for(int i=0;i<room_stream_list.Count;i++)
                    {
                        if(room_stream_list[i].room_id == roomID && room_stream_list[i].stream.streamID == stream.streamID)
                        {
                            room_stream_list.RemoveAt(i);
                            i--;
                        }
                    }
                }
            });

            listBox_RoomStreams.Items.Clear();

            room_stream_list.ForEach((stream) => {
                listBox_RoomStreams.Items.Add("roomID: " + stream.room_id + " streamID: " + stream.stream.streamID);
            });
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
            }
        }

        private void DestroyEngine()
        {
            if (engine != null)
            {
                engine = null;
                ZegoExpressEngine.DestroyEngine();
            }
            ZegoExpressEngine.SetRoomMode(ZegoRoomMode.SingleRoom);
        }

        private void LoginRoom(string room_id)
        {
            ZegoUtil.PrintLogToView(string.Format("LoginRoom, roomID:{0}, userID:{1}, userName:{2}", room_id, user.userID, user.userName));
            engine.LoginRoom(room_id, user);
        }

        private void LogoutRoom(string room_id)
        {
            ZegoUtil.PrintLogToView(string.Format("LogoutRoom, roomID:{0}", room_id));
            engine.LogoutRoom(room_id);
        }

        private void StartPublishStream()
        {         
            publish_stream_id = textBox_PublishStreamID.Text;
            publish_room_id = textBox_PublishRoomID.Text;

            ZegoPublisherConfig config = new ZegoPublisherConfig();
            config.roomID = publish_room_id;

            ZegoUtil.PrintLogToView(string.Format("StartPublishingStream, roomID:{0}, streamID:{1}", publish_room_id, publish_stream_id));
            engine.StartPublishingStream(publish_stream_id, config);
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

        private void StartPlayStream(string playStreamID, string playRoomID)
        {
            ZegoUtil.PrintLogToView(string.Format("StartPlayingStream, streamID:{0}, roomID{1}", playStreamID, playRoomID));
            ZegoCanvas canvas = new ZegoCanvas();
            canvas.view = pictureBox_Remote.Handle;
            ZegoPlayerConfig config = new ZegoPlayerConfig();
            config.resourceMode = ZegoStreamResourceMode.OnlyRTC;
            config.roomID = playRoomID;
            engine.StartPlayingStream(playStreamID, canvas, config);
        }
        private void StopPlayStream(string play_stream_id)
        {
            ZegoUtil.PrintLogToView(string.Format("StopPlayingStream, streamID:{0}", play_stream_id));
            engine.StopPlayingStream(play_stream_id);
        }

        private void button_StartPublishing_Click(object sender, EventArgs e)
        {
            if (publisher_state == ZegoPublisherState.NoPublish)
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

        private void button_LoginRoom1_Click(object sender, EventArgs e)
        {
            if(room_1_state == ZegoRoomState.Disconnected)
            {
                room_id_1 = textBox_RoomID1.Text;

                LoginRoom(room_id_1);
            }
            else
            {
                LogoutRoom(room_id_1);
            }
        }

        private void button_LoginRoom2_Click(object sender, EventArgs e)
        {
            if (room_2_state == ZegoRoomState.Disconnected)
            {
                room_id_2 = textBox_RoomID2.Text;

                LoginRoom(room_id_2);
            }
            else
            {
                LogoutRoom(room_id_2);
            }
        }

        private void listBox_RoomStreams_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(listBox_RoomStreams.SelectedIndex < 0 || listBox_RoomStreams.SelectedIndex >= room_stream_list.Count)
            {
                return;
            }
            if(play_stream_id.Length != 0)
            {
                StopPlayStream(play_stream_id);
            }
            var select_stream = room_stream_list.ElementAt(listBox_RoomStreams.SelectedIndex);
            play_stream_id = select_stream.stream.streamID;
            StartPlayStream(play_stream_id, select_stream.room_id);
        }
    }
}
