using System.Runtime.InteropServices;
using System;
using System.Collections.Generic;
using System.Collections.Concurrent;

namespace ZEGO
{
    public class ZegoConstans
    {


        public const string LIB_NAME = "ZegoExpressEngine";
        public const string ZEGO_CALLBACK_GAME_OBJ_NAME = "ZEGO_CALLBACK_GAME_OBJECT";

        public const CallingConvention ZEGO_CALINGCONVENTION = CallingConvention.Cdecl;
        public const int ZEGO_EXPRESS_MAX_COMMON_LEN = 512;
        public const int ZEGO_EXPRESS_MAX_APPSIGN_LEN = 64;
        public const int ZEGO_EXPRESS_MAX_USERID_LEN = 64;
        public const int ZEGO_EXPRESS_MAX_USERNAME_LEN = 256;
        public const int ZEGO_EXPRESS_MAX_ROOMID_LEN = 128;
        public const int ZEGO_EXPRESS_MAX_TOKEN_LEN = 512;
        public const int ZEGO_EXPRESS_MAX_MIX_INPUT_COUNT = 12;
        public const int ZEGO_EXPRESS_MAX_STREAM_LEN = 256;
        public const int ZEGO_EXPRESS_MAX_MIXER_TASK_LEN = 256;
        public const int ZEGO_EXPRESS_MAX_EXTRA_INFO_LEN = 1024;
        public const int ZEGO_EXPRESS_MAX_DEVICE_ID_LEN = 256;
        public const int ZEGO_EXPRESS_MAX_URL_COUNT = 10;
        public const int ZEGO_EXPRESS_MAX_URL_LEN = 1024;
        public const int ZEGO_EXPRESS_MAX_IMAGE_PATH = 512;
        public const int ZEGO_EXPRESS_MAX_MESSAGE_LEN = 1024;
        public const int ZEGO_EXPRESS_MAX_CUSTOM_CMD_LEN = 1024;
        public const int ZEGO_EXPRESS_MAX_MEDIAPLAYER_INSTANCE_COUNT = 4;
        public const string MOUDLE = "dotnet";

        //module
        /// ZEGO_EXPRESS_MODULE_COMMON -> (0)
        public const int ZEGO_EXPRESS_MODULE_COMMON = 0;

        /// ZEGO_EXPRESS_MODULE_ENGINE -> (1)
        public const int ZEGO_EXPRESS_MODULE_ENGINE = 1;

        /// ZEGO_EXPRESS_MODULE_ROOM -> (2)
        public const int ZEGO_EXPRESS_MODULE_ROOM = 2;

        /// ZEGO_EXPRESS_MODULE_PUBLISHER -> (3)
        public const int ZEGO_EXPRESS_MODULE_PUBLISHER = 3;

        /// ZEGO_EXPRESS_MODULE_PLAYER -> (4)
        public const int ZEGO_EXPRESS_MODULE_PLAYER = 4;

        /// ZEGO_EXPRESS_MODULE_MIXER -> (5)
        public const int ZEGO_EXPRESS_MODULE_MIXER = 5;

        /// ZEGO_EXPRESS_MODULE_DEVICE -> (6)
        public const int ZEGO_EXPRESS_MODULE_DEVICE = 6;

        /// ZEGO_EXPRESS_MODULE_PREPROCESS -> (7)
        public const int ZEGO_EXPRESS_MODULE_PREPROCESS = 7;

        /// ZEGO_EXPRESS_MODULE_MEDIAPLAYER -> (8)
        public const int ZEGO_EXPRESS_MODULE_MEDIAPLAYER = 8;

        /// ZEGO_EXPRESS_MODULE_IM -> (9)
        public const int ZEGO_EXPRESS_MODULE_IM = 9;

        /// ZEGO_EXPRESS_MODULE_RECORD -> (10)
        public const int ZEGO_EXPRESS_MODULE_RECORD = 10;

        /// ZEGO_EXPRESS_MODULE_CUSTOMVIDEOIO -> (11)
        public const int ZEGO_EXPRESS_MODULE_CUSTOMVIDEOIO = 11;

        /// ZEGO_EXPRESS_MODULE_CUSTOMAUDIOIO -> (12)
        public const int ZEGO_EXPRESS_MODULE_CUSTOMAUDIOIO = 12;

