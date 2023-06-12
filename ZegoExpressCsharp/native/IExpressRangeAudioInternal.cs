using System;
using System.Runtime.InteropServices;
using static ZEGO.ZegoConstans;

namespace ZEGO {
public class IExpressRangeAudioInternal {
    [DllImport(LIB_NAME, EntryPoint = "zego_express_create_range_audio",
               CallingConvention = ZEGO_CALLINGCONVENTION)]
    public static extern int
    zego_express_create_range_audio(ref zego_range_audio_instance_index index);

    [DllImport(LIB_NAME, EntryPoint = "zego_express_destroy_range_audio",
               CallingConvention = ZEGO_CALLINGCONVENTION)]
    public static extern int
    zego_express_destroy_range_audio(zego_range_audio_instance_index instance_index);

    [DllImport(LIB_NAME, EntryPoint = "zego_express_range_audio_set_audio_receive_range",
               CallingConvention = ZEGO_CALLINGCONVENTION)]
    public static extern int zego_express_range_audio_set_audio_receive_range(
        float range, zego_range_audio_instance_index instance_index);

    [DllImport(LIB_NAME, EntryPoint = "zego_express_range_audio_update_self_position",
               CallingConvention = ZEGO_CALLINGCONVENTION)]
    public static extern int
    zego_express_range_audio_update_self_position(float[] position, float[] axis_forward,
                                                  float[] axis_right, float[] axis_up,
                                                  zego_range_audio_instance_index instance_index);

    [DllImport(LIB_NAME, EntryPoint = "zego_express_range_audio_update_audio_source",
               CallingConvention = ZEGO_CALLINGCONVENTION)]
    public static extern int zego_express_range_audio_update_audio_source(
        [In()][MarshalAs(UnmanagedType.CustomMarshaler,
                         MarshalTypeRef = typeof(ZegoUtil.UTF8StringMarshaler))] string userid,
        float[] position, zego_range_audio_instance_index instance_index);

    [DllImport(LIB_NAME, EntryPoint = "zego_express_range_audio_enable_spatializer",
               CallingConvention = ZEGO_CALLINGCONVENTION)]
    public static extern int
    zego_express_range_audio_enable_spatializer([MarshalAs(UnmanagedType.I1)] bool enable,
                                                zego_range_audio_instance_index instance_index);

    [DllImport(LIB_NAME, EntryPoint = "zego_express_range_audio_enable_microphone",
               CallingConvention = ZEGO_CALLINGCONVENTION)]
    public static extern int
    zego_express_range_audio_enable_microphone([MarshalAs(UnmanagedType.I1)] bool enable,
                                               zego_range_audio_instance_index instance_index);

    [DllImport(LIB_NAME, EntryPoint = "zego_express_range_audio_enable_speaker",
               CallingConvention = ZEGO_CALLINGCONVENTION)]
    public static extern int
    zego_express_range_audio_enable_speaker([MarshalAs(UnmanagedType.I1)] bool enable,
                                            zego_range_audio_instance_index instance_index);

    [DllImport(LIB_NAME, EntryPoint = "zego_express_set_range_audio_mode",
               CallingConvention = ZEGO_CALLINGCONVENTION)]
    public static extern int
    zego_express_set_range_audio_mode(zego_range_audio_mode mode,
                                      zego_range_audio_instance_index instance_index);

    [DllImport(LIB_NAME, EntryPoint = "zego_express_range_audio_set_team_id",
               CallingConvention = ZEGO_CALLINGCONVENTION)]
    public static extern int zego_express_range_audio_set_team_id(
        [In()][MarshalAs(UnmanagedType.CustomMarshaler,
                         MarshalTypeRef = typeof(ZegoUtil.UTF8StringMarshaler))] string team_id,
        zego_range_audio_instance_index instance_index);

    [DllImport(LIB_NAME, EntryPoint = "zego_express_range_audio_mute_user",
               CallingConvention = ZEGO_CALLINGCONVENTION)]
    public static extern int zego_express_range_audio_mute_user(
        [In()][MarshalAs(UnmanagedType.CustomMarshaler,
                         MarshalTypeRef = typeof(ZegoUtil.UTF8StringMarshaler))] string user_id,
        [MarshalAs(UnmanagedType.I1)] bool mute, zego_range_audio_instance_index instance_index);

    [UnmanagedFunctionPointer(ZEGO_CALLINGCONVENTION)]
    public delegate void zego_on_range_audio_microphone_state_update(
        zego_range_audio_microphone_state state, int error_code,
        zego_range_audio_instance_index instance_index, IntPtr user_context);

    [DllImport(LIB_NAME, EntryPoint = "zego_register_range_audio_microphone_state_update_callback",
               CallingConvention = ZEGO_CALLINGCONVENTION)]
    public static extern void zego_register_range_audio_microphone_state_update_callback(
        zego_on_range_audio_microphone_state_update callback_func, IntPtr user_context);

    [DllImport(LIB_NAME, EntryPoint = "zego_express_range_audio_set_audio_volume",
               CallingConvention = ZEGO_CALLINGCONVENTION)]
    public static extern int
    zego_express_range_audio_set_audio_volume(int volume,
                                              zego_range_audio_instance_index instance_index);

#if !UNITY_WEBGL
    [DllImport(LIB_NAME, EntryPoint = "zego_express_set_range_audio_custom_mode",
               CallingConvention = ZEGO_CALLINGCONVENTION)]
    public static extern int
    zego_express_set_range_audio_custom_mode(zego_range_audio_speak_mode speak_mode,
                                             zego_range_audio_listen_mode listen_mode,
                                             zego_range_audio_instance_index instance_index);
#endif
}

}