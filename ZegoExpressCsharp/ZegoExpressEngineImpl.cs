using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using static ZEGO.IZegoEventHandler;

namespace ZEGO
{
    public class ZegoExpressEngineImpl : ZegoExpressEngine
    {

        static ZegoExpressEngineImpl enginePtr = null;
        static IntPtr jvm = IntPtr.Zero;
        static IntPtr application = IntPtr.Zero;
        public static zego_engine_config engineConfig = new zego_engine_config();
        private static object zegoExpressEngineLock = new object();
        private static object zegoExpressEngineMediaPlayerLock = new object();
        private static Dictionary<int, OnPublisherUpdateCdnUrlResult> onPublisherUpdateCdnUrlResultDics = new Dictionary<int, OnPublisherUpdateCdnUrlResult>();
        public static IZegoDestroyCompletionCallback onDestroyCompletion;
        private static Dictionary<int, OnIMSendBroadcastMessageResult> onIMSendBroadcastMessageResultDics = new Dictionary<int, OnIMSendBroadcastMessageResult>();
        private static Dictionary<int, OnIMSendCustomCommandResult> onIMSendCustomCommandResultDics = new Dictionary<int, OnIMSendCustomCommandResult>();
        private static Dictionary<int, OnIMSendBarrageMessageResult> onIMSendBarrageMessageResultDics = new Dictionary<int, OnIMSendBarrageMessageResult>();
        private static Dictionary<int, OnPublisherSetStreamExtraInfoResult> onPublisherSetStreamExtraInfoResultDics = new Dictionary<int, OnPublisherSetStreamExtraInfoResult>();
        // private static bool setEngineConfigFlag = false;
        static SynchronizationContext context;
        private static Dictionary<ZegoMediaPlayerInstanceIndex, ZegoMediaPlayer> mediaPlayerAndIndex = new Dictionary<ZegoMediaPlayerInstanceIndex, ZegoMediaPlayer>();
        private static Dictionary<int, OnMixerStartResult> onMixerStartResultDics = new Dictionary<int, OnMixerStartResult>();
        private static Dictionary<int, OnMixerStopResult> onMixerStopResultDics = new Dictionary<int, OnMixerStopResult>();
        private static IExpressEngineInternal.zego_on_engine_uninit zegoOnEngineUninit;//避免GC回收
        private static IExpressMediaPlayerInternal.zego_on_media_player_playing_progress zegoOnMediaplayerPlayingProgress;
        private static IExpressRoomInternal.zego_on_room_state_update zegoOnRoomStateUpdate;
        private static IExpressRoomInternal.zego_on_room_user_update zegoOnRoomUserUpdate;
        private static IExpressRoomInternal.zego_on_room_stream_update zegoOnRoomStreamUpdate;
        private static IExpressPublisherInternal.zego_on_publisher_state_update zegoOnPublisherStateUpdate;
        private static IExpressPublisherInternal.zego_on_publisher_quality_update zegoOnPublisherQualityUpdate;
        private static IExpressPublisherInternal.zego_on_publisher_captured_audio_first_frame zegoOnPublisherRecvAudioCapturedFirstFrame;
        private static IExpressPublisherInternal.zego_on_publisher_captured_video_first_frame zegoOnPublisherRecvVideoCapturedFirstFrame;
        private static IExpressPublisherInternal.zego_on_publisher_video_size_changed zegoOnPublisherVideoSizeChanged;
        private static IExpressCustomVideoInternal.zego_on_custom_video_render_captured_frame_data zegoOnCustomVideoRenderCapturedFrameData;
        private static IExpressCustomVideoInternal.zego_on_custom_video_render_remote_frame_data zegoOnCustomVideoRenderRemoteFrameData;
        private static IExpressPlayerInternal.zego_on_player_state_update zegoOnPlayerStateUpdate;
        private static IExpressPlayerInternal.zego_on_player_quality_update zegoOnPlayerQualityUpdate;
        private static IExpressPlayerInternal.zego_on_player_media_event zegoOnPlayerMediaEvent;
        private static IExpressPlayerInternal.zego_on_player_recv_audio_first_frame zegoOnPlayerRecvAudioFirstFrame;
        private static IExpressPlayerInternal.zego_on_player_recv_video_first_frame zegoOnPlayerRecvVideoFirstFrame;
        private static IExpressPlayerInternal.zego_on_player_render_video_first_frame zegoOnPlayerRenderVideoFirstFrame;
        private static IExpressPlayerInternal.zego_on_player_video_size_changed zegoOnPlayerVideoSizeChanged;
        private static IExpressIMInternal.zego_on_im_recv_barrage_message zegoOnImRecvBarrageMessage;
        private static IExpressIMInternal.zego_on_im_recv_broadcast_message zegoOnImRecvBroadcastMessage;
        private static IExpressIMInternal.zego_on_im_recv_custom_command zegoOnImRecvCustomCommand;
        private static IExpressIMInternal.zego_on_im_send_barrage_message_result zegoOnImSendBarrageMessageResult;
        private static IExpressIMInternal.zego_on_im_send_broadcast_message_result zegoOnImSendBroadcastMessageResult;
        private static IExpressIMInternal.zego_on_im_send_custom_command_result zegoOnImSendCustomCommandResult;
        private static IExpressPublisherInternal.zego_on_publisher_update_cdn_url_result zegoOnPublisherUpdateCdnUrlResult;
        private static IExpressPublisherInternal.zego_on_publisher_relay_cdn_state_update zegoOnPublisherRelayCdnStateUpdate;
        private static IExpressDeviceInternal.zego_on_captured_sound_level_update zegoOnCapturedSoundLevelUpdate;
        private static IExpressDeviceInternal.zego_on_remote_sound_level_update zegoOnRemoteSoundLevelUpdate;
        private static IExpressDeviceInternal.zego_on_captured_audio_spectrum_update zegoOnCapturedAudioSpectrumUpdate;
        private static IExpressDeviceInternal.zego_on_remote_audio_spectrum_update zegoOnRemoteAudioSpectrumUpdate;
        private static IExpressPlayerInternal.zego_on_player_recv_sei zegoOnPlayerRecvSei;
        private static IExpressEngineInternal.zego_on_debug_error zegoOnDebugError;
        private static IExpressRoomInternal.zego_on_room_stream_extra_info_update zegoOnRoomStreamExtraInfoUpdate;
        private static IExpressPublisherInternal.zego_on_publisher_update_stream_extra_info_result zegoOnPublisherUpdateStreamExtraInfoResult;
        private static IExpressMediaPlayerInternal.zego_on_media_player_state_update zegoOnMediaplayerStateUpdate;
        private static IExpressMediaPlayerInternal.zego_on_media_player_load_resource zegoOnMediaplayerLoadResourceResult;
        private static IExpressMediaPlayerInternal.zego_on_media_player_network_event zegoOnMediaplayerNetworkEvent;
        private static IExpressMediaPlayerInternal.zego_on_media_player_seek_to zegoOnMediaplayerSeekToTimeResult;
        private static IExpressMediaPlayerInternal.zego_on_media_player_audio_frame zegoOnMediaplayerAudioData;
        private static IExpressMediaPlayerInternal.zego_on_media_player_video_frame zegoOnMediaplayerVideoData;
        private static IExpressMixerInternal.zego_on_mixer_start_result zegoOnMixerStartResult;
        private static IExpressMixerInternal.zego_on_mixer_stop_result zegoOnMixerStopResult;
        private static IExpressCustomVideoInternal.zego_on_custom_video_capture_start zegoOnCustomVideoCaptureStart;
        private static IExpressCustomVideoInternal.zego_on_custom_video_capture_stop zegoOnCustomVideoCaptureStop;
        private static IExpressCustomAudioIO.zego_on_captured_audio_data zegoOnCapturedAudioData;
        private static IExpressCustomAudioIO.zego_on_remote_audio_data zegoOnRemoteAudioData;
        private static IExpressCustomAudioIO.zego_on_mixed_audio_data zegoOnMixedAudioData;
        private ArrayList arrayList;
        public static new void SetEngineConfig(ZegoEngineConfig config)
        {
            engineConfig = ChangeZegoEngineConfigClassToStruct(config);
            // DefaultOpenCustomRender(ref engineConfig);//Unity跨平台，默认开启外部渲染
            IExpressEngineInternal.zego_express_set_engine_config(engineConfig);
            ZegoUtil.ReleaseStructPointer(engineConfig.log_config);
            // setEngineConfigFlag = true;
        }

