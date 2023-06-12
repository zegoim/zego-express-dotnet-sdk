using System;
using System.Runtime.InteropServices;
using static ZEGO.ZegoConstans;

namespace ZEGO {
internal class IExpressRangeSceneInternal {
    [DllImport(LIB_NAME, EntryPoint = "zego_express_create_range_scene",
               CallingConvention = ZEGO_CALLINGCONVENTION)]
    public static extern int zego_express_create_range_scene(ref int handle);

    [DllImport(LIB_NAME, EntryPoint = "zego_express_destroy_range_scene",
               CallingConvention = ZEGO_CALLINGCONVENTION)]
    public static extern int zego_express_destroy_range_scene(int range_scene_handle);

    [DllImport(LIB_NAME, EntryPoint = "zego_express_range_scene_login_scene",
               CallingConvention = ZEGO_CALLINGCONVENTION)]
    public static extern int zego_express_range_scene_login_scene(int range_scene_handle,
                                                                  ref int seq,
                                                                  zego_scene_param config);

    [DllImport(LIB_NAME, EntryPoint = "zego_express_range_scene_logout_scene",
               CallingConvention = ZEGO_CALLINGCONVENTION)]
    public static extern int zego_express_range_scene_logout_scene(int range_scene_handle,
                                                                   ref int seq);

    [DllImport(LIB_NAME, EntryPoint = "zego_express_range_scene_update_user_status",
               CallingConvention = ZEGO_CALLINGCONVENTION)]
    public static extern int
    zego_express_range_scene_update_user_status(int range_scene_handle, zego_position position,
                                                uint channel, IntPtr status, uint status_length);

    [DllImport(LIB_NAME, EntryPoint = "zego_express_range_scene_update_user_command",
               CallingConvention = ZEGO_CALLINGCONVENTION)]
    public static extern int
    zego_express_range_scene_update_user_command(int range_scene_handle, zego_position position,
                                                 uint channel, IntPtr command, uint command_length);

    [DllImport(LIB_NAME, EntryPoint = "zego_express_range_scene_update_user_position",
               CallingConvention = ZEGO_CALLINGCONVENTION)]
    public static extern int zego_express_range_scene_update_user_position(int range_scene_handle,
                                                                           zego_position position);

    [DllImport(LIB_NAME, EntryPoint = "zego_express_range_scene_get_user_count",
               CallingConvention = ZEGO_CALLINGCONVENTION)]
    public static extern int zego_express_range_scene_get_user_count(int range_scene_handle,
                                                                     ref int seq);

    [DllImport(LIB_NAME, EntryPoint = "zego_express_range_scene_get_user_list_in_view",
               CallingConvention = ZEGO_CALLINGCONVENTION)]
    public static extern int zego_express_range_scene_get_user_list_in_view(int range_scene_handle,
                                                                            ref int seq);

    [DllImport(LIB_NAME, EntryPoint = "zego_express_range_scene_send_custom_command",
               CallingConvention = ZEGO_CALLINGCONVENTION)]
    public static extern int zego_express_range_scene_send_custom_command(int range_scene_handle,
                                                                          ref int seq,
                                                                          IntPtr command,
                                                                          uint command_length);

    [DllImport(LIB_NAME, EntryPoint = "zego_express_range_scene_set_stream_config",
               CallingConvention = ZEGO_CALLINGCONVENTION)]
    public static extern int
    zego_express_range_scene_set_stream_config(int range_scene_handle,
                                               zego_scene_stream_config config);

    [UnmanagedFunctionPointer(ZEGO_CALLINGCONVENTION)]
    public delegate void zego_on_range_scene_scene_state_update(int range_scene_handle,
                                                                zego_scene_state state,
                                                                int error_code,
                                                                IntPtr user_context);

    [DllImport(LIB_NAME, EntryPoint = "zego_register_range_scene_scene_state_update_callback",
               CallingConvention = ZEGO_CALLINGCONVENTION)]
    public static extern void zego_register_range_scene_scene_state_update_callback(
        zego_on_range_scene_scene_state_update callback_func, IntPtr user_context);

    [UnmanagedFunctionPointer(ZEGO_CALLINGCONVENTION)]
    public delegate void zego_on_range_scene_enter_view(int range_scene_handle, zego_user user,
                                                        zego_position position,
                                                        IntPtr user_context);

    [DllImport(LIB_NAME, EntryPoint = "zego_register_range_scene_enter_view_callback",
               CallingConvention = ZEGO_CALLINGCONVENTION)]
    public static extern void
    zego_register_range_scene_enter_view_callback(zego_on_range_scene_enter_view callback_func,
                                                  IntPtr user_context);

    [UnmanagedFunctionPointer(ZEGO_CALLINGCONVENTION)]
    public delegate void zego_on_range_scene_leave_view(
        int range_scene_handle,
        [In()][MarshalAs(UnmanagedType.CustomMarshaler,
                         MarshalTypeRef = typeof(ZegoUtil.UTF8StringMarshaler))] string userid,
        IntPtr user_context);

    [DllImport(LIB_NAME, EntryPoint = "zego_register_range_scene_leave_view_callback",
               CallingConvention = ZEGO_CALLINGCONVENTION)]
    public static extern void
    zego_register_range_scene_leave_view_callback(zego_on_range_scene_leave_view callback_func,
                                                  IntPtr user_context);

    [UnmanagedFunctionPointer(ZEGO_CALLINGCONVENTION)]
    public delegate void zego_on_range_scene_user_status_update(
        int range_scene_handle,
        [In()][MarshalAs(UnmanagedType.CustomMarshaler,
                         MarshalTypeRef = typeof(ZegoUtil.UTF8StringMarshaler))] string userid,
        zego_position position, uint channel, IntPtr status, uint status_length,
        IntPtr user_context);

