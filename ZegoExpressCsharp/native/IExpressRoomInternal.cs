using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using static ZEGO.ZegoConstans;
namespace ZEGO
{
    public class IExpressRoomInternal
    {
        [UnmanagedFunctionPointer(ZEGO_CALINGCONVENTION)]
        public delegate void zego_on_room_state_update([In()] [MarshalAs(UnmanagedType.LPStr)] string room_id, ZegoRoomState state, int error_code, [In()][MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(ZegoUtil.UTF8StringMarshaler))] string extended_data, IntPtr user_context);

        [UnmanagedFunctionPointer(ZEGO_CALINGCONVENTION)]
        public delegate void zego_on_room_user_update([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string room_id, ZegoUpdateType update_type, System.IntPtr user_list,uint user_count, System.IntPtr user_context);


        [UnmanagedFunctionPointer(ZEGO_CALINGCONVENTION)]
        public delegate void zego_on_room_stream_update([In()][MarshalAs(UnmanagedType.LPStr)] string room_id, ZegoUpdateType update_type, IntPtr stream_info_list, uint stream_info_count, [In()][MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(ZegoUtil.UTF8StringMarshaler))] string extend_data, IntPtr user_context);

        [UnmanagedFunctionPointer(ZEGO_CALINGCONVENTION)]
        public delegate void zego_on_room_stream_extra_info_update([InAttribute()] [MarshalAs(UnmanagedType.LPStr)] string room_id, IntPtr stream_info_list, uint stream_info_count, IntPtr user_context);

        [DllImportAttribute(ZegoConstans.LIB_NAME, EntryPoint = "zego_express_login_room", CallingConvention = ZegoConstans.ZEGO_CALINGCONVENTION)]
        public static extern int zego_express_login_room([In()] [MarshalAs(UnmanagedType.LPStr)] string room_id,zego_user user, System.IntPtr config);

        [DllImportAttribute(ZegoConstans.LIB_NAME, EntryPoint = "zego_express_logout_room", CallingConvention = ZegoConstans.ZEGO_CALINGCONVENTION)]
        public static extern int zego_express_logout_room([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string room_id);

        [DllImportAttribute(ZegoConstans.LIB_NAME, EntryPoint = "zego_express_logout_all_room", CallingConvention = ZegoConstans.ZEGO_CALINGCONVENTION)]
        public static extern int zego_express_logout_all_room();

        [DllImport(LIB_NAME, EntryPoint = "zego_express_switch_room", CallingConvention = ZEGO_CALINGCONVENTION)]
        public static extern int zego_express_switch_room([In()][MarshalAs(UnmanagedType.LPStr)] string from_room_id, [In()][MarshalAs(UnmanagedType.LPStr)] string to_room_id, IntPtr config);

        [DllImportAttribute(ZegoConstans.LIB_NAME, EntryPoint = "zego_register_room_state_update_callback", CallingConvention = ZegoConstans.ZEGO_CALINGCONVENTION)]
        public static extern void zego_register_room_state_update_callback(zego_on_room_state_update callback_func, System.IntPtr user_context);

        [DllImportAttribute(ZegoConstans.LIB_NAME, EntryPoint = "zego_register_room_user_update_callback", CallingConvention = ZegoConstans.ZEGO_CALINGCONVENTION)]
        public static extern void zego_register_room_user_update_callback(zego_on_room_user_update callback_func, System.IntPtr user_context);


        [DllImportAttribute(ZegoConstans.LIB_NAME, EntryPoint = "zego_register_room_stream_update_callback", CallingConvention = ZegoConstans.ZEGO_CALINGCONVENTION)]
        public static extern void zego_register_room_stream_update_callback(zego_on_room_stream_update callback_func, System.IntPtr user_context);



        [DllImportAttribute(ZegoConstans.LIB_NAME, EntryPoint = "zego_register_room_stream_extra_info_update_callback", CallingConvention = ZegoConstans.ZEGO_CALINGCONVENTION)]
        public static extern void zego_register_room_stream_extra_info_update_callback(zego_on_room_stream_extra_info_update callback_func, System.IntPtr user_context);

        [DllImport(ZegoConstans.LIB_NAME, EntryPoint = "zego_express_set_room_extra_info", CallingConvention = ZegoConstans.ZEGO_CALINGCONVENTION)]
        public static extern int zego_express_set_room_extra_info([In()][MarshalAs(UnmanagedType.LPStr)] string room_id, [In()][MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(ZegoUtil.UTF8StringMarshaler))] string key, [In()][MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(ZegoUtil.UTF8StringMarshaler))] string value);

    }


}