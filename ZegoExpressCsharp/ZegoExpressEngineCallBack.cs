using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Runtime.InteropServices;
using static ZEGO.ZegoExpressEngineImpl;
using static ZEGO.ZegoCallBackChangeUtil;

namespace ZEGO
{
    class ZegoExpressEngineCallBack
    {
        public static void zego_on_mixer_start_result(int error_code, int seq, [System.Runtime.InteropServices.InAttribute()][System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string extended_data, System.IntPtr user_context)
        {
            if (enginePtr == null || onMixerStartResultDics == null) return;

            string log = string.Format("zego_on_mixer_start_result error_code:{0}  seq:{1} extended_data:{2}", error_code, seq, extended_data);
            ZegoUtil.ZegoPrivateLog(error_code, log, true, ZegoConstans.ZEGO_EXPRESS_MODULE_MIXER);
            OnMixerStartResult onMixerStartResult = GetCallbackFromSeq<OnMixerStartResult>(onMixerStartResultDics, seq);
            if (onMixerStartResult == null)
            {
                return;
            }


            context?.Post(new SendOrPostCallback((o) =>
            {
                onMixerStartResult?.Invoke(error_code, extended_data);
                onMixerStartResultDics?.TryRemove(seq, out _);
            }), null);

        }

        public static void zego_on_mixer_stop_result(int error_code, int seq, System.IntPtr user_context)
        {
            if (enginePtr == null || onMixerStopResultDics == null) return;
            string log = string.Format("zego_on_mixer_stop_result error_code:{0}  seq:{1}", error_code, seq);

            ZegoUtil.ZegoPrivateLog(error_code, log, true, ZegoConstans.ZEGO_EXPRESS_MODULE_MIXER);

            OnMixerStopResult onMixerStopResult = GetCallbackFromSeq<OnMixerStopResult>(onMixerStopResultDics, seq);
            if (onMixerStopResult == null)
            {
                return;
            }

            context?.Post(new SendOrPostCallback((o) =>
            {
                onMixerStopResult?.Invoke(error_code);
                onMixerStopResultDics?.TryRemove(seq, out _);
            }), null);

        }

        public static void zego_on_mixer_relay_cdn_state_update([In()][MarshalAs(UnmanagedType.LPStr)] string task_id, System.IntPtr info_list, uint info_count, System.IntPtr user_context)
        {
            if (enginePtr == null || enginePtr.onMixerRelayCDNStateUpdate == null) return;
            string log = string.Format("zego_on_mixer_relay_cdn_state_update task_id:{0}  info_count:{1}", task_id, info_count);
            ZegoUtil.ZegoPrivateLog(0, log, false, 0);
            zego_stream_relay_cdn_info[] zego_Stream_Relay_Cdn_Infos = new zego_stream_relay_cdn_info[info_count];
            ZegoUtil.GetStructListByPtr(ref zego_Stream_Relay_Cdn_Infos, info_list, info_count);
            List<ZegoStreamRelayCDNInfo> result = ChangeZegoStreamRelayCDNInfoStructListToClassList(zego_Stream_Relay_Cdn_Infos);
            context?.Post(new SendOrPostCallback((o) =>
            {

                enginePtr?.onMixerRelayCDNStateUpdate?.Invoke(task_id, result);

            }), null);
        }

        public static void zego_on_mixer_sound_level_update(IntPtr sound_levels, uint info_count, System.IntPtr user_context)
        {
            if (enginePtr == null || enginePtr.onMixerSoundLevelUpdate == null) return;
            string log = string.Format("zego_on_mixer_sound_level_update  info_count:{0}", info_count);
            ZegoUtil.ZegoPrivateLog(0, log, false, 0);
            zego_mixer_sound_level_info[] zego_Mixer_Sound_Level_Infos = new zego_mixer_sound_level_info[info_count];
            ZegoUtil.GetStructListByPtr(ref zego_Mixer_Sound_Level_Infos, sound_levels, info_count);
            Dictionary<uint, float> result = ChangeZegoMixerSoundLevelInfoStructListToDictionary(zego_Mixer_Sound_Level_Infos);
            context?.Post(new SendOrPostCallback((o) =>
            {

                enginePtr?.onMixerSoundLevelUpdate?.Invoke(result);

            }), null);
        }
        public static void zego_on_mediaplayer_audio_data(IntPtr data, uint data_length, zego_audio_frame_param param, ZegoMediaPlayerInstanceIndex instance_index, System.IntPtr user_context)
        {
            ZegoMediaPlayer zegoMediaPlayer = GetObjectFromIndex(mediaPlayerAndIndex, (int)instance_index);
            if (zegoMediaPlayer.onAudioFrame != null)
            {

                ZegoAudioFrameParam zegoAudioFrameParam = ChangeZegoAudioFrameStructToClass(param);
                zegoMediaPlayer.onAudioFrame(zegoMediaPlayer, data, data_length, zegoAudioFrameParam);
            }
            else
            {
                return;
            }
        }

        public static void zego_on_media_player_video_frame([In][MarshalAs(UnmanagedType.LPArray, SizeConst = 4)] IntPtr[] data,
            [In][MarshalAs(UnmanagedType.LPArray, SizeConst = 4)] uint[] data_length,
            zego_video_frame_param param,
            [In()][MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(ZegoUtil.UTF8StringMarshaler))] string extra_info,
            zego_media_player_instance_index instance_index,
            System.IntPtr user_context)
        {
            ZegoMediaPlayer zegoMediaPlayer = GetObjectFromIndex(mediaPlayerAndIndex, (int)instance_index);
            if (zegoMediaPlayer.onVideoFrame != null)
            {
                ZegoVideoFrameParam zegoVideoFrameParam = ChangeZegoVideoFrameParamStructToClass(param);
                zegoMediaPlayer.onVideoFrame(zegoMediaPlayer, data, data_length, zegoVideoFrameParam);

            }
            else
            {
                return;
            }
        }

