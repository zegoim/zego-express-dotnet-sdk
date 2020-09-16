using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace ZEGO
{
    class IExpressPrivateInternal
    {
        [DllImportAttribute(ZegoConstans.LIB_NAME, EntryPoint = "zego_express_custom_log", CallingConvention = ZegoConstans.ZEGO_CALINGCONVENTION)]
        public static extern void zego_express_custom_log([System.Runtime.InteropServices.InAttribute()][System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(ZegoUtil.UTF8StringMarshaler))] string log, [System.Runtime.InteropServices.InAttribute()][System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string module);


        [DllImportAttribute(ZegoConstans.LIB_NAME, EntryPoint = "zego_express_get_print_debug_info", CallingConvention = ZegoConstans.ZEGO_CALINGCONVENTION)]
        public static extern IntPtr zego_express_get_print_debug_info(int module, [System.Runtime.InteropServices.InAttribute()][System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string func_name, int error_code);



        [DllImportAttribute(ZegoConstans.LIB_NAME, EntryPoint = "zego_express_trigger_on_debug_error", CallingConvention = ZegoConstans.ZEGO_CALINGCONVENTION)]
        public static extern void zego_express_trigger_on_debug_error(int error_code, [System.Runtime.InteropServices.InAttribute()][System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string func_name, [System.Runtime.InteropServices.InAttribute()][System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string info);
    }
    
}
