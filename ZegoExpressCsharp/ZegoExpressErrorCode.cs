
namespace ZEGO {
public class ZegoExpressErrorCode {
    /** Execution successful. */
    public const int ZEGO_ERROR_CODE_COMMON_SUCCESS = 0;

    /** Description: The engine is not initialized and cannot call non-static functions. <br>Cause: Engine not created.<br>Solutions: Please call the [createEngine] function to create the engine first, and then call the current function. */
    public const int ZEGO_ERROR_CODE_COMMON_ENGINE_NOT_CREATE = 1000001;

    /** Description: Not logged in to the room, unable to support function implementation. <br>Cause: Not logged in to the room.<br>Solutions: Please call [loginRoom] to log in to the room first, and use related functions during the online period after entering the room. */
    public const int ZEGO_ERROR_CODE_COMMON_NOT_LOGIN_ROOM = 1000002;

    /** Description: The audio and video module of the engine is not started and cannot support function realization. <br>Cause: Audio and video modules with no engine started.<br>Solutions: Please call [startPreviewView] [startPublishingStream] [startPlayingStream] to start the audio and video module first. */
    public const int ZEGO_ERROR_CODE_COMMON_ENGINE_NOT_STARTED = 1000003;

    /** Description: Call functions that are not supported on the current system/platform. <br>Cause: For example, calling the function of setting the Android context environment on a non-Android system.<br>Solutions: Check if the system environment matches. */
    public const int ZEGO_ERROR_CODE_COMMON_UNSUPPORTED_PLATFORM = 1000006;

    /** Description: Invalid Android context. <br>Cause: Not set or set the wrong Android context environment.<br>Solutions: Set the correct Android context. */
    public const int ZEGO_ERROR_CODE_COMMON_INVALID_ANDROID_ENVIRONMENT = 1000007;

    /** Description: `setEventHandler` has been called to set the handler, please do not set it repeatedly. <br>Cause: Call `setEventHandler` repeatedly to set the handler.<br>Solutions: If you need to repeat the settings, please call `setEventHandler` first to empty the previous handler. */
    public const int ZEGO_ERROR_CODE_COMMON_EVENT_HANDLER_EXISTS = 1000008;

    /** Description: The current SDK does not support this feature. <br>Cause: The SDK version used does not include this feature.<br>Solutions: Please contact ZEGO technical support. */
    public const int ZEGO_ERROR_CODE_COMMON_SDK_NO_MODULE = 1000010;

    /** Description: The input streamID is too long. <br>Cause: The length of the streamID parameter passed in when calling [startPublishingStream] or [startPlayingStream] exceeds the limit. <br>Solutions: The streamID should be less than 256 bytes. */
    public const int ZEGO_ERROR_CODE_COMMON_STREAM_ID_TOO_LONG = 1000014;

    /** Description: The input StreamID is null. <br>Cause: The streamID parameter passed in when calling [startPublishingStream] or [startPlayingStream] is null or empty string. <br>Solutions: Check whether the streamID parameter passed in when calling the function is normal. */
    public const int ZEGO_ERROR_CODE_COMMON_STREAM_ID_NULL = 1000015;

    /** Description: The input streamID contains invalid characters. <br>Cause: The streamID parameter passed in when calling [startPublishingStream] or [startPlayingStream] contains invalid characters. <br>Solutions: Check whether the streamID parameter passed in when calling the function is normal, only support numbers, english characters and '~', '!', '@', '$', '%', '^', '&', '*', '(', ')', '_', '+', '=', '-', '`', ';', ',', '.', '<', '>', '/', '\'. */
    public const int ZEGO_ERROR_CODE_COMMON_STREAM_ID_INVALID_CHARACTER = 1000016;

    /** Illegal param. */
    public const int ZEGO_ERROR_CODE_COMMON_ILLEGAL_PARAM = 1000017;

    /** Description: This AppID has been removed from production. <br>Solutions: Please check the status of the AppID on the ZEGO official website console or contact ZEGO technical support. */
    public const int ZEGO_ERROR_CODE_COMMON_APP_OFFLINE_ERROR = 1000037;

    /** Description: The backend configuration of the server is incorrect. <br>Cause: 1. The domain name configuration is incorrect; 2. The media network is abnormal; 3. The media network link is empty. <br>Solutions: Please contact ZEGO technical support. */
    public const int ZEGO_ERROR_CODE_COMMON_APP_FLEXIABLE_CONFIG_ERROR = 1000038;

    /** Description: Incorrect CDN address. <br>Cause: The set CDN URL is not a standard RTMP or FLV protocol. <br>Solutions: Please check the supported protocol and format. */
    public const int ZEGO_ERROR_CODE_COMMON_CDN_URL_INVALID = 1000055;

    /** DNS resolution failed. Please check network configurations. This error code is deprecated. */
    public const int ZEGO_ERROR_CODE_COMMON_DNS_RESOLVE_ERROR = 1000060;

    /** Server dispatching exception. Please contact ZEGO technical support to solve the problem. This error code is deprecated. */
    public const int ZEGO_ERROR_CODE_COMMON_DISPATCH_ERROR = 1000065;

    /** Description: SDK internal null pointer error. <br>Cause: The Android JVM environment is abnormal. <br>Solutions: Please check whether the Android JVM environment is normal or contact ZEGO technical support. */
    public const int ZEGO_ERROR_CODE_COMMON_INNER_NULLPTR = 1000090;

    /** AppID cannot be 0. Please check if the AppID is correct. */
    public const int ZEGO_ERROR_CODE_ENGINE_APPID_ZERO = 1001000;

    /** The length of the input AppSign must be 64 bytes. */
    public const int ZEGO_ERROR_CODE_ENGINE_APPSIGN_INVALID_LENGTH = 1001001;

    /** The input AppSign contains invalid characters. Only '0'-'9', 'a'-'f', 'A'-'F' are valid. */
    public const int ZEGO_ERROR_CODE_ENGINE_APPSIGN_INVALID_CHARACTER = 1001002;

    /** The input AppSign is empty. */
    public const int ZEGO_ERROR_CODE_ENGINE_APPSIGN_NULL = 1001003;

    /** Description: Authentication failed. <br>Cause: Incorrect AppID; using AppID in wrong environment. <br>Solutions: Please check AppID is correct or not on ZEGO manage console, or check whether the environment configured by AppID is consistent with the environment set by SDK. */
    public const int ZEGO_ERROR_CODE_ENGINE_APPID_INCORRECT_OR_NOT_ONLINE = 1001004;

    /** Description: Authentication failed. <br>Cause: Incorrect AppSign. <br>Solutions: Please check AppSign is correct or not on ZEGO manage console. */
    public const int ZEGO_ERROR_CODE_ENGINE_APPSIGN_INCORRECT = 1001005;

    /** Description: No write permission to the log file. <br>Cause: App has no write permission to log file folder. <br>Solutions: Please check has grant write permission to App or not; check log folder is protected or not. */
    public const int ZEGO_ERROR_CODE_ENGINE_LOG_NO_WRITE_PERMISSION = 1001014;

    /** Description: The log file path is too long. <br>Cause: The length of log file path exceeds limit. <br>Solutions: Please check the length of log file path. */
    public const int ZEGO_ERROR_CODE_ENGINE_LOG_PATH_TOO_LONG = 1001015;

    /** Description: Set room mode failed. <br>Cause: Set room mode before initialize the SDK. <br>Solutions: Please set room mode after initialize the SDK. */
    public const int ZEGO_ERROR_CODE_ENGINE_SET_ROOM_MODE_ERROR_TIME = 1001020;

    /** Description: The experimental API json parameter parsing failed. <br>Cause: Invalid json format; wrong function name or parameter. <br>Solutions: Please check json format is valid or not; check function name or parameter is correct or not, contact ZEGO technical support for specific function name and parameters. */
    public const int ZEGO_ERROR_CODE_ENGINE_EXPERIMENTAL_JSON_STR_INVALID = 1001091;

    /** Description: The number of rooms the user attempted to log into simultaneously exceeds the maximum number allowed. Currently, a user can only be logged in to one main room.<br>Cause: Login multiple rooms simultaneously under single room mode. <br>Solutions: Please check is login multiple rooms simultaneously or not under single room mode. */
    public const int ZEGO_ERROR_CODE_ROOM_COUNT_EXCEED = 1002001;

    /** Description: Haven't login with the input room ID.<br>Cause: Haven't login with the input room ID before call [logoutRoom] or [switchRoom] or [renewToken] or [setRoomExtraInfo]. <br>Solutions: Please check has login with the room ID or not. */
    public const int ZEGO_ERROR_CODE_ROOM_ROOMID_INCORRECT = 1002002;

    /** Description: The input user ID is empty.<br>Cause: The input user ID is empty. <br>Solutions: Please check the input user ID is empty or not. */
    public const int ZEGO_ERROR_CODE_ROOM_USER_ID_NULL = 1002005;

    /** Description: The input user ID contains invalid characters.<br>Cause: The input user ID contains invalid characters. <br>Solutions: User ID can only contains numbers, English characters and '~', '!', '@', '#', '$', '%', '^', '&', '*', '(', ')', '_', '+', '=', '-', '`', ';', ',', '.', '<', '>', '/', '\'. */
    public const int ZEGO_ERROR_CODE_ROOM_USER_ID_INVALID_CHARACTER = 1002006;

    /** The input user ID is too long. <br>The length of the user ID input by the [loginRoom] function is greater than or equal to 64 bytes. <br>Please check the user ID entered when calling the [loginRoom] function to ensure that its length is less than 64 bytes. */
    public const int ZEGO_ERROR_CODE_ROOM_USER_ID_TOO_LONG = 1002007;

    /** The input user name is empty. <br>The user name entered by the [loginRoom] function is empty. <br>Please check the user name entered when calling the [loginRoom] function to make sure it is not empty. */
    public const int ZEGO_ERROR_CODE_ROOM_USER_NAME_NULL = 1002008;

    /** The input user name contains invalid characters. <br>The user name entered by the [loginRoom] function contains illegal characters.<br>Please check the user name entered when calling the [loginRoom] function to ensure that it is only contain numbers, English characters and '~', '!', '@', '#', '$', '%', '^', '&', '*', '(', ')', '_', '+', '=', '-', '`', ';', ',', '.', '<', '>', '/', '\'. */
    public const int ZEGO_ERROR_CODE_ROOM_USER_NAME_INVALID_CHARACTER = 1002009;

    /** The input user name is too long. <br>The length of the user name input by the [loginRoom] function is greater than or equal to 256 bytes. <br>Please check the user name entered when calling the [loginRoom] function to ensure that its length is less than 256 bytes. */
    public const int ZEGO_ERROR_CODE_ROOM_USER_NAME_TOO_LONG = 1002010;

