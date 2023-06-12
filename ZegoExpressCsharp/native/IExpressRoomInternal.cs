using System;
using System.Runtime.InteropServices;
using static ZEGO.ZegoConstans;
//using UnityEngine;
namespace ZEGO {
public class IExpressRoomInternal {
    [UnmanagedFunctionPointer(ZEGO_CALLINGCONVENTION)]
    public delegate void zego_on_room_state_update(
        [In()][MarshalAs(UnmanagedType.LPStr)] string room_id, ZegoRoomState state, int error_code,
        [In()][MarshalAs(UnmanagedType.CustomMarshaler,
                         MarshalTypeRef = typeof(ZegoUtil.UTF8StringMarshaler))] string
            extended_data,
        IntPtr user_context);

    [UnmanagedFunctionPointer(ZEGO_CALLINGCONVENTION)]
    public delegate void zego_on_room_user_update(
        [InAttribute()][MarshalAsAttribute(UnmanagedType.LPStr)] string room_id,
        ZegoUpdateType update_type, System.IntPtr user_list, uint user_count,
        System.IntPtr user_context);

    [UnmanagedFunctionPointer(ZEGO_CALLINGCONVENTION)]
    public delegate void zego_on_room_stream_update(
        [In()][MarshalAs(UnmanagedType.LPStr)] string room_id, ZegoUpdateType update_type,
        IntPtr stream_info_list, uint stream_info_count,
        [In()][MarshalAs(UnmanagedType.CustomMarshaler,
                         MarshalTypeRef = typeof(ZegoUtil.UTF8StringMarshaler))] string extend_data,
        IntPtr user_context);

    [UnmanagedFunctionPointer(ZEGO_CALLINGCONVENTION)]
    public delegate void zego_on_room_stream_extra_info_update(
        [InAttribute()][MarshalAs(UnmanagedType.LPStr)] string room_id, IntPtr stream_info_list,
        uint stream_info_count, IntPtr user_context);

