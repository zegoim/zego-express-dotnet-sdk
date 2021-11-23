using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using static ZEGO.ZegoConstans;
namespace ZEGO
{
    public class IExpressRoomInternal
    {
        [UnmanagedFunctionPointer(ZEGO_CALINGCONVENTION)]
        public delegate void zego_on_room_state_update([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string room_id, ZegoRoomState state, int error_code, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string extended_data, System.IntPtr user_context);

        [UnmanagedFunctionPointer(ZEGO_CALINGCONVENTION)]
        public delegate void zego_on_room_user_update([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string room_id, ZegoUpdateType update_type, System.IntPtr user_list,uint user_count, System.IntPtr user_context);


        [UnmanagedFunctionPointer(ZEGO_CALINGCONVENTION)]
        public delegate void zego_on_room_stream_update([InAttribute()][MarshalAsAttribute(UnmanagedType.LPStr)] string room_id, ZegoUpdateType update_type, System.IntPtr stream_info_list, uint stream_info_count, [InAttribute()][MarshalAsAttribute(UnmanagedType.LPStr)] string extend_data, System.IntPtr user_context);

        [UnmanagedFunctionPointer(ZEGO_CALINGCONVENTION)]
        public delegate void zego_on_room_stream_extra_info_update([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string room_id,System.IntPtr stream_info_list, uint stream_info_count, System.IntPtr user_context);

        [DllImportAttribute(ZegoConstans.LIB_NAME, EntryPoint = "zego_express_login_room", CallingConvention = ZegoConstans.ZEGO_CALINGCONVENTION)]
        public static extern int zego_express_login_room([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string room_id,zego_user user, System.IntPtr config);

        [DllImportAttribute(ZegoConstans.LIB_NAME, EntryPoint = "zego_express_logout_room", CallingConvention = ZegoConstans.ZEGO_CALINGCONVENTION)]
        public static extern int zego_express_logout_room([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string room_id);

        [DllImportAttribute(ZegoConstans.LIB_NAME, EntryPoint = "zego_register_room_state_update_callback", CallingConvention = ZegoConstans.ZEGO_CALINGCONVENTION)]
        public static extern void zego_register_room_state_update_callback(zego_on_room_state_update callback_func, System.IntPtr user_context);

        [DllImportAttribute(ZegoConstans.LIB_NAME, EntryPoint = "zego_register_room_user_update_callback", CallingConvention = ZegoConstans.ZEGO_CALINGCONVENTION)]
        public static extern void zego_register_room_user_update_callback(zego_on_room_user_update callback_func, System.IntPtr user_context);


        [DllImportAttribute(ZegoConstans.LIB_NAME, EntryPoint = "zego_register_room_stream_update_callback", CallingConvention = ZegoConstans.ZEGO_CALINGCONVENTION)]
        public static extern void zego_register_room_stream_update_callback(zego_on_room_stream_update callback_func, System.IntPtr user_context);



        [DllImportAttribute(ZegoConstans.LIB_NAME, EntryPoint = "zego_register_room_stream_extra_info_update_callback", CallingConvention = ZegoConstans.ZEGO_CALINGCONVENTION)]
        public static extern void zego_register_room_stream_extra_info_update_callback(zego_on_room_stream_extra_info_update callback_func, System.IntPtr user_context);

    }


}