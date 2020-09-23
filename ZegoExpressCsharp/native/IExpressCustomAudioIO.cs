using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace ZEGO
{
    class IExpressCustomAudioIO
    {
        [DllImportAttribute(ZegoConstans.LIB_NAME, EntryPoint = "zego_express_enable_audio_data_callback", CallingConvention = ZegoConstans.ZEGO_CALINGCONVENTION)]
        public static extern int zego_express_enable_audio_data_callback([System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.I1)]bool enable, uint callback_bit_mask, zego_audio_frame_param param);




        /// Return Type: void
        ///data: char*
        ///data_length: unsigned int
        ///param: zego_audio_frame_param
        ///user_context: void*
        [UnmanagedFunctionPointer(ZegoConstans.ZEGO_CALINGCONVENTION)]
        public delegate void zego_on_remote_audio_data(IntPtr  data, uint data_length, zego_audio_frame_param param, System.IntPtr user_context);

        /// Return Type: void
        ///data: char*
        ///data_length: unsigned int
        ///param: zego_audio_frame_param
        ///user_context: void*
        [UnmanagedFunctionPointer(ZegoConstans.ZEGO_CALINGCONVENTION)]
        public delegate void zego_on_captured_audio_data(IntPtr data, uint data_length, zego_audio_frame_param param, System.IntPtr user_context);

        /// Return Type: void
        ///data: char*
        ///data_length: unsigned int
        ///param: zego_audio_frame_param
        ///user_context: void*
        [UnmanagedFunctionPointer(ZegoConstans.ZEGO_CALINGCONVENTION)]
        public delegate void zego_on_mixed_audio_data(IntPtr data, uint data_length, zego_audio_frame_param param, System.IntPtr user_context);



        /// Return Type: void
        ///callback_func: zego_on_remote_audio_data
        ///user_context: void*
        [DllImportAttribute(ZegoConstans.LIB_NAME, EntryPoint = "zego_register_remote_audio_data_callback", CallingConvention = ZegoConstans.ZEGO_CALINGCONVENTION)]
        public static extern void zego_register_remote_audio_data_callback(zego_on_remote_audio_data callback_func, System.IntPtr user_context);


        /// Return Type: void
        ///callback_func: zego_on_captured_audio_data
        ///user_context: void*
        [DllImportAttribute(ZegoConstans.LIB_NAME, EntryPoint = "zego_register_captured_audio_data_callback", CallingConvention = ZegoConstans.ZEGO_CALINGCONVENTION)]
        public static extern void zego_register_captured_audio_data_callback(zego_on_captured_audio_data callback_func, System.IntPtr user_context);


        /// Return Type: void
        ///callback_func: zego_on_mixed_audio_data
        ///user_context: void*
        [DllImportAttribute(ZegoConstans.LIB_NAME, EntryPoint = "zego_register_mixed_audio_data_callback", CallingConvention = ZegoConstans.ZEGO_CALINGCONVENTION)]
        public static extern void zego_register_mixed_audio_data_callback(zego_on_mixed_audio_data callback_func, System.IntPtr user_context);


        [DllImportAttribute(ZegoConstans.LIB_NAME, EntryPoint = "zego_express_enable_custom_audio_io", CallingConvention = ZegoConstans.ZEGO_CALINGCONVENTION)]
        public static extern int zego_express_enable_custom_audio_io([System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.I1)] bool enable, IntPtr config, ZegoPublishChannel channel);


        [DllImportAttribute(ZegoConstans.LIB_NAME, EntryPoint = "zego_express_send_custom_audio_capture_aac_data", CallingConvention = ZegoConstans.ZEGO_CALINGCONVENTION)]
        public static extern int zego_express_send_custom_audio_capture_aac_data(byte[] data, uint data_length, uint config_length, ulong reference_time_millisecond, zego_audio_frame_param param, ZegoPublishChannel channel);


        [DllImportAttribute(ZegoConstans.LIB_NAME, EntryPoint = "zego_express_send_custom_audio_capture_pcm_data", CallingConvention = ZegoConstans.ZEGO_CALINGCONVENTION)]
        public static extern int zego_express_send_custom_audio_capture_pcm_data(byte[] data, uint data_length, zego_audio_frame_param param, ZegoPublishChannel channel);


        [DllImportAttribute(ZegoConstans.LIB_NAME, EntryPoint = "zego_express_fetch_custom_audio_render_pcm_data", CallingConvention = ZegoConstans.ZEGO_CALINGCONVENTION)]
        public static extern int zego_express_fetch_custom_audio_render_pcm_data(byte[] data, uint data_length, zego_audio_frame_param param);


        [UnmanagedFunctionPointer(ZegoConstans.ZEGO_CALINGCONVENTION)]
        public delegate void zego_on_playback_audio_data(IntPtr data, uint data_length, zego_audio_frame_param param, System.IntPtr user_context);


        [DllImportAttribute(ZegoConstans.LIB_NAME, EntryPoint = "zego_register_playback_audio_data_callback", CallingConvention = ZegoConstans.ZEGO_CALINGCONVENTION)]
        public static extern void zego_register_playback_audio_data_callback(zego_on_playback_audio_data callback_func, System.IntPtr user_context);
    }
}
