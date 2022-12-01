using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using static ZEGO.IZegoEventHandler;
using static ZEGO.ZegoImplCallChangeUtil;
using static ZEGO.ZegoCallBackChangeUtil;
using static ZEGO.ZegoAudioEffectPlayerImpl;
using static ZEGO.ZegoExpressEngineCallBack;
using static ZEGO.ZegoCopyrightedMusicImpl;

namespace ZEGO
{
    public class ZegoExpressEngineImpl : ZegoExpressEngine
    {

        public static ZegoExpressEngineImpl enginePtr = null;
        public static zego_engine_config engineConfig = new zego_engine_config();
        private static object zegoExpressEngineLock = new object();
        private static object zegoCopyMusicLock = new object();
        public static ConcurrentDictionary<int, OnPublisherUpdateCdnUrlResult> onPublisherUpdateCdnUrlResultDics = new ConcurrentDictionary<int, OnPublisherUpdateCdnUrlResult>();
        public static IZegoDestroyCompletionCallback onDestroyCompletion;
        public static ConcurrentDictionary<int, OnIMSendBroadcastMessageResult> onIMSendBroadcastMessageResultDics = new ConcurrentDictionary<int, OnIMSendBroadcastMessageResult>();
        public static ConcurrentDictionary<int, OnIMSendCustomCommandResult> onIMSendCustomCommandResultDics = new ConcurrentDictionary<int, OnIMSendCustomCommandResult>();
        public static ConcurrentDictionary<int, OnIMSendBarrageMessageResult> onIMSendBarrageMessageResultDics = new ConcurrentDictionary<int, OnIMSendBarrageMessageResult>();
        public static ConcurrentDictionary<int, OnPublisherSetStreamExtraInfoResult> onPublisherSetStreamExtraInfoResultDics = new ConcurrentDictionary<int, OnPublisherSetStreamExtraInfoResult>();
        public static ConcurrentDictionary<int, OnRoomSetRoomExtraInfoResult> onRoomSetRoomExtraInfoResultDics = new ConcurrentDictionary<int, OnRoomSetRoomExtraInfoResult>();
        // private static bool setEngineConfigFlag = false;
        public static SynchronizationContext context;
        public static ConcurrentDictionary<int, ZegoMediaPlayer> mediaPlayerAndIndex = new ConcurrentDictionary<int, ZegoMediaPlayer>();
        public static ConcurrentDictionary<int, OnMixerStartResult> onMixerStartResultDics = new ConcurrentDictionary<int, OnMixerStartResult>();
        public static ConcurrentDictionary<int, OnMixerStopResult> onMixerStopResultDics = new ConcurrentDictionary<int, OnMixerStopResult>();
        public static ConcurrentDictionary<int, ZegoAudioEffectPlayer> audioEffectPlayerAndIndex = new ConcurrentDictionary<int, ZegoAudioEffectPlayer>();

        public static ZegoCopyrightedMusicImpl copyrighted_music_instance = null;

        //避免GC回收
        private static IExpressEngineInternal.zego_on_engine_uninit zegoOnEngineUninit;
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
        private static IExpressMixerInternal.zego_on_mixer_relay_cdn_state_update zegoOnMixerRelayCdnStateUpdate;
        private static IExpressMixerInternal.zego_on_mixer_sound_level_update zegoOnMixerSoundLevelUpdate;

        private static IExpressCustomVideoInternal.zego_on_custom_video_capture_start zegoOnCustomVideoCaptureStart;
        private static IExpressCustomVideoInternal.zego_on_custom_video_capture_stop zegoOnCustomVideoCaptureStop;
        private static IExpressRoomInternal.zego_on_room_set_room_extra_info_result zegoOnRoomSetRoomExtraInfoResult;
        private static IExpressRoomInternal.zego_on_room_extra_info_update zegoOnRoomExtraInfoUpdate;
        private static IExpressRoomInternal.zego_on_room_online_user_count_update zegoOnRoomOnlineUserCountUpdate;
        private static IExpressEngineInternal.zego_on_engine_state_update zegoOnEngineStateUpdate;
        private static IExpressCustomAudioIOInternal.zego_on_captured_audio_data zegoOnCapturedAudioData;
        private static IExpressCustomAudioIOInternal.zego_on_mixed_audio_data zegoOnMixedAudioData;
        private static IExpressRecordInternal.zego_on_captured_data_record_state_update zegoOnCapturedDataRecordStateUpdate;
        private static IExpressRecordInternal.zego_on_captured_data_record_progress_update zegoOnCapturedDataRecordProgressUpdate;
        private static IExpressCustomAudioIOInternal.zego_on_playback_audio_data zegoOnPlaybackAudioData;
        private static IExpressCustomAudioIOInternal.zego_on_player_audio_data zegoOnPlayerAudioData;
        private static IExpressDeviceInternal.zego_on_local_device_exception_occurred zegoOnLocalDeviceExceptionOccurred;
        private static IExpressDeviceInternal.zego_on_remote_camera_state_update zegoOnRemoteCameraStateUpdate;
        private static IExpressDeviceInternal.zego_on_remote_mic_state_update zegoOnRemoteMicStateUpdate;
        private static IExpressAudioEffectPlayerInternal.zego_on_audio_effect_player_seek_to zegoOnAudioEffectPlayerSeekTo;
        private static IExpressAudioEffectPlayerInternal.zego_on_audio_effect_player_load_resource zegoOnAudioEffectPlayerLoadResource;
        private static IExpressAudioEffectPlayerInternal.zego_on_audio_effect_play_state_update zegoOnAudioEffectPlayerStateUpdate;
        // Copyrighted music
        private static IExpressCopyrightedMusicInternal.zego_on_copyrighted_music_send_extended_request zegoOnCopyrightedMusicSendExtendedRequest;
        private static IExpressCopyrightedMusicInternal.zego_on_copyrighted_music_init zegoOnCopyrightedMusicInit;
        private static IExpressCopyrightedMusicInternal.zego_on_copyrighted_music_request_accompaniment zegoOnCopyrightedMusciRequestAccompaniment;
        private static IExpressCopyrightedMusicInternal.zego_on_copyrighted_music_request_song zegoOnCopyreghtedMusicRequestSong;
        private static IExpressCopyrightedMusicInternal.zego_on_copyrighted_music_get_lrc_lyric zegoOnCopyreghtedMusicGetLrcLyric;
        private static IExpressCopyrightedMusicInternal.zego_on_copyrighted_music_get_krc_lyric_by_token zegoOnCopyrightedMusicGetKrcLyricByToken;
        private static IExpressCopyrightedMusicInternal.zego_on_copyrighted_music_download zegoOnCopyrightedMusicDownoad;
        private static IExpressCopyrightedMusicInternal.zego_on_copyrighted_music_download_progress_update zegoOnCopyrightedMusicDownloadProgressUpdate;
        private static IExpressCopyrightedMusicInternal.zego_on_copyrighted_music_get_music_by_token zegoOnCopyrightedMusicGetMusicByToken;

        public static new void SetEngineConfig(ZegoEngineConfig config)
        {
            engineConfig = ChangeZegoEngineConfigClassToStruct(config);
            //DefaultOpenCustomRender(ref engineConfig);//Unity跨平台，默认开启外部渲染
            IExpressEngineInternal.zego_express_set_engine_config(engineConfig);
            if (engineConfig.log_config != IntPtr.Zero)
            {
                ZegoUtil.ReleaseStructPointer(engineConfig.log_config);
            }
            //setEngineConfigFlag = true;
        }

        public static new void SetLogConfig(ZegoLogConfig config)
        {
            zego_log_config log_config = ChangeZegoLogConfigClassToStruct(config);

            IExpressEngineInternal.zego_express_set_log_config(log_config);
        }

