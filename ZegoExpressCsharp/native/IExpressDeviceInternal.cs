using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
namespace ZEGO
{
    public class IExpressDeviceInternal
    {
        [UnmanagedFunctionPointer(ZegoConstans.ZEGO_CALINGCONVENTION)]
        public delegate void zego_on_remote_sound_level_update(System.IntPtr sound_level_info_list, uint info_count, System.IntPtr user_context);


        [UnmanagedFunctionPointer(ZegoConstans.ZEGO_CALINGCONVENTION)]
        public delegate void zego_on_captured_sound_level_update(System.IntPtr sound_level_info, System.IntPtr user_context);



        [UnmanagedFunctionPointer(ZegoConstans.ZEGO_CALINGCONVENTION)]
        public delegate void zego_on_captured_audio_spectrum_update(System.IntPtr audio_spectrum_info, System.IntPtr user_context);

        [UnmanagedFunctionPointer(ZegoConstans.ZEGO_CALINGCONVENTION)]
        public delegate void zego_on_remote_audio_spectrum_update(System.IntPtr audio_spectrum_info_list, uint info_count, System.IntPtr user_context);

        [DllImportAttribute(ZegoConstans.LIB_NAME, EntryPoint = "zego_express_use_front_camera", CallingConvention = ZegoConstans.ZEGO_CALINGCONVENTION)]
        public static extern int zego_express_use_front_camera(bool enable, ZegoPublishChannel channel);



        /// Return Type: int
        [DllImportAttribute(ZegoConstans.LIB_NAME, EntryPoint = "zego_express_start_sound_level_monitor", CallingConvention = ZegoConstans.ZEGO_CALINGCONVENTION)]
        public static extern int zego_express_start_sound_level_monitor();


        /// Return Type: int
        [DllImportAttribute(ZegoConstans.LIB_NAME, EntryPoint = "zego_express_stop_sound_level_monitor", CallingConvention = ZegoConstans.ZEGO_CALINGCONVENTION)]
        public static extern int zego_express_stop_sound_level_monitor();


        /// Return Type: int
        [DllImportAttribute(ZegoConstans.LIB_NAME, EntryPoint = "zego_express_start_audio_spectrum_monitor", CallingConvention = ZegoConstans.ZEGO_CALINGCONVENTION)]
        public static extern int zego_express_start_audio_spectrum_monitor();


        /// Return Type: int
        [DllImportAttribute(ZegoConstans.LIB_NAME, EntryPoint = "zego_express_stop_audio_spectrum_monitor", CallingConvention = ZegoConstans.ZEGO_CALINGCONVENTION)]
        public static extern int zego_express_stop_audio_spectrum_monitor();


        /// Return Type: void
        ///callback_func: zego_on_captured_sound_level_update
        ///user_context: void*
        [DllImportAttribute(ZegoConstans.LIB_NAME, EntryPoint = "zego_register_captured_sound_level_update_callback", CallingConvention = ZegoConstans.ZEGO_CALINGCONVENTION)]
        public static extern void zego_register_captured_sound_level_update_callback(zego_on_captured_sound_level_update callback_func, System.IntPtr user_context);


        /// Return Type: void
        ///callback_func: zego_on_remote_sound_level_update
        ///user_context: void*
        [DllImportAttribute(ZegoConstans.LIB_NAME, EntryPoint = "zego_register_remote_sound_level_update_callback", CallingConvention = ZegoConstans.ZEGO_CALINGCONVENTION)]
        public static extern void zego_register_remote_sound_level_update_callback(zego_on_remote_sound_level_update callback_func, System.IntPtr user_context);


        /// Return Type: void
        ///callback_func: zego_on_captured_audio_spectrum_update
        ///user_context: void*
        [DllImportAttribute(ZegoConstans.LIB_NAME, EntryPoint = "zego_register_captured_audio_spectrum_update_callback", CallingConvention = ZegoConstans.ZEGO_CALINGCONVENTION)]
        public static extern void zego_register_captured_audio_spectrum_update_callback(zego_on_captured_audio_spectrum_update callback_func, System.IntPtr user_context);


        /// Return Type: void
        ///callback_func: zego_on_remote_audio_spectrum_update
        ///user_context: void*
        [DllImportAttribute(ZegoConstans.LIB_NAME, EntryPoint = "zego_register_remote_audio_spectrum_update_callback", CallingConvention = ZegoConstans.ZEGO_CALINGCONVENTION)]
        public static extern void zego_register_remote_audio_spectrum_update_callback(zego_on_remote_audio_spectrum_update callback_func, System.IntPtr user_context);

        [DllImportAttribute(ZegoConstans.LIB_NAME, EntryPoint = "zego_express_enable_camera", CallingConvention = ZegoConstans.ZEGO_CALINGCONVENTION)]
        public static extern int zego_express_enable_camera(bool enable, ZegoPublishChannel channel);

        [DllImportAttribute(ZegoConstans.LIB_NAME, EntryPoint = "zego_express_mute_speaker", CallingConvention = ZegoConstans.ZEGO_CALINGCONVENTION)]
        public static extern int zego_express_mute_speaker(bool mute);

        [DllImportAttribute(ZegoConstans.LIB_NAME, EntryPoint = "zego_express_mute_microphone", CallingConvention = ZegoConstans.ZEGO_CALINGCONVENTION)]
        public static extern int zego_express_mute_microphone(bool mute);



        [DllImportAttribute(ZegoConstans.LIB_NAME, EntryPoint = "zego_express_get_audio_device_list", CallingConvention = ZegoConstans.ZEGO_CALINGCONVENTION)]
        public static extern System.IntPtr zego_express_get_audio_device_list(ZegoAudioDeviceType device_type, ref int device_count);


        /// Return Type: zego_device_info*
        ///device_count: int*
        [DllImportAttribute(ZegoConstans.LIB_NAME, EntryPoint = "zego_express_get_video_device_list", CallingConvention = ZegoConstans.ZEGO_CALINGCONVENTION)]
        public static extern System.IntPtr zego_express_get_video_device_list(ref int device_count);


        /// Return Type: int
        ///device_id: char*
        ///channel: zego_publish_channel
        [DllImportAttribute(ZegoConstans.LIB_NAME, EntryPoint = "zego_express_use_video_device", CallingConvention = ZegoConstans.ZEGO_CALINGCONVENTION)]
        public static extern int zego_express_use_video_device([System.Runtime.InteropServices.InAttribute()] [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(ZegoUtil.UTF8StringMarshaler))] string device_id, ZegoPublishChannel channel);


        /// Return Type: int
        ///device_type: zego_audio_device_type
        ///device_id: char*
        [DllImportAttribute(ZegoConstans.LIB_NAME, EntryPoint = "zego_express_use_audio_device", CallingConvention = ZegoConstans.ZEGO_CALINGCONVENTION)]
        public static extern int zego_express_use_audio_device(ZegoAudioDeviceType device_type, [System.Runtime.InteropServices.InAttribute()] [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(ZegoUtil.UTF8StringMarshaler))] string device_id);
    }
}
