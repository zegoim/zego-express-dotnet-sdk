using System;
using System.Runtime.InteropServices;
using static ZEGO.ZegoConstans;
namespace ZEGO
{
    public class IExpressRecordInternal
    {
        [UnmanagedFunctionPointer(ZEGO_CALLINGCONVENTION)]
        public delegate void zego_on_captured_data_record_state_update(ZegoDataRecordState state, int error_code, zego_data_record_config config, ZegoPublishChannel channel, IntPtr user_context);

        [UnmanagedFunctionPointer(ZEGO_CALLINGCONVENTION)]
        public delegate void zego_on_captured_data_record_progress_update(zego_data_record_progress progress, zego_data_record_config config, ZegoPublishChannel channel, IntPtr user_context);


        [DllImport(LIB_NAME, EntryPoint = "zego_express_start_recording_captured_data", CallingConvention = ZEGO_CALLINGCONVENTION)]
        public static extern int zego_express_start_recording_captured_data(zego_data_record_config config, ZegoPublishChannel channel);

        [DllImport(LIB_NAME, EntryPoint = "zego_express_stop_recording_captured_data", CallingConvention = ZEGO_CALLINGCONVENTION)]
        public static extern int zego_express_stop_recording_captured_data(ZegoPublishChannel channel);

        [DllImport(LIB_NAME, EntryPoint = "zego_register_captured_data_record_state_update_callback", CallingConvention = ZEGO_CALLINGCONVENTION)]
        public static extern void zego_register_captured_data_record_state_update_callback(zego_on_captured_data_record_state_update callback_func, IntPtr user_context);

        [DllImport(LIB_NAME, EntryPoint = "zego_register_captured_data_record_progress_update_callback", CallingConvention = ZEGO_CALLINGCONVENTION)]
        public static extern void zego_register_captured_data_record_progress_update_callback(zego_on_captured_data_record_progress_update callback_func, IntPtr user_context);

    }
}
