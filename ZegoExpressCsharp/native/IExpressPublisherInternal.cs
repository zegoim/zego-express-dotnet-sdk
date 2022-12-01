
using System;
using System.Runtime.InteropServices;

namespace ZEGO
{
    public class IExpressPublisherInternal
    {
        [UnmanagedFunctionPointer(ZegoConstans.ZEGO_CALLINGCONVENTION)]
        public delegate void zego_on_publisher_state_update([In()] [MarshalAs(UnmanagedType.LPStr)] string stream_id, ZegoPublisherState state, int error_code, [In()][MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(ZegoUtil.UTF8StringMarshaler))] string extended_data, IntPtr user_context);


        [UnmanagedFunctionPointer(ZegoConstans.ZEGO_CALLINGCONVENTION)]
        public delegate void zego_on_publisher_quality_update([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string stream_id, zego_publish_stream_quality quality, System.IntPtr user_context);

        [UnmanagedFunctionPointer(ZegoConstans.ZEGO_CALLINGCONVENTION)]
        public delegate void zego_on_publisher_captured_audio_first_frame(System.IntPtr user_context);


        [UnmanagedFunctionPointer(ZegoConstans.ZEGO_CALLINGCONVENTION)]
        public delegate void zego_on_publisher_captured_video_first_frame(ZegoPublishChannel channel, System.IntPtr user_context);

        [UnmanagedFunctionPointer(ZegoConstans.ZEGO_CALLINGCONVENTION)]
        public delegate void zego_on_publisher_video_size_changed(int width, int height, ZegoPublishChannel channel, System.IntPtr user_context);

        /// Return Type: void
        ///stream_id: char*
        ///error_code: int
        ///seq: int
        ///user_context: void*
        [UnmanagedFunctionPointer(ZegoConstans.ZEGO_CALLINGCONVENTION)]
        public delegate void zego_on_publisher_update_cdn_url_result([In()] [MarshalAs(UnmanagedType.LPStr)] string stream_id, int error_code, int seq, IntPtr user_context);


        /// Return Type: void
        ///error_code: int
        ///seq: int
        ///user_context: void*
        [UnmanagedFunctionPointer(ZegoConstans.ZEGO_CALLINGCONVENTION)]
        public delegate void zego_on_publisher_update_stream_extra_info_result(int error_code, int seq, IntPtr user_context);

        /// Return Type: void
        ///stream_id: char*
        ///cdn_info_list: zego_stream_relay_cdn_info*
        ///info_count: unsigned int
        ///user_context: void*
        [UnmanagedFunctionPointer(ZegoConstans.ZEGO_CALLINGCONVENTION)]
        public delegate void zego_on_publisher_relay_cdn_state_update([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string stream_id, IntPtr cdn_info_list, uint info_count, System.IntPtr user_context);


        [DllImportAttribute(ZegoConstans.LIB_NAME, EntryPoint = "zego_express_start_publishing_stream", CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
        public static extern int zego_express_start_publishing_stream([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string stream_id, ZegoPublishChannel channel);

        [DllImport(ZegoConstans.LIB_NAME, EntryPoint = "zego_express_start_publishing_stream_with_config", CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
        public static extern int zego_express_start_publishing_stream_with_config([In()][MarshalAs(UnmanagedType.LPStr)] string stream_id, zego_publisher_config config, ZegoPublishChannel channel);


        [DllImportAttribute(ZegoConstans.LIB_NAME, EntryPoint = "zego_express_stop_publishing_stream", CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
        public static extern int zego_express_stop_publishing_stream(ZegoPublishChannel channel);



        [DllImportAttribute(ZegoConstans.LIB_NAME, EntryPoint = "zego_register_publisher_state_update_callback", CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
        public static extern int zego_register_publisher_state_update_callback(zego_on_publisher_state_update callback_func, System.IntPtr user_context);


        [DllImportAttribute(ZegoConstans.LIB_NAME, EntryPoint = "zego_express_start_preview", CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
        public static extern int zego_express_start_preview(System.IntPtr canvas, ZegoPublishChannel channel);
        [DllImportAttribute(ZegoConstans.LIB_NAME, EntryPoint = "zego_express_stop_preview", CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
        public static extern int zego_express_stop_preview(ZegoPublishChannel channel);


        [DllImportAttribute(ZegoConstans.LIB_NAME, EntryPoint = "zego_express_set_app_orientation", CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
        public static extern int zego_express_set_app_orientation(ZegoOrientation orientation, ZegoPublishChannel channel);



        /// Return Type: int
        ///video_config: zego_video_config
        ///channel: zego_publish_channel
        [System.Runtime.InteropServices.DllImportAttribute(ZegoConstans.LIB_NAME, EntryPoint = "zego_express_set_video_config", CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
        public static extern int zego_express_set_video_config(zego_video_config video_config, ZegoPublishChannel channel);


        /// Return Type: int
        ///mirror_mode: zego_video_mirror_mode
        ///channel: zego_publish_channel
        [System.Runtime.InteropServices.DllImportAttribute(ZegoConstans.LIB_NAME, EntryPoint = "zego_express_set_video_mirror_mode", CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
        public static extern int zego_express_set_video_mirror_mode(ZegoVideoMirrorMode mirror_mode, ZegoPublishChannel channel);


        /// Return Type: int
        ///audio_config: zego_audio_config
        [System.Runtime.InteropServices.DllImportAttribute(ZegoConstans.LIB_NAME, EntryPoint = "zego_express_set_audio_config", CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
        public static extern int zego_express_set_audio_config(zego_audio_config audio_config);

        /// Return Type: int
        ///audio_config: zego_audio_config
        ///chanel: zego_publish_channel
        [System.Runtime.InteropServices.DllImportAttribute(ZegoConstans.LIB_NAME, EntryPoint = "zego_express_set_audio_config_by_channel", CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
        public static extern int zego_express_set_audio_config_by_channel(zego_audio_config audio_config, ZegoPublishChannel channel);


        /// Return Type: int
        ///mute: boolean
        ///channel: zego_publish_channel
        [System.Runtime.InteropServices.DllImportAttribute(ZegoConstans.LIB_NAME, EntryPoint = "zego_express_mute_publish_stream_audio", CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
        public static extern int zego_express_mute_publish_stream_audio([System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.I1)] bool mute, ZegoPublishChannel channel);


        /// Return Type: int
        ///mute: boolean
        ///channel: zego_publish_channel
        [System.Runtime.InteropServices.DllImportAttribute(ZegoConstans.LIB_NAME, EntryPoint = "zego_express_mute_publish_stream_video", CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
        public static extern int zego_express_mute_publish_stream_video([System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.I1)] bool mute, ZegoPublishChannel channel);


        /// Return Type: int
        ///enable: boolean
        ///property: int
        [System.Runtime.InteropServices.DllImportAttribute(ZegoConstans.LIB_NAME, EntryPoint = "zego_express_enable_traffic_control", CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
        public static extern int zego_express_enable_traffic_control([System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.I1)] bool enable, int property);


        /// Return Type: int
        ///bitrate: int
        ///mode: zego_traffic_control_min_video_bitrate_mode
        [System.Runtime.InteropServices.DllImportAttribute(ZegoConstans.LIB_NAME, EntryPoint = "zego_express_set_min_video_bitrate_for_traffic_control", CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
        public static extern int zego_express_set_min_video_bitrate_for_traffic_control(int bitrate, ZegoTrafficControlMinVideoBitrateMode mode);


        /// Return Type: int
        ///volume: int
        [System.Runtime.InteropServices.DllImportAttribute(ZegoConstans.LIB_NAME, EntryPoint = "zego_express_set_capture_volume", CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
        public static extern int zego_express_set_capture_volume(int volume);


        /// Return Type: int
        ///enable: boolean
        [System.Runtime.InteropServices.DllImportAttribute(ZegoConstans.LIB_NAME, EntryPoint = "zego_express_enable_hardware_encoder", CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
        public static extern int zego_express_enable_hardware_encoder([System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.I1)] bool enable);


        /// Return Type: void
        ///callback_func: zego_on_publisher_quality_update
        ///user_context: void*
        [System.Runtime.InteropServices.DllImportAttribute(ZegoConstans.LIB_NAME, EntryPoint = "zego_register_publisher_quality_update_callback", CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
        public static extern void zego_register_publisher_quality_update_callback(zego_on_publisher_quality_update callback_func, System.IntPtr user_context);


        /// Return Type: void
        ///callback_func: zego_on_publisher_recv_audio_captured_first_frame
        ///user_context: void*
        [System.Runtime.InteropServices.DllImportAttribute(ZegoConstans.LIB_NAME, EntryPoint = "zego_register_publisher_captured_audio_first_frame_callback", CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
        public static extern void zego_register_publisher_captured_audio_first_frame_callback(zego_on_publisher_captured_audio_first_frame callback_func, System.IntPtr user_context);


        /// Return Type: void
        ///callback_func: zego_on_publisher_recv_video_captured_first_frame
        ///user_context: void*
        [System.Runtime.InteropServices.DllImportAttribute(ZegoConstans.LIB_NAME, EntryPoint = "zego_register_publisher_captured_video_first_frame_callback", CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
        public static extern void zego_register_publisher_captured_video_first_frame_callback(zego_on_publisher_captured_video_first_frame callback_func, System.IntPtr user_context);


        /// Return Type: void
        ///callback_func: zego_on_publisher_video_size_changed
        ///user_context: void*
        [System.Runtime.InteropServices.DllImportAttribute(ZegoConstans.LIB_NAME, EntryPoint = "zego_register_publisher_video_size_changed_callback", CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
        public static extern void zego_register_publisher_video_size_changed_callback(zego_on_publisher_video_size_changed callback_func, System.IntPtr user_context);

        [System.Runtime.InteropServices.DllImportAttribute(ZegoConstans.LIB_NAME, EntryPoint = "zego_express_set_capture_pipeline_scale_mode", CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
        public static extern int zego_express_set_capture_pipeline_scale_mode(ZegoCapturePipelineScaleMode mode);
        [System.Runtime.InteropServices.DllImportAttribute(ZegoConstans.LIB_NAME, EntryPoint = "zego_express_enable_publish_direct_to_cdn", CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
        public static extern int zego_express_enable_publish_direct_to_cdn([MarshalAs(UnmanagedType.I1)]bool enable, IntPtr config, ZegoPublishChannel channel);


        /// Return Type: int
        ///stream_id: char*
        ///target_url: char*
        [DllImport(ZegoConstans.LIB_NAME, EntryPoint = "zego_express_add_publish_cdn_url", CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
        public static extern int zego_express_add_publish_cdn_url([In()] [MarshalAs(UnmanagedType.LPStr)] string stream_id, [In()] [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(ZegoUtil.UTF8StringMarshaler))] string target_url);


        /// Return Type: int
        ///stream_id: char*
        ///target_url: char*
        [DllImport(ZegoConstans.LIB_NAME, EntryPoint = "zego_express_remove_publish_cdn_url", CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
        public static extern int zego_express_remove_publish_cdn_url([In()] [MarshalAs(UnmanagedType.LPStr)] string stream_id, [In()][MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(ZegoUtil.UTF8StringMarshaler))] string target_url);


        /// Return Type: void
        ///callback_func: zego_on_publisher_update_cdn_url_result
        ///user_context: void*
        [DllImport(ZegoConstans.LIB_NAME, EntryPoint = "zego_register_publisher_update_cdn_url_result_callback", CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
        public static extern void zego_register_publisher_update_cdn_url_result_callback(zego_on_publisher_update_cdn_url_result callback_func, IntPtr user_context);


        /// Return Type: void
        ///callback_func: zego_on_publisher_relay_cdn_state_update
        ///user_context: void*
        [System.Runtime.InteropServices.DllImportAttribute(ZegoConstans.LIB_NAME, EntryPoint = "zego_register_publisher_relay_cdn_state_update_callback", CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
        public static extern void zego_register_publisher_relay_cdn_state_update_callback(zego_on_publisher_relay_cdn_state_update callback_func, System.IntPtr user_context);


        /// Return Type: int
        ///data: char*
        ///data_length: unsigned int
        ///channel: zego_publish_channel
        [System.Runtime.InteropServices.DllImportAttribute(ZegoConstans.LIB_NAME, EntryPoint = "zego_express_send_sei", CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
        public static extern int zego_express_send_sei(System.IntPtr data, uint data_length, ZegoPublishChannel channel);

        /// Return Type: int
        ///is_preview_visible: boolean
        ///watermark: zego_watermark*
        ///channel: zego_publish_channel
        [DllImportAttribute(ZegoConstans.LIB_NAME, EntryPoint = "zego_express_set_publish_watermark", CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
        public static extern int zego_express_set_publish_watermark([System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.I1)] bool is_preview_visible, System.IntPtr watermark, ZegoPublishChannel channel);

        /// Return Type: int
        ///extra_info: char*
        ///channel: zego_publish_channel
        [DllImport(ZegoConstans.LIB_NAME, EntryPoint = "zego_express_set_stream_extra_info", CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
        public static extern int zego_express_set_stream_extra_info([In()] [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(ZegoUtil.UTF8StringMarshaler))] string extra_info, ZegoPublishChannel channel);


        /// Return Type: void
        ///callback_func: zego_on_publisher_update_stream_extra_info_result
        ///user_context: void*
        [DllImport(ZegoConstans.LIB_NAME, EntryPoint = "zego_register_publisher_update_stream_extra_info_result_callback", CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
        public static extern void zego_register_publisher_update_stream_extra_info_result_callback(zego_on_publisher_update_stream_extra_info_result callback_func, IntPtr user_context);

        [DllImport(ZegoConstans.LIB_NAME, EntryPoint = "zego_express_set_audio_capture_stereo_mode", CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
        public static extern int zego_express_set_audio_capture_stereo_mode(ZegoAudioCaptureStereoMode mode);

        [DllImport(ZegoConstans.LIB_NAME, EntryPoint = "zego_express_get_audio_config", CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
        public static extern zego_audio_config zego_express_get_audio_config();

        [DllImport(ZegoConstans.LIB_NAME, EntryPoint = "zego_express_get_video_config", CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
        public static extern zego_video_config zego_express_get_video_config(ZegoPublishChannel channel);


        [UnmanagedFunctionPointer(ZegoConstans.ZEGO_CALLINGCONVENTION)]
        public delegate void zego_on_publisher_render_video_first_frame(ZegoPublishChannel channel, System.IntPtr user_context);


        [DllImport(ZegoConstans.LIB_NAME, EntryPoint = "zego_register_publisher_render_video_first_frame_callback", CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
        public static extern void zego_register_publisher_render_video_first_frame_callback(zego_on_publisher_render_video_first_frame callback_func, System.IntPtr user_context);


        [DllImport(ZegoConstans.LIB_NAME, EntryPoint = "zego_express_take_publish_stream_snapshot", CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
        public static extern int zego_express_take_publish_stream_snapshot(ZegoPublishChannel channel);


        
        [UnmanagedFunctionPointer(ZegoConstans.ZEGO_CALLINGCONVENTION)]
        public delegate void zego_on_publisher_take_snapshot_result(int error_code, ZegoPublishChannel channel, System.IntPtr image, System.IntPtr user_context);


        [DllImport(ZegoConstans.LIB_NAME, EntryPoint = "zego_register_publisher_take_snapshot_result_callback", CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
        public static extern void zego_register_publisher_take_snapshot_result_callback(zego_on_publisher_take_snapshot_result callback_func, System.IntPtr user_context);


        [DllImport(ZegoConstans.LIB_NAME, EntryPoint = "zego_express_enable_virtual_stereo", CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
        public static extern int zego_express_enable_virtual_stereo([MarshalAs(UnmanagedType.I1)]bool enable, int angle);


        [DllImport(ZegoConstans.LIB_NAME, EntryPoint = "zego_express_enable_play_stream_virtual_stereo", CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
        public static extern int zego_express_enable_play_stream_virtual_stereo([MarshalAs(UnmanagedType.I1)]bool enable, int angle, [In()] [MarshalAs(UnmanagedType.LPStr)] string stream_id);


        [DllImport(ZegoConstans.LIB_NAME, EntryPoint = "zego_express_set_voice_changer_preset", CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
        public static extern int zego_express_set_voice_changer_preset(ZegoVoiceChangerPreset preset);


        [DllImport(ZegoConstans.LIB_NAME, EntryPoint = "zego_express_set_voice_changer_param", CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
        public static extern int zego_express_set_voice_changer_param(float _param);


        [DllImport(ZegoConstans.LIB_NAME, EntryPoint = "zego_express_set_reverb_preset", CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
        public static extern int zego_express_set_reverb_preset(ZegoReverbPreset preset);


        [DllImport(ZegoConstans.LIB_NAME, EntryPoint = "zego_express_set_reverb_advanced_param", CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
        public static extern int zego_express_set_reverb_advanced_param(zego_reverb_advanced_param _param);


        [DllImport(ZegoConstans.LIB_NAME, EntryPoint = "zego_express_set_reverb_echo_param", CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
        public static extern int zego_express_set_reverb_echo_param(zego_reverb_echo_param _param);


        [DllImport(ZegoConstans.LIB_NAME, EntryPoint = "zego_express_set_stream_alignment_property", CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
        public static extern int zego_express_set_stream_alignment_property(int alignment, ZegoPublishChannel channel);


        [DllImport(ZegoConstans.LIB_NAME, EntryPoint = "zego_express_set_traffic_control_focus_on_by_channel", CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
        public static extern int zego_express_set_traffic_control_focus_on_by_channel(ZegoTrafficControlFocusOnMode mode, ZegoPublishChannel channel);
    }
}