    /** The input room ID is empty. <br>The room ID entered by the [loginRoom] function is empty. <br>Please check the room ID entered when calling the [loginRoom] function to make sure it is not empty. */
    public const int ZEGO_ERROR_CODE_ROOM_ROOMID_NULL = 1002011;

    /** The input room ID contains invalid characters. <br>The room ID entered by the [loginRoom] function contains illegal characters.<br>Please check the room ID entered when calling the [loginRoom] function to ensure that it is only contain numbers, English characters and '~', '!', '@', '#', '$', '%', '^', '&', '*', '(', ')', '_', '+', '=', '-', '`', ';', ',', '.', '<', '>', '/', '\'. */
    public const int ZEGO_ERROR_CODE_ROOM_ROOMID_INVALID_CHARACTER = 1002012;

    /** The input room ID is too long. <br>The length of the room ID input by the [loginRoom] function is greater than or equal to 128 bytes. <br>Please check the room ID entered when calling the [loginRoom] function to ensure that its length is less than 128 bytes. */
    public const int ZEGO_ERROR_CODE_ROOM_ROOMID_TOO_LONG = 1002013;

    /** The key for room extra info is empty. <br>The key for room extra info entered by the [setRoomExtraInfo] function is empty. <br>Please check the key for room extra info entered when calling the [setRoomExtraInfo] function to make sure it is not empty. */
    public const int ZEGO_ERROR_CODE_ROOM_ROOM_EXTRA_INFO_KEY_EMPTY = 1002014;

    /** The key for room extra info is too long. <br>The length of the key for room extra info input by the [setRoomExtraInfo] function is greater than or equal to 128 bytes. <br>Please check the key for room extra info entered when calling the [setRoomExtraInfo] function to ensure that its length is less than 128 bytes. */
    public const int ZEGO_ERROR_CODE_ROOM_ROOM_EXTRA_INFO_KEY_TOO_LONG = 1002015;

    /** The value for room extra info is too long. <br>The length of the value for room extra info input by the [setRoomExtraInfo] function is greater than or equal to 4096 bytes. <br>Please check the value for room extra info entered when calling the [setRoomExtraInfo] function to ensure that its length is less than 4096 bytes. */
    public const int ZEGO_ERROR_CODE_ROOM_ROOM_EXTRA_INFO_VALUE_TOO_LONG = 1002016;

    /** Description: The number of keys set in the room additional message exceeds the maximum number of supported limits. <br>Cause: called setRoomExtraInfo Different keys have been passed in multiple times. <br> Solutions: please contact ZEGO technical support. */
    public const int ZEGO_ERROR_CODE_ROOM_ROOM_EXTRA_INFO_EXCEED_KEYS = 1002017;

    /** Description: set multi room mode, userID or user name is different. <br>Cause: set multi room mode, login multi room use different user id or user name. <br> Solutions: Currently supports at most one key, if you need to support multiple, contact ZEGO technical support. */
    public const int ZEGO_ERROR_CODE_ROOM_MULTI_ROOM_LOGIN_USER_NOT_SAME = 1002018;

    /** Description: The [switchRoom] function cannot be used in multi-room mode. <br>Cause: multi room mode SDK not support. <br> Solutions: first call [logoutRoom] then call [loginRoom]. */
    public const int ZEGO_ERROR_CODE_ROOM_MULTI_ROOM_SWTICH_ROOM_INVALID = 1002019;

    /** Description: Login failed, possibly due to network problems. <br>Cause: The current network is abnormal. <br> Solutions: It is recommended to switch the network to try. */
    public const int ZEGO_ERROR_CODE_ROOM_ERROR_CONNECT_FAILED = 1002030;

    /** Description: Login timed out, possibly due to network problems. <br>Cause: The current network delay is large. <br> Solutions: It is recommended to switch the network to try. */
    public const int ZEGO_ERROR_CODE_ROOM_ERROR_LOGIN_TIMEOUT = 1002031;

    /** Description: Room login authentication failed. <br>Cause: login set token error or token expired. <br> Solutions: set new token. */
    public const int ZEGO_ERROR_CODE_ROOM_ERROR_AUTHENTICATION_FAILED = 1002033;

    /** Description: The number of users logging into the room exceeds the maximum number of concurrent users configured for the room. (In the test environment, the default maximum number of users in the room is 50). <br>Cause: too much user in room. <br> Solutions: contact ZEGO technical support. */
    public const int ZEGO_ERROR_CODE_ROOM_ERROR_EXCEED_MAXIMUM_MEMBER = 1002034;

    /** Description: in test environment The total number of rooms logged in at the same time exceeds the limit. (In the test environment, the maximum number of concurrent rooms is 10). <br>Cause: Too many rooms logged in at the same time. <br> Solutions: logout some room, login room. */
    public const int ZEGO_ERROR_CODE_ROOM_ERROR_EXCEED_MAXIMUM_ROOM_COUNT = 1002035;

    /** Description: login failed, multi-room mode is not activate. <br>Cause: multi-room mode is not activate. <br> Solutions: please contact ZEGO technical support. */
    public const int ZEGO_ERROR_CODE_ROOM_ERROR_LOGIN_MULTI_ROOM_NOT_OPEN = 1002036;

    /** The total number of rooms logged in at the same time exceeds the limit, Please contact ZEGO technical support. */
    public const int ZEGO_ERROR_CODE_ROOM_ERROR_MULTI_ROOM_EXCEED_MAXIMUM_ROOM_COUNT = 1002037;

    /** Description: The user was kicked out of the room. <br>Cause: Possibly because the same user ID is logged in on another device. <br>Solutions: Use a unique user ID. */
    public const int ZEGO_ERROR_CODE_ROOM_KICKED_OUT = 1002050;

    /** Description: Room connection is temporarily interrupted and is retrying. <br>Cause: Possibly due to network problems. <br>Solutions: Please wait or check whether the network is normal. */
    public const int ZEGO_ERROR_CODE_ROOM_CONNECT_TEMPORARY_BROKEN = 1002051;

    /** Description: Room connection disconnected. <br>Cause: Possibly due to network problems. <br>Solutions: Please check whether the network is working or switch the network environment. */
    public const int ZEGO_ERROR_CODE_ROOM_DISCONNECT = 1002052;

    /** Description: Room login retry has exceeded the maximum retry time. <br>Cause: Possibly due to network problems. <br>Solutions: Please check whether the network is working or switch the network environment. */
    public const int ZEGO_ERROR_CODE_ROOM_RETRY_TIMEOUT = 1002053;

    /** Description: The business server has sent a signal to kick the user out of the room. <br>Cause: The business server has sent a signal to kick the user out of the room. <br>Solutions: Contact the business server for processing. */
    public const int ZEGO_ERROR_CODE_ROOM_MANUAL_KICKED_OUT = 1002055;

    /** Description: Wrong order of login rooms. <br>Cause: Log in multi room without log in the main room. <br>Solutions: Please log in to the main room with `loginRoom` before logging in to multi room. */
    public const int ZEGO_ERROR_CODE_ROOM_WRONG_LOGIN_SEQUENCE = 1002061;

    /** Description: Wrong order of logout rooms. <br>Cause: Log out the main room without log out multi room. <br>Solutions: Please log out of the multi room before logging out of the main room. */
    public const int ZEGO_ERROR_CODE_ROOM_WRONG_LOGOUT_SEQUENCE = 1002062;

    /** Description: No multi-room permission. <br>Cause: No multi-room permission. <br>Solutions: Please contact ZEGO technical support to enable it. */
    public const int ZEGO_ERROR_CODE_ROOM_NO_MULTI_ROOM_PERMISSION = 1002063;

    /** Description: The room ID has been used by other login room interface. Current user can not login room with the room ID before release the room ID. <br>Cause: The room ID has been used by other login room interface. <br>Solutions: Logout the room with the same room ID first. */
    public const int ZEGO_ERROR_CODE_ROOM_ROOM_ID_HAS_BEEN_USED = 1002064;

    /** Description: This method has been deprecated after version 2.9.0. <br>Cause: This method has been deprecated after version 2.9.0. <br>Solutions: Please set [setRoomMode] to select multi-room mode before the engine started, and then call [loginRoom] to use multi-room. */
    public const int ZEGO_ERROR_CODE_ROOM_MULTI_ROOM_DEPRECATED = 1002065;

    /** Description: If the user is in the server blacklist when logging in to the room, this error code will be returned, indicating that it is forbidden to log in to the room. <br>Cause: The user is currently in the server blacklist. <br>Solutions: Please contact ZEGO technical support. */
    public const int ZEGO_ERROR_CODE_ROOM_USER_IN_BLACKLIST = 1002066;

    /** Description: Room login failed due to internal system exceptions.<br>Cause: Unknown internal error.<br>Solutions: Contact ZEGO technical support to deal with it. */
    public const int ZEGO_ERROR_CODE_ROOM_INNER_ERROR = 1002099;

    /** Description: Publishing failed due to no data in the stream.<br>Cause: No data in the stream.<br>Solutions: Check whether the video, audio capture module is working properly. */
    public const int ZEGO_ERROR_CODE_PUBLISHER_PUBLISH_STREAM_FAILED = 1003001;

    /** Description: Publishing failed due to wrong bitrate setting.<br>Cause: The set video bitrate, audio bitrate, or minimum video bitrate threshold for traffic control exceeds the upper limit.<br>Solutions: Please check if the bitrate value is in the correct unit (kbps).Adjust the bitrate setting. */
    public const int ZEGO_ERROR_CODE_PUBLISHER_BITRATE_INVALID = 1003002;

    /** Description: The property param of the traffic control is set incorrectly.<br>Cause: The property param of the traffic control is less than 0 or exceeds all combinations.<br>Solutions: Check the settings of the property param of the traffic control. */
    public const int ZEGO_ERROR_CODE_PUBLISHER_TRAFFIC_MODE_INVALID = 1003005;

    /** Description: Streaming failed, H.265 encoding is not supported.<br>Cause: The hardware device does not support H.265 encoding, or the SDK does not include H.265 encoding module.<br>Solutions: Contact ZEGO technical support to confirm whether the SDK contains the H.265 encoding module, if the hardware device does not support it, it is recommended to upgrade the hardware. */
    public const int ZEGO_ERROR_CODE_PUBLISHER_ERROR_H265_ENCODER_NOT_SUPPORTED = 1003010;

    /** Description:Stream publishing is temporarily interrupted and is retrying. <br>Cause: The network fluctuates or the network signal is bad.<br>Solutions: Please wait or check whether the network is normal. */
    public const int ZEGO_ERROR_CODE_PUBLISHER_ERROR_NETWORK_INTERRUPT = 1003020;

    /** Description: Stream publish retry has exceeds the maximum retry time.<br>Cause: The the network signal is bad, and the maximum retry time is exceeded.<br>Solutions: Check the network status or switch to another network. */
    public const int ZEGO_ERROR_CODE_PUBLISHER_ERROR_RETRY_TIMEOUT = 1003021;