        public static new ZegoExpressEngine CreateEngine(ZegoEngineProfile profile, SynchronizationContext uiThreadContext)
        {
            if (enginePtr == null) //双if +lock
            {
                lock (zegoExpressEngineLock)
                {
                    if (enginePtr == null)
                    {
                        if (uiThreadContext == null)
                        {
                            throw new Exception("CreateEngine uiThreadContext should not be null");
                        }
                        context = uiThreadContext;

                        // init framework for log upload
                        ZegoEngineConfig config = new ZegoEngineConfig();
                        config.advancedConfig = new Dictionary<string, string>();
                        config.advancedConfig.Add("thirdparty_framework_info", "c#(windows)");
                        SetEngineConfig(config);

                        RegisterCallback();

                        zego_engine_profile engine_profile = ChangeZegoEngineProfileClassToStruct(profile);
                        int createResult = IExpressEngineInternal.zego_express_engine_init_with_profile(engine_profile);
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

        public static ZegoExpressEngine CreateEngine(uint appId, [InAttribute()][MarshalAsAttribute(UnmanagedType.LPStr)] string appSign, bool isTestEnv, ZegoScenario scenario, SynchronizationContext uiThreadContext)
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

                        RegisterCallback();

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

        /// <summary>
        /// Register callback
        /// </summary>
        private static void RegisterCallback()
        {
            zegoOnEngineUninit = new IExpressEngineInternal.zego_on_engine_uninit(zego_on_engine_uninit);
            zegoOnRoomStateUpdate = new IExpressRoomInternal.zego_on_room_state_update(zego_on_room_state_update);
            zegoOnRoomUserUpdate = new IExpressRoomInternal.zego_on_room_user_update(zego_on_room_user_update);
            zegoOnMediaplayerPlayingProgress = new IExpressMediaPlayerInternal.zego_on_media_player_playing_progress(zego_on_mediaplayer_playing_progress);
            zegoOnRoomStreamUpdate = new IExpressRoomInternal.zego_on_room_stream_update(zego_on_room_stream_update);
            zegoOnPublisherStateUpdate = new IExpressPublisherInternal.zego_on_publisher_state_update(zego_on_publisher_state_update);
            zegoOnPublisherQualityUpdate = new IExpressPublisherInternal.zego_on_publisher_quality_update(zego_on_publisher_quality_update);
            zegoOnPublisherRecvAudioCapturedFirstFrame = new IExpressPublisherInternal.zego_on_publisher_captured_audio_first_frame(zego_on_publisher_captured_audio_first_frame);
            zegoOnPublisherRecvVideoCapturedFirstFrame = new IExpressPublisherInternal.zego_on_publisher_captured_video_first_frame(zego_on_publisher_captured_video_first_frame);
            zegoOnPublisherVideoSizeChanged = new IExpressPublisherInternal.zego_on_publisher_video_size_changed(zego_on_publisher_video_size_changed);
            zegoOnCustomVideoRenderCapturedFrameData = new IExpressCustomVideoInternal.zego_on_custom_video_render_captured_frame_data(zego_on_custom_video_render_captured_frame_data);
            zegoOnCustomVideoRenderRemoteFrameData = new IExpressCustomVideoInternal.zego_on_custom_video_render_remote_frame_data(zego_on_custom_video_render_remote_frame_data);
            zegoOnPlayerStateUpdate = new IExpressPlayerInternal.zego_on_player_state_update(zego_on_player_state_update);
            zegoOnPlayerQualityUpdate = new IExpressPlayerInternal.zego_on_player_quality_update(zego_on_player_quality_update);
            zegoOnPlayerMediaEvent = new IExpressPlayerInternal.zego_on_player_media_event(zego_on_player_media_event);
            zegoOnPlayerRecvAudioFirstFrame = new IExpressPlayerInternal.zego_on_player_recv_audio_first_frame(zego_on_player_recv_audio_first_frame);
            zegoOnPlayerRecvVideoFirstFrame = new IExpressPlayerInternal.zego_on_player_recv_video_first_frame(zego_on_player_recv_video_first_frame);
            zegoOnPlayerRenderVideoFirstFrame = new IExpressPlayerInternal.zego_on_player_render_video_first_frame(zego_on_player_render_video_first_frame);
            zegoOnPlayerVideoSizeChanged = new IExpressPlayerInternal.zego_on_player_video_size_changed(zego_on_player_video_size_changed);
            zegoOnImRecvBarrageMessage = new IExpressIMInternal.zego_on_im_recv_barrage_message(zego_on_im_recv_barrage_message);
            zegoOnImRecvBroadcastMessage = new IExpressIMInternal.zego_on_im_recv_broadcast_message(zego_on_im_recv_broadcast_message);
            zegoOnImRecvCustomCommand = new IExpressIMInternal.zego_on_im_recv_custom_command(zego_on_im_recv_custom_command);
            zegoOnImSendBarrageMessageResult = new IExpressIMInternal.zego_on_im_send_barrage_message_result(zego_on_im_send_barrage_message_result);
            zegoOnImSendBroadcastMessageResult = new IExpressIMInternal.zego_on_im_send_broadcast_message_result(zego_on_im_send_broadcast_message_result);
            zegoOnImSendCustomCommandResult = new IExpressIMInternal.zego_on_im_send_custom_command_result(zego_on_im_send_custom_command_result);
            zegoOnPublisherUpdateCdnUrlResult = new IExpressPublisherInternal.zego_on_publisher_update_cdn_url_result(zego_on_publisher_update_cdn_url_result);
            zegoOnPublisherRelayCdnStateUpdate = new IExpressPublisherInternal.zego_on_publisher_relay_cdn_state_update(zego_on_publisher_relay_cdn_state_update);
            zegoOnCapturedSoundLevelUpdate = new IExpressDeviceInternal.zego_on_captured_sound_level_update(zego_on_captured_sound_level_update);
            zegoOnRemoteSoundLevelUpdate = new IExpressDeviceInternal.zego_on_remote_sound_level_update(zego_on_remote_sound_level_update);
            zegoOnCapturedAudioSpectrumUpdate = new IExpressDeviceInternal.zego_on_captured_audio_spectrum_update(zego_on_captured_audio_spectrum_update);
            zegoOnRemoteAudioSpectrumUpdate = new IExpressDeviceInternal.zego_on_remote_audio_spectrum_update(zego_on_remote_audio_spectrum_update);
            zegoOnPlayerRecvSei = new IExpressPlayerInternal.zego_on_player_recv_sei(zego_on_player_recv_sei);
            zegoOnDebugError = new IExpressEngineInternal.zego_on_debug_error(zego_on_debug_error);
            zegoOnRoomStreamExtraInfoUpdate = new IExpressRoomInternal.zego_on_room_stream_extra_info_update(zego_on_room_stream_extra_info_update);
            zegoOnRoomStateUpdate = new IExpressRoomInternal.zego_on_room_state_update(zego_on_room_state_update);
            zegoOnEngineStateUpdate = new IExpressEngineInternal.zego_on_engine_state_update(zego_on_engine_state_update);
            zegoOnRoomExtraInfoUpdate = new IExpressRoomInternal.zego_on_room_extra_info_update(zego_on_room_extra_info_update);
            zegoOnRoomOnlineUserCountUpdate = new IExpressRoomInternal.zego_on_room_online_user_count_update(zego_on_room_online_user_count_update);
            zegoOnPublisherUpdateStreamExtraInfoResult = new IExpressPublisherInternal.zego_on_publisher_update_stream_extra_info_result(zego_on_publisher_update_stream_extra_info_result);
            zegoOnMediaplayerStateUpdate = new IExpressMediaPlayerInternal.zego_on_media_player_state_update(zego_on_mediaplayer_state_update);
            zegoOnMediaplayerLoadResourceResult = new IExpressMediaPlayerInternal.zego_on_media_player_load_resource(zego_on_mediaplayer_load_resource_result);
            zegoOnMediaplayerNetworkEvent = new IExpressMediaPlayerInternal.zego_on_media_player_network_event(zego_on_mediaplayer_network_event);
            zegoOnMediaplayerSeekToTimeResult = new IExpressMediaPlayerInternal.zego_on_media_player_seek_to(zego_on_mediaplayer_seek_to_time_result);
            zegoOnMediaplayerAudioData = new IExpressMediaPlayerInternal.zego_on_media_player_audio_frame(zego_on_mediaplayer_audio_data);
            zegoOnMediaplayerVideoData = new IExpressMediaPlayerInternal.zego_on_media_player_video_frame(zego_on_media_player_video_frame);
            zegoOnMixerStartResult = new IExpressMixerInternal.zego_on_mixer_start_result(zego_on_mixer_start_result);
            zegoOnMixerStopResult = new IExpressMixerInternal.zego_on_mixer_stop_result(zego_on_mixer_stop_result);
            zegoOnMixerRelayCdnStateUpdate = new IExpressMixerInternal.zego_on_mixer_relay_cdn_state_update(zego_on_mixer_relay_cdn_state_update);
            zegoOnMixerSoundLevelUpdate = new IExpressMixerInternal.zego_on_mixer_sound_level_update(zego_on_mixer_sound_level_update);
            zegoOnCustomVideoCaptureStart = new IExpressCustomVideoInternal.zego_on_custom_video_capture_start(zego_on_custom_video_capture_start);
            zegoOnCustomVideoCaptureStop = new IExpressCustomVideoInternal.zego_on_custom_video_capture_stop(zego_on_custom_video_capture_stop);
            zegoOnRoomSetRoomExtraInfoResult = new IExpressRoomInternal.zego_on_room_set_room_extra_info_result(zego_on_room_set_room_extra_info_result);
            zegoOnCapturedAudioData = new IExpressCustomAudioIOInternal.zego_on_captured_audio_data(zego_on_captured_audio_data);
            zegoOnMixedAudioData = new IExpressCustomAudioIOInternal.zego_on_mixed_audio_data(zego_on_mixed_audio_data);
            zegoOnCapturedDataRecordStateUpdate = new IExpressRecordInternal.zego_on_captured_data_record_state_update(zego_on_captured_data_record_state_update);
            zegoOnCapturedDataRecordProgressUpdate = new IExpressRecordInternal.zego_on_captured_data_record_progress_update(zego_on_captured_data_record_progress_update);
            zegoOnPlaybackAudioData = new IExpressCustomAudioIOInternal.zego_on_playback_audio_data(zego_on_playback_audio_data);
            zegoOnPlayerAudioData = new IExpressCustomAudioIOInternal.zego_on_player_audio_data(zego_on_player_audio_data);
            zegoOnLocalDeviceExceptionOccurred = new IExpressDeviceInternal.zego_on_local_device_exception_occurred(zego_on_local_device_exception_occurred);
            zegoOnRemoteCameraStateUpdate = new IExpressDeviceInternal.zego_on_remote_camera_state_update(zego_on_remote_camera_state_update);
            zegoOnRemoteMicStateUpdate = new IExpressDeviceInternal.zego_on_remote_mic_state_update(zego_on_remote_mic_state_update);
            zegoOnAudioEffectPlayerSeekTo = new IExpressAudioEffectPlayerInternal.zego_on_audio_effect_player_seek_to(zego_on_audio_effect_player_seek_to);
            zegoOnAudioEffectPlayerLoadResource = new IExpressAudioEffectPlayerInternal.zego_on_audio_effect_player_load_resource(zego_on_audio_effect_player_load_resource);
            zegoOnAudioEffectPlayerStateUpdate = new IExpressAudioEffectPlayerInternal.zego_on_audio_effect_play_state_update(zego_on_audio_effect_play_state_update);

            // Copyrighted music
            zegoOnCopyrightedMusicSendExtendedRequest = new IExpressCopyrightedMusicInternal.zego_on_copyrighted_music_send_extended_request(zego_on_copyrighted_music_send_extended_request);
            zegoOnCopyrightedMusicInit = new IExpressCopyrightedMusicInternal.zego_on_copyrighted_music_init(zego_on_copyrighted_music_init);
            zegoOnCopyrightedMusciRequestAccompaniment = new IExpressCopyrightedMusicInternal.zego_on_copyrighted_music_request_accompaniment(zego_on_copyrighted_music_request_accompaniment);
            zegoOnCopyreghtedMusicRequestSong = new IExpressCopyrightedMusicInternal.zego_on_copyrighted_music_request_song(zego_on_copyrighted_music_request_song);
            zegoOnCopyreghtedMusicGetLrcLyric = new IExpressCopyrightedMusicInternal.zego_on_copyrighted_music_get_lrc_lyric(zego_on_copyrighted_music_get_lrc_lyric);
            zegoOnCopyrightedMusicGetKrcLyricByToken = new IExpressCopyrightedMusicInternal.zego_on_copyrighted_music_get_krc_lyric_by_token(zego_on_copyrighted_music_get_krc_lyric_by_token);
            zegoOnCopyrightedMusicDownoad = new IExpressCopyrightedMusicInternal.zego_on_copyrighted_music_download(zego_on_copyrighted_music_download);
            zegoOnCopyrightedMusicDownloadProgressUpdate = new IExpressCopyrightedMusicInternal.zego_on_copyrighted_music_download_progress_update(zego_on_copyrighted_music_download_progress_update);
            zegoOnCopyrightedMusicGetMusicByToken = new IExpressCopyrightedMusicInternal.zego_on_copyrighted_music_get_music_by_token(zego_on_copyrighted_music_get_music_by_token);

            IExpressEngineInternal.zego_register_engine_uninit_callback(zegoOnEngineUninit, IntPtr.Zero);
            IExpressRoomInternal.zego_register_room_state_update_callback(zegoOnRoomStateUpdate, IntPtr.Zero);
            IExpressRoomInternal.zego_register_room_user_update_callback(zegoOnRoomUserUpdate, IntPtr.Zero);
            IExpressRoomInternal.zego_register_room_stream_update_callback(zegoOnRoomStreamUpdate, IntPtr.Zero);
            IExpressPublisherInternal.zego_register_publisher_state_update_callback(zegoOnPublisherStateUpdate, IntPtr.Zero);
            IExpressPublisherInternal.zego_register_publisher_quality_update_callback(zegoOnPublisherQualityUpdate, IntPtr.Zero);
            IExpressPublisherInternal.zego_register_publisher_captured_audio_first_frame_callback(zegoOnPublisherRecvAudioCapturedFirstFrame, IntPtr.Zero);
            IExpressPublisherInternal.zego_register_publisher_captured_video_first_frame_callback(zegoOnPublisherRecvVideoCapturedFirstFrame, IntPtr.Zero);
            IExpressPublisherInternal.zego_register_publisher_video_size_changed_callback(zegoOnPublisherVideoSizeChanged, IntPtr.Zero);
            IExpressCustomVideoInternal.zego_register_custom_video_render_captured_frame_data_callback(zegoOnCustomVideoRenderCapturedFrameData, IntPtr.Zero);
            IExpressCustomVideoInternal.zego_register_custom_video_render_remote_frame_data_callback(zegoOnCustomVideoRenderRemoteFrameData, IntPtr.Zero);
            IExpressPlayerInternal.zego_register_player_state_update_callback(zegoOnPlayerStateUpdate, IntPtr.Zero);
            IExpressPlayerInternal.zego_register_player_quality_update_callback(zegoOnPlayerQualityUpdate, IntPtr.Zero);
            IExpressPlayerInternal.zego_register_player_media_event_callback(zegoOnPlayerMediaEvent, IntPtr.Zero);
            IExpressPlayerInternal.zego_register_player_recv_audio_first_frame_callback(zegoOnPlayerRecvAudioFirstFrame, IntPtr.Zero);
            IExpressPlayerInternal.zego_register_player_recv_video_first_frame_callback(zegoOnPlayerRecvVideoFirstFrame, IntPtr.Zero);
            IExpressPlayerInternal.zego_register_player_render_video_first_frame_callback(zegoOnPlayerRenderVideoFirstFrame, IntPtr.Zero);
            IExpressPlayerInternal.zego_register_player_video_size_changed_callback(zegoOnPlayerVideoSizeChanged, IntPtr.Zero);
            IExpressIMInternal.zego_register_im_recv_barrage_message_callback(zegoOnImRecvBarrageMessage, IntPtr.Zero);
            IExpressIMInternal.zego_register_im_recv_broadcast_message_callback(zegoOnImRecvBroadcastMessage, IntPtr.Zero);
            IExpressIMInternal.zego_register_im_recv_custom_command_callback(zegoOnImRecvCustomCommand, IntPtr.Zero);
            IExpressIMInternal.zego_register_im_send_barrage_message_result_callback(zegoOnImSendBarrageMessageResult, IntPtr.Zero);
            IExpressIMInternal.zego_register_im_send_broadcast_message_result_callback(zegoOnImSendBroadcastMessageResult, IntPtr.Zero);
            IExpressIMInternal.zego_register_im_send_custom_command_result_callback(zegoOnImSendCustomCommandResult, IntPtr.Zero);
            IExpressPublisherInternal.zego_register_publisher_update_cdn_url_result_callback(zegoOnPublisherUpdateCdnUrlResult, IntPtr.Zero);
            IExpressPublisherInternal.zego_register_publisher_relay_cdn_state_update_callback(zegoOnPublisherRelayCdnStateUpdate, IntPtr.Zero);
            IExpressDeviceInternal.zego_register_captured_sound_level_update_callback(zegoOnCapturedSoundLevelUpdate, IntPtr.Zero);
            IExpressDeviceInternal.zego_register_remote_sound_level_update_callback(zegoOnRemoteSoundLevelUpdate, IntPtr.Zero);
            IExpressDeviceInternal.zego_register_captured_audio_spectrum_update_callback(zegoOnCapturedAudioSpectrumUpdate, IntPtr.Zero);
            IExpressDeviceInternal.zego_register_remote_audio_spectrum_update_callback(zegoOnRemoteAudioSpectrumUpdate, IntPtr.Zero);
            IExpressPlayerInternal.zego_register_player_recv_sei_callback(zegoOnPlayerRecvSei, IntPtr.Zero);
            IExpressEngineInternal.zego_register_debug_error_callback(zegoOnDebugError, IntPtr.Zero);
            IExpressRoomInternal.zego_register_room_stream_extra_info_update_callback(zegoOnRoomStreamExtraInfoUpdate, IntPtr.Zero);
            IExpressPublisherInternal.zego_register_publisher_update_stream_extra_info_result_callback(zegoOnPublisherUpdateStreamExtraInfoResult, IntPtr.Zero);
            IExpressCustomVideoInternal.zego_register_custom_video_capture_start_callback(zegoOnCustomVideoCaptureStart, IntPtr.Zero);
            IExpressCustomVideoInternal.zego_register_custom_video_capture_stop_callback(zegoOnCustomVideoCaptureStop, IntPtr.Zero);
            IExpressRoomInternal.zego_register_room_set_room_extra_info_result_callback(zegoOnRoomSetRoomExtraInfoResult, IntPtr.Zero);
            IExpressRoomInternal.zego_register_room_extra_info_update_callback(zegoOnRoomExtraInfoUpdate, IntPtr.Zero);
            IExpressEngineInternal.zego_register_engine_state_update_callback(zegoOnEngineStateUpdate, IntPtr.Zero);
            IExpressRoomInternal.zego_register_room_online_user_count_update_callback(zegoOnRoomOnlineUserCountUpdate, IntPtr.Zero);
            IExpressMediaPlayerInternal.zego_register_media_player_state_update_callback(zegoOnMediaplayerStateUpdate, IntPtr.Zero);
            IExpressMediaPlayerInternal.zego_register_media_player_load_resource_callback(zegoOnMediaplayerLoadResourceResult, IntPtr.Zero);
            IExpressMediaPlayerInternal.zego_register_media_player_playing_progress_callback(zegoOnMediaplayerPlayingProgress, IntPtr.Zero);
            IExpressMediaPlayerInternal.zego_register_media_player_network_event_callback(zegoOnMediaplayerNetworkEvent, IntPtr.Zero);
            IExpressMediaPlayerInternal.zego_register_media_player_seek_to_callback(zegoOnMediaplayerSeekToTimeResult, IntPtr.Zero);
            IExpressMediaPlayerInternal.zego_register_media_player_audio_frame_callback(zegoOnMediaplayerAudioData, IntPtr.Zero);
            IExpressMediaPlayerInternal.zego_register_media_player_video_frame_callback(zegoOnMediaplayerVideoData, IntPtr.Zero);
            IExpressMixerInternal.zego_register_mixer_start_result_callback(zegoOnMixerStartResult, IntPtr.Zero);
            IExpressMixerInternal.zego_register_mixer_stop_result_callback(zegoOnMixerStopResult, IntPtr.Zero);
            IExpressMixerInternal.zego_register_mixer_relay_cdn_state_update_callback(zegoOnMixerRelayCdnStateUpdate, IntPtr.Zero);
            IExpressMixerInternal.zego_register_mixer_sound_level_update_callback(zegoOnMixerSoundLevelUpdate, IntPtr.Zero);
            IExpressDeviceInternal.zego_register_local_device_exception_occurred_callback(zegoOnLocalDeviceExceptionOccurred, IntPtr.Zero);
            IExpressDeviceInternal.zego_register_remote_camera_state_update_callback(zegoOnRemoteCameraStateUpdate, IntPtr.Zero);
            IExpressDeviceInternal.zego_register_remote_mic_state_update_callback(zegoOnRemoteMicStateUpdate, IntPtr.Zero);
            IExpressAudioEffectPlayerInternal.zego_register_audio_effect_player_seek_to_callback(zegoOnAudioEffectPlayerSeekTo, IntPtr.Zero);
            IExpressAudioEffectPlayerInternal.zego_register_audio_effect_player_load_resource_callback(zegoOnAudioEffectPlayerLoadResource, IntPtr.Zero);
            IExpressAudioEffectPlayerInternal.zego_register_audio_effect_play_state_update_callback(zegoOnAudioEffectPlayerStateUpdate, IntPtr.Zero);
            IExpressCustomAudioIOInternal.zego_register_captured_audio_data_callback(zegoOnCapturedAudioData, IntPtr.Zero);
            IExpressCustomAudioIOInternal.zego_register_mixed_audio_data_callback(zegoOnMixedAudioData, IntPtr.Zero);
            IExpressCustomAudioIOInternal.zego_register_playback_audio_data_callback(zegoOnPlaybackAudioData, IntPtr.Zero);
            IExpressCustomAudioIOInternal.zego_register_player_audio_data_callback(zegoOnPlayerAudioData, IntPtr.Zero);
            IExpressRecordInternal.zego_register_captured_data_record_state_update_callback(zegoOnCapturedDataRecordStateUpdate, IntPtr.Zero);
            IExpressRecordInternal.zego_register_captured_data_record_progress_update_callback(zegoOnCapturedDataRecordProgressUpdate, IntPtr.Zero);
            //CopyrightedMusic
            IExpressCopyrightedMusicInternal.zego_register_copyrighted_music_send_extended_request_callback(zegoOnCopyrightedMusicSendExtendedRequest, IntPtr.Zero);
            IExpressCopyrightedMusicInternal.zego_register_copyrighted_music_init_callback(zegoOnCopyrightedMusicInit, IntPtr.Zero);
            IExpressCopyrightedMusicInternal.zego_register_copyrighted_music_request_accompaniment_callback(zegoOnCopyrightedMusciRequestAccompaniment, IntPtr.Zero);
            IExpressCopyrightedMusicInternal.zego_register_copyrighted_music_request_song_callback(zegoOnCopyreghtedMusicRequestSong, IntPtr.Zero);
            IExpressCopyrightedMusicInternal.zego_register_copyrighted_music_get_lrc_lyric_callback(zegoOnCopyreghtedMusicGetLrcLyric, IntPtr.Zero);
            IExpressCopyrightedMusicInternal.zego_register_copyrighted_music_get_krc_lyric_by_token_callback(zegoOnCopyrightedMusicGetKrcLyricByToken, IntPtr.Zero);
            IExpressCopyrightedMusicInternal.zego_register_copyrighted_music_download_callback(zegoOnCopyrightedMusicDownoad, IntPtr.Zero);
            IExpressCopyrightedMusicInternal.zego_register_copyrighted_music_download_progress_update_callback(zegoOnCopyrightedMusicDownloadProgressUpdate, IntPtr.Zero);
            IExpressCopyrightedMusicInternal.zego_register_copyrighted_music_get_music_by_token_callback(zegoOnCopyrightedMusicGetMusicByToken, IntPtr.Zero);
        }
        
        private static void DefaultOpenCustomRender()//结构体是栈区分配，值类型，传递的时候是值拷贝，通过ref引用传递值类型解决
        {
            if (enginePtr == null)
            {
                ZegoUtil.ZegoPrivateLog(-1, "enginePtr is null.", false, ZegoConstans.ZEGO_EXPRESS_MODULE_CUSTOMVIDEOIO);
                return;
            }
            ZegoCustomVideoRenderConfig customVideoRenderConfig = new ZegoCustomVideoRenderConfig
            {
                bufferType = ZegoVideoBufferType.RawData,
                frameFormatSeries = ZegoVideoFrameFormatSeries.RGB,
                enableEngineRender = false

            };
            enginePtr.EnableCustomVideoRender(true, customVideoRenderConfig);
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

        public static void release()
        {
            engineConfig = new zego_engine_config();
            ReleaseMediaPlayer();
            mediaPlayerAndIndex.Clear();
            onIMSendBarrageMessageResultDics.Clear();
            onIMSendBroadcastMessageResultDics.Clear();
            onIMSendCustomCommandResultDics.Clear();
            onPublisherSetStreamExtraInfoResultDics.Clear();
            onPublisherUpdateCdnUrlResultDics.Clear();
            onMixerStartResultDics.Clear();
            onMixerStopResultDics.Clear();
            onRoomSetRoomExtraInfoResultDics.Clear();
            //setEngineConfigFlag = false;
        }

        private static void ReleaseMediaPlayer()
        {
            int result = 0;
            string log;
            foreach (var item in mediaPlayerAndIndex)
            {
                result = IExpressMediaPlayerInternal.zego_express_destroy_media_player((ZegoMediaPlayerInstanceIndex)item.Key);
                item.Value.seekToTimeCallbackDic.Clear();
                log = string.Format("MediaPlayer Destroy index:{0} result:{1} ", item.Key, result);
                ZegoUtil.ZegoPrivateLog(result, log, true, ZegoConstans.ZEGO_EXPRESS_MODULE_MEDIAPLAYER);
            }
        }

        public static new void SetRoomMode(ZegoRoomMode mode)
        {
            int result = IExpressEngineInternal.zego_express_set_room_mode(mode);
            string log = string.Format("SetRoomMode, mode:{0}", mode);
            ZegoUtil.ZegoPrivateLog(result, log, false, ZegoConstans.ZEGO_EXPRESS_MODULE_ENGINE);
        }

        public static new string GetVersion()
        {

            string result = ZegoUtil.PtrToString(IExpressEngineInternal.zego_express_get_version());
            string log = string.Format("GetVersion SDK version:{0}", result);
            ZegoUtil.ZegoPrivateLog(0, log, false, ZegoConstans.ZEGO_EXPRESS_MODULE_ENGINE);
            return result;

        }
        public static new ZegoExpressEngine GetEngine()
        {
            return enginePtr;
        }

        public override void EnableAEC(bool enable)
        {
            if (enginePtr != null)
            {
                int result = IExpressPreprocessInternal.zego_express_enable_aec(enable);
                string log = string.Format("EnableAEC enable:{0} result:{1}", enable, result);
                ZegoUtil.ZegoPrivateLog(result, log, true, ZegoConstans.ZEGO_EXPRESS_MODULE_PREPROCESS);
            }
        }

        public override void SetAECMode(ZegoAECMode mode)
        {
            if (enginePtr != null)
            {
                int result = IExpressPreprocessInternal.zego_express_set_aec_mode(mode);
                string log = string.Format("SetAECMode ZegoAECMode:{0} result:{1}", mode, result);
                ZegoUtil.ZegoPrivateLog(result, log, true, ZegoConstans.ZEGO_EXPRESS_MODULE_PREPROCESS);
            }
        }
        public override void EnableAGC(bool enable)
        {
            if (enginePtr != null)
            {
                int result = IExpressPreprocessInternal.zego_express_enable_agc(enable);
                string log = string.Format("EnableAGC enable:{0} result:{1}", enable, result);
                ZegoUtil.ZegoPrivateLog(result, log, true, ZegoConstans.ZEGO_EXPRESS_MODULE_PREPROCESS);
            }
        }
        
        public override void EnableANS(bool enable)
        {
            if (enginePtr != null)
            {
                int result = IExpressPreprocessInternal.zego_express_enable_ans(enable);
                string log = string.Format("EnableANS enable:{0} result:{1}", enable, result);
                ZegoUtil.ZegoPrivateLog(result, log, true, ZegoConstans.ZEGO_EXPRESS_MODULE_PREPROCESS);
            }
        }

        public override void EnableTransientANS(bool enable)
        {
            if (enginePtr != null)
            {
                int result = IExpressPreprocessInternal.zego_express_enable_transient_ans(enable);
                string log = string.Format("EnableTransientANS enable:{0} result:{1}", enable, result);
                ZegoUtil.ZegoPrivateLog(result, log, true, ZegoConstans.ZEGO_EXPRESS_MODULE_PREPROCESS);
            }
        }

        public override void SetANSMode(ZegoANSMode mode)
        {
            if (enginePtr != null)
            {
                int result = IExpressPreprocessInternal.zego_express_set_ans_mode(mode);
                string log = string.Format("SetANSMode ZegoANSMode:{0} result:{1}", mode, result);
                ZegoUtil.ZegoPrivateLog(result, log, true, ZegoConstans.ZEGO_EXPRESS_MODULE_PREPROCESS);
            }
        }

        public override void SendCustomVideoCaptureRawData(byte[] data, uint dataLength, ZegoVideoFrameParam param, ulong referenceTimeMillisecond, ZegoPublishChannel channel = ZegoPublishChannel.Main)
        {
            if (enginePtr != null)
            {
                zego_video_frame_param zego_Video_Frame_Param = ChangeZegoVideoFrameParamClassToStruct(param);
                int result = IExpressCustomVideoInternal.zego_express_send_custom_video_capture_raw_data(data, dataLength, zego_Video_Frame_Param, referenceTimeMillisecond, 1000, channel);
                //string log = string.Format("SendCustomVideoCaptureRawData result:{0}", result);
                //ZegoUtil.ZegoPrivateLog(result, log, true, ZegoConstans.ZEGO_EXPRESS_MODULE_CUSTOMVIDEOIO, false);
            }
        }
        public override void SendCustomVideoCaptureRawData(IntPtr data, uint dataLength, ZegoVideoFrameParam param, ulong referenceTimeMillisecond, ZegoPublishChannel channel = ZegoPublishChannel.Main)
        {
            if (enginePtr != null)
            {
                zego_video_frame_param zego_Video_Frame_Param = ChangeZegoVideoFrameParamClassToStruct(param);
                int result = IExpressCustomVideoInternal.zego_express_send_custom_video_capture_raw_data(data, dataLength, zego_Video_Frame_Param, referenceTimeMillisecond, 1000, channel);
                //string log = string.Format("SendCustomVideoCaptureRawData result:{0}", result);
                //ZegoUtil.ZegoPrivateLog(result, log, true, ZegoConstans.ZEGO_EXPRESS_MODULE_CUSTOMVIDEOIO, false);

            }
        }


        public override void EnableCustomVideoProcessing(bool enable, ZegoCustomVideoProcessConfig config, ZegoPublishChannel channel = ZegoPublishChannel.Main)
        {
            if (enginePtr != null)
            {
                zego_custom_video_process_config custom_video_process_config_ = ChangeZegoCustomVideoProcessConfigToStruct(config);
                IntPtr config_ptr_ = ZegoUtil.GetStructPointer(custom_video_process_config_);
                int result = IExpressCustomVideoInternal.zego_express_enable_custom_video_processing(enable, config_ptr_, channel);
                string log = string.Format("EnableCustomVideoProcessing, enable:{0}, buffer_type:{1}, channel:{2}", enable, config.bufferType, channel);
                ZegoUtil.ZegoPrivateLog(result, log, true, ZegoConstans.ZEGO_EXPRESS_MODULE_CUSTOMVIDEOIO);
            }
        }

        public override void EnableCustomVideoCapture(bool enable, ZegoCustomVideoCaptureConfig config, ZegoPublishChannel channel = ZegoPublishChannel.Main)
        {
            if (enginePtr != null)
            {
                zego_custom_video_capture_config zego_Custom_Video_Capture_Config = ChangeCustomVideoCaptureConfigClassToStruct(config);
                IntPtr ptr = ZegoUtil.GetStructPointer(zego_Custom_Video_Capture_Config);
                int result = IExpressCustomVideoInternal.zego_express_enable_custom_video_capture(enable, ptr, channel);
                string log = string.Format("EnableCustomVideoCapture  enable:{0}  channel:{1}   result:{2}", enable, channel, result);
                ZegoUtil.ZegoPrivateLog(result, log, true, ZegoConstans.ZEGO_EXPRESS_MODULE_CUSTOMVIDEOIO);
            }
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
                string log = string.Format("UseAudioDevice  result:{0}", result);
                ZegoUtil.ZegoPrivateLog(result, log, true, ZegoConstans.ZEGO_EXPRESS_MODULE_DEVICE);
            }

        }
        public override void UseVideoDevice(string deviceID, ZegoPublishChannel channel = ZegoPublishChannel.Main)
        {


            if (enginePtr != null)
            {

                int result = IExpressDeviceInternal.zego_express_use_video_device(deviceID, channel);
                string log = string.Format("UseVideoDevice  result:{0}", result);
                ZegoUtil.ZegoPrivateLog(result, log, true, ZegoConstans.ZEGO_EXPRESS_MODULE_DEVICE);
            }
        }

        public override void StartAudioDataObserver(uint observerBitMask, ZegoAudioFrameParam param)
        {
            zego_audio_frame_param audioFrameParam = ChangeZegoAudioFrameParamClassToStruct(param);
            IExpressCustomAudioIOInternal.zego_express_start_audio_data_observer(observerBitMask, audioFrameParam);
        }

        public override void StopAudioDataObserver()
        {
            IExpressCustomAudioIOInternal.zego_express_stop_audio_data_observer();
        }

        public override void EnableCustomAudioIO(bool enable, ZegoCustomAudioConfig config, ZegoPublishChannel channel = ZegoPublishChannel.Main)
        {
            if (enginePtr != null)
            {
                zego_custom_audio_config custom_Audio_Config = ChangeZegoCustomAudioConfigClassToStruct(config);
                IntPtr ptr = ZegoUtil.GetStructPointer(custom_Audio_Config);
                int result = IExpressCustomAudioIOInternal.zego_express_enable_custom_audio_io(enable, ptr, channel);
                string log = string.Format("EnableCustomAudioIO  enable:{0} source_type:{1} channel:{2}  result:{3}", enable, config.sourceType, channel, result);
                ZegoUtil.ReleaseStructPointer(ptr);
                ZegoUtil.ZegoPrivateLog(result, log, true, ZegoConstans.ZEGO_EXPRESS_MODULE_CUSTOMAUDIOIO);
            }
        }


        public override void SendCustomAudioCaptureAACData(byte[] data, uint dataLength, uint configLength, ulong referenceTimeMillisecond, ZegoAudioFrameParam param, ZegoPublishChannel channel = ZegoPublishChannel.Main)
        {
            if (enginePtr != null)
            {
                zego_audio_frame_param zego_Audio_Frame_Param = ChangeZegoAudioFrameParamClassToStruct(param);
                int result = IExpressCustomAudioIOInternal.zego_express_send_custom_audio_capture_aac_data(data, dataLength, configLength, referenceTimeMillisecond, zego_Audio_Frame_Param, channel);
                string log = string.Format("SendCustomAudioCaptureAACData result:{0}", result);
                ZegoUtil.ZegoPrivateLog(result, log, true, ZegoConstans.ZEGO_EXPRESS_MODULE_CUSTOMAUDIOIO, false);
            }
        }
        public override void SendCustomAudioCapturePCMData(byte[] data, uint dataLength, ZegoAudioFrameParam param, ZegoPublishChannel channel = ZegoPublishChannel.Main)
        {
            if (enginePtr != null)
            {
                zego_audio_frame_param zego_Audio_Frame_Param = ChangeZegoAudioFrameParamClassToStruct(param);
                int result = IExpressCustomAudioIOInternal.zego_express_send_custom_audio_capture_pcm_data(data, dataLength, zego_Audio_Frame_Param, channel);
                string log = string.Format("SendCustomAudioCapturePCMData result:{0}", result);
                ZegoUtil.ZegoPrivateLog(result, log, true, ZegoConstans.ZEGO_EXPRESS_MODULE_CUSTOMAUDIOIO, false);
            }
        }
        public override void FetchCustomAudioRenderPCMData(ref byte[] data, uint dataLength, ZegoAudioFrameParam param)
        {
            if (enginePtr != null)
            {
                zego_audio_frame_param zego_Audio_Frame_Param = ChangeZegoAudioFrameParamClassToStruct(param);
                int result = IExpressCustomAudioIOInternal.zego_express_fetch_custom_audio_render_pcm_data(data, dataLength, zego_Audio_Frame_Param);
                string log = string.Format("FetchCustomAudioRenderPCMData result:{0}", result);
                ZegoUtil.ZegoPrivateLog(result, log, true, ZegoConstans.ZEGO_EXPRESS_MODULE_CUSTOMAUDIOIO, false);
            }
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
                    IntPtr ptr = IntPtr.Zero;// ChangeZegoRoomConfigClassToStructPoniter(config);
                    error_code = IExpressRoomInternal.zego_express_login_room(roomId, zegoUser, ptr);
                    ZegoUtil.ReleaseStructPointer(ptr);
                }
                string log = string.Format("LoginRoom  roomId:{0}  userId:{1}  userName:{2} result:{3}", roomId, user.userID, user.userName, error_code);
                ZegoUtil.ZegoPrivateLog(error_code, log, true, ZegoConstans.ZEGO_EXPRESS_MODULE_ROOM);

            }
        }

        public static void SetAudioHandler(ZegoMediaPlayer zegoMediaPlayer, OnAudioFrame onAudioFrame)
        {
            if (enginePtr != null)
            {
                int result = 0;
                bool enable = false;
                ZegoMediaPlayerInstanceIndex curIndex = GetIndexFromZegoMediaPlayer(zegoMediaPlayer);
                if (onAudioFrame == null)
                {
                    enable = false;
                    result = IExpressMediaPlayerInternal.zego_express_media_player_enable_audio_data(enable, curIndex);
                }
                else
                {
                    enable = true;
                    result = IExpressMediaPlayerInternal.zego_express_media_player_enable_audio_data(enable, curIndex);
                }
                string log = string.Format("SetAudioHandler enable:{0} result:{1} ", enable, result);
                ZegoUtil.ZegoPrivateLog(result, log, true, ZegoConstans.ZEGO_EXPRESS_MODULE_MEDIAPLAYER);
            }
        }

        public static void SetVideoHandler(ZegoMediaPlayer zegoMediaPlayer, ZegoVideoFrameFormat format, OnVideoFrame onVideoFrame)
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
                string log = string.Format("SetVideoHandler enable:{0} result:{1} ", enable, result);
                ZegoUtil.ZegoPrivateLog(result, log, true, ZegoConstans.ZEGO_EXPRESS_MODULE_MEDIAPLAYER);
            }
        }