    [DllImport(LIB_NAME, EntryPoint = "zego_register_range_scene_user_status_update_callback",
               CallingConvention = ZEGO_CALLINGCONVENTION)]
    public static extern void zego_register_range_scene_user_status_update_callback(
        zego_on_range_scene_user_status_update callback_func, IntPtr user_context);

    [UnmanagedFunctionPointer(ZEGO_CALLINGCONVENTION)]
    public delegate void zego_on_range_scene_user_command_update(
        int range_scene_handle,
        [In()][MarshalAs(UnmanagedType.CustomMarshaler,
                         MarshalTypeRef = typeof(ZegoUtil.UTF8StringMarshaler))] string userid,
        zego_position position, uint channel, IntPtr command, uint command_length,
        IntPtr user_context);

    [DllImport(LIB_NAME, EntryPoint = "zego_register_range_scene_user_command_update_callback",
               CallingConvention = ZEGO_CALLINGCONVENTION)]
    public static extern void zego_register_range_scene_user_command_update_callback(
        zego_on_range_scene_user_command_update callback_func, IntPtr user_context);

    [UnmanagedFunctionPointer(ZEGO_CALLINGCONVENTION)]
    public delegate void zego_on_range_scene_custom_command_update(int range_scene_handle,
                                                                   IntPtr command,
                                                                   uint command_length,
                                                                   IntPtr user_context);

    [DllImport(LIB_NAME, EntryPoint = "zego_register_range_scene_custom_command_update_callback",
               CallingConvention = ZEGO_CALLINGCONVENTION)]
    public static extern void zego_register_range_scene_custom_command_update_callback(
        zego_on_range_scene_custom_command_update callback_func, IntPtr user_context);

    [UnmanagedFunctionPointer(ZEGO_CALLINGCONVENTION)]
    public delegate void zego_on_range_scene_login_scene(int range_scene_handle, int seq,
                                                         int error_code, zego_scene_config config,
                                                         IntPtr user_context);

    [DllImport(LIB_NAME, EntryPoint = "zego_register_range_scene_login_scene_callback",
               CallingConvention = ZEGO_CALLINGCONVENTION)]
    public static extern void
    zego_register_range_scene_login_scene_callback(zego_on_range_scene_login_scene callback_func,
                                                   IntPtr user_context);

    [UnmanagedFunctionPointer(ZEGO_CALLINGCONVENTION)]
    public delegate void zego_on_range_scene_logout_scene(int range_scene_handle, int seq,
                                                          int error_code, IntPtr user_context);

    [DllImport(LIB_NAME, EntryPoint = "zego_register_range_scene_logout_scene_callback",
               CallingConvention = ZEGO_CALLINGCONVENTION)]
    public static extern void
    zego_register_range_scene_logout_scene_callback(zego_on_range_scene_logout_scene callback_func,
                                                    IntPtr user_context);

    [UnmanagedFunctionPointer(ZEGO_CALLINGCONVENTION)]
    public delegate void zego_on_range_scene_get_user_count(int range_scene_handle, int seq,
                                                            int error_code, uint count,
                                                            IntPtr user_context);

    [DllImport(LIB_NAME, EntryPoint = "zego_register_range_scene_get_user_count_callback",
               CallingConvention = ZEGO_CALLINGCONVENTION)]
    public static extern void zego_register_range_scene_get_user_count_callback(
        zego_on_range_scene_get_user_count callback_func, IntPtr user_context);

    [UnmanagedFunctionPointer(ZEGO_CALLINGCONVENTION)]
    public delegate void zego_on_range_scene_get_user_list_in_view(int range_scene_handle, int seq,
                                                                   int error_code, IntPtr user_list,
                                                                   uint user_list_size,
                                                                   IntPtr user_context);

    [DllImport(LIB_NAME, EntryPoint = "zego_register_range_scene_get_user_list_in_view_callback",
               CallingConvention = ZEGO_CALLINGCONVENTION)]
    public static extern void zego_register_range_scene_get_user_list_in_view_callback(
        zego_on_range_scene_get_user_list_in_view callback_func, IntPtr user_context);

    [UnmanagedFunctionPointer(ZEGO_CALLINGCONVENTION)]
    public delegate void zego_on_range_scene_send_custom_command(int range_scene_handle, int seq,
                                                                 int error_code,
                                                                 IntPtr user_context);

    [DllImport(LIB_NAME, EntryPoint = "zego_register_range_scene_send_custom_command_callback",
               CallingConvention = ZEGO_CALLINGCONVENTION)]
    public static extern void zego_register_range_scene_send_custom_command_callback(
        zego_on_range_scene_send_custom_command callback_func, IntPtr user_context);

    [UnmanagedFunctionPointer(ZEGO_CALLINGCONVENTION)]
    public delegate void zego_on_range_scene_token_will_expire(int range_scene_handle,
                                                               int remain_time_in_second,
                                                               IntPtr user_context);

    [DllImport(LIB_NAME, EntryPoint = "zego_register_range_scene_token_will_expire_callback",
               CallingConvention = ZEGO_CALLINGCONVENTION)]
    public static extern void zego_register_range_scene_token_will_expire_callback(
        zego_on_range_scene_token_will_expire callback_func, IntPtr user_context);

    [DllImport(LIB_NAME, EntryPoint = "zego_express_range_scene_renew_token",
               CallingConvention = ZEGO_CALLINGCONVENTION)]

    public static extern int zego_express_range_scene_renew_token(
        int range_scene_handle,
        [In()][MarshalAs(UnmanagedType.CustomMarshaler,
                         MarshalTypeRef = typeof(ZegoUtil.UTF8StringMarshaler))] string token);
} //class IExpressRangeScene
} //namespace ZEGO
