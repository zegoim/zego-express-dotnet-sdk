using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
//using UnityEngine;
namespace ZEGO {
public class IExpressPlayerInternal {
    [UnmanagedFunctionPointer(ZegoConstans.ZEGO_CALLINGCONVENTION)]
    public delegate void zego_on_player_state_update(
        [In()][MarshalAs(UnmanagedType.LPStr)] string stream_id, ZegoPlayerState state,
        int error_code,
        [In()][MarshalAs(UnmanagedType.CustomMarshaler,
                         MarshalTypeRef = typeof(ZegoUtil.UTF8StringMarshaler))] string
            extended_data,
        System.IntPtr user_context);
    [UnmanagedFunctionPointer(ZegoConstans.ZEGO_CALLINGCONVENTION)]
    public delegate void zego_on_player_quality_update(
        [InAttribute()][MarshalAsAttribute(UnmanagedType.LPStr)] string stream_id,
        zego_play_stream_quality quality, System.IntPtr user_context);
    [UnmanagedFunctionPointer(ZegoConstans.ZEGO_CALLINGCONVENTION)]
    public delegate void zego_on_player_media_event(
        [InAttribute()][MarshalAsAttribute(UnmanagedType.LPStr)] string stream_id,
        ZegoPlayerMediaEvent media_event, System.IntPtr user_context);
    [UnmanagedFunctionPointer(ZegoConstans.ZEGO_CALLINGCONVENTION)]
    public delegate void zego_on_player_recv_audio_first_frame(
        [InAttribute()][MarshalAsAttribute(UnmanagedType.LPStr)] string stream_id,
        System.IntPtr user_context);
    [UnmanagedFunctionPointer(ZegoConstans.ZEGO_CALLINGCONVENTION)]
    public delegate void zego_on_player_recv_video_first_frame(
        [InAttribute()][MarshalAsAttribute(UnmanagedType.LPStr)] string stream_id,
        System.IntPtr user_context);
    [UnmanagedFunctionPointer(ZegoConstans.ZEGO_CALLINGCONVENTION)]
    public delegate void zego_on_player_render_video_first_frame(
        [InAttribute()][MarshalAsAttribute(UnmanagedType.LPStr)] string stream_id,
        System.IntPtr user_context);
    [UnmanagedFunctionPointer(ZegoConstans.ZEGO_CALLINGCONVENTION)]
    public delegate void zego_on_player_video_size_changed(
        [InAttribute()][MarshalAsAttribute(UnmanagedType.LPStr)] string stream_id, int width,
        int height, System.IntPtr user_context);
    [UnmanagedFunctionPointer(ZegoConstans.ZEGO_CALLINGCONVENTION)]
    public delegate void
    zego_on_player_recv_sei([InAttribute()][MarshalAs(UnmanagedType.LPStr)] string stream_id,
                            System.IntPtr data, uint data_length, System.IntPtr user_context);
    [DllImport(ZegoConstans.LIB_NAME, EntryPoint = "zego_express_start_playing_stream",
               CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
    public static extern int
    zego_express_start_playing_stream([In()][MarshalAs(UnmanagedType.LPStr)] string stream_id,
                                      System.IntPtr canvas);
    [DllImport(ZegoConstans.LIB_NAME, EntryPoint = "zego_express_start_playing_stream_with_config",
               CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
    public static extern int zego_express_start_playing_stream_with_config(
        [In()][MarshalAs(UnmanagedType.LPStr)] string stream_id, System.IntPtr canvas,
        zego_player_config config);

    [DllImportAttribute(ZegoConstans.LIB_NAME, EntryPoint = "zego_express_stop_playing_stream",
                        CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
    public static extern int zego_express_stop_playing_stream(
        [InAttribute()][MarshalAsAttribute(UnmanagedType.LPStr)] string stream_id);

    [DllImportAttribute(ZegoConstans.LIB_NAME,
                        EntryPoint = "zego_register_player_state_update_callback",
                        CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
    public static extern void
    zego_register_player_state_update_callback(zego_on_player_state_update callback_func,
                                               System.IntPtr user_context);
    [DllImportAttribute(ZegoConstans.LIB_NAME, EntryPoint = "zego_express_set_play_volume",
                        CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
    public static extern int zego_express_set_play_volume(
        [InAttribute()][MarshalAsAttribute(UnmanagedType.LPStr)] string stream_id, int volume);
    [DllImportAttribute(ZegoConstans.LIB_NAME, EntryPoint = "zego_express_mute_play_stream_audio",
                        CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
    public static extern int zego_express_mute_play_stream_audio(
        [InAttribute()][MarshalAsAttribute(UnmanagedType.LPStr)] string stream_id,
        [MarshalAs(UnmanagedType.I1)] bool mute);
    [DllImportAttribute(ZegoConstans.LIB_NAME, EntryPoint = "zego_express_mute_play_stream_video",
                        CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
    public static extern int zego_express_mute_play_stream_video(
        [InAttribute()][MarshalAsAttribute(UnmanagedType.LPStr)] string stream_id,
        [MarshalAs(UnmanagedType.I1)] bool mute);
    [DllImportAttribute(ZegoConstans.LIB_NAME, EntryPoint = "zego_express_enable_hardware_decoder",
                        CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
    public static extern int
    zego_express_enable_hardware_decoder([MarshalAs(UnmanagedType.I1)] bool enable);
    [DllImportAttribute(ZegoConstans.LIB_NAME, EntryPoint = "zego_express_enable_check_poc",
                        CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
    public static extern int
    zego_express_enable_check_poc([MarshalAs(UnmanagedType.I1)] bool enable);
    [DllImportAttribute(ZegoConstans.LIB_NAME,
                        EntryPoint = "zego_register_player_quality_update_callback",
                        CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
    public static extern void
    zego_register_player_quality_update_callback(zego_on_player_quality_update callback_func,
                                                 System.IntPtr user_context);
    [DllImportAttribute(ZegoConstans.LIB_NAME,
                        EntryPoint = "zego_register_player_media_event_callback",
                        CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
    public static extern void
    zego_register_player_media_event_callback(zego_on_player_media_event callback_func,
                                              System.IntPtr user_context);
    [DllImportAttribute(ZegoConstans.LIB_NAME,
                        EntryPoint = "zego_register_player_recv_audio_first_frame_callback",
                        CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
    public static extern void zego_register_player_recv_audio_first_frame_callback(
        zego_on_player_recv_audio_first_frame callback_func, System.IntPtr user_context);
    [DllImportAttribute(ZegoConstans.LIB_NAME,
                        EntryPoint = "zego_register_player_recv_video_first_frame_callback",
                        CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
    public static extern void zego_register_player_recv_video_first_frame_callback(
        zego_on_player_recv_video_first_frame callback_func, System.IntPtr user_context);
    [DllImportAttribute(ZegoConstans.LIB_NAME,
                        EntryPoint = "zego_register_player_render_video_first_frame_callback",
                        CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
    public static extern void zego_register_player_render_video_first_frame_callback(
        zego_on_player_render_video_first_frame callback_func, System.IntPtr user_context);
    [DllImportAttribute(ZegoConstans.LIB_NAME,
                        EntryPoint = "zego_register_player_video_size_changed_callback",
                        CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
    public static extern void zego_register_player_video_size_changed_callback(
        zego_on_player_video_size_changed callback_func, System.IntPtr user_context);
    /// Return Type: void
    ///callback_func: zego_on_player_recv_sei
    ///user_context: void*
    [DllImportAttribute(ZegoConstans.LIB_NAME,
                        EntryPoint = "zego_register_player_recv_sei_callback",
                        CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
    public static extern void
    zego_register_player_recv_sei_callback(zego_on_player_recv_sei callback_func,
                                           System.IntPtr user_context);

    [DllImport(ZegoConstans.LIB_NAME, EntryPoint = "zego_express_take_play_stream_snapshot",
               CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
    public static extern int
    zego_express_take_play_stream_snapshot([In()][MarshalAs(UnmanagedType.LPStr)] string stream_id);

    [UnmanagedFunctionPointer(ZegoConstans.ZEGO_CALLINGCONVENTION)]
    public delegate void
    zego_on_player_take_snapshot_result(int error_code,
                                        [In()][MarshalAs(UnmanagedType.LPStr)] string stream_id,
                                        System.IntPtr image, System.IntPtr user_context);

    [DllImport(ZegoConstans.LIB_NAME,
               EntryPoint = "zego_register_player_take_snapshot_result_callback",
               CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
    public static extern void zego_register_player_take_snapshot_result_callback(
        zego_on_player_take_snapshot_result callback_func, System.IntPtr user_context);

    [DllImport(ZegoConstans.LIB_NAME, EntryPoint = "zego_express_set_all_play_stream_volume",
               CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
    public static extern int zego_express_set_all_play_stream_volume(int volume);

    [DllImport(ZegoConstans.LIB_NAME,
               EntryPoint = "zego_express_set_play_stream_buffer_interval_range",
               CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
    public static extern int zego_express_set_play_stream_buffer_interval_range(
        [In()][MarshalAs(UnmanagedType.LPStr)] string stream_id, uint min_buffer_interval,
        uint max_buffer_interval);

    [DllImport(ZegoConstans.LIB_NAME, EntryPoint = "zego_express_set_play_stream_focus_on",
               CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
    public static extern int
    zego_express_set_play_stream_focus_on([In()][MarshalAs(UnmanagedType.LPStr)] string stream_id);

    [DllImport(ZegoConstans.LIB_NAME, EntryPoint = "zego_express_mute_all_play_stream_audio",
               CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
    public static extern int
    zego_express_mute_all_play_stream_audio([MarshalAs(UnmanagedType.I1)] bool mute);

    [DllImport(ZegoConstans.LIB_NAME, EntryPoint = "zego_express_mute_all_play_stream_video",
               CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
    public static extern int
    zego_express_mute_all_play_stream_video([MarshalAs(UnmanagedType.I1)] bool mute);

    [DllImport(ZegoConstans.LIB_NAME, EntryPoint = "zego_express_set_play_stream_video_type",
               CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
    public static extern int
    zego_express_set_play_stream_video_type([In()][MarshalAs(UnmanagedType.LPStr)] string stream_id,
                                            ZegoVideoStreamType video_type);

    [UnmanagedFunctionPointer(ZegoConstans.ZEGO_CALLINGCONVENTION)]
    public delegate void zego_on_player_render_camera_video_first_frame(
        [In()][MarshalAs(UnmanagedType.LPStr)] string stream_id, System.IntPtr user_context);

    [DllImport(ZegoConstans.LIB_NAME,
               EntryPoint = "zego_register_player_render_camera_video_first_frame_callback",
               CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
    public static extern void zego_register_player_render_camera_video_first_frame_callback(
        zego_on_player_render_camera_video_first_frame callback_func, System.IntPtr user_context);
}
}