        public override void LogoutRoom()
        {
            if (enginePtr != null)
            {
                int result = IExpressRoomInternal.zego_express_logout_all_room();
                string log = string.Format("LogoutRoom result:{0}", result);
                ZegoUtil.ZegoPrivateLog(result, log, true, ZegoConstans.ZEGO_EXPRESS_MODULE_ROOM);
            }
        }

        public override void LogoutRoom(string roomId)
        {
            if (enginePtr != null)
            {

                int result = IExpressRoomInternal.zego_express_logout_room(roomId);
                string log = string.Format("LogoutRoom roomId:{0}  result:{1}", roomId, result);
                ZegoUtil.ZegoPrivateLog(result, log, true, ZegoConstans.ZEGO_EXPRESS_MODULE_ROOM);
            }
        }

        public override void SwitchRoom(string fromRoomID, string toRoomID, ZegoRoomConfig config = null)
        {
            if (enginePtr != null)
            {
                IntPtr ptr = ChangeZegoRoomConfigClassToStructPoniter(config);
                int result = IExpressRoomInternal.zego_express_switch_room(fromRoomID, toRoomID, ptr);
                ZegoUtil.ReleaseStructPointer(ptr);
                string log = string.Format("SwitchRoom  fromRoomID:{0}  toRoomID:{1} result:{2}", fromRoomID, toRoomID, result);
                ZegoUtil.ZegoPrivateLog(result, log, true, ZegoConstans.ZEGO_EXPRESS_MODULE_ROOM);
            }
        }

