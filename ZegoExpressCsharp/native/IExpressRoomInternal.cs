using System;
using System.Runtime.InteropServices;
using static ZEGO.ZegoConstans;
//using UnityEngine;
namespace ZEGO
{
    public class IExpressRoomInternal
    {
        [UnmanagedFunctionPointer(ZEGO_CALLINGCONVENTION)]
        public delegate void zego_on_room_state_update([In()] [MarshalAs(UnmanagedType.LPStr)] string room_id, ZegoRoomState state, int error_code, [In()][MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(ZegoUtil.UTF8StringMarshaler))] string extended_data, IntPtr user_context);

        [UnmanagedFunctionPointer(ZEGO_CALLINGCONVENTION)]
        public delegate void zego_on_room_user_update([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string room_id, ZegoUpdateType update_type, System.IntPtr user_list,uint user_count, System.IntPtr user_context);


        [UnmanagedFunctionPointer(ZEGO_CALLINGCONVENTION)]
        public delegate void zego_on_room_stream_update([In()][MarshalAs(UnmanagedType.LPStr)] string room_id, ZegoUpdateType update_type, IntPtr stream_info_list, uint stream_info_count, [In()][MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(ZegoUtil.UTF8StringMarshaler))] string extend_data, IntPtr user_context);

        [UnmanagedFunctionPointer(ZEGO_CALLINGCONVENTION)]
        public delegate void zego_on_room_stream_extra_info_update([InAttribute()] [MarshalAs(UnmanagedType.LPStr)] string room_id, IntPtr stream_info_list, uint stream_info_count, IntPtr user_context);

        [DllImportAttribute(ZegoConstans.LIB_NAME, EntryPoint = "zego_express_login_room", CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
        public static extern int zego_express_login_room([In()] [MarshalAs(UnmanagedType.LPStr)] string room_id,zego_user user, System.IntPtr config);

        [DllImportAttribute(ZegoConstans.LIB_NAME, EntryPoint = "zego_express_login_multi_room", CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
        public static extern int zego_express_login_multi_room([InAttribute()][MarshalAsAttribute(UnmanagedType.LPStr)] string room_id, System.IntPtr config);

        [DllImportAttribute(ZegoConstans.LIB_NAME, EntryPoint = "zego_express_logout_room", CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
        public static extern int zego_express_logout_room([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string room_id);

        [DllImportAttribute(ZegoConstans.LIB_NAME, EntryPoint = "zego_express_logout_all_room", CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
        public static extern int zego_express_logout_all_room();

        [DllImport(LIB_NAME, EntryPoint = "zego_express_switch_room", CallingConvention = ZEGO_CALLINGCONVENTION)]
        public static extern int zego_express_switch_room([In()][MarshalAs(UnmanagedType.LPStr)] string from_room_id, [In()][MarshalAs(UnmanagedType.LPStr)] string to_room_id, IntPtr config);

        [DllImportAttribute(ZegoConstans.LIB_NAME, EntryPoint = "zego_register_room_state_update_callback", CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
        public static extern void zego_register_room_state_update_callback(zego_on_room_state_update callback_func, System.IntPtr user_context);

        [DllImportAttribute(ZegoConstans.LIB_NAME, EntryPoint = "zego_register_room_user_update_callback", CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
        public static extern void zego_register_room_user_update_callback(zego_on_room_user_update callback_func, System.IntPtr user_context);


        [DllImportAttribute(ZegoConstans.LIB_NAME, EntryPoint = "zego_register_room_stream_update_callback", CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
        public static extern void zego_register_room_stream_update_callback(zego_on_room_stream_update callback_func, System.IntPtr user_context);



        [DllImportAttribute(ZegoConstans.LIB_NAME, EntryPoint = "zego_register_room_stream_extra_info_update_callback", CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
        public static extern void zego_register_room_stream_extra_info_update_callback(zego_on_room_stream_extra_info_update callback_func, System.IntPtr user_context);

        [DllImport(ZegoConstans.LIB_NAME, EntryPoint = "zego_express_set_room_extra_info", CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
        public static extern int zego_express_set_room_extra_info([In()][MarshalAs(UnmanagedType.LPStr)] string room_id, [In()][MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(ZegoUtil.UTF8StringMarshaler))] string key, [In()][MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(ZegoUtil.UTF8StringMarshaler))] string value);


        /// Return Type: void
        ///callback_func: zego_on_room_extra_info_update
        ///user_context: void*
        [DllImportAttribute(ZegoConstans.LIB_NAME, EntryPoint = "zego_register_room_extra_info_update_callback", CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
        public static extern void zego_register_room_extra_info_update_callback(zego_on_room_extra_info_update callback_func, System.IntPtr user_context);


        /// Return Type: void
        ///callback_func: zego_on_room_set_room_extra_info_result
        ///user_context: void*
        [DllImportAttribute(ZegoConstans.LIB_NAME, EntryPoint = "zego_register_room_set_room_extra_info_result_callback", CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
        public static extern void zego_register_room_set_room_extra_info_result_callback(zego_on_room_set_room_extra_info_result callback_func, System.IntPtr user_context);

        [UnmanagedFunctionPointer(ZEGO_CALLINGCONVENTION)]
        public delegate void zego_on_room_extra_info_update([In()] [MarshalAs(UnmanagedType.LPStr)] string room_id, IntPtr room_extra_info_list, uint room_extra_info_count, System.IntPtr user_context);

        [UnmanagedFunctionPointer(ZEGO_CALLINGCONVENTION)]
        public delegate void zego_on_room_set_room_extra_info_result(int error_code, [System.Runtime.InteropServices.InAttribute()] [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string room_id, [System.Runtime.InteropServices.InAttribute()] [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string key, int seq, System.IntPtr user_context);

        [UnmanagedFunctionPointer(ZEGO_CALLINGCONVENTION)]
        public delegate void zego_on_room_online_user_count_update([In()] [MarshalAs(UnmanagedType.LPStr)] string room_id, int count, IntPtr user_context);

        [DllImport(LIB_NAME, EntryPoint = "zego_register_room_online_user_count_update_callback", CallingConvention = ZEGO_CALLINGCONVENTION)]
        public static extern void zego_register_room_online_user_count_update_callback(zego_on_room_online_user_count_update callback_func, IntPtr user_context);

        
    }


}