        /// ZEGO_EXPRESS_MODULE_MEDIAPUBLISHER -> (13)
        public const int ZEGO_EXPRESS_MODULE_MEDIAPUBLISHER = 13;


    }
    public enum ZegoMixerInputContentType
    {

        Audio,

        Video,
    }

    public enum ZegoEngineState
    {
        Start,
        Stop
    }

    public enum ZegoVideoBufferType
    {
        Unknown = 0,
        RawData = 1,
    }

    public enum ZegoCustomVideoRenderSeries
    {
        RGB,
        YUV
    }

    // MODULE: ENGINE
    public enum ZegoScenario
    {
        /** General scenario */
        General,
        /** Communication scenario */
        Communication,
        /** Live scenario */
        Live
    }
    public enum ZegoLanguage
    {
        English,
        Chinese
    }
    public enum ZegoRoomState
    {
        Disconnected,
        Connecting,
        Connected
    }
    public enum ZegoUpdateType
    {
        /** Add */
        TypeAdd,
        /** Delete */
        Delete
    }

    public enum ZegoPublisherState
    {
        /** The state is not published, and it is in this state before publishing the stream. If a steady-state exception occurs in the publish process, such as AppID and AppSign are incorrect, or if other users are already publishing the stream, there will be a failure and enter this state. */
        NoPublish,
        /** The state that it is requesting to publish the stream. After the publish stream interface is successfully called, and the application interface is usually displayed using the state. If the connection is interrupted due to poor network quality, the SDK will perform an internal retry and will return to the requesting state. */
        PublishRequesting,
        /** The state that the stream is being published, entering the state indicates that the stream has been successfully published, and the user can communicate normally. */
        Publishing
    }
    public enum ZegoPublishChannel
    {
        /** Main publish channel */
        Main,
        /** Main publish channel */
        Aux
    }
    /** Video frame flip mode */
    public enum ZegoVideoFlipMode
    {
        /** No flip */
        None,
        /** X-axis flip */
        ModeX,
        /** Y-axis flip */
        ModeY,
        /** X and Y-axis flip */
        ModeXY,
    }

    public enum ZegoVideoFrameFormat
    {
        Unknown,
        I420,
        NV12,
        NV21,
        BGRA32,
        RGBA32,
        ARGB32,
        ABGR32,
        I422
    }
    public enum ZegoOrientation
    {
        /** Not rotate */
        ZegoOrientation_0,
        /** Rotate 90 degrees counterclockwise */
        ZegoOrientation_90,
        /** Rotate 180 degrees counterclockwise */
        ZegoOrientation_180,
        /** Rotate 270 degrees counterclockwise */
        ZegoOrientation_270
    }
    public enum ZegoPlayerState
    {
        /** The state of the flow is not played, and it is in this state before the stream is played. If the steady flow anomaly occurs during the playing process, such as AppID and AppSign are incorrect, it will enter this state. */
        NoPlay,
        /** The state that the stream is being requested for playing. After the stream playing interface is successfully called, it will enter the state, and the application interface is usually displayed using this state. If the connection is interrupted due to poor network quality, the SDK will perform an internal retry and will return to the requesting state. */
        PlayRequesting,
        /** The state that the stream is being playing, entering the state indicates that the stream has been successfully played, and the user can communicate normally. */
        Playing
    }


    public enum ZegoMediaPlayerInstanceIndex
    {

        /// ZegoMediaPlayerInstanceIndex_null -> -1
        Null = -1,

        /// ZegoMediaPlayerInstanceIndex_first -> 0
        First = 0,

        /// ZegoMediaPlayerInstanceIndex_second -> 1

        Second = 1,

        /// ZegoMediaPlayerInstanceIndex_third -> 2
        Third = 2,

        /// ZegoMediaPlayerInstanceIndex_forth -> 3
        Forth = 3,
    }
    public enum ZegoStreamQuality
    {

        Excellent,

        Good,

        Medium,

        Bad,

        Die,
    }
    public enum ZegoMediaPlayerState
    {

        NoPlay,

        Playing,

        Pausing,

        PlayEnd,
    }

    public enum ZegoMediaPlayerNetworkEvent
    {

        BufferBegin,

        BufferEnd,
    }
    public enum ZegoAudioChannel
    {
        Unknown,

        Mono,

        Stereo,
    }