        public override void SetRoomExtraInfo(string roomID, string key, string value, OnRoomSetRoomExtraInfoResult onRoomSetRoomExtraInfoResult)
        {
            if (enginePtr != null)
            {

                int result = IExpressRoomInternal.zego_express_set_room_extra_info(roomID, key, value);
                string log = string.Format("SetRoomExtraInfo roomID:{0}  key:{1} value:{2} result:{3}", roomID, key, value, result);
                onRoomSetRoomExtraInfoResultDics.AddOrUpdate(result, onRoomSetRoomExtraInfoResult, (key1, oldvalue) => onRoomSetRoomExtraInfoResult);
                ZegoUtil.ZegoPrivateLog(0, log, false, 0);
            }
        }


        
        public override void StartPublishingStream(string streamID, ZegoPublishChannel channel = ZegoPublishChannel.Main)
        {
            if (enginePtr != null)
            {
                int error_code = IExpressPublisherInternal.zego_express_start_publishing_stream(streamID, channel);
                string log = string.Format("StartPublishingStream streamID:{0} channel:{1} result:{2}", streamID, channel, error_code);
                ZegoUtil.ZegoPrivateLog(error_code, log, true, ZegoConstans.ZEGO_EXPRESS_MODULE_PUBLISHER);
            }
        }