    /** Description: Failed to publish the stream. The publish channel is already publishing streams.<br>Cause:  The publish channel is already publishing streams.<br>Solutions: Please check the business logic to avoid repeating the publish for publish channel which is publishing. */
    public const int ZEGO_ERROR_CODE_PUBLISHER_ERROR_ALREADY_DO_PUBLISH = 1003023;

    /** Description: Failed to publish the stream. Publishing of this stream is prohibited by backend configuration.<br>Cause: Publishing of this stream is prohibited by backend configuration.<br>Solutions: Contact ZEGO technical support to deal with it. */
    public const int ZEGO_ERROR_CODE_PUBLISHER_ERROR_SERVER_FORBID = 1003025;

    /** Description: Failed to publish the stream. The same stream already exists in the room.<br>Cause: The same stream already exists in the room.<br>Solutions: Replace with a new stream ID. Adjust the stream ID generation strategy to ensure uniqueness. */
    public const int ZEGO_ERROR_CODE_PUBLISHER_ERROR_REPETITIVE_PUBLISH_STREAM = 1003028;

    /** Description: Failed to publish the stream. The connection to the RTMP server is interrupted.<br>Cause: The publish address is wrong, or the network signal is bad.<br>Solutions: Please check whether there is any problem with the network connection or the stream publishing URL. */
    public const int ZEGO_ERROR_CODE_PUBLISHER_RTMP_SERVER_DISCONNECT = 1003029;

    /** Description: Failed to take a screenshot of the publis stream screen. <br>Cause: The preview is stopped and the push is abnormal. <br>Solutions: Turn on preview or re-publish. */
    public const int ZEGO_ERROR_CODE_PUBLISHER_TAKE_PUBLISH_STREAM_SNAPSHOT_FAILED = 1003030;

    /** Description: Failed to update the relay CDN status. <br>Cause: The URL of the relay address is incorrect. <br>Solutions: Check whether the input URL is valid. */
    public const int ZEGO_ERROR_CODE_PUBLISHER_UPDATE_CDN_TARGET_ERROR = 1003040;

    /** Description: Failed to send SEI. <br>Cause: data is empty. <br>Solutions: Incoming non-empty data. */
    public const int ZEGO_ERROR_CODE_PUBLISHER_SEI_DATA_NULL = 1003043;

    /** Description: Failed to send SEI. <br>Cause: The input data exceeds the length limit. <br>Solutions: The length of the sent SEI data should be less than 4096 bytes. */
    public const int ZEGO_ERROR_CODE_PUBLISHER_SEI_DATA_TOO_LONG = 1003044;

    /** The extra info of the stream is null. */
    public const int ZEGO_ERROR_CODE_PUBLISHER_EXTRA_INFO_NULL = 1003050;

    /** The extra info of the stream is too long. The maximum length should be less than 1024 bytes. */
    public const int ZEGO_ERROR_CODE_PUBLISHER_EXTRA_INFO_TOO_LONG = 1003051;

    /** Failed to update the extra info of the stream. Please check the network connection. */
    public const int ZEGO_ERROR_CODE_PUBLISHER_UPDATE_EXTRA_INFO_FAILED = 1003053;

    /** Description: Failed to set publish watermark. <br>Cause: The incoming watermark path is empty. <br>Solutions: Incoming non-empty path. */
    public const int ZEGO_ERROR_CODE_PUBLISHER_WATERMARK_URL_NULL = 1003055;

    /** Description: Failed to set publish watermark. <br>Cause: The incoming watermark path exceeds the byte size limit. <br>Solutions: The incoming watermark path should be less than 1024 bytes. */
    public const int ZEGO_ERROR_CODE_PUBLISHER_WATERMARK_URL_TOO_LONG = 1003056;

    /** Description: Failed to set publish watermark. <br>Cause: The incoming watermark path was entered incorrectly or the image format is not supported. <br>Solutions: Incoming the correct watermark path, only `jpg` and `png` image formats are supported. */
    public const int ZEGO_ERROR_CODE_PUBLISHER_WATERMARK_URL_INVALID = 1003057;

    /** Description: Incorrect watermark layout.<br>Caution: The layout area exceed the encoding resolution.<br>Solutions: Make sure the layout area cannot exceed the encoding resolution and call current interface. */
    public const int ZEGO_ERROR_CODE_PUBLISHER_WATERMARK_LAYOUT_INVALID = 1003058;

    /** Description: The publish stream encryption key is invalid.<br>Caution: The set encryption key length is not supported.<br>Solutions: The Publish-stream encryption key length to be 16/24/32 bytes. */
    public const int ZEGO_ERROR_CODE_PUBLISHER_ENCRYPTION_KEY_INVALID = 1003060;

    /** Description: StartPlayingStream failed.<br>Caution: In multi-room mode, the publish-stream function is called incorrectly.<br>Solutions: In multi-room mode, A publish-stream function with the parameter 'ZegoPublisherConfig' needs to be called. */
    public const int ZEGO_ERROR_CODE_PUBLISHER_ERROR_PUBLISH_WHEN_USING_MULTI_ROOM = 1003070;

    /** Description: StartPlayingStream failed.<br>Caution: In multi-room mode, the publish-stream function is called incorrectly.<br>Solutions: In multi-room mode, A publish-stream function parameter 'roomID' cannot be empty. */
    public const int
        ZEGO_ERROR_CODE_PUBLISHER_ERROR_PUBLISH_WITH_ROOM_ID_IS_NULL_WHEN_USING_MULTI_ROOM =
            1003071;

    /** Description: Unsupported video encoder.<br>Caution: There is no selected video encoder in the current SDK.<br>Solutions: Please contact ZEGO technical support. */
    public const int ZEGO_ERROR_CODE_PUBLISHER_VIDEO_ENCODER_NO_SUPPORTTED = 1003080;

    /** Description: Video encoder error.<br>Caution: Video encoder error.<br>Solutions: Please contact ZEGO technical support. */
    public const int ZEGO_ERROR_CODE_PUBLISHER_VIDEO_ENCODER_FAIL = 1003081;

    /** Description: Stream publishing failed due to system internal exceptions.<br>Caution: Stream publishing failed due to system internal exceptions.<br>Solutions: Please contact ZEGO technical support to solve the problem. */
    public const int ZEGO_ERROR_CODE_PUBLISHER_INNER_ERROR = 1003099;

    /** Description: Stream playing failed.<br>Caution: Possibly due to no data in the stream.<br>Solutions: Check to see if the publish-stream is working or try to play stream again, and if the problem is still not resolved, please contact ZEGO technical support to solve the problem. */
    public const int ZEGO_ERROR_CODE_PLAYER_PLAY_STREAM_FAILED = 1004001;

    /** Description: Stream playing failed.<br>Caution: The stream does not exist.<br>Solutions: Please check whether the remote end publish is indeed successful, or whether the publish and play environment are inconsistent. */
    public const int ZEGO_ERROR_CODE_PLAYER_PLAY_STREAM_NOT_EXIST = 1004002;

    /** Description: Stream playing error.<br>Caution: The number of streams the user attempted to play simultaneously exceeds the maximum number allowed.<br>Solutions: Currently, up to 12 steams can be played at the same time. Please contact ZEGO technical support to increase the capacity if necessary. */
    public const int ZEGO_ERROR_CODE_PLAYER_COUNT_EXCEED = 1004010;

    /** Description: Stream playing is temporarily interrupted.<br>Caution: Network exception.<br>Solutions: Please wait or check whether the network is normal. */
    public const int ZEGO_ERROR_CODE_PLAYER_ERROR_NETWORK_INTERRUPT = 1004020;

    /** Description: Failed to play the stream.<br>Caution: Publishing of this stream is prohibited by backend configuration.<br>Solutions: Please contact ZEGO technical support to solve the problem. */
    public const int ZEGO_ERROR_CODE_PLAYER_ERROR_SERVER_FORBID = 1004025;

    /** Description: Failed to capture the screenshot of the streaming screen, please check whether the stream to be captured is normal. <br>Cause: The stream is not pulled. <br>Solutions: Check whether it starts to play the stream, and whether there is an abnormality in the process of playing the stream. */
    public const int ZEGO_ERROR_CODE_PLAYER_TAKE_PLAY_STREAM_SNAPSHOT_FAILED = 1004030;

    /** Description: The play stream decryption key is invalid, the key length only supports 16/24/32 bytes. <br>Cause: The input key length is not 16/24/32 bytes. <br>Solutions: Adjust the input key length to 16/24/32 bytes. */
    public const int ZEGO_ERROR_CODE_PLAYER_DECRYPTION_KEY_INVALID = 1004060;

    /** Description: Pull stream decryption failed, please check whether the decryption key is correct. <br>Cause: Incorrect decryption key entered. <br>Solutions: Enter the correct decryption key. */
    public const int ZEGO_ERROR_CODE_PLAYER_DECRYPTION_FAILED = 1004061;

    /** Description: Calling the wrong function after enabling the multi-room function causes playing stream fail. <br>Cause: Called the playing stream function that only works for joining a single room mode. <br>Solutions: Please use the function of the same name with ZegoPlayerConfig and specify the room ID to play the stream. */
    public const int ZEGO_ERROR_CODE_PLAYER_ERROR_PLAY_STREAM_WHEN_USING_MULTI_ROOM = 1004070;

    /** Description: In the multi-room mode, the roomID parameter of the play stream cannot be empty. <br>Cause: The roomID parameter of the pull stream is empty. <br>Solutions: Please enter the correct roomID. */
    public const int
        ZEGO_ERROR_CODE_PLAYER_ERROR_PLAY_STREAM_WITH_ROOM_ID_IS_NULL_WHEN_USING_MULTI_ROOM =
            1004071;

    /** Description: When using the SDK to play the latency of live streaming, this error code will be returned if you have not subscribed to the low latency live streaming service. <br>Cause: Low-latency live broadcast service is not activated. <br>Solutions: Please contact ZEGO technical support staff to open the low-latency live broadcast service. */
    public const int ZEGO_ERROR_CODE_PLAYER_NOT_CONFIG_L3 = 1004072;

    /** Description: Unsupported video decoder.<br>Caution: There is no selected video decoder in the current SDK.<br>Solutions: Please contact ZEGO technical support. */
    public const int ZEGO_ERROR_CODE_PLAYER_VIDEO_DECODER_NO_SUPPORTTED = 1004080;

    /** Description: Video decoder fail.<br>Caution: Video decoder fail.<br>Solutions: Please contact ZEGO technical support. */
    public const int ZEGO_ERROR_CODE_PLAYER_VIDEO_DECODER_FAIL = 1004081;

    /** Description: An internal system exception causes a failure to pull the stream. <br>Cause: SDK internal error. <br>Solutions: Please contact ZEGO technical support. */
    public const int ZEGO_ERROR_CODE_PLAYER_INNER_ERROR = 1004099;

