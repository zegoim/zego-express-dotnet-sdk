using System.Runtime.InteropServices;
using static ZEGO.ZegoConstans;

namespace ZEGO
{
    public class IExpressEngineInternal
    {
        /**
         * 调试错误回调
         * 
         * @param error_code 错误码，详情请参考常用错误码文档
         * @param func_name 接口名
         * @param info 错误的详细信息
         * @param user_context 用户上下文
         */
        [UnmanagedFunctionPointer(ZegoConstans.ZEGO_CALINGCONVENTION)]
        public delegate void zego_on_debug_error(int error_code, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string func_name, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string info, System.IntPtr user_context);
        /**
         * 音视频引擎状态变更回调
         *
         * @discussion 当开发者首次预览、推流或拉流时，音视频引擎将会启动
         * @discussion 当开发者使用异步销毁引擎时，必须要确保收到音视频引擎停止通知之后才能表示内部已完全释放资源。此后才能再进行下一次的创建引擎的操作
         * @param user_context 用户上下文
         */
        [UnmanagedFunctionPointer(ZegoConstans.ZEGO_CALINGCONVENTION)]
        public delegate void zego_on_engine_state_update(ZegoEngineState state, System.IntPtr user_context);
        /**
        * 音视频引擎销毁通知回调
        *
        * @discussion 当开发者使用异步销毁引擎时，可通过监听此回调来获取SDK是否已经完全释放资源
        * @param user_context 用户上下文
        */
        [UnmanagedFunctionPointer(ZegoConstans.ZEGO_CALINGCONVENTION)]
        public delegate void zego_on_engine_uninit(System.IntPtr user_context);


        /**
          * 获取 SDK 版本号
          * 
          * @return (const char*), ZegoExpressSDK 版本号
          */

        [DllImportAttribute(ZegoConstans.LIB_NAME, EntryPoint = "zego_express_get_version", CallingConvention = ZegoConstans.ZEGO_CALINGCONVENTION)]
        public static extern System.IntPtr zego_express_get_version();



        /**
         * 设置Android的上下文环境
         * 
         * @param jvm Java 虚拟机
         * @param app_context Android 应用上下文
         * @return (zego_error), 错误码
         */
        [DllImportAttribute(ZegoConstans.LIB_NAME, EntryPoint = "zego_express_set_android_env", CallingConvention = ZegoConstans.ZEGO_CALINGCONVENTION)]
        public static extern int zego_express_set_android_env(System.IntPtr jvm, System.IntPtr app_context);
        /**
        * 获取之前设置好的 Android 的上下文环境
        *
        * @return (void*), context 当初始化SDK之前没有调用过 zego_express_Set_android_env，或者不是在 android平台下调用，则返回 NULL
        */

        [DllImportAttribute(ZegoConstans.LIB_NAME, EntryPoint = "zego_express_get_android_context", CallingConvention = ZegoConstans.ZEGO_CALINGCONVENTION)]
        public static extern System.IntPtr zego_express_get_android_context();
        /**
         * 设置初始化预配置
         * 
         * @param config 高级配置，可选配置，设置为空则使用默认配置
         */
        [DllImportAttribute(ZegoConstans.LIB_NAME, EntryPoint = "zego_express_set_engine_config", CallingConvention = ZegoConstans.ZEGO_CALINGCONVENTION)]
        public static extern void zego_express_set_engine_config(zego_engine_config config);
        /**
         * 创建引擎实例对象
         * 在调用其他 API 前需要先创建并初始化引擎；SDK 只支持创建一个 ZegoExpressEngine 实例，多次调用此接口返回的都是同一个对象。
         * @param app_id ZEGO 为开发者签发的应用 ID，请从 ZEGO 管理控制台申请
         * @param app_sign 每个 AppID 对应的应用签名，请从 ZEGO 管理控制台申请
         * @param is_test_env 选择使用测试环境还是正式商用环境，正式环境需要在 ZEGO 管理控制台提交工单配置
         * @param scenario 所属的应用场景，当前请选择为 ZegoScenarioGeneral
         * @param event_handler 事件通知回调对象
         * @return (zego_error), 错误码
         */
        [DllImportAttribute(ZegoConstans.LIB_NAME, EntryPoint = "zego_express_engine_init", CallingConvention = ZegoConstans.ZEGO_CALINGCONVENTION)]
        public static extern int zego_express_engine_init(uint app_id, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string app_sign, bool is_test_env, ZegoScenario scenario);
        /**
         * 同步销毁引擎实例对象
         * 用于释放 SDK 使用的资源。同步销毁会阻塞当前线程，若开发者不希望在这途中阻塞UI线程，可在其他线程调用。
         * @return (zego_error), 错误码
         */
        [DllImportAttribute(ZegoConstans.LIB_NAME, EntryPoint = "zego_express_engine_uninit_async", CallingConvention = ZegoConstans.ZEGO_CALINGCONVENTION)]
        public static extern int zego_express_engine_uninit_async();


        /**
         * 上传日志到 ZEGO 服务器
         * 
         */
        [DllImportAttribute(ZegoConstans.LIB_NAME, EntryPoint = "zego_express_upload_log", CallingConvention = ZegoConstans.ZEGO_CALINGCONVENTION)]
        public static extern void zego_express_upload_log();
        /**
         * 设置调试详细信息开关以及语言
         * 默认开启且调试信息的语言为英文。
         * @param enable 详细调试信息开关
         * @param language 调试信息语种，默认为英文
         */
        [DllImportAttribute(ZegoConstans.LIB_NAME, EntryPoint = "zego_express_set_debug_verbose", CallingConvention = ZegoConstans.ZEGO_CALINGCONVENTION)]
        public static extern void zego_express_set_debug_verbose(bool enable, ZegoLanguage language);
        /**
         * 注册调试错误回调
         * 
         * @param event_handler 事件通知回调
         * @param callback_func 调试信息回调接口
         * @param user_context 用户上下文
         */
        [DllImportAttribute(ZegoConstans.LIB_NAME, EntryPoint = "zego_register_debug_error_callback", CallingConvention = ZegoConstans.ZEGO_CALINGCONVENTION)]
        public static extern void zego_register_debug_error_callback(zego_on_debug_error callback_func, System.IntPtr user_context);
        /**
         * 注册接收音视频引擎状态变更回调
         *
         * @param event_handler 事件通知回调
         * @param callback_func 调试信息回调接口
         * @param user_context 用户上下文
         */
        [DllImportAttribute(ZegoConstans.LIB_NAME, EntryPoint = "zego_register_engine_state_update_callback", CallingConvention = ZegoConstans.ZEGO_CALINGCONVENTION)]
        public static extern void zego_register_engine_state_update_callback(zego_on_engine_state_update callback_func, System.IntPtr user_context);


        [DllImportAttribute(ZegoConstans.LIB_NAME, EntryPoint = "zego_register_engine_uninit_callback", CallingConvention = ZegoConstans.ZEGO_CALINGCONVENTION)]
        public static extern void zego_register_engine_uninit_callback(zego_on_engine_uninit callback_func, System.IntPtr user_context);
    }
}


