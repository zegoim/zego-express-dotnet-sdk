using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System;
namespace ZEGO
{
    public class IExpressCustomVideoInternal
    {
        [UnmanagedFunctionPointer(ZegoConstans.ZEGO_CALINGCONVENTION)]
        public delegate void zego_on_custom_video_render_captured_frame_data([In][MarshalAs(UnmanagedType.LPArray, SizeConst = 4)] IntPtr[] data,
            [In][MarshalAs(UnmanagedType.LPArray, SizeConst = 4)] uint[] data_length, zego_video_frame_param param, ZegoVideoFlipMode flip_mode,
            ZegoPublishChannel channel, IntPtr user_context);

        [UnmanagedFunctionPointer(ZegoConstans.ZEGO_CALINGCONVENTION)]
        public delegate void zego_on_custom_video_render_remote_frame_data([In][MarshalAs(UnmanagedType.LPStr)] string streamID,
            [In][MarshalAs(UnmanagedType.LPArray, SizeConst = 4)] IntPtr[] data, [In][MarshalAs(UnmanagedType.LPArray, SizeConst = 4)] uint[] data_length,
            zego_video_frame_param param, IntPtr user_context);


        [DllImportAttribute(ZegoConstans.LIB_NAME, EntryPoint = "zego_register_custom_video_render_captured_frame_data_callback", CallingConvention = ZegoConstans.ZEGO_CALINGCONVENTION)]
        public static extern void zego_register_custom_video_render_captured_frame_data_callback(zego_on_custom_video_render_captured_frame_data callback_func, System.IntPtr user_context);
        [DllImportAttribute(ZegoConstans.LIB_NAME, EntryPoint = "zego_register_custom_video_render_remote_frame_data_callback", CallingConvention = ZegoConstans.ZEGO_CALINGCONVENTION)]
        public static extern void zego_register_custom_video_render_remote_frame_data_callback(zego_on_custom_video_render_remote_frame_data callback_func, System.IntPtr user_context);
        /// Return Type: int
        ///enable: boolean
        ///config: zego_custom_video_render_config*
        [DllImportAttribute(ZegoConstans.LIB_NAME, EntryPoint = "zego_express_enable_custom_video_render", CallingConvention = ZegoConstans.ZEGO_CALINGCONVENTION)]
        public static extern int zego_express_enable_custom_video_render([System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.I1)] bool enable, IntPtr config);


        /// Return Type: int
        ///enable: boolean
        ///config: zego_custom_video_capture_config*
        ///channel: zego_publish_channel
        [DllImportAttribute(ZegoConstans.LIB_NAME, EntryPoint = "zego_express_enable_custom_video_capture", CallingConvention = ZegoConstans.ZEGO_CALINGCONVENTION)]
        public static extern int zego_express_enable_custom_video_capture([System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.I1)] bool enable, IntPtr config, ZegoPublishChannel channel);



        /// Return Type: void
        ///channel: zego_publish_channel
        ///user_context: void*
        [UnmanagedFunctionPointer(ZegoConstans.ZEGO_CALINGCONVENTION)]
        public delegate void zego_on_custom_video_capture_start(ZegoPublishChannel channel, System.IntPtr user_context);

        /// Return Type: void
        ///channel: zego_publish_channel
        ///user_context: void*
        [UnmanagedFunctionPointer(ZegoConstans.ZEGO_CALINGCONVENTION)]
        public delegate void zego_on_custom_video_capture_stop(ZegoPublishChannel channel, System.IntPtr user_context);
        /// Return Type: void
        ///callback_func: zego_on_custom_video_capture_start
        ///user_context: void*
        [DllImportAttribute(ZegoConstans.LIB_NAME, EntryPoint = "zego_register_custom_video_capture_start_callback", CallingConvention = ZegoConstans.ZEGO_CALINGCONVENTION)]
        public static extern void zego_register_custom_video_capture_start_callback(zego_on_custom_video_capture_start callback_func, System.IntPtr user_context);


        /// Return Type: void
        ///callback_func: zego_on_custom_video_capture_stop
        ///user_context: void*
        [DllImportAttribute(ZegoConstans.LIB_NAME, EntryPoint = "zego_register_custom_video_capture_stop_callback", CallingConvention = ZegoConstans.ZEGO_CALINGCONVENTION)]
        public static extern void zego_register_custom_video_capture_stop_callback(zego_on_custom_video_capture_stop callback_func, System.IntPtr user_context);

        /// Return Type: int
        ///data: char*
        ///data_length: unsigned int
        ///param: zego_video_frame_param
        ///reference_time: unsigned int
        ///reference_time_scale: unsigned int
        ///channel: zego_publish_channel
        [DllImportAttribute(ZegoConstans.LIB_NAME, EntryPoint = "zego_express_send_custom_video_capture_raw_data", CallingConvention = ZegoConstans.ZEGO_CALINGCONVENTION)]
        public static extern int zego_express_send_custom_video_capture_raw_data(byte[] data, uint data_length, zego_video_frame_param param, ulong reference_time, uint reference_time_scale, ZegoPublishChannel channel);
    }
}
