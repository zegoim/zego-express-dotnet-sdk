using System;
using System.Runtime.InteropServices;
using static ZEGO.ZegoConstans;

namespace ZEGO {
public class IExpressUtilsInternal {
    [DllImportAttribute(ZegoConstans.LIB_NAME, EntryPoint = "zego_express_get_network_time_info",
                        CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
    public static extern int zego_express_get_network_time_info(IntPtr time_info);
}
}