    public enum ZegoTrafficControlMinVideoBitrateMode
    {
        /** Stop video transmission when current bitrate is lower than the set minimum bitrate */
        NoVideo,
        /** Video is sent at a very low frequency (no more than 2fps) which is lower than the set minimum bitrate */
        UltraLowFps,
    }

    public enum ZegoVideoMirrorMode
    {
        /** The mirror image only for previewing locally. This mode is used by default. */
        OnlyPreviewMirror,
        /** Both the video previewed locally and the far end playing the stream will see mirror image. */
        BothMirror,
        /** Both the video previewed locally and the far end playing the stream will not see mirror image. */
        NoMirror,
        /** The mirror image only for far end playing the stream. */
        OnlyPublishMirror,
    }



    public enum ZegoVideoCodecId
    {

        Default,

        SVC,

        VP8,
    }





    public enum ZegoAudioCodecId
    {

        Default,

        Normal,

        Normal2,

        Normal3,

        Low,

        Low2,

        Low3,
    }
    public enum ZegoCapturePipelineScaleMode
    {
        /** Zoom immediately after acquisition, default */
        PreScale,
        /** Scaling while encoding */
        PostScale
    }


    public enum ZegoPlayerMediaEvent
    {
        /** Audio stuck event when playing */
        AudioBreakOccur,
        /** Audio stuck event recovery when playing */
        AudioBreakResume,
        /** Video stuck event when playing */
        VideoBreakOccur,
        /** Video stuck event recovery when playing */
        VideoBreakResume
    }

    public enum ZegoPlayerVideoLayer
    {
        /** The layer to be played depends on the network status */
        Auto,
        /** Play the base layer (small resolution) */
        Base,
        /** Play the extend layer (big resolution) */
        Extend,
    }


    public enum ZegoStreamRelayCdnState
    {
        /** The state indicates that there is no CDN relay */
        NoRelay,
        /** The CDN relay is being requested */
        RelayRequesting,
        /** Entering this status indicates that the CDN relay has been successful */
        Relaying,
    }

    public enum ZegoStreamRelayCdnUpdateReason
    {
        /** No error */
        None,
        /** Server error */
        ServerError,
        /** Handshake error */
        HandshakeFailed,
        /** Access point error */
        AccessPointError,
        /** Stream create failure */
        CreateStreamFailed,
        /** Bad name */
        BadName,
        /** CDN server actively disconnected */
        CdnServerDisconnected,
        /** Active disconnect */
        Disconnected,
    }

    /** 美颜特性 */
    public enum ZegoBeautifyFeature
    {
        /** No beautifying */
        None = 0,
        /** Polish */
        Polish = 1,
        /** Whiten */
        Whiten = 2,
        /** Skin whiten */
        SkinWhiten = 4,
        /** Sharpen */
        Sharpen = 8

    }



    public enum ZegoViewMode
    {

        Fit,

        AspectFill,

        ScaleToFill
    }


    public class ZegoAudioConfig
    {
        /// int
        /** Audio bitrate in kbps, default is 48 kbps */
        public int bitrate;

        /// ZegoAudioChannel
         /** Audio channel, default is Mono */
        public ZegoAudioChannel channel;

        /// ZegoAudioCodecId
        /** codec ID, default is ZegoAudioCodecIDDefault */
        public ZegoAudioCodecId audioCodecId;

        /**
         * Create a default audio configuration (ZegoAudioConfigPresetStandardQuality, 48 kbps, Mono, ZegoAudioCodecIDDefault)
         */
        public ZegoAudioConfig() : this(ZegoAudioConfigPreset.StandardQuality)
        {

        }

        /**
         * Create a audio configuration with preset enumeration values
         */
        public ZegoAudioConfig(ZegoAudioConfigPreset presetType)
        {
            audioCodecId = ZegoAudioCodecId.Default;
            switch (presetType)
            {
                case ZegoAudioConfigPreset.BasicQuality:
                    bitrate = 16;
                    channel = ZegoAudioChannel.Mono;
                    break;
                case ZegoAudioConfigPreset.StandardQuality:
                    bitrate = 48;
                    channel = ZegoAudioChannel.Mono;
                    break;
                case ZegoAudioConfigPreset.StandardQualityStereo:
                    bitrate = 56;
                    channel = ZegoAudioChannel.Stereo;
                    break;
                case ZegoAudioConfigPreset.HighQuality:
                    bitrate = 128;
                    channel = ZegoAudioChannel.Mono;
                    break;
                case ZegoAudioConfigPreset.HighQualityStereo:
                    bitrate = 192;
                    channel = ZegoAudioChannel.Stereo;
                    break;
            }
        }
    }
    public class ZegoBarrageMessageInfo
    {
        /// char[512]
        /** message content */
        public string message;