        public override void StartPublishingStream(string streamID, ZegoPublisherConfig config, ZegoPublishChannel channel = ZegoPublishChannel.Main)
        {
            if (enginePtr != null)
            {
                zego_publisher_config config_struct = ChangeZegoPublisherConfigToStruct(config);
                int error_code = IExpressPublisherInternal.zego_express_start_publishing_stream_with_config(streamID, config_struct, channel);
                string log = string.Format("StartPublishingStream streamID:{0} roomID:{1}, channel:{2} result:{3}", streamID, config.roomID, channel, error_code);
                ZegoUtil.ZegoPrivateLog(error_code, log, true, ZegoConstans.ZEGO_EXPRESS_MODULE_PUBLISHER);
            }
        }

        public override void StopPublishingStream(ZegoPublishChannel channel = ZegoPublishChannel.Main)
        {
            if (enginePtr != null)
            {
                int error_code = IExpressPublisherInternal.zego_express_stop_publishing_stream(channel);
                string log = string.Format("StopPublishingStream channel:{0} result:{1}", channel, error_code);
                ZegoUtil.ZegoPrivateLog(error_code, log, true, ZegoConstans.ZEGO_EXPRESS_MODULE_PUBLISHER);
            }
        }
        public override void SendBarrageMessage(string roomID, string message, OnIMSendBarrageMessageResult onIMSendBarrageMessageResult)
        {
            if (enginePtr != null)
            {

                int result = IExpressIMInternal.zego_express_send_barrage_message(roomID, message);
                string log = string.Format("SendBarrageMessage roomID:{0}  message:{1} result:{2}", roomID, message, result);
                onIMSendBarrageMessageResultDics.AddOrUpdate(result, onIMSendBarrageMessageResult, (key, oldValue) => onIMSendBarrageMessageResult);
                ZegoUtil.ZegoPrivateLog(0, log, false, 0);
            }
        }


        public override void SendBroadcastMessage(string roomID, string message, OnIMSendBroadcastMessageResult onIMSendBroadcastMessageResult)
        {
            if (enginePtr != null)
            {
                int result = IExpressIMInternal.zego_express_send_broadcast_message(roomID, message);
                string log = string.Format("SendBroadcastMessage roomID:{0}  message:{1} result:{2}", roomID, message, result);
                onIMSendBroadcastMessageResultDics.AddOrUpdate(result, onIMSendBroadcastMessageResult, (key, oldValue) => onIMSendBroadcastMessageResult);
                ZegoUtil.ZegoPrivateLog(0, log, false, 0);
            }
        }
        public override void SetStreamExtraInfo(string extraInfo, OnPublisherSetStreamExtraInfoResult onPublisherSetStreamExtraInfoResult, ZegoPublishChannel channel = ZegoPublishChannel.Main)
        {
            if (enginePtr != null)
            {

                int result = IExpressPublisherInternal.zego_express_set_stream_extra_info(extraInfo, channel);
                string log = string.Format("SetStreamExtraInfo extraInfo:{0}  channel:{1} result:{2}", extraInfo, channel, result);
                onPublisherSetStreamExtraInfoResultDics.AddOrUpdate(result, onPublisherSetStreamExtraInfoResult, (key, oldValue) => onPublisherSetStreamExtraInfoResult);
                ZegoUtil.ZegoPrivateLog(0, log, false, 0);
            }
        }
        public override void SendCustomCommand(string roomID, string command, List<ZegoUser> toUserList, OnIMSendCustomCommandResult onIMSendCustomCommandResult)
        {
            if (enginePtr != null)
            {

                zego_user[] zegoUsers = ChangeZegoUserClassListToStructList(toUserList);
                int result = IExpressIMInternal.zego_express_send_custom_command(roomID, command, zegoUsers, (uint)zegoUsers.Length);
                string log = string.Format("SendCustomCommand roomID:{0}  command:{1} result:{2}", roomID, command, result);
                onIMSendCustomCommandResultDics.AddOrUpdate(result, onIMSendCustomCommandResult, (key, oldValue) => onIMSendCustomCommandResult);
                ZegoUtil.ZegoPrivateLog(0, log, false, 0);
            }
        }
        public override void AddPublishCdnUrl(string streamID, string targetURL, OnPublisherUpdateCdnUrlResult onPublisherUpdateCdnUrlResult)
        {
            if (enginePtr != null)
            {

                int result = IExpressPublisherInternal.zego_express_add_publish_cdn_url(streamID, targetURL);
                string log = string.Format("AddPublishCdnUrl streamID:{0} targetURL:{1} result:{2}", streamID, targetURL, result);
                onPublisherUpdateCdnUrlResultDics.AddOrUpdate(result, onPublisherUpdateCdnUrlResult, (key, oldValue) => onPublisherUpdateCdnUrlResult);
                ZegoUtil.ZegoPrivateLog(0, log, false, 0);
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
                string log = string.Format("EnableCustomVideoRender enable:{0}  result:{1}", enable, result);
                ZegoUtil.ZegoPrivateLog(result, log, true, ZegoConstans.ZEGO_EXPRESS_MODULE_CUSTOMVIDEOIO);
            }
        }

        public override void RemovePublishCdnUrl(string streamID, string targetURL, OnPublisherUpdateCdnUrlResult onPublisherUpdateCdnUrlResult)
        {
            if (enginePtr != null)
            {

                int result = IExpressPublisherInternal.zego_express_remove_publish_cdn_url(streamID, targetURL);
                string log = string.Format("RemovePublishCdnUrl streamID:{0} targetURL:{1} result:{2}", streamID, targetURL, result);
                onPublisherUpdateCdnUrlResultDics.AddOrUpdate(result, onPublisherUpdateCdnUrlResult, (key, oldValue) => onPublisherUpdateCdnUrlResult);
                ZegoUtil.ZegoPrivateLog(0, log, false, 0);
            }
        }

        public static void Stop(ZegoMediaPlayer zegoMediaPlayer)
        {
            if (enginePtr != null)
            {
                ZegoMediaPlayerInstanceIndex index = GetIndexFromZegoMediaPlayer(zegoMediaPlayer);
                int result = IExpressMediaPlayerInternal.zego_express_media_player_stop(index);
                string log = string.Format("MediaPlayer Stop index:{0}  result:{1} ", index, result);
                ZegoUtil.ZegoPrivateLog(result, log, true, ZegoConstans.ZEGO_EXPRESS_MODULE_MEDIAPLAYER);
            }
        }

        public static ZegoMediaPlayerState GetCurrentState(ZegoMediaPlayer zegoMediaPlayer)
        {
            ZegoMediaPlayerState state = ZegoMediaPlayerState.NoPlay;
            if (enginePtr != null)
            {
                ZegoMediaPlayerInstanceIndex index = GetIndexFromZegoMediaPlayer(zegoMediaPlayer);
                state = IExpressMediaPlayerInternal.zego_express_media_player_get_current_state(index);
                string log = string.Format("MediaPlayer GetCurrentState index:{0}  result:{1} ", index, state);
                ZegoUtil.ZegoPrivateLog(0, log, false, 0);
            }
            return state;
        }

        public static void Resume(ZegoMediaPlayer zegoMediaPlayer)
        {
            if (enginePtr != null)
            {
                ZegoMediaPlayerInstanceIndex index = GetIndexFromZegoMediaPlayer(zegoMediaPlayer);
                int result = IExpressMediaPlayerInternal.zego_express_media_player_resume(index);
                string log = string.Format("MediaPlayer Resume index:{0}  result:{1} ", index, result);
                ZegoUtil.ZegoPrivateLog(result, log, true, ZegoConstans.ZEGO_EXPRESS_MODULE_MEDIAPLAYER);
            }
        }

        public static void SeekTo(ZegoMediaPlayer zegoMediaPlayer, ulong millisecond, OnSeekToTimeCallback onSeekToTimeCallback)
        {
            if (enginePtr != null)
            {
                ZegoMediaPlayerInstanceIndex index = GetIndexFromZegoMediaPlayer(zegoMediaPlayer);
                int seq = IExpressMediaPlayerInternal.zego_express_media_player_seek_to(millisecond, index);
                string log = string.Format("MediaPlayer SeekTo index:{0} millisecond:{1} result:{2} ", index, millisecond, seq);
                zegoMediaPlayer.seekToTimeCallbackDic.AddOrUpdate(seq, onSeekToTimeCallback, (key, oldValue) => onSeekToTimeCallback);
                ZegoUtil.ZegoPrivateLog(0, log, false, 0);
            }
        }
        public override void DestroyMediaPlayer(ZegoMediaPlayer mediaPlayer)
        {
            if (enginePtr != null)
            {
                ZegoMediaPlayerInstanceIndex index = GetIndexFromZegoMediaPlayer(mediaPlayer);
                int result = IExpressMediaPlayerInternal.zego_express_destroy_media_player(index);
                string log = string.Format("MediaPlayer Destroy index:{0} result:{1} ", index, result);
                mediaPlayer.seekToTimeCallbackDic.Clear();
                mediaPlayerAndIndex.TryRemove((int)index, out _);
                ZegoUtil.ZegoPrivateLog(result, log, true, ZegoConstans.ZEGO_EXPRESS_MODULE_MEDIAPLAYER);
            }
        }