    /** Description: Does not support the use of stream mixing service. <br>Cause: No stream mixing service configured. <br>Solutions: Please open the service on the console or contact ZEGO business staff. */
    public const int ZEGO_ERROR_CODE_MIXER_NO_SERVICES = 1005000;

    /** Description: The mixing task ID is null. <br>Cause: The mixing task ID input when starting mixing task is empty. <br>Solutions: Please enter the correct mixing task ID. */
    public const int ZEGO_ERROR_CODE_MIXER_TASK_ID_NULL = 1005001;

    /** Description: The stream mixing task ID is too long. <br>Cause: The stream mixing task ID is greater than 256 bytes. <br>Solutions: Please enter a mixing task ID less than 256 bytes. */
    public const int ZEGO_ERROR_CODE_MIXER_TASK_ID_TOO_LONG = 1005002;

    /** Description: Invalid mixed flow task ID. <br>Cause: Illegal characters in the stream mixing task ID. <br>Solutions: Stream mixing task ID only supports numbers, English characters and'~','!','@','$','%','^','&','*','(',')', '_','+','=','-','`',';',''',',','.','<','>','/','\', please enter the stream mixing task ID in the correct format. */
    public const int ZEGO_ERROR_CODE_MIXER_TASK_ID_INVALID_CHARACTER = 1005003;

    /** Description: Illegal parameters exist in mixing task configuration. <br>Cause: 1. The mixing task ID is empty; 2. The mixing room ID is empty; 3. The mixing custom data length exceeds 1000 bytes; 4. The mixing output target stream is empty. <br>Solutions: Please check the configuration parameters of the mixing task. */
    public const int ZEGO_ERROR_CODE_MIXER_NO_OUTPUT_TARGET = 1005005;

    /** Description: Illegal format of mixed stream output target parameter. <br>Cause: When the target of the mixed stream output target is streamID, an illegal character is passed in. <br>Solutions: Please check whether the target of the mixed stream output target is of streamID type, if so, target only supports numbers, English characters and'~','!','@','$','%','^','&','*','(',')', '_','+','=','-','`',';',''',',','.','<','>','/','\'. */
    public const int ZEGO_ERROR_CODE_MIXER_OUTPUT_TARGET_INVALID = 1005006;

    /** Description: Failed to start the stream mixing task. <br>Cause: Requests are too frequent, exceeding the qps limit of the service. <br>Solutions: Please ensure that the qps of the mixing request is less than 100. */
    public const int ZEGO_ERROR_CODE_MIXER_START_REQUEST_ERROR = 1005010;

    /** Description: Failed to stop the stream mixing task. <br>Cause: May be the cause of the network error. <br>Solutions: Please check the network ring. */
    public const int ZEGO_ERROR_CODE_MIXER_STOP_REQUEST_ERROR = 1005011;

    /** The stream mixing task must be stopped by the user who started the task. This error code is deprecated. */
    public const int ZEGO_ERROR_CODE_MIXER_NOT_OWNER_STOP_MIXER = 1005012;

    /** Description: Starts stream mixing tasks too frequently. <br>Cause: Requests are too frequent, exceeding the qps limit of the service. <br>Solutions: Please ensure that the qps of the mixing request is less than 100. */
    public const int ZEGO_ERROR_CODE_MIXER_START_QPS_OVERLOAD = 1005015;

    /** Description: Stop stream mixing tasks too frequently. <br>Cause: Requests are too frequent, exceeding the qps limit of the service. <br>Solutions: Please ensure that the qps of the stop mixing request is less than 100. */
    public const int ZEGO_ERROR_CODE_MIXER_STOP_QPS_OVERLOAD = 1005016;

    /** Description: The input stream list of the stream mixing task is empty. <br>Cause:  The input stream list of the stream mixing task is empty. <br>Solutions: Please check the input stream list of the mixing task. */
    public const int ZEGO_ERROR_CODE_MIXER_INPUT_LIST_INVALID = 1005020;

    /** Description: The output stream list of the stream mixing task is empty. <br>Cause:  The output stream list of the stream mixing task is empty. <br>Solutions: Please check the output stream list of the mixing task. */
    public const int ZEGO_ERROR_CODE_MIXER_OUTPUT_LIST_INVALID = 1005021;

    /** Description: The video configuration of the stream mixing task is invalid. <br>Cause:  The video configuration of the stream mixing task is invalid. <br>Solutions: Please check the video configuration of the stream mixing task. */
    public const int ZEGO_ERROR_CODE_MIXER_VIDEO_CONFIG_INVALID = 1005023;

    /** Description: The video configuration of the stream mixing task is invalid. <br>Cause: 1. An unsupported audio codec format is used. 2. The audio bit rate exceeds 192 kbps. <br>Solutions: Please check the audio configuration of the stream mixing task. */
    public const int ZEGO_ERROR_CODE_MIXER_AUDIO_CONFIG_INVALID = 1005024;

    /** Description: The number of input streams exceeds the maximum number allowed. <br>Cause: Supports up to 9 input streams, and may pass more than 9 input streams. <br>Solutions: Please check the input stream configuration of the mixing task. */
    public const int ZEGO_ERROR_CODE_MIXER_EXCEED_MAX_INPUT_COUNT = 1005025;

    /** Description: Failed to start mixed stream. <br>Cause: The input stream does not exist. <br>Solutions: Please make sure that the stream corresponding to the entered streamID is being pushed. */
    public const int ZEGO_ERROR_CODE_MIXER_INPUT_STREAM_NOT_EXISTS = 1005026;

    /** Description: Failed to start mixed stream. <br>Cause: The mixed stream input parameter is wrong, it may be that the layout of the input stream exceeds the canvas range. <br>Solutions: Please enter the correct mixed stream parameters. [ZegoMixerTask] */
    public const int ZEGO_ERROR_CODE_MIXER_INPUT_PARAMETERS_ERROR = 1005027;

    /** Description: Failed to start mixed stream. <br>Cause: Exceeding the maximum number of output streams. <br>Solutions: Support up to 3 output streams. */
    public const int ZEGO_ERROR_CODE_MIXER_EXCEED_MAX_OUTPUT_COUNT = 1005030;

    /** Description: Failed to start mixed stream. <br>Cause: The maximum number of focus voice input streams is exceeded. <br>Solutions: Support up to 4 input streams to set the focus voice. */
    public const int ZEGO_ERROR_CODE_MIXER_EXCEED_MAX_AUDIO_FOCUS_STREAM_COUNT = 1005031;

    /** Description: Failed to start mixed stream. <br>Cause: Mixed-stream authentication failed. <br>Solutions: Contact ZEGO technical support. */
    public const int ZEGO_ERROR_CODE_MIXER_AUTHENTICATION_FAILED = 1005050;

    /** Description: Failed to start mixed stream. <br>Cause: The input image watermark is empty. <br>Solutions: Please enter the correct watermark parameters [ZegoWatermark]. */
    public const int ZEGO_ERROR_CODE_MIXER_WATERMARK_NULL = 1005061;

    /** Description: Failed to start mixed stream. <br>Cause: The input image watermark parameter is wrong, it may be that the layout exceeds the canvas range. <br>Solutions: Please enter the correct watermark parameters [ZegoWatermark]. */
    public const int ZEGO_ERROR_CODE_MIXER_WATERMARK_PARAMETERS_ERROR = 1005062;

    /** Description: Failed to start mixed stream. <br>Cause: The input watermark URL is illegal. <br>Solutions: The watermark URL must start with `preset-id://` and end with `.jpg` or `.png`. */
    public const int ZEGO_ERROR_CODE_MIXER_WATERMARK_URL_INVALID = 1005063;

    /** Description: Failed to start mixed stream. <br>Cause: The URL of the background image entered is illegal. <br>Solutions: The URL of the background image must start with preset-id:// and end with `.jpg` or `.png`. */
    public const int ZEGO_ERROR_CODE_MIXER_BACKGROUND_IMAGE_URL_INVALID = 1005067;

    /** Description: Failed to start mixed stream. <br>Cause: The user-defined data is too long. <br>Solutions: The maximum length of the custom input should not exceed 1000 bytes. */
    public const int ZEGO_ERROR_CODE_MIXER_USER_DATA_TOO_LONG = 1005068;

    /** Description: Failed to start mixed stream. <br>Cause: The auto-mixing server was not found. <br>Solutions: Please contact ZEGO technical support. */
    public const int ZEGO_ERROR_CODE_MIXER_AUTO_MIX_STREAM_SERVER_NOT_FOUND = 1005070;

    /** Description: Stream mixing internal error.<br>Cause: Unknown error occured in stream mixing internal.<br>Solutions: Please contact ZEGO technical support. */
    public const int ZEGO_ERROR_CODE_MIXER_INNER_ERROR = 1005099;

    /** Description: Generic device error.<br>Cause: Device dose not work normally.<br>Solutions: Use the system's video or audio recording application to check whether the device can work normally. If the device is normal, please contact ZEGO technical support. */
    public const int ZEGO_ERROR_CODE_DEVICE_ERROR_TYPE_GENERIC = 1006001;

    /** Description: The device ID does not exist.<br>Cause: The device ID is spelled incorrectly, or the corresponding device is unplugged.<br>Solutions: Please use the SDK interface to obtain the device ID, and check whether the device is properly connected. */
    public const int ZEGO_ERROR_CODE_DEVICE_ERROR_TYPE_INVALID_ID = 1006002;

    /** Description: No permission to access the device. <br>Cause: Did not apply for or obtain the permission to use the corresponding device.<br>Solutions: Please check whether the application has correctly applied for the camera or microphone permission, and whether the user has granted the corresponding permission. */
    public const int ZEGO_ERROR_CODE_DEVICE_ERROR_TYPE_NO_AUTHORIZATION = 1006003;

    /** Description: The frame rate of the capture device is 0.<br>Cause: Device error, or device does not have permission.<br>Solutions: Please use the system's video or audio recording application to check whether the device can work normally. Please check whether the application has correctly applied for the camera or microphone permission, and whether the user has granted the corresponding permission. If the device is normal and the application has obtained the corresponding device permissions, please contact ZEGO technical support. */
    public const int ZEGO_ERROR_CODE_DEVICE_ERROR_TYPE_ZERO_FPS = 1006004;

    /** Description: The device is occupied.<br>Cause: The device is occupied by other programs.<br>Solutions: Please use the system's video or audio recording application to check whether the device is working properly and make sure that the device is not occupied by other applications. */
    public const int ZEGO_ERROR_CODE_DEVICE_ERROR_TYPE_IN_USE_BY_OTHER = 1006005;

    /** Description: The device is unplugged.<br>Cause: The device is unplugged or not properly connected.<br>Solutions: Check the device wiring and reconnect the device. */
    public const int ZEGO_ERROR_CODE_DEVICE_ERROR_TYPE_UNPLUGGED = 1006006;