        /// char[64]
        /** message id */
        public string messageId;

        /** Message send time */
        public ulong sendTime;
        /// zego_user
        /** Message sender */
        public ZegoUser fromUser;
    }
    public class ZegoBeautifyOption
    {
        /// double
        /** The sample step size of beauty peeling, the value range is [0,1], default 0.2 */
        public double polishStep;

        /// double
        /** Brightness parameter for beauty and whitening, the larger the value, the brighter the brightness, ranging from [0,1], default 0.5 */
        public double whitenFactor;

        /// double
        /** Beauty sharpening parameter, the larger the value, the stronger the sharpening, value range [0,1], default 0.1 */
        public double sharpenFactor;
    }
    public class ZegoBroadcastMessageInfo
    {
        /// char[512]
        /** message content */
        public string message;

        /// char[64]
        /** message id */

        public ulong messageId;

        /** Message send time */
        public ulong sendTime;

        /// zego_user
        /** Message sender */
        public ZegoUser fromUser;
    }

    public class ZegoCDNConfig
    {
        /// char[1024]
        /** CDN URL */
        public string url;

        /// char[512]
        /** Auth param of URL */
        public string authParam;
    }
    /**
    * Advanced engine configuration
    *
    * When you need to use the advanced functions of SDK, such as custom video capture, custom video rendering and other advanced functions, you need to set the instance corresponding to the advanced function configuration to the corresponding field of this type of instance to achieve the purpose of enabling the corresponding advanced functions of ZegoExpressEngine.
    * The configuration of the corresponding advanced functions needs to be set before [createEngine], and it is invalid to set after [createEngine].
    */
    public class ZegoEngineConfig
    {
        /** Log configuration, if not set, use the default configuration */
        public ZegoLogConfig logConfig;
        /** Other special function switches, if not set, no other special functions are used by default. The special functions referred to here do not include the functions listed in the other parameter fields of the custom video capture function and custom video rendering described above. */
        public Dictionary<string, string> advancedConfig;
    }
    public class ZegoLogConfig
    {
        /// char[512]
        /** Log file save path */
        public string logPath;
        /// ULONGLONG->unsigned __int64
        /** The maximum log file size (Bytes). The default maximum size is 5MB (5 * 1024 * 1024 Bytes) */
        public ulong logSize;
    }
    public class ZegoPlayerConfig
    {
        /** The CDN configuration for playing stream. If set, the stream is play according to the URL instead of the streamID. After that, the streamID is only used as the ID of SDK internal onLoadResourceCallback. */
        public ZegoCDNConfig cDNConfig;
        /** Set the video layer for playing the stream */
        public ZegoPlayerVideoLayer videoLayer;
    }


    public class ZegoPlayStreamQuality
    {
        /// zego_stream_quality
        /** Published stream quality level */
        public ZegoStreamQuality quality;

        /// double
        /** Video reception frame rate. The unit of frame rate is f/s */
        public double videoRecvFps;

        /// double
        /** Video decoding frame rate. The unit of frame rate is f/s */
        public double videoDecodeFps;

        /// double
        /** Video rendering frame rate. The unit of frame rate is f/s */
        public double videoRenderFps;

        /// double
        /** Video bit rate in kbps */
        public double videoKbps;

        /// double
        /** Audio reception frame rate. The unit of frame rate is f/s */
        public double audioRecvFps;

        /// double
        /** Audio decoding frame rate. The unit of frame rate is f/s */
        public double audioDecodeFps;

        /// double
        /** Audio rendering frame rate. The unit of frame rate is f/s */
        public double audioRenderFps;

        /// double
        /** Audio bit rate in kbps */
        public double audioKbps;

        /// int
        /** Server to local delay, in milliseconds */
        public int rtt;

        /// double
        /** Packet loss rate, in percentage, 0.0 ~ 1.0 */
        public double packetLostRate;

        /// int
        /** Delay from peer to peer, in milliseconds */
        public int peerToPeerDelay;

