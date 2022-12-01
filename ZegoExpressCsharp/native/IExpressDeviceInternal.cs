using System;
using System.Runtime.InteropServices;
//using UnityEngine;
namespace ZEGO
{
    public class IExpressDeviceInternal
    {
        [UnmanagedFunctionPointer(ZegoConstans.ZEGO_CALLINGCONVENTION)]
        public delegate void zego_on_remote_sound_level_update(System.IntPtr sound_level_info_list, uint info_count, System.IntPtr user_context);


        [UnmanagedFunctionPointer(ZegoConstans.ZEGO_CALLINGCONVENTION)]
        public delegate void zego_on_captured_sound_level_update(System.IntPtr sound_level_info, System.IntPtr user_context);



        [UnmanagedFunctionPointer(ZegoConstans.ZEGO_CALLINGCONVENTION)]
        public delegate void zego_on_captured_audio_spectrum_update(System.IntPtr audio_spectrum_info, System.IntPtr user_context);

        [UnmanagedFunctionPointer(ZegoConstans.ZEGO_CALLINGCONVENTION)]
        public delegate void zego_on_remote_audio_spectrum_update(System.IntPtr audio_spectrum_info_list, uint info_count, System.IntPtr user_context);

        [DllImportAttribute(ZegoConstans.LIB_NAME, EntryPoint = "zego_express_use_front_camera", CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
        public static extern int zego_express_use_front_camera(bool enable, ZegoPublishChannel channel);



        /// Return Type: int
        [DllImportAttribute(ZegoConstans.LIB_NAME, EntryPoint = "zego_express_start_sound_level_monitor", CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
        public static extern int zego_express_start_sound_level_monitor(uint milliSecond);

        [DllImportAttribute(ZegoConstans.LIB_NAME, EntryPoint = "zego_express_start_sound_level_monitor_with_config", CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
        public static extern int zego_express_start_sound_level_monitor_with_config(zego_sound_level_config sound_level_config);
        

        /// Return Type: int
        [DllImportAttribute(ZegoConstans.LIB_NAME, EntryPoint = "zego_express_stop_sound_level_monitor", CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
        public static extern int zego_express_stop_sound_level_monitor();


        /// Return Type: int
        [DllImportAttribute(ZegoConstans.LIB_NAME, EntryPoint = "zego_express_start_audio_spectrum_monitor", CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
        public static extern int zego_express_start_audio_spectrum_monitor(uint milliSecond);


        /// Return Type: int
        [DllImportAttribute(ZegoConstans.LIB_NAME, EntryPoint = "zego_express_stop_audio_spectrum_monitor", CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
        public static extern int zego_express_stop_audio_spectrum_monitor();


        /// Return Type: void
        ///callback_func: zego_on_captured_sound_level_update
        ///user_context: void*
        [DllImportAttribute(ZegoConstans.LIB_NAME, EntryPoint = "zego_register_captured_sound_level_update_callback", CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
        public static extern void zego_register_captured_sound_level_update_callback(zego_on_captured_sound_level_update callback_func, System.IntPtr user_context);


        /// Return Type: void
        ///callback_func: zego_on_remote_sound_level_update
        ///user_context: void*
        [DllImportAttribute(ZegoConstans.LIB_NAME, EntryPoint = "zego_register_remote_sound_level_update_callback", CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
        public static extern void zego_register_remote_sound_level_update_callback(zego_on_remote_sound_level_update callback_func, System.IntPtr user_context);


        /// Return Type: void
        ///callback_func: zego_on_captured_audio_spectrum_update
        ///user_context: void*
        [DllImportAttribute(ZegoConstans.LIB_NAME, EntryPoint = "zego_register_captured_audio_spectrum_update_callback", CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
        public static extern void zego_register_captured_audio_spectrum_update_callback(zego_on_captured_audio_spectrum_update callback_func, System.IntPtr user_context);


        /// Return Type: void
        ///callback_func: zego_on_remote_audio_spectrum_update
        ///user_context: void*
        [DllImportAttribute(ZegoConstans.LIB_NAME, EntryPoint = "zego_register_remote_audio_spectrum_update_callback", CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
        public static extern void zego_register_remote_audio_spectrum_update_callback(zego_on_remote_audio_spectrum_update callback_func, System.IntPtr user_context);

        [DllImportAttribute(ZegoConstans.LIB_NAME, EntryPoint = "zego_express_enable_camera", CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
        public static extern int zego_express_enable_camera(bool enable, ZegoPublishChannel channel);

        [DllImportAttribute(ZegoConstans.LIB_NAME, EntryPoint = "zego_express_mute_speaker", CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
        public static extern int zego_express_mute_speaker(bool mute);

        [DllImportAttribute(ZegoConstans.LIB_NAME, EntryPoint = "zego_express_mute_microphone", CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
        public static extern int zego_express_mute_microphone(bool mute);



        [DllImportAttribute(ZegoConstans.LIB_NAME, EntryPoint = "zego_express_get_audio_device_list", CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
        public static extern System.IntPtr zego_express_get_audio_device_list(ZegoAudioDeviceType device_type, ref int device_count);


        /// Return Type: zego_device_info*
        ///device_count: int*
        [DllImportAttribute(ZegoConstans.LIB_NAME, EntryPoint = "zego_express_get_video_device_list", CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
        public static extern System.IntPtr zego_express_get_video_device_list(ref int device_count);


        /// Return Type: int
        ///device_id: char*
        ///channel: zego_publish_channel
        [DllImport(ZegoConstans.LIB_NAME, EntryPoint = "zego_express_use_video_device", CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
        public static extern int zego_express_use_video_device([In()] [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(ZegoUtil.UTF8StringMarshaler))] string device_id, ZegoPublishChannel channel);


        /// Return Type: int
        ///device_type: zego_audio_device_type
        ///device_id: char*
        [DllImport(ZegoConstans.LIB_NAME, EntryPoint = "zego_express_use_audio_device", CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
        public static extern int zego_express_use_audio_device(ZegoAudioDeviceType device_type, [In()] [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(ZegoUtil.UTF8StringMarshaler))] string device_id);



        /// Return Type: boolean
        [DllImportAttribute(ZegoConstans.LIB_NAME, EntryPoint = "zego_express_is_microphone_muted", CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool zego_express_is_microphone_muted();


        /// Return Type: boolean
        [DllImportAttribute(ZegoConstans.LIB_NAME, EntryPoint = "zego_express_is_speaker_muted", CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool zego_express_is_speaker_muted();


        [DllImportAttribute(ZegoConstans.LIB_NAME, EntryPoint = "zego_express_enable_audio_capture_device", CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
        public static extern int zego_express_enable_audio_capture_device([MarshalAs(UnmanagedType.I1)] bool enable);


        /// Return Type: int
        ///enable: boolean
        [DllImportAttribute(ZegoConstans.LIB_NAME, EntryPoint = "zego_express_enable_headphone_monitor", CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
        public static extern int zego_express_enable_headphone_monitor([MarshalAs(UnmanagedType.I1)] bool enable);


        /// Return Type: int
        ///volume: int
        [DllImportAttribute(ZegoConstans.LIB_NAME, EntryPoint = "zego_express_set_headphone_monitor_volume", CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
        public static extern int zego_express_set_headphone_monitor_volume(int volume);

        /// Return Type: void
        ///stream_id: char*
        ///state: zego_remote_device_state
        ///user_context: void*
        [UnmanagedFunctionPointer(ZegoConstans.ZEGO_CALLINGCONVENTION)]
        public delegate void zego_on_remote_camera_state_update([In()][MarshalAs(UnmanagedType.LPStr)] string stream_id, ZegoRemoteDeviceState state, IntPtr user_context);

        /// Return Type: void
        ///stream_id: char*
        ///state: zego_remote_device_state
        ///user_context: void*
        [UnmanagedFunctionPointer(ZegoConstans.ZEGO_CALLINGCONVENTION)]
        public delegate void zego_on_remote_mic_state_update([In()][MarshalAs(UnmanagedType.LPStr)] string stream_id, ZegoRemoteDeviceState state, IntPtr user_context);


        /// Return Type: void
        ///callback_func: zego_on_remote_camera_state_update
        ///user_context: void*
        [DllImportAttribute(ZegoConstans.LIB_NAME, EntryPoint = "zego_register_remote_camera_state_update_callback", CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
        public static extern void zego_register_remote_camera_state_update_callback(zego_on_remote_camera_state_update callback_func, System.IntPtr user_context);


        /// Return Type: void
        ///callback_func: zego_on_remote_mic_state_update
        ///user_context: void*
        [DllImportAttribute(ZegoConstans.LIB_NAME, EntryPoint = "zego_register_remote_mic_state_update_callback", CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
        public static extern void zego_register_remote_mic_state_update_callback(zego_on_remote_mic_state_update callback_func, System.IntPtr user_context);


        [UnmanagedFunctionPointer(ZegoConstans.ZEGO_CALLINGCONVENTION)]
        public delegate void zego_on_remote_speaker_state_update([In()][MarshalAs(UnmanagedType.LPStr)] string stream_id, ZegoRemoteDeviceState state, System.IntPtr user_context);


        [DllImport(ZegoConstans.LIB_NAME, EntryPoint = "zego_register_remote_speaker_state_update_callback", CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
        public static extern void zego_register_remote_speaker_state_update_callback(zego_on_remote_speaker_state_update callback_func, System.IntPtr user_context);


        [UnmanagedFunctionPointer(ZegoConstans.ZEGO_CALLINGCONVENTION)]
        public delegate void zego_on_local_device_exception_occurred(ZegoDeviceExceptionType exception_type, ZegoDeviceType device_type, [In()][MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(ZegoUtil.UTF8StringMarshaler))] string device_id, System.IntPtr user_context);


        [DllImport(ZegoConstans.LIB_NAME, EntryPoint = "zego_register_local_device_exception_occurred_callback", CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
        public static extern void zego_register_local_device_exception_occurred_callback(zego_on_local_device_exception_occurred callback_func, System.IntPtr user_context);


        [DllImport(ZegoConstans.LIB_NAME, EntryPoint = "zego_express_get_audio_route_type", CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
        public static extern ZegoAudioRoute zego_express_get_audio_route_type();


        [UnmanagedFunctionPointer(ZegoConstans.ZEGO_CALLINGCONVENTION)]
        public delegate void zego_on_audio_route_change(ZegoAudioRoute audio_route, System.IntPtr user_context);


        [DllImport(ZegoConstans.LIB_NAME, EntryPoint = "zego_register_audio_route_change_callback", CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
        public static extern void zego_register_audio_route_change_callback(zego_on_audio_route_change callback_func, System.IntPtr user_context);


        [DllImport(ZegoConstans.LIB_NAME, EntryPoint = "zego_express_set_audio_route_to_speaker", CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
        public static extern int zego_express_set_audio_route_to_speaker([MarshalAs(UnmanagedType.I1)]bool enable);


        [UnmanagedFunctionPointer(ZegoConstans.ZEGO_CALLINGCONVENTION)]
        public delegate void zego_on_captured_sound_level_info_update(IntPtr sound_level_info, IntPtr user_context);


        [DllImport(ZegoConstans.LIB_NAME, EntryPoint = "zego_register_captured_sound_level_info_update_callback", CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
        public static extern void zego_register_captured_sound_level_info_update_callback(zego_on_captured_sound_level_info_update callback_func, IntPtr user_context);


        [UnmanagedFunctionPointer(ZegoConstans.ZEGO_CALLINGCONVENTION)]
        public delegate void zego_on_remote_sound_level_info_update(IntPtr sound_level_info, uint info_count, IntPtr user_context);


        [DllImport(ZegoConstans.LIB_NAME, EntryPoint = "zego_register_remote_sound_level_info_update_callback", CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
        public static extern void zego_register_remote_sound_level_info_update_callback(zego_on_remote_sound_level_info_update callback_func, IntPtr user_context);
    }
}
