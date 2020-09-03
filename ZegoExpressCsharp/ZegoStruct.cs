using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
namespace ZEGO
{
    // 日志属性，默认为空（size 为 5M，路径为默认k路径）
    public struct zego_log_config
    {
        /// char[512]
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = ZegoConstans.ZEGO_EXPRESS_MAX_COMMON_LEN)]
        public string log_path;
        /// ULONGLONG->unsigned __int64
        public ulong log_size;
    }
    // 外部采集主/辅助通道选项设置，默认为空（不开启主/辅助通道外部采集）
    public struct zego_custom_video_capture_config
    {
        public ZegoVideoBufferType type;
    }
    // 外部渲染选项设置，默认为空（不开启外部渲染）
    public struct zego_custom_video_render_config
    {
        /** 自定义视频渲染视频帧数据类型 */
        public ZegoVideoBufferType type;
        /** 自定义视频渲染视频帧数据格式 */
        public ZegoCustomVideoRenderSeries series;
        /** 是否在自定义视频渲染的同时，引擎也渲染，默认为 [false] */
        [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.I1)]
        public bool is_internal_render;
    }
    public struct zego_engine_config
    {
        // 日志属性，默认为空（size 为 5M，路径为默认k路径）
        public IntPtr log_config;

        // 外部采集主通道选项设置，默认为空（不开启主通道外部采集）
        public IntPtr custom_video_capture_config;

        // 外部采集辅助通道选项设置，默认为空（不开启辅助通道外部采集）
        public IntPtr custom_video_capture_aux_config;

        // 外部渲染选项设置，默认为空（不开启外部渲染）
        public IntPtr custom_video_render_config;

        // 隐藏功能开关。多个key-value使用';'隔开，如"config1=A;config2=B"
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = ZegoConstans.ZEGO_EXPRESS_MAX_COMMON_LEN)]
        public string advanced_config;//结构体new 的时候string默认为null,引用类型
    }
    public struct zego_user
    {
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = ZegoConstans.ZEGO_EXPRESS_MAX_USERID_LEN)]
        public byte[] user_id;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = ZegoConstans.ZEGO_EXPRESS_MAX_USERNAME_LEN)]
        public byte[] user_name;

    }
    public struct zego_stream
    {
        public zego_user user;
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = ZegoConstans.ZEGO_EXPRESS_MAX_STREAM_LEN)]
        public string stream_id;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = ZegoConstans.ZEGO_EXPRESS_MAX_EXTRA_INFO_LEN)]
        public byte[] extra_info;
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
    public struct zego_room_config
    {

        /// unsigned int
        public uint max_member_count;

        /// boolean
        [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.I1)]
        public bool is_user_status_notify;

        /// char[]
        [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.ByValTStr, SizeConst = ZegoConstans.ZEGO_EXPRESS_MAX_COMMON_LEN)]
        public string thrid_token;
    }
    public struct zego_video_frame_param
    {
        public ZegoVideoFrameFormat format;
        /// int[4]
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 4, ArraySubType = UnmanagedType.I4)]
        public int[] strides;

        public int width;
        public int height;

        public int rotation;
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public struct zego_publish_stream_quality
    {

        /// double
        public double video_capture_fps;

        /// double
        public double video_encode_fps;

        /// double
        public double video_send_fps;

        /// double
        public double video_kbps;

        /// double
        public double audio_capture_fps;

        /// double
        public double audio_send_fps;

        /// double
        public double audio_kbps;

        /// int
        public int rtt;

        /// double
        public double packet_lost_rate;
        /** Published stream quality level */
        public ZegoStreamQuality quality;
        /// boolean
        [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.I1)]
        public bool is_hardware_encode;

        /// double
        public double total_send_bytes;

        /// double
        public double audio_send_bytes;

        /// double
        public double video_send_bytes;
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public struct zego_video_config
    {

        /// int
        public int capture_resolution_width;

        /// int
        public int capture_resolution_height;

        /// int
        public int encode_resolution_width;

        /// int
        public int encode_resolution_height;

        public int fps;

        /// int
        public int bitrate;


        /// zego_video_codec_id
        public ZegoVideoCodecId video_codec_id;
    }

    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public struct zego_audio_config
    {

        /// int
        public int bitrate;

        /// ZegoAudioChannel
        public ZegoAudioChannel channel;

        /// ZegoAudioCodecId
        public ZegoAudioCodecId audio_codec_id;
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public struct zego_play_stream_quality
    {

        /// double
        public double video_recv_fps;

        /// double
        public double video_decode_fps;

        /// double
        public double video_render_fps;

        /// double
        public double video_kbps;

        /// double
        public double audio_recv_fps;

        /// double
        public double audio_decode_fps;

        /// double
        public double audio_render_fps;

        /// double
        public double audio_kbps;

        /// int
        public int rtt;

        /// double
        public double packet_lost_rate;

        /// int
        public int peer_to_peer_delay;

        /// double
        public double peer_to_peer_packet_lost_rate;

        public ZegoStreamQuality quality;

        /// int
        public int delay;

        /// boolean
        [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.I1)]
        public bool is_hardware_decode;

        /// double
        public double total_recv_bytes;

        /// double
        public double audio_recv_bytes;

        /// double
        public double video_recv_bytes;
    }


    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
    public struct zego_barrage_message_info
    {

        /// char[512]
        [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst = ZegoConstans.ZEGO_EXPRESS_MAX_MESSAGE_LEN)]
        public byte[] message;

        /// char[64]
        [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst = 64)]
        public byte[] message_id;

        public ulong send_time;
        /// zego_user
        public zego_user from_user;
    }
    public struct zego_broadcast_message_info
    {
        /// char[512]
        [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst = ZegoConstans.ZEGO_EXPRESS_MAX_MESSAGE_LEN)]
        public byte[] message;

        public ulong message_id;

        public ulong send_time;
        /// zego_user
        public zego_user from_user;
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public struct zego_player_config
    {

        /// zego_cdn_config*
        public System.IntPtr cdn_config;

        /// zego_player_video_layer
        public ZegoPlayerVideoLayer video_layer;
    }

    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
    public struct zego_cdn_config
    {

        /// char[1024]
        [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.ByValTStr, SizeConst = ZegoConstans.ZEGO_EXPRESS_MAX_URL_LEN)]
        public string url;

        /// char[512]
        [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.ByValTStr, SizeConst = ZegoConstans.ZEGO_EXPRESS_MAX_COMMON_LEN)]
        public string auth_param;
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
    public struct zego_stream_relay_cdn_info
    {

        /// char[1024]
        [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.ByValTStr, SizeConst = ZegoConstans.ZEGO_EXPRESS_MAX_URL_LEN)]
        public string url;

        /// zego_stream_relay_cdn_state
        public ZegoStreamRelayCdnState cdn_state;

        /// zego_stream_relay_cdn_update_reason
        public ZegoStreamRelayCdnUpdateReason update_reason;

        /// unsigned int
        public ulong state_time;
    }

    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
    public struct zego_sound_level_info
    {

        /// char[256]
        [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.ByValTStr, SizeConst = ZegoConstans.ZEGO_EXPRESS_MAX_STREAM_LEN)]
        public string stream_id;

        /// float
        public float sound_level;
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
    public struct zego_audio_spectrum_info
    {

        /// char[256]
        [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.ByValTStr, SizeConst = ZegoConstans.ZEGO_EXPRESS_MAX_STREAM_LEN)]
        public string stream_id;

        /// float*
        public System.IntPtr spectrum_list;

        /// unsigned int
        public uint spectrum_count;
    }


    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public struct zego_beautify_option
    {

        /// double
        public double polish_step;

        /// double
        public double whiten_factor;

        /// double
        public double sharpen_factor;
    }

    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
    public struct zego_watermark
    {

        /// char[512]
        [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.ByValTStr, SizeConst = ZegoConstans.ZEGO_EXPRESS_MAX_COMMON_LEN)]
        public string image;

        /// zego_rect
        public zego_rect layout;
    }

    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public struct zego_rect
    {

        /// int
        public int left;

        /// int
        public int top;

        /// int
        public int right;

        /// int
        public int bottom;
    }


    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public struct zego_canvas
    {

        /// void*
        public System.IntPtr view;

        /// zego_view_mode
        public ZegoViewMode view_mode;

        /// int
        public int background_color;
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public struct zego_audio_frame_param
    {
        /// int
        public ZegoAudioSampleRate samples_rate;
        /// ZegoAudioChannel
        public ZegoAudioChannel channel;

        
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
    public struct zego_mixer_task
    {

        /// char[256]
        [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.ByValTStr, SizeConst = ZegoConstans.ZEGO_EXPRESS_MAX_MIXER_TASK_LEN)]
        public string task_id;
        //[MarshalAs(UnmanagedType.ByValArray,ArraySubType =UnmanagedType.Struct)]
        /// zego_mixer_input*
        public IntPtr input_list;

        /// unsigned int
        public uint input_list_count;

        /// zego_mixer_output*
        //[MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.Struct)]
        public IntPtr output_list;

        /// unsigned int
        public uint output_list_count;

        /// zego_mixer_video_config
        public zego_mixer_video_config video_config;

        /// zego_mixer_audio_config
        public zego_mixer_audio_config audio_config;

        /// zego_watermark*
        public System.IntPtr watermark;

        /// char[1024]
        [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.ByValTStr, SizeConst = ZegoConstans.ZEGO_EXPRESS_MAX_URL_LEN)]
        public string background_image_url;

        /// boolean
        [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.I1)]
        public bool enable_sound_level;
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
    public struct zego_mixer_input
    {

       

        /// char[256]
        [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.ByValTStr, SizeConst = ZegoConstans.ZEGO_EXPRESS_MAX_STREAM_LEN)]
        public string stream_id;
        /// ZegoMixerInputContentType
        public ZegoMixerInputContentType content_type;
        /// zego_rect
        public zego_rect layout;

        /// unsigned int
        public uint sound_level_id;
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
    public struct zego_mixer_output
    {

        /// char[1024]
       [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.ByValTStr, SizeConst = ZegoConstans.ZEGO_EXPRESS_MAX_URL_LEN)]
        public string target;
    }

    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public struct zego_mixer_video_config
    {

        /// int
        public int resolution_width;

        /// int
        public int resolution_height;
        /// int
        public int fps;

        /// int
        public int bitrate;

        
    }

    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public struct zego_mixer_audio_config
    {

        /// int
        public int bitrate;

        /// zego_audio_channel
        public ZegoAudioChannel channel;

        /// ZegoAudioCodecId
        public ZegoAudioCodecId audio_codec_id;
    }
    
    public struct zego_device_info
    {

        /// char[]
        [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst = ZegoConstans.ZEGO_EXPRESS_MAX_COMMON_LEN)]
        public byte[] device_id;

        /// char[]
        [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst = ZegoConstans.ZEGO_EXPRESS_MAX_COMMON_LEN)]
        public byte[] device_name;

    }
    public struct zego_custom_audio_config
    {
        /** Audio capture source type */
        public  ZegoAudioSourceType source_type;        
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct zego_data_record_config
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = ZegoConstans.ZEGO_EXPRESS_MAX_COMMON_LEN)]
        public byte[] file_path;

        public ZegoDataRecordType record_type;
    };

    [StructLayout(LayoutKind.Sequential)]
    public struct zego_data_record_progress
    {
        /// <summary>
        /// Current recording duration in milliseconds
        /// </summary>
        public ulong duration;

        /// <summary>
        /// Current recording file size in byte
        /// </summary>
        public ulong current_file_size;
    }
}
