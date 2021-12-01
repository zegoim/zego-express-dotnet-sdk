using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
//using UnityEngine;
using System;
namespace ZEGO
{
    public class IExpressCustomVideoInternal
    {
        [UnmanagedFunctionPointer(ZegoConstans.ZEGO_CALLINGCONVENTION)]
        public delegate void zego_on_custom_video_render_captured_frame_data(ref IntPtr data, ref uint data_length, zego_video_frame_param param, ZegoVideoFlipMode flip_mode, ZegoPublishChannel channel, System.IntPtr user_context);
        
        [UnmanagedFunctionPointer(ZegoConstans.ZEGO_CALLINGCONVENTION)]
        public delegate void zego_on_custom_video_render_remote_frame_data([In()] [MarshalAs(UnmanagedType.LPStr)] string streamID, ref IntPtr data, ref uint data_length, zego_video_frame_param param, System.IntPtr user_context);

        [UnmanagedFunctionPointer(ZegoConstans.ZEGO_CALLINGCONVENTION)]
        public delegate void zego_on_custom_video_process_captured_unprocessed_raw_data(ref System.IntPtr data, ref uint data_length, zego_video_frame_param param, ulong reference_time_millisecond, ZegoPublishChannel channel, System.IntPtr user_context);

        [UnmanagedFunctionPointer(ZegoConstans.ZEGO_CALLINGCONVENTION)]
        public delegate void zego_on_custom_video_process_captured_unprocessed_cvpixelbuffer(IntPtr buffer, ulong reference_time_millisecond, ZegoPublishChannel channel, IntPtr user_context);

        [UnmanagedFunctionPointer(ZegoConstans.ZEGO_CALLINGCONVENTION)]
        public delegate void zego_on_custom_video_process_captured_unprocessed_texture_data(int texture_id, int width, int height, ulong reference_time_millisecond, ZegoPublishChannel channel, IntPtr user_context);

        [DllImportAttribute(ZegoConstans.LIB_NAME, EntryPoint = "zego_register_custom_video_render_captured_frame_data_callback", CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
        public static extern void zego_register_custom_video_render_captured_frame_data_callback(zego_on_custom_video_render_captured_frame_data callback_func, System.IntPtr user_context);
        [DllImportAttribute(ZegoConstans.LIB_NAME, EntryPoint = "zego_register_custom_video_render_remote_frame_data_callback", CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
        public static extern void zego_register_custom_video_render_remote_frame_data_callback(zego_on_custom_video_render_remote_frame_data callback_func, System.IntPtr user_context);


        [DllImportAttribute(ZegoConstans.LIB_NAME, EntryPoint = "zego_express_enable_custom_video_capture", CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
        public static extern int zego_express_enable_custom_video_capture([System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.I1)] bool enable, IntPtr config, ZegoPublishChannel channel);


        [UnmanagedFunctionPointer(ZegoConstans.ZEGO_CALLINGCONVENTION)]
        public delegate void zego_on_custom_video_capture_start(ZegoPublishChannel channel, System.IntPtr user_context);


        [UnmanagedFunctionPointer(ZegoConstans.ZEGO_CALLINGCONVENTION)]
        public delegate void zego_on_custom_video_capture_stop(ZegoPublishChannel channel, System.IntPtr user_context);


        [DllImportAttribute(ZegoConstans.LIB_NAME, EntryPoint = "zego_register_custom_video_capture_start_callback", CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
        public static extern void zego_register_custom_video_capture_start_callback(zego_on_custom_video_capture_start callback_func, System.IntPtr user_context);


        [DllImportAttribute(ZegoConstans.LIB_NAME, EntryPoint = "zego_register_custom_video_capture_stop_callback", CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
        public static extern void zego_register_custom_video_capture_stop_callback(zego_on_custom_video_capture_stop callback_func, System.IntPtr user_context);


        [DllImportAttribute(ZegoConstans.LIB_NAME, EntryPoint = "zego_express_send_custom_video_capture_raw_data", CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
        public static extern int zego_express_send_custom_video_capture_raw_data(byte[] data, uint data_length, zego_video_frame_param param, ulong reference_time, uint reference_time_scale, ZegoPublishChannel channel);

        [DllImportAttribute(ZegoConstans.LIB_NAME, EntryPoint = "zego_express_send_custom_video_capture_raw_data", CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
        public static extern int zego_express_send_custom_video_capture_raw_data(IntPtr data, uint data_length, zego_video_frame_param param, ulong reference_time, uint reference_time_scale, ZegoPublishChannel channel);

        [DllImportAttribute(ZegoConstans.LIB_NAME, EntryPoint = "zego_express_enable_custom_video_render", CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
        public static extern int zego_express_enable_custom_video_render([System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.I1)] bool enable, IntPtr config);

        [DllImportAttribute(ZegoConstans.LIB_NAME, EntryPoint = "zego_express_enable_custom_video_processing", CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
        public static extern int zego_express_enable_custom_video_processing([System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.I1)] bool enable, System.IntPtr config, ZegoPublishChannel channel);

        [DllImportAttribute(ZegoConstans.LIB_NAME, EntryPoint = "zego_express_send_custom_video_processed_raw_data", CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
        public static extern int zego_express_send_custom_video_processed_raw_data(ref IntPtr data, ref uint data_length, zego_video_frame_param param, ulong reference_time_millisecond, ZegoPublishChannel channel);

        [DllImportAttribute(ZegoConstans.LIB_NAME, EntryPoint = "zego_express_send_custom_video_processed_cv_pixel_buffer", CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
        public static extern int zego_express_send_custom_video_processed_cv_pixel_buffer(IntPtr buffer, ulong reference_time_millisecond, ZegoPublishChannel channel);

        [DllImportAttribute(ZegoConstans.LIB_NAME, EntryPoint = "zego_express_send_custom_video_processed_texture_data", CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
        public static extern int zego_express_send_custom_video_processed_texture_data(int texture_id, int width, int height, ulong reference_time_millisecond, ZegoPublishChannel channel);

        [DllImportAttribute(ZegoConstans.LIB_NAME, EntryPoint = "zego_register_custom_video_process_captured_unprocessed_raw_data_callback", CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
        public static extern int zego_register_custom_video_process_captured_unprocessed_raw_data_callback(zego_on_custom_video_process_captured_unprocessed_raw_data callback_func, System.IntPtr user_context);
    
        [DllImportAttribute(ZegoConstans.LIB_NAME, EntryPoint = "zego_register_custom_video_process_captured_unprocessed_cvpixelbuffer_callback", CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
        public static extern int zego_register_custom_video_process_captured_unprocessed_cvpixelbuffer_callback(zego_on_custom_video_process_captured_unprocessed_cvpixelbuffer callback_func, System.IntPtr user_context);

        [DllImportAttribute(ZegoConstans.LIB_NAME, EntryPoint = "zego_register_custom_video_process_captured_unprocessed_texture_data_callback", CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
        public static extern int zego_register_custom_video_process_captured_unprocessed_texture_data_callback(zego_on_custom_video_process_captured_unprocessed_texture_data callback_func, System.IntPtr user_context);
    }
}