        /// double
        /** Packet loss rate from peer to peer, in percentage, 0.0 ~ 1.0 */
        public double peerToPeerPktLostRate;

        /// int
        /** Delay after the data is received by the local end, in milliseconds */
        public int delay;

        /// boolean
        /** Whether to enable hardware decoding */
        public bool isHardwareDecode;

        /// double
        /** Total number of bytes received, including audio, video, SEI */
        public double totalRecvBytes;

        /// double
        /** Number of audio bytes received */
        public double audioRecvBytes;

        /// double
        /** Number of video bytes received */
        public double videoRecvBytes;
    }



    public class ZegoPublishStreamQuality
    {
        /// zego_stream_quality
        /** Published stream quality level */
        public ZegoStreamQuality quality;

        /// double
        /** Video capture frame rate. The unit of frame rate is f/s */
        public double videoCaptureFps;

        /// double
         /** Video encoding frame rate. The unit of frame rate is f/s */
        public double videoEncodeFps;

        /// double
        /** Video transmission frame rate. The unit of frame rate is f/s */
        public double videoSendFps;

        /// double
        /** Video bit rate in kbps */
        public double videoKbps;

        /// double
         /** Audio capture frame rate. The unit of frame rate is f/s */
        public double audioCaptureFps;

        /// double
        /** Audio transmission frame rate. The unit of frame rate is f/s */
        public double audioSendFps;

        /// double
        /** Audio bit rate in kbps */
        public double audioKbps;

        /// int
        /** Local to server delay, in milliseconds */
        public int rtt;

        /// double
        /** Packet loss rate, in percentage, 0.0 ~ 1.0 */
        public double packetLostRate;

        /// boolean
        /** Whether to enable hardware encoding */
        public bool isHardwareEncode;

        /// double
        /** Total number of bytes sent, including audio, video, SEI */
        public double totalSendBytes;

        /// double
        /** Number of audio bytes sent */
        public double audioSendBytes;

        /// double
        /** Number of video bytes sent */
        public double videoSendBytes;
    }
    public class ZegoRect
    {
        /// int
        public int left;

        /// int
        public int top;

        /// int
        public int right;

        /// int
        public int bottom;
        public ZegoRect()
        {

        }
        public ZegoRect(int left, int top, int right, int bottom)
        {
            this.left = left;
            this.top = top;
            this.right = right;
            this.bottom = bottom;
        }
    }

    public class ZegoRoomConfig
    {
        /** The maximum number of users in the room, Passing 0 means unlimited, the default is unlimited. */
        public uint maxMemberCount;
        /** Whether to enable the user in and out of the room onLoadResourceCallback notification [onRoomUserUpdate], the default is off. */
        public bool isUserStatusNotify;
        /** The token issued by the developer's business server is used to ensure security. The generation rules are detailed in [https://doc.zego.im/CN/565.html](https://doc.zego.im/CN/565.html). Default is empty string, that is, no authentication */
        public string token;
    }
    public class ZegoStream
    {
        /** User object instance */
        public ZegoUser user;

        /** Stream ID, a string of up to 256 characters. You cannot include URL keywords, otherwise publishing stream and playing stream will fails. Only support numbers, English characters and '~', '!', '@', '#', '$', '%', '^', '&', '*', '(', ')', '_', '+', '=', '-', '`', ';', '’', ',', '.', '<', '>', '/', '\'. */

        public string streamId;



        /** Stream extra info */

        public string extraInfo;

    }
    public class ZegoStreamRelayCDNInfo
    {
        /// char[1024]
        /** URL of publishing stream to CDN */

        public string url;

        /// zego_stream_relay_cdn_state
        /** State of relaying to CDN */
        public ZegoStreamRelayCdnState cdnState;

        /// zego_stream_relay_cdn_update_reason
        /** Reason for relay state changed */
        public ZegoStreamRelayCdnUpdateReason updateReason;

        /// unsigned int
        /** The timestamp when the state changed, in milliseconds */
        public ulong stateTime;
    }

    public class ZegoUser
    {
        /** User ID, a string with a maximum length of 64 bytes or less. Only support numbers, English characters and '~', '!', '@', '#', '$', '%', '^', '&', '*', '(', ')', '_', '+', '=', '-', '`', ';', '’', ',', '.', '<', '>', '/', '\'. */
        public string userId;