    [DllImportAttribute(ZegoConstans.LIB_NAME, EntryPoint = "zego_express_login_room",
                        CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
#if UNITY_WEBGL
    public static extern int zego_express_login_room(string room_id, string user, string config);
#else
    public static extern int
    zego_express_login_room([In()][MarshalAs(UnmanagedType.LPStr)] string room_id, zego_user user,
                            System.IntPtr config);
#endif

    [DllImportAttribute(ZegoConstans.LIB_NAME, EntryPoint = "zego_express_login_room_with_callback",
                        CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
#if UNITY_WEBGL
    public static extern int zego_express_login_room_with_callback(string room_id, string user,
                                                                   string config, int sequence);
#else
    public static extern int
    zego_express_login_room_with_callback([In()][MarshalAs(UnmanagedType.LPStr)] string room_id,
                                          zego_user user, System.IntPtr config, ref int sequence);
#endif

    [DllImportAttribute(ZegoConstans.LIB_NAME, EntryPoint = "zego_express_logout_room",
                        CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
    public static extern int zego_express_logout_room(
        [InAttribute()][MarshalAsAttribute(UnmanagedType.LPStr)] string room_id);

    [DllImportAttribute(ZegoConstans.LIB_NAME, EntryPoint = "zego_express_logout_all_room",
                        CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
    public static extern int zego_express_logout_all_room();

    [DllImport(LIB_NAME, EntryPoint = "zego_express_switch_room",
               CallingConvention = ZEGO_CALLINGCONVENTION)]
    public static extern int
    zego_express_switch_room([In()][MarshalAs(UnmanagedType.LPStr)] string from_room_id,
                             [In()][MarshalAs(UnmanagedType.LPStr)] string to_room_id,
                             IntPtr config);

    [DllImportAttribute(ZegoConstans.LIB_NAME,
                        EntryPoint = "zego_register_room_state_update_callback",
                        CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
    public static extern void
    zego_register_room_state_update_callback(zego_on_room_state_update callback_func,
                                             System.IntPtr user_context);

    [DllImportAttribute(ZegoConstans.LIB_NAME,
                        EntryPoint = "zego_register_room_user_update_callback",
                        CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
    public static extern void
    zego_register_room_user_update_callback(zego_on_room_user_update callback_func,
                                            System.IntPtr user_context);

    [DllImportAttribute(ZegoConstans.LIB_NAME,
                        EntryPoint = "zego_register_room_stream_update_callback",
                        CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
    public static extern void
    zego_register_room_stream_update_callback(zego_on_room_stream_update callback_func,
                                              System.IntPtr user_context);

    [DllImportAttribute(ZegoConstans.LIB_NAME,
                        EntryPoint = "zego_register_room_stream_extra_info_update_callback",
                        CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
    public static extern void zego_register_room_stream_extra_info_update_callback(
        zego_on_room_stream_extra_info_update callback_func, System.IntPtr user_context);

    [DllImport(ZegoConstans.LIB_NAME, EntryPoint = "zego_express_set_room_extra_info",
               CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
#if UNITY_WEBGL
    public static extern int zego_express_set_room_extra_info(
        [In()][MarshalAs(UnmanagedType.LPStr)] string room_id,
        [In()][MarshalAs(UnmanagedType.CustomMarshaler,
                         MarshalTypeRef = typeof(ZegoUtil.UTF8StringMarshaler))] string key,
        [In()][MarshalAs(UnmanagedType.CustomMarshaler,
                         MarshalTypeRef = typeof(ZegoUtil.UTF8StringMarshaler))] string value,
        int seq);
#else
    public static extern int zego_express_set_room_extra_info(
        [In()][MarshalAs(UnmanagedType.LPStr)] string room_id,
        [In()][MarshalAs(UnmanagedType.CustomMarshaler,
                         MarshalTypeRef = typeof(ZegoUtil.UTF8StringMarshaler))] string key,
        [In()][MarshalAs(UnmanagedType.CustomMarshaler,
                         MarshalTypeRef = typeof(ZegoUtil.UTF8StringMarshaler))] string value,
        ref int seq);
#endif

    /// Return Type: void
    ///callback_func: zego_on_room_extra_info_update
    ///user_context: void*
    [DllImportAttribute(ZegoConstans.LIB_NAME,
                        EntryPoint = "zego_register_room_extra_info_update_callback",
                        CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
    public static extern void
    zego_register_room_extra_info_update_callback(zego_on_room_extra_info_update callback_func,
                                                  System.IntPtr user_context);

    /// Return Type: void
    ///callback_func: zego_on_room_set_room_extra_info_result
    ///user_context: void*
    [DllImportAttribute(ZegoConstans.LIB_NAME,
                        EntryPoint = "zego_register_room_set_room_extra_info_result_callback",
                        CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
    public static extern void zego_register_room_set_room_extra_info_result_callback(
        zego_on_room_set_room_extra_info_result callback_func, System.IntPtr user_context);

    [UnmanagedFunctionPointer(ZEGO_CALLINGCONVENTION)]
    public delegate void
    zego_on_room_extra_info_update([In()][MarshalAs(UnmanagedType.LPStr)] string room_id,
                                   IntPtr room_extra_info_list, uint room_extra_info_count,
                                   System.IntPtr user_context);

    [UnmanagedFunctionPointer(ZEGO_CALLINGCONVENTION)]
    public delegate void zego_on_room_set_room_extra_info_result(
        int error_code,
        [System.Runtime.InteropServices
             .InAttribute()][System.Runtime.InteropServices.MarshalAsAttribute(
            System.Runtime.InteropServices.UnmanagedType.LPStr)] string room_id,
        [System.Runtime.InteropServices
             .InAttribute()][System.Runtime.InteropServices.MarshalAsAttribute(
            System.Runtime.InteropServices.UnmanagedType.LPStr)] string key,
        int seq, System.IntPtr user_context);

    [UnmanagedFunctionPointer(ZEGO_CALLINGCONVENTION)]
    public delegate void
    zego_on_room_online_user_count_update([In()][MarshalAs(UnmanagedType.LPStr)] string room_id,
                                          int count, IntPtr user_context);

    [DllImport(LIB_NAME, EntryPoint = "zego_register_room_online_user_count_update_callback",
               CallingConvention = ZEGO_CALLINGCONVENTION)]
    public static extern void zego_register_room_online_user_count_update_callback(
        zego_on_room_online_user_count_update callback_func, IntPtr user_context);

    [DllImport(LIB_NAME, EntryPoint = "zego_express_renew_token",
               CallingConvention = ZEGO_CALLINGCONVENTION)]
    public static extern int
    zego_express_renew_token([In()][MarshalAs(UnmanagedType.LPStr)] string room_id,
                             [In()][MarshalAs(UnmanagedType.LPStr)] string token);

    [UnmanagedFunctionPointer(ZEGO_CALLINGCONVENTION)]
    public delegate void
    zego_on_room_token_will_expire([In()][MarshalAs(UnmanagedType.LPStr)] string room_id,
                                   int remain_time_in_second, System.IntPtr user_context);

    [DllImport(LIB_NAME, EntryPoint = "zego_register_room_token_will_expire_callback",
               CallingConvention = ZEGO_CALLINGCONVENTION)]
    public static extern void
    zego_register_room_token_will_expire_callback(zego_on_room_token_will_expire callback_func,
                                                  System.IntPtr user_context);

    [UnmanagedFunctionPointer(ZEGO_CALLINGCONVENTION)]
    public delegate void zego_on_room_login_result(
        int error_code,
        [In()][MarshalAs(UnmanagedType.CustomMarshaler,
                         MarshalTypeRef = typeof(ZegoUtil.UTF8StringMarshaler))] string
            extended_data,
        [In()][MarshalAs(UnmanagedType.CustomMarshaler,
                         MarshalTypeRef = typeof(ZegoUtil.UTF8StringMarshaler))] string room_id,
        int seq, IntPtr user_context);

    [DllImport(LIB_NAME, EntryPoint = "zego_register_room_login_result_callback",
               CallingConvention = ZEGO_CALLINGCONVENTION)]
    public static extern void
    zego_register_room_login_result_callback(zego_on_room_login_result callback_func,
                                             IntPtr user_context);

    [UnmanagedFunctionPointer(ZEGO_CALLINGCONVENTION)]
    public delegate void zego_on_room_logout_result(
        int error_code,
        [In()][MarshalAs(UnmanagedType.CustomMarshaler,
                         MarshalTypeRef = typeof(ZegoUtil.UTF8StringMarshaler))] string
            extended_data,
        [In()][MarshalAs(UnmanagedType.CustomMarshaler,
                         MarshalTypeRef = typeof(ZegoUtil.UTF8StringMarshaler))] string room_id,
        int seq, IntPtr user_context);

    [DllImport(LIB_NAME, EntryPoint = "zego_register_room_logout_result_callback",
               CallingConvention = ZEGO_CALLINGCONVENTION)]
    public static extern void
    zego_register_room_logout_result_callback(zego_on_room_logout_result callback_func,
                                              IntPtr user_context);

    [UnmanagedFunctionPointer(ZEGO_CALLINGCONVENTION)]
    public delegate void zego_on_room_state_changed(
        [In()][MarshalAs(UnmanagedType.CustomMarshaler,
                         MarshalTypeRef = typeof(ZegoUtil.UTF8StringMarshaler))] string room_id,
        ZegoRoomStateChangedReason reason, int error_code,
        [In()][MarshalAs(UnmanagedType.CustomMarshaler,
                         MarshalTypeRef = typeof(ZegoUtil.UTF8StringMarshaler))] string
            extended_data,
        IntPtr user_context);

    [DllImport(LIB_NAME, EntryPoint = "zego_register_room_state_changed_callback",
               CallingConvention = ZEGO_CALLINGCONVENTION)]
    public static extern void
    zego_register_room_state_changed_callback(zego_on_room_state_changed callback_func,
                                              IntPtr user_context);

    [DllImport(LIB_NAME, EntryPoint = "zego_express_logout_all_room_with_callback",
               CallingConvention = ZEGO_CALLINGCONVENTION)]

    public static extern int zego_express_logout_all_room_with_callback(ref int sequence);

    [DllImport(LIB_NAME, EntryPoint = "zego_express_logout_room_with_callback",
               CallingConvention = ZEGO_CALLINGCONVENTION)]
    public static extern int zego_express_logout_room_with_callback(
        [In()][MarshalAs(UnmanagedType.CustomMarshaler,
                         MarshalTypeRef = typeof(ZegoUtil.UTF8StringMarshaler))] string room_id,
        ref int sequence);
}

}