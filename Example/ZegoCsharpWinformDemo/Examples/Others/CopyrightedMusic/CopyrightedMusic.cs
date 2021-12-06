using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ZEGO;
using static ZegoCsharpWinformDemo.ZegoUtil;

namespace ZegoCsharpWinformDemo.Examples
{
    public partial class CopyrightedMusic : UserControl
    {
        private ZegoExpressEngine engine;
        private ZegoUser user = new ZegoUser();
        private string room_id = "";
        private string publish_stream_id = "";
        private string play_stream_id = "";
        private bool is_login_room = false;
        private bool is_publish = false;
        private ZegoRoomState room_state = ZegoRoomState.Disconnected;
        private ZegoPublisherState publisher_state = ZegoPublisherState.NoPublish;
        private SynchronizationContext context;
        private Common.ZegoEventHandlerWithLog event_handler_with_log = new Common.ZegoEventHandlerWithLog();
        private Common.ZegoEventHandler event_handler = new Common.ZegoEventHandler();
        private ZegoMediaPlayer media_player;
        private ZegoCopyrightedMusic copyrighted_music;
        private List<string> request_apis = new List<string>();
        private Dictionary<string, string> request_apis_dics = new Dictionary<string, string>();
        private string select_song_id;
        private string select_resource_id;
        private ZegoCopyrightedMusicBillingMode billing_mode;
        private ZegoCopyrightedMusicRequestConfig request_config = new ZegoCopyrightedMusicRequestConfig();

        public CopyrightedMusic()
        {
            InitializeComponent();
        }

        private void CopyrightedMusic_Load(object sender, EventArgs e)
        {
            context = SynchronizationContext.Current;

            ZegoUtil.InitLogViewControl(richTextBox_LogView);
            ZegoUtil.InitRoomStateControl(label_RoomState);

            CreateEngine();

            InitConfig();

            // Create copyrighted music
            copyrighted_music = engine.CreateCopyrightedMusic();

            // Create Media player
            media_player = engine.CreateMediaPlayer();

            media_player.onMediaPlayerPlayingProgress = OnMediaPlayerPlayingProgress;
            media_player.EnableAux(checkBox_EnableAux.Checked);
            media_player.EnableRepeat(checkBox_Repeat.Checked);

            // Init copyrighted music
            InitCopyrightedMusic();

            LoadJson();
        }

        public void InitConfig()
        {
            user.userID = ZegoUtil.DeviceName() + new Random().Next(0,99999);
            user.userName = user.userID;
            room_id = "Room_Copyrighted";
            publish_stream_id = "Stream_Copyrighted";

            textBox_RoomID.Text = room_id;
            textBox_PublishStreamID.Text = publish_stream_id;
            textBox_UserID.Text = user.userID;
            ZegoUtil.SetRoomState(room_state);

            checkBox_EnableAux.CheckedChanged -= checkBox_EnableAux_CheckedChanged;
            checkBox_EnableAux.Checked = true;
            checkBox_EnableAux.CheckedChanged += checkBox_EnableAux_CheckedChanged;
            checkBox_Repeat.CheckedChanged -= checkBox_Repeat_CheckedChanged;
            checkBox_Repeat.Checked = true;
            checkBox_Repeat.CheckedChanged += checkBox_Repeat_CheckedChanged;

            trackBar_Volume.Scroll -= trackBar_Volume_Scroll;
            trackBar_Volume.Maximum = 100;
            trackBar_Volume.Value = 100;
            trackBar_Volume.Scroll += trackBar_Volume_Scroll;

            // Song ID list
            List<string> song_id_list = new List<string>() {
                "65973657",
                "101846593",
                "300785364",
                "287915293",
                "125282604",
                "68431743",
                "245222868",
                "345222868",
                "36365"
            };

            // Resource ID list
            List<string> resource_id_list = new List<string>() {
                "z_65973657_1",
                "z_101846593_1",
                "z_300785364_1",
                "z_287915293_1",
                "z_125282604_1",
                "z_345222868_1",
                "z_125282604_1_hq",
                "z_125282604_1_sq",
                "z_125282604_2"
            };

            List<string> billing_mode_list = new List<string>()
            {
                /** Pay-per-use. */
                "Count",
                /** Monthly billing by user. */
                "User",
                /** Monthly billing by room. */
                "Room"
            };

            listBox_SoundIDList.DataSource = song_id_list;
            comboBox_BillingMode.DataSource = billing_mode_list;
            listBox_ResourceIDList.DataSource = resource_id_list;
        }

