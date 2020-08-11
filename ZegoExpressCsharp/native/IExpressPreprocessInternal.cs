using System.Collections;
using System.Collections.Generic;
namespace ZEGO
{
    public class IExpressPreprocessInternal
    {
        ///feature_bitmask: int
        ///channel: zego_publish_channel
        [System.Runtime.InteropServices.DllImportAttribute(ZegoConstans.LIB_NAME, EntryPoint = "zego_express_enable_beautify", CallingConvention = ZegoConstans.ZEGO_CALINGCONVENTION)]
        public static extern int zego_express_enable_beautify(int feature_bitmask, ZegoPublishChannel channel);


        /// Return Type: int
        ///option: zego_beautify_option
        ///channel: zego_publish_channel
        [System.Runtime.InteropServices.DllImportAttribute(ZegoConstans.LIB_NAME, EntryPoint = "zego_express_set_beautify_option", CallingConvention = ZegoConstans.ZEGO_CALINGCONVENTION)]
        public static extern int zego_express_set_beautify_option(zego_beautify_option option, ZegoPublishChannel channel);
    }
}
