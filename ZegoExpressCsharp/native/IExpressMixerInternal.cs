using System;
using System.Runtime.InteropServices;
namespace ZEGO
{
    public class IExpressMixerInternal
    {
        /// Return Type: int
        ///instance_index: zego_mediaplayer_instance_index
        [DllImportAttribute(ZegoConstans.LIB_NAME, EntryPoint = "zego_express_start_mixer_task", CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
        public static extern int zego_express_start_mixer_task(zego_mixer_task task);


        /// Return Type: void
        ///callback_func: zego_on_mixer_start_result
        ///user_context: void*
        [DllImportAttribute(ZegoConstans.LIB_NAME, EntryPoint = "zego_register_mixer_start_result_callback", CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
        public static extern void zego_register_mixer_start_result_callback(zego_on_mixer_start_result callback_func, System.IntPtr user_context);


        /// Return Type: void
        ///callback_func: zego_on_mixer_stop_result
        ///user_context: void*
        [DllImportAttribute(ZegoConstans.LIB_NAME, EntryPoint = "zego_register_mixer_stop_result_callback", CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
        public static extern void zego_register_mixer_stop_result_callback(zego_on_mixer_stop_result callback_func, System.IntPtr user_context);


        /// Return Type: int
        ///task: zego_mixer_task
        [DllImportAttribute(ZegoConstans.LIB_NAME, EntryPoint = "zego_express_stop_mixer_task", CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
        public static extern int zego_express_stop_mixer_task(zego_mixer_task task);
        /// Return Type: void
        ///error_code: int
        ///seq: int
        ///extended_data: char*
        ///user_context: void*
        [UnmanagedFunctionPointer(ZegoConstans.ZEGO_CALLINGCONVENTION)]
        public delegate void zego_on_mixer_start_result(int error_code, int seq, [In()] [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(ZegoUtil.UTF8StringMarshaler))] string extended_data, IntPtr user_context);

        /// Return Type: void
        ///error_code: int
        ///seq: int
        ///user_context: void*
        [UnmanagedFunctionPointer(ZegoConstans.ZEGO_CALLINGCONVENTION)]
        public delegate void zego_on_mixer_stop_result(int error_code, int seq, System.IntPtr user_context);

        [UnmanagedFunctionPointer(ZegoConstans.ZEGO_CALLINGCONVENTION)]
        public delegate void zego_on_mixer_relay_cdn_state_update([In()] [MarshalAs(UnmanagedType.LPStr)] string task_id, System.IntPtr info_list, uint info_count, System.IntPtr user_context);

        [UnmanagedFunctionPointer(ZegoConstans.ZEGO_CALLINGCONVENTION)]
        public delegate void zego_on_mixer_sound_level_update(System.IntPtr sound_levels, uint info_count, System.IntPtr user_context);

        [DllImport(ZegoConstans.LIB_NAME, EntryPoint = "zego_register_mixer_relay_cdn_state_update_callback", CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
        public static extern void zego_register_mixer_relay_cdn_state_update_callback(zego_on_mixer_relay_cdn_state_update callback_func, System.IntPtr user_context);


        [DllImport(ZegoConstans.LIB_NAME, EntryPoint = "zego_register_mixer_sound_level_update_callback", CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
        public static extern void zego_register_mixer_sound_level_update_callback(zego_on_mixer_sound_level_update callback_func, System.IntPtr user_context);


        [DllImport(ZegoConstans.LIB_NAME, EntryPoint = "zego_express_start_auto_mixer_task", CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
        public static extern int zego_express_start_auto_mixer_task(zego_auto_mixer_task task);


        [DllImport(ZegoConstans.LIB_NAME, EntryPoint = "zego_express_stop_auto_mixer_task", CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
        public static extern int zego_express_stop_auto_mixer_task(zego_auto_mixer_task task);


        [UnmanagedFunctionPointer(ZegoConstans.ZEGO_CALLINGCONVENTION)]
        public delegate void zego_on_auto_mixer_sound_level_update(IntPtr sound_levels, uint info_count, IntPtr user_context);


        [DllImport(ZegoConstans.LIB_NAME, EntryPoint = "zego_register_auto_mixer_sound_level_update_callback", CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
        public static extern void zego_register_auto_mixer_sound_level_update_callback(zego_on_auto_mixer_sound_level_update callback_func, IntPtr user_context);


        [UnmanagedFunctionPointer(ZegoConstans.ZEGO_CALLINGCONVENTION)]
        public delegate void zego_on_auto_mixer_start_result(int error_code, int seq, [In()] [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(ZegoUtil.UTF8StringMarshaler))] string extended_data, IntPtr user_context);


        [DllImport(ZegoConstans.LIB_NAME, EntryPoint = "zego_register_auto_mixer_start_result_callback", CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
        public static extern void zego_register_auto_mixer_start_result_callback(zego_on_auto_mixer_start_result callback_func, IntPtr user_context);


        [UnmanagedFunctionPointer(ZegoConstans.ZEGO_CALLINGCONVENTION)]
        public delegate void zego_on_auto_mixer_stop_result(int error_code, int seq, IntPtr user_context);


        [DllImport(ZegoConstans.LIB_NAME, EntryPoint = "zego_register_auto_mixer_stop_result_callback", CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
        public static extern void zego_register_auto_mixer_stop_result_callback(zego_on_auto_mixer_stop_result callback_func, IntPtr user_context);

    }
}