        public static void MuteLocal(ZegoMediaPlayer zegoMediaPlayer, bool mute)
        {
            if (enginePtr != null)
            {
                ZegoMediaPlayerInstanceIndex index = GetIndexFromZegoMediaPlayer(zegoMediaPlayer);
                int result = IExpressMediaPlayerInternal.zego_express_media_player_mute_local_audio(mute, index);
                string log = string.Format("MediaPlayer MuteLocal index:{0} mute:{1} result:{2} ", index, mute, result);
                ZegoUtil.ZegoPrivateLog(result, log, true, ZegoConstans.ZEGO_EXPRESS_MODULE_MEDIAPLAYER);
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
                string log = string.Format("MediaPlayer SetPlayerCanvas index:{0}  result:{1} ", index, result);
                ZegoUtil.ReleaseStructPointer(ptr);
                ZegoUtil.ZegoPrivateLog(result, log, true, ZegoConstans.ZEGO_EXPRESS_MODULE_MEDIAPLAYER);
            }
        }

        public static void SetVolume(ZegoMediaPlayer zegoMediaPlayer, int volume)
        {
            if (enginePtr != null)
            {
                ZegoMediaPlayerInstanceIndex index = GetIndexFromZegoMediaPlayer(zegoMediaPlayer);
                int result = IExpressMediaPlayerInternal.zego_express_media_player_set_volume(volume, index);
                string log = string.Format("MediaPlayer SetVolume index:{0} volume:{1} result:{2} ", index, volume, result);
                ZegoUtil.ZegoPrivateLog(result, log, true, ZegoConstans.ZEGO_EXPRESS_MODULE_MEDIAPLAYER);
            }
        }

        public static void SetProgressInterval(ZegoMediaPlayer zegoMediaPlayer, ulong millisecond)
        {
            if (enginePtr != null)
            {
                ZegoMediaPlayerInstanceIndex index = GetIndexFromZegoMediaPlayer(zegoMediaPlayer);
                int result = IExpressMediaPlayerInternal.zego_express_media_player_set_progress_interval(millisecond, index);
                string log = string.Format("MediaPlayer SetProgressInterval index:{0} millisecond:{1} result:{2} ", index, millisecond, result);
                ZegoUtil.ZegoPrivateLog(result, log, true, ZegoConstans.ZEGO_EXPRESS_MODULE_MEDIAPLAYER);
            }
        }