    /** Description: The device needs to be restarted.<br>Cause: Device driver update, or device error requires restart.<br>Solutions: Restart device. */
    public const int ZEGO_ERROR_CODE_DEVICE_ERROR_TYPE_REBOOT_REQUIRED = 1006007;

    /** Description: The device media is lost.<br>Cause: Media service cannot be restored.<br>Solutions: Restart device. */
    public const int ZEGO_ERROR_CODE_DEVICE_ERROR_MEDIA_SERVICES_LOST = 1006008;

    /** Description: The device list cannot be empty when trying to release devices.<br>Cause: The device list has been released or has not been initialized.<br>Solutions: Ignore it. */
    public const int ZEGO_ERROR_CODE_DEVICE_FREE_DEVICE_LIST_NULL = 1006020;

    /** Description: The set sound level monitoring interval is out of range.<br>Cause: The set sound level monitoring interval is less than 100 milliseconds, or greater than 3000 milliseconds.<br>Solutions: Reset the effective sound level monitoring interval, the effective sound level monitoring interval is [100, 3000], in milliseconds. */
    public const int ZEGO_ERROR_CODE_DEVICE_SOULD_LEVEL_INTERVAL_INVALID = 1006031;

    /** Description: The set audio spectrum monitoring interval is out of range.<br>Cause:  The set audio spectrum monitoring interval is less than 10 milliseconds.<br>Solutions: Reset audio spectrum monitoring interval which is not less than 10 milliseconds. */
    public const int ZEGO_ERROR_CODE_DEVICE_AUDIO_SPECTRUM_INTERVAL_INVALID = 1006032;

    /** Description: Failed to set the camera zoom. <br>Cause: The set camera zoom factor is out of range. <br>Solutions: The set camera zoom factor cannot exceed the maximum range obtained, the maximum range can be obtained through [getCameraMaxZoomFactor]. */
    public const int ZEGO_ERROR_CODE_DEVICE_ZOOM_FACTOR_INVALID = 1006040;

    /** Description: Failed to set the camera exposure compensation. <br>Cause: The set camera exposure compensation value is out of range. <br>Solutions: Set the camera exposure compensation range between [-1,1]. */
    public const int ZEGO_ERROR_CODE_DEVICE_EXPOSURE_COMPENSATION_VALUE_INVALID = 1006041;

    /** invalid audio VAD monitor type */
    public const int ZEGO_ERROR_CODE_DEVICE_AUDIO_VAD_STABLE_STATE_MONITOR_TYPE_INVALID = 1006042;

    /** Description: Internal error of the device. <br>Solutions: Contact ZEGO technical support. */
    public const int ZEGO_ERROR_CODE_DEVICE_INNER_ERROR = 1006099;

    /** Description: Unknown error of the pre-processing module. <br>Solutions: Please contact ZEGO technical support. */
    public const int ZEGO_ERROR_CODE_PREPROCESS_PREPROCESS_UNKNOWN_ERROR = 1007001;

    /** Description: Failed to set the beauty configuration. <br>Cause: The incoming beauty parameters are incorrect. <br>Solutions: Please check the passed in [ZegoBeautifyOption] type parameter. */
    public const int ZEGO_ERROR_CODE_PREPROCESS_BEAUTIFY_OPTION_INVALID = 1007005;

    /** The reverberation parameter is null. Please check the input parameter. This error code is deprecated. */
    public const int ZEGO_ERROR_CODE_PREPROCESS_REVERB_PARAM_NULL = 1007006;

    /** The voice changer parameter is null. Please check the input parameter. This error code is deprecated. */
    public const int ZEGO_ERROR_CODE_PREPROCESS_VOICE_CHANGER_PARAM_NULL = 1007007;

    /** Description: Failed to set the reverberation parameters. <br>Cause: the reverberation room size parameter is invalid. <br>Solutions: The normal range of the reverberation room size parameter is 0.0 ~ 1.0 */
    public const int ZEGO_ERROR_CODE_PREPROCESS_REVERB_PARAM_ROOM_SIZE_INVALID = 1007011;

    /** Description: Failed to set the reverberation parameters. <br>Cause: The reverberance parameter is invalid. <br>Solutions: The normal range of the reverberance parameter is 0.0 ~ 0.5 */
    public const int ZEGO_ERROR_CODE_PREPROCESS_REVERB_PARAM_REVERBERANCE_INVALID = 1007012;

    /** Description: Failed to set the reverberation parameters. <br>Cause: the reverberation damping parameter is invalid. <br>Solutions: The normal range of the reverberation damping parameter is 0.0 ~ 2.0 */
    public const int ZEGO_ERROR_CODE_PREPROCESS_REVERB_PARAM_DAMPING_INVALID = 1007013;

    /** Description: Failed to set the reverberation parameters. <br>Cause: The dry_wet_ratio parameter of the reverberation is invalid. <br>Solutions: The normal range of the dry_wet_ratio parameter of reverberation is greater than 0.0 */
    public const int ZEGO_ERROR_CODE_PREPROCESS_REVERB_PARAM_DRY_WET_RATIO_INVALID = 1007014;

    /** Description: Failed to start virtual stereo. <br>Cause: The virtual stereo angle parameter is invalid. <br>Solutions: The normal range of angle parameter is -1 ~ 360. */
    public const int ZEGO_ERROR_CODE_PREPROCESS_VIRTUAL_STEREO_ANGLE_INVALID = 1007015;

    /** Description: Failed to set the voice changing parameters. <br>Cause: The param setting of the voice changing parameter is invalid. <br>Solutions: The normal range of parameter param is -8.0 ~ 8.0 */
    public const int ZEGO_ERROR_CODE_PREPROCESS_VOICE_CHANGER_PARAM_INVALID = 1007016;

    /** The reverberation echo parameters is null. Please check the input parameter. */
    public const int ZEGO_ERROR_CODE_PREPROCESS_REVERB_ECHO_PARAM_NULL = 1007017;

    /** Description: Set reverberation echo parameters failed . <br>Cause: The reverberation echo parameters is invalid. <br> Solutions: Input the correct reverb echo parameters [setReverbEchoParam]. */
    public const int ZEGO_ERROR_CODE_PREPROCESS_REVERB_ECHO_PARAM_INVALID = 1007018;

    /** Description: Failed to turn on or turn off the electronic sound effect. <br>Cause: the initial pitch parameter tonal of the electronic tone is invalid. <br>Solutions: The normal range of the starting pitch parameter of the electronic tone is 0 ~ 11. */
    public const int ZEGO_ERROR_CODE_PREPROCESS_ELECTRONIC_EFFECTS_TONAL_INVALID = 1007019;

    /** Description: Failed to open or close the beauty environment. <br>Cause: The beauty environment was not turned on or off before the engine started. <br>Solutions: Please make sure to turn on or turn off the beauty environment before the engine starts, for example: before calling (startPreview), (startPublishingStream), (startPlayingStream), (createMediaPlayer) or (createAudioEffectPlayer). */
    public const int ZEGO_ERROR_CODE_PREPROCESS_ENABLE_EFFECTS_ENV_FAILED = 1007020;

    /** Description: Failed to turn on or turn off the beauty effect. <br>Cause: The beauty environment is not activated. <br>Solutions: Please call [startEffectsEnv] to start the beauty environment first. */
    public const int ZEGO_ERROR_CODE_PREPROCESS_ENABLE_EFFECTS_BEAUTY_FAILED = 1007021;

    /** Description: Failed to set beauty parameters. <br>Cause: The beauty environment is not activated. <br>Solutions: Please call [startEffectsEnv] to start the beauty environment first. */
    public const int ZEGO_ERROR_CODE_PREPROCESS_SET_EFFECTS_PARAM_FAILED = 1007022;

    /** Description: Effects Beauty does not support the currently set video data type. <br>Cause: [enableCustomVideoProcessing] interface, Windows platform only supports raw_data, Apple device only supports cv_pixel_buffer, Android platform supports gl_texture_2d. <br>Solutions: select the correct video data type. */
    public const int ZEGO_ERROR_CODE_PREPROCESS_NOT_SUPPORT_EFFECTS_BUFFER_TYPE = 1007023;

    /** Description: The MediaPlayer failed to play the media. <br>Cause: The resource file is not loaded. <br> Solutions: Create a media player instance before using media players [createMediaPlayer]. */
    public const int ZEGO_ERROR_CODE_MEDIA_PLAYER_NO_INSTANCE = 1008001;

    /** Description: The MediaPlayer failed to play the media. <br>Cause: The resource file is not loaded. <br> Solutions: The media player loads the media resource [loadResource] before starting. */
    public const int ZEGO_ERROR_CODE_MEDIA_PLAYER_NO_FILE_PATH = 1008003;

    /** Description: The MediaPlayer failed to load the file. <br>Cause: File formats are not supported. <br> Solutions: Files in this format are not supported, please use files in the supporting format. */
    public const int ZEGO_ERROR_CODE_MEDIA_PLAYER_FILE_FORMAT_ERROR = 1008005;

    /** Description: The MediaPlayer failed to load the file. <br>Cause: The file path does not exist. <br> Solutions: Check the validity of the media file path. */
    public const int ZEGO_ERROR_CODE_MEDIA_PLAYER_FILE_PATH_NOT_EXISTS = 1008006;

    /** Description: The MediaPlayer failed to load the file. <br>Cause: The file decoding failed. <br> Solutions: Check that the media file is corrupted or contact ZEGO technical support. */
    public const int ZEGO_ERROR_CODE_MEDIA_PLAYER_FILE_DECODE_ERROR = 1008007;

    /** Description: The MediaPlayer failed to load the file. <br>Cause: No supported audio/video stream exists. <br> Solutions: Check that the media file data is empty. */
    public const int ZEGO_ERROR_CODE_MEDIA_PLAYER_FILE_NO_SUPPORTED_STREAM = 1008008;

    /** Description: The copyrighted music resource file has expired. <br>Cause: The resource file has expired. <br>Solutions: Please request song or accompaniment again. */
    public const int ZEGO_ERROR_CODE_MEDIA_PLAYER_FILE_EXPIRED = 1008009;

    /** Description: The MediaPlayer failed to load the file. <br>Cause: There was an error during file resolution. <br> Solutions: Try again or contact ZEGO technical support. */
    public const int ZEGO_ERROR_CODE_MEDIA_PLAYER_DEMUX_ERROR = 1008010;

    /** Description: The MediaPlayer failed to seek. <br>Cause: The file hasn't been loaded yet. <br> Solutions: The media player loads the media resource [loadResource] before seeking [seekTo]. */
    public const int ZEGO_ERROR_CODE_MEDIA_PLAYER_SEEK_ERROR = 1008016;