        public static void zego_on_mediaplayer_load_resource_result(int error_code, ZegoMediaPlayerInstanceIndex instance_index, System.IntPtr user_context)
        {
            ZegoMediaPlayer zegoMediaPlayer = GetObjectFromIndex(mediaPlayerAndIndex, (int)instance_index);
            if (zegoMediaPlayer.onLoadResourceCallback != null)
            {

                string log = string.Format("zego_on_mediaplayer_load_resource_result mediaplayerID:{0} error_code:{1}", instance_index, error_code);
                ZegoUtil.ZegoPrivateLog(error_code, log, true, ZegoConstans.ZEGO_EXPRESS_MODULE_MEDIAPLAYER);
                context?.Post(new SendOrPostCallback((o) =>
                {

                    zegoMediaPlayer?.onLoadResourceCallback?.Invoke(error_code);

                }), null);

            }
            else
            {
                return;
            }

        }

        public static void zego_on_engine_uninit(System.IntPtr userContext)
        {


            Console.WriteLine("destroy engine success");
            if (onDestroyCompletion != null)
            {

                context?.Post(new SendOrPostCallback((o) =>
                {
                    onDestroyCompletion();
                }), null);


                Console.WriteLine("destroy engine callback success");
            }
            release();

        }

        public static void zego_on_room_state_update(string roomId, ZegoRoomState state, int errorCode, string extendedData, System.IntPtr userContext)
        {
            if (enginePtr == null || enginePtr.onRoomStateUpdate == null) return;

            string log = string.Format("onRoomStateUpdate roomId:{0}  state:{1}  errorCode:{2} extendedData{3}", roomId, state, errorCode, extendedData);
            context?.Post(new SendOrPostCallback((o) =>
            {

                enginePtr?.onRoomStateUpdate?.Invoke(roomId, state, errorCode, extendedData);

            }), null);
            ZegoUtil.ZegoPrivateLog(0, log, false, 0);


        }

        public static void zego_on_debug_error(int error_code, [In()][MarshalAs(UnmanagedType.LPStr)] string func_name, [In()][MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(ZegoUtil.UTF8StringMarshaler))] string info, System.IntPtr user_context)
        {
            if (enginePtr == null || enginePtr.onDebugError == null) return;
            context?.Post(new SendOrPostCallback((o) =>
            {

                enginePtr?.onDebugError.Invoke(error_code, func_name, info);

            }), null);
        }

        public static void zego_on_room_stream_extra_info_update([InAttribute()][MarshalAsAttribute(UnmanagedType.LPStr)] string room_id, System.IntPtr stream_info_list, uint stream_info_count, System.IntPtr user_context)
        {
            if (enginePtr == null || enginePtr.onRoomStreamExtraInfoUpdate == null) return;
            zego_stream[] zego_streams = new zego_stream[stream_info_count];
            ZegoUtil.GetStructListByPtr<zego_stream>(ref zego_streams, stream_info_list, stream_info_count);//get StructLists by pointer
            List<ZegoStream> result = ChangeZegoStreamStructListToClassList(zego_streams);
            string log = string.Format("onRoomStreamExtraInfoUpdate room_id:{0}  stream_info_count:{1}", room_id, stream_info_count);
            context?.Post(new SendOrPostCallback((o) =>
            {

                enginePtr?.onRoomStreamExtraInfoUpdate?.Invoke(room_id, result);

            }), null);

            ZegoUtil.ZegoPrivateLog(0, log, false, 0);

        }

        public static void zego_on_publisher_state_update(string streamId, ZegoPublisherState state, int errorCode, string extendedData, System.IntPtr user_Context)
        {
            if (enginePtr == null || enginePtr.onPublisherStateUpdate == null) return;

            string log = string.Format("onPublisherStateUpdate streamId:{0}  state:{1}  errorCode:{2} extendedData{3}", streamId, state, errorCode, extendedData);

            ZegoUtil.ZegoPrivateLog(0, log, false, 0);

            context?.Post(new SendOrPostCallback((o) =>
            {

                enginePtr?.onPublisherStateUpdate?.Invoke(streamId, state, errorCode, extendedData);

            }), null);

        }