        /** User Name, a string with a maximum length of 256 bytes or less */
        public string userName;
        public ZegoUser()
        {

        }
        public ZegoUser(string userId)
        {
            this.userId = userId;
            this.userName = userId;
        }

    }


    public class ZegoVideoConfig
    {
        /// int
        /** Capture resolution width */
        public int captureResolutionWidth;

        /// int
        /** Capture resolution height */
        public int captureResolutionHeight;

        /// int
        /** Encode resolution width */
        public int encodeResolutionWidth;

        /// int
        /** Encode resolution height */
        public int encodeResolutionHeight;

        /// int
        /** Bit rate in kbps */
        public int bitrate;

        /// int
         /** frame rate */
        public int fps;

        /// zego_video_codec_id
        /** codec ID */
        public ZegoVideoCodecId videoCodecId;

        /**
         * Create video configuration with preset enumeration values
         */
        public ZegoVideoConfig(ZegoVideoConfigPreset preset)
        {
            videoCodecId = ZegoVideoCodecId.Default;
            switch (preset)
            {
                case ZegoVideoConfigPreset.Preset180P:
                    captureResolutionWidth = 320;
                    captureResolutionHeight = 180;
                    encodeResolutionWidth = 320;
                    encodeResolutionHeight = 180;
                    bitrate = 300;
                    fps = 15;
                    break;
                case ZegoVideoConfigPreset.Preset270P:
                    captureResolutionWidth = 480;
                    captureResolutionHeight = 270;
                    encodeResolutionWidth = 480;
                    encodeResolutionHeight = 270;
                    bitrate = 400;
                    fps = 15;
                    break;
                case ZegoVideoConfigPreset.Preset360P:
                    captureResolutionWidth = 640;
                    captureResolutionHeight = 360;
                    encodeResolutionWidth = 640;
                    encodeResolutionHeight = 360;
                    bitrate = 600;
                    fps = 15;
                    break;
                case ZegoVideoConfigPreset.Preset540P:
                    captureResolutionWidth = 960;
                    captureResolutionHeight = 540;
                    encodeResolutionWidth = 960;
                    encodeResolutionHeight = 540;
                    bitrate = 1200;
                    fps = 15;
                    break;
                case ZegoVideoConfigPreset.Preset720P:
                    captureResolutionWidth = 1280;
                    captureResolutionHeight = 720;
                    encodeResolutionWidth = 1280;
                    encodeResolutionHeight = 720;
                    bitrate = 1500;
                    fps = 15;
                    break;
                case ZegoVideoConfigPreset.Preset1080P:
                    captureResolutionWidth = 1920;
                    captureResolutionHeight = 1080;
                    encodeResolutionWidth = 1920;
                    encodeResolutionHeight = 1080;
                    bitrate = 3000;
                    fps = 15;
                    break;
            }
        }

        /**
         * Create default video configuration(360p, 15fps, 600000bps)
         *
         * 360p, 15fps, 600kbps
         */
        public ZegoVideoConfig() : this(ZegoVideoConfigPreset.Preset360P)
        {

        }
    }


    public class ZegoWatermark
    {
        /// char[512]
        /** Watermark image URL */

        public string imageUrl;

        /// zego_rect
        /** Watermark image layout */
        public ZegoRect layout;
    }
    public class ZegoCanvas
    {
        /// void*
        public System.IntPtr view;

        /// zego_view_mode
        public ZegoViewMode viewMode;

        /// int
        public int backgroundColor;
    }
    public class ZegoCustomVideoRenderConfig
    {
        /** 自定义视频渲染视频帧数据类型 */
        public ZegoVideoBufferType bufferType;
        /** 自定义视频渲染视频帧数据格式 */
        public ZegoCustomVideoRenderSeries frameFormatSeries;
        /** 是否在自定义视频渲染的同时，引擎也渲染，默认为 [false] */
        public bool enableEngineRender;
    }
    public class ZegoVideoFrameParam
    {
        public ZegoVideoFrameFormat format;
        /// int[4]
        public int[] strides;

        public int width;
        public int height;

        public int rotation;
    }

    public class ZegoAudioFrameParam
    {

        /// ZegoAudioChannel
        public ZegoAudioChannel channel;

        /// int
        public ZegoAudioSampleRate samplesRate;
    }
    public class ZegoMixerVideoConfig
    {

        /// int
        public int resolutionWidth;

        /// int
        public int resolutionHeight;