    /** Description: The MediaPlayer is configured with a video data format not supported by the platform. <br>Cause: The MediaPlayer is configured with a video data format not supported by the platform (e.g., CVPixelBuffer on iOS does not support NV21). <br> Solutions: Check the data format [setVideoHandler] supported by the current media player platform and set the correct data format. */
    public const int ZEGO_ERROR_CODE_MEDIA_PLAYER_PLATFORM_FORMAT_NOT_SUPPORTED = 1008020;

    /** Description: The number of MediaPlayer instances exceeds the maximum number allowed. <br>Cause: The number of MediaPlayer instances exceeds the maximum number allowed. Up to 4 instances can be created. <br> Solutions: Media players can create up to 4 instances, and make sure that the number of media player instances is not exceeded the maximum limit. */
    public const int ZEGO_ERROR_CODE_MEDIA_PLAYER_EXCEED_MAX_COUNT = 1008030;

    /** Description: The media player failed to specify the audio track index. <br>Cause: The audio track index not exist. <br>Solutions: Check file audio track index call [getAudioTrackCount] can get. */
    public const int ZEGO_ERROR_CODE_MEDIA_PLAYER_SET_AUDIO_TRACK_INDEX_ERROR = 1008040;

    /** Description: Media player setting sound change parameter invalid. <br>Cause: Error setting parameters. <br>Solutions: Checking setting parameters control during -8.0 to 8.0 */
    public const int ZEGO_ERROR_CODE_MEDIA_PLAYER_SET_VOICE_CHANGER_PARAM_INVALID = 1008041;

    /** Description: takeSnapshot screenshot failed <br>Cause: The video is not playing or 'setPlayerCanvas' is not called to display the video to the control. <br>Solutions: Check whether the video plays normally(check [onPlayStart] callback) and the screen is displayed normally. */
    public const int ZEGO_ERROR_CODE_MEDIA_PLAYER_TAKE_SNAPSHOT_TIMING_ERROR = 1008042;

    /** Description: the passed parameter is not in the valid value range. <br>Cause: error setting parameters. <br>Solutions: Review the interface comment and pass in a value within the legal range. */
    public const int ZEGO_ERROR_CODE_MEDIA_PLAYER_PARAM_VALUE_RANGE_ILLEGAL = 1008043;

    /** Description: MediaPlayer internal error. <br>Cause: internal error. <br>Solutions: Contact Technical support. */
    public const int ZEGO_ERROR_CODE_MEDIA_PLAYER_INNER_ERROR = 1008099;

    /** Description: the input message content is empty <br>Cause: imessage content is empty <br>Solutions: Input a non-empty message. */
    public const int ZEGO_ERROR_CODE_IM_CONTENT_NULL = 1009001;

    /** Description: The input message content is too long <br>Cause: message more than 1024 bytes. <br>Solutions: The maximum length should be less than 1024 byte */
    public const int ZEGO_ERROR_CODE_IM_CONTENT_TOO_LONG = 1009002;

    /** Description: The input real-time sequential data is too long. <br>Cause: The length of the input data is greater than 4096 bytes. <br>Solution: Check the length of the input data, consider splitting the large data packet into multiple small data and sending it multiple times. */
    public const int ZEGO_ERROR_CODE_IM_DATA_TOO_LONG = 1009003;

    /** Description: The room where the message is sent is different from the room currently logged in. <br>Cause: The room where the message is sent is different from the room currently logged in. <br>Solutions: Send a message to the current logged-in room ID. */
    public const int ZEGO_ERROR_CODE_IM_INCONSISTENT_ROOM_ID = 1009005;

    /** Description: Failed to send the message. <br>Cause: network problems. <br>Solutions: Check the network. */
    public const int ZEGO_ERROR_CODE_IM_SEND_FAILED = 1009010;

    /** Description: Failed to send custom command. <br>Cause: The entered user ID is empty. <br>Solutions: Please enter the correct user ID. */
    public const int ZEGO_ERROR_CODE_IM_USER_ID_EMPTY = 1009011;

    /** Description: Failed to send custom signaling. <br>Cause: The entered user ID is too long. <br>Solutions: Please enter the correct user ID, the maximum user ID cannot exceed 64 bytes. */
    public const int ZEGO_ERROR_CODE_IM_USER_ID_TOO_LONG = 1009012;

    /** Description: Failed to send broadcast message,. <br>Cause: QPS exceeds the limit. <br>Solutions: Control the maximum QPS is 2 . */
    public const int ZEGO_ERROR_CODE_IM_BROADCAST_MESSAGE_QPS_OVERLOAD = 1009015;

    /** Description: The real-time sequential data manager instance creation failed. <br>Cause: A manager instance with this room ID has already been created. <br>Solution: A maximum of 1 instance can be created for each room ID. If you need to create multiple instances, please use other room IDs. */
    public const int ZEGO_ERROR_CODE_IM_MANAGER_CREATION_FAILED = 1009031;

    /** Description: The specified real-time sequential data manager instance could not be found. <br>Cause: This manager instance has not been created yet. <br>Solution: Please call the [createRealTimeSequentialDataManager] function to create a manager instance first. */
    public const int ZEGO_ERROR_CODE_IM_NO_MANAGER_INSTANCE = 1009032;

    /** Description: No publish channel available for broadcasting. <br>Cause: The developer has used all publish channels. <br>Solution: Do not use all the publish channels, check if there are any streams that can stop publsihing, or contact ZEGO technical support to increase the available publish channels. */
    public const int ZEGO_ERROR_CODE_IM_NO_AVAILABLE_BROADCAST_CHANNEL = 1009033;

    /** Description: The stream ID to start broadcasting is not available. <br>Cause: The stream ID has been used in this device for RTC business (e.g. [startPublishingStream] / [startPlayingStream]). <br>Solution: Please use another stream ID for broadcasting. */
    public const int ZEGO_ERROR_CODE_IM_NO_AVAILABLE_STREAM_ID = 1009034;

    /** Description: Repeat broadcast. <br>Cause: The developer repeatedly calls the [startBroadcasting] function. <br>Solution: Please check the business logic to avoid repeating the broadcast for the stream which is broadcasting. */
    public const int ZEGO_ERROR_CODE_IM_REPEAT_BROADCAST = 1009035;

    /** Description: The stream to stop broadcasting does not exist. <br>Cause: The stream ID set [stopBroadcasting] function is not in broadcasting. <br>Solution: Check if the stream ID is correct, or if the stream ID is not in broadcasting. */
    public const int ZEGO_ERROR_CODE_IM_NO_BROADCATING_STREAM = 1009036;

    /** Description: The stream to stop subscribing does not exist. <br>Cause: The stream ID set [stopSubscribing] function is not in subscribing. <br>Solution: Check if the stream ID is correct, or if the stream ID is not in subscribing. */
    public const int ZEGO_ERROR_CODE_IM_NO_SUBSCRIBING_STREAM = 1009037;

    /** Description: Repeat broadcast. <br>Cause: The developer repeatedly calls the [startBroadcasting] function. <br>Solution: Please check the business logic to avoid repeating the subscribe for the stream which is subscribing. */
    public const int ZEGO_ERROR_CODE_IM_REPEAT_SUBSCRIBE = 1009038;

    /** Description: Failed to send real-time sequential data. <br>Cause: The broadcast has not started yet, or the broadcast has encountered network problems. <br>Solution: Check whether [startBroadcasting] has been called to start broadcasting, or check whether the network is normal. */
    public const int ZEGO_ERROR_CODE_IM_REAL_TIME_SEQUENTIAL_DATA_SEND_FAILED = 1009039;

    /** Description: the file name suffix is not supported. <br>Cause: the file name suffix is not supported. <br>Solutions: only support .mp4/.aac/.flv. */
    public const int ZEGO_ERROR_CODE_RECORDER_FILE_SUFFIX_NAME_FORMAT_NOT_SUPPORT = 1010002;

    /** Description: Generic recording API error. <br>Cause: Invalid input parameter. <br> Solutions: Please check the record file path parameter or the record file format parameter is valid or not. */
    public const int ZEGO_ERROR_CODE_RECORDER_COMMON_LIVEROOM_API_ERROR = 1010003;

    /** Description: The specified recorded file path is too long. <br>Cause: The specified recorded file path is too long. The maximum length should be less than 1024 bytes. <br> Solutions: Please specify recorded file path less than 1024 bytes. */
    public const int ZEGO_ERROR_CODE_RECORDER_FILE_PATH_TOO_LONG = 1010011;

    /** Description: SDK internal error. <br>Cause: Internal error. <br> Solutions: Please contact ZEGO technical support. */
    public const int ZEGO_ERROR_CODE_RECORDER_INNER_VE_ERROR = 1010012;

    /** Description: Open file failed. <br>Cause: Invalid file path or no permissions to read/write file. <br> Solutions: Please specify a valid file path and has proper permissions to read/write. */
    public const int ZEGO_ERROR_CODE_RECORDER_OPEN_FILE_FAILED = 1010013;

    /** Description: Write file failed. <br>Cause: No permissions to write file. <br> Solutions: Please specify a valid file path and has proper permissions to write. */
    public const int ZEGO_ERROR_CODE_RECORDER_WRITE_FILE_ERROR = 1010014;

    /** Description: Insufficient disk space. <br>Cause: Insufficient disk space. <br> Solutions: Please ensure sufficient disk space. */
    public const int ZEGO_ERROR_CODE_RECORDER_NO_ENOUGH_SPARE_CAPACITY = 1010017;

    /** Description: File handle exception. <br>Cause: File handle exception. <br> Solutions: Please contact ZEGO technical support. */
    public const int ZEGO_ERROR_CODE_RECORDER_FILE_HANDLE_EXCEPTIONS = 1010018;

    /** Description: I/O exception. <br>Cause: I/O exception. <br> Solutions: Please contact ZEGO technical support. */
    public const int ZEGO_ERROR_CODE_RECORDER_IO_EXCEPTIONS = 1010019;

    /** Description: The custom video capturer is not created. <br>Cause: Create custom video capturer before onStart callback received. <br> Solutions: Please create custom video capturer after received onStart callback. */
    public const int ZEGO_ERROR_CODE_CUSTOM_VIDEO_IO_CAPTURER_NOT_CREATED = 1011001;

    /** Description: The custom video capture module is not enabled. <br>Cause: Custom video capture module is not enabled in initialization configurations. <br> Solutions: Please contact ZEGO technical support, make sure custom video capture module is enabled in initialization configurations. */
    public const int ZEGO_ERROR_CODE_CUSTOM_VIDEO_IO_NO_CUSTOM_VIDEO_CAPTURE = 1011002;

    /** Description: Failed to enable/disable custom video capture/rendering. <br>Cause: Not enable/disable custom video capture/rendering before engine is started. <br> Solutions: Please make sure to enable/disable custom video capture/rendering before engine is started, i.e., before calling (startPreview), (startPublishingStream), (startPlayingStream), (createMediaPlayer) or (createAudioEffectPlayer). */
    public const int ZEGO_ERROR_CODE_CUSTOM_VIDEO_IO_ENABLE_CUSTOM_IO_FAILED = 1011003;

