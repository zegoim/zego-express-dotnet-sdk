using System;
using System.Runtime.InteropServices;
using static ZEGO.ZegoConstans;

namespace ZEGO {
internal class IExpressRangeSceneStreamInternal {
    [DllImport(LIB_NAME, EntryPoint = "zego_express_range_scene_stream_set_receive_range",
               CallingConvention = ZEGO_CALLINGCONVENTION)]
    public static extern int
    zego_express_range_scene_stream_set_receive_range(int range_scene_handle, float range);

    [DllImport(LIB_NAME, EntryPoint = "zego_express_range_scene_stream_enable_range_spatializer",
               CallingConvention = ZEGO_CALLINGCONVENTION)]
    public static extern int
    zego_express_range_scene_stream_enable_range_spatializer(int range_scene_handle, bool enable);

    [DllImport(LIB_NAME, EntryPoint = "zego_express_range_scene_stream_mute_play_audio",
               CallingConvention = ZEGO_CALLINGCONVENTION)]
    public static extern int zego_express_range_scene_stream_mute_play_audio(
        int range_scene_handle,
        [In()][MarshalAs(UnmanagedType.CustomMarshaler,
                         MarshalTypeRef = typeof(ZegoUtil.UTF8StringMarshaler))] string userid,
        bool mute);

    [DllImport(LIB_NAME, EntryPoint = "zego_express_range_scene_stream_mute_play_video",
               CallingConvention = ZEGO_CALLINGCONVENTION)]
    public static extern int zego_express_range_scene_stream_mute_play_video(
        int range_scene_handle,
        [In()][MarshalAs(UnmanagedType.CustomMarshaler,
                         MarshalTypeRef = typeof(ZegoUtil.UTF8StringMarshaler))] string userid,
        bool mute);

    [UnmanagedFunctionPointer(ZEGO_CALLINGCONVENTION)]
    public delegate void zego_on_range_scene_stream_user_stream_state_update(
        int range_scene_handle,
        [In()][MarshalAs(UnmanagedType.CustomMarshaler,
                         MarshalTypeRef = typeof(ZegoUtil.UTF8StringMarshaler))] string userid,
        [In()][MarshalAs(UnmanagedType.CustomMarshaler,
                         MarshalTypeRef = typeof(ZegoUtil.UTF8StringMarshaler))] string stream_id,
        zego_stream_state state, IntPtr user_context);

    [DllImport(LIB_NAME,
               EntryPoint = "zego_register_range_scene_stream_user_stream_state_update_callback",
               CallingConvention = ZEGO_CALLINGCONVENTION)]
    public static extern void zego_register_range_scene_stream_user_stream_state_update_callback(
        zego_on_range_scene_stream_user_stream_state_update callback_func, IntPtr user_context);

    [UnmanagedFunctionPointer(ZEGO_CALLINGCONVENTION)]
    public delegate void zego_on_range_scene_stream_user_mic_update(
        int range_scene_handle,
        [In()][MarshalAs(UnmanagedType.CustomMarshaler,
                         MarshalTypeRef = typeof(ZegoUtil.UTF8StringMarshaler))] string userid,
        zego_device_state state, IntPtr user_context);

    [DllImport(LIB_NAME, EntryPoint = "zego_register_range_scene_stream_user_mic_update_callback",
               CallingConvention = ZEGO_CALLINGCONVENTION)]
    public static extern void zego_register_range_scene_stream_user_mic_update_callback(
        zego_on_range_scene_stream_user_mic_update callback_func, IntPtr user_context);

    [UnmanagedFunctionPointer(ZEGO_CALLINGCONVENTION)]
    public delegate void zego_on_range_scene_stream_user_camera_update(
        int range_scene_handle,
        [In()][MarshalAs(UnmanagedType.CustomMarshaler,
                         MarshalTypeRef = typeof(ZegoUtil.UTF8StringMarshaler))] string userid,
        zego_device_state state, IntPtr user_context);

    [DllImport(LIB_NAME,
               EntryPoint = "zego_register_range_scene_stream_user_camera_update_callback",
               CallingConvention = ZEGO_CALLINGCONVENTION)]
    public static extern void zego_register_range_scene_stream_user_camera_update_callback(
        zego_on_range_scene_stream_user_camera_update callback_func, IntPtr user_context);

    [UnmanagedFunctionPointer(ZEGO_CALLINGCONVENTION)]
    public delegate void zego_on_range_scene_stream_user_speaker_update(
        int range_scene_handle,
        [In()][MarshalAs(UnmanagedType.CustomMarshaler,
                         MarshalTypeRef = typeof(ZegoUtil.UTF8StringMarshaler))] string userid,
        zego_device_state state, IntPtr user_context);

    [DllImport(LIB_NAME,
               EntryPoint = "zego_register_range_scene_stream_user_speaker_update_callback",
               CallingConvention = ZEGO_CALLINGCONVENTION)]
    public static extern void zego_register_range_scene_stream_user_speaker_update_callback(
        zego_on_range_scene_stream_user_speaker_update callback_func, IntPtr user_context);
}
}