        public static zego_engine_config ChangeZegoEngineConfigClassToStruct(ZegoEngineConfig config)
        {
            if (config == null)
            {
                throw new Exception("SetEngineConfig param can not be null");
            }
            zego_engine_config engineConfig = new zego_engine_config();
            if (config.logConfig != null)
            {
                zego_log_config logConfig = new zego_log_config();
                logConfig.log_path = config.logConfig.logPath;
                logConfig.log_size = config.logConfig.logSize;
                engineConfig.log_config = ZegoUtil.GetStructPointer(logConfig);
                Console.WriteLine(string.Format("SetEngineConfig  logConfig.log_path:{0} logConfig.log_size:{1}", logConfig.log_path, logConfig.log_size));
            }
            else
            {
                Console.WriteLine("SetEngineConfig  logConfig is null");
            }
            if (config.advancedConfig != null)
            {
                string advancedConfig = "";
                foreach (KeyValuePair<string, string> item in config.advancedConfig)
                {
                    advancedConfig += item.Key + "=" + item.Value + ";";
                }
                Console.WriteLine(string.Format("SetEngineConfig  advancedConfig:{0}", advancedConfig));
                engineConfig.advanced_config = advancedConfig;
            }
            else
            {
                Console.WriteLine("SetEngineConfig  advancedConfig is null");
            }
            return engineConfig;

        }
        public static new ZegoExpressEngine CreateEngine(uint appId, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string appSign, bool isTestEnv, ZegoScenario scenario, SynchronizationContext uiThreadContext)
        {
            if (enginePtr == null) //双if +lock
            {
                lock (zegoExpressEngineLock)
                {
                    if (enginePtr == null)
                    {

                        //if (!setEngineConfigFlag)
                        //{
                        //    DefaultOpenCustomRender(ref engineConfig);//Unity跨平台，默认开启外部渲染
                        //    IExpressEngineInternal.zego_express_set_engine_config(engineConfig);
                        //    ZegoUtil.ReleaseAllStructPointers();
                        //}
                        if (uiThreadContext == null)
                        {
                            throw new Exception("CreateEngine uiThreadContext should not be null");
                        }
                        context = uiThreadContext;
                        zegoOnEngineUninit = new IExpressEngineInternal.zego_on_engine_uninit(zego_on_engine_uninit);
                        IExpressEngineInternal.zego_register_engine_uninit_callback(zegoOnEngineUninit, IntPtr.Zero);
                        

                        zegoOnRoomStateUpdate = new IExpressRoomInternal.zego_on_room_state_update(zego_on_room_state_update);
                        IExpressRoomInternal.zego_register_room_state_update_callback(zegoOnRoomStateUpdate, IntPtr.Zero);
                        

                        zegoOnRoomUserUpdate = new IExpressRoomInternal.zego_on_room_user_update(zego_on_room_user_update);
                        IExpressRoomInternal.zego_register_room_user_update_callback(zegoOnRoomUserUpdate, IntPtr.Zero);
                        

                        zegoOnRoomStreamUpdate = new IExpressRoomInternal.zego_on_room_stream_update(zego_on_room_stream_update);
                        IExpressRoomInternal.zego_register_room_stream_update_callback(zegoOnRoomStreamUpdate, IntPtr.Zero);
                        

                        zegoOnPublisherStateUpdate = new IExpressPublisherInternal.zego_on_publisher_state_update(zego_on_publisher_state_update);
                        IExpressPublisherInternal.zego_register_publisher_state_update_callback(zegoOnPublisherStateUpdate, IntPtr.Zero);
                        

                        zegoOnPublisherQualityUpdate = new IExpressPublisherInternal.zego_on_publisher_quality_update(zego_on_publisher_quality_update);
                        IExpressPublisherInternal.zego_register_publisher_quality_update_callback(zegoOnPublisherQualityUpdate, IntPtr.Zero);
                        

                        zegoOnPublisherRecvAudioCapturedFirstFrame = new IExpressPublisherInternal.zego_on_publisher_captured_audio_first_frame(zego_on_publisher_recv_audio_captured_first_frame);
                        IExpressPublisherInternal.zego_register_publisher_captured_audio_first_frame_callback(zegoOnPublisherRecvAudioCapturedFirstFrame, IntPtr.Zero);
                        


                        zegoOnPublisherRecvVideoCapturedFirstFrame = new IExpressPublisherInternal.zego_on_publisher_captured_video_first_frame(zego_on_publisher_recv_video_captured_first_frame);
                        IExpressPublisherInternal.zego_register_publisher_captured_video_first_frame_callback(zegoOnPublisherRecvVideoCapturedFirstFrame, IntPtr.Zero);
                        

                        zegoOnPublisherVideoSizeChanged = new IExpressPublisherInternal.zego_on_publisher_video_size_changed(zego_on_publisher_video_size_changed);
                        IExpressPublisherInternal.zego_register_publisher_video_size_changed_callback(zegoOnPublisherVideoSizeChanged, IntPtr.Zero);
                        

                        zegoOnCustomVideoRenderCapturedFrameData = new IExpressCustomVideoInternal.zego_on_custom_video_render_captured_frame_data(zego_on_custom_video_render_captured_frame_data);
                        IExpressCustomVideoInternal.zego_register_custom_video_render_captured_frame_data_callback(zegoOnCustomVideoRenderCapturedFrameData, IntPtr.Zero);
                        

                        zegoOnCustomVideoRenderRemoteFrameData = new IExpressCustomVideoInternal.zego_on_custom_video_render_remote_frame_data(zego_on_custom_video_render_remote_frame_data);
                        IExpressCustomVideoInternal.zego_register_custom_video_render_remote_frame_data_callback(zegoOnCustomVideoRenderRemoteFrameData, IntPtr.Zero);
                        

                        zegoOnPlayerStateUpdate = new IExpressPlayerInternal.zego_on_player_state_update(zego_on_player_state_update);
                        IExpressPlayerInternal.zego_register_player_state_update_callback(zegoOnPlayerStateUpdate, IntPtr.Zero);
                        

                        zegoOnPlayerQualityUpdate = new IExpressPlayerInternal.zego_on_player_quality_update(zego_on_player_quality_update);
                        IExpressPlayerInternal.zego_register_player_quality_update_callback(zegoOnPlayerQualityUpdate, IntPtr.Zero);
                        

                        zegoOnPlayerMediaEvent = new IExpressPlayerInternal.zego_on_player_media_event(zego_on_player_media_event);
                        IExpressPlayerInternal.zego_register_player_media_event_callback(zegoOnPlayerMediaEvent, IntPtr.Zero);
                        

                        zegoOnPlayerRecvAudioFirstFrame = new IExpressPlayerInternal.zego_on_player_recv_audio_first_frame(zego_on_player_recv_audio_first_frame);
                        IExpressPlayerInternal.zego_register_player_recv_audio_first_frame_callback(zegoOnPlayerRecvAudioFirstFrame, IntPtr.Zero);
                        

                        zegoOnPlayerRecvVideoFirstFrame = new IExpressPlayerInternal.zego_on_player_recv_video_first_frame(zego_on_player_recv_video_first_frame);
                        IExpressPlayerInternal.zego_register_player_recv_video_first_frame_callback(zegoOnPlayerRecvVideoFirstFrame, IntPtr.Zero);
                       

                        zegoOnPlayerRenderVideoFirstFrame = new IExpressPlayerInternal.zego_on_player_render_video_first_frame(zego_on_player_render_video_first_frame);
                        IExpressPlayerInternal.zego_register_player_render_video_first_frame_callback(zegoOnPlayerRenderVideoFirstFrame, IntPtr.Zero);
                        


                        zegoOnPlayerVideoSizeChanged = new IExpressPlayerInternal.zego_on_player_video_size_changed(zego_on_player_video_size_changed);
                        IExpressPlayerInternal.zego_register_player_video_size_changed_callback(zegoOnPlayerVideoSizeChanged, IntPtr.Zero);
                        

                        zegoOnImRecvBarrageMessage = new IExpressIMInternal.zego_on_im_recv_barrage_message(zego_on_im_recv_barrage_message);
                        IExpressIMInternal.zego_register_im_recv_barrage_message_callback(zegoOnImRecvBarrageMessage, IntPtr.Zero);
                        

                        zegoOnImRecvBroadcastMessage = new IExpressIMInternal.zego_on_im_recv_broadcast_message(zego_on_im_recv_broadcast_message);
                        IExpressIMInternal.zego_register_im_recv_broadcast_message_callback(zegoOnImRecvBroadcastMessage, IntPtr.Zero);
                        

                        zegoOnImRecvCustomCommand = new IExpressIMInternal.zego_on_im_recv_custom_command(zego_on_im_recv_custom_command);
                        IExpressIMInternal.zego_register_im_recv_custom_command_callback(zegoOnImRecvCustomCommand, IntPtr.Zero);
                        

                        zegoOnImSendBarrageMessageResult = new IExpressIMInternal.zego_on_im_send_barrage_message_result(zego_on_im_send_barrage_message_result);
                        IExpressIMInternal.zego_register_im_send_barrage_message_result_callback(zegoOnImSendBarrageMessageResult, IntPtr.Zero);
                        

                        zegoOnImSendBroadcastMessageResult = new IExpressIMInternal.zego_on_im_send_broadcast_message_result(zego_on_im_send_broadcast_message_result);
                        IExpressIMInternal.zego_register_im_send_broadcast_message_result_callback(zegoOnImSendBroadcastMessageResult, IntPtr.Zero);
                        

                        zegoOnImSendCustomCommandResult = new IExpressIMInternal.zego_on_im_send_custom_command_result(zego_on_im_send_custom_command_result);
                        IExpressIMInternal.zego_register_im_send_custom_command_result_callback(zegoOnImSendCustomCommandResult, IntPtr.Zero);
                        

                        zegoOnPublisherUpdateCdnUrlResult = new IExpressPublisherInternal.zego_on_publisher_update_cdn_url_result(zego_on_publisher_update_cdn_url_result);
                        IExpressPublisherInternal.zego_register_publisher_update_cdn_url_result_callback(zegoOnPublisherUpdateCdnUrlResult, IntPtr.Zero);
                        

                        zegoOnPublisherRelayCdnStateUpdate = new IExpressPublisherInternal.zego_on_publisher_relay_cdn_state_update(zego_on_publisher_relay_cdn_state_update);
                        IExpressPublisherInternal.zego_register_publisher_relay_cdn_state_update_callback(zegoOnPublisherRelayCdnStateUpdate, IntPtr.Zero);
                        

                        zegoOnCapturedSoundLevelUpdate = new IExpressDeviceInternal.zego_on_captured_sound_level_update(zego_on_captured_sound_level_update);
                        IExpressDeviceInternal.zego_register_captured_sound_level_update_callback(zegoOnCapturedSoundLevelUpdate, IntPtr.Zero);
                        

                        zegoOnRemoteSoundLevelUpdate = new IExpressDeviceInternal.zego_on_remote_sound_level_update(zego_on_remote_sound_level_update);
                        IExpressDeviceInternal.zego_register_remote_sound_level_update_callback(zegoOnRemoteSoundLevelUpdate, IntPtr.Zero);
                        

                        zegoOnCapturedAudioSpectrumUpdate = new IExpressDeviceInternal.zego_on_captured_audio_spectrum_update(zego_on_captured_audio_spectrum_update);
                        IExpressDeviceInternal.zego_register_captured_audio_spectrum_update_callback(zegoOnCapturedAudioSpectrumUpdate, IntPtr.Zero);
                        

                        zegoOnRemoteAudioSpectrumUpdate = new IExpressDeviceInternal.zego_on_remote_audio_spectrum_update(zego_on_remote_audio_spectrum_update);
                        IExpressDeviceInternal.zego_register_remote_audio_spectrum_update_callback(zegoOnRemoteAudioSpectrumUpdate, IntPtr.Zero);
                        


                        zegoOnPlayerRecvSei = new IExpressPlayerInternal.zego_on_player_recv_sei(zego_on_player_recv_sei);
                        IExpressPlayerInternal.zego_register_player_recv_sei_callback(zegoOnPlayerRecvSei, IntPtr.Zero);
                        

                        zegoOnDebugError = new IExpressEngineInternal.zego_on_debug_error(zego_on_debug_error);
                        IExpressEngineInternal.zego_register_debug_error_callback(zegoOnDebugError, IntPtr.Zero);
                        

                        zegoOnRoomStreamExtraInfoUpdate = new IExpressRoomInternal.zego_on_room_stream_extra_info_update(zego_on_room_stream_extra_info_update);
                        IExpressRoomInternal.zego_register_room_stream_extra_info_update_callback(zegoOnRoomStreamExtraInfoUpdate, IntPtr.Zero);
                        

                        zegoOnPublisherUpdateStreamExtraInfoResult = new IExpressPublisherInternal.zego_on_publisher_update_stream_extra_info_result(zego_on_publisher_update_stream_extra_info_result);
                        IExpressPublisherInternal.zego_register_publisher_update_stream_extra_info_result_callback(zegoOnPublisherUpdateStreamExtraInfoResult, IntPtr.Zero);
                        

                        zegoOnMediaplayerStateUpdate = new IExpressMediaPlayerInternal.zego_on_media_player_state_update(zego_on_mediaplayer_state_update);
                        IExpressMediaPlayerInternal.zego_register_media_player_state_update_callback(zegoOnMediaplayerStateUpdate, IntPtr.Zero);
                        

                        zegoOnMediaplayerLoadResourceResult = new IExpressMediaPlayerInternal.zego_on_media_player_load_resource(zego_on_mediaplayer_load_resource_result);
                        IExpressMediaPlayerInternal.zego_register_media_player_load_resource_callback(zegoOnMediaplayerLoadResourceResult, IntPtr.Zero);
                        

                        zegoOnMediaplayerPlayingProgress = new IExpressMediaPlayerInternal.zego_on_media_player_playing_progress(zego_on_mediaplayer_playing_progress);
                        IExpressMediaPlayerInternal.zego_register_media_player_playing_progress_callback(zegoOnMediaplayerPlayingProgress, IntPtr.Zero);
                        

                        zegoOnMediaplayerNetworkEvent = new IExpressMediaPlayerInternal.zego_on_media_player_network_event(zego_on_mediaplayer_network_event);
                        IExpressMediaPlayerInternal.zego_register_media_player_network_event_callback(zegoOnMediaplayerNetworkEvent, IntPtr.Zero);
                        

                        zegoOnMediaplayerSeekToTimeResult = new IExpressMediaPlayerInternal.zego_on_media_player_seek_to(zego_on_mediaplayer_seek_to_time_result);
                        IExpressMediaPlayerInternal.zego_register_media_player_seek_to_callback(zegoOnMediaplayerSeekToTimeResult, IntPtr.Zero);
                       

                        zegoOnMediaplayerAudioData = new IExpressMediaPlayerInternal.zego_on_media_player_audio_frame(zego_on_mediaplayer_audio_data);
                        IExpressMediaPlayerInternal.zego_register_media_player_audio_frame_callback(zegoOnMediaplayerAudioData, IntPtr.Zero);
                        

                        zegoOnMediaplayerVideoData = new IExpressMediaPlayerInternal.zego_on_media_player_video_frame(zego_on_mediaplayer_video_data);
                        IExpressMediaPlayerInternal.zego_register_media_player_video_frame_callback(zegoOnMediaplayerVideoData, IntPtr.Zero);
                       


                        zegoOnMixerStartResult = new IExpressMixerInternal.zego_on_mixer_start_result(zego_on_mixer_start_result);
                        IExpressMixerInternal.zego_register_mixer_start_result_callback(zegoOnMixerStartResult, IntPtr.Zero);
                        

                        zegoOnMixerStopResult = new IExpressMixerInternal.zego_on_mixer_stop_result(zego_on_mixer_stop_result);
                        IExpressMixerInternal.zego_register_mixer_stop_result_callback(zegoOnMixerStopResult, IntPtr.Zero);
                        

                        zegoOnCustomVideoCaptureStart = new IExpressCustomVideoInternal.zego_on_custom_video_capture_start(zego_on_custom_video_capture_start);
                        IExpressCustomVideoInternal.zego_register_custom_video_capture_start_callback(zegoOnCustomVideoCaptureStart, IntPtr.Zero);
                        

                        zegoOnCustomVideoCaptureStop = new IExpressCustomVideoInternal.zego_on_custom_video_capture_stop(zego_on_custom_video_capture_stop);
                        IExpressCustomVideoInternal.zego_register_custom_video_capture_stop_callback(zegoOnCustomVideoCaptureStop, IntPtr.Zero);
                        

                        zegoOnCapturedAudioData = new IExpressCustomAudioIO.zego_on_captured_audio_data(zego_on_captured_audio_data);
                        IExpressCustomAudioIO.zego_register_captured_audio_data_callback(zegoOnCapturedAudioData, IntPtr.Zero);
                        

                        zegoOnRemoteAudioData = new IExpressCustomAudioIO.zego_on_remote_audio_data(zego_on_remote_audio_data);
                        IExpressCustomAudioIO.zego_register_remote_audio_data_callback(zegoOnRemoteAudioData, IntPtr.Zero);
                        

                        zegoOnMixedAudioData = new IExpressCustomAudioIO.zego_on_mixed_audio_data(zego_on_mixed_audio_data);
                        IExpressCustomAudioIO.zego_register_mixed_audio_data_callback(zegoOnMixedAudioData, IntPtr.Zero);
                        

                        int createResult = IExpressEngineInternal.zego_express_engine_init(appId, appSign, isTestEnv, scenario);
                        if (createResult != 0)
                        {
                            Console.WriteLine(string.Format("create Engine fail,error Code:{0}", createResult));
                            throw new Exception("create Engine fail,error Code:" + createResult);
                        }
                        else
                        {
                            Console.WriteLine("create Enigne success!!!");
                            enginePtr = new ZegoExpressEngineImpl();
                        }
                    }
                }
            }
            return enginePtr;

        }


