using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
namespace ZEGO
{
    public class IExpressIMInternal
    {
        /// Return Type: void
        ///room_id: char*
        ///param1: unsigned int
        ///message_id: int
        ///error_code: int
        ///seq: int
        ///user_context: void*
        [UnmanagedFunctionPointer(ZegoConstans.ZEGO_CALINGCONVENTION)]
        public delegate void zego_on_im_send_broadcast_message_result([System.Runtime.InteropServices.InAttribute()] [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string room_id,ulong message_id, int error_code, int seq, System.IntPtr user_context);

        /// Return Type: void
        ///room_id: char*
        ///message_info_list: zego_broadcast_message_info*
        ///message_count: unsigned int
        ///user_context: void*
        [UnmanagedFunctionPointer(ZegoConstans.ZEGO_CALINGCONVENTION)]
        public delegate void zego_on_im_recv_broadcast_message([System.Runtime.InteropServices.InAttribute()] [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string room_id, System.IntPtr message_info_list, uint message_count, System.IntPtr user_context);

        /// Return Type: void
        ///room_id: char*
        ///error_code: int
        ///seq: int
        ///user_context: void*
        [UnmanagedFunctionPointer(ZegoConstans.ZEGO_CALINGCONVENTION)]
        public delegate void zego_on_im_send_custom_command_result([System.Runtime.InteropServices.InAttribute()] [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string room_id, int error_code, int seq, System.IntPtr user_context);

        /// Return Type: void
        ///room_id: char*
        ///from_user: zego_user
        ///content: char*
        ///user_context: void*
        [UnmanagedFunctionPointer(ZegoConstans.ZEGO_CALINGCONVENTION)]
        public delegate void zego_on_im_recv_custom_command([System.Runtime.InteropServices.InAttribute()] [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string room_id, zego_user from_user, [System.Runtime.InteropServices.InAttribute()] [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(ZegoUtil.UTF8StringMarshaler))] string content, System.IntPtr user_context);

        /// Return Type: void
        ///room_id: char*
        ///message_id: char*
        ///error_code: int
        ///seq: int
        ///user_context: void*
        [UnmanagedFunctionPointer(ZegoConstans.ZEGO_CALINGCONVENTION)]
        public delegate void zego_on_im_send_barrage_message_result([System.Runtime.InteropServices.InAttribute()] [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string room_id, [System.Runtime.InteropServices.InAttribute()] [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string message_id, int error_code, int seq, System.IntPtr user_context);

        /// Return Type: void
        ///room_id: char*
        ///message_info_list: zego_barrage_message_info*
        ///message_count: unsigned int
        ///user_context: void*
        [UnmanagedFunctionPointer(ZegoConstans.ZEGO_CALINGCONVENTION)]
        public delegate void zego_on_im_recv_barrage_message([System.Runtime.InteropServices.InAttribute()] [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string room_id, System.IntPtr message_info_list, uint message_count, System.IntPtr user_context);




        /// Return Type: int
        ///room_id: char*
        ///content: char*
        [DllImportAttribute(ZegoConstans.LIB_NAME, EntryPoint = "zego_express_send_broadcast_message", CallingConvention = ZegoConstans.ZEGO_CALINGCONVENTION)]
        public static extern int zego_express_send_broadcast_message([System.Runtime.InteropServices.InAttribute()] [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string room_id, [System.Runtime.InteropServices.InAttribute()] [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(ZegoUtil.UTF8StringMarshaler))] string content);


        /// Return Type: int
        ///room_id: char*
        ///content: char*
        ///to_user_list: zego_user*
        ///to_user_count: unsigned int
        [DllImportAttribute(ZegoConstans.LIB_NAME, EntryPoint = "zego_express_send_custom_command", CallingConvention = ZegoConstans.ZEGO_CALINGCONVENTION)]
        public static extern int zego_express_send_custom_command([System.Runtime.InteropServices.InAttribute()] [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string room_id, [System.Runtime.InteropServices.InAttribute()] [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(ZegoUtil.UTF8StringMarshaler))] string content, zego_user[] user_list, uint to_user_count);


        /// Return Type: int
        ///room_id: char*
        ///content: char*
        [DllImportAttribute(ZegoConstans.LIB_NAME, EntryPoint = "zego_express_send_barrage_message", CallingConvention = ZegoConstans.ZEGO_CALINGCONVENTION)]
        public static extern int zego_express_send_barrage_message([System.Runtime.InteropServices.InAttribute()] [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string room_id, [System.Runtime.InteropServices.InAttribute()] [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(ZegoUtil.UTF8StringMarshaler))] string content);


        /// Return Type: void
        ///callback_func: zego_on_im_send_broadcast_message_result
        ///user_context: void*
        [DllImportAttribute(ZegoConstans.LIB_NAME, EntryPoint = "zego_register_im_send_broadcast_message_result_callback", CallingConvention = ZegoConstans.ZEGO_CALINGCONVENTION)]
        public static extern void zego_register_im_send_broadcast_message_result_callback(zego_on_im_send_broadcast_message_result callback_func, System.IntPtr user_context);


        /// Return Type: void
        ///callback_func: zego_on_im_recv_broadcast_message
        ///user_context: void*
        [DllImportAttribute(ZegoConstans.LIB_NAME, EntryPoint = "zego_register_im_recv_broadcast_message_callback", CallingConvention = ZegoConstans.ZEGO_CALINGCONVENTION)]
        public static extern void zego_register_im_recv_broadcast_message_callback(zego_on_im_recv_broadcast_message callback_func, System.IntPtr user_context);


        /// Return Type: void
        ///callback_func: zego_on_im_send_custom_command_result
        ///user_context: void*
        [DllImportAttribute(ZegoConstans.LIB_NAME, EntryPoint = "zego_register_im_send_custom_command_result_callback", CallingConvention = ZegoConstans.ZEGO_CALINGCONVENTION)]
        public static extern void zego_register_im_send_custom_command_result_callback(zego_on_im_send_custom_command_result callback_func, System.IntPtr user_context);


        /// Return Type: void
        ///callback_func: zego_on_im_recv_custom_command
        ///user_context: void*
        [DllImportAttribute(ZegoConstans.LIB_NAME, EntryPoint = "zego_register_im_recv_custom_command_callback", CallingConvention = ZegoConstans.ZEGO_CALINGCONVENTION)]
        public static extern void zego_register_im_recv_custom_command_callback(zego_on_im_recv_custom_command callback_func, System.IntPtr user_context);


        /// Return Type: void
        ///callback_func: zego_on_im_send_barrage_message_result
        ///user_context: void*
        [DllImportAttribute(ZegoConstans.LIB_NAME, EntryPoint = "zego_register_im_send_barrage_message_result_callback", CallingConvention = ZegoConstans.ZEGO_CALINGCONVENTION)]
        public static extern void zego_register_im_send_barrage_message_result_callback(zego_on_im_send_barrage_message_result callback_func, System.IntPtr user_context);


        /// Return Type: void
        ///callback_func: zego_on_im_recv_barrage_message
        ///user_context: void*
        [DllImportAttribute(ZegoConstans.LIB_NAME, EntryPoint = "zego_register_im_recv_barrage_message_callback", CallingConvention = ZegoConstans.ZEGO_CALINGCONVENTION)]
        public static extern void zego_register_im_recv_barrage_message_callback(zego_on_im_recv_barrage_message callback_func, System.IntPtr user_context);

    }


}