        /// int
        public int bitrate;

        /// int
        public int fps;
        public ZegoMixerVideoConfig()
        {
            this.resolutionWidth = 360;
            this.resolutionHeight = 640;
            this.fps = 15;
            this.bitrate = 600;
        }
        public ZegoMixerVideoConfig(int resolutionWidth, int resolutionHeight, int bitrate, int fps)
        {
            this.resolutionWidth = resolutionWidth;
            this.resolutionHeight = resolutionHeight;
            this.fps = fps;
            this.bitrate = bitrate;
        }
    }
    public class ZegoMixerTask
    {
        public string taskId;

        /// zego_mixer_input*
        public List<ZegoMixerInput> inputList;


        /// zego_mixer_output*
        public List<ZegoMixerOutput> outputList;

        /// zego_mixer_video_config
        public ZegoMixerVideoConfig videoConfig;

        /// zego_mixer_audio_config
        public ZegoMixerAudioConfig audioConfig;

        /// zego_watermark*
        public ZegoWatermark watermark;


        public string backgroundImageUrl;

        /// boolean
        public bool enableSoundLevel;
        public ZegoMixerTask(string taskId)
        {
            this.taskId = taskId;
        }
        public ZegoMixerTask()
        {

        }
    }
    public class ZegoMixerInput
    {

        /// ZegoMixerInputContentType
        public ZegoMixerInputContentType contentType;

        /// char[256]
        public string streamId;

        /// zego_rect
        public ZegoRect layout;

        /// unsigned int
        public uint soundLevelId;
        public ZegoMixerInput()
        {

        }
        public ZegoMixerInput(string streamId, ZegoMixerInputContentType contentType, ZegoRect layout)
        {
            this.streamId = streamId;
            this.contentType = contentType;
            this.layout = layout;
        }
        public ZegoMixerInput(string streamId, ZegoMixerInputContentType contentType, ZegoRect layout, uint soundLevelId)
        {
            this.streamId = streamId;
            this.contentType = contentType;
            this.layout = layout;
            this.soundLevelId = soundLevelId;
        }
    }
    public class ZegoMixerOutput
    {
        public string target;
        public ZegoMixerOutput()
        {

        }
        public ZegoMixerOutput(string target)
        {
            this.target = target;
        }
    }
    public class ZegoMixerAudioConfig
    {

        /// int
        public int bitrate = 48;

        /// zego_audio_channel
        public ZegoAudioChannel channel;

        /// ZegoAudioCodecId
        public ZegoAudioCodecId audioCodecId;
        public ZegoMixerAudioConfig()
        {
            this.channel = ZegoAudioChannel.Mono;
            this.audioCodecId = ZegoAudioCodecId.Default;
        }
    }
    public class ZegoCustomVideoCaptureConfig
    {
        public ZegoVideoBufferType type;
    }
    public enum ZegoAudioDeviceType
    {

        Input,

        Output,
    }
    public class ZegoDeviceInfo
    {

        public string deviceId;

        public string deviceName;

    }

    public enum ZegoAudioSampleRate
    {

        /// zego_audio_sample_rate_unknown -> 0
        ZegoAudioSampleRateUnknown = 0,

        /// zego_audio_sample_rate_8k -> 8000
        ZegoAudioSampleRate_8k = 8000,

        /// zego_audio_sample_rate_16k -> 16000
        ZegoAudioSampleRate_16k = 16000,

        /// zego_audio_sample_rate_22k -> 22050
        ZegoAudioSampleRate_22k = 22050,

        /// zego_audio_sample_rate_24k -> 24000
        ZegoAudioSampleRate_24k = 24000,

        /// zego_audio_sample_rate_32k -> 32000
        ZegoAudioSampleRate_32k = 32000,

        /// zego_audio_sample_rate_44k -> 44100
        ZegoAudioSampleRate_44k = 44100,

        /// zego_audio_sample_rate_48k -> 48000
        ZegoAudioSampleRate_48k = 48000,
    }
    public enum ZegoAudioDataCallbackBitMask
    {
        CAPTURED = 1,
        PLAYBACK = 2,
        MIXED = 4,
    }
    public enum ZegoAudioSourceType
    {
        /** Default audio capture source (the main channel uses custom audio capture by default; the aux channel uses the same sound as main channel by default) */
        Default = 0,

