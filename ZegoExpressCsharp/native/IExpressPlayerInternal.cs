using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
namespace ZEGO
{
    public class IExpressPlayerInternal
    {
        [UnmanagedFunctionPointer(ZegoConstans.ZEGO_CALINGCONVENTION)]
        public delegate void zego_on_player_state_update([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string stream_id, ZegoPlayerState state, int error_code, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string extended_data, System.IntPtr user_context);
        [UnmanagedFunctionPointer(ZegoConstans.ZEGO_CALINGCONVENTION)]
        public delegate void zego_on_player_quality_update([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string stream_id, zego_play_stream_quality quality, System.IntPtr user_context);
        [UnmanagedFunctionPointer(ZegoConstans.ZEGO_CALINGCONVENTION)]
        public delegate void zego_on_player_media_event([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string stream_id, ZegoPlayerMediaEvent media_event, System.IntPtr user_context);
        [UnmanagedFunctionPointer(ZegoConstans.ZEGO_CALINGCONVENTION)]
        public delegate void zego_on_player_recv_audio_first_frame([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string stream_id, System.IntPtr user_context);
        [UnmanagedFunctionPointer(ZegoConstans.ZEGO_CALINGCONVENTION)]
        public delegate void zego_on_player_recv_video_first_frame([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string stream_id, System.IntPtr user_context);
        [UnmanagedFunctionPointer(ZegoConstans.ZEGO_CALINGCONVENTION)]
        public delegate void zego_on_player_render_video_first_frame([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string stream_id, System.IntPtr user_context);
        [UnmanagedFunctionPointer(ZegoConstans.ZEGO_CALINGCONVENTION)]
        public delegate void zego_on_player_video_size_changed([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string stream_id, int width, int height, System.IntPtr user_context);
        [UnmanagedFunctionPointer(ZegoConstans.ZEGO_CALINGCONVENTION)]
        public delegate void zego_on_player_recv_sei([System.Runtime.InteropServices.InAttribute()] [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string stream_id, System.IntPtr data, uint data_length, System.IntPtr user_context);
        [DllImportAttribute(ZegoConstans.LIB_NAME, EntryPoint = "zego_express_start_playing_stream", CallingConvention = ZegoConstans.ZEGO_CALINGCONVENTION)]
        public static extern int zego_express_start_playing_stream([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string stream_id, System.IntPtr canvas);
        [DllImportAttribute(ZegoConstans.LIB_NAME, EntryPoint = "zego_express_start_playing_stream_with_config", CallingConvention = ZegoConstans.ZEGO_CALINGCONVENTION)]
        public static extern int zego_express_start_playing_stream_with_config([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string stream_id, System.IntPtr canvas, zego_player_config config);



        [DllImportAttribute(ZegoConstans.LIB_NAME, EntryPoint = "zego_express_stop_playing_stream", CallingConvention = ZegoConstans.ZEGO_CALINGCONVENTION)]
        public static extern int zego_express_stop_playing_stream([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string stream_id);

        [DllImportAttribute(ZegoConstans.LIB_NAME, EntryPoint = "zego_register_player_state_update_callback", CallingConvention = ZegoConstans.ZEGO_CALINGCONVENTION)]
        public static extern void zego_register_player_state_update_callback(zego_on_player_state_update callback_func, System.IntPtr user_context);
        [DllImportAttribute(ZegoConstans.LIB_NAME, EntryPoint = "zego_express_set_play_volume", CallingConvention = ZegoConstans.ZEGO_CALINGCONVENTION)]
        public static extern int zego_express_set_play_volume([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string stream_id, int volume);
        [DllImportAttribute(ZegoConstans.LIB_NAME, EntryPoint = "zego_express_mute_play_stream_audio", CallingConvention = ZegoConstans.ZEGO_CALINGCONVENTION)]
        public static extern int zego_express_mute_play_stream_audio([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string stream_id, bool mute);
        [DllImportAttribute(ZegoConstans.LIB_NAME, EntryPoint = "zego_express_mute_play_stream_video", CallingConvention = ZegoConstans.ZEGO_CALINGCONVENTION)]
        public static extern int zego_express_mute_play_stream_video([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string stream_id, bool mute);
        [DllImportAttribute(ZegoConstans.LIB_NAME, EntryPoint = "zego_express_enable_hardware_decoder", CallingConvention = ZegoConstans.ZEGO_CALINGCONVENTION)]
        public static extern int zego_express_enable_hardware_decoder(bool enable);
        [DllImportAttribute(ZegoConstans.LIB_NAME, EntryPoint = "zego_express_enable_check_poc", CallingConvention = ZegoConstans.ZEGO_CALINGCONVENTION)]
        public static extern int zego_express_enable_check_poc(bool enable);
        [DllImportAttribute(ZegoConstans.LIB_NAME, EntryPoint = "zego_register_player_quality_update_callback", CallingConvention = ZegoConstans.ZEGO_CALINGCONVENTION)]
        public static extern void zego_register_player_quality_update_callback(zego_on_player_quality_update callback_func, System.IntPtr user_context);
        [DllImportAttribute(ZegoConstans.LIB_NAME, EntryPoint = "zego_register_player_media_event_callback", CallingConvention = ZegoConstans.ZEGO_CALINGCONVENTION)]
        public static extern void zego_register_player_media_event_callback(zego_on_player_media_event callback_func, System.IntPtr user_context);
        [DllImportAttribute(ZegoConstans.LIB_NAME, EntryPoint = "zego_register_player_recv_audio_first_frame_callback", CallingConvention = ZegoConstans.ZEGO_CALINGCONVENTION)]
        public static extern void zego_register_player_recv_audio_first_frame_callback(zego_on_player_recv_audio_first_frame callback_func, System.IntPtr user_context);
        [DllImportAttribute(ZegoConstans.LIB_NAME, EntryPoint = "zego_register_player_recv_video_first_frame_callback", CallingConvention = ZegoConstans.ZEGO_CALINGCONVENTION)]
        public static extern void zego_register_player_recv_video_first_frame_callback(zego_on_player_recv_video_first_frame callback_func, System.IntPtr user_context);
        [DllImportAttribute(ZegoConstans.LIB_NAME, EntryPoint = "zego_register_player_render_video_first_frame_callback", CallingConvention = ZegoConstans.ZEGO_CALINGCONVENTION)]
        public static extern void zego_register_player_render_video_first_frame_callback(zego_on_player_render_video_first_frame callback_func, System.IntPtr user_context);
        [DllImportAttribute(ZegoConstans.LIB_NAME, EntryPoint = "zego_register_player_video_size_changed_callback", CallingConvention = ZegoConstans.ZEGO_CALINGCONVENTION)]
        public static extern void zego_register_player_video_size_changed_callback(zego_on_player_video_size_changed callback_func, System.IntPtr user_context);
        /// Return Type: void
        ///callback_func: zego_on_player_recv_sei
        ///user_context: void*
        [DllImportAttribute(ZegoConstans.LIB_NAME, EntryPoint = "zego_register_player_recv_sei_callback", CallingConvention = ZegoConstans.ZEGO_CALINGCONVENTION)]
        public static extern void zego_register_player_recv_sei_callback(zego_on_player_recv_sei callback_func, System.IntPtr user_context);

    }
}

