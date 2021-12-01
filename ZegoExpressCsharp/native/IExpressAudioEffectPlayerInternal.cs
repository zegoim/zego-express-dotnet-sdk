using System;
using System.Runtime.InteropServices;
namespace ZEGO
{
    public class IExpressAudioEffectPlayerInternal
    {
        [DllImport(ZegoConstans.LIB_NAME, EntryPoint = "zego_express_create_audio_effect_player", CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
        public static extern ZegoAudioEffectPlayerInstanceIndex zego_express_create_audio_effect_player();


        [DllImport(ZegoConstans.LIB_NAME, EntryPoint = "zego_express_audio_effect_player_start", CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
        public static extern int zego_express_audio_effect_player_start(uint audio_effect_id, [In()] [MarshalAs(UnmanagedType.LPStr)] string path, IntPtr config, ZegoAudioEffectPlayerInstanceIndex instance_index);



        [DllImport(ZegoConstans.LIB_NAME, EntryPoint = "zego_express_audio_effect_player_stop", CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
        public static extern int zego_express_audio_effect_player_stop(uint audio_effect_id, ZegoAudioEffectPlayerInstanceIndex instance_index);


        [DllImport(ZegoConstans.LIB_NAME, EntryPoint = "zego_express_audio_effect_player_stop_all", CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
        public static extern int zego_express_audio_effect_player_stop_all(ZegoAudioEffectPlayerInstanceIndex instance_index);


        [DllImport(ZegoConstans.LIB_NAME, EntryPoint = "zego_express_audio_effect_player_unload_resource", CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
        public static extern int zego_express_audio_effect_player_unload_resource(uint audio_effect_id, ZegoAudioEffectPlayerInstanceIndex instance_index);


        [DllImport(ZegoConstans.LIB_NAME, EntryPoint = "zego_express_audio_effect_player_set_volume_all", CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
        public static extern int zego_express_audio_effect_player_set_volume_all(int volume, ZegoAudioEffectPlayerInstanceIndex instance_index);


        [DllImport(ZegoConstans.LIB_NAME, EntryPoint = "zego_express_audio_effect_player_set_volume", CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
        public static extern int zego_express_audio_effect_player_set_volume(uint audio_effect_id, int volume, ZegoAudioEffectPlayerInstanceIndex instance_index);

        [DllImport(ZegoConstans.LIB_NAME, EntryPoint = "zego_express_audio_effect_player_seek_to", CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
        public static extern int zego_express_audio_effect_player_seek_to(uint audio_effect_id, ulong millisecond, ZegoAudioEffectPlayerInstanceIndex instance_index);


        [UnmanagedFunctionPointer(ZegoConstans.ZEGO_CALLINGCONVENTION)]
        public delegate void zego_on_audio_effect_player_seek_to(int seq, int error_code, ZegoAudioEffectPlayerInstanceIndex instance_index, System.IntPtr user_context);

        [DllImport(ZegoConstans.LIB_NAME, EntryPoint = "zego_register_audio_effect_player_seek_to_callback", CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
        public static extern void zego_register_audio_effect_player_seek_to_callback(zego_on_audio_effect_player_seek_to callback_func, System.IntPtr user_context);


        [DllImport(ZegoConstans.LIB_NAME, EntryPoint = "zego_express_audio_effect_player_load_resource", CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
        public static extern int zego_express_audio_effect_player_load_resource(uint audio_effect_id, [In()] [MarshalAs(UnmanagedType.LPStr)] string path, ZegoAudioEffectPlayerInstanceIndex instance_index);

        [UnmanagedFunctionPointer(ZegoConstans.ZEGO_CALLINGCONVENTION)]
        public delegate void zego_on_audio_effect_player_load_resource(int seq, int error_code, ZegoAudioEffectPlayerInstanceIndex instance_index, System.IntPtr user_context);

        [DllImport(ZegoConstans.LIB_NAME, EntryPoint = "zego_register_audio_effect_player_load_resource_callback", CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
        public static extern void zego_register_audio_effect_player_load_resource_callback(zego_on_audio_effect_player_load_resource callback_func, System.IntPtr user_context);


        [UnmanagedFunctionPointer(ZegoConstans.ZEGO_CALLINGCONVENTION)]
        public delegate void zego_on_audio_effect_play_state_update(uint audio_effect_id, ZegoAudioEffectPlayState state, int error_code, ZegoAudioEffectPlayerInstanceIndex instance_index, System.IntPtr user_context);
        [DllImport(ZegoConstans.LIB_NAME, EntryPoint = "zego_register_audio_effect_play_state_update_callback", CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
        public static extern void zego_register_audio_effect_play_state_update_callback(zego_on_audio_effect_play_state_update callback_func, System.IntPtr user_context);




        [DllImport(ZegoConstans.LIB_NAME, EntryPoint = "zego_express_audio_effect_player_get_current_progress", CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
        public static extern ulong zego_express_audio_effect_player_get_current_progress(uint audio_effect_id, ZegoAudioEffectPlayerInstanceIndex instance_index);

        [DllImport(ZegoConstans.LIB_NAME, EntryPoint = "zego_express_audio_effect_player_get_total_duration", CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
        public static extern ulong zego_express_audio_effect_player_get_total_duration(uint audio_effect_id, ZegoAudioEffectPlayerInstanceIndex instance_index);



        [DllImport(ZegoConstans.LIB_NAME, EntryPoint = "zego_express_audio_effect_player_pause", CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
        public static extern int zego_express_audio_effect_player_pause(uint audio_effect_id, ZegoAudioEffectPlayerInstanceIndex instance_index);


        [DllImport(ZegoConstans.LIB_NAME, EntryPoint = "zego_express_audio_effect_player_pause_all", CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
        public static extern int zego_express_audio_effect_player_pause_all(ZegoAudioEffectPlayerInstanceIndex instance_index);


        [DllImport(ZegoConstans.LIB_NAME, EntryPoint = "zego_express_audio_effect_player_resume", CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
        public static extern int zego_express_audio_effect_player_resume(uint audio_effect_id, ZegoAudioEffectPlayerInstanceIndex instance_index);


        [DllImport(ZegoConstans.LIB_NAME, EntryPoint = "zego_express_audio_effect_player_resume_all", CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
        public static extern int zego_express_audio_effect_player_resume_all(ZegoAudioEffectPlayerInstanceIndex instance_index);



        [DllImport(ZegoConstans.LIB_NAME, EntryPoint = "zego_express_destroy_audio_effect_player", CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
        public static extern int zego_express_destroy_audio_effect_player(ZegoAudioEffectPlayerInstanceIndex instance_index);

    }
}