        /** Use custom audio capture, refer to [enableCustomAudioIO] */
        Custom = 1,

        /** Use media player as audio source, only support aux channel */
        MediaPlayer = 2

    };
    public class ZegoCustomAudioConfig
    {
        /** Audio capture source type */
        public ZegoAudioSourceType sourceType;
    }

    public enum ZegoAECMode
    {

        /// zego_aec_mode_aggressive -> 0
        aggressive = 0,

        /// zego_aec_mode_medium -> 1
        medium = 1,

        /// zego_aec_mode_soft -> 2
        soft = 2,
    }

    public enum ZegoANSMode
    {

        /// zego_ans_mode_soft -> 0
        soft = 0,

        /// zego_ans_mode_medium -> 1
        medium = 1,

        /// zego_ans_mode_aggressive -> 2
        aggressive = 2,
    }

    public enum ZegoDataRecordType
    {
        /// <summary>
        /// This field indicates that the audio-only SDK records audio by default, and the audio and video SDK records audio and video by default.
        /// </summary>
        Default = 0,

        /// <summary>
        /// only record audio
        /// </summary>
        OnlyAudio = 1,

        /// <summary>
        /// only record video, Audio-only SDK is invalid.
        /// </summary>
        OnlyVideo = 2,

        /// <summary>
        /// record audio and video, Audio-only SDK will be recorded only audio.
        /// </summary>
        AudioAndVideo = 3
    }

    public class ZegoDataRecordConfig
    {
        /// <summary>
        /// The path to save the recording file, absolute path, need to include the file name, the file name need to specify the suffix,
        /// currently only support .mp4 or .flv, if multiple recording for the same path, will overwrite the file with the same name.
        /// The maximum length should be less than 1024 bytes.
        /// </summary>
        public string filePath;

        /// <summary>
        /// Type of recording media
        /// </summary>
        public ZegoDataRecordType recordType;
    }

    public enum ZegoDataRecordState
    {
        /// <summary>
        /// Unrecorded state, which is the state when a recording error occurs or before recording starts.
        /// </summary>
        NoRecord = 0,

        /// <summary>
        /// Recording in progress, in this state after successfully call [startCapturedMediaRecord]
        /// </summary>
        Recording = 1,

        /// <summary>
        /// Record successs
        /// </summary>
        Success = 2
    }

    /// <summary>
    /// File recording progress
    /// </summary>
    public class ZegoDataRecordProgress
    {
        /// <summary>
        /// Current recording duration in milliseconds
        /// </summary>
        public ulong duration;

        /// <summary>
        /// Current recording file size in byte
        /// </summary>
        public ulong currentFileSize;
    }
    /** Audio Config Preset */
    public enum ZegoAudioConfigPreset
    {
        /** Basic sound quality (16 kbps, Mono, ZegoAudioCodecIDDefault) */
        BasicQuality,
        /** Standard sound quality (48 kbps, Mono, ZegoAudioCodecIDDefault) */
        StandardQuality,
        /** Standard sound quality (56 kbps, Stereo, ZegoAudioCodecIDDefault) */
        StandardQualityStereo,
        /** High sound quality (128 kbps, Mono, ZegoAudioCodecIDDefault) */
        HighQuality,
        /** High sound quality (192 kbps, Stereo, ZegoAudioCodecIDDefault) */
        HighQualityStereo
    }
    /** Video configuration resolution and bitrate preset enumeration. The preset resolutions are adapted for mobile and desktop. On mobile, height is longer than width, and desktop is the opposite. For example, 1080p is actually 1080(w) x 1920(h) on mobile and 1920(w) x 1080(h) on desktop. */
    public enum ZegoVideoConfigPreset
    {
        /** Set the resolution to 320x180, the default is 15 fps, the code rate is 300 kbps */
        Preset180P,
        /** Set the resolution to 480x270, the default is 15 fps, the code rate is 400 kbps */
        Preset270P,
        /** Set the resolution to 640x360, the default is 15 fps, the code rate is 600 kbps */
        Preset360P,
        /** Set the resolution to 960x540, the default is 15 fps, the code rate is 1200 kbps */
        Preset540P,
        /** Set the resolution to 1280x720, the default is 15 fps, the code rate is 1500 kbps */
        Preset720P,
        /** Set the resolution to 1920x1080, the default is 15 fps, the code rate is 3000 kbps */
        Preset1080P
    }
}