    /** Description: The custom video capturer is not created. <br>Cause: Internal video-related modules are not created. <br> Solutions: Please call [startPreview] or [startPublishingStream] first. */
    public const int ZEGO_ERROR_CODE_CUSTOM_VIDEO_IO_PROCESS_MODULE_NOT_CREATED = 1011004;

    /** Description: The custom video process module is not enabled. <br>Cause: The custom video process module is not enabled. <br> Solutions: Call [enableCustomVideoProcessing] to enable a custom video capturermodule. */
    public const int ZEGO_ERROR_CODE_CUSTOM_VIDEO_IO_NO_CUSTOM_VIDEO_PROCESSING = 1011005;

    /** Description: The currently configured custom video capture format does not support this API. <br>Cause: The currently configured custom video capture format does not support this API. <br> Solutions: Please contact ZEGO technical support. */
    public const int ZEGO_ERROR_CODE_CUSTOM_VIDEO_IO_NOT_SUPPORTED_FORMAT = 1011010;

    /** Description: Custom video rendering does not support the currently set video buffer type. <br>Cause: The buffer_type in the config parameter of [enableCustomVideoRender] only supports raw_data, cv_pixel_buffer, encoded_data. For [enableCustomVideoProcessing], only raw_data is supported on Windows platform, only cv_pixel_buffer is supported on Apple devices, and gl_texture_2d and surface_texture are supported on Android platform. <br> Solutions: Select the correct video buffer type. */
    public const int ZEGO_ERROR_CODE_CUSTOM_VIDEO_IO_NOT_SUPPORTED_BUFFER_TYPE = 1011011;

    /** Description: Unsupported custom audio source type. <br>Cause: Only channel_aux supports zego_audio_source_type_media_player. <br> Solutions: Select the correct custom audio source type. */
    public const int ZEGO_ERROR_CODE_CUSTOM_AUDIO_IO_UNSUPPORTED_AUDIO_SOURCE_TYPE = 1012001;

    /** Description: The custom audio capture feature is not enabled. <br>Cause: The custom audio capture feature is not enabled. <br> Solutions: Please make sure that the custom audio IO module is enabled for the specified stream publishing channel. */
    public const int ZEGO_ERROR_CODE_CUSTOM_AUDIO_IO_CAPTURER_NOT_CREATED = 1012002;

    /** Description: The custom audio rendering feature is not enabled. <br>Cause: The custom audio rendering feature is not enabled. <br> Solutions: Please make sure that the custom audio IO module is enabled. */
    public const int ZEGO_ERROR_CODE_CUSTOM_AUDIO_IO_RENDERER_NOT_CREATED = 1012003;

    /** Description: Failed to enable/disable custom audio IO. <br>Cause: Failed to enable/disable custom audio IO. <br> Solutions: Please make sure to enable/disable it before the engine is started (i.e., before calling `startPreview`, `startPublishingStream` or `startPlayingStream`). */
    public const int ZEGO_ERROR_CODE_CUSTOM_AUDIO_IO_ENABLE_CUSTOM_AUDIO_IO_FAILED = 1012004;

    /** Description: The sample rate parameter is illegal. <br>Cause: Capture and render mix results recording does not support 8000, 22050, 24000 sample rates. <br> Solutions: Please confirm whether the sample rate parameter value allowed by the interface is legal. */
    public const int ZEGO_ERROR_CODE_CUSTOM_AUDIO_IO_AUDIO_DATA_CALLBACK_SAMPLE_RATE_NO_SUPPORT =
        1012010;

    /** Description: The MediaDataPublisher instance is not created. <br>Cause: The MediaDataPublisher instance is not created. <br> Solutions: Call [createMediaDataPublisher] to create a media pusher instance. */
    public const int ZEGO_ERROR_CODE_MEDIA_DATA_PUBLISHER_NO_INSTANCE = 1013000;

    /** Description: This error code is deprecated. <br>Cause: None. <br> Solutions: None. */
    public const int ZEGO_ERROR_CODE_MEDIA_DATA_PUBLISHER_FILE_PARSE_ERROR = 1013001;

    /** Description: This error code is deprecated. <br>Cause: None. <br> Solutions: None. */
    public const int ZEGO_ERROR_CODE_MEDIA_DATA_PUBLISHER_FILE_PATH_ERROR = 1013002;

    /** Description: File decoding exception. <br>Cause: Invalid media file format. <br>Solutions: Please check the file is a valid media file or not; check the file format is in the MediaPlayer support file format list or not. Please refer to https://doc-zh.zego.im/article/1153 for details. */
    public const int ZEGO_ERROR_CODE_MEDIA_DATA_PUBLISHER_FILE_CODEC_ERROR = 1013003;

    /** Description: Timestamp error. <br>Cause: the later frame timestamp is smaller than the previous frame timestamp. <br>Solutions: Please provide the media file, and contact ZEGO technical support. */
    public const int ZEGO_ERROR_CODE_MEDIA_DATA_PUBLISHER_TIMESTAMP_GO_BACK_ERROR = 1013004;

    /** Description: No audio effect player instance. <br>Cause: The audio effect player instance not created. <br> Solutions: Create an audio effect player instance before using it(createAudioEffectPlayer). */
    public const int ZEGO_ERROR_CODE_AUDIO_EFFECT_PLAYER_NO_INSTANCE = 1014000;

    /** Description: Load audio effect resource failed. <br>Cause: Invalid audio effect resource file. <br> Solutions: Check the file format is in the AudioEffectPlayer support file format list or not. Please refer to https://doc-zh.zego.im/article/5670 for details. */
    public const int ZEGO_ERROR_CODE_AUDIO_EFFECT_PLAYER_LOAD_FAILED = 1014001;

    /** Description: Play audio effect failed. <br>Cause: Invalid audio effect resource file. <br> Solutions: Check the file format is in the AudioEffectPlayer support file format list or not. Please refer to https://doc-zh.zego.im/article/5670 for details. */
    public const int ZEGO_ERROR_CODE_AUDIO_EFFECT_PLAYER_PLAY_FAILED = 1014002;

    /** Description: Change audio effect progress failed. <br>Cause: The audio effect progress value exceed audio effect file duration. <br> Solutions: Please check the audio effect progress value exceed audio effect file duration or not. */
    public const int ZEGO_ERROR_CODE_AUDIO_EFFECT_PLAYER_SEEK_FAILED = 1014003;

    /** Description: The number of instances of the audio effect player created exceeds the maximum limit. <br>Cause: The number of instances of the audio effect player created exceeds the maximum limit. <br> Solutions: Please check if the number of instances of the audio effect player created exceeds the maximum limit, the maximum number of instances allowed to be created is 12. */
    public const int ZEGO_ERROR_CODE_AUDIO_EFFECT_PLAYER_EXCEED_MAX_COUNT = 1014004;

    /** Description: Network connectivity test failed. <br>Cause: Not connected to the network. <br> Solutions: Please check if you can access the Internet properly. */
    public const int ZEGO_ERROR_CODE_UTILITIES_NETWORK_CONNECTIVITY_TEST_FAILED = 1015001;

    /** Description: Network speed test connection failure. <br>Cause: Not connected to the network. <br> Solutions: Please check if you can access the Internet properly. */
    public const int ZEGO_ERROR_CODE_UTILITIES_NETWORK_TOOL_CONNECT_SERVER_FAILED = 1015002;

    /** Description: RTP timeout. <br>Cause: Not connected to the network. <br> Solutions: Please check if you can access the Internet properly. */
    public const int ZEGO_ERROR_CODE_UTILITIES_NETWORK_TOOL_RTP_TIMEOUT_ERROR = 1015003;

    /** Description: The server side ends the network speed test. <br>Cause: Network speed test time is too long. <br> Solutions: Please stop network speed test in 3 minutes. */
    public const int ZEGO_ERROR_CODE_UTILITIES_NETWORK_TOOL_ENGINE_DENIED = 1015004;

    /** Description: Network speed test stopped. <br>Cause: Network speed test not stopped before publishing stream. <br> Solutions: Please stop network speed test(stopNetworkSpeedTest) before publishing stream. */
    public const int ZEGO_ERROR_CODE_UTILITIES_NETWORK_TOOL_STOPPED_BY_PUBLISHING_STREAM = 1015005;

    /** Description: Network speed test stopped. <br>Cause: Network speed test not stopped before playing stream. <br> Solutions: Please stop network speed test(stopNetworkSpeedTest) before playing stream. */
    public const int ZEGO_ERROR_CODE_UTILITIES_NETWORK_TOOL_STOPPED_BY_PLAYING_STREAM = 1015006;

    /** Description: Network speed test internal error. <br>Cause: Internal error. <br> Solutions: Please contact ZEGO technical support. */
    public const int ZEGO_ERROR_CODE_UTILITIES_NETWORK_TOOL_INNER_ERROR = 1015009;

    /** Description: Invalid system performance monitoring interval. <br>Cause: The set system performance monitoring interval is out of range. <br> Solutions: Please check if the system performance monitoring interval is out of range or not, valid range is [1000, 10000]. */
    public const int ZEGO_ERROR_CODE_UTILITIES_PERFORMANCE_MONITOR_INTERVAL_INVALID = 1015031;

    /** Description: Login to the room causes the network test to stop. <br>Cause: Already logged in to the room. <br>Solutions: Since the network test will take up bandwidth, please do it before logging in to the room. */
    public const int ZEGO_ERROR_CODE_UTILITIES_STOP_BY_LOGIN_ROOM = 1015032;

    /** Description: The function call failed. <br>Cause: No range auido instance has been created. <br>Solutions: Create a range audio instance. */
    public const int ZEGO_ERROR_CODE_RANGE_AUDIO_NO_INSTANCE = 1016000;

    /** Description: Failed to create range audio. <br>Cause: The instance exceeds the maximum limit. <br>Solutions: Use the used range audio example. */
    public const int ZEGO_ERROR_CODE_RANGE_AUDIO_EXCEED_MAX_COUNT = 1016001;

    /** Description: Failed to create range voice. <br>Cause: Range voice cannot be used in multi-room mode. <br>Solutions: Set the single-party mode. */
    public const int ZEGO_ERROR_CODE_RANGE_AUDIO_NOT_SUPPORT_MULTI_ROOM = 1016002;

    /** Description: Failed to set the team ID. <br>Cause: The input team ID exceeds the maximum limit. <br>Solutions: The input string is less than 64 bytes. */
    public const int ZEGO_ERROR_CODE_RANGE_AUDIO_TEAM_ID_TOO_LONG = 1016003;

