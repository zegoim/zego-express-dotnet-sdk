﻿using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
//using UnityEngine;
namespace ZEGO {
public class IExpressIMInternal {
    /// Return Type: void
    ///room_id: char*
    ///param1: unsigned int
    ///message_id: int
    ///error_code: int
    ///seq: int
    ///user_context: void*
    [UnmanagedFunctionPointer(ZegoConstans.ZEGO_CALLINGCONVENTION)]
    public delegate void
    zego_on_im_send_broadcast_message_result([In()][MarshalAs(UnmanagedType.LPStr)] string room_id,
                                             ulong message_id, int error_code, int seq,
                                             System.IntPtr user_context);

    /// Return Type: void
    ///room_id: char*
    ///message_info_list: zego_broadcast_message_info*
    ///message_count: unsigned int
    ///user_context: void*
    [UnmanagedFunctionPointer(ZegoConstans.ZEGO_CALLINGCONVENTION)]
    public delegate void
    zego_on_im_recv_broadcast_message([In()][MarshalAs(UnmanagedType.LPStr)] string room_id,
                                      System.IntPtr message_info_list, uint message_count,
                                      System.IntPtr user_context);

    /// Return Type: void
    ///room_id: char*
    ///error_code: int
    ///seq: int
    ///user_context: void*
    [UnmanagedFunctionPointer(ZegoConstans.ZEGO_CALLINGCONVENTION)]
    public delegate void
    zego_on_im_send_custom_command_result([In()][MarshalAs(UnmanagedType.LPStr)] string room_id,
                                          int error_code, int seq, System.IntPtr user_context);

    /// Return Type: void
    ///room_id: char*
    ///from_user: zego_user
    ///content: char*
    ///user_context: void*
    [UnmanagedFunctionPointer(ZegoConstans.ZEGO_CALLINGCONVENTION)]
    public delegate void zego_on_im_recv_custom_command(
        [In()][MarshalAs(UnmanagedType.LPStr)] string room_id, zego_user from_user,
        [In()][MarshalAs(UnmanagedType.CustomMarshaler,
                         MarshalTypeRef = typeof(ZegoUtil.UTF8StringMarshaler))] string content,
        System.IntPtr user_context);

    /// Return Type: void
    ///room_id: char*
    ///message_id: char*
    ///error_code: int
    ///seq: int
    ///user_context: void*
    [UnmanagedFunctionPointer(ZegoConstans.ZEGO_CALLINGCONVENTION)]
    public delegate void
    zego_on_im_send_barrage_message_result([In()][MarshalAs(UnmanagedType.LPStr)] string room_id,
                                           [In()][MarshalAs(UnmanagedType.LPStr)] string message_id,
                                           int error_code, int seq, System.IntPtr user_context);

    /// Return Type: void
    ///room_id: char*
    ///message_info_list: zego_barrage_message_info*
    ///message_count: unsigned int
    ///user_context: void*
    [UnmanagedFunctionPointer(ZegoConstans.ZEGO_CALLINGCONVENTION)]
    public delegate void
    zego_on_im_recv_barrage_message([In()][MarshalAs(UnmanagedType.LPStr)] string room_id,
                                    System.IntPtr message_info_list, uint message_count,
                                    System.IntPtr user_context);