        public static ulong GetTotalDuration(ZegoMediaPlayer zegoMediaPlayer)
        {
            ulong result = 0;
            if (enginePtr != null)
            {
                ZegoMediaPlayerInstanceIndex index = GetIndexFromZegoMediaPlayer(zegoMediaPlayer);
                result = IExpressMediaPlayerInternal.zego_express_media_player_get_total_duration(index);
                string log = string.Format("MediaPlayer GetTotalDuration index:{0} result:{1} ", index, result);
                ZegoUtil.ZegoPrivateLog(0, log, false, 0);

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
                string log = string.Format("MediaPlayer GetCurrentProgress index:{0} result:{1} ", index, result);
                ZegoUtil.ZegoPrivateLog(0, log, false, 0);
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



        public static void EnableAux(ZegoMediaPlayer zegoMediaPlayer, bool enable)
        {
            if (enginePtr != null)
            {
                ZegoMediaPlayerInstanceIndex index = GetIndexFromZegoMediaPlayer(zegoMediaPlayer);
                int result = IExpressMediaPlayerInternal.zego_express_media_player_enable_aux(enable, index);
                string log = string.Format("MediaPlayer EnableAux index:{0} result:{1} enable{2}", index, result, enable);
                ZegoUtil.ZegoPrivateLog(result, log, true, ZegoConstans.ZEGO_EXPRESS_MODULE_MEDIAPLAYER);
            }
        }

        public static void Pause(ZegoMediaPlayer zegoMediaPlayer)
        {
            if (enginePtr != null)
            {
                ZegoMediaPlayerInstanceIndex index = GetIndexFromZegoMediaPlayer(zegoMediaPlayer);
                int result = IExpressMediaPlayerInternal.zego_express_media_player_pause(index);
                string log = string.Format("MediaPlayer Pause index:{0} result:{1}", index, result);
                ZegoUtil.ZegoPrivateLog(result, log, true, ZegoConstans.ZEGO_EXPRESS_MODULE_MEDIAPLAYER);
            }
        }

        public static void Start(ZegoMediaPlayer zegoMediaPlayer)
        {
            if (enginePtr != null)
            {
                ZegoMediaPlayerInstanceIndex index = GetIndexFromZegoMediaPlayer(zegoMediaPlayer);
                int result = IExpressMediaPlayerInternal.zego_express_media_player_start(index);
                string log = string.Format("MediaPlayer Start index:{0} result:{1}", index, result);
                ZegoUtil.ZegoPrivateLog(result, log, true, ZegoConstans.ZEGO_EXPRESS_MODULE_MEDIAPLAYER);
            }
        }

        public static void EnableRepeat(ZegoMediaPlayer zegoMediaPlayer, bool enable)
        {
            if (enginePtr != null)
            {
                ZegoMediaPlayerInstanceIndex index = GetIndexFromZegoMediaPlayer(zegoMediaPlayer);
                int result = IExpressMediaPlayerInternal.zego_express_media_player_enable_repeat(enable, index);
                string log = string.Format("EnableRepeat enable:{0} result:{1}", enable, result);
                ZegoUtil.ZegoPrivateLog(result, log, true, ZegoConstans.ZEGO_EXPRESS_MODULE_MEDIAPLAYER);
            }
        }

        public static void LoadResource(ZegoMediaPlayer zegoMediaPlayer, string path)
        {
            if (enginePtr != null)
            {
                ZegoMediaPlayerInstanceIndex curIndex = GetIndexFromZegoMediaPlayer(zegoMediaPlayer);
                int result = IExpressMediaPlayerInternal.zego_express_media_player_load_resource(path, curIndex);
                string log = string.Format("LoadResource result:{0}  path:{1} ", result, path);
                ZegoUtil.ZegoPrivateLog(0, log, false, 0);
            }
        }
        public static ZegoMediaPlayerInstanceIndex GetIndexFromZegoMediaPlayer(ZegoMediaPlayer zegoMediaPlayer)
        {
            ZegoMediaPlayerInstanceIndex result = ZegoMediaPlayerInstanceIndex.Null;
            foreach (KeyValuePair<int, ZegoMediaPlayer> kvp in mediaPlayerAndIndex)
            {
                if (kvp.Value == zegoMediaPlayer)
                {
                    result = (ZegoMediaPlayerInstanceIndex)kvp.Key;
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

        public override void StartPreview(ZegoCanvas zegoCanvas, ZegoPublishChannel channel = ZegoPublishChannel.Main)
        {
            if (enginePtr != null)
            {
                IntPtr ptr = IntPtr.Zero;
                if (zegoCanvas != null)
                {
                    zego_canvas canvas = ChangeZegoCanvasClassToStruct(zegoCanvas);
                    ptr = ZegoUtil.GetStructPointer(canvas);
                }
                int result = IExpressPublisherInternal.zego_express_start_preview(ptr, channel);
                ZegoUtil.ReleaseStructPointer(ptr);
                string log = string.Format("StartPreview  channel:{0} result:{1}", channel, result);
                ZegoUtil.ZegoPrivateLog(result, log, true, ZegoConstans.ZEGO_EXPRESS_MODULE_PUBLISHER);

            }
        }

        public override void StopPreview(ZegoPublishChannel channel = ZegoPublishChannel.Main)
        {
            if (enginePtr != null)
            {
                int result = IExpressPublisherInternal.zego_express_stop_preview(channel);
                string log = string.Format("StopPreview  channel:{0} result:{1}", channel, result);
                ZegoUtil.ZegoPrivateLog(result, log, true, ZegoConstans.ZEGO_EXPRESS_MODULE_PUBLISHER);
            }
        }
        public override void StartPlayingStream(string streamId, ZegoCanvas canvas, ZegoPlayerConfig config = null)
        {
            if (enginePtr != null)
            {
                int result = 0;
                IntPtr ptr = IntPtr.Zero;
                if (canvas != null)
                {
                    zego_canvas zegoCanvas = ChangeZegoCanvasClassToStruct(canvas);
                    ptr = ZegoUtil.GetStructPointer(zegoCanvas);
                }
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
                string log = string.Format("StartPlayingStream streamId:{0} result:{1}", streamId, result);
                ZegoUtil.ZegoPrivateLog(result, log, true, ZegoConstans.ZEGO_EXPRESS_MODULE_PLAYER);
            }
        }

        public override void EnablePublishDirectToCDN(bool enable, ZegoCDNConfig config, ZegoPublishChannel channel = ZegoPublishChannel.Main)
        {
            if (enginePtr != null)
            {
                IntPtr ptr = ZegoUtil.GetStructPointer(ChangeCDNConfigClassToStruct(config));
                int result = IExpressPublisherInternal.zego_express_enable_publish_direct_to_cdn(enable, ptr, channel);
                ZegoUtil.ReleaseStructPointer(ptr);
                string log = string.Format("EnablePublishDirectToCDN enable:{0} channel:{1} result:{2}", enable, channel, result);
                ZegoUtil.ZegoPrivateLog(result, log, true, ZegoConstans.ZEGO_EXPRESS_MODULE_PUBLISHER);
            }
        }

        public override void SetAppOrientation(ZegoOrientation orientation, ZegoPublishChannel channel = ZegoPublishChannel.Main)//设置采集视频的朝向（仅Android平台）,逆时针
        {
            if (enginePtr != null)
            {
                int result = IExpressPublisherInternal.zego_express_set_app_orientation(orientation, channel);
                string log = string.Format("SetAppOrientation orientation:{0} channel:{1} result:{2}", orientation, channel, result);
                ZegoUtil.ZegoPrivateLog(result, log, true, ZegoConstans.ZEGO_EXPRESS_MODULE_PUBLISHER);
            }
        }

        public override void StartMixerTask(ZegoMixerTask task, OnMixerStartResult onMixerStartResult)
        {
            if (enginePtr != null)
            {
                zego_mixer_task zego_Mixer_Task = ChangeZegoMixerTaskClassToStruct(task);
                int result = IExpressMixerInternal.zego_express_start_mixer_task(zego_Mixer_Task);//result is seq
                string log = string.Format("StartMixerTask  result:{0}", result);
                ZegoUtil.ReleaseAllStructPointers(mixerPtrArrayList);
                ZegoUtil.ReleaseStructPointer(zego_Mixer_Task.watermark);
                onMixerStartResultDics.AddOrUpdate(result, onMixerStartResult, (key, oldValue) => onMixerStartResult);
                ZegoUtil.ZegoPrivateLog(0, log, false, 0);
            }
        }

        public override void StopMixerTask(ZegoMixerTask task, OnMixerStopResult onMixerStopResult)
        {
            if (enginePtr != null)
            {
                zego_mixer_task zego_Mixer_Task = ChangeZegoMixerTaskClassToStruct(task);
                int result = IExpressMixerInternal.zego_express_stop_mixer_task(zego_Mixer_Task);
                string log = string.Format("StopMixerTask  result:{0}", result);
                ZegoUtil.ReleaseAllStructPointers(mixerPtrArrayList);
                ZegoUtil.ReleaseStructPointer(zego_Mixer_Task.watermark);
                onMixerStopResultDics.AddOrUpdate(result, onMixerStopResult, (key, oldValue) => onMixerStopResult);
                ZegoUtil.ZegoPrivateLog(0, log, false, 0);
            }

        }

        public override void StopPlayingStream(string streamId)
        {
            if (enginePtr != null)
            {

                int result = IExpressPlayerInternal.zego_express_stop_playing_stream(streamId);
                string log = string.Format("StopPlayingStream streamId:{0} result:{1}", streamId, result);
                ZegoUtil.ZegoPrivateLog(result, log, true, ZegoConstans.ZEGO_EXPRESS_MODULE_PLAYER);
            }
        }

        public override void SetVideoConfig(ZegoVideoConfig config, ZegoPublishChannel channel = ZegoPublishChannel.Main)
        {
            if (enginePtr != null)
            {
                int result = IExpressPublisherInternal.zego_express_set_video_config(ChangeVideoConfigClassToStruct(config), channel);
                string log = string.Format("SetVideoConfig channel:{0}  result:{1}", channel, result);
                ZegoUtil.ZegoPrivateLog(result, log, true, ZegoConstans.ZEGO_EXPRESS_MODULE_PUBLISHER);
            }
        }

        public override ZegoVideoConfig GetVideoConfig(ZegoPublishChannel channel = ZegoPublishChannel.Main)
        {
            ZegoVideoConfig zegoVideoConfig = null;
            if (enginePtr != null)
            {
                zego_video_config zego_Video_Config = IExpressPublisherInternal.zego_express_get_video_config(channel);
                zegoVideoConfig = ChangeVideoConfigStructToClass(zego_Video_Config);
                string log = string.Format("GetVideoConfig");
                ZegoUtil.ZegoPrivateLog(0, log, false, 0);
            }
            return zegoVideoConfig;
        }

        public override void SetVideoMirrorMode(ZegoVideoMirrorMode mirrorMode, ZegoPublishChannel channel = ZegoPublishChannel.Main)
        {
            if (enginePtr != null)
            {
                int result = IExpressPublisherInternal.zego_express_set_video_mirror_mode(mirrorMode, channel);
                string log = string.Format("SetVideoMirrorMode mirrorMode:{0}  channel:{1}  result:{2}", mirrorMode, channel, result);
                ZegoUtil.ZegoPrivateLog(result, log, true, ZegoConstans.ZEGO_EXPRESS_MODULE_PUBLISHER);
            }
        }
        //public override void SetAudioConfig(ZegoAudioConfig config)
        //{
        //    if (enginePtr != null)
        //    {
        //        int result = IExpressPublisherInternal.zego_express_set_audio_config(ChangeAudioConfigClassToStruct(config));
        //        string log = string.Format("SetAudioConfig result:{0}", result);
        //        ZegoUtil.ZegoPrivateLog(result, log, true, ZegoConstans.ZEGO_EXPRESS_MODULE_PUBLISHER);
        //    }
        //}

        public override void SetAudioConfig(ZegoAudioConfig config, ZegoPublishChannel channel = ZegoPublishChannel.Main)
        {
            if (enginePtr != null)
            {
                int result = IExpressPublisherInternal.zego_express_set_audio_config_by_channel(ChangeAudioConfigClassToStruct(config), channel);
                string log = string.Format("SetAudioConfig result:{0}", result);
                ZegoUtil.ZegoPrivateLog(result, log, true, ZegoConstans.ZEGO_EXPRESS_MODULE_PUBLISHER);
            }
        }

        public override ZegoAudioConfig GetAudioConfig()
        {
            ZegoAudioConfig zegoAudioConfig = null;
            if (enginePtr != null)
            {
                zego_audio_config zego_Audio_Config = IExpressPublisherInternal.zego_express_get_audio_config();
                zegoAudioConfig = ChangeAudioConfigStructToClass(zego_Audio_Config);
                string log = string.Format("GetAudioConfig");
                ZegoUtil.ZegoPrivateLog(0, log, false, 0);
            }
            return zegoAudioConfig;
        }

        public override void MutePublishStreamAudio(bool mute, ZegoPublishChannel channel = ZegoPublishChannel.Main)
        {
            if (enginePtr != null)
            {
                int result = IExpressPublisherInternal.zego_express_mute_publish_stream_audio(mute, channel);
                string log = string.Format("MutePublishStreamAudio mute:{0} channel:{1} result:{2}", mute, channel, result);
                ZegoUtil.ZegoPrivateLog(result, log, true, ZegoConstans.ZEGO_EXPRESS_MODULE_PUBLISHER);
            }
        }
        public override void MutePublishStreamVideo(bool mute, ZegoPublishChannel channel = ZegoPublishChannel.Main)
        {
            if (enginePtr != null)
            {
                int result = IExpressPublisherInternal.zego_express_mute_publish_stream_video(mute, channel);
                string log = string.Format("MutePublishStreamVideo mute:{0} channel:{1} result:{2}", mute, channel, result);
                ZegoUtil.ZegoPrivateLog(result, log, true, ZegoConstans.ZEGO_EXPRESS_MODULE_PUBLISHER);
            }
        }
        public override void EnableTrafficControl(bool enable, int property)
        {
            if (enginePtr != null)
            {
                int result = IExpressPublisherInternal.zego_express_enable_traffic_control(enable, property);
                string log = string.Format("EnableTrafficControl enable:{0} property:{1} result:{2}", enable, property, result);
                ZegoUtil.ZegoPrivateLog(result, log, true, ZegoConstans.ZEGO_EXPRESS_MODULE_PUBLISHER);
            }
        }
        public override void SetMinVideoBitrateForTrafficControl(int bitrate, ZegoTrafficControlMinVideoBitrateMode mode)
        {
            if (enginePtr != null)
            {
                int result = IExpressPublisherInternal.zego_express_set_min_video_bitrate_for_traffic_control(bitrate, mode);
                string log = string.Format("SetMinVideoBitrateForTrafficControl bitrate:{0} mode:{1} result:{2}", bitrate, mode, result);
                ZegoUtil.ZegoPrivateLog(result, log, true, ZegoConstans.ZEGO_EXPRESS_MODULE_PUBLISHER);
            }
        }
        public override void SetCaptureVolume(int volume)
        {
            if (enginePtr != null)
            {
                int result = IExpressPublisherInternal.zego_express_set_capture_volume(volume);
                string log = string.Format("SetCaptureVolume volume:{0} result:{1}", volume, result);
                ZegoUtil.ZegoPrivateLog(result, log, true, ZegoConstans.ZEGO_EXPRESS_MODULE_PUBLISHER);
            }
        }

        public override void SetAudioCaptureStereoMode(ZegoAudioCaptureStereoMode mode)
        {
            if (enginePtr != null)
            {
                int result = IExpressPublisherInternal.zego_express_set_audio_capture_stereo_mode(mode);
                string log = string.Format("SetAudioCaptureStereoMode  mode {0}", mode);
                ZegoUtil.ZegoPrivateLog(result, log, true, ZegoConstans.ZEGO_EXPRESS_MODULE_PUBLISHER);
            }
        }
        public override void EnableHardwareEncoder(bool enable)
        {
            if (enginePtr != null)
            {
                int result = IExpressPublisherInternal.zego_express_enable_hardware_encoder(enable);
                string log = string.Format("EnableHardwareEncoder enable:{0} result:{1}", enable, result);
                ZegoUtil.ZegoPrivateLog(result, log, true, ZegoConstans.ZEGO_EXPRESS_MODULE_PUBLISHER);
            }
        }

        public override void UploadLog()
        {
            if (enginePtr != null)
            {
                IExpressEngineInternal.zego_express_upload_log();
            }
        }
        public override void SetCapturePipelineScaleMode(ZegoCapturePipelineScaleMode mode)
        {
            if (enginePtr != null)
            {
                int result = IExpressPublisherInternal.zego_express_set_capture_pipeline_scale_mode(mode);
                string log = string.Format("SetCapturePipelineScaleMode mode:{0} result:{1}", mode, result);
                ZegoUtil.ZegoPrivateLog(result, log, true, ZegoConstans.ZEGO_EXPRESS_MODULE_PUBLISHER);
            }
        }

        public override void SetPlayVolume(string streamId, int volume)
        {
            if (enginePtr != null)
            {
                int result = IExpressPlayerInternal.zego_express_set_play_volume(streamId, volume);
                string log = string.Format("SetPlayVolume streamId:{0} volume:{1} result:{2}", streamId, volume, result);
                ZegoUtil.ZegoPrivateLog(result, log, true, ZegoConstans.ZEGO_EXPRESS_MODULE_PLAYER);
            }
        }
        public override void MutePlayStreamAudio(string streamId, bool mute)
        {
            if (enginePtr != null)
            {
                int result = IExpressPlayerInternal.zego_express_mute_play_stream_audio(streamId, mute);
                string log = string.Format("MutePlayStreamAudio streamId:{0} mute:{1}", streamId, mute);
                ZegoUtil.ZegoPrivateLog(result, log, true, ZegoConstans.ZEGO_EXPRESS_MODULE_PLAYER);
            }
        }
        public override void MutePlayStreamVideo(string streamId, bool mute)
        {
            if (enginePtr != null)
            {
                int result = IExpressPlayerInternal.zego_express_mute_play_stream_video(streamId, mute);
                string log = string.Format("MutePlayStreamVideo streamId:{0} mute:{1} result:{2}", streamId, mute, result);
                ZegoUtil.ZegoPrivateLog(result, log, true, ZegoConstans.ZEGO_EXPRESS_MODULE_PLAYER);
            }
        }
        public override void EnableCheckPoc(bool enable)
        {
            if (enginePtr != null)
            {
                int result = IExpressPlayerInternal.zego_express_enable_check_poc(enable);
                string log = string.Format("EnableCheckPoc enable:{0} result:{1}", enable, result);
                ZegoUtil.ZegoPrivateLog(result, log, true, ZegoConstans.ZEGO_EXPRESS_MODULE_PLAYER);
            }
        }
        public override void UseFrontCamera(bool enable, ZegoPublishChannel channel = ZegoPublishChannel.Main)
        {
            if (enginePtr != null)
            {
                int result = IExpressDeviceInternal.zego_express_use_front_camera(enable, channel);
                string log = string.Format("UseFrontCamera enable:{0} channel:{1} result:{2}", enable, channel, result);
                ZegoUtil.ZegoPrivateLog(result, log, true, ZegoConstans.ZEGO_EXPRESS_MODULE_DEVICE);
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

        public override void EnableHardwareDecoder(bool enable)
        {
            if (enginePtr != null)
            {
                int result = IExpressPlayerInternal.zego_express_enable_hardware_decoder(enable);
                string log = string.Format("EnableHardwareDecoder enable:{0} result:{1}", enable, result);
                ZegoUtil.ZegoPrivateLog(result, log, true, ZegoConstans.ZEGO_EXPRESS_MODULE_PLAYER);
            }
        }
        public override void SendSEI(byte[] data, ZegoPublishChannel channel = ZegoPublishChannel.Main)
        {
            if (enginePtr != null)
            {
                int result = IExpressPublisherInternal.zego_express_send_sei(Marshal.UnsafeAddrOfPinnedArrayElement(data, 0), (uint)data.Length, channel);
                string log = string.Format("SendSEI channel:{0} result:{1}", channel, result);
                ZegoUtil.ZegoPrivateLog(result, log, true, ZegoConstans.ZEGO_EXPRESS_MODULE_PUBLISHER, false);
            }
        }

        
        public static ZegoMediaPlayer GetMediaPlayerFromIndex(ZegoMediaPlayerInstanceIndex index)
        {
            ZegoMediaPlayer zegoMediaPlayer = null;
            mediaPlayerAndIndex.TryGetValue((int)index, out zegoMediaPlayer);
            if (zegoMediaPlayer == null)
            {
                throw new Exception("GetMediaPlayerFromIndex null");
            }
            return zegoMediaPlayer;
        }

        public override void StartAudioSpectrumMonitor(uint milliSecond = 100)
        {
            if (enginePtr != null)
            {
                int result = IExpressDeviceInternal.zego_express_start_audio_spectrum_monitor(milliSecond);
                string log = string.Format("StartAudioSpectrumMonitor result:{0}", result);
                ZegoUtil.ZegoPrivateLog(result, log, true, ZegoConstans.ZEGO_EXPRESS_MODULE_DEVICE);
            }
        }
        public override void StartSoundLevelMonitor(uint milliSecond = 100)
        {
            if (enginePtr != null)
            {
                int result = IExpressDeviceInternal.zego_express_start_sound_level_monitor(milliSecond);
                string log = string.Format("StartSoundLevelMonitor result:{0}", result);
                ZegoUtil.ZegoPrivateLog(result, log, true, ZegoConstans.ZEGO_EXPRESS_MODULE_DEVICE);
            }
        }

        public override void StartSoundLevelMonitor(ZegoSoundLevelConfig config)
        {
            if (enginePtr != null)
            {
                zego_sound_level_config config_struct = ChangeZegoSoundLevelConfigToStruct(config);
                int result = IExpressDeviceInternal.zego_express_start_sound_level_monitor_with_config(config_struct);
                string log = string.Format("StartSoundLevelMonitor result:{0}", result);
                ZegoUtil.ZegoPrivateLog(result, log, true, ZegoConstans.ZEGO_EXPRESS_MODULE_DEVICE);
            }
        }

        public override void StopAudioSpectrumMonitor()
        {
            if (enginePtr != null)
            {
                int result = IExpressDeviceInternal.zego_express_stop_audio_spectrum_monitor();
                string log = string.Format("StopAudioSpectrumMonitor result:{0}", result);
                ZegoUtil.ZegoPrivateLog(result, log, true, ZegoConstans.ZEGO_EXPRESS_MODULE_DEVICE);
            }
        }
        public override void StopSoundLevelMonitor()
        {
            if (enginePtr != null)
            {
                int result = IExpressDeviceInternal.zego_express_stop_sound_level_monitor();
                string log = string.Format("StopSoundLevelMonitor result:{0}", result);
                ZegoUtil.ZegoPrivateLog(result, log, true, ZegoConstans.ZEGO_EXPRESS_MODULE_DEVICE);
            }
        }
        public override void MuteMicrophone(bool mute)
        {
            if (enginePtr != null)
            {
                int result = IExpressDeviceInternal.zego_express_mute_microphone(mute);
                string log = string.Format("MuteMicrophone mute:{0} result:{1}", mute, result);
                ZegoUtil.ZegoPrivateLog(result, log, true, ZegoConstans.ZEGO_EXPRESS_MODULE_DEVICE);
            }
        }
        public override void MuteSpeaker(bool mute)
        {
            if (enginePtr != null)
            {
                int result = IExpressDeviceInternal.zego_express_mute_speaker(mute);
                string log = string.Format("MuteSpeaker mute:{0} result:{1}", mute, result);
                ZegoUtil.ZegoPrivateLog(result, log, true, ZegoConstans.ZEGO_EXPRESS_MODULE_DEVICE);
            }
        }
        public override void EnableCamera(bool enable, ZegoPublishChannel channel = ZegoPublishChannel.Main)
        {
            if (enginePtr != null)
            {
                int result = IExpressDeviceInternal.zego_express_enable_camera(enable, channel);
                string log = string.Format("EnableCamera enable:{0} channel:{1} result:{2}", enable, channel, result);
                ZegoUtil.ZegoPrivateLog(result, log, true, ZegoConstans.ZEGO_EXPRESS_MODULE_DEVICE);
            }
        }
        public override ZegoMediaPlayer CreateMediaPlayer()
        {
            if (enginePtr != null)
            {
                ZegoMediaPlayerInstanceIndex result = IExpressMediaPlayerInternal.zego_express_create_media_player();
                string log = string.Format("CreateMediaPlayer  result:{0}", result);
                ZegoUtil.ZegoPrivateLog(0, log, false, 0);
                if (result >= 0)
                {
                    ZegoMediaPlayer zegoMediaPlayer = new ZegoMediaPlayerImpl();
                    mediaPlayerAndIndex.AddOrUpdate((int)result, zegoMediaPlayer, (key, oldValue) => zegoMediaPlayer);
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

        public override void StartRecordingCapturedData(ZegoDataRecordConfig config, ZegoPublishChannel channel = ZegoPublishChannel.Main)
        {
            if (enginePtr != null)
            {
                int result = IExpressRecordInternal.zego_express_start_recording_captured_data(ChangeZegoDataRecordConfigClassToStruct(config), channel);
                string log = string.Format("StartRecordingCapturedData channel:{0} result:{1}", channel, result);
                ZegoUtil.ZegoPrivateLog(result, log, true, ZegoConstans.ZEGO_EXPRESS_MODULE_RECORD);
            }
        }

        public override void StopRecordingCapturedData(ZegoPublishChannel channel = ZegoPublishChannel.Main)
        {
            if (enginePtr != null)
            {
                int result = IExpressRecordInternal.zego_express_stop_recording_captured_data(channel);
                string log = string.Format("StopRecordingCapturedData channel:{0} result:{1}", channel, result);
                ZegoUtil.ZegoPrivateLog(result, log, true, ZegoConstans.ZEGO_EXPRESS_MODULE_RECORD);
            }
        }

        

        public static void SetMediaPlayerPlayVolume(ZegoMediaPlayer zegoMediaPlayer, int volume)
        {
            if (enginePtr != null)
            {
                ZegoMediaPlayerInstanceIndex index = GetIndexFromZegoMediaPlayer(zegoMediaPlayer);
                int result = IExpressMediaPlayerInternal.zego_express_media_player_set_play_volume(volume, index);
                string log = string.Format("MediaPlayer SetMediaPlayerPlayVolume index:{0} volume:{1} result:{2} ", index, volume, result);
                ZegoUtil.ZegoPrivateLog(result, log, true, ZegoConstans.ZEGO_EXPRESS_MODULE_MEDIAPLAYER);
            }
        }
        public static void SetMediaPlayerPublishVolume(ZegoMediaPlayer zegoMediaPlayer, int volume)
        {
            if (enginePtr != null)
            {
                ZegoMediaPlayerInstanceIndex index = GetIndexFromZegoMediaPlayer(zegoMediaPlayer);
                int result = IExpressMediaPlayerInternal.zego_express_media_player_set_publish_volume(volume, index);
                string log = string.Format("MediaPlayer SetMediaPlayerPublishVolume index:{0} volume:{1} result:{2} ", index, volume, result);
                ZegoUtil.ZegoPrivateLog(result, log, true, ZegoConstans.ZEGO_EXPRESS_MODULE_MEDIAPLAYER);
            }
        }
        public static int GetMediaPlayerPlayVolume(ZegoMediaPlayer zegoMediaPlayer)
        {
            int result = -1;
            if (enginePtr != null)
            {
                ZegoMediaPlayerInstanceIndex index = GetIndexFromZegoMediaPlayer(zegoMediaPlayer);
                result = IExpressMediaPlayerInternal.zego_express_media_player_get_play_volume(index);
                string log = string.Format("MediaPlayer GetMediaPlayerPlayVolume index:{0} result:{1} ", index, result);
                ZegoUtil.ZegoPrivateLog(0, log, false, 0);
            }
            return result;
        }
        public static int GetMediaPlayerPublishVolume(ZegoMediaPlayer zegoMediaPlayer)
        {
            int result = -1;
            if (enginePtr != null)
            {
                ZegoMediaPlayerInstanceIndex index = GetIndexFromZegoMediaPlayer(zegoMediaPlayer);
                result = IExpressMediaPlayerInternal.zego_express_media_player_get_publish_volume(index);
                string log = string.Format("MediaPlayer GetMediaPlayerPublishVolume index:{0} result:{1} ", index, result);
                ZegoUtil.ZegoPrivateLog(0, log, false, 0);
            }
            return result;
        }

        public static uint GetAudioTrackCount(ZegoMediaPlayer zegoMediaPlayer)
        {
            uint audio_track_count = 0;
            if(enginePtr != null)
            {
                ZegoMediaPlayerInstanceIndex index = GetIndexFromZegoMediaPlayer(zegoMediaPlayer);
                audio_track_count = IExpressMediaPlayerInternal.zego_express_media_player_get_audio_track_count(index);
            }

            return audio_track_count;
        }

        public static void SetAudioTrackIndex(ZegoMediaPlayer zegoMediaPlayer, uint index)
        {
            if (enginePtr != null)
            {
                ZegoMediaPlayerInstanceIndex player_index = GetIndexFromZegoMediaPlayer(zegoMediaPlayer);
                int result = IExpressMediaPlayerInternal.zego_express_media_player_set_audio_track_index(index, player_index);
                string log = string.Format("MediaPlayer SetAudioTrackIndex, index:{0}, track index:{1}, result:{2}", player_index, index, result);
                ZegoUtil.ZegoPrivateLog(result, log, true, ZegoConstans.ZEGO_EXPRESS_MODULE_MEDIAPLAYER);
            }
        }

        public override bool IsMicrophoneMuted()
        {
            bool result = false;
            if (enginePtr != null)
            {
                result = IExpressDeviceInternal.zego_express_is_microphone_muted();
                string log = string.Format("IsMicrophoneMuted  result:{0}", result);
                ZegoUtil.ZegoPrivateLog(0, log, false, 0);
            }
            return result;
        }
        public override bool IsSpeakerMuted()
        {
            bool result = false;
            if (enginePtr != null)
            {
                result = IExpressDeviceInternal.zego_express_is_speaker_muted();
                string log = string.Format("IsSpeakerMuted  result:{0}", result);
                ZegoUtil.ZegoPrivateLog(0, log, false, 0);
            }
            return result;
        }
        public override void EnableAudioCaptureDevice(bool enable)
        {
            if (enginePtr != null)
            {
                int result = IExpressDeviceInternal.zego_express_enable_audio_capture_device(enable);
                string log = string.Format("EnableAudioCaptureDevice  result:{0} enable:{1}", result, enable);
                ZegoUtil.ZegoPrivateLog(result, log, true, ZegoConstans.ZEGO_EXPRESS_MODULE_DEVICE);
            }
        }


        public override void EnableHeadphoneMonitor(bool enable)
        {
            if (enginePtr != null)
            {
                int result = IExpressDeviceInternal.zego_express_enable_headphone_monitor(enable);
                string log = string.Format("EnableHeadphoneMonitor  result:{0} enable:{1}", result, enable);
                ZegoUtil.ZegoPrivateLog(result, log, true, ZegoConstans.ZEGO_EXPRESS_MODULE_DEVICE);
            }
        }

        public override void SetHeadphoneMonitorVolume(int volume)
        {
            if (enginePtr != null)
            {
                int result = IExpressDeviceInternal.zego_express_set_headphone_monitor_volume(volume);
                string log = string.Format("SetHeadphoneMonitorVolume  result:{0} volume:{1}", result, volume);
                ZegoUtil.ZegoPrivateLog(result, log, true, ZegoConstans.ZEGO_EXPRESS_MODULE_DEVICE);
            }
        }

        public override ZegoCopyrightedMusic CreateCopyrightedMusic()
        {
            lock (zegoCopyMusicLock)
            {
                if (copyrighted_music_instance == null)
                {
                    IExpressCopyrightedMusicInternal.zego_express_create_copyrighted_music();
                    ZegoUtil.ZegoPrivateLog(0, string.Format("CreateCopyrightedMusic"), false, 0);

                    copyrighted_music_instance = new ZegoCopyrightedMusicImpl();
                }

                return copyrighted_music_instance;
            }
        }

        public override void DestroyCopyrightedMusic(ZegoCopyrightedMusic copyrightedMusic)
        {
            lock (zegoCopyMusicLock)
            {
                IExpressCopyrightedMusicInternal.zego_express_destroy_copyrighted_music();
                ZegoUtil.ZegoPrivateLog(0, string.Format("DestroyCopyrightedMusic"), false, 0);
                copyrighted_music_instance.ClearAllAfterDestroy();
                if (copyrighted_music_instance != null)
                {
                    copyrighted_music_instance = null;
                }
            }
        }

    }
}