    /** Description: Failed to set the team ID.<br>Cause: The input user ID contains invalid characters. <br>Solutions: User ID can only contains numbers, English characters and '~', '!', '@', '#', '$', '%', '^', '&', '*', '(', ')', '_', '+', '=', '-', '`', ';', ',', '.', '<', '>', '/', '\'. */
    public const int ZEGO_ERROR_CODE_RANGE_AUDIO_TEAM_ID_INVALID_CHARACTER = 1016004;

    /** Description: The command invalid. <br>Cause: The command entered by the [ZegoCopyrightedSendExtendedRequest] function is empty. <br>Solutions: Please check the command entered when calling the [ZegoCopyrightedSendExtendedRequest] function to make sure it is not empty. see https://doc-zh.zego.im/article/13610#1. */
    public const int ZEGO_ERROR_CODE_COPYRIGHTED_MUSIC_COMMAND_INVALID = 1017000;

    /** Description: The params invalid. <br>Cause: The params entered by the [ZegoCopyrightedSendExtendedRequest] function is empty. <br>Solutions: Please check the params entered when calling the [ZegoCopyrightedSendExtendedRequest] function to make sure it is not empty. */
    public const int ZEGO_ERROR_CODE_COPYRIGHTED_MUSIC_PARAMS_INVALID = 1017001;

    /** Description: The song_id invalid. <br>Cause: The song_id entered is empty. <br>Solutions: Please check the song_id entered when calling the function to make sure it is not empty.see https://doc-zh.zego.im/article/13610#1 */
    public const int ZEGO_ERROR_CODE_COPYRIGHTED_MUSIC_SONG_ID_INVALID = 1017002;

    /** Description: The share_token invalid. <br>Cause: The share_token entered is empty. <br>Solutions: Please check the share_token entered when calling the function to make sure it is not empty.share_token can be obtained by call [RequestAccompaniment] */
    public const int ZEGO_ERROR_CODE_COPYRIGHTED_MUSIC_SHARE_TOKEN_INVALID = 1017003;

    /** Description: The resource_id invalid. <br>Cause: The resource_id entered is empty. <br>Solutions: Please check the resource_id entered when calling the function to make sure it is not empty.resource_id can be obtained by call [RequestSong] [RequestAccompaniment] [GetMusicByToken] */
    public const int ZEGO_ERROR_CODE_COPYRIGHTED_MUSIC_RESOURCE_ID_INVALID = 1017004;

    /** Description: The start_position invalid. <br>Cause: The start_position entered by the fuction [ZegoCopyrightedMusicPlay] is invalid. <br>Solutions: Please check the start_position entered when calling the function [ZegoCopyrightedMusicPlay] to make sure it is in 0 ~ song duration. */
    public const int ZEGO_ERROR_CODE_COPYRIGHTED_MUSIC_START_POSITION_INVALID = 1017005;

    /** Description: The position invalid. <br>Cause: The position entered by the fuction [ZegoCopyrightedMusicSeek] is invalid. <br>Solutions: Please check the position entered when calling the function [ZegoCopyrightedMusicSeek] to make sure it is in 0 ~ song duration. */
    public const int ZEGO_ERROR_CODE_COPYRIGHTED_MUSIC_POSITION_INVALID = 1017006;

    /** Description: The volume invalid.. <br>Cause: The Volume entered by the fuction [ZegoCopyrightedMusicSetPlayVolume] is invalid. <br>Solutions: Please check the Volume entered when calling the function [ZegoCopyrightedMusicSetPlayVolume] to make sure it is in 0 ~ 200. */
    public const int ZEGO_ERROR_CODE_COPYRIGHTED_MUSIC_VOLUME_INVALID = 1017007;

    /** Description: The krcToken invalid. <br>Cause: The krcToken entered is empty. <br>Solutions: Please check the krcToken entered when calling the function to make sure it is not empty.krcToken can be obtained by call [RequestAccompaniment] */
    public const int ZEGO_ERROR_CODE_COPYRIGHTED_MUSIC_KRC_TOKEN_INVALID = 1017008;

    /** Description: Request copyrighted server fail. <br>Cause: The params entered make mistake or some network reasons. <br>Solutions: Please check the params entered and retry. */
    public const int ZEGO_ERROR_CODE_COPYRIGHTED_MUSIC_COPYRIGHTED_SERVER_FAIL = 1017010;

    /** Description: Free space limit. <br>Cause: Free space limit. <br>Solutions: Please clean up local files and make sure there is enough free disk space. */
    public const int ZEGO_ERROR_CODE_COPYRIGHTED_MUSIC_FREE_SPACE_LIMIT = 1017011;

    /** Description: Downloading. <br>Cause: Download same resource. <br>Solutions: Please wait for the resource to download successfully. */
    public const int ZEGO_ERROR_CODE_COPYRIGHTED_MUSIC_DOWNLOADING = 1017012;

    /** Description: Resource file not exist. <br>Cause: Resource file has been deleted. <br>Solutions: Please reload resource. */
    public const int ZEGO_ERROR_CODE_COPYRIGHTED_MUSIC_RESOURCE_FILE_NOT_EXIST = 1017013;

    /** Description: Resource file expired. <br>Cause: The resource file has expired. <br>Solutions: Please request song or accompaniment again. */
    public const int ZEGO_ERROR_CODE_COPYRIGHTED_MUSIC_RESOURCE_FILE_EXPIRED = 1017014;

    /** Description: Resource file invalid. <br>Cause: File is corrupted <br>Solutions: Please call [load] function to reload media resource. */
    public const int ZEGO_ERROR_CODE_COPYRIGHTED_MUSIC_RESOURCE_FILE_INVALID = 1017015;

    /** Description: The resource_id unauthorized. <br>Cause: When [load] is called to load resources, the resource_id is unauthorization. <br>Solutions: Please call the [requestSong] [requestAccompaniment] [getMusicByToken] function before call [load] function to load resource. */
    public const int ZEGO_ERROR_CODE_COPYRIGHTED_MUSIC_RESOURCE_ID_UNAUTHORIZED = 1017018;

    /** Description: No copyright, unable to listen to and sing songs. <br>Cause: No copyright. <br>Solutions: Please select another music. */
    public const int ZEGO_ERROR_CODE_COPYRIGHTED_MUSIC_NO_COPYRIGHT = 1017030;

    /** Description: No permissions of accompaniment, can only listen to songs, not sing. <br>Cause: No permissions of accompaniment. <br>Solutions: Please select another music. */
    public const int ZEGO_ERROR_CODE_COPYRIGHTED_MUSIC_NO_PERMISSIONS_OF_LYRICS_AND_MUSIC = 1017031;

    /** Description: Non monthly membership. <br>Cause: Unopened monthly membership. <br>Solutions: Open monthly membership or ues COUNT mode request music. */
    public const int ZEGO_ERROR_CODE_COPYRIGHTED_MUSIC_NON_MONTHLY_MEMBERSHIP = 1017032;

    /** Description: No accompany. <br>Cause: Music don't have accompany. <br>Solutions: Please choice music have accompany. */
    public const int ZEGO_ERROR_CODE_COPYRIGHTED_MUSIC_NO_ACCOMPANY = 1017033;

    /** Description: Resource not exist. <br>Cause: Resource not exist. <br>Solutions: Please select another music. */
    public const int ZEGO_ERROR_CODE_COPYRIGHTED_MUSIC_RESOURCE_NOT_EXIST = 1017034;

    /** Description: Illegal param. <br>Cause: The entered param is incorrect. <br>Solutions: Please check param when entered function to make sure it is correct. */
    public const int ZEGO_ERROR_CODE_COPYRIGHTED_MUSIC_ILLEGAL_PARAM = 1017040;

    /** Description: AppID invalid. <br>Cause: The appID is not support copyrighted music. <br>Solutions: Please contact ZEGO technical support. */
    public const int ZEGO_ERROR_CODE_COPYRIGHTED_MUSIC_APPID_INVALID = 1017041;

    /** Description: Billing mode invalid. <br>Cause: Billing mode invalid. <br>Solutions: Please select correct billing mode. */
    public const int ZEGO_ERROR_CODE_COPYRIGHTED_MUSIC_BILLING_MODE_INVALID = 1017042;

    /** Description: Unreasonable_access. <br>Cause: Monthly membership request music by COUNT. <br>Solutions: Please select correct billing mode. */
    public const int ZEGO_ERROR_CODE_COPYRIGHTED_MUSIC_UNREASONABLE_ACCESS = 1017043;

    /** Description: Share token expired. <br>Cause: Share token expired. <br>Solutions: Please select an unexpired sharing token to get resources. */
    public const int ZEGO_ERROR_CODE_COPYRIGHTED_MUSIC_SHARE_TOKEN_EXPIRED = 1017044;

    /** Description: Share token illegal. <br>Cause: Share token illegal. <br>Solutions: Please check songToken when entered by calling [getMusicByToken] to make sure it is correct. */
    public const int ZEGO_ERROR_CODE_COPYRIGHTED_MUSIC_SHARE_TOKEN_ILLEGAL = 1017045;

    /** Description: krcToken illegal. <br>Cause: krcToken illegal. <br>Solutions: Please check krcToken when entered by calling [getKrcLyricByKrcToken] to make sure it is correct. */
    public const int ZEGO_ERROR_CODE_COPYRIGHTED_MUSIC_KRC_TOKEN_ILLEGAL = 1017046;

    /** Description: krcToken expired. <br>Cause: krcToken expired. <br>Solutions: Please select an unexpired krcToken to get lyrics in KRC format. */
    public const int ZEGO_ERROR_CODE_COPYRIGHTED_MUSIC_KRC_TOKEN_EXPIRED = 1017047;

    /** Description: Get lyric fail. <br>Cause: Lyrics not found. <br>Solutions: Please try again later. */
    public const int ZEGO_ERROR_CODE_COPYRIGHTED_MUSIC_GET_LYRIC_FAIL = 1017048;

    /** Description: The copyright music module is not initialized. <br>Cause: The [InitCopyrightedMusic] method is not called to initialize the copyright module. <br>Solutions: Please call the [InitCopyrightedMusic] method first. */
    public const int ZEGO_ERROR_CODE_COPYRIGHTED_MUSIC_NO_INIT = 1017096;

    /** Description: System is busy. <br>Cause: System is busy. <br>Solutions: Please try again. */
    public const int ZEGO_ERROR_CODE_COPYRIGHTED_MUSIC_SYSTEM_BUSY = 1017097;

    /** Description: Failed due to network exceptions.<br>Cause: Unknown internal error.<br>Solutions: Contact ZEGO technical support to deal with it. */
    public const int ZEGO_ERROR_CODE_COPYRIGHTED_MUSIC_NETWORK_ERROR = 1017098;

    /** Description: Failed due to internal system exceptions.<br>Cause: Unknown internal error.<br>Solutions: Contact ZEGO technical support to deal with it. */
    public const int ZEGO_ERROR_CODE_COPYRIGHTED_MUSIC_INNER_ERROR = 1017099;
}
}
