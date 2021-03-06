﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
namespace ZEGO
{
    public class IExpressMixerInternal
    {
        /// Return Type: int
        ///instance_index: zego_mediaplayer_instance_index
        [DllImportAttribute(ZegoConstans.LIB_NAME, EntryPoint = "zego_express_start_mixer_task", CallingConvention = ZegoConstans.ZEGO_CALINGCONVENTION)]
        public static extern int zego_express_start_mixer_task(zego_mixer_task task);


        /// Return Type: void
        ///callback_func: zego_on_mixer_start_result
        ///user_context: void*
        [DllImportAttribute(ZegoConstans.LIB_NAME, EntryPoint = "zego_register_mixer_start_result_callback", CallingConvention = ZegoConstans.ZEGO_CALINGCONVENTION)]
        public static extern void zego_register_mixer_start_result_callback(zego_on_mixer_start_result callback_func, System.IntPtr user_context);


        /// Return Type: void
        ///callback_func: zego_on_mixer_stop_result
        ///user_context: void*
        [DllImportAttribute(ZegoConstans.LIB_NAME, EntryPoint = "zego_register_mixer_stop_result_callback", CallingConvention = ZegoConstans.ZEGO_CALINGCONVENTION)]
        public static extern void zego_register_mixer_stop_result_callback(zego_on_mixer_stop_result callback_func, System.IntPtr user_context);


        /// Return Type: int
        ///task: zego_mixer_task
        [DllImportAttribute(ZegoConstans.LIB_NAME, EntryPoint = "zego_express_stop_mixer_task", CallingConvention = ZegoConstans.ZEGO_CALINGCONVENTION)]
        public static extern int zego_express_stop_mixer_task(zego_mixer_task task);
        /// Return Type: void
        ///error_code: int
        ///seq: int
        ///extended_data: char*
        ///user_context: void*
        [UnmanagedFunctionPointer(ZegoConstans.ZEGO_CALINGCONVENTION)]
        public delegate void zego_on_mixer_start_result(int error_code, int seq, [System.Runtime.InteropServices.InAttribute()] [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string extended_data, System.IntPtr user_context);

        /// Return Type: void
        ///error_code: int
        ///seq: int
        ///user_context: void*
        [UnmanagedFunctionPointer(ZegoConstans.ZEGO_CALINGCONVENTION)]
        public delegate void zego_on_mixer_stop_result(int error_code, int seq, System.IntPtr user_context);
    }
}