        public static void zego_on_mixer_start_result(int error_code, int seq, [System.Runtime.InteropServices.InAttribute()] [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string extended_data, System.IntPtr user_context)
        {
            if (enginePtr == null || onMixerStartResultDics == null) return;

            Console.WriteLine(string.Format("zego_on_mixer_start_result error_code:{0}  seq:{1} extended_data:{2}", error_code, seq, extended_data));

            OnMixerStartResult onMixerStartResult = GetCallbackFromSeq<OnMixerStartResult>(onMixerStartResultDics, seq);

            if (context != null)
            {
                context.Post(new SendOrPostCallback((o) =>
                {
                    onMixerStartResult(error_code, extended_data);
                    onMixerStartResultDics.Remove(seq);
                }), null);
            }
        }

        /// Return Type: void
        ///error_code: int
        ///seq: int
        ///user_context: void*
        public static void zego_on_mixer_stop_result(int error_code, int seq, System.IntPtr user_context)
        {
            if (enginePtr == null || onMixerStopResultDics == null) return;

            Console.WriteLine(string.Format("zego_on_mixer_stop_result error_code:{0}  seq:{1}", error_code, seq));

            OnMixerStopResult onMixerStopResult = GetCallbackFromSeq<OnMixerStopResult>(onMixerStopResultDics, seq);

            if (context != null)
            {
                context.Post(new SendOrPostCallback((o) =>
                {
                    onMixerStopResult(error_code);
                    onMixerStopResultDics.Remove(seq);
                }), null);
            }
        }
        public static void zego_on_mediaplayer_audio_data(IntPtr data, uint data_length, zego_audio_frame_param param, ZegoMediaPlayerInstanceIndex instance_index, System.IntPtr user_context)
        {
            ZegoMediaPlayer zegoMediaPlayer = GetMediaPlayerFromIndex(instance_index);
            if (zegoMediaPlayer.onAudioFrame != null)
            {
                Console.WriteLine(string.Format("zego_on_mediaplayer_audio_data mediaplayerID:{0}", instance_index));
                ZegoAudioFrameParam zegoAudioFrameParam = ChangeZegoAudioFrameStructToClass(param);
                zegoMediaPlayer.onAudioFrame(zegoMediaPlayer, data, data_length, zegoAudioFrameParam);
            }
            else
            {
                return;
            }
        }

        private static ZegoAudioFrameParam ChangeZegoAudioFrameStructToClass(zego_audio_frame_param param)
        {
            ZegoAudioFrameParam zegoAudioFrameParam = new ZegoAudioFrameParam();
            zegoAudioFrameParam.channel = param.channel;
            zegoAudioFrameParam.samplesRate = param.samples_rate;
            return zegoAudioFrameParam;
        }

    
        public static void zego_on_mediaplayer_video_data(ref System.IntPtr data, IntPtr data_length, zego_video_frame_param param, ZegoMediaPlayerInstanceIndex instance_index, System.IntPtr user_context) {
            ZegoMediaPlayer zegoMediaPlayer = GetMediaPlayerFromIndex(instance_index);
            if (zegoMediaPlayer.onVideoFrame != null)
            {
                Console.WriteLine(string.Format("zego_on_mediaplayer_video_data mediaplayerID:{0}", instance_index));
                ZegoVideoFrameParam zegoVideoFrameParam = ChangeZegoVideoFrameParamStructToClass(param);
                zegoMediaPlayer.onVideoFrame(zegoMediaPlayer, data, data_length, zegoVideoFrameParam);
                
            }
            else
            {
                return;
            }
        }
        private static void DefaultOpenCustomRender(ref zego_engine_config engineConfig)//结构体是栈区分配，值类型，传递的时候是值拷贝，通过ref引用传递值类型解决
        {
            zego_custom_video_render_config customVideoRenderConfig = new zego_custom_video_render_config
            {
                type = ZegoVideoBufferType.RawData,
                series = ZegoCustomVideoRenderSeries.RGB,
                is_internal_render = false,

            };
            engineConfig.custom_video_render_config = ZegoUtil.GetStructPointer(customVideoRenderConfig);
        }


        public static void zego_on_mediaplayer_load_resource_result(int error_code, ZegoMediaPlayerInstanceIndex instance_index, System.IntPtr user_context)
        {
            ZegoMediaPlayer zegoMediaPlayer = GetMediaPlayerFromIndex(instance_index);
            if (zegoMediaPlayer.onLoadResourceCallback != null)
            {
                if (context != null)
                {
                    Console.WriteLine(string.Format("zego_on_mediaplayer_load_resource_result mediaplayerID:{0} error_code:{1}", instance_index, error_code));
                    context.Post(new SendOrPostCallback((o) =>
                    {
                        if (zegoMediaPlayer != null)
                        {
                            zegoMediaPlayer.onLoadResourceCallback(error_code);
                        }
                    }), null);
                }
            }
            else
            {
                return;
            }

        }



        private static void zego_on_engine_uninit(System.IntPtr userContext)
        {
           

            Console.WriteLine("destroy engine success");
            if (onDestroyCompletion != null)
            {
                if (context != null)
                {
                    context.Post(new SendOrPostCallback((o) =>
                    {
                        onDestroyCompletion();
                    }), null);
                }

                Console.WriteLine("destroy engine callback success");
            }
            else
            {
                Console.WriteLine("no set destroy engine callback");
            }

            release();

        }
        public static new void DestroyEngine(IZegoDestroyCompletionCallback onDestroyCompletion = null)
        {
            if (enginePtr != null) //双if +lock
            {
                lock (zegoExpressEngineLock)
                {
                    if (enginePtr != null)
                    {
                        ZegoExpressEngineImpl.onDestroyCompletion = onDestroyCompletion;
                        enginePtr = null;//engine must set null here,or crash
                        IExpressEngineInternal.zego_express_engine_uninit_async();                     
                    }
                }
            }
        }

        private static void release()
        {
           
            jvm = IntPtr.Zero;
            application = IntPtr.Zero;
            engineConfig = new zego_engine_config();
            mediaPlayerAndIndex.Clear();
            onIMSendBarrageMessageResultDics.Clear();
            onIMSendBroadcastMessageResultDics.Clear();
            onIMSendCustomCommandResultDics.Clear();
            onPublisherSetStreamExtraInfoResultDics.Clear();
            onPublisherUpdateCdnUrlResultDics.Clear();
            onMixerStartResultDics.Clear();
            onMixerStopResultDics.Clear();
            //setEngineConfigFlag = false;
        }
        public override void EnableAEC(bool enable)
        {
            if (enginePtr != null)
            {
                int result = IExpressPreprocessInternal.zego_express_enable_aec(enable);
                Console.WriteLine(string.Format("EnableAEC enable:{0} result:{1}",enable, result));
            }
        }
        
        public override void SetAECMode(ZegoAECMode mode)
        {
            if (enginePtr != null)
            {
                int result = IExpressPreprocessInternal.zego_express_set_aec_mode(mode);
                Console.WriteLine(string.Format("SetAECMode ZegoAECMode:{0} result:{1}", mode, result));
            }
        }
        public override void EnableAGC(bool enable)
        {
            if (enginePtr != null)
            {
                int result = IExpressPreprocessInternal.zego_express_enable_agc(enable);
                Console.WriteLine(string.Format("EnableAGC enable:{0} result:{1}", enable, result));
            }
        }
        public override void EnableANS(bool enable)
        {
            if (enginePtr != null)
            {
                int result = IExpressPreprocessInternal.zego_express_enable_ans(enable);
                Console.WriteLine(string.Format("EnableANS enable:{0} result:{1}", enable, result));
            }
        }
        public override void SetANSMode(ZegoANSMode mode)
        {
            if (enginePtr != null)
            {
                int result = IExpressPreprocessInternal.zego_express_set_ans_mode(mode);
                Console.WriteLine(string.Format("SetANSMode ZegoANSMode:{0} result:{1}", mode, result));
            }
        }

        public override void SendCustomVideoCaptureRawData(byte[] data, uint dataLength, ZegoVideoFrameParam param, ulong referenceTimeMillisecond, ZegoPublishChannel channel = ZegoPublishChannel.Main)
        {
            if (enginePtr != null)
            {
                zego_video_frame_param zego_Video_Frame_Param = ChangeZegoVideoFrameParamClassToStruct(param);
                int result = IExpressCustomVideoInternal.zego_express_send_custom_video_capture_raw_data(data, dataLength, zego_Video_Frame_Param, referenceTimeMillisecond, 1000, channel);
                //Console.WriteLine(string.Format("SendCustomVideoCaptureRawData result:{0}",result));
            }
        }


        public override void EnableCustomVideoCapture(bool enable, ZegoCustomVideoCaptureConfig config, ZegoPublishChannel channel = ZegoPublishChannel.Main)
        {
            if (enginePtr != null)
            {
                zego_custom_video_capture_config zego_Custom_Video_Capture_Config = ChangeCustomVideoCaptureConfigClassToStruct(config);
                IntPtr ptr = ZegoUtil.GetStructPointer(zego_Custom_Video_Capture_Config);
                int result = IExpressCustomVideoInternal.zego_express_enable_custom_video_capture(enable, ptr, channel);
                Console.WriteLine(string.Format("EnableCustomVideoCapture  enable:{0}  channel:{1}   result:{2}", enable, channel, result));
                ZegoUtil.ReleaseStructPointer(ptr);
            }
        }
        private zego_custom_video_capture_config ChangeCustomVideoCaptureConfigClassToStruct(ZegoCustomVideoCaptureConfig config)
        {
            zego_custom_video_capture_config result = new zego_custom_video_capture_config();
            if (config != null)
            {
                result.type = config.type;
            }
            return result;
        }


        private zego_video_frame_param ChangeZegoVideoFrameParamClassToStruct(ZegoVideoFrameParam param)
        {
            zego_video_frame_param result = new zego_video_frame_param();
            if (param != null)
            {
                result.format = param.format;
                result.height = param.height;
                result.width = param.width;
                result.rotation = param.rotation;
                result.strides = param.strides;
            }
            return result;
        }

        public override ZegoDeviceInfo[] GetAudioDeviceList(ZegoAudioDeviceType deviceType)
        {
            ZegoDeviceInfo[] zegoDeviceInfos = null;
            if (enginePtr != null)
            {
                int count = 0;
                IntPtr deviceInfo = IExpressDeviceInternal.zego_express_get_audio_device_list(deviceType, ref count);
                zego_device_info[] zego_Device_Info = new zego_device_info[count];
                ZegoUtil.GetStructListByPtr<zego_device_info>(ref zego_Device_Info, deviceInfo, count);
                zegoDeviceInfos = ChangeZegoDeviceInfoStructListToClassList(zego_Device_Info);
                ZegoUtil.ReleaseStructPointer(deviceInfo);
                Console.WriteLine(string.Format("GetAudioDeviceList  count:{0}", count));

            }
            return zegoDeviceInfos;
        }


        private ZegoDeviceInfo[] ChangeZegoDeviceInfoStructListToClassList(zego_device_info[] zego_Device_Info)
        {
            ZegoDeviceInfo[] result = null;
            if (zego_Device_Info != null)
            {
                result = new ZegoDeviceInfo[zego_Device_Info.Length];
                for (int i = 0; i < zego_Device_Info.Length; i++)
                {
                    ZegoDeviceInfo zegoDevice = new ZegoDeviceInfo();
                    zegoDevice.deviceId = Encoding.UTF8.GetString(zego_Device_Info[i].device_id);//device接口这里剔除'\0'会出问题
                    zegoDevice.deviceName = Encoding.UTF8.GetString(zego_Device_Info[i].device_name);
                    result[i] = zegoDevice;
                }
            }
            return result;
        }


        public override ZegoDeviceInfo[] GetVideoDeviceList()
        {
            ZegoDeviceInfo[] zegoDeviceInfos = null;
            if (enginePtr != null)
            {
                int count = 0;
                IntPtr deviceInfo = IExpressDeviceInternal.zego_express_get_video_device_list(ref count);
                zego_device_info[] zego_Device_Info = new zego_device_info[count];
                ZegoUtil.GetStructListByPtr<zego_device_info>(ref zego_Device_Info, deviceInfo, count);
                zegoDeviceInfos = ChangeZegoDeviceInfoStructListToClassList(zego_Device_Info);
                ZegoUtil.ReleaseStructPointer(deviceInfo);
                Console.WriteLine(string.Format("GetVideoDeviceList  count:{0}", count));

            }
            return zegoDeviceInfos;
        }

        public override void UseAudioDevice(ZegoAudioDeviceType deviceType, string deviceID)
        {


            if (enginePtr != null)
            {
                
                int result = IExpressDeviceInternal.zego_express_use_audio_device(deviceType, deviceID);
                Console.WriteLine(string.Format("UseAudioDevice  result:{0}", result));
            }

        }
        public override void UseVideoDevice(string deviceID, ZegoPublishChannel channel = ZegoPublishChannel.Main)
        {


            if (enginePtr != null)
            {
                
                int result = IExpressDeviceInternal.zego_express_use_video_device(deviceID, channel);
                Console.WriteLine(string.Format("UseVideoDevice  result:{0}", result));
            }
        }
        public override void EnableAudioDataCallback(bool enable, int callbackBitMask, ZegoAudioFrameParam param)
        {
            if (enginePtr != null)
            {
                zego_audio_frame_param audio_Frame_Param=ChangeZegoAudioFrameParamClassToStruct(param);
                int result = IExpressCustomAudioIO.zego_express_enable_audio_data_callback(enable,(uint)callbackBitMask,audio_Frame_Param);
                Console.WriteLine(string.Format("EnableAudioDataCallback  enable:{0} callbackBitMask:{1} channel:{2} sampleRate:{3} result:{4}", enable,callbackBitMask,param.channel,param.samplesRate,result));
            }
        }
        public override void EnableCustomAudioIO(bool enable, ZegoCustomAudioConfig config, ZegoPublishChannel channel = ZegoPublishChannel.Main)
        {
            if (enginePtr != null)
            {
                zego_custom_audio_config custom_Audio_Config = ChangeZegoCustomAudioConfigClassToStruct(config);
                IntPtr ptr = ZegoUtil.GetStructPointer(custom_Audio_Config);
                int result=IExpressCustomAudioIO.zego_express_enable_custom_audio_io(enable,ptr,channel);
                Console.WriteLine(string.Format("EnableCustomAudioIO  enable:{0} source_type:{1} channel:{2}  result:{3}", enable, config.source_type, channel, result));
                ZegoUtil.ReleaseStructPointer(ptr);
            }
        }

        private zego_custom_audio_config ChangeZegoCustomAudioConfigClassToStruct(ZegoCustomAudioConfig config)
        {
            zego_custom_audio_config result = new zego_custom_audio_config();
            if (config == null)
            {
                throw new Exception("EnableCustomAudioIO ZegoCustomAudioConfig should not be null");
            }
            else
            {
                result.source_type = config.source_type;
            }
            return result;
        }

        public override void SendCustomAudioCaptureAACData(byte[] data, uint dataLength, uint configLength, ulong referenceTimeMillisecond, ZegoAudioFrameParam param, ZegoPublishChannel channel = ZegoPublishChannel.Main)
        {
            if (enginePtr != null)
            {
                zego_audio_frame_param zego_Audio_Frame_Param = ChangeZegoAudioFrameParamClassToStruct(param);
                int result = IExpressCustomAudioIO.zego_express_send_custom_audio_capture_aac_data(data,dataLength,configLength,referenceTimeMillisecond,zego_Audio_Frame_Param,channel);
            }
        }
        public override void SendCustomAudioCapturePCMData(byte[] data, uint dataLength, ZegoAudioFrameParam param, ZegoPublishChannel channel = ZegoPublishChannel.Main)
        {
            if (enginePtr != null)
            {
                zego_audio_frame_param zego_Audio_Frame_Param = ChangeZegoAudioFrameParamClassToStruct(param);
                int result = IExpressCustomAudioIO.zego_express_send_custom_audio_capture_pcm_data(data, dataLength,zego_Audio_Frame_Param, channel);

            }
        }
        public override void FetchCustomAudioRenderPCMData(ref byte[] data, uint dataLength, ZegoAudioFrameParam param)
        {
            if (enginePtr != null)
            {
                zego_audio_frame_param zego_Audio_Frame_Param = ChangeZegoAudioFrameParamClassToStruct(param);
                int result = IExpressCustomAudioIO.zego_express_fetch_custom_audio_render_pcm_data(data, dataLength, zego_Audio_Frame_Param);

            }
        }
        private zego_audio_frame_param ChangeZegoAudioFrameParamClassToStruct(ZegoAudioFrameParam param)
        {
            zego_audio_frame_param result = new zego_audio_frame_param();
            if (param == null)
            {
                throw new Exception("EnableAudioDataCallback ZegoAudioFrameParam should not be null");
            }
            else
            {
                result.channel = param.channel;
                result.samples_rate = param.samplesRate;
            }
            return result;
        }

        public override void LoginRoom(string roomId, ZegoUser user, ZegoRoomConfig config = null)
        {
            if (enginePtr != null)
            {

                zego_user zegoUser = ChangeZegoUserClassToStruct(user);
                int error_code = 0;
                if (config == null)
                {
                    error_code = IExpressRoomInternal.zego_express_login_room(roomId, zegoUser, IntPtr.Zero);
                    Console.WriteLine("LoginRoom ZegoRoomConfig is null");
                }
                else
                {
                    IntPtr ptr = ChangeZegoRoomConfigClassToStructPoniter(config);
                    error_code = IExpressRoomInternal.zego_express_login_room(roomId, zegoUser, ptr);
                    ZegoUtil.ReleaseStructPointer(ptr);
                }
                Console.WriteLine(string.Format("LoginRoom  roomId:{0}  userId:{1}  userName:{2} result:{3}", roomId, user.userId, user.userName, error_code));

            }
        }

        public static void SetAudioHandler(ZegoMediaPlayer zegoMediaPlayer, ZegoMediaPlayer.OnAudioFrame onAudioFrame)
        {
            if (enginePtr != null)
            {
                int result = 0;
                bool enable = false;
                ZegoMediaPlayerInstanceIndex curIndex = GetIndexFromZegoMediaPlayer(zegoMediaPlayer);
                if (onAudioFrame == null) {
                    enable = false;
                    result = IExpressMediaPlayerInternal.zego_express_media_player_enable_audio_data(enable, curIndex);
                }
                else
                {
                    enable = true;
                    result = IExpressMediaPlayerInternal.zego_express_media_player_enable_audio_data(enable, curIndex);
                }
                Console.WriteLine(string.Format("SetAudioHandler enable:{0} result:{1} ", enable, result));
            }
        }

        public static void SetVideoHandler(ZegoMediaPlayer zegoMediaPlayer, ZegoVideoFrameFormat format, ZegoMediaPlayer.OnVideoFrame onVideoFrame)
        {
            if (enginePtr != null)
            {
                int result = 0;
                bool enable = false;
                ZegoMediaPlayerInstanceIndex curIndex = GetIndexFromZegoMediaPlayer(zegoMediaPlayer);
                if (onVideoFrame == null)
                {
                    enable = false;
                    result = IExpressMediaPlayerInternal.zego_express_media_player_enable_video_data(enable, format, curIndex);
                }
                else
                {
                    enable = true;
                    result = IExpressMediaPlayerInternal.zego_express_media_player_enable_video_data(enable, format, curIndex);
                }
                Console.WriteLine(string.Format("SetVideoHandler enable:{0} result:{1} ", enable, result));
            }
        }

        private IntPtr ChangeZegoRoomConfigClassToStructPoniter(ZegoRoomConfig config)
        {
            if (config == null)
            {
                return IntPtr.Zero;
            }
            else
            {
                zego_room_config roomConfig = new zego_room_config();
                roomConfig.max_member_count = config.maxMemberCount;
                roomConfig.thrid_token = config.token;
                roomConfig.is_user_status_notify = config.isUserStatusNotify;
                Console.WriteLine(string.Format("LoginRoom ZegoRoomConfig max_member_count:{0} thrid_token:{1} is_user_status_notify:{2}", roomConfig.max_member_count, roomConfig.thrid_token, roomConfig.is_user_status_notify));
                return ZegoUtil.GetStructPointer(roomConfig);
            }
        }

        private zego_user ChangeZegoUserClassToStruct(ZegoUser user)
        {
            zego_user zegoUser;
            if (user == null)
            {
                throw new Exception("ZegoUser should not be null");
            }
            else
            {
                if (user.userId == null)
                {
                    throw new Exception("ZegoUser userId should not be null");
                }
                if (user.userName == null)
                {
                    throw new Exception("ZegoUser userName should not be null");
                }
                byte[] tempUserIdBytes = Encoding.UTF8.GetBytes(user.userId);
                byte[] userIdBytes = new byte[ZegoConstans.ZEGO_EXPRESS_MAX_USERID_LEN];
                Array.Copy(tempUserIdBytes, userIdBytes, tempUserIdBytes.Length);

                byte[] tempUserNameBytes = Encoding.UTF8.GetBytes(user.userName);
                byte[] userNameBytes = new byte[ZegoConstans.ZEGO_EXPRESS_MAX_USERNAME_LEN];
                Array.Copy(tempUserNameBytes, userNameBytes, tempUserNameBytes.Length);

                zegoUser = new zego_user
                {
                    user_id = userIdBytes,
                    user_name = userNameBytes
                };
            }
            return zegoUser;
        }

        public override void LogoutRoom(string roomId)
        {
            if (enginePtr != null)
            {

                int result = IExpressRoomInternal.zego_express_logout_room(roomId);
                Console.WriteLine(string.Format("LogoutRoom roomId:{0}  result:{1}", roomId, result));
            }
        }


        public static void zego_on_room_state_update(string roomId, ZegoRoomState state, int errorCode, string extendedData, System.IntPtr userContext)
        {
            if (enginePtr == null || enginePtr.onRoomStateUpdate == null) return;
            if (context != null)
            {
                Console.WriteLine(string.Format("onRoomStateUpdate roomId:{0}  state:{1}  errorCode:{2} extendedData{3}", roomId, state, errorCode, extendedData));
                context.Post(new SendOrPostCallback((o) =>
                {
                    if (enginePtr != null)
                    {
                        enginePtr.onRoomStateUpdate(roomId, state, errorCode, extendedData);
                    }
                }), null);

            }
        }

        public static void zego_on_debug_error(int error_code, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string func_name, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string info, System.IntPtr user_context)
        {
            if (enginePtr == null || enginePtr.onDebugError == null) return;
            if (context != null)
            {
                Console.WriteLine(string.Format("onDebugError error_code:{0} func_name:{1} info:{2}", error_code, func_name, info));
                context.Post(new SendOrPostCallback((o) =>
                {
                    if (enginePtr != null)
                    {
                        enginePtr.onDebugError(error_code, func_name, info);
                    }
                }), null);
            }
        }

        public static void zego_on_room_stream_extra_info_update([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string room_id, System.IntPtr stream_info_list, uint stream_info_count, System.IntPtr user_context)
        {
            if (enginePtr == null || enginePtr.onRoomStreamExtraInfoUpdate == null) return;
            zego_stream[] zego_streams = new zego_stream[stream_info_count];
            ZegoUtil.GetStructListByPtr<zego_stream>(ref zego_streams, stream_info_list, stream_info_count);//get StructLists by pointer
            List<ZegoStream> result = ChangeZegoStreamStructListToClassList(zego_streams);
            Console.WriteLine(string.Format("onRoomStreamExtraInfoUpdate room_id:{0}  stream_info_count:{1}", room_id, stream_info_count));
            if (context != null)
            {
                context.Post(new SendOrPostCallback((o) =>
                {
                    if (enginePtr != null)
                    {
                        enginePtr.onRoomStreamExtraInfoUpdate(room_id, result);
                    }
                }), null);
            }


        }
        public override void StartPublishingStream(string streamID, ZegoPublishChannel channel = ZegoPublishChannel.Main)
        {
            if (enginePtr != null)
            {
                int error_code = IExpressPublisherInternal.zego_express_start_publishing_stream(streamID, channel);
                Console.WriteLine(string.Format("StartPublishingStream streamID:{0} channel:{1} result:{2}", streamID, channel, error_code));
            }
        }
        public override void StopPublishingStream(ZegoPublishChannel channel = ZegoPublishChannel.Main)
        {
            if (enginePtr != null)
            {
                int error_code = IExpressPublisherInternal.zego_express_stop_publishing_stream(channel);
                Console.WriteLine(string.Format("StopPublishingStream channel:{0} result:{1}", channel, error_code));
            }
        }
        public override void SendBarrageMessage(string roomID, string message, OnIMSendBarrageMessageResult onIMSendBarrageMessageResult)
        {
            if (enginePtr != null)
            {

                int result = IExpressIMInternal.zego_express_send_barrage_message(roomID, message);
                Console.WriteLine(string.Format("SendBarrageMessage roomID:{0}  message:{1} result:{2}", roomID, message, result));
                lock (zegoExpressEngineLock)
                {
                    if (onIMSendBarrageMessageResultDics.ContainsKey(result))
                    {
                        onIMSendBarrageMessageResultDics[result] = onIMSendBarrageMessageResult;
                    }
                    else
                    {
                        onIMSendBarrageMessageResultDics.Add(result, onIMSendBarrageMessageResult);
                    }
                }

            }
        }


        public override void SendBroadcastMessage(string roomID, string message, OnIMSendBroadcastMessageResult onIMSendBroadcastMessageResult)
        {
            if (enginePtr != null)
            {
                int result = IExpressIMInternal.zego_express_send_broadcast_message(roomID, message);
                Console.WriteLine(string.Format("SendBroadcastMessage roomID:{0}  message:{1} result:{2}", roomID, message, result));
                lock (zegoExpressEngineLock)
                {
                    if (onIMSendBroadcastMessageResultDics.ContainsKey(result))
                    {
                        onIMSendBroadcastMessageResultDics[result] = onIMSendBroadcastMessageResult;
                    }
                    else
                    {
                        onIMSendBroadcastMessageResultDics.Add(result, onIMSendBroadcastMessageResult);
                    }
                }
            }
        }
        public override void SetStreamExtraInfo(string extraInfo, OnPublisherSetStreamExtraInfoResult onPublisherSetStreamExtraInfoResult, ZegoPublishChannel channel = ZegoPublishChannel.Main)
        {
            if (enginePtr != null)
            {

                int result = IExpressPublisherInternal.zego_express_set_stream_extra_info(extraInfo, channel);
                Console.WriteLine(string.Format("SetStreamExtraInfo extraInfo:{0}  channel:{1} result:{2}", extraInfo, channel, result));
                lock (zegoExpressEngineLock)
                {
                    if (onPublisherSetStreamExtraInfoResultDics.ContainsKey(result))
                    {
                        onPublisherSetStreamExtraInfoResultDics[result] = onPublisherSetStreamExtraInfoResult;
                    }
                    else
                    {
                        onPublisherSetStreamExtraInfoResultDics.Add(result, onPublisherSetStreamExtraInfoResult);
                    }
                }
            }
        }
        public override void SendCustomCommand(string roomID, string command, List<ZegoUser> toUserList, OnIMSendCustomCommandResult onIMSendCustomCommandResult)
        {
            if (enginePtr != null)
            {

                zego_user[] zegoUsers = ChangeZegoUserClassListToStructList(toUserList);
                int result = IExpressIMInternal.zego_express_send_custom_command(roomID, command, zegoUsers, (uint)zegoUsers.Length);
                Console.WriteLine(string.Format("SendCustomCommand roomID:{0}  command:{1} result:{2}", roomID, command, result));
                lock (zegoExpressEngineLock)
                {
                    if (onIMSendCustomCommandResultDics.ContainsKey(result))
                    {
                        onIMSendCustomCommandResultDics[result] = onIMSendCustomCommandResult;
                    }
                    else
                    {
                        onIMSendCustomCommandResultDics.Add(result, onIMSendCustomCommandResult);
                    }
                }
            }
        }
        public override void AddPublishCdnUrl(string streamID, string targetURL, OnPublisherUpdateCdnUrlResult onPublisherUpdateCdnUrlResult)
        {
            if (enginePtr != null)
            {

                int result = IExpressPublisherInternal.zego_express_add_publish_cdn_url(streamID, targetURL);
                Console.WriteLine(string.Format("AddPublishCdnUrl streamID:{0} targetURL:{1} result:{2}", streamID, targetURL, result));
                lock (zegoExpressEngineLock)
                {
                    if (onPublisherUpdateCdnUrlResultDics.ContainsKey(result))
                    {
                        onPublisherUpdateCdnUrlResultDics[result] = onPublisherUpdateCdnUrlResult;
                    }
                    else
                    {
                        onPublisherUpdateCdnUrlResultDics.Add(result, onPublisherUpdateCdnUrlResult);
                    }
                }
            }
        }
        public override void EnableCustomVideoRender(bool enable, ZegoCustomVideoRenderConfig config)
        {
            if (enginePtr != null)
            {
                zego_custom_video_render_config zegoCustomVideo = ChangeZegoCustomVideoRenderConfigClassToStruct(config);
                IntPtr ptr = ZegoUtil.GetStructPointer(zegoCustomVideo);
                int result = IExpressCustomVideoInternal.zego_express_enable_custom_video_render(enable, ptr);
                ZegoUtil.ReleaseStructPointer(ptr);
                Console.WriteLine(string.Format("EnableCustomVideoRender enable:{0}  result:{1}", enable, result));
            }
        }

        private zego_custom_video_render_config ChangeZegoCustomVideoRenderConfigClassToStruct(ZegoCustomVideoRenderConfig config)
        {
            zego_custom_video_render_config customVideoRenderConfig = new zego_custom_video_render_config();
            if (config != null)
            {
                customVideoRenderConfig.type = config.bufferType;
                customVideoRenderConfig.series = config.frameFormatSeries;
                customVideoRenderConfig.is_internal_render = config.enableEngineRender;
            }
            return customVideoRenderConfig;
        }

        public override void RemovePublishCdnUrl(string streamID, string targetURL, OnPublisherUpdateCdnUrlResult onPublisherUpdateCdnUrlResult)
        {
            if (enginePtr != null)
            {

                int result = IExpressPublisherInternal.zego_express_remove_publish_cdn_url(streamID, targetURL);
                Console.WriteLine(string.Format("RemovePublishCdnUrl streamID:{0} targetURL:{1} result:{2}", streamID, targetURL, result));
                lock (zegoExpressEngineLock)
                {
                    if (onPublisherUpdateCdnUrlResultDics.ContainsKey(result))
                    {
                        onPublisherUpdateCdnUrlResultDics[result] = onPublisherUpdateCdnUrlResult;
                    }
                    else
                    {
                        onPublisherUpdateCdnUrlResultDics.Add(result, onPublisherUpdateCdnUrlResult);
                    }
                }
            }
        }

        private zego_user[] ChangeZegoUserClassListToStructList(List<ZegoUser> toUserList)
        {
            zego_user[] zegoUsers;
            if (toUserList == null)
            {
                throw new Exception("SendCustomCommand toUserList should not be null");
            }
            else
            {
                zegoUsers = new zego_user[toUserList.Count];
                for (int i = 0; i < toUserList.Count; i++)
                {
                    zegoUsers[i] = ChangeZegoUserClassToStruct(toUserList[i]);
                }
            }
            return zegoUsers;
        }

        public static void Stop(ZegoMediaPlayer zegoMediaPlayer)
        {
            if (enginePtr != null)
            {
                ZegoMediaPlayerInstanceIndex index = GetIndexFromZegoMediaPlayer(zegoMediaPlayer);
                int result = IExpressMediaPlayerInternal.zego_express_media_player_stop(index);
                Console.WriteLine(string.Format("MediaPlayer Stop index:{0}  result:{1} ", index, result));
            }
        }

        public static ZegoMediaPlayerState GetCurrentState(ZegoMediaPlayer zegoMediaPlayer)
        {
            ZegoMediaPlayerState state = ZegoMediaPlayerState.NoPlay;
            if (enginePtr != null)
            {
                ZegoMediaPlayerInstanceIndex index = GetIndexFromZegoMediaPlayer(zegoMediaPlayer);
                state = IExpressMediaPlayerInternal.zego_express_media_player_get_current_state(index);
                Console.WriteLine(string.Format("MediaPlayer GetCurrentState index:{0}  result:{1} ", index, state));
            }
            return state;
        }

        public static void Resume(ZegoMediaPlayer zegoMediaPlayer)
        {
            if (enginePtr != null)
            {
                ZegoMediaPlayerInstanceIndex index = GetIndexFromZegoMediaPlayer(zegoMediaPlayer);
                int result = IExpressMediaPlayerInternal.zego_express_media_player_resume(index);
                Console.WriteLine(string.Format("MediaPlayer Resume index:{0}  result:{1} ", index, result));
            }
        }

        public static void SeekTo(ZegoMediaPlayer zegoMediaPlayer, ulong millisecond, ZegoMediaPlayer.OnSeekToTimeCallback onSeekToTimeCallback)
        {
            if (enginePtr != null)
            {
                ZegoMediaPlayerInstanceIndex index = GetIndexFromZegoMediaPlayer(zegoMediaPlayer);
                int seq = IExpressMediaPlayerInternal.zego_express_media_player_seek_to(millisecond, index);
                Console.WriteLine(string.Format("MediaPlayer SeekTo index:{0} millisecond:{1} result:{2} ", index, millisecond, seq));
                lock (zegoExpressEngineMediaPlayerLock)
                {
                    if (zegoMediaPlayer.seekToTimeCallbackDic.ContainsKey(seq))
                    {
                        zegoMediaPlayer.seekToTimeCallbackDic[seq] = onSeekToTimeCallback;
                    }
                    else
                    {
                        zegoMediaPlayer.seekToTimeCallbackDic.Add(seq, onSeekToTimeCallback);
                    }
                }
            }
        }
        public override void DestroyMediaPlayer(ZegoMediaPlayer mediaPlayer)
        {
            if (enginePtr != null)
            {
                ZegoMediaPlayerInstanceIndex index = GetIndexFromZegoMediaPlayer(mediaPlayer);
                int result = IExpressMediaPlayerInternal.zego_express_destroy_media_player(index);
                Console.WriteLine(string.Format("MediaPlayer MuteLocal index:{0} result:{1} ", index, result));
                mediaPlayer.seekToTimeCallbackDic.Clear();
                mediaPlayerAndIndex.Remove(index);
            }
        }
        public static void MuteLocal(ZegoMediaPlayer zegoMediaPlayer, bool mute)
        {
            if (enginePtr != null)
            {
                ZegoMediaPlayerInstanceIndex index = GetIndexFromZegoMediaPlayer(zegoMediaPlayer);
                int result = IExpressMediaPlayerInternal.zego_express_media_player_mute_local_audio(mute, index);
                Console.WriteLine(string.Format("MediaPlayer MuteLocal index:{0} mute:{1} result:{2} ", index, mute, result));
            }
        }

        public static void SetPlayerCanvas(ZegoMediaPlayer zegoMediaPlayer, ZegoCanvas canvas)
        {
            if (enginePtr != null)
            {
                ZegoMediaPlayerInstanceIndex index = GetIndexFromZegoMediaPlayer(zegoMediaPlayer);
                zego_canvas zegoCanvas = ChangeZegoCanvasClassToStruct(canvas);
                IntPtr ptr = ZegoUtil.GetStructPointer(zegoCanvas);
                int result = IExpressMediaPlayerInternal.zego_express_media_player_set_player_canvas(ptr, index);
                Console.WriteLine(string.Format("MediaPlayer SetPlayerCanvas index:{0}  result:{1} ", index, result));
                ZegoUtil.ReleaseStructPointer(ptr);
            }
        }

        public static void SetVolume(ZegoMediaPlayer zegoMediaPlayer, int volume)
        {
            if (enginePtr != null)
            {
                ZegoMediaPlayerInstanceIndex index = GetIndexFromZegoMediaPlayer(zegoMediaPlayer);
                int result = IExpressMediaPlayerInternal.zego_express_media_player_set_volume(volume, index);
                Console.WriteLine(string.Format("MediaPlayer SetVolume index:{0} volume:{1} result:{2} ", index, volume, result));
            }
        }

        public static void SetProgressInterval(ZegoMediaPlayer zegoMediaPlayer, ulong millisecond)
        {
            if (enginePtr != null)
            {
                ZegoMediaPlayerInstanceIndex index = GetIndexFromZegoMediaPlayer(zegoMediaPlayer);
                int result = IExpressMediaPlayerInternal.zego_express_media_player_set_progress_interval(millisecond, index);
                Console.WriteLine(string.Format("MediaPlayer SetProgressInterval index:{0} millisecond:{1} result:{2} ", index, millisecond, result));
            }
        }

        public static ulong GetTotalDuration(ZegoMediaPlayer zegoMediaPlayer)
        {
            ulong result = 0;
            if (enginePtr != null)
            {
                ZegoMediaPlayerInstanceIndex index = GetIndexFromZegoMediaPlayer(zegoMediaPlayer);
                result = IExpressMediaPlayerInternal.zego_express_media_player_get_total_duration(index);
                Console.WriteLine(string.Format("MediaPlayer GetTotalDuration index:{0} result:{1} ", index, result));

            }
            return result;
        }

        public static ulong GetCurrentProgress(ZegoMediaPlayer zegoMediaPlayer)
        {
            ulong result = 0;
            if (enginePtr != null)
            {
                ZegoMediaPlayerInstanceIndex index = GetIndexFromZegoMediaPlayer(zegoMediaPlayer);
                result = IExpressMediaPlayerInternal.zego_express_media_player_get_current_progress(index);
                Console.WriteLine(string.Format("MediaPlayer GetCurrentProgress index:{0} result:{1} ", index, result));

            }
            return result;
        }

        public static int GetIndex(ZegoMediaPlayer zegoMediaPlayer)
        {
            ZegoMediaPlayerInstanceIndex index = ZegoMediaPlayerInstanceIndex.Null;
            if (enginePtr != null)
            {
                index = GetIndexFromZegoMediaPlayer(zegoMediaPlayer);
                Console.WriteLine(string.Format("MediaPlayer GetIndex  index:{0} ", index));

            }
            return (int)index;
        }

        public static int GetVolume(ZegoMediaPlayer zegoMediaPlayer)
        {
            int result = 0;
            if (enginePtr != null)
            {
                ZegoMediaPlayerInstanceIndex index = GetIndexFromZegoMediaPlayer(zegoMediaPlayer);
                result = IExpressMediaPlayerInternal.zego_express_media_player_get_volume(index);
                Console.WriteLine(string.Format("MediaPlayer GetVolume index:{0} result:{1} ", index, result));

            }
            return result;
        }

        public static void EnableAux(ZegoMediaPlayer zegoMediaPlayer, bool enable)
        {
            if (enginePtr != null)
            {
                ZegoMediaPlayerInstanceIndex index = GetIndexFromZegoMediaPlayer(zegoMediaPlayer);
                int result = IExpressMediaPlayerInternal.zego_express_media_player_enable_aux(enable, index);
                Console.WriteLine(string.Format("MediaPlayer EnableAux index:{0} result:{1} enable{2}", index, result, enable));
            }
        }

        public static void Pause(ZegoMediaPlayer zegoMediaPlayer)
        {
            if (enginePtr != null)
            {
                ZegoMediaPlayerInstanceIndex index = GetIndexFromZegoMediaPlayer(zegoMediaPlayer);
                int result = IExpressMediaPlayerInternal.zego_express_media_player_pause(index);
                Console.WriteLine(string.Format("MediaPlayer Pause index:{0} result:{1}", index, result));
            }
        }

        public static void Start(ZegoMediaPlayer zegoMediaPlayer)
        {
            if (enginePtr != null)
            {
                ZegoMediaPlayerInstanceIndex index = GetIndexFromZegoMediaPlayer(zegoMediaPlayer);
                int result = IExpressMediaPlayerInternal.zego_express_media_player_start(index);
                Console.WriteLine(string.Format("MediaPlayer Start index:{0} result:{1}", index, result));
            }
        }

        public static void EnableRepeat(ZegoMediaPlayer zegoMediaPlayer, bool enable)
        {
            if (enginePtr != null)
            {
                ZegoMediaPlayerInstanceIndex index = GetIndexFromZegoMediaPlayer(zegoMediaPlayer);
                int result = IExpressMediaPlayerInternal.zego_express_media_player_enable_repeat(enable, index);
                Console.WriteLine(string.Format("EnableRepeat enable:{0} result:{1}", enable, result));
            }
        }

        public static void zego_on_publisher_state_update(string streamId, ZegoPublisherState state, int errorCode, string extendedData, System.IntPtr user_Context)
        {
            if (enginePtr == null || enginePtr.onPublisherStateUpdate == null) return;

            Console.WriteLine(string.Format("onPublisherStateUpdate streamId:{0}  state:{1}  errorCode:{2} extendedData{3}", streamId, state, errorCode, extendedData));
            if (context != null)
            {
                context.Post(new SendOrPostCallback((o) =>
                {
                    if (enginePtr != null)
                    {
                        enginePtr.onPublisherStateUpdate(streamId, state, errorCode, extendedData);
                    }
                }), null);
            }



        }

        public static void LoadResource(ZegoMediaPlayer zegoMediaPlayer, string path)
        {
            if (enginePtr != null)
            {
                ZegoMediaPlayerInstanceIndex curIndex = GetIndexFromZegoMediaPlayer(zegoMediaPlayer);
                int result = IExpressMediaPlayerInternal.zego_express_media_player_load_resource(path, curIndex);
                Console.WriteLine(string.Format("LoadResource result:{0}  path:{1} ", result, path));
            }
        }
        private static ZegoMediaPlayerInstanceIndex GetIndexFromZegoMediaPlayer(ZegoMediaPlayer zegoMediaPlayer)
        {
            ZegoMediaPlayerInstanceIndex result = ZegoMediaPlayerInstanceIndex.Null;
            foreach (KeyValuePair<ZegoMediaPlayerInstanceIndex, ZegoMediaPlayer> kvp in mediaPlayerAndIndex)
            {
                if (kvp.Value == zegoMediaPlayer)
                {
                    result = kvp.Key;
                }
            }
            if (result == ZegoMediaPlayerInstanceIndex.Null)
            {
                throw new Exception("GetIndexFromZegoMediaPlayer found null，Maybe you have already release the mediaplayer");
            }
            else
            {
                return result;
            }
        }
        public static void zego_on_publisher_update_cdn_url_result([System.Runtime.InteropServices.InAttribute()] [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string stream_id, int error_code, int seq, System.IntPtr user_context)
        {
            if (enginePtr == null || onPublisherUpdateCdnUrlResultDics == null) return;
            Console.WriteLine(string.Format("onPublisherUpdateCdnUrlResult streamId:{0}  errorCode:{1} seq{2}", stream_id, error_code, seq));
            OnPublisherUpdateCdnUrlResult onPublisherUpdateCdnUrlResult = GetCallbackFromSeq<OnPublisherUpdateCdnUrlResult>(onPublisherUpdateCdnUrlResultDics, seq);

            if (context != null)
            {
                context.Post(new SendOrPostCallback((o) =>
                {
                    onPublisherUpdateCdnUrlResult(error_code);
                    onPublisherUpdateCdnUrlResultDics.Remove(seq);
                }), null);
            }

        }


        public static void zego_on_publisher_relay_cdn_state_update([System.Runtime.InteropServices.InAttribute()] [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string stream_id, System.IntPtr cdn_info_list, uint info_count, System.IntPtr user_context)
        {
            if (enginePtr == null || enginePtr.onPublisherRelayCDNStateUpdate == null) return;
            zego_stream_relay_cdn_info[] infos = new zego_stream_relay_cdn_info[info_count];
            ZegoUtil.GetStructListByPtr<zego_stream_relay_cdn_info>(ref infos, cdn_info_list, info_count);//get StructLists by pointer
            List<ZegoStreamRelayCDNInfo> infoList = ChangeZegoStreamRelayCDNInfoStructListToClassList(infos);

            Console.WriteLine(string.Format("onPublisherRelayCDNStateUpdate streamId:{0}  info_count:{1}", stream_id, info_count));
            if (context != null)
            {
                context.Post(new SendOrPostCallback((o) =>
                {
                    if (enginePtr != null)
                    {
                        enginePtr.onPublisherRelayCDNStateUpdate(stream_id, infoList);
                    }
                }), null);
            }


        }

        private static List<ZegoStreamRelayCDNInfo> ChangeZegoStreamRelayCDNInfoStructListToClassList(zego_stream_relay_cdn_info[] infos)
        {
            List<ZegoStreamRelayCDNInfo> lists = new List<ZegoStreamRelayCDNInfo>();
            for (int i = 0; i < infos.Length; i++)
            {
                lists.Add(ChangeZegoStreamRelayCDNInfoStructToClass(infos[i]));
            }
            return lists;
        }

        private static ZegoStreamRelayCDNInfo ChangeZegoStreamRelayCDNInfoStructToClass(zego_stream_relay_cdn_info zego_stream_relay_cdn_info)
        {
            ZegoStreamRelayCDNInfo zegoStreamRelayCDNInfo = new ZegoStreamRelayCDNInfo();
            zegoStreamRelayCDNInfo.cdnState = zego_stream_relay_cdn_info.cdn_state;
            zegoStreamRelayCDNInfo.updateReason = zego_stream_relay_cdn_info.update_reason;
            zegoStreamRelayCDNInfo.stateTime = zego_stream_relay_cdn_info.state_time;
            zegoStreamRelayCDNInfo.url = zego_stream_relay_cdn_info.url;
            return zegoStreamRelayCDNInfo;
        }

        public override void StartPreview(ZegoCanvas zegoCanvas, ZegoPublishChannel channel = ZegoPublishChannel.Main)
        {
            if (enginePtr != null)
            {
                zego_canvas canvas = ChangeZegoCanvasClassToStruct(zegoCanvas);
                IntPtr ptr = ZegoUtil.GetStructPointer(canvas);
                int result = IExpressPublisherInternal.zego_express_start_preview(ptr, channel);
                ZegoUtil.ReleaseStructPointer(ptr);
                Console.WriteLine(string.Format("StartPreview  channel:{0} result:{1}", channel, result));

            }
        }

        private static zego_canvas ChangeZegoCanvasClassToStruct(ZegoCanvas zegoCanvas)
        {
            if (zegoCanvas == null)
            {
                throw new Exception("StartPreview ZegoCanvas should not be null");
            }
            else
            {
                zego_canvas result = new zego_canvas();
                result.background_color = zegoCanvas.backgroundColor;
                result.view = zegoCanvas.view;
                result.view_mode = zegoCanvas.viewMode;
                return result;
            }
        }

        public override void StopPreview(ZegoPublishChannel channel = ZegoPublishChannel.Main)
        {
            if (enginePtr != null)
            {
                int result = IExpressPublisherInternal.zego_express_stop_preview(channel);
                Console.WriteLine(string.Format("StopPreview  channel:{0} result:{1}", channel, result));

            }
        }
        public override void StartPlayingStream(string streamId, ZegoCanvas canvas, ZegoPlayerConfig config = null)
        {
            if (enginePtr != null)
            {
                int result = 0;
                zego_canvas zegoCanvas = ChangeZegoCanvasClassToStruct(canvas);
                IntPtr ptr = ZegoUtil.GetStructPointer(zegoCanvas);
                if (config != null)
                {
                    zego_player_config zegoPlayerConfig = ChangeZegoPlayerConfigClassToStruct(config);
                    result = IExpressPlayerInternal.zego_express_start_playing_stream_with_config(streamId, ptr, zegoPlayerConfig);
                    ZegoUtil.ReleaseStructPointer(zegoPlayerConfig.cdn_config);
                }
                else
                {
                    Console.WriteLine("StartPlayingStream ZegoPlayerConfig is null");
                    result = IExpressPlayerInternal.zego_express_start_playing_stream(streamId, ptr);
                }
                Console.WriteLine(string.Format("StartPlayingStream streamId:{0} result:{1}", streamId, result));
            }
        }

        private zego_player_config ChangeZegoPlayerConfigClassToStruct(ZegoPlayerConfig config)
        {
            zego_player_config zegoPlayerConfig;
            if (config == null)
            {
                throw new Exception("ZegoPlayerConfig should not be null");
            }
            else
            {
                zegoPlayerConfig = new zego_player_config();
                zegoPlayerConfig.cdn_config = ZegoUtil.GetStructPointer(ChangeCDNConfigClassToStruct(config.cDNConfig));
                zegoPlayerConfig.video_layer = config.videoLayer;
                Console.WriteLine(string.Format("StartPlayingStream ZegoPlayerConfig url:{0} authParam:{1} video_layer{2}", config.cDNConfig.url, config.cDNConfig.authParam, config.videoLayer));
                return zegoPlayerConfig;
            }

        }

        private zego_cdn_config ChangeCDNConfigClassToStruct(ZegoCDNConfig cDNConfig)
        {
            zego_cdn_config config = new zego_cdn_config();
            if (cDNConfig != null)
            {
                config.auth_param = cDNConfig.authParam;
                config.url = cDNConfig.url;
            }
            return config;
        }

        public override void EnablePublishDirectToCDN(bool enable, ZegoCDNConfig config, ZegoPublishChannel channel = ZegoPublishChannel.Main)
        {
            if (enginePtr != null)
            {
                IntPtr ptr = ZegoUtil.GetStructPointer(ChangeCDNConfigClassToStruct(config));
                int result = IExpressPublisherInternal.zego_express_enable_publish_direct_to_cdn(enable, ptr, channel);
                ZegoUtil.ReleaseStructPointer(ptr);
                Console.WriteLine(string.Format("EnablePublishDirectToCDN enable:{0} channel:{1} result:{2}", enable, channel, result));
            }
        }

        public override void SetAppOrientation(ZegoOrientation orientation, ZegoPublishChannel channel = ZegoPublishChannel.Main)//设置采集视频的朝向（仅Android平台）,逆时针
        {
            if (enginePtr != null)
            {
                int result = IExpressPublisherInternal.zego_express_set_app_orientation(orientation, channel);
                Console.WriteLine(string.Format("SetAppOrientation orientation:{0} channel:{1} result:{2}", orientation, channel, result));
            }
        }


        public static void zego_on_player_state_update(string streamId, ZegoPlayerState state, int errorCode, string extendedData, System.IntPtr userContext)
        {
            if (enginePtr == null || enginePtr.onPlayerStateUpdate == null) return;

            Console.WriteLine(string.Format("onPlayerStateUpdate streamId:{0}  state:{1} errorCode:{2} extendedData:{3}", streamId, state, errorCode, extendedData));
            if (context != null)
            {
                context.Post(new SendOrPostCallback((o) =>
                {
                    if (enginePtr != null)
                    {
                        enginePtr.onPlayerStateUpdate(streamId, state, errorCode, extendedData);
                    }
                }), null);
            }



        }

        public static void zego_on_publisher_quality_update([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string streamId, zego_publish_stream_quality quality, System.IntPtr userContext)
        {
            if (enginePtr == null || enginePtr.onPublisherQualityUpdate == null) return;
            ZegoPublishStreamQuality result = ChangePublishQualityToClass(quality);

            Console.WriteLine(string.Format("onPublisherQualityUpdate streamId:{0} quality:{1}", streamId, quality));
            if (context != null)
            {
                context.Post(new SendOrPostCallback((o) =>
                {
                    if (enginePtr != null)
                    {
                        enginePtr.onPublisherQualityUpdate(streamId, result);
                    }
                }), null);
            }



        }
        private static ZegoPublishStreamQuality ChangePublishQualityToClass(zego_publish_stream_quality quality)
        {
            ZegoPublishStreamQuality publishStreamQuality = new ZegoPublishStreamQuality();
            publishStreamQuality.quality = quality.quality;
            publishStreamQuality.videoCaptureFps = quality.video_capture_fps;
            publishStreamQuality.videoEncodeFps = quality.video_encode_fps;
            publishStreamQuality.videoSendFps = quality.video_send_fps;
            publishStreamQuality.videoKbps = quality.video_kbps;

            publishStreamQuality.audioCaptureFps = quality.audio_capture_fps;
            publishStreamQuality.audioSendFps = quality.audio_send_fps;
            publishStreamQuality.audioKbps = quality.audio_kbps;
            publishStreamQuality.rtt = quality.rtt;
            publishStreamQuality.packetLostRate = quality.packet_lost_rate;
            publishStreamQuality.isHardwareEncode = quality.is_hardware_encode;
            publishStreamQuality.totalSendBytes = quality.total_send_bytes;
            publishStreamQuality.audioSendBytes = quality.audio_send_bytes;
            publishStreamQuality.videoSendBytes = quality.video_send_bytes;
            return publishStreamQuality;
        }

        public static void zego_on_publisher_recv_audio_captured_first_frame(System.IntPtr userContext)
        {
            if (enginePtr == null || enginePtr.onPublisherCapturedAudioFirstFrame == null) return;

            if (context != null)
            {
                context.Post(new SendOrPostCallback((o) =>
                {
                    if (enginePtr != null)
                    {
                        enginePtr.onPublisherCapturedAudioFirstFrame();
                    }
                }), null);
            }



        }

        public static void zego_on_publisher_recv_video_captured_first_frame(ZegoPublishChannel channel, System.IntPtr userContext)
        {
            if (enginePtr == null || enginePtr.onPublisherCapturedVideoFirstFrame == null) return;
            if (context != null)
            {
                context.Post(new SendOrPostCallback((o) =>
                {
                    if (enginePtr != null)
                    {
                        enginePtr.onPublisherCapturedVideoFirstFrame(channel);
                    }
                }), null);
            }



        }

        public static void zego_on_publisher_video_size_changed(int width, int height, ZegoPublishChannel channel, System.IntPtr userContext)
        {
            if (enginePtr == null || enginePtr.onPublisherVideoSizeChanged == null) return;

            Console.WriteLine(string.Format("onPublisherVideoSizeChanged width:{0} height:{1} channel{2}", width, height, channel));
            if (context != null)
            {
                context.Post(new SendOrPostCallback((o) =>
                {
                    if (enginePtr != null)
                    {
                        enginePtr.onPublisherVideoSizeChanged(width, height, channel);
                    }
                }), null);
            }



        }

        public static void zego_on_room_user_update([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string roomId, ZegoUpdateType updateType, IntPtr userList, uint userCount, System.IntPtr userContext)
        {
            if (enginePtr == null || enginePtr.onRoomUserUpdate == null) return;
            zego_user[] users = new zego_user[userCount];
            ZegoUtil.GetStructListByPtr<zego_user>(ref users, userList, userCount);//get StructLists by pointer
            List<ZegoUser> result = ChangeZegoUserStructListToClassList(users);

            Console.WriteLine(string.Format("onRoomUserUpdate roomId:{0} updateType:{1} userCount{2}", roomId, updateType, userCount));
            if (context != null)
            {
                context.Post(new SendOrPostCallback((o) =>
                {
                    if (enginePtr != null)
                    {
                        enginePtr.onRoomUserUpdate(roomId, updateType, result, userCount);
                    }
                }), null);
            }


        }
        public override void StartMixerTask(ZegoMixerTask task, OnMixerStartResult onMixerStartResult)
        {
            if (enginePtr != null)
            {
                zego_mixer_task zego_Mixer_Task = ChangeZegoMixerTaskClassToStruct(task);
                int result = IExpressMixerInternal.zego_express_start_mixer_task(zego_Mixer_Task);
                Console.WriteLine(string.Format("StartMixerTask  result:{0}", result));
                ZegoUtil.ReleaseAllStructPointers(arrayList);
                ZegoUtil.ReleaseStructPointer(zego_Mixer_Task.watermark);
                lock (zegoExpressEngineLock)
                {
                    if (onMixerStartResultDics.ContainsKey(result))
                    {
                        onMixerStartResultDics[result] = onMixerStartResult;
                    }
                    else
                    {
                        onMixerStartResultDics.Add(result, onMixerStartResult);
                    }
                }
            }
        }

        private zego_mixer_task ChangeZegoMixerTaskClassToStruct(ZegoMixerTask task)
        {
            arrayList = new ArrayList();
            zego_mixer_task result = new zego_mixer_task();
            if (task == null)
            {
                throw new Exception("ZegoMixerTask Class should not be null");
            }
            else
            {
                result.task_id = task.taskId;
                zego_mixer_input[] zego_Mixer_Inputs = ChangeZegoMixerInputClassListToStructList(task.inputList);
                result.input_list_count = (uint)zego_Mixer_Inputs.Length;
                IntPtr inputListPtr = GetMixerInputListPtr(zego_Mixer_Inputs);
                arrayList.Add(inputListPtr);
                result.input_list = inputListPtr;
                zego_mixer_output[] zego_Mixer_Outputs = ChangeZegoMixerOutputClassListToStructList(task.outputList);
                result.output_list_count = (uint)zego_Mixer_Outputs.Length;
                IntPtr outPutListPtr = GetMixerOutputListPtr(zego_Mixer_Outputs);
                arrayList.Add(outPutListPtr);
                result.output_list = outPutListPtr;
                result.audio_config = ChangeZegoMixerAudioConfigClassToStruct(task.audioConfig);
                result.video_config = ChangeZegoMixerVideoConfigClassToStruct(task.videoConfig);
                if (task.watermark != null)
                {
                    result.watermark = ZegoUtil.GetStructPointer(ChangeWaterMarkClassToStruct(task.watermark));
                }
                result.background_image_url = task.backgroundImageUrl;
                result.enable_sound_level = task.enableSoundLevel;
            }
            return result;
        }

        private IntPtr GetMixerOutputListPtr(zego_mixer_output[] zego_Mixer_Outputs)
        {
            int size = Marshal.SizeOf(typeof(zego_mixer_output));
            IntPtr result = Marshal.AllocHGlobal(zego_Mixer_Outputs.Length * size);
            long LongPtr = result.ToInt64();
            for (int i = 0; i < zego_Mixer_Outputs.Length; i++)
            {
                IntPtr a = new IntPtr(LongPtr);
                Marshal.StructureToPtr(zego_Mixer_Outputs[i], a, false);
                LongPtr += Marshal.SizeOf(typeof(zego_mixer_output));
            }
            return result;
        }

        private IntPtr GetMixerInputListPtr(zego_mixer_input[] zego_Mixer_Inputs)
        {
            int size = Marshal.SizeOf(typeof(zego_mixer_input));
            IntPtr result = Marshal.AllocHGlobal(zego_Mixer_Inputs.Length * size);
            long LongPtr = result.ToInt64();
            for (int i = 0; i < zego_Mixer_Inputs.Length; i++)
            {
                IntPtr a = new IntPtr(LongPtr);
                Marshal.StructureToPtr(zego_Mixer_Inputs[i], a, false);
                LongPtr += Marshal.SizeOf(typeof(zego_mixer_input));
            }
            return result;
        }


        private zego_mixer_video_config ChangeZegoMixerVideoConfigClassToStruct(ZegoMixerVideoConfig videoConfig)
        {
            zego_mixer_video_config config = new zego_mixer_video_config();
            if (videoConfig != null)
            {
                config.bitrate = videoConfig.bitrate;
                config.fps = videoConfig.fps;
                config.resolution_height = videoConfig.resolutionHeight;
                config.resolution_width = videoConfig.resolutionWidth;
            }
            return config;
        }

        private zego_mixer_audio_config ChangeZegoMixerAudioConfigClassToStruct(ZegoMixerAudioConfig audioConfig)
        {
            zego_mixer_audio_config config = new zego_mixer_audio_config();
            if (audioConfig != null)
            {
                config.audio_codec_id = audioConfig.audioCodecId;
                config.channel = audioConfig.channel;
                config.bitrate = audioConfig.bitrate;
            }
            return config;
        }

        private zego_mixer_input[] ChangeZegoMixerInputClassListToStructList(List<ZegoMixerInput> inputList)
        {
            zego_mixer_input[] result = new zego_mixer_input[inputList.Count];
            if (inputList == null)
            {
                throw new Exception("List<ZegoMixerInput> should not be null");
            }
            else
            {
                for (int i = 0; i < inputList.Count; i++)
                {
                    zego_mixer_input zegoMixerInput = ChangeZegoMixerInputClassToStruct(inputList[i]);
                    result[i] = zegoMixerInput;
                }
                return result;

            }
        }

        private zego_mixer_input ChangeZegoMixerInputClassToStruct(ZegoMixerInput zegoMixerInput)
        {
            zego_mixer_input zego_Mixer_Input = new zego_mixer_input();
            if (zegoMixerInput != null)
            {
                zego_Mixer_Input.content_type = zegoMixerInput.contentType;
                zego_Mixer_Input.sound_level_id = zegoMixerInput.soundLevelId;
                zego_Mixer_Input.stream_id = zegoMixerInput.streamId;
                zego_Mixer_Input.layout = ChangeRectClassToStruct(zegoMixerInput.layout);
            }
            return zego_Mixer_Input;
        }
        private zego_mixer_output[] ChangeZegoMixerOutputClassListToStructList(List<ZegoMixerOutput> outputList)
        {
            zego_mixer_output[] result = new zego_mixer_output[outputList.Count];
            if (outputList == null)
            {
                throw new Exception("List<ZegoMixerOutput> should not be null");
            }
            else
            {
                for (int i = 0; i < outputList.Count; i++)
                {
                    zego_mixer_output zegoMixerOutput = ChangeZegoMixerOutputClassToStruct(outputList[i]);
                    result[i] = zegoMixerOutput;
                }
                return result;

            }
        }

        private zego_mixer_output ChangeZegoMixerOutputClassToStruct(ZegoMixerOutput zegoMixerOutput)
        {
            zego_mixer_output zego_Mixer_Output = new zego_mixer_output();
            zego_Mixer_Output.target = zegoMixerOutput.target;
            return zego_Mixer_Output;
        }

        public override void StopMixerTask(ZegoMixerTask task, OnMixerStopResult onMixerStopResult)
        {
            if (enginePtr != null)
            {
                zego_mixer_task zego_Mixer_Task = ChangeZegoMixerTaskClassToStruct(task);
                int result = IExpressMixerInternal.zego_express_stop_mixer_task(zego_Mixer_Task);
                Console.WriteLine(string.Format("StopMixerTask  result:{0}", result));
                ZegoUtil.ReleaseAllStructPointers(arrayList);
                ZegoUtil.ReleaseStructPointer(zego_Mixer_Task.watermark);
                lock (zegoExpressEngineLock)
                {
                    if (onMixerStopResultDics.ContainsKey(result))
                    {
                        onMixerStopResultDics[result] = onMixerStopResult;
                    }
                    else
                    {
                        onMixerStopResultDics.Add(result, onMixerStopResult);
                    }
                }
            }

        }
        private static List<ZegoUser> ChangeZegoUserStructListToClassList(zego_user[] users)
        {
            int length = users.Length;
            List<ZegoUser> zegoUsers = new List<ZegoUser>();
            for (int i = 0; i < length; i++)
            {
                zegoUsers.Add(ChangeZegoUserStructToClass(users[i]));
            }
            return zegoUsers;
        }
        private static ZegoUser ChangeZegoUserStructToClass(zego_user user)
        {
            ZegoUser zegoUser = new ZegoUser();
            zegoUser.userId =ZegoUtil.GetUTF8String(user.user_id);
            zegoUser.userName = ZegoUtil.GetUTF8String(user.user_name);
            return zegoUser;
        }

        public static void zego_on_room_stream_update([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string roomId, ZegoUpdateType updateType, System.IntPtr streamInfoList, uint streamInfoCount, System.IntPtr userContext)
        {
            if (enginePtr == null || enginePtr.onRoomStreamUpdate == null) return;
            zego_stream[] zego_streams = new zego_stream[streamInfoCount];
            ZegoUtil.GetStructListByPtr<zego_stream>(ref zego_streams, streamInfoList, streamInfoCount);//get StructLists by pointer
            List<ZegoStream> result = ChangeZegoStreamStructListToClassList(zego_streams);

            Console.WriteLine(string.Format("onRoomStreamUpdate roomId:{0} updateType:{1} userCount{2}", roomId, updateType, streamInfoList));
            if (context != null)
            {
                context.Post(new SendOrPostCallback((o) =>
                {
                    if (enginePtr != null)
                    {
                        enginePtr.onRoomStreamUpdate(roomId, updateType, result, streamInfoCount);
                    }
                }), null);
            }


        }

        private static List<ZegoStream> ChangeZegoStreamStructListToClassList(zego_stream[] streams)
        {
            int length = streams.Length;
            List<ZegoStream> zegoStreams = new List<ZegoStream>();
            for (int i = 0; i < length; i++)
            {
                zegoStreams.Add(ChangeZegoStreamStructToClass(streams[i]));
            }
            return zegoStreams;
        }
        private static ZegoStream ChangeZegoStreamStructToClass(zego_stream stream)
        {
            ZegoStream zegoStream = new ZegoStream();
            zegoStream.streamId = stream.stream_id;
            zegoStream.extraInfo = ZegoUtil.GetUTF8String(stream.extra_info);
            zegoStream.user = ChangeZegoUserStructToClass(stream.user);
            return zegoStream;
        }

        public static void zego_on_player_quality_update([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string streamId, zego_play_stream_quality quality, System.IntPtr userContext)
        {
            if (enginePtr == null || enginePtr.onPlayerQualityUpdate == null) return;
            ZegoPlayStreamQuality result = ChangePlayerQualityStructToClass(quality);
            if (context != null)
            {
                context.Post(new SendOrPostCallback((o) =>
                {
                    if (enginePtr != null)
                    {
                        enginePtr.onPlayerQualityUpdate(streamId, result);
                    }
                }), null);
            }



        }
        private static ZegoPlayStreamQuality ChangePlayerQualityStructToClass(zego_play_stream_quality quality)
        {
            ZegoPlayStreamQuality playStreamQuality = new ZegoPlayStreamQuality();
            playStreamQuality.quality = quality.quality;
            playStreamQuality.videoRecvFps = quality.video_recv_fps;
            playStreamQuality.videoDecodeFps = quality.video_decode_fps;
            playStreamQuality.videoRenderFps = quality.video_render_fps;
            playStreamQuality.videoKbps = quality.video_kbps;
            playStreamQuality.audioRecvFps = quality.audio_recv_fps;
            playStreamQuality.audioDecodeFps = quality.audio_decode_fps;
            playStreamQuality.audioRenderFps = quality.audio_render_fps;
            playStreamQuality.audioKbps = quality.audio_kbps;
            playStreamQuality.rtt = quality.rtt;
            playStreamQuality.packetLostRate = quality.packet_lost_rate;
            playStreamQuality.peerToPeerDelay = quality.peer_to_peer_delay;
            playStreamQuality.peerToPeerPktLostRate = quality.peer_to_peer_packet_lost_rate;
            playStreamQuality.delay = quality.delay;
            playStreamQuality.isHardwareDecode = quality.is_hardware_decode;
            playStreamQuality.totalRecvBytes = quality.total_recv_bytes;
            playStreamQuality.audioRecvBytes = quality.audio_recv_bytes;
            playStreamQuality.videoRecvBytes = quality.video_recv_bytes;
            return playStreamQuality;
        }

        public static void zego_on_player_media_event([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string streamId, ZegoPlayerMediaEvent mediaEvent, System.IntPtr userContext)
        {

            if (enginePtr == null || enginePtr.onPlayerMediaEvent == null) return;

            if (context != null)
            {
                context.Post(new SendOrPostCallback((o) =>
                {
                    if (enginePtr != null)
                    {
                        enginePtr.onPlayerMediaEvent(streamId, mediaEvent);
                    }
                }), null);
            }


        }

        public static void zego_on_player_recv_audio_first_frame([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string streamId, System.IntPtr userContext)
        {

            if (enginePtr == null || enginePtr.onPlayerRecvAudioFirstFrame == null) return;
            if (context != null)
            {
                context.Post(new SendOrPostCallback((o) =>
                {
                    if (enginePtr != null)
                    {
                        enginePtr.onPlayerRecvAudioFirstFrame(streamId);
                    }
                }), null);
            }



        }

        public static void zego_on_player_recv_video_first_frame([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string streamId, System.IntPtr userContext)
        {

            if (enginePtr == null || enginePtr.onPlayerRecvVideoFirstFrame == null) return;
            if (context != null)
            {
                context.Post(new SendOrPostCallback((o) =>
                {
                    if (enginePtr != null)
                    {
                        enginePtr.onPlayerRecvVideoFirstFrame(streamId);
                    }
                }), null);
            }



        }

        public static void zego_on_player_render_video_first_frame([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string streamId, System.IntPtr userContext)
        {

            if (enginePtr == null || enginePtr.onPlayerRenderVideoFirstFrame == null) return;

            if (context != null)
            {
                context.Post(new SendOrPostCallback((o) =>
                {
                    if (enginePtr != null)
                    {
                        enginePtr.onPlayerRenderVideoFirstFrame(streamId);
                    }
                }), null);
            }



        }

        public static void zego_on_player_video_size_changed([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string streamId, int width, int height, System.IntPtr userContext)
        {

            if (enginePtr == null || enginePtr.onPlayerVideoSizeChanged == null) return;

            Console.WriteLine(string.Format("onPlayerVideoSizeChanged streamId:{0} width:{1} height:{2}", streamId, width, height));
            if (context != null)
            {
                context.Post(new SendOrPostCallback((o) =>
                {
                    if (enginePtr != null)
                    {
                        enginePtr.onPlayerVideoSizeChanged(streamId, width, height);
                    }
                }), null);
            }



        }

        public override void StopPlayingStream(string streamId)
        {
            if (enginePtr != null)
            {

                int result = IExpressPlayerInternal.zego_express_stop_playing_stream(streamId);
                Console.WriteLine(string.Format("StopPlayingStream streamId:{0} result:{1}", streamId, result));
            }
        }

        public override void SetVideoConfig(ZegoVideoConfig config, ZegoPublishChannel channel = ZegoPublishChannel.Main)
        {
            if (enginePtr != null)
            {
                int result = IExpressPublisherInternal.zego_express_set_video_config(ChangeVideoConfigClassToStruct(config), channel);
                Console.WriteLine(string.Format("SetVideoConfig channel:{0}  result:{1}", channel, result));
            }
        }
        private zego_video_config ChangeVideoConfigClassToStruct(ZegoVideoConfig config)
        {
            zego_video_config zegoVideoConfig;
            if (config == null)
            {
                throw new Exception("ZegoVideoConfig should not be null");
            }
            else
            {
                zegoVideoConfig = new zego_video_config();
                zegoVideoConfig.capture_resolution_width = config.captureResolutionWidth;
                zegoVideoConfig.capture_resolution_height = config.captureResolutionHeight;
                zegoVideoConfig.encode_resolution_width = config.encodeResolutionWidth;
                zegoVideoConfig.encode_resolution_height = config.encodeResolutionHeight;
                zegoVideoConfig.bitrate = config.bitrate;
                zegoVideoConfig.fps = config.fps;
                zegoVideoConfig.video_codec_id = config.videoCodecId;
            }
            return zegoVideoConfig;
        }
        public override void SetVideoMirrorMode(ZegoVideoMirrorMode mirrorMode, ZegoPublishChannel channel = ZegoPublishChannel.Main)
        {
            if (enginePtr != null)
            {
                int result = IExpressPublisherInternal.zego_express_set_video_mirror_mode(mirrorMode, channel);
                Console.WriteLine(string.Format("SetVideoMirrorMode mirrorMode:{0}  channel:{1}  result:{2}", mirrorMode, channel, result));
            }
        }
        public override void SetAudioConfig(ZegoAudioConfig config)
        {
            if (enginePtr != null)
            {
                int result = IExpressPublisherInternal.zego_express_set_audio_config(ChangeAudioConfigClassToStruct(config));
                Console.WriteLine(string.Format("SetAudioConfig result:{0}", result));
            }
        }
        private zego_audio_config ChangeAudioConfigClassToStruct(ZegoAudioConfig config)
        {
            zego_audio_config zegoAudioConfig;
            if (config == null)
            {
                throw new Exception("ZegoAudioConfig should not be null");
            }
            else
            {
                zegoAudioConfig.bitrate = config.bitrate;
                zegoAudioConfig.channel = config.channel;
                zegoAudioConfig.audio_codec_id = config.audioCodecId;
            }
            return zegoAudioConfig;
        }
        public override void MutePublishStreamAudio(bool mute, ZegoPublishChannel channel = ZegoPublishChannel.Main)
        {
            if (enginePtr != null)
            {
                int result = IExpressPublisherInternal.zego_express_mute_publish_stream_audio(mute, channel);
                Console.WriteLine(string.Format("MutePublishStreamAudio mute:{0} channel:{1} result:{2}", mute, channel, result));
            }
        }
        public override void MutePublishStreamVideo(bool mute, ZegoPublishChannel channel = ZegoPublishChannel.Main)
        {
            if (enginePtr != null)
            {
                int result = IExpressPublisherInternal.zego_express_mute_publish_stream_video(mute, channel);
                Console.WriteLine(string.Format("MutePublishStreamVideo mute:{0} channel:{1} result:{2}", mute, channel, result));
            }
        }
        public override void EnableTrafficControl(bool enable, int property)
        {
            if (enginePtr != null)
            {
                int result = IExpressPublisherInternal.zego_express_enable_traffic_control(enable, property);
                Console.WriteLine(string.Format("EnableTrafficControl enable:{0} property:{1} result:{2}", enable, property, result));
            }
        }
        public override void SetMinVideoBitrateForTrafficControl(int bitrate, ZegoTrafficControlMinVideoBitrateMode mode)
        {
            if (enginePtr != null)
            {
                int result = IExpressPublisherInternal.zego_express_set_min_video_bitrate_for_traffic_control(bitrate, mode);
                Console.WriteLine(string.Format("SetMinVideoBitrateForTrafficControl bitrate:{0} mode:{1} result:{2}", bitrate, mode, result));
            }
        }
        public override void SetCaptureVolume(int volume)
        {
            if (enginePtr != null)
            {
                int result = IExpressPublisherInternal.zego_express_set_capture_volume(volume);
                Console.WriteLine(string.Format("SetCaptureVolume volume:{0} result:{1}", volume, result));
            }
        }
        public override void EnableHardwareEncoder(bool enable)
        {
            if (enginePtr != null)
            {
                int result = IExpressPublisherInternal.zego_express_enable_hardware_encoder(enable);
                Console.WriteLine(string.Format("EnableHardwareEncoder enable:{0} result:{1}", enable, result));
            }
        }
        public static new string GetVersion()
        {

            string reuslt = ZegoUtil.PtrToString(IExpressEngineInternal.zego_express_get_version());
            Console.WriteLine(string.Format("GetVersion SDK version:{0}", reuslt));
            return reuslt;

        }
        public static new ZegoExpressEngine GetEngine()
        {
            Console.WriteLine("GetEngine");
            return enginePtr;
        }
        public override void UploadLog()
        {
            if (enginePtr != null)
            {
                IExpressEngineInternal.zego_express_upload_log();
                Console.WriteLine("UploadLog");
            }
        }
        public override void SetCapturePipelineScaleMode(ZegoCapturePipelineScaleMode mode)
        {
            if (enginePtr != null)
            {
                IExpressPublisherInternal.zego_express_set_capture_pipeline_scale_mode(mode);
                Console.WriteLine(string.Format("SetCapturePipelineScaleMode mode:{0}", mode));
            }
        }
        public override void SetDebugVerbose(bool enable, ZegoLanguage language)
        {
            if (enginePtr != null)
            {
                IExpressEngineInternal.zego_express_set_debug_verbose(enable, language);
                Console.WriteLine(string.Format("SetDebugVerbose enable:{0} language:{1}", enable, language));
            }
        }
        public override void SetPlayVolume(string streamId, int volume)
        {
            if (enginePtr != null)
            {
                IExpressPlayerInternal.zego_express_set_play_volume(streamId, volume);
                Console.WriteLine(string.Format("SetPlayVolume streamId:{0} volume:{1}", streamId, volume));
            }
        }
        public override void MutePlayStreamAudio(string streamId, bool mute)
        {
            if (enginePtr != null)
            {
                IExpressPlayerInternal.zego_express_mute_play_stream_audio(streamId, mute);
                Console.WriteLine(string.Format("MutePlayStreamAudio streamId:{0} mute:{1}", streamId, mute));
            }
        }
        public override void MutePlayStreamVideo(string streamId, bool mute)
        {
            if (enginePtr != null)
            {
                IExpressPlayerInternal.zego_express_mute_play_stream_video(streamId, mute);
                Console.WriteLine(string.Format("MutePlayStreamVideo streamId:{0} mute:{1}", streamId, mute));
            }
        }
        public override void EnableCheckPoc(bool enable)
        {
            if (enginePtr != null)
            {
                IExpressPlayerInternal.zego_express_enable_check_poc(enable);
                Console.WriteLine(string.Format("EnableCheckPoc enable:{0} ", enable));
            }
        }
        public override void UseFrontCamera(bool enable, ZegoPublishChannel channel = ZegoPublishChannel.Main)
        {
            if (enginePtr != null)
            {
                IExpressDeviceInternal.zego_express_use_front_camera(enable, channel);
                Console.WriteLine(string.Format("UseFrontCamera enable:{0} channel:{1}", enable, channel));
            }
        }
        public override void EnableBeautify(int featureBitmask, ZegoPublishChannel channel = ZegoPublishChannel.Main)
        {

            throw new Exception("PC Platform do not support EnableBeautify");
        }
        public override void SetBeautifyOption(ZegoBeautifyOption option, ZegoPublishChannel channel = ZegoPublishChannel.Main)
        {
            throw new Exception("PC Platform do not support SetBeautifyOption");
        }

        private zego_beautify_option ChangeZegoBeautifyOptionToStruct(ZegoBeautifyOption option)
        {
            zego_beautify_option option1 = new zego_beautify_option();
            if (option == null)
            {
                throw new Exception("ZegoBeautifyOption should not be null");
            }
            else
            {
                option1.polish_step = option.polishStep;
                option1.sharpen_factor = option.sharpenFactor;
                option1.whiten_factor = option.whitenFactor;
                return option1;
            }
        }

        public override void EnableHardwareDecoder(bool enable)
        {
            if (enginePtr != null)
            {
                IExpressPlayerInternal.zego_express_enable_hardware_decoder(enable);
                Console.WriteLine(string.Format("EnableHardwareDecoder enable:{0} ", enable));
            }
        }
        public override void SendSEI(byte[] data, ZegoPublishChannel channel = ZegoPublishChannel.Main)
        {
            if (enginePtr != null)
            {
                int result = IExpressPublisherInternal.zego_express_send_sei(Marshal.UnsafeAddrOfPinnedArrayElement(data, 0), (uint)data.Length, channel);
                Console.WriteLine(string.Format("SendSEI channel:{0} result:{1}", channel, result));
            }
        }

        public static void zego_on_im_recv_barrage_message([System.Runtime.InteropServices.InAttribute()] [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string room_id, System.IntPtr message_info_list, uint message_count, System.IntPtr user_context)
        {

            if (enginePtr == null || enginePtr.onIMRecvBarrageMessage == null) return;
            zego_barrage_message_info[] zego_messages = new zego_barrage_message_info[message_count];
            ZegoUtil.GetStructListByPtr<zego_barrage_message_info>(ref zego_messages, message_info_list, message_count);//get StructLists by pointer
            List<ZegoBarrageMessageInfo> result = ChangeBarrageMessageStructListToClassList(zego_messages);

            Console.WriteLine(string.Format("onIMRecvBarrageMessage room_id:{0} message_count:{1} ", room_id, message_count));
            if (context != null)
            {
                context.Post(new SendOrPostCallback((o) =>
                {
                    if (enginePtr != null)
                    {
                        enginePtr.onIMRecvBarrageMessage(room_id, result);
                    }
                }), null);
            }


        }
        public static List<ZegoBarrageMessageInfo> ChangeBarrageMessageStructListToClassList(zego_barrage_message_info[] infos)
        {
            List<ZegoBarrageMessageInfo> zegoBarrageMessageInfos = new List<ZegoBarrageMessageInfo>();
            for (int i = 0; i < infos.Length; i++)
            {
                zegoBarrageMessageInfos.Add(ChangeBarrageMessageStructToClass(infos[i]));
            }
            return zegoBarrageMessageInfos;

        }
        //public override void SetPublishWatermark(ZegoWatermark watermark, bool isPreviewVisible, zego_publish_channel channel = zego_publish_channel.zego_publish_channel_main)
        //{
        //    if (enginePtr != null)
        //    {
        //        IExpressPublisherInternal.zego_express_set_publish_watermark(isPreviewVisible, ZegoUtil.GetStructPointer(ChangeWaterMarkClassToStruct(watermark)), channel);
        //        ZegoUtil.ReleaseAllStructPointers();
        //    }
        //}

        private zego_watermark ChangeWaterMarkClassToStruct(ZegoWatermark watermark)
        {
            zego_watermark zegoWatermark = new zego_watermark();
            if (watermark != null)
            {
                zegoWatermark.image = watermark.imageUrl;
                zegoWatermark.layout = ChangeRectClassToStruct(watermark.layout);

            }
            return zegoWatermark;
        }

        private zego_rect ChangeRectClassToStruct(ZegoRect layout)
        {
            if (layout == null)
            {
                throw new Exception("ZegoRect in ZegoWatermark should not be null");
            }
            else
            {
                zego_rect rect = new zego_rect();
                rect.top = layout.top;
                rect.bottom = layout.bottom;
                rect.left = layout.left;
                rect.right = layout.right;
                return rect;
            }
        }

        private static ZegoBarrageMessageInfo ChangeBarrageMessageStructToClass(zego_barrage_message_info zego_barrage_message_info)
        {
            ZegoBarrageMessageInfo zegoBarrageMessageInfo = new ZegoBarrageMessageInfo();
            zegoBarrageMessageInfo.message = ZegoUtil.GetUTF8String(zego_barrage_message_info.message);
            zegoBarrageMessageInfo.messageId = ZegoUtil.GetUTF8String(zego_barrage_message_info.message_id);
            zegoBarrageMessageInfo.sendTime = zego_barrage_message_info.send_time;
            zegoBarrageMessageInfo.fromUser = ChangeZegoUserStructToClass(zego_barrage_message_info.from_user);
            return zegoBarrageMessageInfo;
        }

        public static void zego_on_custom_video_capture_start(ZegoPublishChannel channel, System.IntPtr user_context)
        {
            if (enginePtr == null || enginePtr.onCustomVideoCaptureStart == null) return;
            Console.WriteLine(string.Format("onCustomVideoCaptureStart channel:{0}  ", channel));
            if (context != null)
            {
                context.Post(new SendOrPostCallback((o) =>
                {
                    if (enginePtr != null)
                    {
                        enginePtr.onCustomVideoCaptureStart(channel);
                    }
                }), null);
            }
        }

        /// Return Type: void
        ///channel: zego_publish_channel
        ///user_context: void*

        public static void zego_on_custom_video_capture_stop(ZegoPublishChannel channel, System.IntPtr user_context)
        {
            if (enginePtr == null || enginePtr.onCustomVideoCaptureStop == null) return;
            Console.WriteLine(string.Format("onCustomVideoCaptureStop channel:{0}  ", channel));
            if (context != null)
            {
                context.Post(new SendOrPostCallback((o) =>
                {
                    if (enginePtr != null)
                    {
                        enginePtr.onCustomVideoCaptureStop(channel);
                    }
                }), null);
            }

        }
        public static void zego_on_captured_audio_data(IntPtr data, uint data_length, zego_audio_frame_param param, System.IntPtr user_context)
        {
            if (enginePtr == null || enginePtr.onCapturedAudioData == null) return;
            //Console.WriteLine(string.Format("onCapturedAudioData data_length:{0}  ", data_length));
            ZegoAudioFrameParam zegoAudioFrameParam = ChangeZegoAudioFrameStructToClass(param);
            enginePtr.onCapturedAudioData(data, data_length, zegoAudioFrameParam);
            
        }
        public static void zego_on_remote_audio_data(IntPtr data, uint data_length, zego_audio_frame_param param, System.IntPtr user_context)
        {
            if (enginePtr == null || enginePtr.onRemoteAudioData == null) return;
            //Console.WriteLine(string.Format("onRemoteAudioData data_length:{0}  ", data_length));
            ZegoAudioFrameParam zegoAudioFrameParam = ChangeZegoAudioFrameStructToClass(param);
            enginePtr.onRemoteAudioData(data, data_length, zegoAudioFrameParam);
        }
        public static void zego_on_mixed_audio_data(IntPtr data, uint data_length, zego_audio_frame_param param, System.IntPtr user_context){
            if (enginePtr == null || enginePtr.onMixedAudioData == null) return;
            //Console.WriteLine(string.Format("onMixedAudioData data_length:{0}  ", data_length));
            ZegoAudioFrameParam zegoAudioFrameParam = ChangeZegoAudioFrameStructToClass(param);
            enginePtr.onMixedAudioData(data, data_length, zegoAudioFrameParam);
        }
        public static void zego_on_im_recv_broadcast_message([System.Runtime.InteropServices.InAttribute()] [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string room_id, System.IntPtr message_info_list, uint message_count, System.IntPtr user_context)
        {

            if (enginePtr == null || enginePtr.onIMRecvBroadcastMessage == null) return;
            zego_broadcast_message_info[] zego_messages = new zego_broadcast_message_info[message_count];
            ZegoUtil.GetStructListByPtr<zego_broadcast_message_info>(ref zego_messages, message_info_list, message_count);//get StructLists by pointer
            List<ZegoBroadcastMessageInfo> result = ChangeBroadMessageStructListToClassList(zego_messages);

            Console.WriteLine(string.Format("onIMRecvBroadcastMessage room_id:{0} message_count:{1} ", room_id, message_count));
            if (context != null)
            {
                context.Post(new SendOrPostCallback((o) =>
                {
                    if (enginePtr != null)
                    {
                        enginePtr.onIMRecvBroadcastMessage(room_id, result);
                    }
                }), null);
            }


        }
        public static List<ZegoBroadcastMessageInfo> ChangeBroadMessageStructListToClassList(zego_broadcast_message_info[] infos)
        {
            List<ZegoBroadcastMessageInfo> zegoBroadMessageInfos = new List<ZegoBroadcastMessageInfo>();
            for (int i = 0; i < infos.Length; i++)
            {
                zegoBroadMessageInfos.Add(ChangeBroadMessageStructToClass(infos[i]));
            }
            return zegoBroadMessageInfos;

        }

        private static ZegoBroadcastMessageInfo ChangeBroadMessageStructToClass(zego_broadcast_message_info zego_broad_message_info)
        {
            ZegoBroadcastMessageInfo zegoBroadMessageInfo = new ZegoBroadcastMessageInfo();
            zegoBroadMessageInfo.message = ZegoUtil.GetUTF8String(zego_broad_message_info.message);
            zegoBroadMessageInfo.messageId = zego_broad_message_info.message_id;
            zegoBroadMessageInfo.sendTime = zego_broad_message_info.send_time;
            zegoBroadMessageInfo.fromUser = ChangeZegoUserStructToClass(zego_broad_message_info.from_user);
            return zegoBroadMessageInfo;
        }

        public static void zego_on_im_recv_custom_command([System.Runtime.InteropServices.InAttribute()] [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string room_id, zego_user from_user,[System.Runtime.InteropServices.InAttribute()] [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(ZegoUtil.UTF8StringMarshaler))] string content, System.IntPtr user_context)
        {

            if (enginePtr == null || enginePtr.onIMRecvCustomCommand == null) return;
            ZegoUser result = ChangeZegoUserStructToClass(from_user);

            Console.WriteLine(string.Format("onIMRecvCustomCommand room_id:{0} content:{1}", room_id,content));
            if (context != null)
            {
                context.Post(new SendOrPostCallback((o) =>
                {
                    if (enginePtr != null)
                    {
                        enginePtr.onIMRecvCustomCommand(room_id, result, content);
                    }
                }), null);
            }


        }

        public static void zego_on_im_send_barrage_message_result([System.Runtime.InteropServices.InAttribute()] [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string room_id, [System.Runtime.InteropServices.InAttribute()] [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string message_id, int error_code, int seq, System.IntPtr user_context)
        {

            if (enginePtr == null || onIMSendBarrageMessageResultDics == null) return;
          
                 Console.WriteLine(string.Format("onIMSendBarrageMessageResult room_id:{0} message_id:{1} error_code:{2} seq:{3}", room_id, message_id, error_code, seq));
                OnIMSendBarrageMessageResult onIMSendBarrageMessageResult = GetCallbackFromSeq<OnIMSendBarrageMessageResult>(onIMSendBarrageMessageResultDics, seq);
                
            if (context != null)
            {
                context.Post(new SendOrPostCallback((o) =>
                {
                    onIMSendBarrageMessageResult(error_code, message_id);
                    onIMSendBarrageMessageResultDics.Remove(seq);
                }), null);
            }
        }
        public static ZegoMediaPlayer GetMediaPlayerFromIndex(ZegoMediaPlayerInstanceIndex index)
        {
            ZegoMediaPlayer zegoMediaPlayer = null;
            foreach (KeyValuePair<ZegoMediaPlayerInstanceIndex, ZegoMediaPlayer> kvp in mediaPlayerAndIndex)
            {
                if (kvp.Key == index)
                {
                    zegoMediaPlayer = kvp.Value;
                }
            }
            if (zegoMediaPlayer == null)
            {
                throw new Exception("GetMediaPlayerFromIndex null");
            }
            else
            {
                return zegoMediaPlayer;
            }
        }
        public static void zego_on_mediaplayer_state_update(ZegoMediaPlayerState state, int error_code, ZegoMediaPlayerInstanceIndex instance_index, System.IntPtr user_context)
        {
            lock (zegoExpressEngineMediaPlayerLock)
            {
                ZegoMediaPlayer zegoMediaPlayer = GetMediaPlayerFromIndex(instance_index);
                if (zegoMediaPlayer.onMediaPlayerStateUpdate != null)
                {
                    if (context != null)
                    {
                        Console.WriteLine(string.Format("zego_on_mediaplayer_state_update mediaplayerID:{0} state:{1}", instance_index, state));
                        context.Post(new SendOrPostCallback((o) =>
                        {
                            if (zegoMediaPlayer != null)
                            {
                                zegoMediaPlayer.onMediaPlayerStateUpdate(zegoMediaPlayer, state, error_code);
                            }
                        }), null);
                    }
                }
                else
                {
                    return;
                }

            }
        }
        public static void zego_on_mediaplayer_network_event(ZegoMediaPlayerNetworkEvent net_event, ZegoMediaPlayerInstanceIndex instance_index, System.IntPtr user_context)

        {
            lock (zegoExpressEngineMediaPlayerLock)
            {
                ZegoMediaPlayer zegoMediaPlayer = GetMediaPlayerFromIndex(instance_index);

                if (zegoMediaPlayer.onMediaPlayerNetworkEvent != null)
                {
                    if (context != null)
                    {
                        Console.WriteLine(string.Format("zego_on_mediaplayer_network_event mediaplayerID:{0}", instance_index));
                        context.Post(new SendOrPostCallback((o) =>
                        {
                            if (zegoMediaPlayer != null)
                            {
                                zegoMediaPlayer.onMediaPlayerNetworkEvent(zegoMediaPlayer, net_event);
                            }
                        }), null);
                    }
                }
                else
                {
                    return;
                }
            }

        }
        public static void zego_on_mediaplayer_playing_progress(ulong millisecond, ZegoMediaPlayerInstanceIndex instance_index, System.IntPtr user_context)
        {
            lock (zegoExpressEngineMediaPlayerLock)
            {
                ZegoMediaPlayer zegoMediaPlayer = GetMediaPlayerFromIndex(instance_index);
                if (zegoMediaPlayer.onMediaPlayerPlayingProgress != null)
                {
                    if (context != null)
                    {
                        Console.WriteLine(string.Format("zego_on_mediaplayer_playing_progress mediaplayerID:{0}", instance_index));
                        context.Post(new SendOrPostCallback((o) =>
                        {
                            if (zegoMediaPlayer != null)
                            {
                                zegoMediaPlayer.onMediaPlayerPlayingProgress(zegoMediaPlayer, millisecond);
                            }
                        }), null);
                    }
                }
                else
                {
                    return;
                }
            }


        }

        public static void zego_on_mediaplayer_seek_to_time_result(int seq, int error_code, ZegoMediaPlayerInstanceIndex instance_index, System.IntPtr user_context)
        {
            lock (zegoExpressEngineMediaPlayerLock)
            {
                ZegoMediaPlayer zegoMediaPlayer = GetMediaPlayerFromIndex(instance_index);
                if (zegoMediaPlayer.seekToTimeCallbackDic != null)
                {
                    if (context != null)
                    {
                        Console.WriteLine(string.Format("zego_on_mediaplayer_seek_to_time_result mediaplayerID:{0} seq:{1} error_code:{2}", instance_index, seq, error_code));
                        ZegoMediaPlayer.OnSeekToTimeCallback callback = GetCallbackFromSeq<ZegoMediaPlayer.OnSeekToTimeCallback>(zegoMediaPlayer.seekToTimeCallbackDic,seq);
                        context.Post(new SendOrPostCallback((o) =>
                        {
                            if (callback != null)
                            {
                                callback(error_code);
                                if (zegoMediaPlayer != null)
                                {
                                    zegoMediaPlayer.seekToTimeCallbackDic.Remove(seq);
                                }
                            }
                        }), null);
                    }
                }
                else
                {
                    return;
                }
            }
        }
       
        public static void zego_on_player_recv_sei([System.Runtime.InteropServices.InAttribute()] [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string stream_id, IntPtr data, uint data_length, System.IntPtr user_context)
        {

            if (enginePtr == null || enginePtr.onPlayerRecvSEI == null) return;
            byte[] result = new byte[data_length];
            ZegoUtil.GetStructListByPtr<byte>(ref result, data, data_length);

            Console.WriteLine(string.Format("onPlayerRecvSEI stream_id:{0}  data_length:{1}", stream_id, data_length));
            if (context != null)
            {
                context.Post(new SendOrPostCallback((o) =>
                {
                    if (enginePtr != null)
                    {
                        enginePtr.onPlayerRecvSEI(stream_id, result);
                    }
                }), null);
            }


        }

        public static void zego_on_im_send_broadcast_message_result([System.Runtime.InteropServices.InAttribute()] [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string room_id, ulong message_id, int error_code, int seq, System.IntPtr user_context)
        {

            if (enginePtr == null || onIMSendBroadcastMessageResultDics == null) return;          
                 Console.WriteLine(string.Format("onIMSendBroadcastMessageResult room_id:{0} message_id:{1} error_code:{2} seq:{3}", room_id, message_id, error_code, seq));
                OnIMSendBroadcastMessageResult onIMSendBroadcastMessageResult = GetCallbackFromSeq<OnIMSendBroadcastMessageResult>(onIMSendBroadcastMessageResultDics, seq);              
            if (context != null)
            {
                context.Post(new SendOrPostCallback((o) =>
                {
                    onIMSendBroadcastMessageResult(error_code, message_id);
                    onIMSendBroadcastMessageResultDics.Remove(seq);
                }), null);
            }
        }
        private static T GetCallbackFromSeq<T>(Dictionary<int, T> dics, int seq)
        {
            bool flag = false;
            T callbak = default(T);
            foreach (KeyValuePair<int, T> kvp in dics)
            {
                if (kvp.Key == seq)
                {
                    callbak = kvp.Value;
                    flag = true;
                }
            }
            if (flag)
            {
                return callbak;
            }
            else
            {
                throw new Exception("GetCallbackFromSeq found null");
            }
        }
        public static void zego_on_publisher_update_stream_extra_info_result(int error_code, int seq, System.IntPtr user_context)
        {

            if (enginePtr == null || onPublisherSetStreamExtraInfoResultDics == null) return;
                 Console.WriteLine(string.Format("onPublisherSetStreamExtraInfoResult error_code:{0}  seq:{1}", error_code, seq));
                OnPublisherSetStreamExtraInfoResult onPublisherSetStreamExtraInfoResult = GetCallbackFromSeq<OnPublisherSetStreamExtraInfoResult>(onPublisherSetStreamExtraInfoResultDics, seq);
            if (context != null)
            {
                context.Post(new SendOrPostCallback((o) =>
                {
                    onPublisherSetStreamExtraInfoResult(error_code);
                    onPublisherSetStreamExtraInfoResultDics.Remove(seq);
                }), null);
            }
        }

        public static void zego_on_im_send_custom_command_result([System.Runtime.InteropServices.InAttribute()] [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string room_id, int error_code, int seq, System.IntPtr user_context)
        {

            if (enginePtr == null || onIMSendCustomCommandResultDics == null) return;
         
                 Console.WriteLine(string.Format("onIMSendCustomCommandResult room_id:{0} message_id:{1} seq:{2}", room_id, error_code, seq));

                OnIMSendCustomCommandResult onIMSendCustomCommandResult = GetCallbackFromSeq<OnIMSendCustomCommandResult>(onIMSendCustomCommandResultDics, seq);
               
            if (context != null)
            {
                context.Post(new SendOrPostCallback((o) =>
                {
                    onIMSendCustomCommandResult(error_code);
                    onIMSendCustomCommandResultDics.Remove(seq);
                }), null);
            }
        }

        public static void zego_on_captured_sound_level_update(System.IntPtr sound_level_info, System.IntPtr user_context)
        {
            if (enginePtr == null || enginePtr.onCapturedSoundLevelUpdate == null) return;
            zego_sound_level_info soundLevelInfo = ZegoUtil.GetStructByPtr<zego_sound_level_info>(sound_level_info);

            //直接在c层子线程返回回调，避免切换到ui线程导致界面卡顿
            if (enginePtr != null)
            {
                enginePtr.onCapturedSoundLevelUpdate(soundLevelInfo.sound_level);
            }
            //callBackQueue.PostAsynAction(() =>
            //{
            //    enginePtr.onCapturedSoundLevelUpdate(soundLevelInfo.sound_level);
            //});
        }


        public static void zego_on_remote_sound_level_update(System.IntPtr sound_level_info_list, uint info_count, System.IntPtr user_context)
        {

            if (enginePtr == null || enginePtr.onRemoteSoundLevelUpdate == null) return;
            zego_sound_level_info[] infos = new zego_sound_level_info[info_count];
            ZegoUtil.GetStructListByPtr<zego_sound_level_info>(ref infos, sound_level_info_list, info_count);
            Dictionary<string, float> results = ChangeZegoSoundLevelInfoStructListToDictionary(infos);
            //直接在c层子线程返回回调，避免切换到ui线程导致界面卡顿
            if (enginePtr != null)
            {
                enginePtr.onRemoteSoundLevelUpdate(results);
            }
            //callBackQueue.PostAsynAction(() =>
            //{
            //    enginePtr.onRemoteSoundLevelUpdate(results);
            //});
        }

        private static Dictionary<string, float> ChangeZegoSoundLevelInfoStructListToDictionary(zego_sound_level_info[] infos)
        {
            Dictionary<string, float> keyValuePairs = new Dictionary<string, float>();
            for (int i = 0; i < infos.Length; i++)
            {
                if (keyValuePairs.ContainsKey(infos[i].stream_id))
                {
                    keyValuePairs[infos[i].stream_id] = infos[i].sound_level;
                }
                else
                {
                    keyValuePairs.Add(infos[i].stream_id, infos[i].sound_level);
                }
            }
            return keyValuePairs;
        }

        public static void zego_on_captured_audio_spectrum_update(System.IntPtr audio_spectrum_info, System.IntPtr user_context)
        {

            if (enginePtr == null || enginePtr.onCapturedAudioSpectrumUpdate == null) return;
            zego_audio_spectrum_info zegoAudioSpectrumInfo = ZegoUtil.GetStructByPtr<zego_audio_spectrum_info>(audio_spectrum_info);
            float[] result = GetZegoAudioSpectrumInfoStructSpectrumList(zegoAudioSpectrumInfo);
            //直接在c层子线程返回回调，避免切换到ui线程导致界面卡顿
            if (enginePtr != null)
            {
                enginePtr.onCapturedAudioSpectrumUpdate(result);
            }
            //callBackQueue.PostAsynAction(() =>
            //{

            //    enginePtr.onCapturedAudioSpectrumUpdate(result);
            //});
        }

        private static float[] GetZegoAudioSpectrumInfoStructSpectrumList(zego_audio_spectrum_info zegoAudioSpectrumInfo)
        {

            float[] results = new float[zegoAudioSpectrumInfo.spectrum_count];
            ZegoUtil.GetStructListByPtr<float>(ref results, zegoAudioSpectrumInfo.spectrum_list, zegoAudioSpectrumInfo.spectrum_count);
            return results;
        }


        public static void zego_on_remote_audio_spectrum_update(System.IntPtr audio_spectrum_info_list, uint info_count, System.IntPtr user_context)
        {

            if (enginePtr == null || enginePtr.onRemoteAudioSpectrumUpdate == null) return;
            zego_audio_spectrum_info[] infos = new zego_audio_spectrum_info[info_count];
            ZegoUtil.GetStructListByPtr<zego_audio_spectrum_info>(ref infos, audio_spectrum_info_list, info_count);
            Dictionary<string, float[]> results = ChangeZegoAudioSpectrumInfoListToDictionary(infos);
            //直接在c层子线程返回回调，避免切换到ui线程导致界面卡顿
            if (enginePtr != null)
            {
                enginePtr.onRemoteAudioSpectrumUpdate(results);
            }
            //callBackQueue.PostAsynAction(() =>
            //{

            //    enginePtr.onRemoteAudioSpectrumUpdate(results);
            //});
        }

        private static Dictionary<string, float[]> ChangeZegoAudioSpectrumInfoListToDictionary(zego_audio_spectrum_info[] infos)
        {
            Dictionary<string, float[]> keyValuePairs = new Dictionary<string, float[]>();
            for (int i = 0; i < infos.Length; i++)
            {
                if (keyValuePairs.ContainsKey(infos[i].stream_id))
                {
                    keyValuePairs[infos[i].stream_id] = GetZegoAudioSpectrumInfoStructSpectrumList(infos[i]);
                }
                else
                {
                    keyValuePairs.Add(infos[i].stream_id, GetZegoAudioSpectrumInfoStructSpectrumList(infos[i]));
                }
            }
            return keyValuePairs;
        }

        public override void StartAudioSpectrumMonitor()
        {
            if (enginePtr != null)
            {
                int result = IExpressDeviceInternal.zego_express_start_audio_spectrum_monitor();
                Console.WriteLine(string.Format("StartAudioSpectrumMonitor result:{0}", result));
            }
        }
        public override void StartSoundLevelMonitor()
        {
            if (enginePtr != null)
            {
                int result = IExpressDeviceInternal.zego_express_start_sound_level_monitor();
                Console.WriteLine(string.Format("StartSoundLevelMonitor result:{0}", result));
            }
        }
        public override void StopAudioSpectrumMonitor()
        {
            if (enginePtr != null)
            {
                int result = IExpressDeviceInternal.zego_express_stop_audio_spectrum_monitor();
                Console.WriteLine(string.Format("StopAudioSpectrumMonitor result:{0}", result));
            }
        }
        public override void StopSoundLevelMonitor()
        {
            if (enginePtr != null)
            {
                int result = IExpressDeviceInternal.zego_express_stop_sound_level_monitor();
                Console.WriteLine(string.Format("StopSoundLevelMonitor result:{0}", result));
            }
        }
        public override void MuteMicrophone(bool mute)
        {
            if (enginePtr != null)
            {
                int result = IExpressDeviceInternal.zego_express_mute_microphone(mute);
                Console.WriteLine(string.Format("MuteMicrophone mute:{0} result:{1}", mute, result));
            }
        }
        public override void MuteSpeaker(bool mute)
        {
            if (enginePtr != null)
            {
                int result = IExpressDeviceInternal.zego_express_mute_speaker(mute);
                Console.WriteLine(string.Format("MuteSpeaker mute:{0} result:{1}", mute, result));
            }
        }
        public override void EnableCamera(bool enable, ZegoPublishChannel channel = ZegoPublishChannel.Main)
        {
            if (enginePtr != null)
            {
                int result = IExpressDeviceInternal.zego_express_enable_camera(enable, channel);
                Console.WriteLine(string.Format("EnableCamera enable:{0} channel:{1} result:{2}", enable, channel, result));
            }
        }
        public override ZegoMediaPlayer CreateMediaPlayer()
        {
            if (enginePtr != null)
            {
                ZegoMediaPlayerInstanceIndex result = IExpressMediaPlayerInternal.zego_express_create_media_player();
                Console.WriteLine(string.Format("CreateMediaPlayer  result:{0}", result));
                if (result >= 0)
                {
                    ZegoMediaPlayer zegoMediaPlayer = new ZegoMediaPlayer();
                    if (mediaPlayerAndIndex.ContainsKey(result))
                    {
                        mediaPlayerAndIndex[result] = zegoMediaPlayer;
                    }
                    else
                    {
                        mediaPlayerAndIndex.Add(result, zegoMediaPlayer);
                    }
                    return zegoMediaPlayer;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        
        public static void zego_on_custom_video_render_captured_frame_data(ref IntPtr data, IntPtr dataLength, zego_video_frame_param param, ZegoVideoFlipMode flipMode, ZegoPublishChannel channel, System.IntPtr userContext)
        {//预览数据回调（写数据） 推流不会触发该回调
            if (enginePtr == null || enginePtr.onCapturedVideoFrameRawData == null) return;
            ZegoVideoFrameParam zegoVideoFrameParam = ChangeZegoVideoFrameParamStructToClass(param);
            enginePtr.onCapturedVideoFrameRawData(data, dataLength, zegoVideoFrameParam, flipMode, channel);           
        }

       



        private static ZegoVideoFrameParam ChangeZegoVideoFrameParamStructToClass(zego_video_frame_param param)
        {
            ZegoVideoFrameParam zegoVideoFrameParam = new ZegoVideoFrameParam();
            zegoVideoFrameParam.strides = param.strides;
            zegoVideoFrameParam.height = param.height;
            zegoVideoFrameParam.width = param.width;
            zegoVideoFrameParam.rotation = param.rotation;
            zegoVideoFrameParam.format = param.format;
            return zegoVideoFrameParam;
        }
        
        public static void zego_on_custom_video_render_remote_frame_data(string streamID, ref IntPtr data, IntPtr dataLength, zego_video_frame_param param, System.IntPtr userContext)
        {//拉流数据回调（写数据）
            if (enginePtr == null || enginePtr.onRemoteVideoFrameRawData == null) return;
            ZegoVideoFrameParam zegoVideoFrameParam = ChangeZegoVideoFrameParamStructToClass(param);
            enginePtr.onRemoteVideoFrameRawData(streamID, data, dataLength, zegoVideoFrameParam);
        }
    }
}