    /// Return Type: int
    ///room_id: char*
    ///content: char*
    [DllImportAttribute(ZegoConstans.LIB_NAME, EntryPoint = "zego_express_send_broadcast_message",
                        CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
    public static extern int zego_express_send_broadcast_message(
        [In()][MarshalAs(UnmanagedType.LPStr)] string room_id,
        [In()][MarshalAs(UnmanagedType.CustomMarshaler,
                         MarshalTypeRef = typeof(ZegoUtil.UTF8StringMarshaler))] string content);

    /// Return Type: int
    ///room_id: char*
    ///content: char*
    ///to_user_list: zego_user*
    ///to_user_count: unsigned int
    [DllImport(ZegoConstans.LIB_NAME, EntryPoint = "zego_express_send_custom_command",
               CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
    public static extern int zego_express_send_custom_command(
        [In()][MarshalAs(UnmanagedType.LPStr)] string room_id,
        [In()][MarshalAs(UnmanagedType.CustomMarshaler,
                         MarshalTypeRef = typeof(ZegoUtil.UTF8StringMarshaler))] string content,
        zego_user[] user_list, uint to_user_count);

    /// Return Type: int
    ///room_id: char*
    ///content: char*
    [DllImport(ZegoConstans.LIB_NAME, EntryPoint = "zego_express_send_barrage_message",
               CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
    public static extern int zego_express_send_barrage_message(
        [In()][MarshalAs(UnmanagedType.LPStr)] string room_id,
        [In()][MarshalAs(UnmanagedType.CustomMarshaler,
                         MarshalTypeRef = typeof(ZegoUtil.UTF8StringMarshaler))] string content);

    /// Return Type: void
    ///callback_func: zego_on_im_send_broadcast_message_result
    ///user_context: void*
    [DllImportAttribute(ZegoConstans.LIB_NAME,
                        EntryPoint = "zego_register_im_send_broadcast_message_result_callback",
                        CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
    public static extern void zego_register_im_send_broadcast_message_result_callback(
        zego_on_im_send_broadcast_message_result callback_func, System.IntPtr user_context);

    /// Return Type: void
    ///callback_func: zego_on_im_recv_broadcast_message
    ///user_context: void*
    [DllImportAttribute(ZegoConstans.LIB_NAME,
                        EntryPoint = "zego_register_im_recv_broadcast_message_callback",
                        CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
    public static extern void zego_register_im_recv_broadcast_message_callback(
        zego_on_im_recv_broadcast_message callback_func, System.IntPtr user_context);

    /// Return Type: void
    ///callback_func: zego_on_im_send_custom_command_result
    ///user_context: void*
    [DllImportAttribute(ZegoConstans.LIB_NAME,
                        EntryPoint = "zego_register_im_send_custom_command_result_callback",
                        CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
    public static extern void zego_register_im_send_custom_command_result_callback(
        zego_on_im_send_custom_command_result callback_func, System.IntPtr user_context);

    /// Return Type: void
    ///callback_func: zego_on_im_recv_custom_command
    ///user_context: void*
    [DllImportAttribute(ZegoConstans.LIB_NAME,
                        EntryPoint = "zego_register_im_recv_custom_command_callback",
                        CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
    public static extern void
    zego_register_im_recv_custom_command_callback(zego_on_im_recv_custom_command callback_func,
                                                  System.IntPtr user_context);

    /// Return Type: void
    ///callback_func: zego_on_im_send_barrage_message_result
    ///user_context: void*
    [DllImportAttribute(ZegoConstans.LIB_NAME,
                        EntryPoint = "zego_register_im_send_barrage_message_result_callback",
                        CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
    public static extern void zego_register_im_send_barrage_message_result_callback(
        zego_on_im_send_barrage_message_result callback_func, System.IntPtr user_context);

    /// Return Type: void
    ///callback_func: zego_on_im_recv_barrage_message
    ///user_context: void*
    [DllImportAttribute(ZegoConstans.LIB_NAME,
                        EntryPoint = "zego_register_im_recv_barrage_message_callback",
                        CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
    public static extern void
    zego_register_im_recv_barrage_message_callback(zego_on_im_recv_barrage_message callback_func,
                                                   System.IntPtr user_context);

    [UnmanagedFunctionPointer(ZegoConstans.ZEGO_CALLINGCONVENTION)]
    public delegate void zego_on_real_time_sequential_data_sent(int error_code, int instance_index,
                                                                int seq, IntPtr user_context);

    [DllImport(ZegoConstans.LIB_NAME,
               EntryPoint = "zego_register_real_time_sequential_data_sent_callback",
               CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
    public static extern void zego_register_real_time_sequential_data_sent_callback(
        zego_on_real_time_sequential_data_sent callback_func, IntPtr user_context);

    [UnmanagedFunctionPointer(ZegoConstans.ZEGO_CALLINGCONVENTION)]
    public delegate void zego_on_receive_real_time_sequential_data(
        int manager, IntPtr data, uint data_length,
        [In()][MarshalAs(UnmanagedType.LPStr)] string stream_id, IntPtr user_context);

    [DllImport(ZegoConstans.LIB_NAME,
               EntryPoint = "zego_register_receive_real_time_sequential_data_callback",
               CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
    public static extern void zego_register_receive_real_time_sequential_data_callback(
        zego_on_receive_real_time_sequential_data callback_func, IntPtr user_context);

    [DllImport(ZegoConstans.LIB_NAME,
               EntryPoint = "zego_express_create_real_time_sequential_data_manager",
               CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
    public static extern int zego_express_create_real_time_sequential_data_manager(
        [In()][MarshalAs(UnmanagedType.LPStr)] string room_id);

    [DllImport(ZegoConstans.LIB_NAME,
               EntryPoint = "zego_express_destroy_real_time_sequential_data_manager",
               CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
    public static extern int
    zego_express_destroy_real_time_sequential_data_manager(int instance_index);

    [DllImport(ZegoConstans.LIB_NAME,
               EntryPoint = "zego_express_real_time_sequential_data_start_broadcasting",
               CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
    public static extern int zego_express_real_time_sequential_data_start_broadcasting(
        [In()][MarshalAs(UnmanagedType.LPStr)] string stream_id, int instance_index);

    [DllImport(ZegoConstans.LIB_NAME,
               EntryPoint = "zego_express_real_time_sequential_data_stop_broadcasting",
               CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
    public static extern int zego_express_real_time_sequential_data_stop_broadcasting(
        [In()][MarshalAs(UnmanagedType.LPStr)] string stream_id, int instance_index);

    [DllImport(ZegoConstans.LIB_NAME, EntryPoint = "zego_express_send_real_time_sequential_data",
               CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
    public static extern int zego_express_send_real_time_sequential_data(
        IntPtr data, uint data_length, [In()][MarshalAs(UnmanagedType.LPStr)] string stream_id,
        int instance_index);

    [DllImport(ZegoConstans.LIB_NAME,
               EntryPoint = "zego_express_real_time_sequential_data_start_subscribing",
               CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
    public static extern int zego_express_real_time_sequential_data_start_subscribing(
        [In()][MarshalAs(UnmanagedType.LPStr)] string stream_id, int instance_index);

    [DllImport(ZegoConstans.LIB_NAME,
               EntryPoint = "zego_express_real_time_sequential_data_stop_subscribing",
               CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
    public static extern int zego_express_real_time_sequential_data_stop_subscribing(
        [In()][MarshalAs(UnmanagedType.LPStr)] string stream_id, int instance_index);
}

}