        public static void zego_on_publisher_update_cdn_url_result([System.Runtime.InteropServices.InAttribute()][System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string stream_id, int error_code, int seq, System.IntPtr user_context)
        {
            if (enginePtr == null || onPublisherUpdateCdnUrlResultDics == null) return;
            string log = string.Format("onPublisherUpdateCdnUrlResult streamId:{0}  errorCode:{1} seq{2}", stream_id, error_code, seq);
            ZegoUtil.ZegoPrivateLog(error_code, log, true, ZegoConstans.ZEGO_EXPRESS_MODULE_PUBLISHER);
            OnPublisherUpdateCdnUrlResult onPublisherUpdateCdnUrlResult = GetCallbackFromSeq<OnPublisherUpdateCdnUrlResult>(onPublisherUpdateCdnUrlResultDics, seq);
            if (onPublisherUpdateCdnUrlResult == null)
            {
                return;
            }

            context?.Post(new SendOrPostCallback((o) =>
            {
                onPublisherUpdateCdnUrlResult?.Invoke(error_code);
                onPublisherUpdateCdnUrlResultDics?.TryRemove(seq, out _);
            }), null);


        }

        public static void zego_on_publisher_relay_cdn_state_update([System.Runtime.InteropServices.InAttribute()][System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string stream_id, System.IntPtr cdn_info_list, uint info_count, System.IntPtr user_context)
        {
            if (enginePtr == null || enginePtr.onPublisherRelayCDNStateUpdate == null) return;
            zego_stream_relay_cdn_info[] infos = new zego_stream_relay_cdn_info[info_count];
            ZegoUtil.GetStructListByPtr<zego_stream_relay_cdn_info>(ref infos, cdn_info_list, info_count);//get StructLists by pointer
            List<ZegoStreamRelayCDNInfo> infoList = ChangeZegoStreamRelayCDNInfoStructListToClassList(infos);

            string log = string.Format("onPublisherRelayCDNStateUpdate streamId:{0}  info_count:{1}", stream_id, info_count);
            ZegoUtil.ZegoPrivateLog(0, log, false, 0);

            context?.Post(new SendOrPostCallback((o) =>
            {

                enginePtr?.onPublisherRelayCDNStateUpdate?.Invoke(stream_id, infoList);

            }), null);
        }

        public static void zego_on_player_state_update(string streamId, ZegoPlayerState state, int errorCode, string extendedData, System.IntPtr userContext)
        {
            if (enginePtr == null || enginePtr.onPlayerStateUpdate == null) return;

            string log = string.Format("onPlayerStateUpdate streamId:{0}  state:{1} errorCode:{2} extendedData:{3}", streamId, state, errorCode, extendedData);

            context?.Post(new SendOrPostCallback((o) =>
            {

                enginePtr?.onPlayerStateUpdate?.Invoke(streamId, state, errorCode, extendedData);

            }), null);

            ZegoUtil.ZegoPrivateLog(0, log, false, 0);


        }

        public static void zego_on_publisher_quality_update([InAttribute()][MarshalAsAttribute(UnmanagedType.LPStr)] string streamId, zego_publish_stream_quality quality, System.IntPtr userContext)
        {
            if (enginePtr == null || enginePtr.onPublisherQualityUpdate == null) return;
            ZegoPublishStreamQuality result = ChangePublishQualityToClass(quality);

            string log = string.Format("onPublisherQualityUpdate streamId:{0} quality:{1}", streamId, quality);

            context?.Post(new SendOrPostCallback((o) =>
            {

                enginePtr?.onPublisherQualityUpdate?.Invoke(streamId, result);

            }), null);

            ZegoUtil.ZegoPrivateLog(0, log, false, 0);
        }

        public static void zego_on_publisher_captured_audio_first_frame(System.IntPtr userContext)
        {
            if (enginePtr == null || enginePtr.onPublisherCapturedAudioFirstFrame == null) return;


            context?.Post(new SendOrPostCallback((o) =>
            {

                enginePtr?.onPublisherCapturedAudioFirstFrame?.Invoke();

            }), null);




        }

        public static void zego_on_publisher_captured_video_first_frame(ZegoPublishChannel channel, System.IntPtr userContext)
        {
            if (enginePtr == null || enginePtr.onPublisherCapturedVideoFirstFrame == null) return;

            context?.Post(new SendOrPostCallback((o) =>
            {

                enginePtr?.onPublisherCapturedVideoFirstFrame?.Invoke(channel);

            }), null);




        }

        public static void zego_on_publisher_video_size_changed(int width, int height, ZegoPublishChannel channel, System.IntPtr userContext)
        {
            if (enginePtr == null || enginePtr.onPublisherVideoSizeChanged == null) return;

            string log = string.Format("onPublisherVideoSizeChanged width:{0} height:{1} channel{2}", width, height, channel);

            context?.Post(new SendOrPostCallback((o) =>
            {

                enginePtr?.onPublisherVideoSizeChanged?.Invoke(width, height, channel);

            }), null);


            ZegoUtil.ZegoPrivateLog(0, log, false, 0);

        }

        public static void zego_on_room_user_update([InAttribute()][MarshalAsAttribute(UnmanagedType.LPStr)] string roomId, ZegoUpdateType updateType, IntPtr userList, uint userCount, System.IntPtr userContext)
        {
            if (enginePtr == null || enginePtr.onRoomUserUpdate == null) return;
            zego_user[] users = new zego_user[userCount];
            ZegoUtil.GetStructListByPtr<zego_user>(ref users, userList, userCount);//get StructLists by pointer
            List<ZegoUser> result = ChangeZegoUserStructListToClassList(users);

            string log = string.Format("onRoomUserUpdate roomId:{0} updateType:{1} userCount{2}", roomId, updateType, userCount);

            context?.Post(new SendOrPostCallback((o) =>
            {

                enginePtr?.onRoomUserUpdate?.Invoke(roomId, updateType, result, userCount);

            }), null);

            ZegoUtil.ZegoPrivateLog(0, log, false, 0);

        }

        public static void zego_on_room_stream_update([InAttribute()][MarshalAsAttribute(UnmanagedType.LPStr)] string roomId, ZegoUpdateType updateType, System.IntPtr streamInfoList, uint streamInfoCount, [InAttribute()][MarshalAsAttribute(UnmanagedType.LPStr)] string extend_data, System.IntPtr userContext)
        {
            if (enginePtr == null || enginePtr.onRoomStreamUpdate == null) return;
            zego_stream[] zego_streams = new zego_stream[streamInfoCount];
            ZegoUtil.GetStructListByPtr<zego_stream>(ref zego_streams, streamInfoList, streamInfoCount);//get StructLists by pointer
            List<ZegoStream> result = ChangeZegoStreamStructListToClassList(zego_streams);
            string log = string.Format("onRoomStreamUpdate roomId:{0} updateType:{1} userCount{2} extend_data{3}", roomId, updateType, streamInfoCount, extend_data);
            context?.Post(new SendOrPostCallback((o) =>
            {

                enginePtr?.onRoomStreamUpdate?.Invoke(roomId, updateType, result, extend_data);

            }), null);
            ZegoUtil.ZegoPrivateLog(0, log, false, 0);
        }

        public static void zego_on_player_quality_update([InAttribute()][MarshalAsAttribute(UnmanagedType.LPStr)] string streamId, zego_play_stream_quality quality, System.IntPtr userContext)
        {
            if (enginePtr == null || enginePtr.onPlayerQualityUpdate == null) return;
            ZegoPlayStreamQuality result = ChangePlayerQualityStructToClass(quality);

            context?.Post(new SendOrPostCallback((o) =>
            {

                enginePtr?.onPlayerQualityUpdate?.Invoke(streamId, result);

            }), null);
        }

        public static void zego_on_player_media_event([InAttribute()][MarshalAsAttribute(UnmanagedType.LPStr)] string streamId, ZegoPlayerMediaEvent mediaEvent, System.IntPtr userContext)
        {

            if (enginePtr == null || enginePtr.onPlayerMediaEvent == null) return;


            context?.Post(new SendOrPostCallback((o) =>
            {

                enginePtr?.onPlayerMediaEvent?.Invoke(streamId, mediaEvent);

            }), null);
        }

        public static void zego_on_player_recv_audio_first_frame([InAttribute()][MarshalAsAttribute(UnmanagedType.LPStr)] string streamId, System.IntPtr userContext)
        {

            if (enginePtr == null || enginePtr.onPlayerRecvAudioFirstFrame == null) return;

            context?.Post(new SendOrPostCallback((o) =>
            {

                enginePtr?.onPlayerRecvAudioFirstFrame?.Invoke(streamId);

            }), null);
        }

        public static void zego_on_player_recv_video_first_frame([InAttribute()][MarshalAsAttribute(UnmanagedType.LPStr)] string streamId, System.IntPtr userContext)
        {

            if (enginePtr == null || enginePtr.onPlayerRecvVideoFirstFrame == null) return;

            context?.Post(new SendOrPostCallback((o) =>
            {

                enginePtr?.onPlayerRecvVideoFirstFrame?.Invoke(streamId);

            }), null);
        }

        public static void zego_on_player_render_video_first_frame([InAttribute()][MarshalAsAttribute(UnmanagedType.LPStr)] string streamId, System.IntPtr userContext)
        {

            if (enginePtr == null || enginePtr.onPlayerRenderVideoFirstFrame == null) return;


            context?.Post(new SendOrPostCallback((o) =>
            {

                enginePtr?.onPlayerRenderVideoFirstFrame?.Invoke(streamId);

            }), null);
        }

        public static void zego_on_player_video_size_changed([InAttribute()][MarshalAsAttribute(UnmanagedType.LPStr)] string streamId, int width, int height, System.IntPtr userContext)
        {

            if (enginePtr == null || enginePtr.onPlayerVideoSizeChanged == null) return;

            string log = string.Format("onPlayerVideoSizeChanged streamId:{0} width:{1} height:{2}", streamId, width, height);

            context?.Post(new SendOrPostCallback((o) =>
            {

                enginePtr?.onPlayerVideoSizeChanged?.Invoke(streamId, width, height);

            }), null);

            ZegoUtil.ZegoPrivateLog(0, log, false, 0);
        }

        public static void zego_on_im_recv_barrage_message([System.Runtime.InteropServices.InAttribute()][System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string room_id, System.IntPtr message_info_list, uint message_count, System.IntPtr user_context)
        {

            if (enginePtr == null || enginePtr.onIMRecvBarrageMessage == null) return;
            zego_barrage_message_info[] zego_messages = new zego_barrage_message_info[message_count];
            ZegoUtil.GetStructListByPtr<zego_barrage_message_info>(ref zego_messages, message_info_list, message_count);//get StructLists by pointer
            List<ZegoBarrageMessageInfo> result = ChangeBarrageMessageStructListToClassList(zego_messages);

            string log = string.Format("onIMRecvBarrageMessage room_id:{0} message_count:{1} ", room_id, message_count);

            context?.Post(new SendOrPostCallback((o) =>
            {

                enginePtr?.onIMRecvBarrageMessage?.Invoke(room_id, result);

            }), null);

            ZegoUtil.ZegoPrivateLog(0, log, false, 0);

        }

        public static void zego_on_custom_video_capture_start(ZegoPublishChannel channel, System.IntPtr user_context)
        {
            if (enginePtr == null || enginePtr.onCustomVideoCaptureStart == null) return;
            string log = string.Format("onCustomVideoCaptureStart channel:{0}  ", channel);

            context?.Post(new SendOrPostCallback((o) =>
            {

                enginePtr?.onCustomVideoCaptureStart?.Invoke(channel);

            }), null);
            ZegoUtil.ZegoPrivateLog(0, log, false, 0);
        }

        public static void zego_on_custom_video_capture_stop(ZegoPublishChannel channel, System.IntPtr user_context)
        {
            if (enginePtr == null || enginePtr.onCustomVideoCaptureStop == null) return;
            string log = string.Format("onCustomVideoCaptureStop channel:{0}  ", channel);

            context?.Post(new SendOrPostCallback((o) =>
            {

                enginePtr?.onCustomVideoCaptureStop?.Invoke(channel);

            }), null);
            ZegoUtil.ZegoPrivateLog(0, log, false, 0);

        }

        public static void zego_on_room_set_room_extra_info_result(int error_code, [In()][MarshalAs(UnmanagedType.LPStr)] string room_id, [In()][MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(ZegoUtil.UTF8StringMarshaler))] string key, int seq, System.IntPtr user_context)
        {
            if (enginePtr == null || onRoomSetRoomExtraInfoResultDics == null) return;

            string log = string.Format("onRoomSetRoomExtraInfoResultDics, errorCode:{0} seq{1}", error_code, seq);
            ZegoUtil.ZegoPrivateLog(error_code, log, true, ZegoConstans.ZEGO_EXPRESS_MODULE_ROOM);

            var onRoomSetRoomExtraInfoResult = GetCallbackFromSeq<OnRoomSetRoomExtraInfoResult>(onRoomSetRoomExtraInfoResultDics, seq);
            if (onRoomSetRoomExtraInfoResult == null)
            {
                return;
            }

            context?.Post(new SendOrPostCallback((o) =>
            {
                onRoomSetRoomExtraInfoResult?.Invoke(error_code);
                onRoomSetRoomExtraInfoResultDics?.TryRemove(seq, out _);
            }), null);
        }

        public static void zego_on_room_extra_info_update([In()][MarshalAs(UnmanagedType.LPStr)] string room_id, IntPtr room_extra_info_list, uint room_extra_info_count, System.IntPtr user_context)
        {
            if (enginePtr == null || enginePtr.onRoomExtraInfoUpdate == null) return;
            string log = string.Format("onRoomExtraInfoUpdate roomId:{0} stream_info_count:{1}", room_id, room_extra_info_list);
            zego_room_extra_info[] zego_Room_Extra_Infos = new zego_room_extra_info[room_extra_info_count];
            ZegoUtil.GetStructListByPtr<zego_room_extra_info>(ref zego_Room_Extra_Infos, room_extra_info_list, room_extra_info_count);//get StructLists by pointer
            List<ZegoRoomExtraInfo> result = ChangeZegoRoomExtraInfoStructListToClassList(zego_Room_Extra_Infos);

            context?.Post(new SendOrPostCallback((o) =>
            {
                enginePtr?.onRoomExtraInfoUpdate?.Invoke(room_id, result);

            }), null);
            ZegoUtil.ZegoPrivateLog(0, log, false, 0);
        }

        public static void zego_on_engine_state_update(ZegoEngineState state, System.IntPtr user_context)
        {

            if (enginePtr == null || enginePtr.onEngineStateUpdate == null) return;
            string log = string.Format("zego_on_engine_state_update state:{0}", state);
            ZegoUtil.ZegoPrivateLog(0, log, false, 0);
            context?.Post(new SendOrPostCallback((o) =>
            {

                enginePtr?.onEngineStateUpdate?.Invoke(state);

            }), null);
        }
        public static void zego_on_room_online_user_count_update([In()][MarshalAs(UnmanagedType.LPStr)] string room_id, int count, IntPtr user_context)
        {
            if (enginePtr == null || enginePtr.onRoomOnlineUserCountUpdate == null) return;
            string log = string.Format("onRoomOnlineUserCountUpdate roomId:{0} count:{1}", room_id, count);
            context?.Post(new SendOrPostCallback((o) =>
            {

                enginePtr?.onRoomOnlineUserCountUpdate?.Invoke(room_id, count);

            }), null);
            ZegoUtil.ZegoPrivateLog(0, log, false, 0);
        }


        public static void zego_on_captured_audio_data(IntPtr data, uint data_length, zego_audio_frame_param param, System.IntPtr user_context)
        {
            if (enginePtr == null || enginePtr.onCapturedAudioData == null) return;
            //Console.WriteLine(string.Format("onCapturedAudioData data_length:{0}  ", data_length));
            ZegoAudioFrameParam zegoAudioFrameParam = ChangeZegoAudioFrameStructToClass(param);
            enginePtr.onCapturedAudioData(data, data_length, zegoAudioFrameParam);

        }

        public static void zego_on_mixed_audio_data(IntPtr data, uint data_length, zego_audio_frame_param param, System.IntPtr user_context)
        {
            if (enginePtr == null || enginePtr.onMixedAudioData == null) return;
            //Console.WriteLine(string.Format("onMixedAudioData data_length:{0}  ", data_length));
            ZegoAudioFrameParam zegoAudioFrameParam = ChangeZegoAudioFrameStructToClass(param);
            enginePtr.onMixedAudioData(data, data_length, zegoAudioFrameParam);
        }
        public static void zego_on_playback_audio_data(IntPtr data, uint data_length, zego_audio_frame_param param, System.IntPtr user_context)
        {
            if (enginePtr == null || enginePtr.onPlaybackAudioData == null) return;
            ZegoAudioFrameParam zegoAudioFrameParam = ChangeZegoAudioFrameStructToClass(param);
            enginePtr.onPlaybackAudioData(data, data_length, zegoAudioFrameParam);
        }

        public static void zego_on_player_audio_data(IntPtr data, uint data_length, zego_audio_frame_param param, [In()][MarshalAs(UnmanagedType.LPStr)] string stream_id, IntPtr user_context)
        {
            if (enginePtr == null || enginePtr.onPlayerAudioData == null) return;
            ZegoAudioFrameParam zegoAudioFrameParam = ChangeZegoAudioFrameStructToClass(param);
            enginePtr.onPlayerAudioData(data, data_length, zegoAudioFrameParam, stream_id);
        }

        public static void zego_on_im_recv_broadcast_message([System.Runtime.InteropServices.InAttribute()][System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string room_id, System.IntPtr message_info_list, uint message_count, System.IntPtr user_context)
        {

            if (enginePtr == null || enginePtr.onIMRecvBroadcastMessage == null) return;
            zego_broadcast_message_info[] zego_messages = new zego_broadcast_message_info[message_count];
            ZegoUtil.GetStructListByPtr<zego_broadcast_message_info>(ref zego_messages, message_info_list, message_count);//get StructLists by pointer
            List<ZegoBroadcastMessageInfo> result = ChangeBroadMessageStructListToClassList(zego_messages);

            string log = string.Format("onIMRecvBroadcastMessage room_id:{0} message_count:{1} ", room_id, message_count);

            context?.Post(new SendOrPostCallback((o) =>
            {

                enginePtr?.onIMRecvBroadcastMessage?.Invoke(room_id, result);

            }), null);

            ZegoUtil.ZegoPrivateLog(0, log, false, 0);

        }

        public static void zego_on_im_recv_custom_command([System.Runtime.InteropServices.InAttribute()][System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string room_id, zego_user from_user, [System.Runtime.InteropServices.InAttribute()][System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(ZegoUtil.UTF8StringMarshaler))] string content, System.IntPtr user_context)
        {

            if (enginePtr == null || enginePtr.onIMRecvCustomCommand == null) return;
            ZegoUser result = ChangeZegoUserStructToClass(from_user);

            string log = string.Format("onIMRecvCustomCommand room_id:{0} content:{1}", room_id, content);

            context?.Post(new SendOrPostCallback((o) =>
            {

                enginePtr?.onIMRecvCustomCommand?.Invoke(room_id, result, content);

            }), null);

            ZegoUtil.ZegoPrivateLog(0, log, false, 0);

        }

        public static void zego_on_im_send_barrage_message_result([System.Runtime.InteropServices.InAttribute()][System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string room_id, [System.Runtime.InteropServices.InAttribute()][System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string message_id, int error_code, int seq, System.IntPtr user_context)
        {

            if (enginePtr == null || onIMSendBarrageMessageResultDics == null) return;
            string log = string.Format("onIMSendBarrageMessageResult room_id:{0} message_id:{1} error_code:{2} seq:{3}", room_id, message_id, error_code, seq);
            ZegoUtil.ZegoPrivateLog(error_code, log, true, ZegoConstans.ZEGO_EXPRESS_MODULE_IM);
            OnIMSendBarrageMessageResult onIMSendBarrageMessageResult = GetCallbackFromSeq<OnIMSendBarrageMessageResult>(onIMSendBarrageMessageResultDics, seq);
            if (onIMSendBarrageMessageResult == null)
            {
                return;
            }


            context?.Post(new SendOrPostCallback((o) =>
            {
                onIMSendBarrageMessageResult?.Invoke(error_code, message_id);
                onIMSendBarrageMessageResultDics.TryRemove(seq, out _);
            }), null);

        }

        public static void zego_on_mediaplayer_state_update(ZegoMediaPlayerState state, int error_code, ZegoMediaPlayerInstanceIndex instance_index, System.IntPtr user_context)
        {

            ZegoMediaPlayer zegoMediaPlayer = GetObjectFromIndex(mediaPlayerAndIndex, (int)instance_index);
            if (zegoMediaPlayer.onMediaPlayerStateUpdate != null)
            {

                string log = string.Format("zego_on_mediaplayer_state_update mediaplayerID:{0} state:{1}", instance_index, state);
                context?.Post(new SendOrPostCallback((o) =>
                {

                    zegoMediaPlayer?.onMediaPlayerStateUpdate?.Invoke(zegoMediaPlayer, state, error_code);

                }), null);
                ZegoUtil.ZegoPrivateLog(0, log, false, 0);
            }
            else
            {
                return;
            }


        }
        public static void zego_on_mediaplayer_network_event(ZegoMediaPlayerNetworkEvent net_event, ZegoMediaPlayerInstanceIndex instance_index, System.IntPtr user_context)

        {

            ZegoMediaPlayer zegoMediaPlayer = GetObjectFromIndex(mediaPlayerAndIndex, (int)instance_index);

            if (zegoMediaPlayer.onMediaPlayerNetworkEvent != null)
            {

                string log = string.Format("zego_on_mediaplayer_network_event mediaplayerID:{0}", instance_index);
                context?.Post(new SendOrPostCallback((o) =>
                {

                    zegoMediaPlayer?.onMediaPlayerNetworkEvent?.Invoke(zegoMediaPlayer, net_event);

                }), null);
                ZegoUtil.ZegoPrivateLog(0, log, false, 0);

            }
            else
            {
                return;
            }


        }
        public static void zego_on_mediaplayer_playing_progress(ulong millisecond, ZegoMediaPlayerInstanceIndex instance_index, System.IntPtr user_context)
        {

            ZegoMediaPlayer zegoMediaPlayer = GetObjectFromIndex(mediaPlayerAndIndex, (int)instance_index);
            if (zegoMediaPlayer.onMediaPlayerPlayingProgress != null)
            {

                string log = string.Format("zego_on_mediaplayer_playing_progress mediaplayerID:{0}", instance_index);
                context?.Post(new SendOrPostCallback((o) =>
                {

                    zegoMediaPlayer?.onMediaPlayerPlayingProgress?.Invoke(zegoMediaPlayer, millisecond);

                }), null);
                ZegoUtil.ZegoPrivateLog(0, log, false, 0);
            }
            else
            {
                return;
            }



        }

        public static void zego_on_mediaplayer_seek_to_time_result(int seq, int error_code, ZegoMediaPlayerInstanceIndex instance_index, System.IntPtr user_context)
        {

            ZegoMediaPlayer zegoMediaPlayer = GetObjectFromIndex(mediaPlayerAndIndex, (int)instance_index);
            if (zegoMediaPlayer.seekToTimeCallbackDic != null)
            {
                string log = string.Format("zego_on_mediaplayer_seek_to_time_result mediaplayerID:{0} seq:{1} error_code:{2}", instance_index, seq, error_code);
                ZegoUtil.ZegoPrivateLog(error_code, log, true, ZegoConstans.ZEGO_EXPRESS_MODULE_MEDIAPLAYER);
                OnSeekToTimeCallback callback = GetCallbackFromSeq<OnSeekToTimeCallback>(zegoMediaPlayer.seekToTimeCallbackDic, seq);
                if (callback == null)
                {
                    return;
                }


                context?.Post(new SendOrPostCallback((o) =>
                {

                    callback?.Invoke(error_code);

                    zegoMediaPlayer?.seekToTimeCallbackDic.TryRemove(seq, out _);


                }), null);

            }
            else
            {
                return;
            }

        }

        public static void zego_on_player_recv_sei([System.Runtime.InteropServices.InAttribute()][System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string stream_id, IntPtr data, uint data_length, System.IntPtr user_context)
        {

            if (enginePtr == null || enginePtr.onPlayerRecvSEI == null) return;
            byte[] result = new byte[data_length];
            ZegoUtil.GetStructListByPtr<byte>(ref result, data, data_length);

            string log = string.Format("onPlayerRecvSEI stream_id:{0}  data_length:{1}", stream_id, data_length);

            context?.Post(new SendOrPostCallback((o) =>
            {

                enginePtr?.onPlayerRecvSEI?.Invoke(stream_id, result);

            }), null);
            ZegoUtil.ZegoPrivateLog(0, log, false, 0);


        }

        public static void zego_on_im_send_broadcast_message_result([System.Runtime.InteropServices.InAttribute()][System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string room_id, ulong message_id, int error_code, int seq, System.IntPtr user_context)
        {

            if (enginePtr == null || onIMSendBroadcastMessageResultDics == null) return;
            string log = string.Format("onIMSendBroadcastMessageResult room_id:{0} message_id:{1} error_code:{2} seq:{3}", room_id, message_id, error_code, seq);
            ZegoUtil.ZegoPrivateLog(error_code, log, true, ZegoConstans.ZEGO_EXPRESS_MODULE_IM);
            OnIMSendBroadcastMessageResult onIMSendBroadcastMessageResult = GetCallbackFromSeq<OnIMSendBroadcastMessageResult>(onIMSendBroadcastMessageResultDics, seq);
            if (onIMSendBroadcastMessageResult == null)
            {
                return;
            }

            context?.Post(new SendOrPostCallback((o) =>
            {
                onIMSendBroadcastMessageResult?.Invoke(error_code, message_id);
                onIMSendBroadcastMessageResultDics?.TryRemove(seq, out _);
            }), null);


        }

        public static void zego_on_publisher_update_stream_extra_info_result(int error_code, int seq, System.IntPtr user_context)
        {

            if (enginePtr == null || onPublisherSetStreamExtraInfoResultDics == null) return;
            string log = string.Format("onPublisherSetStreamExtraInfoResult error_code:{0}  seq:{1}", error_code, seq);
            ZegoUtil.ZegoPrivateLog(error_code, log, true, ZegoConstans.ZEGO_EXPRESS_MODULE_PUBLISHER);
            OnPublisherSetStreamExtraInfoResult onPublisherSetStreamExtraInfoResult = GetCallbackFromSeq<OnPublisherSetStreamExtraInfoResult>(onPublisherSetStreamExtraInfoResultDics, seq);
            if (onPublisherSetStreamExtraInfoResult == null)
            {
                return;
            }

            context?.Post(new SendOrPostCallback((o) =>
            {
                onPublisherSetStreamExtraInfoResult?.Invoke(error_code);
                onPublisherSetStreamExtraInfoResultDics?.TryRemove(seq, out _);
            }), null);

        }

        public static void zego_on_im_send_custom_command_result([System.Runtime.InteropServices.InAttribute()][System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string room_id, int error_code, int seq, System.IntPtr user_context)
        {

            if (enginePtr == null || onIMSendCustomCommandResultDics == null) return;

            string log = string.Format("onIMSendCustomCommandResult room_id:{0} message_id:{1} seq:{2}", room_id, error_code, seq);
            ZegoUtil.ZegoPrivateLog(error_code, log, true, ZegoConstans.ZEGO_EXPRESS_MODULE_IM);
            OnIMSendCustomCommandResult onIMSendCustomCommandResult = GetCallbackFromSeq<OnIMSendCustomCommandResult>(onIMSendCustomCommandResultDics, seq);
            if (onIMSendCustomCommandResult == null)
            {
                return;
            }

            context?.Post(new SendOrPostCallback((o) =>
            {
                onIMSendCustomCommandResult?.Invoke(error_code);
                onIMSendCustomCommandResultDics?.TryRemove(seq, out _);
            }), null);

        }

        public static void zego_on_captured_sound_level_update(System.IntPtr sound_level_info, System.IntPtr user_context)
        {
            if (enginePtr == null || enginePtr.onCapturedSoundLevelUpdate == null) return;
            zego_sound_level_info soundLevelInfo = ZegoUtil.GetStructByPtr<zego_sound_level_info>(sound_level_info);

            //直接在c层子线程返回回调，避免切换到ui线程导致界面卡顿

            enginePtr?.onCapturedSoundLevelUpdate?.Invoke(soundLevelInfo.sound_level);

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

            enginePtr?.onRemoteSoundLevelUpdate?.Invoke(results);

            //callBackQueue.PostAsynAction(() =>
            //{
            //    enginePtr.onRemoteSoundLevelUpdate(results);
            //});
        }

        public static void zego_on_captured_audio_spectrum_update(System.IntPtr audio_spectrum_info, System.IntPtr user_context)
        {

            if (enginePtr == null || enginePtr.onCapturedAudioSpectrumUpdate == null) return;
            zego_audio_spectrum_info zegoAudioSpectrumInfo = ZegoUtil.GetStructByPtr<zego_audio_spectrum_info>(audio_spectrum_info);
            float[] result = GetZegoAudioSpectrumInfoStructSpectrumList(zegoAudioSpectrumInfo);
            //直接在c层子线程返回回调，避免切换到ui线程导致界面卡顿

            enginePtr?.onCapturedAudioSpectrumUpdate?.Invoke(result);

            //callBackQueue.PostAsynAction(() =>
            //{

            //    enginePtr.onCapturedAudioSpectrumUpdate(result);
            //});
        }

        public static void zego_on_remote_audio_spectrum_update(System.IntPtr audio_spectrum_info_list, uint info_count, System.IntPtr user_context)
        {

            if (enginePtr == null || enginePtr.onRemoteAudioSpectrumUpdate == null) return;
            zego_audio_spectrum_info[] infos = new zego_audio_spectrum_info[info_count];
            ZegoUtil.GetStructListByPtr<zego_audio_spectrum_info>(ref infos, audio_spectrum_info_list, info_count);
            Dictionary<string, float[]> results = ChangeZegoAudioSpectrumInfoListToDictionary(infos);
            //直接在c层子线程返回回调，避免切换到ui线程导致界面卡顿

            enginePtr?.onRemoteAudioSpectrumUpdate?.Invoke(results);

            //callBackQueue.PostAsynAction(() =>
            //{

            //    enginePtr.onRemoteAudioSpectrumUpdate(results);
            //});
        }

        public static void zego_on_custom_video_render_captured_frame_data(ref IntPtr data, ref uint dataLength, zego_video_frame_param param, ZegoVideoFlipMode flipMode, ZegoPublishChannel channel, System.IntPtr userContext)
        {
            //预览数据回调（写数据） 推流不会触发该回调
            if (enginePtr == null || enginePtr.onCapturedVideoFrameRawData == null) return;
            ZegoVideoFrameParam zegoVideoFrameParam = ChangeZegoVideoFrameParamStructToClass(param);
            enginePtr.onCapturedVideoFrameRawData(ref data, ref dataLength, zegoVideoFrameParam, flipMode, channel);
        }

        public static void zego_on_custom_video_render_remote_frame_data(string streamID, ref IntPtr data, ref uint dataLength, zego_video_frame_param param, System.IntPtr userContext)
        {
            //拉流数据回调（写数据）
            if (enginePtr == null || enginePtr.onRemoteVideoFrameRawData == null) return;
            ZegoVideoFrameParam zegoVideoFrameParam = ChangeZegoVideoFrameParamStructToClass(param);

            enginePtr.onRemoteVideoFrameRawData(ref data, ref dataLength, zegoVideoFrameParam, streamID);
        }

        public static void zego_on_captured_data_record_state_update(ZegoDataRecordState state, int error_code, zego_data_record_config config, ZegoPublishChannel channel, IntPtr user_context)
        {
            if (enginePtr == null || enginePtr.onCapturedDataRecordStateUpdate == null) return;
            ZegoDataRecordConfig zegoDataRecordConfig = ChangeZegoDataRecordConfigStructToClass(config);
            string log = string.Format("onCapturedDataRecordStateUpdate state:{0} error_code:{1} channel:{2}", state, error_code, channel);
            context?.Post(new SendOrPostCallback((o) =>
            {
                enginePtr?.onCapturedDataRecordStateUpdate?.Invoke(state, error_code, zegoDataRecordConfig, channel);

            }), null);
            ZegoUtil.ZegoPrivateLog(0, log, false, 0);
        }

        public static void zego_on_captured_data_record_progress_update(zego_data_record_progress progress, zego_data_record_config config, ZegoPublishChannel channel, IntPtr user_context)
        {
            if (enginePtr == null || enginePtr.onCapturedDataRecordProgressUpdate == null) return;
            ZegoDataRecordProgress zegoDataRecordProgress = ChangeZegoDataRecordProgresstructToClass(progress);
            ZegoDataRecordConfig zegoDataRecordConfig = ChangeZegoDataRecordConfigStructToClass(config);

            context?.Post(new SendOrPostCallback((o) =>
            {
                enginePtr?.onCapturedDataRecordProgressUpdate?.Invoke(zegoDataRecordProgress, zegoDataRecordConfig, channel);

            }), null);

        }

        public static void zego_on_local_device_exception_occurred(ZegoDeviceExceptionType exception_type, ZegoDeviceType device_type, [In()][MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(ZegoUtil.UTF8StringMarshaler))] string device_id, System.IntPtr user_context)
        {
            if (enginePtr == null || enginePtr.onLocalDeviceExceptionOccurred == null) return;

            context?.Post(new SendOrPostCallback((o) =>
            {
                enginePtr?.onLocalDeviceExceptionOccurred?.Invoke(exception_type, device_type, device_id);
            }), null);
        }

        public static void zego_on_remote_camera_state_update([In()][MarshalAs(UnmanagedType.LPStr)] string stream_id, ZegoRemoteDeviceState state, System.IntPtr user_context)
        {

            if (enginePtr == null || enginePtr.onRemoteCameraStateUpdate == null) return;
            string log = string.Format("zego_on_remote_camera_state_update  stream_id:{0} state:{1}", stream_id, state);
            ZegoUtil.ZegoPrivateLog(0, log, false, 0);
            context?.Post(new SendOrPostCallback((o) =>
            {
                enginePtr?.onRemoteCameraStateUpdate?.Invoke(stream_id, state);

            }), null);
        }

        public static void zego_on_remote_mic_state_update([In()][MarshalAs(UnmanagedType.LPStr)] string stream_id, ZegoRemoteDeviceState state, System.IntPtr user_context)
        {

            if (enginePtr == null || enginePtr.onRemoteMicStateUpdate == null) return;
            string log = string.Format("zego_on_remote_mic_state_update  stream_id:{0} state:{1}", stream_id, state);
            ZegoUtil.ZegoPrivateLog(0, log, false, 0);
            context?.Post(new SendOrPostCallback((o) =>
            {
                enginePtr?.onRemoteMicStateUpdate?.Invoke(stream_id, state);

            }), null);
        }
    }
}
