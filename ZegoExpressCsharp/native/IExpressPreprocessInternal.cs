using System.Collections;
using System.Collections.Generic;
//using UnityEngine;
namespace ZEGO
{
    public class IExpressPreprocessInternal
    {
        ///feature_bitmask: int
        ///channel: zego_publish_channel
        [System.Runtime.InteropServices.DllImportAttribute(ZegoConstans.LIB_NAME, EntryPoint = "zego_express_enable_beautify", CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
        public static extern int zego_express_enable_beautify(int feature_bitmask, ZegoPublishChannel channel);


        /// Return Type: int
        ///option: zego_beautify_option
        ///channel: zego_publish_channel
        [System.Runtime.InteropServices.DllImportAttribute(ZegoConstans.LIB_NAME, EntryPoint = "zego_express_set_beautify_option", CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
        public static extern int zego_express_set_beautify_option(zego_beautify_option option, ZegoPublishChannel channel);


        /// Return Type: int
        ///enable: boolean
        [System.Runtime.InteropServices.DllImportAttribute(ZegoConstans.LIB_NAME, EntryPoint = "zego_express_enable_aec", CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
        public static extern int zego_express_enable_aec([System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.I1)] bool enable);

        [System.Runtime.InteropServices.DllImportAttribute(ZegoConstans.LIB_NAME, EntryPoint = "zego_express_enable_headphone_aec", CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
        public static extern int zego_express_enable_headphone_aec([System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.I1)] bool enable);


        /// Return Type: int
        ///mode: ZegoAecMode
        [System.Runtime.InteropServices.DllImportAttribute(ZegoConstans.LIB_NAME, EntryPoint = "zego_express_set_aec_mode", CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
        public static extern int zego_express_set_aec_mode(ZegoAECMode mode);


        /// Return Type: int
        ///enable: boolean
        [System.Runtime.InteropServices.DllImportAttribute(ZegoConstans.LIB_NAME, EntryPoint = "zego_express_enable_agc", CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
        public static extern int zego_express_enable_agc([System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.I1)] bool enable);


        /// Return Type: int
        ///enable: boolean
        [System.Runtime.InteropServices.DllImportAttribute(ZegoConstans.LIB_NAME, EntryPoint = "zego_express_enable_ans", CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
        public static extern int zego_express_enable_ans([System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.I1)] bool enable);


        [System.Runtime.InteropServices.DllImportAttribute(ZegoConstans.LIB_NAME, EntryPoint = "zego_express_enable_transient_ans", CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
        public static extern int zego_express_enable_transient_ans([System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.I1)] bool enable);

        /// Return Type: int
        ///mode: ZegoAnsMode
        [System.Runtime.InteropServices.DllImportAttribute(ZegoConstans.LIB_NAME, EntryPoint = "zego_express_set_ans_mode", CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
        public static extern int zego_express_set_ans_mode(ZegoANSMode mode);

    }
}
