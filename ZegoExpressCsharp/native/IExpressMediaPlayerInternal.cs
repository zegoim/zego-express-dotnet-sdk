using System;
using System.Runtime.InteropServices;
namespace ZEGO {
public class IExpressMediaPlayerInternal {
    [DllImport(ZegoConstans.LIB_NAME, EntryPoint = "zego_express_create_media_player",
               CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
    public static extern ZegoMediaPlayerInstanceIndex zego_express_create_media_player();

    [DllImport(ZegoConstans.LIB_NAME, EntryPoint = "zego_express_destroy_media_player",
               CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
    public static extern int
    zego_express_destroy_media_player(ZegoMediaPlayerInstanceIndex instance_index);

    [DllImport(ZegoConstans.LIB_NAME, EntryPoint = "zego_express_media_player_start",
               CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
    public static extern int
    zego_express_media_player_start(ZegoMediaPlayerInstanceIndex instance_index);

    [DllImport(ZegoConstans.LIB_NAME, EntryPoint = "zego_express_media_player_stop",
               CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
    public static extern int
    zego_express_media_player_stop(ZegoMediaPlayerInstanceIndex instance_index);

    [DllImport(ZegoConstans.LIB_NAME, EntryPoint = "zego_express_media_player_pause",
               CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
    public static extern int
    zego_express_media_player_pause(ZegoMediaPlayerInstanceIndex instance_index);

    [DllImport(ZegoConstans.LIB_NAME, EntryPoint = "zego_express_media_player_resume",
               CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
    public static extern int
    zego_express_media_player_resume(ZegoMediaPlayerInstanceIndex instance_index);

    [DllImport(ZegoConstans.LIB_NAME, EntryPoint = "zego_express_media_player_load_resource",
               CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
    public static extern int zego_express_media_player_load_resource(
        [In()][MarshalAs(UnmanagedType.CustomMarshaler,
                         MarshalTypeRef = typeof(ZegoUtil.UTF8StringMarshaler))] string path,
        ZegoMediaPlayerInstanceIndex instance_index);

    [DllImport(ZegoConstans.LIB_NAME,
               EntryPoint = "zego_express_media_player_load_resource_from_media_data",
               CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
    public static extern int zego_express_media_player_load_resource_from_media_data(
        IntPtr media_data, int media_data_length, IntPtr start_position,
        ZegoMediaPlayerInstanceIndex instance_index);

    [DllImport(ZegoConstans.LIB_NAME,
               EntryPoint = "zego_express_media_player_load_resource_with_position",
               CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
    public static extern int zego_express_media_player_load_resource_with_position(
        [In()][MarshalAs(UnmanagedType.CustomMarshaler,
                         MarshalTypeRef = typeof(ZegoUtil.UTF8StringMarshaler))] string path,
        IntPtr start_position, ZegoMediaPlayerInstanceIndex instance_index);

    [DllImport(ZegoConstans.LIB_NAME,
               EntryPoint =
                   "zego_express_media_player_load_copyrighted_music_resource_with_position",
               CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
    public static extern int
    zego_express_media_player_load_copyrighted_music_resource_with_position(
        [In()][MarshalAs(UnmanagedType.CustomMarshaler,
                         MarshalTypeRef = typeof(ZegoUtil.UTF8StringMarshaler))] string resource_id,
        IntPtr start_position, ZegoMediaPlayerInstanceIndex instance_index);

    [DllImport(ZegoConstans.LIB_NAME, EntryPoint = "zego_express_media_player_get_current_state",
               CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
    public static extern ZegoMediaPlayerState
    zego_express_media_player_get_current_state(ZegoMediaPlayerInstanceIndex instance_index);

    [DllImport(ZegoConstans.LIB_NAME, EntryPoint = "zego_express_media_player_seek_to",
               CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
    public static extern int
    zego_express_media_player_seek_to(ulong millisecond,
                                      ZegoMediaPlayerInstanceIndex instance_index);

    [DllImport(ZegoConstans.LIB_NAME, EntryPoint = "zego_express_media_player_set_volume",
               CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
    public static extern int
    zego_express_media_player_set_volume(int volume, ZegoMediaPlayerInstanceIndex instance_index);

    [DllImport(ZegoConstans.LIB_NAME, EntryPoint = "zego_express_media_player_set_play_volume",
               CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
    public static extern int
    zego_express_media_player_set_play_volume(int volume,
                                              ZegoMediaPlayerInstanceIndex instance_index);

    [DllImport(ZegoConstans.LIB_NAME, EntryPoint = "zego_express_media_player_set_publish_volume",
               CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
    public static extern int
    zego_express_media_player_set_publish_volume(int volume,
                                                 ZegoMediaPlayerInstanceIndex instance_index);

    [DllImport(ZegoConstans.LIB_NAME, EntryPoint = "zego_express_media_player_get_play_volume",
               CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
    public static extern int
    zego_express_media_player_get_play_volume(ZegoMediaPlayerInstanceIndex instance_index);

    [DllImport(ZegoConstans.LIB_NAME, EntryPoint = "zego_express_media_player_get_publish_volume",
               CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
    public static extern int
    zego_express_media_player_get_publish_volume(ZegoMediaPlayerInstanceIndex instance_index);

    [DllImport(ZegoConstans.LIB_NAME, EntryPoint = "zego_express_media_player_get_total_duration",
               CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
    public static extern ulong
    zego_express_media_player_get_total_duration(ZegoMediaPlayerInstanceIndex instance_index);

    [DllImport(ZegoConstans.LIB_NAME, EntryPoint = "zego_express_media_player_get_current_progress",
               CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
    public static extern ulong
    zego_express_media_player_get_current_progress(ZegoMediaPlayerInstanceIndex instance_index);

    [DllImport(ZegoConstans.LIB_NAME, EntryPoint = "zego_express_media_player_mute_local_audio",
               CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
    public static extern int
    zego_express_media_player_mute_local_audio([MarshalAs(UnmanagedType.I1)] bool mute,
                                               ZegoMediaPlayerInstanceIndex instance_index);

    [DllImport(ZegoConstans.LIB_NAME, EntryPoint = "zego_express_media_player_enable_aux",
               CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
    public static extern int
    zego_express_media_player_enable_aux([MarshalAs(UnmanagedType.I1)] bool enable,
                                         ZegoMediaPlayerInstanceIndex instance_index);

    [DllImport(ZegoConstans.LIB_NAME, EntryPoint = "zego_express_media_player_enable_repeat",
               CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
    public static extern int
    zego_express_media_player_enable_repeat([MarshalAs(UnmanagedType.I1)] bool enable,
                                            ZegoMediaPlayerInstanceIndex instance_index);

    [DllImport(ZegoConstans.LIB_NAME, EntryPoint = "zego_express_media_player_set_play_loop_count",
               CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
    public static extern int
    zego_express_media_player_set_play_loop_count(int count,
                                                  ZegoMediaPlayerInstanceIndex instance_index);

    [DllImport(ZegoConstans.LIB_NAME, EntryPoint = "zego_express_media_player_set_play_speed",
               CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
    public static extern int
    zego_express_media_player_set_play_speed(float speed,
                                             ZegoMediaPlayerInstanceIndex instance_index);

    [DllImport(ZegoConstans.LIB_NAME,
               EntryPoint = "zego_express_media_player_set_progress_interval",
               CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
    public static extern int
    zego_express_media_player_set_progress_interval(ulong millisecond,
                                                    ZegoMediaPlayerInstanceIndex instance_index);

    [DllImport(ZegoConstans.LIB_NAME,
               EntryPoint = "zego_express_media_player_get_audio_track_count",
               CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
    public static extern uint
    zego_express_media_player_get_audio_track_count(ZegoMediaPlayerInstanceIndex instance_index);

    [DllImport(ZegoConstans.LIB_NAME,
               EntryPoint = "zego_express_media_player_set_audio_track_index",
               CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
    public static extern int
    zego_express_media_player_set_audio_track_index(uint index,
                                                    ZegoMediaPlayerInstanceIndex instance_index);

    [DllImport(ZegoConstans.LIB_NAME,
               EntryPoint = "zego_express_media_player_set_voice_changer_param",
               CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
    public static extern int
    zego_express_media_player_set_voice_changer_param(ZegoMediaPlayerAudioChannel audio_channel,
                                                      float param,
                                                      ZegoMediaPlayerInstanceIndex instance_index);

    [DllImport(ZegoConstans.LIB_NAME, EntryPoint = "zego_express_media_player_enable_audio_data",
               CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
    public static extern int
    zego_express_media_player_enable_audio_data([MarshalAs(UnmanagedType.I1)] bool enable,
                                                ZegoMediaPlayerInstanceIndex instance_index);

    [DllImport(ZegoConstans.LIB_NAME, EntryPoint = "zego_express_media_player_enable_video_data",
               CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
    public static extern int
    zego_express_media_player_enable_video_data([MarshalAs(UnmanagedType.I1)] bool enable,
                                                ZegoVideoFrameFormat format,
                                                ZegoMediaPlayerInstanceIndex instance_index);

    [DllImport(ZegoConstans.LIB_NAME, EntryPoint = "zego_express_media_player_enable_accurate_seek",
               CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
    public static extern int
    zego_express_media_player_enable_accurate_seek([MarshalAs(UnmanagedType.I1)] bool enable,
                                                   IntPtr config,
                                                   ZegoMediaPlayerInstanceIndex instance_index);

    [DllImport(ZegoConstans.LIB_NAME,
               EntryPoint = "zego_express_media_player_set_network_resource_max_cache",
               CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
    public static extern int zego_express_media_player_set_network_resource_max_cache(
        uint time, uint size, ZegoMediaPlayerInstanceIndex instance_index);

    [DllImport(ZegoConstans.LIB_NAME,
               EntryPoint = "zego_express_media_player_get_network_resource_cache",
               CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
    public static extern int zego_express_media_player_get_network_resource_cache(
        IntPtr cache, ZegoMediaPlayerInstanceIndex instance_index);

    [DllImport(ZegoConstans.LIB_NAME,
               EntryPoint = "zego_express_media_player_set_network_buffer_threshold",
               CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
    public static extern int zego_express_media_player_set_network_buffer_threshold(
        uint threshold, ZegoMediaPlayerInstanceIndex instance_index);

    [DllImport(ZegoConstans.LIB_NAME,
               EntryPoint = "zego_express_media_player_enable_sound_level_monitor",
               CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
    public static extern int zego_express_media_player_enable_sound_level_monitor(
        [MarshalAs(UnmanagedType.I1)] bool enable, uint millisecond,
        ZegoMediaPlayerInstanceIndex instance_index);

    [DllImport(ZegoConstans.LIB_NAME,
               EntryPoint = "zego_express_media_player_enable_frequency_spectrum_monitor",
               CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
    public static extern int zego_express_media_player_enable_frequency_spectrum_monitor(
        [MarshalAs(UnmanagedType.I1)] bool enable, uint millisecond,
        ZegoMediaPlayerInstanceIndex instance_index);

    [UnmanagedFunctionPointer(ZegoConstans.ZEGO_CALLINGCONVENTION)]
    public delegate void
    zego_on_media_player_state_update(ZegoMediaPlayerState state, int error_code,
                                      ZegoMediaPlayerInstanceIndex instance_index,
                                      IntPtr user_context);

    [DllImport(ZegoConstans.LIB_NAME,
               EntryPoint = "zego_register_media_player_state_update_callback",
               CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
    public static extern void zego_register_media_player_state_update_callback(
        zego_on_media_player_state_update callback_func, IntPtr user_context);

    [UnmanagedFunctionPointer(ZegoConstans.ZEGO_CALLINGCONVENTION)]
    public delegate void
    zego_on_media_player_network_event(ZegoMediaPlayerNetworkEvent network_event,
                                       ZegoMediaPlayerInstanceIndex instance_index,
                                       IntPtr user_context);

    [DllImport(ZegoConstans.LIB_NAME,
               EntryPoint = "zego_register_media_player_network_event_callback",
               CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
    public static extern void zego_register_media_player_network_event_callback(
        zego_on_media_player_network_event callback_func, IntPtr user_context);

    [UnmanagedFunctionPointer(ZegoConstans.ZEGO_CALLINGCONVENTION)]
    public delegate void zego_on_media_player_playing_progress(
        ulong millisecond, ZegoMediaPlayerInstanceIndex instance_index, IntPtr user_context);

    [DllImport(ZegoConstans.LIB_NAME,
               EntryPoint = "zego_register_media_player_playing_progress_callback",
               CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
    public static extern void zego_register_media_player_playing_progress_callback(
        zego_on_media_player_playing_progress callback_func, IntPtr user_context);

    [UnmanagedFunctionPointer(ZegoConstans.ZEGO_CALLINGCONVENTION)]
    public delegate void zego_on_media_player_recv_sei(IntPtr data, uint data_length,
                                                       ZegoMediaPlayerInstanceIndex instance_index,
                                                       IntPtr user_context);

    [DllImport(ZegoConstans.LIB_NAME, EntryPoint = "zego_register_media_player_recv_sei_callback",
               CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
    public static extern void
    zego_register_media_player_recv_sei_callback(zego_on_media_player_recv_sei callback_func,
                                                 IntPtr user_context);

    [UnmanagedFunctionPointer(ZegoConstans.ZEGO_CALLINGCONVENTION)]
    public delegate void zego_on_media_player_sound_level_update(
        float sound_level, ZegoMediaPlayerInstanceIndex instance_index, IntPtr user_context);

    [DllImport(ZegoConstans.LIB_NAME,
               EntryPoint = "zego_register_media_player_sound_level_update_callback",
               CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
    public static extern void zego_register_media_player_sound_level_update_callback(
        zego_on_media_player_sound_level_update callback_func, IntPtr user_context);

    [UnmanagedFunctionPointer(ZegoConstans.ZEGO_CALLINGCONVENTION)]
    public delegate void
    zego_on_media_player_frequency_spectrum_update(IntPtr spectrum_list, uint spectrum_count,
                                                   ZegoMediaPlayerInstanceIndex instance_index,
                                                   IntPtr user_context);

    [DllImport(ZegoConstans.LIB_NAME,
               EntryPoint = "zego_register_media_player_frequency_spectrum_update_callback",
               CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
    public static extern void zego_register_media_player_frequency_spectrum_update_callback(
        zego_on_media_player_frequency_spectrum_update callback_func, IntPtr user_context);

    [UnmanagedFunctionPointer(ZegoConstans.ZEGO_CALLINGCONVENTION)]
    public delegate void zego_on_media_player_video_frame(
        [In][MarshalAs(UnmanagedType.LPArray, SizeConst = 4)] IntPtr[] data,
        [In][MarshalAs(UnmanagedType.LPArray, SizeConst = 4)] uint[] data_length,
        zego_video_frame_param param,
        [In()][MarshalAs(UnmanagedType.CustomMarshaler,
                         MarshalTypeRef = typeof(ZegoUtil.UTF8StringMarshaler))] string extra_info,
        zego_media_player_instance_index instance_index, System.IntPtr user_context);

    [DllImport(ZegoConstans.LIB_NAME,
               EntryPoint = "zego_register_media_player_video_frame_callback",
               CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
    public static extern void
    zego_register_media_player_video_frame_callback(zego_on_media_player_video_frame callback_func,
                                                    IntPtr user_context);

    [UnmanagedFunctionPointer(ZegoConstans.ZEGO_CALLINGCONVENTION)]
    public delegate void
    zego_on_media_player_audio_frame(IntPtr data, uint data_length, zego_audio_frame_param param,
                                     ZegoMediaPlayerInstanceIndex instance_index,
                                     IntPtr user_context);

    [DllImport(ZegoConstans.LIB_NAME,
               EntryPoint = "zego_register_media_player_audio_frame_callback",
               CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
    public static extern void
    zego_register_media_player_audio_frame_callback(zego_on_media_player_audio_frame callback_func,
                                                    IntPtr user_context);

    [UnmanagedFunctionPointer(ZegoConstans.ZEGO_CALLINGCONVENTION)]
    public delegate void
    zego_on_media_player_load_resource(int error_code, ZegoMediaPlayerInstanceIndex instance_index,
                                       IntPtr user_context);

    [DllImport(ZegoConstans.LIB_NAME,
               EntryPoint = "zego_register_media_player_load_resource_callback",
               CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
    public static extern void zego_register_media_player_load_resource_callback(
        zego_on_media_player_load_resource callback_func, IntPtr user_context);

    [UnmanagedFunctionPointer(ZegoConstans.ZEGO_CALLINGCONVENTION)]
    public delegate void zego_on_media_player_seek_to(int seq, int error_code,
                                                      ZegoMediaPlayerInstanceIndex instance_index,
                                                      IntPtr user_context);

    [DllImport(ZegoConstans.LIB_NAME, EntryPoint = "zego_register_media_player_seek_to_callback",
               CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
    public static extern void
    zego_register_media_player_seek_to_callback(zego_on_media_player_seek_to callback_func,
                                                IntPtr user_context);

    [UnmanagedFunctionPointer(ZegoConstans.ZEGO_CALLINGCONVENTION)]
    public delegate void
    zego_on_media_player_take_snapshot_result(int error_code, IntPtr image,
                                              ZegoMediaPlayerInstanceIndex instance_index,
                                              IntPtr user_context);

    [DllImport(ZegoConstans.LIB_NAME,
               EntryPoint = "zego_register_media_player_take_snapshot_result_callback",
               CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
    public static extern void zego_register_media_player_take_snapshot_result_callback(
        zego_on_media_player_take_snapshot_result callback_func, IntPtr user_context);

    [DllImport(ZegoConstans.LIB_NAME, EntryPoint = "zego_express_media_player_set_player_canvas",
               CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
    public static extern int
    zego_express_media_player_set_player_canvas(IntPtr canvas,
                                                ZegoMediaPlayerInstanceIndex instance_index);
}
}