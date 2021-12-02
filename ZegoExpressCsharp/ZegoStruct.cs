using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
namespace ZEGO
{
    ///
    /// enum
    ///

    /** MediaPlayer instance index. */
    public enum zego_media_player_instance_index
    {
        /** Unknown value */
        zego_media_player_instance_index_null = -1,

        /** The first mediaplayer instance index */
        zego_media_player_instance_index_first = 0,

        /** The second mediaplayer instance index */
        zego_media_player_instance_index_second = 1,

        /** The third mediaplayer instance index */
        zego_media_player_instance_index_third = 2,

        /** The forth mediaplayer instance index */
        zego_media_player_instance_index_forth = 3

    };

    /** VOD billing mode. */
    public enum zego_copyrighted_music_billing_mode
    {
        /** Pay-per-use. */
        zego_copyrighted_music_billing_mode_count = 0,

        /** Monthly billing by user. */
        zego_copyrighted_music_billing_mode_user = 1,

        /** Monthly billing by room. */
        zego_copyrighted_music_billing_mode_room = 2

    };

    /// 
    /// struct
    ///

    // 日志属性，默认为空（size 为 5M，路径为默认k路径）
    public struct zego_log_config
    {
        /// char[512]
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = ZegoConstans.ZEGO_EXPRESS_MAX_COMMON_LEN)]
        //[MarshalAs(UnmanagedType)]
        public byte[] log_path;
        /// ULONGLONG->unsigned __int64
        public ulong log_size;
    }

    // 外部采集主/辅助通道选项设置，默认为空（不开启主/辅助通道外部采集）
    public struct zego_custom_video_capture_config
    {
        public ZegoVideoBufferType buffer_type;
    }

    public struct zego_custom_video_process_config
    {
        public ZegoVideoBufferType buffer_type;
    }

    // 外部渲染选项设置，默认为空（不开启外部渲染）
    public struct zego_custom_video_render_config
    {
        /** 自定义视频渲染视频帧数据类型 */
        public ZegoVideoBufferType type;
        /** 自定义视频渲染视频帧数据格式 */
        public ZegoVideoFrameFormatSeries series;
        /** 是否在自定义视频渲染的同时，引擎也渲染，默认为 [false] */
        [MarshalAs(UnmanagedType.I1)]
        public bool is_internal_render;
    }

    public struct zego_custom_audio_config
    {
        /** Audio capture source type */
        public ZegoAudioSourceType source_type;
    }

    /**
     * Profile for create engine
     *
     * Profile for create engine
     */
    public struct zego_engine_profile
    {
        /** Application ID issued by ZEGO for developers, please apply from the ZEGO Admin Console https://console-express.zego.im The value ranges from 0 to 4294967295. */
        public uint app_id;

        /** Application signature for each AppID, please apply from the ZEGO Admin Console. Application signature is a 64 character string. Each character has a range of '0' ~ '9', 'a' ~ 'z'. */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = ZegoConstans.ZEGO_EXPRESS_MAX_APPSIGN_LEN)]
        public byte[] app_sign;

        /** The application scenario. Developers can choose one of ZegoScenario based on the scenario of the app they are developing, and the engine will preset a more general setting for specific scenarios based on the set scenario. After setting specific scenarios, developers can still call specific functions to set specific parameters if they have customized parameter settings.The recommended configuration for different application scenarios can be referred to: https://doc-zh.zego.im/faq/profile_difference. */
        public ZegoScenario scenario;
    }

    public struct zego_engine_config
    {
        // 日志属性，默认为空（size 为 5M，路径为默认k路径）
        public IntPtr log_config;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = ZegoConstans.ZEGO_EXPRESS_MAX_COMMON_LEN)]
        public byte[] advanced_config;//结构体new 的时候string默认为null,引用类型
    }

    public struct zego_room_config
    {

        /// unsigned int
        public uint max_member_count;

        /// boolean
        [MarshalAs(UnmanagedType.I1)]
        public bool is_user_status_notify;

        /// char[]
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = ZegoConstans.ZEGO_EXPRESS_MAX_COMMON_LEN)]
        public byte[] thrid_token;
    }

    public struct zego_video_config
    {
        /** Capture resolution width, control the width of camera image acquisition. SDK requires this member to be set to an even number. Only the camera is not started and the custom video capture is not used, the setting is effective. For performance reasons, the SDK scales the video frame to the encoding resolution after capturing from camera and before rendering to the preview view. Therefore, the resolution of the preview image is the encoding resolution. If you need the resolution of the preview image to be this value, Please call [setCapturePipelineScaleMode] first to change the capture pipeline scale mode to [Post] */
        public int capture_width;

        /** Capture resolution height, control the height of camera image acquisition. SDK requires this member to be set to an even number. Only the camera is not started and the custom video capture is not used, the setting is effective. For performance reasons, the SDK scales the video frame to the encoding resolution after capturing from camera and before rendering to the preview view. Therefore, the resolution of the preview image is the encoding resolution. If you need the resolution of the preview image to be this value, Please call [setCapturePipelineScaleMode] first to change the capture pipeline scale mode to [Post] */
        public int capture_height;

        /** Encode resolution width, control the image width of the encoder when publishing stream. SDK requires this member to be set to an even number. The settings before and after publishing stream can be effective */
        public int encode_width;

        /** Encode resolution height, control the image height of the encoder when publishing stream. SDK requires this member to be set to an even number. The settings before and after publishing stream can be effective */
        public int encode_height;

        /** Frame rate, control the frame rate of the camera and the frame rate of the encoder. Only the camera is not started, the setting is effective */
        public int fps;

        /** Bit rate in kbps. The settings before and after publishing stream can be effective */
        public int bitrate;

        /** The codec id to be used, the default value is [default]. Settings only take effect before publishing stream */
        public ZegoVideoCodecID codec_id;

        /** Video keyframe interval, in seconds. Required: No. Default value: 2 seconds. Value range: [2, 5]. Caution: The setting is only valid before pushing. */
        public int key_frame_interval;
    }

    public struct zego_sei_config
    {
        public ZegoSEIType type;
    }

    /**
     * Audio reverberation echo parameters.
     */
    public struct zego_reverb_echo_param
    {
        /** Gain of input audio signal, in the range [0.0, 1.0] */
        public float in_gain;

        /** Gain of output audio signal, in the range [0.0, 1.0] */
        public float out_gain;

        /** Number of echos, in the range [0, 7] */
        public int num_delays;

        /** Respective delay of echo signal, in milliseconds, in the range [0, 5000] ms */
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 7, ArraySubType = UnmanagedType.I4)]
        public int[] delay;

        /** Respective decay coefficient of echo signal, in the range [0.0, 1.0] */
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 7, ArraySubType = UnmanagedType.I4)]
        public float[] decay;

    };

    public struct zego_user
    {
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = ZegoConstans.ZEGO_EXPRESS_MAX_USERID_LEN)]
        public byte[] user_id;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = ZegoConstans.ZEGO_EXPRESS_MAX_USERNAME_LEN)]
        public byte[] user_name;

    }

    public struct zego_stream
    {
        public zego_user user;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = ZegoConstans.ZEGO_EXPRESS_MAX_STREAM_LEN)]
        public byte[] stream_id;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = ZegoConstans.ZEGO_EXPRESS_MAX_EXTRA_INFO_LEN)]
        public byte[] extra_info;
    }

    public struct zego_room_extra_info
    {
        /** The key of the room extra information. */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = ZegoConstans.ZEGO_EXPRESS_MAX_ROOM_EXTRA_INFO_KEY_LEN)]
        public byte[] key;

        /** The value of the room extra information. */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = ZegoConstans.ZEGO_EXPRESS_MAX_ROOM_EXTRA_INFO_VALUE_LEN)]
        public byte[] value;

        /** The user who update the room extra information.Please do not fill in sensitive user information in this field, including but not limited to mobile phone number, ID number, passport number, real name, etc. */
        public zego_user update_user;

        /** Update time of the room extra information, UNIX timestamp, in milliseconds. */
        public ulong update_time;

    };

    public struct zego_rect
    {
        /** The value at the left of the horizontal axis of the rectangle */
        public int left;

        /** The value at the top of the vertical axis of the rectangle */
        public int top;

        /** The value at the right of the horizontal axis of the rectangle */
        public int right;

        /** The value at the bottom of the vertical axis of the rectangle */
        public int bottom;
    };

    public struct zego_canvas
    {
        /** View object */
        public System.IntPtr view;

        /** View mode, default is ZegoViewModeAspectFit */
        public ZegoViewMode view_mode;

        /** Background color, the format is 0xRRGGBB, default is black, which is 0x000000 */
        public int background_color;
    }

    public struct zego_publisher_config
    {
        /** The Room ID */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = ZegoConstans.ZEGO_EXPRESS_MAX_ROOMID_LEN)]
        public byte[] room_id;

        /** Whether to synchronize the network time when pushing streams. 1 is synchronized with 0 is not synchronized. And must be used with setStreamAlignmentProperty. It is used to align multiple streams at the mixed stream service or streaming end, such as the chorus scene of KTV. */
        public int force_synchronous_network_time;
    };

    public struct zego_publish_stream_quality
    {
        /** Video capture frame rate. The unit of frame rate is f/s */
        public double video_capture_fps;

        /** Video encoding frame rate. The unit of frame rate is f/s */
        public double video_encode_fps;

        /** Video transmission frame rate. The unit of frame rate is f/s */
        public double video_send_fps;

        /** Video bit rate in kbps */
        public double video_kbps;

        /** Audio capture frame rate. The unit of frame rate is f/s */
        public double audio_capture_fps;

        /** Audio transmission frame rate. The unit of frame rate is f/s */
        public double audio_send_fps;

        /** Audio bit rate in kbps */
        public double audio_kbps;

        /** Local to server delay, in milliseconds */
        public int rtt;

        /** Packet loss rate, in percentage, 0.0 ~ 1.0 */
        public double packet_lost_rate;

        /** Published stream quality level */
        public ZegoStreamQualityLevel level;

        /** Whether to enable hardware encoding */
        [MarshalAs(UnmanagedType.I1)]
        public bool is_hardware_encode;

        /** Video codec ID */
        public ZegoVideoCodecID video_codec_id;

        /** Total number of bytes sent, including audio, video, SEI */
        public double total_send_bytes;

        /** Number of audio bytes sent */
        public double audio_send_bytes;

        /** Number of video bytes sent */
        public double video_send_bytes;
    }

    public struct zego_cdn_config
    {

        /// char[1024]
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = ZegoConstans.ZEGO_EXPRESS_MAX_URL_LEN)]
        public byte[] url;

        /// char[512]
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = ZegoConstans.ZEGO_EXPRESS_MAX_COMMON_LEN)]
        public byte[] auth_param;
    }

    /**
     * Relay to CDN info.
     *
     * Including the URL of the relaying CDN, relaying state, etc.
     */
    public struct zego_stream_relay_cdn_info
    {
        /** URL of publishing stream to CDN */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = ZegoConstans.ZEGO_EXPRESS_MAX_URL_LEN)]
        public byte[] url;

        /** State of relaying to CDN */
        public ZegoStreamRelayCDNState state;

        /** Reason for relay state changed */
        public ZegoStreamRelayCDNUpdateReason update_reason;

        /** The timestamp when the state changed, UNIX timestamp, in milliseconds. */
        public ulong state_time;
    }

    /**
     * Advanced player configuration.
     *
     * Configure playing stream CDN configuration, video layer, room id.
     */
    public struct zego_player_config
    {
        /** Stream resource mode. */
        public ZegoStreamResourceMode resource_mode;

        /** The CDN configuration for playing stream. If set, the stream is play according to the URL instead of the streamID. After that, the streamID is only used as the ID of SDK internal callback. */
        public IntPtr cdn_config;

        /** @deprecated This property has been deprecated since version 1.19.0, please use the [setPlayStreamVideoLayer] function instead. */
        public ZegoPlayerVideoLayer video_layer;

        /** The Room ID. */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = ZegoConstans.ZEGO_EXPRESS_MAX_ROOMID_LEN)]
        public byte[] room_id;
    }

    /**
     * Played stream quality information.
     *
     * Audio and video parameters and network quality, etc.
     */
    public struct zego_play_stream_quality
    {
        /** Video receiving frame rate. The unit of frame rate is f/s */
        public double video_recv_fps;

        /** Video dejitter frame rate. The unit of frame rate is f/s */
        public double video_dejitter_fps;

        /** Video decoding frame rate. The unit of frame rate is f/s */
        public double video_decode_fps;

        /** Video rendering frame rate. The unit of frame rate is f/s */
        public double video_render_fps;

        /** Video bit rate in kbps */
        public double video_kbps;

        /** Video break rate, the unit is (number of breaks / every 10 seconds) */
        public double video_break_rate;

        /** Audio receiving frame rate. The unit of frame rate is f/s */
        public double audio_recv_fps;

        /** Audio dejitter frame rate. The unit of frame rate is f/s */
        public double audio_dejitter_fps;

        /** Audio decoding frame rate. The unit of frame rate is f/s */
        public double audio_decode_fps;

        /** Audio rendering frame rate. The unit of frame rate is f/s */
        public double audio_render_fps;

        /** Audio bit rate in kbps */
        public double audio_kbps;

        /** Audio break rate, the unit is (number of breaks / every 10 seconds) */
        public double audio_break_rate;

        /** Server to local delay, in milliseconds */
        public int rtt;

        /** Packet loss rate, in percentage, 0.0 ~ 1.0 */
        public double packet_lost_rate;

        /** Delay from peer to peer, in milliseconds */
        public int peer_to_peer_delay;

        /** Packet loss rate from peer to peer, in percentage, 0.0 ~ 1.0 */
        public double peer_to_peer_packet_lost_rate;

        /** Published stream quality level */
        public ZegoStreamQualityLevel level;

        /** Delay after the data is received by the local end, in milliseconds */
        public int delay;

        /** The difference between the video timestamp and the audio timestamp, used to reflect the synchronization of audio and video, in milliseconds. This value is less than 0 means the number of milliseconds that the video leads the audio, greater than 0 means the number of milliseconds that the video lags the audio, and 0 means no difference. When the absolute value is less than 200, it can basically be regarded as synchronized audio and video, when the absolute value is greater than 200 for 10 consecutive seconds, it can be regarded as abnormal */
        public int av_timestamp_diff;

        /** Whether to enable hardware decoding */
        [MarshalAs(UnmanagedType.I1)]
        public bool is_hardware_decode;

        /** Video codec ID */
        public ZegoVideoCodecID video_codec_id;

        /** Total number of bytes received, including audio, video, SEI */
        public double total_recv_bytes;

        /** Number of audio bytes received */
        public double audio_recv_bytes;

        /** Number of video bytes received */
        public double video_recv_bytes;

        /** Accumulated audio break count */
        public uint audio_cumulative_break_count;

        /** Accumulated audio break time, in milliseconds. */
        public uint audio_cumulative_break_time;

        /** Accumulated audio break rate, in percentage, 0.0 ~ 1.0 */
        public double audio_cumulative_break_rate;

        /** Accumulated audio decode time, in milliseconds. */
        public uint audio_cumulative_decode_time;

        /** Accumulated video break count */
        public uint video_cumulative_break_count;

        /** Accumulated video break time, in milliseconds. */
        public uint video_cumulative_break_time;

        /** Accumulated video break rate, in percentage, 0.0 ~ 1.0 */
        public double video_cumulative_break_rate;

        /** Accumulated video decode time, in milliseconds. */
        public uint video_cumulative_decode_time;

    };

    /**
     * Device Info.
     *
     * Including device ID and name
     */
    public struct zego_device_info
    {

        /** Device ID */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = ZegoConstans.ZEGO_EXPRESS_MAX_COMMON_LEN)]
        public byte[] device_id;

        /** Device name */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = ZegoConstans.ZEGO_EXPRESS_MAX_COMMON_LEN)]
        public byte[] device_name;

    }

    /**
     * System performance monitoring status
     */
    public struct zego_performance_status
    {
        /** Current CPU usage of the app, value range [0, 1] */
        public double cpu_usage_app;

        /** Current CPU usage of the system, value range [0, 1] */
        public double cpu_usage_system;

        /** Current memory usage of the app, value range [0, 1] */
        public double memory_usage_app;

        /** Current memory usage of the system, value range [0, 1] */
        public double memory_usage_system;

        /** Current memory used of the app, in MB */
        public double memory_used_app;

    };

    /**
     * Beauty configuration options.
     *
     * Configure the parameters of skin peeling, whitening and sharpening
     */
    public struct zego_beautify_option
    {
        /** The sample step size of beauty peeling, the value range is [0,1], default 0.2 */
        public double polish_step;

        /** Brightness parameter for beauty and whitening, the larger the value, the brighter the brightness, ranging from [0,1], default 0.5 */
        public double whiten_factor;

        /** Beauty sharpening parameter, the larger the value, the stronger the sharpening, value range [0,1], default 0.1 */
        public double sharpen_factor;
    }

    /**
     * Mix stream audio configuration.
     *
     * Configure video frame rate, bitrate, and resolution for mixer task
     */
    public struct zego_mixer_audio_config
    {
        /** Audio bitrate in kbps, default is 48 kbps, cannot be modified after starting a mixer task */
        public int bitrate;

        /** Audio channel, default is Mono */
        public ZegoAudioChannel channel;

        /** codec ID, default is ZegoAudioCodecIDDefault */
        public ZegoAudioCodecID codec_id;

        /** Multi-channel audio stream mixing mode. If [ZegoAudioMixMode] is selected as [Focused], the SDK will select 4 input streams with [isAudioFocus] set as the focus voice highlight. If it is not selected or less than 4 channels are selected, it will automatically fill in 4 channels */
        public ZegoAudioMixMode mix_mode;
    }

    /**
     * Mix stream video config object.
     *
     * Configure video frame rate, bitrate, and resolution for mixer task
     */
    public struct zego_mixer_video_config
    {
        /** Video resolution width */
        public int width;

        /** Video resolution height */
        public int height;

        /** Video FPS, cannot be modified after starting a mixer task */
        public int fps;

        /** Video bitrate in kbps */
        public int bitrate;

    }

    /**
     * Mix stream output video config object.
     *
     * Description: Configure the video parameters, coding format and bitrate of mix stream output.
     * Use cases: Manual mixed stream scenario, such as Co-hosting.
     */
    public struct zego_mixer_output_video_config
    {
        /** Mix stream output video coding format, supporting H.264 and h.265 coding. */
        public ZegoVideoCodecID video_codec_id;

        /** Mix stream output video bitrate in kbps. */
        public int bitrate;

        /** Mix stream video encode profile. Default value is [ZegoEncodeProfileDefault]. */
        public ZegoEncodeProfile encode_profile;

        /** The video encoding delay of mixed stream output, Valid value range [0, 2000], in milliseconds. The default value is 0. */
        public int encode_latency;

    };

    /**
     * Font style.
     *
     * Description: Font style configuration, can be used to configure font type, font size, font color, font transparency.
     * Use cases: Set text watermark in manual stream mixing scene, such as Co-hosting.
     */
    public struct zego_font_style
    {
        /** Font type. Required: False. Default value: Source han sans [ZegoFontTypeSourceHanSans] */
        public ZegoFontType type;

        /** Font size in px. Required: False. Default value: 24. Value range: [12,100]. */
        public int size;

        /** Font color, the calculation formula is: R + G x 256 + B x 65536, the value range of R (red), G (green), and B (blue) [0,255]. Required: False. Default value: 16777215(white). Value range: [0,16777215]. */
        public int color;

        /** Font transparency. Required: False. Default value: 0. Value range: [0,100], 100 is completely opaque, 0 is completely transparent. */
        public int transparency;

    };

    /**
     * Label info.
     *
     * Description: Font style configuration, can be used to configure font type, font si-e, font color, font transparency.
     * Use cases: Set text watermark in manual stream mixing scene, such as Co-hosting.
     */
    public struct zego_label_info
    {
        /** Text content, support for setting simplified Chinese, English, half-width, not full-width. Required: True.Value range: Maximum support for displaying 100 Chinese characters and 300 English characters. */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = ZegoConstans.ZEGO_EXPRESS_MAX_COMMON_LEN)]
        public byte[] text;

        /** The distance between the font and the left border of the output canvas, in px. Required: False. Default value: 0. */
        public int left;

        /** The distance between the font and the top border of the output canvas, in px. Required: False. Default value: 0. */
        public int top;

        /** Font style. Required: False. */
        public zego_font_style font;

    };

    /**
     * Mixer input.
     *
     * Configure the mix stream input stream ID, type, and the layout
     */
    public struct zego_mixer_input
    {
        /** Stream ID, a string of up to 256 characters. You cannot include URL keywords, otherwise publishing stream and playing stream will fails. Only support numbers, English characters and '~', '!', '@', '$', '%', '^', '&', '*', '(', ')', '_', '+', '=', '-', '`', ';', '’', ',', '.', '<', '>', '/', '\'. */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = ZegoConstans.ZEGO_EXPRESS_MAX_STREAM_LEN)]
        public byte[] stream_id;

        /** Mix stream content type */
        public ZegoMixerInputContentType content_type;

        /** Stream layout. When the mixed stream is an audio stream (that is, the ContentType parameter is set to the audio mixed stream type), the layout field is not processed inside the SDK, and there is no need to pay attention to this parameter. */
        public zego_rect layout;

        /** If enable soundLevel in mix stream task, an unique soundLevelID is need for every stream */
        public uint sound_level_id;

        /** Whether the focus voice is enabled in the current input stream, the sound of this stream will be highlighted if enabled */
        [MarshalAs(UnmanagedType.I1)]
        public bool is_audio_focus;

        /** The direction of the audio. Valid direction is between 0 to 360. Set -1 means disable. Default value is -1 */
        public int audio_direction;

        /** Text watermark. */
        public zego_label_info label;

        /** Video view render mode. */
        public ZegoMixRenderMode render_mode;

        [MarshalAs(UnmanagedType.I1)]
        public bool enable_audio_direction;
    }

    /**
     * Mixer output object.
     *
     * Configure mix stream output target URL or stream ID
     */
    public struct zego_mixer_output
    {
        /** Mix stream output target, URL or stream ID, if set to be URL format, only RTMP URL surpported, for example rtmp://xxxxxxxx, addresses with two identical mixed-stream outputs cannot be passed in. */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = ZegoConstans.ZEGO_EXPRESS_MAX_URL_LEN)]
        public byte[] target;

        /** Mix stream output video config */
        public IntPtr video_config;
    }

    /**
     * Watermark object.
     *
     * Configure a watermark image URL and the layout of the watermark in the screen.
     */
    public struct zego_watermark
    {

        /** The path of the watermark image. Support local file absolute path (file://xxx). The format supports png, jpg. */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = ZegoConstans.ZEGO_EXPRESS_MAX_COMMON_LEN)]
        public byte[] image;

        /** Watermark image layout */
        public zego_rect layout;
    }

    /**
     * Mix stream task object.
     *
     * This class is the configuration class of the stream mixing task. When a stream mixing task is requested to the ZEGO RTC server, the configuration of the stream mixing task is required.
     * This class describes the detailed configuration information of this stream mixing task.
     */
    public struct zego_mixer_task
    {

        /// char[256]
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = ZegoConstans.ZEGO_EXPRESS_MAX_MIXER_TASK_LEN)]
        public byte[] task_id;

        public IntPtr input_list;

        public uint input_list_count;

        public IntPtr output_list;

        public uint output_list_count;

        public zego_mixer_video_config video_config;

        public zego_mixer_audio_config audio_config;

        public System.IntPtr watermark;

        public int background_color;

        /// char[1024]
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = ZegoConstans.ZEGO_EXPRESS_MAX_URL_LEN)]
        public byte[] background_image_url;

        /// boolean
        [MarshalAsAttribute(UnmanagedType.I1)]
        public bool enable_sound_level;

        public ZegoStreamAlignmentMode stream_alignment_mode;

        public IntPtr user_data;

        public uint user_data_length;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = ZegoConstans.ZEGO_EXPRESS_MAX_COMMON_LEN)]
        public byte[] advanced_config;
    }

    /**
     * Mix stream sound level info object.
     */
    public struct zego_mixer_sound_level_info
    {
        /** Sound level ID. */
        public uint sound_level_id;

        /** Sound level value. */
        public float sound_level;

    };

    /**
     * Configuration for start sound level monitor.
     */
    public struct zego_sound_level_config
    {
        /** Monitoring time period of the sound level, in milliseconds, has a value range of [100, 3000]. Default is 100 ms. */
        public uint millisecond;

        /** Set whether the sound level callback includes the VAD detection result. */
        [MarshalAs(UnmanagedType.I1)]
        public bool enable_vad;

    };

    /**
     * Sound level info object.
     */
    public struct zego_sound_level_info
    {
        /** Stream ID. */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = ZegoConstans.ZEGO_EXPRESS_MAX_STREAM_LEN)]
        public byte[] stream_id;

        /** Sound level value. */
        public float sound_level;

        /** Whether the stream corresponding to StreamID contains human voice, 0 means noise, 1 means human voice. This value is valid only when the [enableVAD] parameter in the [ZegoSoundLevelConfig] configuration is set to true when calling [startSoundLevelMonitor]. */
        public int vad;
    }

    /**
     * Auto mix stream task object.
     *
     * Description: When using [StartAutoMixerTask] function to start an auto stream mixing task to the ZEGO RTC server, user need to set this parameter to configure the auto stream mixing task, including the task ID, room ID, audio configuration, output stream list, and whether to enable the sound level callback.
     * Use cases: This configuration is required when an auto stream mixing task is requested to the ZEGO RTC server.
     * Caution: As an argument passed when [StartAutoMixerTask] function is called.
     */
    public struct zego_auto_mixer_task
    {
        /** The taskID of the auto mixer task.Description: Auto stream mixing task id, must be unique in a room.Use cases: User need to set this parameter when initiating an auto stream mixing task.Required: Yes.Recommended value: Set this parameter based on requirements.Value range: A string up to 256 bytes.Caution: When starting a new auto stream mixing task, only one auto stream mixing task ID can exist in a room, that is, to ensure the uniqueness of task ID. You are advised to associate task ID with room ID. You can directly use the room ID as the task ID.Cannot include URL keywords, for example, 'http' and '?' etc, otherwise publishing stream and playing stream will fail. Only support numbers, English characters and '~', '!', '@', '$', '%', '^', '&', '*', '(', ')', '_', '+', '=', '-', '`', ';', '’', ',', '.', '<', '>', '/', '\'. */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = ZegoConstans.ZEGO_EXPRESS_MAX_MIXER_TASK_LEN)]
        public byte[] task_id;

        /** The roomID of the auto mixer task.Description: Auto stream mixing task id.Use cases: User need to set this parameter when initiating an auto stream mixing task.Required: Yes.Recommended value: Set this parameter based on requirements.Value range: A string up to 128 bytes.Caution: Only support numbers, English characters and '~', '!', '@', '#', '$', '%', '^', '&', '*', '(', ')', '_', '+', '=', '-', '`', ';', '’', ',', '.', '<', '>', '/', '\'. */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = ZegoConstans.ZEGO_EXPRESS_MAX_ROOMID_LEN)]
        public byte[] room_id;

        /** The audio config of the auto mixer task.Description: The audio config of the auto mixer task.Use cases: If user needs special requirements for the audio config of the auto stream mixing task, such as adjusting the audio bitrate, user can set this parameter as required. Otherwise, user do not need to set this parameter.Required: No.Default value: The default audio bitrate is `48 kbps`, the default audio channel is `ZEGO_AUDIO_CHANNEL_MONO`, the default encoding ID is `ZEGO_AUDIO_CODEC_ID_DEFAULT`, and the default multi-channel audio stream mixing mode is `ZEGO_AUDIO_MIX_MODE_RAW`.Recommended value: Set this parameter based on requirements. */
        public zego_mixer_audio_config audio_config;

        /** The output list of the auto mixer task.Description: The output list of the auto stream mixing task, items in the list are URL or stream ID, if the item set to be URL format, only RTMP URL surpported, for example rtmp://xxxxxxxx.Use cases: User need to set this parameter to specify the mix stream output target when starting an auto stream mixing task.Required: Yes. */
        public IntPtr output_list;

        /** Enable or disable sound level callback for the task. If enabled, then the remote player can get the sound level of every stream in the inputlist by [onAutoMixerSoundLevelUpdate] callback.Description: Enable or disable sound level callback for the task.If enabled, then the remote player can get the sound level of every stream in the inputlist by [onAutoMixerSoundLevelUpdate] callback.Use cases: This parameter needs to be configured if user need the sound level information of every stream when an auto stream mixing task started.Required: No.Default value: `false`.Recommended value: Set this parameter based on requirements. */
        [MarshalAs(UnmanagedType.I1)]
        public bool enable_sound_level;

        /** Stream mixing alignment mode. */
        public ZegoStreamAlignmentMode stream_alignment_mode;

        /** The output list count of the auto mixer task */
        public uint output_list_count;

    };

    /**
     * Broadcast message info.
     *
     * The received object of the room broadcast message, including the message content, message ID, sender, sending time
     */
    public struct zego_broadcast_message_info
    {
        /** message content */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = ZegoConstans.ZEGO_EXPRESS_MAX_MESSAGE_LEN)]
        public byte[] message;

        /** message id */
        public ulong message_id;

        /** Message send time, UNIX timestamp, in milliseconds. */
        public ulong send_time;

        /** Message sender.Please do not fill in sensitive user information in this field, including but not limited to mobile phone number, ID number, passport number, real name, etc. */
        public zego_user from_user;
    }

    /**
     * Barrage message info.
     *
     * The received object of the room barrage message, including the message content, message ID, sender, sending time
     */
    public struct zego_barrage_message_info
    {
        /** message content */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = ZegoConstans.ZEGO_EXPRESS_MAX_MESSAGE_LEN)]
        public byte[] message;

        /** message id */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
        public byte[] message_id;

        /** Message send time, UNIX timestamp, in milliseconds. */
        public ulong send_time;

        /** Message sender.Please do not fill in sensitive user information in this field, including but not limited to mobile phone number, ID number, passport number, real name, etc. */
        public zego_user from_user;
    }

    /**
     * Object for video frame fieldeter.
     *
     * Including video frame format, width and height, etc.
     */
    public struct zego_video_frame_param
    {
        /** Video frame format */
        public ZegoVideoFrameFormat format;

        /** Number of bytes per line (for example: BGRA only needs to consider strides [0], I420 needs to consider strides [0,1,2]) */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4, ArraySubType = UnmanagedType.I4)]
        public int[] strides;

        /** Video frame width. When use custom video capture, the video data meeting the 32-bit alignment can obtain the maximum performance. Taking BGRA as an example, width * 4 is expected to be multiple of 32. */
        public int width;

        /** Video frame height */
        public int height;

        /** The rotation direction of the video frame, the SDK rotates clockwise */
        public int rotation;
    }

    /**
     * Parameter object for audio frame.
     *
     * Including the sampling rate and channel of the audio frame
     */
    public struct zego_audio_frame_param
    {
        /** Sampling Rate */
        public ZegoAudioSampleRate samples_rate;

        /** Audio channel, default is Mono */
        public ZegoAudioChannel channel;

    }

    /**
     * Audio configuration.
     *
     * Configure audio bitrate, audio channel, audio encoding for publishing stream
     */
    public struct zego_audio_config
    {
        /** Audio bitrate in kbps, default is 48 kbps. The settings before and after publishing stream can be effective */
        public int bitrate;

        /** Audio channel, default is Mono. The setting only take effect before publishing stream */
        public ZegoAudioChannel channel;

        /** codec ID, default is ZegoAudioCodecIDDefault. The setting only take effect before publishing stream */
        public ZegoAudioCodecID codec_id;
    }

    /**
     * Record config.
     */
    public struct zego_data_record_config
    {
        /** The path to save the recording file, absolute path, need to include the file name, the file name need to specify the suffix, currently supports .mp4/.flv/.aac format files, if multiple recording for the same path, will overwrite the file with the same name. The maximum length should be less than 1024 bytes. */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = ZegoConstans.ZEGO_EXPRESS_MAX_URL_LEN)]
        public byte[] file_path;

        /** Type of recording media */
        public ZegoDataRecordType record_type;
    }

    /**
     * File recording progress.
     */
    public struct zego_data_record_progress
    {
        /** Current recording duration in milliseconds */
        public ulong duration;

        /** Current recording file size in byte */
        public ulong current_file_size;
    }

    public struct zego_audio_effect_play_config
    {

        /// unsigned int
        public uint play_count;

        /// boolean
        [MarshalAs(UnmanagedType.I1)]
        public bool is_publish_out;
    }

    /**
     * Audio spectrum info object.
     */
    public struct zego_audio_spectrum_info
    {
        /** Stream ID. */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = ZegoConstans.ZEGO_EXPRESS_MAX_STREAM_LEN)]
        public byte[] stream_id;

        /** Spectrum values list. */
        public IntPtr spectrum_list;

        /** Spectrum values list of count. */
        public uint spectrum_count;
    }

    /**
     * CopyrightedMusic play configuration.
     */
    public struct zego_copyrighted_music_config
    {
        /** User object instance, configure userID, userName. Note that the userID needs to be globally unique with the same appID, otherwise the user who logs in later will kick out the user who logged in first. */
        public zego_user user;

    }

    /**
     * Request configuration of song or accompaniment.
     */
    public struct zego_copyrighted_music_request_config
    {
        /** the ID of the song. */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = ZegoConstans.ZEGO_EXPRESS_MAX_COMMON_LEN)]
        public byte[] song_id;

        /** VOD billing mode. */
        public zego_copyrighted_music_billing_mode mode;
    };
}