        public void OnRoomStateUpdate(string roomID, ZegoRoomState state, int errorCode, string extendedData)
        {
            ZegoUtil.SetRoomState(state);
            if (roomID == room_id)
            {
                room_state = state;
            }

            if (state == ZegoRoomState.Connecting)
            {
                if (roomID == room_id)
                {
                    button_LoginRoom.Enabled = false;
                }
            }
            else
            {
                if (roomID == room_id)
                {
                    button_LoginRoom.Enabled = true;
                }

                if (state == ZegoRoomState.Connected)
                {
                    label_StreamID.Text = roomID;

                    if (roomID == room_id)
                    {
                        button_LoginRoom.Text = "Logout Room";
                    }

                }
                else if (state == ZegoRoomState.Disconnected)
                {
                    if (roomID == room_id)
                    {
                        button_LoginRoom.Text = "Login Room";
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
            
        }

        public void OnCopyrightedMusicDownloadProgressUpdate(ZegoCopyrightedMusic copyrightedMusic, string resourceID, float progressRate)
        {
            progressBar_Download.Value = (int)(progressRate*100);
        }

        public void OnMediaPlayerPlayingProgress(ZegoMediaPlayer mediaPlayer, ulong millisecond)
        {
            progressBar_MediaPlay.Value = (int)millisecond;
        }

        public void CreateEngine()
        {
            if (engine == null)
            {
                ZegoEngineProfile engine_profile = new ZegoEngineProfile();
                engine_profile.appID = 2587762184;// KeyCenter.appID();
                engine_profile.appSign = "63b9f6fc59e483864878bca4e3bc84c531eacf39e5f4ea1858180ee6934adf86";// KeyCenter.appSign();
                engine_profile.scenario = ZegoScenario.General;

                ZegoUtil.PrintLogToView(string.Format("CreateEngine, appID:{0}, appSign:{1}, scenario:{2}", engine_profile.appID, engine_profile.appSign, engine_profile.scenario));
                engine = ZegoExpressEngine.CreateEngine(engine_profile, context);

                event_handler_with_log.SetZegoEventHandler(engine, event_handler);

                event_handler.onRoomStateUpdate = OnRoomStateUpdate;
                event_handler.onPublisherStateUpdate = OnPublisherStateUpdate;
                event_handler.onRoomStreamUpdate = OnRoomStreamUpdate;
                event_handler.onCopyrightedMusicDownloadProgressUpdate = OnCopyrightedMusicDownloadProgressUpdate;
            }
        }

        private void DestroyEngine()
        {
            if (engine != null)
            {
                engine.DestroyMediaPlayer(media_player);
                media_player = null;
                engine.DestroyCopyrightedMusic(copyrighted_music);
                copyrighted_music = null;
                engine = null;
                ZegoExpressEngine.DestroyEngine();
            }
            ZegoExpressEngine.SetRoomMode(ZegoRoomMode.SingleRoom);
        }

        private void LoginRoom(string room_id)
        {
            room_id = textBox_RoomID.Text;
            user.userID = textBox_UserID.Text;
            user.userName = user.userID;

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

        private void StartPlayStream(string playStreamID, string playRoomID)
        {
            ZegoUtil.PrintLogToView(string.Format("StartPlayingStream, streamID:{0}, roomID{1}", playStreamID, playRoomID));
            ZegoCanvas canvas = new ZegoCanvas();
            canvas.view = pictureBox1.Handle;
            ZegoPlayerConfig config = new ZegoPlayerConfig();
            config.roomID = playRoomID;
            engine.StartPlayingStream(playStreamID, canvas, config);
        }
        private void StopPlayStream(string play_stream_id)
        {
            ZegoUtil.PrintLogToView(string.Format("StopPlayingStream, streamID:{0}", play_stream_id));
            engine.StopPlayingStream(play_stream_id);
        }

        private void InitCopyrightedMusic()
        {
            ZegoCopyrightedMusicConfig config = new ZegoCopyrightedMusicConfig();
            config.user = new ZegoUser();
            config.user.userID = user.userID;
            config.user.userName = user.userName;

            PrintLogToView(string.Format("InitCopyrightedMusic,userID:{0}, userName:{1}", config.user.userID, config.user.userName));
            copyrighted_music.InitCopyrightedMusic(config, (int errorCode, IntPtr user_context) =>{
                PrintLogToView(string.Format("InitCopyrightedMusic, errorCode:{0}", errorCode));
            });
        }

        private void LoadJson()
        {
            string json_file = "CopyrightedMusic.json";
            using (System.IO.StreamReader file = File.OpenText(json_file))
            {
                using (JsonTextReader reader = new JsonTextReader(file))
                {
                    var json_obj = JObject.Parse(file.ReadToEnd());
                    //dynamic result = Newtonsoft.Json.JsonConvert.DeserializeObject(file.ReadToEnd());
                    foreach(var x in json_obj.Properties())
                    {
                        PrintLogToView(string.Format("{0}", x.ToString()));
                        request_apis.Add(x.ToString());
                        listBox_RequestList.Items.Add(x.Name);
                        request_apis_dics.Add(x.Name, x.Value.ToString());
                    }
                }
            }
        }

        private void button_LoginRoom_Click(object sender, EventArgs e)
        {
            if (room_state == ZegoRoomState.Disconnected)
            {
                room_id = textBox_RoomID.Text;

                LoginRoom(room_id);
            }
            else
            {
                LogoutRoom(room_id);
            }
        }

        private void button_StartPublishing_Click(object sender, EventArgs e)
        {
            if(publisher_state == ZegoPublisherState.NoPublish)
            {
                publish_stream_id = textBox_PublishStreamID.Text;

                StartPreview();
                StartPublishStream();
            }
            else
            {
                StopPreview();
                StopPublishStream();
            }
        }

        private void button_GetAccompaniment_Click(object sender, EventArgs e)
        {
            PrintLogToView(string.Format("RequestAccompaniment,mode:{0}, songID:{1}", request_config.mode, request_config.songID));
            copyrighted_music.RequestAccompaniment(request_config, (int errorCode, string resource) => {
                LogLevel level = GetLogLevel(errorCode);
                PrintLogToView(string.Format("OnCopyrightedMusicRequestAccompaniment,errorCode:{0}, resourece:{1}", errorCode, resource), level);
            });
        }

        private void button_SendRequest_Click(object sender, EventArgs e)
        {
            string req_command, req_param;
            req_command = listBox_RequestList.SelectedItem.ToString();
            req_param = request_apis_dics[req_command];

            PrintLogToView(string.Format("SendExtendedRequest, req_command:{0}, req_param:{1}", req_command, req_param));
            copyrighted_music.SendExtendedRequest(req_command, req_param, (int errorCode, string commands, string result) => {
                PrintLogToView(string.Format("OnCopyrightedMusicSendExtendedRequest,errorCode:{0}, commands:{1}, result:{2}", errorCode, commands, result));
            });
        }

        private void button_GetSong_Click(object sender, EventArgs e)
        {
            PrintLogToView(string.Format("RequestSong, mode:{0}, songID:{1}", request_config.mode, request_config.songID));
            copyrighted_music.RequestSong(request_config, (int errorCode, string resource)=>
            {
                var level = GetLogLevel(errorCode);
                PrintLogToView(string.Format("OnCopyrightedMusicRequestSong, errorCode:{0}, resource:{1}", errorCode, resource), level);
            });
        }

        private void button_GetLrcLyric_Click(object sender, EventArgs e)
        {
            PrintLogToView(string.Format("GetLrcLyric, songID:{0}", select_song_id));
            copyrighted_music.GetLrcLyric(select_song_id, (int errorCode, string lyrics) => {
                var level = GetLogLevel(errorCode);
                PrintLogToView(string.Format("OnCopyrightedMusicGetLrcLyric, errorCode:{0}, lyrics:{1}", errorCode, lyrics), level);
            });
        }

        private void button_GetKrcLyric_Click(object sender, EventArgs e)
        {
            string token = textBox_MusicToken.Text;
            PrintLogToView(string.Format("GetKrcLyricByToken, token:{0}", token));
            copyrighted_music.GetKrcLyricByToken(token, (int errorCode, string lyrics) => {
                var level = GetLogLevel(errorCode);
                PrintLogToView(string.Format("OnCopyrightedMusicGetKrcLyricByToken, errorCode:{0}, lyrics:{1}", errorCode, lyrics), level);
            });
        }

        private void button_Download_Click(object sender, EventArgs e)
        {
            progressBar_Download.Value = 0;
            PrintLogToView(string.Format("Download, resoureID:{0}", select_resource_id));
            copyrighted_music.Download(select_resource_id, (int errorCode)=> {
                var level = GetLogLevel(errorCode);
                PrintLogToView(string.Format("OnCopyrightedMusicDownload, errorCode:{0}", errorCode), level);

                //Get cache size
                textBox_CacheSize.Text = string.Format("{0}", copyrighted_music.GetCacheSize());
            });
        }

        private void button_ClearCache_Click(object sender, EventArgs e)
        {
            PrintLogToView(string.Format("ClearCache"));
            copyrighted_music.ClearCache();
        }

        private void button_Play_Click(object sender, EventArgs e)
        {
            PrintLogToView(string.Format("loadCopyrightedMusicResourceWithPosition, resourceID:{0}", select_resource_id));
            media_player.loadCopyrightedMusicResourceWithPosition(select_resource_id, 0, (int errorCode) =>
            {
                PrintLogToView(string.Format("OnLoadResourceCallback, errorCode:{0}", errorCode));

                progressBar_MediaPlay.Maximum = (int)media_player.GetTotalDuration();

                media_player.Start();
            });
        }

        private void button_Pause_Click(object sender, EventArgs e)
        {
            PrintLogToView(string.Format("Pause"));
            media_player.Pause();
        }

        private void button_Resume_Click(object sender, EventArgs e)
        {
            PrintLogToView(string.Format("Resume"));
            media_player.Resume();
        }

        private void button_Stop_Click(object sender, EventArgs e)
        {
            PrintLogToView(string.Format("Stop"));
            media_player.Stop();
        }

        private void trackBar_Volume_Scroll(object sender, EventArgs e)
        {
            PrintLogToView(string.Format("SetPlayVolume:{0}", trackBar_Volume.Value));
            media_player.SetPlayVolume(trackBar_Volume.Value);
        }

        private void checkBox_EnableAux_CheckedChanged(object sender, EventArgs e)
        {
            PrintLogToView(string.Format("EnableAux:{0}", checkBox_EnableAux.Checked));
            media_player.EnableAux(checkBox_EnableAux.Checked);
        }

        private void checkBox_Repeat_CheckedChanged(object sender, EventArgs e)
        {
            PrintLogToView(string.Format("EnableRepeat:{0}", checkBox_Repeat.Checked));
            media_player.EnableRepeat(checkBox_Repeat.Checked);
        }

        private void listBox_RequestList_SelectedIndexChanged(object sender, EventArgs e)
        {
            int select_index = listBox_RequestList.SelectedIndex;
            if(select_index >= request_apis.Count)
            {
                return;
            }
            PrintLogToView(string.Format("Select json request:{0}", request_apis.ElementAt(select_index)));
        }

        private void listBox_SoundIDList_SelectedIndexChanged(object sender, EventArgs e)
        {
            select_song_id = listBox_SoundIDList.SelectedItem.ToString();
            PrintLogToView(string.Format("Set copyrighted music sound id:{0}", select_song_id));

            request_config.songID = select_song_id;
        }

        private void comboBox_BillingMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            billing_mode = (ZegoCopyrightedMusicBillingMode)comboBox_BillingMode.SelectedIndex;
            PrintLogToView(string.Format("Set copyrighted music billing mode:{0}", billing_mode));

            request_config.mode = billing_mode;
        }

        private void listBox_ResourceIDList_SelectedIndexChanged(object sender, EventArgs e)
        {
            select_resource_id = listBox_ResourceIDList.SelectedItem.ToString();

            PrintLogToView(string.Format("Set resource id:{0}", select_resource_id));
        }
    }
}
