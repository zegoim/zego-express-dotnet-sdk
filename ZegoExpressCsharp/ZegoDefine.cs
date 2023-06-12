using System;
using System.Collections.Generic;

namespace ZEGO {

/// Room scenario.
public enum ZegoScenario {
    /// [Deprecated] Legacy general scenario, this scenario has been deprecated since version 3.0.0, and it is not recommended to use, please migrate to other new scenario as soon as possible.
    General = 0,
    /// [Deprecated] Legacy communication scenario, this scenario has been deprecated since version 3.0.0, and it is not recommended to use, please migrate to other new scenario as soon as possible.
    Communication = 1,
    /// [Deprecated] Legacy live broadcast scenario, this scenario has been deprecated since version 3.0.0, and it is not recommended to use, please migrate to other new scenario as soon as possible.
    Live = 2,
    /// Available since: 3.0.0. Description: The default (generic) scenario. If none of the following scenarios conform to your actual application scenario, this default scenario can be used.
    Default = 3,
    /// Available since: 3.0.0. Description: Standard video call scenario, it is suitable for one-to-one video call scenarios.
    StandardVideoCall = 4,
    /// Available since: 3.0.0. Description: High quality video call scenario, it is similar to the standard video call scenario, but this scenario uses a higher video frame rate, bit rate, and resolution (540p) by default, which is suitable for video call scenario with high image quality requirements.
    HighQualityVideoCall = 5,
    /// Available since: 3.0.0. Description: Standard chatroom scenario, suitable for multi-person pure voice calls (low data usage). Note: On the ExpressVideo SDK, the camera is not enabled by default in this scenario.
    StandardChatroom = 6,
    /// Available since: 3.0.0. Description: High quality chatroom scenario, it is similar to the standard chatroom scenario, but this scenario uses a higher audio bit rate than the standard chatroom scenario by default. It is suitable for multi-person pure voice call scenarios with high requirements on sound quality. Note: On the ExpressVideo SDK, the camera is not enabled by default in this scenario.
    HighQualityChatroom = 7,
    /// Available since: 3.0.0. Description: Live broadcast scenario, it is suitable for one-to-many live broadcast scenarios such as shows, games, e-commerce, and large educational classes. The audio and video quality, fluency, and compatibility have been optimized. Note: Even in live broadcast scenarios, the SDK has no business "roles" (such as anchors and viewers), and all users in the room can publish and play streams.
    Broadcast = 8,
    /// Available since: 3.0.0. Description: Karaoke (KTV) scenario, it is suitable for real-time chorus and online karaoke scenarios, and has optimized delay, sound quality, ear return, echo cancellation, etc., and also ensures accurate alignment and ultra-low delay when multiple people chorus.
    Karaoke = 9,
    /// Available since: 3.3.0. Description: Standard voice call scenario, it is suitable for one-to-one video or voice call scenarios. Note: On the ExpressVideo SDK, the camera is not enabled by default in this scenario.
    StandardVoiceCall = 10
}

/// SDK feature type.
public enum ZegoFeatureType {
    /// Basic audio feature.
    Audio,
    /// Basic video feature.
    Video,
    /// Media player feature.
    MediaPlayer,
    /// Local media data recorder feature.
    MediaDataRecorder,
    /// Media data publisher feature.
    MediaDataPublisher,
    /// Supplemental Enhancement Information (media side info) feature.
    SEI,
    /// SDK video capture feature.
    SdkVideoCapture,
    /// Custom video capture feature.
    CustomVideoCapture,
    /// SDK video rendering feature.
    SdkVideoRender,
    /// Custom video rendering feature.
    CustomVideoRender,
    /// SDK video processing feature (including low-light enhancement feature).
    SdkVideoProcessing,
    /// Custom video processing feature.
    CustomVideoProcessing,
    /// Streaming encryption / decryption feature.
    StreamEncryption,
    /// RTMP streaming feature.
    Rtmp,
    /// RTMPS streaming feature.
    Rtmps,
    /// RTMP over QUIC streaming feature.
    RtmpOverQuic,
    /// RTMP streaming feature.
    HttpFlv,
    /// HTTPS-FLV streaming feature.
    HttpsFlv,
    /// HTTP-FLV over QUIC streaming feature.
    HttpFlvOverQuic,
    /// Super resolution imaging feature.
    SuperResolution,
    /// Effects beauty feature.
    EffectsBeauty,
    /// Whiteboard beauty feature.
    Whiteboard,
    /// Range audio feature.
    RangeAudio,
    /// Copy righted music feature.
    CopyRightedMusic,
    /// Video object segmentation feature.
    VideoObjectSegmentation,
    /// Range scene feature. (3.0.0 and above support)
    RangeScene,
    /// Screen capture feature. (3.1.0 and above support)
    ScreenCapture
}

/// Language.
public enum ZegoLanguage {
    /// English
    English = 0,
    /// Chinese
    Chinese = 1
}

/// Room mode.
public enum ZegoRoomMode {
    /// Single room mode.
    SingleRoom = 0,
    /// Multiple room mode.
    MultiRoom = 1
}

/// engine state.
public enum ZegoEngineState {
    /// The engine has started
    Start,
    /// The engine has stoped
    Stop
}

/// Room state.
public enum ZegoRoomState {
    /// Unconnected state, enter this state before logging in and after exiting the room. If there is a steady state abnormality in the process of logging in to the room, such as AppID or Token are incorrect, or if the same user name is logged in elsewhere and the local end is KickOut, it will enter this state.
    Disconnected,
    /// The state that the connection is being requested. It will enter this state after successful execution login room function. The display of the UI is usually performed using this state. If the connection is interrupted due to poor network quality, the SDK will perform an internal retry and will return to the requesting connection status.
    Connecting,
    /// The status that is successfully connected. Entering this status indicates that the login to the room has been successful. The user can receive the callback notification of the user and the stream information in the room.
    Connected
}

/// Room state change reason.
public enum ZegoRoomStateChangedReason {
    /// Logging in to the room. When calling [loginRoom] to log in to the room or [switchRoom] to switch to the target room, it will enter this state, indicating that it is requesting to connect to the server. The application interface is usually displayed through this state.
    Logining,
    /// Log in to the room successfully. When the room is successfully logged in or switched, it will enter this state, indicating that the login to the room has been successful, and users can normally receive callback notifications of other users in the room and all stream information additions and deletions.
    Logined,
    /// Failed to log in to the room. When the login or switch room fails, it will enter this state, indicating that the login or switch room has failed, for example, AppID or Token is incorrect, etc.
    LoginFailed,
    /// The room connection is temporarily interrupted. If the interruption occurs due to poor network quality, the SDK will retry internally.
    Reconnecting,
    /// The room is successfully reconnected. If there is an interruption due to poor network quality, the SDK will retry internally, and enter this state after successful reconnection.
    Reconnected,
    /// The room fails to reconnect. If there is an interruption due to poor network quality, the SDK will retry internally, and enter this state after the reconnection fails.
    ReconnectFailed,
    /// Kicked out of the room by the server. For example, if you log in to the room with the same user name in other places, and the local end is kicked out of the room, it will enter this state.
    KickOut,
    /// Logout of the room is successful. It is in this state by default before logging into the room. When calling [logoutRoom] to log out of the room successfully or [switchRoom] to log out of the current room successfully, it will enter this state.
    Logout,
    /// Failed to log out of the room. Enter this state when calling [logoutRoom] fails to log out of the room or [switchRoom] fails to log out of the current room internally.
    LogoutFailed
}

/// Publish channel.
public enum ZegoPublishChannel {
    /// The main (default/first) publish channel.
    Main,
    /// The auxiliary (second) publish channel
    Aux,
    /// The third publish channel
    Third,
    /// The fourth publish channel
    Fourth
}

/// Publish CensorshipMode.
public enum ZegoStreamCensorshipMode {
    /// no censorship.
    None,
    /// only censorship stream audio.
    Audio,
    /// only censorship stream video.
    Video,
    /// censorship stream audio and video.
    AudioAndVideo
}

/// Video rendering fill mode.
public enum ZegoViewMode {
    /// The proportional scaling up, there may be black borders
    AspectFit,
    /// The proportional zoom fills the entire View and may be partially cut
    AspectFill,
    /// Fill the entire view, the image may be stretched
    ScaleToFill
}

/// Mirror mode for previewing or playing the of the stream.
public enum ZegoVideoMirrorMode {
    /// The mirror image only for previewing locally. This mode is used by default. When the mobile terminal uses a rear camera, this mode is still used by default, but it does not work. Local preview does not set mirroring.
    OnlyPreviewMirror,
    /// Both the video previewed locally and the far end playing the stream will see mirror image.
    BothMirror,
    /// Both the video previewed locally and the far end playing the stream will not see mirror image.
    NoMirror,
    /// The mirror image only for far end playing the stream.
    OnlyPublishMirror
}

/// SEI type
public enum ZegoSEIType {
    /// Using H.264 SEI (nalu type = 6, payload type = 243) type packaging, this type is not specified by the SEI standard, there is no conflict with the video encoder or the SEI in the video file, users do not need to follow the SEI content Do filtering, SDK uses this type by default.
    ZegoDefined,
    /// SEI (nalu type = 6, payload type = 5) of H.264 is used for packaging. The H.264 standard has a prescribed format for this type: startcode + nalu type (6) + payload type (5) + len + payload (uuid + content) + trailing bits. Because the video encoder itself generates an SEI with a payload type of 5, or when a video file is used for streaming, such SEI may also exist in the video file, so when using this type, the user needs to use uuid + context as a buffer sending SEI. At this time, in order to distinguish the SEI generated by the video encoder itself, when the App sends this type of SEI, it can fill in the service-specific uuid (uuid length is 16 bytes). When the receiver uses the SDK to parse the SEI of the payload type 5, it will set filter string filters out the SEI matching the uuid and throws it to the business. If the filter string is not set, the SDK will throw all received SEI to the developer. uuid filter string setting function, [ZegoEngineConfig.advancedConfig("unregister_sei_filter","XXXXXX")], where unregister_sei_filter is the key, and XXXXX is the uuid filter string to be set.
    UserUnregister
}

/// Publish stream status.
public enum ZegoPublisherState {
    /// The state is not published, and it is in this state before publishing the stream. If a steady-state exception occurs in the publish process, such as AppID or Token are incorrect, or if other users are already publishing the stream, there will be a failure and enter this state.
    NoPublish,
    /// The state that it is requesting to publish the stream after the [startPublishingStream] function is successfully called. The UI is usually displayed through this state. If the connection is interrupted due to poor network quality, the SDK will perform an internal retry and will return to the requesting state.
    PublishRequesting,
    /// The state that the stream is being published, entering the state indicates that the stream has been successfully published, and the user can communicate normally.
    Publishing
}

/// Voice changer preset value.
public enum ZegoVoiceChangerPreset {
    /// No Voice changer
    None,
    /// Male to child voice (loli voice effect)
    MenToChild,
    /// Male to female voice (kindergarten voice effect)
    MenToWomen,
    /// Female to child voice
    WomenToChild,
    /// Female to male voice
    WomenToMen,
    /// Foreigner voice effect
    Foreigner,
    /// Autobot Optimus Prime voice effect
    OptimusPrime,
    /// Android robot voice effect
    Android,
    /// Ethereal voice effect
    Ethereal,
    /// Magnetic(Male) voice effect
    MaleMagnetic,
    /// Fresh(Female) voice effect
    FemaleFresh,
    /// Electronic effects in C major voice effect
    MajorC,
    /// Electronic effects in A minor voice effect
    MinorA,
    /// Electronic effects in harmonic minor voice effect
    HarmonicMinor,
    /// Female Vitality Sound effect
    FemaleEnergetic,
    /// Richness effect
    RichNess,
    /// Muffled effect
    Muffled,
    /// Roundness effect
    Roundness,
    /// Falsetto effect
    Falsetto,
    /// Fullness effect
    Fullness,
    /// Clear effect
    Clear,
    /// Hight effect
    HighlyResonant,
    /// Loud clear effect
    LoudClear,
    /// Minions effect
    Minions
}

/// Reverberation preset value.
public enum ZegoReverbPreset {
    /// No Reverberation
    None,
    /// Soft room reverb effect
    SoftRoom,
    /// Large room reverb effect
    LargeRoom,
    /// Concert hall reverb effect
    ConcertHall,
    /// Valley reverb effect
    Valley,
    /// Recording studio reverb effect
    RecordingStudio,
    /// Basement reverb effect
    Basement,
    /// KTV reverb effect
    KTV,
    /// Popular reverb effect
    Popular,
    /// Rock reverb effect
    Rock,
    /// Vocal concert reverb effect
    VocalConcert,
    /// Gramophone reverb effect
    GramoPhone,
    /// Enhanced KTV reverb effect. Provide KTV effect with more concentrated voice and better brightness. Compared with the original KTV reverb effect, the reverberation time is shortened and the dry-wet ratio is increased.
    EnhancedKTV
}

/// Video configuration resolution and bitrate preset enumeration. The preset resolutions are adapted for mobile and desktop. On mobile, height is longer than width, and desktop is the opposite. For example, 1080p is actually 1080(w) x 1920(h) on mobile and 1920(w) x 1080(h) on desktop.
public enum ZegoVideoConfigPreset {
    /// Set the resolution to 320x180, the default is 15 fps, the code rate is 300 kbps
    Preset180P,
    /// Set the resolution to 480x270, the default is 15 fps, the code rate is 400 kbps
    Preset270P,
    /// Set the resolution to 640x360, the default is 15 fps, the code rate is 600 kbps
    Preset360P,
    /// Set the resolution to 960x540, the default is 15 fps, the code rate is 1200 kbps
    Preset540P,
    /// Set the resolution to 1280x720, the default is 15 fps, the code rate is 1500 kbps
    Preset720P,
    /// Set the resolution to 1920x1080, the default is 15 fps, the code rate is 3000 kbps
    Preset1080P
}

/// Stream quality level.
public enum ZegoStreamQualityLevel {
    /// Excellent
    Excellent,
    /// Good
    Good,
    /// Normal
    Medium,
    /// Bad
    Bad,
    /// Failed
    Die,
    /// Unknown
    Unknown
}

/// Audio channel type.
public enum ZegoAudioChannel {
    /// Unknown
    Unknown,
    /// Mono
    Mono,
    /// Stereo
    Stereo
}

/// Audio capture stereo mode.
public enum ZegoAudioCaptureStereoMode {
    /// Disable stereo capture, that is, mono.
    None,
    /// Always enable stereo capture.
    Always,
    /// [Deprecated] Same as [Always], that is, always enable stereo capture, this mode has been deprecated since version 2.16.0.
    Adaptive
}

/// Audio mix mode.
public enum ZegoAudioMixMode {
    /// Default mode, no special behavior
    Raw,
    /// Audio focus mode, which can highlight the sound of a certain stream in multiple audio streams
    Focused
}

/// Audio codec ID.
public enum ZegoAudioCodecID {
    /// Default, determined by the [scenario] when calling [createEngine].
    Default,
    /// Can be used for RTC and CDN streaming; bitrate range from 10kbps to 128kbps; supports stereo; latency is around 500ms. Server cloud transcoding is required when communicating with the Web SDK, and it is not required when relaying to CDN.
    Normal,
    /// Can be used for RTC and CDN streaming; good compatibility; bitrate range from 16kbps to 192kbps; supports stereo; latency is around 350ms; the sound quality is worse than [Normal] in the same (low) bitrate. Server cloud transcoding is required when communicating with the Web SDK, and it is not required when relaying to CDN.
    Normal2,
    /// Not recommended; if you need to use it, please contact ZEGO technical support. Can only be used for RTC streaming.
    Normal3,
    /// Not recommended; if you need to use it, please contact ZEGO technical support. Can only be used for RTC streaming.
    Low,
    /// Not recommended; if you need to use it, please contact ZEGO technical support. Can only be used for RTC streaming; maximum bitrate is 16kbps.
    Low2,
    /// Can only be used for RTC streaming; bitrate range from 6kbps to 192kbps; supports stereo; latency is around 200ms; Under the same bitrate (low bitrate), the sound quality is significantly better than [Normal] and [Normal2]; low CPU overhead. Server cloud transcoding is not required when communicating with the Web SDK, and it is required when relaying to CDN.
    Low3
}

/// Video codec ID.
public enum ZegoVideoCodecID {
    /// Default (H.264)
    Default,
    /// Scalable Video Coding (H.264 SVC)
    SVC,
    /// VP8
    VP8,
    /// H.265
    H265,
    /// Dualstream Scalable Video Coding
    H264DualStream,
    /// Unknown Video Coding
    Unknown = 100
}

/// Video screen rotation direction.
public enum ZegoOrientation {
    /// Not rotate
    ZegoOrientation_0,
    /// Rotate 90 degrees counterclockwise
    ZegoOrientation_90,
    /// Rotate 180 degrees counterclockwise
    ZegoOrientation_180,
    /// Rotate 270 degrees counterclockwise
    ZegoOrientation_270
}

/// Video stream type
public enum ZegoVideoStreamType {
    /// The type to be played depends on the network status
    Default,
    /// small resolution type
    Small,
    /// big resolution type
    Big
}

/// Audio echo cancellation mode.
public enum ZegoAECMode {
    /// Aggressive echo cancellation may affect the sound quality slightly, but the echo will be very clean.
    Aggressive,
    /// Moderate echo cancellation, which may slightly affect a little bit of sound, but the residual echo will be less.
    Medium,
    /// Comfortable echo cancellation, that is, echo cancellation does not affect the sound quality of the sound, and sometimes there may be a little echo, but it will not affect the normal listening.
    Soft
}

/// Active Noise Suppression mode.
public enum ZegoANSMode {
    /// Soft ANS. In most instances, the sound quality will not be damaged, but some noise will remain.
    Soft,
    /// Medium ANS. It may damage some sound quality, but it has a good noise reduction effect.
    Medium,
    /// Aggressive ANS. It may significantly impair the sound quality, but it has a good noise reduction effect.
    Aggressive,
    /// AI mode ANS. It will cause great damage to music, so it can not be used for noise suppression of sound sources that need to collect background sound. Please contact ZEGO technical support before use.
    AI
}

/// video encode profile.
public enum ZegoEncodeProfile {
    /// The default video encode specifications, The default value is the video encoding specification at the Main level.
    Default,
    /// Baseline-level video encode specifications have low decoding consumption and poor picture effects. They are generally used for low-level applications or applications that require additional fault tolerance.
    Baseline,
    /// Main-level video encode specifications, decoding consumption is slightly higher than Baseline, the picture effect is also better, generally used in mainstream consumer electronic products.
    Main,
    /// High-level video encode specifications, decoding consumption is higher than Main, the picture effect is better, generally used for broadcasting and video disc storage, high-definition TV.
    High
}

/// Video rate control mode, the default mode is constant video rate.
public enum ZegoVideoRateControlMode {
    /// Constant rate.
    ConstantRate,
    /// Constant quality, if this mode is used, the video rate fluctuates according to the network speed. For example, in the live broadcast of games, the constant quality mode will be used to improve the video quality in order to let the audience see smooth operation pictures.
    ConstantQuality
}

/// Stream alignment mode.
public enum ZegoStreamAlignmentMode {
    /// Disable stream alignment.
    None,
    /// Streams should be aligned as much as possible, call the [setStreamAlignmentProperty] function to enable the stream alignment of the push stream network time alignment of the specified channel.
    Try
}

/// Traffic control property (bitmask enumeration).
public enum ZegoTrafficControlProperty {
    /// Basic (Adaptive (reduce) video bitrate)
    Basic = 0,
    /// Adaptive (reduce) video FPS
    AdaptiveFPS = 1,
    /// Adaptive (reduce) video resolution
    AdaptiveResolution = 1 << 1,
    /// Adaptive (reduce) audio bitrate
    AdaptiveAudioBitrate = 1 << 2
}

/// Video transmission mode when current bitrate is lower than the set minimum bitrate.
public enum ZegoTrafficControlMinVideoBitrateMode {
    /// Stop video transmission when current bitrate is lower than the set minimum bitrate
    NoVideo,
    /// Video is sent at a very low frequency (no more than 2fps) which is lower than the set minimum bitrate
    UltraLowFPS
}

/// Factors that trigger traffic control
public enum ZegoTrafficControlFocusOnMode {
    /// Focus only on the local network
    LocalOnly,
    /// Pay attention to the local network, but also take into account the remote network, currently only effective in the 1v1 scenario
    Remote
}

/// Playing stream status.
public enum ZegoPlayerState {
    /// The state of the flow is not played, and it is in this state before the stream is played. If the steady flow anomaly occurs during the playing process, such as AppID or Token are incorrect, it will enter this state.
    NoPlay,
    /// The state that the stream is being requested for playing. After the [startPlayingStream] function is successfully called, it will enter the state. The UI is usually displayed through this state. If the connection is interrupted due to poor network quality, the SDK will perform an internal retry and will return to the requesting state.
    PlayRequesting,
    /// The state that the stream is being playing, entering the state indicates that the stream has been successfully played, and the user can communicate normally.
    Playing
}

/// Media event when playing.
public enum ZegoPlayerMediaEvent {
    /// Audio stuck event when playing
    AudioBreakOccur,
    /// Audio stuck event recovery when playing
    AudioBreakResume,
    /// Video stuck event when playing
    VideoBreakOccur,
    /// Video stuck event recovery when playing
    VideoBreakResume
}

/// Resource Type.
public enum ZegoResourceType {
    /// CDN
    CDN,
    /// RTC
    RTC,
    /// L3
    L3
}

/// Stream Resource Mode
public enum ZegoStreamResourceMode {
    /// Default mode. The SDK will automatically select the streaming resource according to the cdnConfig parameters set by the player config and the ready-made background configuration.
    Default,
    /// Playing stream only from CDN.
    OnlyCDN,
    /// Playing stream only from L3.
    OnlyL3,
    /// Playing stream only from RTC.
    OnlyRTC,
    /// CDN Plus mode. The SDK will automatically select the streaming resource according to the network condition.
    CDNPlus
}

/// Update type.
public enum ZegoUpdateType {
    /// Add
    Add,
    /// Delete
    Delete
}

/// State of CDN relay.
public enum ZegoStreamRelayCDNState {
    /// The state indicates that there is no CDN relay
    NoRelay,
    /// The CDN relay is being requested
    RelayRequesting,
    /// Entering this status indicates that the CDN relay has been successful
    Relaying
}

/// Reason for state of CDN relay changed.
public enum ZegoStreamRelayCDNUpdateReason {
    /// No error
    None,
    /// Server error
    ServerError,
    /// Handshake error
    HandshakeFailed,
    /// Access point error
    AccessPointError,
    /// Stream create failure
    CreateStreamFailed,
    /// Bad stream ID
    BadName,
    /// CDN server actively disconnected
    CDNServerDisconnected,
    /// Active disconnect
    Disconnected,
    /// All mixer input streams sessions closed
    MixStreamAllInputStreamClosed,
    /// All mixer input streams have no data
    MixStreamAllInputStreamNoData,
    /// Internal error of stream mixer server
    MixStreamServerInternalError
}

/// Beauty feature (bitmask enumeration).
public enum ZegoBeautifyFeature {
    /// No beautifying
    None = 0,
    /// Polish
    Polish = 1 << 0,
    /// Sharpen
    Whiten = 1 << 1,
    /// Skin whiten
    SkinWhiten = 1 << 2,
    /// Whiten
    Sharpen = 1 << 3
}

/// Device type.
public enum ZegoDeviceType {
    /// Unknown device type.
    Unknown,
    /// Camera device.
    Camera,
    /// Microphone device.
    Microphone,
    /// Speaker device.
    Speaker,
    /// Audio device. (Other audio device that cannot be accurately classified into microphones or speakers.)
    AudioDevice
}

/// The exception type for the device.
public enum ZegoDeviceExceptionType {
    /// Unknown device exception.
    Unknown,
    /// Generic device exception.
    Generic,
    /// Invalid device ID exception.
    InvalidId,
    /// Device permission is not granted.
    PermissionNotGranted,
    /// The capture frame rate of the device is 0.
    ZeroCaptureFps,
    /// The device is being occupied.
    DeviceOccupied,
    /// The device is unplugged (not plugged in).
    DeviceUnplugged,
    /// The device requires the system to restart before it can work (Windows platform only).
    RebootRequired,
    /// The system media service is unavailable, e.g. when the iOS system detects that the current pressure is huge (such as playing a lot of animation), it is possible to disable all media related services (Apple platform only).
    MediaServicesWereLost,
    /// The device is being occupied by Siri (Apple platform only).
    SiriIsRecording,
    /// The device captured sound level is too low (Windows platform only).
    SoundLevelTooLow,
    /// The device is being occupied, and maybe cause by iPad magnetic case (Apple platform only).
    MagneticCase
}

/// Remote device status.
public enum ZegoRemoteDeviceState {
    /// Device on
    Open,
    /// General device error
    GenericError,
    /// Invalid device ID
    InvalidID,
    /// No permission
    NoAuthorization,
    /// Captured frame rate is 0
    ZeroFPS,
    /// The device is occupied
    InUseByOther,
    /// The device is not plugged in or unplugged
    Unplugged,
    /// The system needs to be restarted
    RebootRequired,
    /// System media services stop, such as under the iOS platform, when the system detects that the current pressure is huge (such as playing a lot of animation), it is possible to disable all media related services.
    SystemMediaServicesLost,
    /// The remote user calls [enableCamera] or [muteMicrophone] to disable the camera or microphone.
    Disable,
    /// The remote user actively calls [mutePublishStreamAudio] or [mutePublishStreamVideo] to stop publish the audio or video stream.
    Mute,
    /// The device is interrupted, such as a phone call interruption, etc.
    Interruption,
    /// There are multiple apps at the same time in the foreground, such as the iPad app split screen, the system will prohibit all apps from using the camera.
    InBackground,
    /// CDN server actively disconnected
    MultiForegroundApp,
    /// The system is under high load pressure and may cause abnormal equipment.
    BySystemPressure,
    /// The remote device is not supported to publish the device state.
    NotSupport
}

/// Audio device type.
public enum ZegoAudioDeviceType {
    /// Audio input type
    Input,
    /// Audio output type
    Output
}

/// Audio route
public enum ZegoAudioRoute {
    /// Speaker
    Speaker,
    /// Headphone
    Headphone,
    /// Bluetooth device
    Bluetooth,
    /// Receiver
    Receiver,
    /// External USB audio device
    ExternalUSB,
    /// Apple AirPlay
    AirPlay
}

/// Mix stream content type.
public enum ZegoMixerInputContentType {
    /// Mix stream for audio only
    Audio,
    /// Mix stream for both audio and video
    Video,
    /// Mix stream for video only
    VideoOnly
}

/// Capture pipeline scale mode.
public enum ZegoCapturePipelineScaleMode {
    /// Zoom immediately after acquisition, default
    Pre,
    /// Scaling while encoding
    Post
}

/// Video frame format.
public enum ZegoVideoFrameFormat {
    /// Unknown format, will take platform default
    Unknown,
    /// I420 (YUV420Planar) format
    I420,
    /// NV12 (YUV420SemiPlanar) format
    NV12,
    /// NV21 (YUV420SemiPlanar) format
    NV21,
    /// BGRA32 format
    BGRA32,
    /// RGBA32 format
    RGBA32,
    /// ARGB32 format
    ARGB32,
    /// ABGR32 format
    ABGR32,
    /// I422 (YUV422Planar) format
    I422
}

/// Video frame buffer type.
public enum ZegoVideoBufferType {
    /// Raw data type video frame
    Unknown,
    /// Raw data type video frame
    RawData,
    /// Encoded data type video frame
    EncodedData,
    /// Texture 2D type video frame
    GLTexture2D,
    /// CVPixelBuffer type video frame
    CVPixelBuffer,
    /// Surface Texture type video frame
    SurfaceTexture,
    /// GL_TEXTURE_EXTERNAL_OES type video frame
    GLTextureExternalOES
}

/// Video frame format series.
public enum ZegoVideoFrameFormatSeries {
    /// RGB series
    RGB,
    /// YUV series
    YUV
}

/// Video frame flip mode.
public enum ZegoVideoFlipMode {
    /// No flip
    None,
    /// X-axis flip
    X,
    /// Y-axis flip
    Y,
    /// X-Y-axis flip
    XY
}

/// Audio Config Preset.
public enum ZegoAudioConfigPreset {
    /// Basic sound quality (16 kbps, Mono, ZegoAudioCodecIDDefault)
    BasicQuality,
    /// Standard sound quality (48 kbps, Mono, ZegoAudioCodecIDDefault)
    StandardQuality,
    /// Standard sound quality (56 kbps, Stereo, ZegoAudioCodecIDDefault)
    StandardQualityStereo,
    /// High sound quality (128 kbps, Mono, ZegoAudioCodecIDDefault)
    HighQuality,
    /// High sound quality (192 kbps, Stereo, ZegoAudioCodecIDDefault)
    HighQualityStereo
}

/// Range audio mode
public enum ZegoRangeAudioMode {
    /// World mode, you can communicate with everyone in the room.
    World,
    /// Team mode, only communicate with members of the team.
    Team,
    /// Secret team mode, communicate with members of the team (with team members), can hear the voices of members who within the audio receive range (except the team members).
    SecretTeam
}

/// Range audio microphone state.
public enum ZegoRangeAudioMicrophoneState {
    /// The range audio microphone is off.
    Off,
    /// The range audio microphone is turning on.
    TurningOn,
    /// The range audio microphone is on.
    On
}

/// Player state.
public enum ZegoMediaPlayerState {
    /// Not playing
    NoPlay,
    /// Playing
    Playing,
    /// Pausing
    Pausing,
    /// End of play
    PlayEnded
}

/// Player network event.
public enum ZegoMediaPlayerNetworkEvent {
    /// Network resources are not playing well, and start trying to cache data
    BufferBegin,
    /// Network resources can be played smoothly
    BufferEnded
}

/// Audio channel.
public enum ZegoMediaPlayerAudioChannel {
    /// Audio channel left
    Left,
    /// Audio channel right
    Right,
    /// Audio channel all
    All
}

/// AudioEffectPlayer state.
public enum ZegoAudioEffectPlayState {
    /// Not playing
    NoPlay,
    /// Playing
    Playing,
    /// Pausing
    Pausing,
    /// End of play
    PlayEnded
}

/// audio sample rate.
public enum ZegoAudioSampleRate {
    /// Unknown
    Unknown = 0,
    /// 8K
    ZegoAudioSampleRate8K = 8000,
    /// 16K
    ZegoAudioSampleRate16K = 16000,
    /// 22.05K
    ZegoAudioSampleRate22K = 22050,
    /// 24K
    ZegoAudioSampleRate24K = 24000,
    /// 32K
    ZegoAudioSampleRate32K = 32000,
    /// 44.1K
    ZegoAudioSampleRate44K = 44100,
    /// 48K
    ZegoAudioSampleRate48K = 48000
}

/// Audio capture source type.
public enum ZegoAudioSourceType {
    /// Default audio capture source (the main channel uses custom audio capture by default; the aux channel uses the same sound as main channel by default).
    Default,
    /// Use custom audio capture, refer to [enableCustomAudioIO] or [setAudioSource].
    Custom,
    /// Use media player as audio source, only support aux channel.
    MediaPlayer,
    /// No audio source. This audio source type can only be used in [setAudioSource] interface, has no effect when used in [enableCustomAudioIO] interface.
    None,
    /// Using microphone as audio source. This audio source type can only be used in [setAudioSource] interface, has no effect when used in [enableCustomAudioIO] interface.
    Microphone,
    /// Using main channel as audio source. Ineffective when used in main channel. This audio source type can only be used in [setAudioSource] interface, has no effect when used in [enableCustomAudioIO] interface.
    MainPublishChannel
}

/// Record type.
public enum ZegoDataRecordType {
    /// This field indicates that the Express-Audio SDK records audio by default, and the Express-Video SDK records audio and video by default. When recording files in .aac format, audio is also recorded by default.
    Default,
    /// only record audio
    OnlyAudio,
    /// only record video, Audio SDK and recording .aac format files are invalid.
    OnlyVideo,
    /// record audio and video. Express-Audio SDK and .aac format files are recorded only audio.
    AudioAndVideo
}

/// Record state.
public enum ZegoDataRecordState {
    /// Unrecorded state, which is the state when a recording error occurs or before recording starts.
    NoRecord,
    /// Recording in progress, in this state after successfully call [startRecordingCapturedData] function
    Recording,
    /// Record successs
    Success
}

/// Audio data callback function enable bitmask enumeration.
public enum ZegoAudioDataCallbackBitMask {
    /// The mask bit of this field corresponds to the enable [onCapturedAudioData] callback function
    Captured = 1 << 0,
    /// The mask bit of this field corresponds to the enable [onPlaybackAudioData] callback function
    Playback = 1 << 1,
    /// The mask bit of this field corresponds to the enable [onMixedAudioData] callback function
    Mixed = 1 << 2,
    /// The mask bit of this field corresponds to the enable [onPlayerAudioData] callback function
    Player = 1 << 3
}

/// network speed test type
public enum ZegoNetworkSpeedTestType {
    /// uplink
    Uplink,
    /// downlink
    Downlink
}

/// MediaPlayer instance index.
public enum ZegoMediaPlayerInstanceIndex {
    /// Unknown value
    Null = -1,
    /// The first mediaplayer instance index
    First = 0,
    /// The second mediaplayer instance index
    Second = 1,
    /// The third mediaplayer instance index
    Third = 2,
    /// The forth mediaplayer instance index
    Forth = 3
}

/// AudioEffectPlayer instance index.
public enum ZegoAudioEffectPlayerInstanceIndex {
    /// Unknown value
    Null = -1,
    /// The first AudioEffectPlayer instance index
    First = 0
}

/// VOD billing mode.
public enum ZegoCopyrightedMusicBillingMode {
    /// Pay-per-use.Each time a user obtains a song resource, a charge is required, that is, the user will be charged for each time based on the actual call to obtain the song resource interface (such as [requestSong], [requestAccompaniment], etc.).
    Count,
    /// Monthly billing by user.Billing for a single user is based on the monthly dimension, that is, the statistics call to obtain song resources (such as [requestSong], [requestAccompaniment], etc.) and the parameters are the user ID of the monthly subscription, and the charging is based on the monthly dimension.
    User,
    /// Monthly billing by room.The room users are billed on a monthly basis, that is, statistical calls to obtain song resources (such as [requestSong], [requestAccompaniment], etc.) are passed as Roomid for a monthly subscription of the room, and fees are charged on a monthly basis.
    Room,
    /// Monthly billing by master. Every time a user obtains a resource, it is counted as the owner’s acquisition of resources, that is, according to the actual call to obtain the song resource interface (such as [requestSong], [requestAccompaniment], etc.), the parameters are passed as the Roomid of the room and the Masterid of the owner, and the fee is charged according to the owner.
    Master
}

/// The music resource type. For [querycache] interface.
public enum ZegoCopyrightedMusicType {
    /// Song.
    ZegoCopyrightedMusicSong,
    /// Song with high quality.
    ZegoCopyrightedMusicSongHQ,
    /// Song with super quality.
    ZegoCopyrightedMusicSongSQ,
    /// Song accompaniment.
    ZegoCopyrightedMusicAccompaniment,
    /// Song accompaniment clip.
    ZegoCopyrightedMusicAccompanimentClip,
    /// Song accompaniment segment.
    ZegoCopyrightedMusicAccompanimentSegment
}

/// Copyright music resource song copyright provider. For more information about the copyright owner, please contact ZEGO business personnel.
public enum ZegoCopyrightedMusicVendorID {
    /// Default copyright provider.
    ZegoCopyrightedMusicVendorDefault = 0,
    /// First copyright provider.
    ZegoCopyrightedMusicVendor1 = 1,
    /// Second copyright provider.
    ZegoCopyrightedMusicVendor2 = 2,
    /// Third copyright provider.
    ZegoCopyrightedMusicVendor3 = 4
}

/// Font type.
public enum ZegoFontType {
    /// Source han sans.
    SourceHanSans = 0,
    /// Alibaba sans.
    AlibabaSans = 1,
    /// Pang men zheng dao title.
    PangMenZhengDaoTitle,
    /// HappyZcool.
    HappyZcool
}

/// Mixing stream video view render mode.
public enum ZegoMixRenderMode {
    /// The proportional zoom fills the entire area and may be partially cut.
    Fill = 0,
    /// Scale the filled area proportionally. If the scale does not match the set size after scaling, the extra part will be displayed as transparent.
    Fit = 1
}

/// Camera focus mode.
public enum ZegoCameraFocusMode {
    /// Auto focus.
    AutoFocus = 0,
    /// Continuous auto focus.
    ContinuousAutoFocus = 1
}

/// Camera exposure mode.
public enum ZegoCameraExposureMode {
    /// Auto exposure.
    AutoExposure = 0,
    /// Continuous auto exposure.
    ContinuousAutoExposure = 1
}

/// voice activity detection type
public enum ZegoAudioVADType {
    /// noise
    Noise,
    /// speech
    Speech
}

/// stable voice activity detection type
public enum ZegoAudioVADStableStateMonitorType {
    /// captured
    Captured,
    /// custom processed
    CustomProcessed
}

/// Supported httpDNS service types.
public enum ZegoHttpDNSType {
    /// None.
    None = 0,
    /// wangsu httpdns.
    Wangsu = 1,
    /// tencent httpdns.
    Tencent = 2,
    /// aliyun httpdns.
    Aliyun = 3
}

/**
     * Log config.
     *
     * Description: This parameter is required when calling [setlogconfig] to customize log configuration.
     * Use cases: This configuration is required when you need to customize the log storage path or the maximum log file size.
     * Caution: None.
     */
public class ZegoLogConfig {

    /// The storage path of the log file. Description: Used to customize the storage path of the log file. Use cases: This configuration is required when you need to customize the log storage path. Required: False. Default value: The default path of each platform is different, please refer to the official website document https://docs.zegocloud.com/faq/express_sdkLog. Caution: Developers need to ensure read and write permissions for files under this path.
    public string logPath;

    /// Maximum log file size(Bytes). Description: Used to customize the maximum log file size. Use cases: This configuration is required when you need to customize the upper limit of the log file size. Required: False. Default value: 5MB (5 * 1024 * 1024 Bytes). Value range: Minimum 1MB (1 * 1024 * 1024 Bytes), maximum 100M (100 * 1024 * 1024 Bytes), 0 means no need to write logs. Caution: The larger the upper limit of the log file size, the more log information it carries, but the log upload time will be longer.
    public ulong logSize;

    public ZegoLogConfig() {
        logPath = "";
        logSize = 5 * 1024 * 1024;
    }
}

/**
     * Custom video capture configuration.
     *
     * Custom video capture, that is, the developer is responsible for collecting video data and sending the collected video data to SDK for video data encoding and publishing to the ZEGO RTC server. This feature is generally used by developers who use third-party beauty features or record game screen living.
     * When you need to use the custom video capture function, you need to set an instance of this class as a parameter to the [enableCustomVideoCapture] function.
     * Because when using custom video capture, SDK will no longer start the camera to capture video data. You need to collect video data from video sources by yourself.
     */
public class ZegoCustomVideoCaptureConfig {

    /// Custom video capture video frame data type
    public ZegoVideoBufferType bufferType;
}

/**
     * Custom video process configuration.
     */
public class ZegoCustomVideoProcessConfig {

    /// Custom video process video frame data type
    public ZegoVideoBufferType bufferType;
}

/**
     * Custom video render configuration.
     *
     * When you need to use the custom video render function, you need to set an instance of this class as a parameter to the [enableCustomVideoRender] function.
     */
public class ZegoCustomVideoRenderConfig {

    /// Custom video capture video frame data type
    public ZegoVideoBufferType bufferType;

    /// Custom video rendering video frame data format。Useless when set bufferType as [EncodedData]
    public ZegoVideoFrameFormatSeries frameFormatSeries;

    /// Whether the engine also renders while customizing video rendering. The default value is [false]. Useless when set bufferType as [EncodedData]
    public bool enableEngineRender;
}

/**
     * Custom audio configuration.
     */
public class ZegoCustomAudioConfig {

    /// Audio capture source type
    public ZegoAudioSourceType sourceType;
}

/**
     * Profile for create engine
     *
     * Profile for create engine
     */
public class ZegoEngineProfile {

    /// Application ID issued by ZEGO for developers, please apply from the ZEGO Admin Console https://console.zegocloud.com The value ranges from 0 to 4294967295.
    public uint appID;

    /// Application signature for each AppID, please apply from the ZEGO Admin Console. Application signature is a 64 character string. Each character has a range of '0' ~ '9', 'a' ~ 'z'. AppSign 2.17.0 and later allows null or no transmission. If the token is passed empty or not passed, the token must be entered in the [ZegoRoomConfig] parameter for authentication when the [loginRoom] interface is called to login to the room.
    public string appSign;

    /// The room scenario. the SDK will optimize the audio and video configuration for the specified scenario to achieve the best effect in this scenario. After specifying the scenario, you can call other APIs to adjusting the audio and video configuration. Differences between scenarios and how to choose a suitable scenario, please refer to https://docs.zegocloud.com/article/14940
    public ZegoScenario scenario;
}

/**
     * Advanced engine configuration.
     */
public class ZegoEngineConfig {

    /// @deprecated This property has been deprecated since version 2.3.0, please use the [setLogConfig] function instead.
    public ZegoLogConfig logConfig;

    /// Other special function switches, if not set, no special function will be used by default. Please contact ZEGO technical support before use.
    public Dictionary<string, string> advancedConfig;
}

/**
     * Advanced room configuration.
     *
     * Configure maximum number of users in the room and authentication token, etc.
     */
public class ZegoRoomConfig {

    /// The maximum number of users in the room, Passing 0 means unlimited, the default is unlimited.
    public uint maxMemberCount;

    /// Whether to enable the user in and out of the room callback notification [onRoomUserUpdate], the default is off. If developers need to use ZEGO Room user notifications, make sure that each user who login sets this flag to true
    public bool isUserStatusNotify;

    /// The token issued by the developer's business server is used to ensure security. For the generation rules, please refer to [Using Token Authentication](https://doc-zh.zego.im/article/10360), the default is an empty string, that is, no authentication. In versions 2.17.0 and above, if appSign is not passed in when calling the [createEngine] API to create an engine, or if appSign is empty, this parameter must be set for authentication when logging in to a room.
    public string token;
}

/**
     * Video config.
     *
     * Configure parameters used for publishing stream, such as bitrate, frame rate, and resolution.
     * Developers should note that the width and height resolution of the mobile and desktop are opposite. For example, 360p, the resolution of the mobile is 360x640, and the desktop is 640x360.
     * When using external capture, the capture and encoding resolution of RTC cannot be set to 0*0, otherwise, there will be no video data in the publishing stream in the entire engine life cycle.
     */
public class ZegoVideoConfig {

    /// Capture resolution width, control the width of camera image acquisition. SDK requires this member to be set to an even number. Only the camera is not started and the custom video capture is not used, the setting is effective. For performance reasons, the SDK scales the video frame to the encoding resolution after capturing from camera and before rendering to the preview view. Therefore, the resolution of the preview image is the encoding resolution. If you need the resolution of the preview image to be this value, Please call [setCapturePipelineScaleMode] first to change the capture pipeline scale mode to [Post]
    public int captureWidth;

    /// Capture resolution height, control the height of camera image acquisition. SDK requires this member to be set to an even number. Only the camera is not started and the custom video capture is not used, the setting is effective. For performance reasons, the SDK scales the video frame to the encoding resolution after capturing from camera and before rendering to the preview view. Therefore, the resolution of the preview image is the encoding resolution. If you need the resolution of the preview image to be this value, Please call [setCapturePipelineScaleMode] first to change the capture pipeline scale mode to [Post]
    public int captureHeight;

    /// Encode resolution width, control the image width of the encoder when publishing stream. SDK requires this member to be set to an even number. The settings before and after publishing stream can be effective
    public int encodeWidth;

    /// Encode resolution height, control the image height of the encoder when publishing stream. SDK requires this member to be set to an even number. The settings before and after publishing stream can be effective
    public int encodeHeight;

    /// Frame rate, control the frame rate of the camera and the frame rate of the encoder. Only the camera is not started, the setting is effective. Publishing stream set to 60 fps, playing stream to take effect need contact technical support
    public int fps;

    /// Bit rate in kbps. The settings before and after publishing stream can be effective
    public int bitrate;

    /// The codec id to be used, the default value is [default]. Settings only take effect before publishing stream
    public ZegoVideoCodecID codecID;

    /// Video keyframe interval, in seconds. Required: No. Default value: 2 seconds. Value range: [2, 5]. Caution: The setting is only valid before pushing.
    public int keyFrameInterval;

    /**
         * Create video configuration with preset enumeration values
         */
    public ZegoVideoConfig(ZegoVideoConfigPreset preset) {
        codecID = ZegoVideoCodecID.Default;
#if UNITY_IOS || UNITY_ANDROID
        switch (preset) {
        case ZegoVideoConfigPreset.Preset180P:
            captureWidth = 180;
            captureHeight = 320;
            encodeWidth = 180;
            encodeHeight = 320;
            bitrate = 300;
            fps = 15;
            break;
        case ZegoVideoConfigPreset.Preset270P:
            captureWidth = 270;
            captureHeight = 480;
            encodeWidth = 270;
            encodeHeight = 480;
            bitrate = 400;
            fps = 15;
            break;
        case ZegoVideoConfigPreset.Preset360P:
            captureWidth = 360;
            captureHeight = 640;
            encodeWidth = 360;
            encodeHeight = 640;
            bitrate = 600;
            fps = 15;
            break;
        case ZegoVideoConfigPreset.Preset540P:
            captureWidth = 540;
            captureHeight = 960;
            encodeWidth = 540;
            encodeHeight = 960;
            bitrate = 1200;
            fps = 15;
            break;
        case ZegoVideoConfigPreset.Preset720P:
            captureWidth = 720;
            captureHeight = 1280;
            encodeWidth = 720;
            encodeHeight = 1280;
            bitrate = 1500;
            fps = 15;
            break;
        case ZegoVideoConfigPreset.Preset1080P:
            captureWidth = 1080;
            captureHeight = 1920;
            encodeWidth = 1080;
            encodeHeight = 1920;
            bitrate = 3000;
            fps = 15;
            break;
        }
#elif UNITY_STANDALONE_OSX || UNITY_STANDALONE_WIN || UNITY_EDITOR
        switch (preset) {
        case ZegoVideoConfigPreset.Preset180P:
            captureWidth = 320;
            captureHeight = 180;
            encodeWidth = 320;
            encodeHeight = 180;
            bitrate = 300;
            fps = 15;
            break;
        case ZegoVideoConfigPreset.Preset270P:
            captureWidth = 480;
            captureHeight = 270;
            encodeWidth = 480;
            encodeHeight = 270;
            bitrate = 400;
            fps = 15;
            break;
        case ZegoVideoConfigPreset.Preset360P:
            captureWidth = 640;
            captureHeight = 360;
            encodeWidth = 640;
            encodeHeight = 360;
            bitrate = 600;
            fps = 15;
            break;
        case ZegoVideoConfigPreset.Preset540P:
            captureWidth = 960;
            captureHeight = 540;
            encodeWidth = 960;
            encodeHeight = 540;
            bitrate = 1200;
            fps = 15;
            break;
        case ZegoVideoConfigPreset.Preset720P:
            captureWidth = 1280;
            captureHeight = 720;
            encodeWidth = 1280;
            encodeHeight = 720;
            bitrate = 1500;
            fps = 15;
            break;
        case ZegoVideoConfigPreset.Preset1080P:
            captureWidth = 1920;
            captureHeight = 1080;
            encodeWidth = 1920;
            encodeHeight = 1080;
            bitrate = 3000;
            fps = 15;
            break;
        }
#else
        // windows by default
        switch (preset) {
        case ZegoVideoConfigPreset.Preset180P:
            captureWidth = 320;
            captureHeight = 180;
            encodeWidth = 320;
            encodeHeight = 180;
            bitrate = 300;
            fps = 15;
            break;
        case ZegoVideoConfigPreset.Preset270P:
            captureWidth = 480;
            captureHeight = 270;
            encodeWidth = 480;
            encodeHeight = 270;
            bitrate = 400;
            fps = 15;
            break;
        case ZegoVideoConfigPreset.Preset360P:
            captureWidth = 640;
            captureHeight = 360;
            encodeWidth = 640;
            encodeHeight = 360;
            bitrate = 600;
            fps = 15;
            break;
        case ZegoVideoConfigPreset.Preset540P:
            captureWidth = 960;
            captureHeight = 540;
            encodeWidth = 960;
            encodeHeight = 540;
            bitrate = 1200;
            fps = 15;
            break;
        case ZegoVideoConfigPreset.Preset720P:
            captureWidth = 1280;
            captureHeight = 720;
            encodeWidth = 1280;
            encodeHeight = 720;
            bitrate = 1500;
            fps = 15;
            break;
        case ZegoVideoConfigPreset.Preset1080P:
            captureWidth = 1920;
            captureHeight = 1080;
            encodeWidth = 1920;
            encodeHeight = 1080;
            bitrate = 3000;
            fps = 15;
            break;
        }
#endif
    }

    /**
         * Create default video configuration(360p, 15fps, 600000bps)
         *
         * 360p, 15fps, 600kbps
         */
    public ZegoVideoConfig() : this(ZegoVideoConfigPreset.Preset360P) {}
}

/**
     * SEI configuration
     *
     * Used to set the relevant configuration of the Supplemental Enhancement Information.
     */
public class ZegoSEIConfig {

    /// SEI type
    public ZegoSEIType type;
}

/**
     * Voice changer parameter.
     *
     * Developer can use the built-in presets of the SDK to change the parameters of the voice changer.
     */
public class ZegoVoiceChangerParam {

    /// Pitch parameter, value range [-12.0, 12.0], the larger the value, the sharper the sound, set it to 0.0 to turn off. Note the tone-shifting sound effect is only effective for the sound played by the media player, and does not change the tone collected by the microphone. Note that on v2.18.0 and older version, the value range is [-8.0, 8.0].
    public float pitch;

    public ZegoVoiceChangerParam() { pitch = 0; }
}

/**
     * Audio reverberation advanced parameters.
     *
     * Developers can use the SDK's built-in presets to change the parameters of the reverb.
     */
public class ZegoReverbAdvancedParam {

    /// Room size(%), in the range [0.0, 1.0], to control the size of the "room" in which the reverb is generated, the larger the room, the stronger the reverb.
    public float roomSize;

    /// Echo(%), in the range [0.0, 100.0], to control the trailing length of the reverb.
    public float reverberance;

    /// Reverb Damping(%), range [0.0, 100.0], controls the attenuation of the reverb, the higher the damping, the higher the attenuation.
    public float damping;

    /// only wet
    public bool wetOnly;

    /// wet gain(dB), range [-20.0, 10.0]
    public float wetGain;

    /// dry gain(dB), range [-20.0, 10.0]
    public float dryGain;

    /// Tone Low. 100% by default
    public float toneLow;

    /// Tone High. 100% by default
    public float toneHigh;

    /// PreDelay(ms), range [0.0, 200.0]
    public float preDelay;

    /// Stereo Width(%). 0% by default
    public float stereoWidth;
}

/**
     * Audio reverberation echo parameters.
     */
public class ZegoReverbEchoParam {

    /// Gain of input audio signal, in the range [0.0, 1.0]
    public float inGain;

    /// Gain of output audio signal, in the range [0.0, 1.0]
    public float outGain;

    /// Number of echos, in the range [0, 7]
    public int numDelays;

    /// Respective delay of echo signal, in milliseconds, in the range [0, 5000] ms
    public int[] delay = new int[7];

    /// Respective decay coefficient of echo signal, in the range [0.0, 1.0]
    public float[] decay = new float[7];
}

/**
     * User object.
     *
     * Configure user ID and username to identify users in the room.
     * Note that the userID must be unique under the same appID, otherwise, there will be mutual kicks when logging in to the room.
     * It is strongly recommended that userID corresponds to the user ID of the business APP, that is, a userID and a real user are fixed and unique, and should not be passed to the SDK in a random userID. Because the unique and fixed userID allows ZEGO technicians to quickly locate online problems.
     */
public class ZegoUser {

    /// User ID, a utf8 string with a maximum length of 64 bytes or less.Privacy reminder: Please do not fill in sensitive user information in this field, including but not limited to mobile phone number, ID number, passport number, real name, etc.Caution: Only support numbers, English characters and '~', '!', '@', '#', '$', '%', '^', '&', '*', '(', ')', '_', '+', '=', '-', '`', ';', '’', ',', '.', '<', '>', '/', '\'.Do not use '%' if you need to communicate with the Web SDK.
    public string userID;

    /// User Name, a utf8 string with a maximum length of 256 bytes or less.Please do not fill in sensitive user information in this field, including but not limited to mobile phone number, ID number, passport number, real name, etc.
    public string userName;

    public ZegoUser(string userId) {
        this.userID = userId;
        this.userName = userId;
    }

    public ZegoUser() {}
}

/**
     * Stream object.
     *
     * Identify an stream object
     */
public class ZegoStream {

    /// User object instance.Please do not fill in sensitive user information in this field, including but not limited to mobile phone number, ID number, passport number, real name, etc.
    public ZegoUser user;

    /// Stream ID, a string of up to 256 characters. Caution: You cannot include URL keywords, otherwise publishing stream and playing stream will fails. Only support numbers, English characters and '-', '_'.
    public string streamID;

    /// Stream extra info
    public string extraInfo;
}

/**
     * Room extra information.
     */
public class ZegoRoomExtraInfo {

    /// The key of the room extra information.
    public string key;

    /// The value of the room extra information.
    public string value;

    /// The user who update the room extra information.Please do not fill in sensitive user information in this field, including but not limited to mobile phone number, ID number, passport number, real name, etc.
    public ZegoUser updateUser;

    /// Update time of the room extra information, UNIX timestamp, in milliseconds.
    public ulong updateTime;
}

/**
     * View related coordinates.
     */
public class ZegoRect {

    /// The horizontal offset from the top-left corner
    public int x;

    /// The vertical offset from the top-left corner
    public int y;

    /// The width of the rectangle
    public int width;

    /// The height of the rectangle
    public int height;

    public ZegoRect(int x, int y, int width, int height) {
        this.x = x;
        this.y = y;
        this.width = width;
        this.height = height;
    }

    public ZegoRect() {}
}

/**
     * View object.
     *
     * Configure view object, view Mode, background color
     */
public class ZegoCanvas {

    /// View object
    public IntPtr view;

    /// View mode, default is ZegoViewModeAspectFit
    public ZegoViewMode viewMode;

    /// Background color, the format is 0xRRGGBB, default is black, which is 0x000000
    public int backgroundColor;
}

/**
     * Advanced publisher configuration.
     *
     * Configure room id
     */
public class ZegoPublisherConfig {

    /// The Room ID, It is not necessary to pass in single room mode, but the ID of the corresponding room must be passed in multi-room mode
    public string roomID;

    /// Whether to synchronize the network time when pushing streams. 1 is synchronized with 0 is not synchronized. And must be used with setStreamAlignmentProperty. It is used to align multiple streams at the mixed stream service or streaming end, such as the chorus scene of KTV.
    public int forceSynchronousNetworkTime;

    /// When pushing a flow, review the pattern of the flow. By default, no audit is performed. If you want to use this function, contact ZEGO technical support.
    public ZegoStreamCensorshipMode streamCensorshipMode;

    public ZegoPublisherConfig() {
        this.roomID = "";
        this.forceSynchronousNetworkTime = 0;
        this.streamCensorshipMode = ZegoStreamCensorshipMode.None;
    }
}

/**
     * Published stream quality information.
     *
     * Audio and video parameters and network quality, etc.
     */
public class ZegoPublishStreamQuality {

    /// Video capture frame rate. The unit of frame rate is f/s
    public double videoCaptureFPS;

    /// Video encoding frame rate. The unit of frame rate is f/s
    public double videoEncodeFPS;

    /// Video transmission frame rate. The unit of frame rate is f/s
    public double videoSendFPS;

    /// Video bit rate in kbps
    public double videoKBPS;

    /// Audio capture frame rate. The unit of frame rate is f/s
    public double audioCaptureFPS;

    /// Audio transmission frame rate. The unit of frame rate is f/s
    public double audioSendFPS;

    /// Audio bit rate in kbps
    public double audioKBPS;

    /// Local to server delay, in milliseconds
    public int rtt;

    /// Packet loss rate, in percentage, 0.0 ~ 1.0
    public double packetLostRate;

    /// Published stream quality level
    public ZegoStreamQualityLevel level;

    /// Whether to enable hardware encoding
    public bool isHardwareEncode;

    /// Video codec ID (Available since 1.17.0)
    public ZegoVideoCodecID videoCodecID;

    /// Total number of bytes sent, including audio, video, SEI
    public double totalSendBytes;

    /// Number of audio bytes sent
    public double audioSendBytes;

    /// Number of video bytes sent
    public double videoSendBytes;
}

/**
     * CDN config object.
     *
     * Includes CDN URL and authentication parameter string
     */
public class ZegoCDNConfig {

    /// CDN URL
    public string url;

    /// Auth param of URL. Please contact ZEGO technical support if you need to use it, otherwise this parameter can be ignored (set to null or empty string).
    public string authParam;

    /// URL supported protocols, candidate values are "tcp" and "quic". If there are more than one, separate them with English commas and try them in order. Please contact ZEGO technical support if you need to use it, otherwise this parameter can be ignored (set to null or empty string).
    public string protocol;

    /// QUIC version。 If [protocol] has the QUIC protocol, this information needs to be filled in. If there are multiple version numbers, separate them with commas. Please contact ZEGO technical support if you need to use it, otherwise this parameter can be ignored (set to null or empty string).
    public string quicVersion;

    /// customized httpdns service. This feature is only supported for playing stream currently.
    public ZegoHttpDNSType httpdns;
}

/**
     * Relay to CDN info.
     *
     * Including the URL of the relaying CDN, relaying state, etc.
     */
public class ZegoStreamRelayCDNInfo {

    /// URL of publishing stream to CDN
    public string url;

    /// State of relaying to CDN
    public ZegoStreamRelayCDNState state;

    /// Reason for relay state changed
    public ZegoStreamRelayCDNUpdateReason updateReason;

    /// The timestamp when the state changed, UNIX timestamp, in milliseconds.
    public ulong stateTime;
}

/**
     * Advanced player configuration.
     *
     * Configure stream resource mode, CDN configuration and other advanced configurations.
     */
public class ZegoPlayerConfig {

    /// Stream resource mode.
    public ZegoStreamResourceMode resourceMode;

    /// The CDN configuration for playing stream. If set, the stream is play according to the URL instead of the streamID. After that, the streamID is only used as the ID of SDK internal callback.
    public ZegoCDNConfig cdnConfig;

    /// The Room ID. It only needs to be filled in the multi-room mode, which indicates which room this stream needs to be bound to. This parameter is ignored in single room mode.
    public string roomID;

    /// The video encoding type of the stream, please contact ZEGO technical support if you need to use it, otherwise this parameter can be ignored.
    public ZegoVideoCodecID videoCodecID;

    /// The resource type of the source stream, please contact ZEGO technical support if you need to use it, otherwise this parameter can be ignored.
    public ZegoResourceType sourceResourceType;

    /// Preconfigured codec template ID, please contact ZEGO technical support if you need to use it, otherwise this parameter can be ignored.
    public int codecTemplateID;

    public ZegoPlayerConfig() {
        resourceMode = ZegoStreamResourceMode.Default;
        cdnConfig = new ZegoCDNConfig();
        roomID = "";
        videoCodecID = ZegoVideoCodecID.Unknown;
        sourceResourceType = ZegoResourceType.RTC;
        codecTemplateID = 0;
    }
}

/**
     * Played stream quality information.
     *
     * Audio and video parameters and network quality, etc.
     */
public class ZegoPlayStreamQuality {

    /// Video receiving frame rate. The unit of frame rate is f/s
    public double videoRecvFPS;

    /// Video dejitter frame rate. The unit of frame rate is f/s (Available since 1.17.0)
    public double videoDejitterFPS;

    /// Video decoding frame rate. The unit of frame rate is f/s
    public double videoDecodeFPS;

    /// Video rendering frame rate. The unit of frame rate is f/s
    public double videoRenderFPS;

    /// Video bit rate in kbps
    public double videoKBPS;

    /// Video break rate, the unit is (number of breaks / every 10 seconds) (Available since 1.17.0)
    public double videoBreakRate;

    /// Audio receiving frame rate. The unit of frame rate is f/s
    public double audioRecvFPS;

    /// Audio dejitter frame rate. The unit of frame rate is f/s (Available since 1.17.0)
    public double audioDejitterFPS;

    /// Audio decoding frame rate. The unit of frame rate is f/s
    public double audioDecodeFPS;

    /// Audio rendering frame rate. The unit of frame rate is f/s
    public double audioRenderFPS;

    /// Audio bit rate in kbps
    public double audioKBPS;

    /// Audio break rate, the unit is (number of breaks / every 10 seconds) (Available since 1.17.0)
    public double audioBreakRate;

    /// The audio quality of the playing stream determined by the audio MOS (Mean Opinion Score) measurement method, value range [-1, 5], where -1 means unknown, [0, 5] means valid score, the higher the score, the better the audio quality. For the subjective perception corresponding to the MOS value, please refer to https://docs.zegocloud.com/article/3720#4_4 (Available since 2.16.0)
    public double mos;

    /// Server to local delay, in milliseconds
    public int rtt;

    /// Packet loss rate, in percentage, 0.0 ~ 1.0
    public double packetLostRate;

    /// Delay from peer to peer, in milliseconds
    public int peerToPeerDelay;

    /// Packet loss rate from peer to peer, in percentage, 0.0 ~ 1.0
    public double peerToPeerPacketLostRate;

    /// Published stream quality level
    public ZegoStreamQualityLevel level;

    /// Delay after the data is received by the local end, in milliseconds
    public int delay;

    /// The difference between the video timestamp and the audio timestamp, used to reflect the synchronization of audio and video, in milliseconds. This value is less than 0 means the number of milliseconds that the video leads the audio, greater than 0 means the number of milliseconds that the video lags the audio, and 0 means no difference. When the absolute value is less than 200, it can basically be regarded as synchronized audio and video, when the absolute value is greater than 200 for 10 consecutive seconds, it can be regarded as abnormal (Available since 1.19.0)
    public int avTimestampDiff;

    /// Whether to enable hardware decoding
    public bool isHardwareDecode;

    /// Video codec ID (Available since 1.17.0)
    public ZegoVideoCodecID videoCodecID;

    /// Total number of bytes received, including audio, video, SEI
    public double totalRecvBytes;

    /// Number of audio bytes received
    public double audioRecvBytes;

    /// Number of video bytes received
    public double videoRecvBytes;
}

/**
     * Device Info.
     *
     * Including device ID and name
     */
public class ZegoDeviceInfo {

    /// Device ID
    public string deviceID;

    /// Device name
    public string deviceName;
}

/**
     * System performance monitoring status
     */
public class ZegoPerformanceStatus {

    /// Current CPU usage of the app, value range [0, 1]
    public double cpuUsageApp;

    /// Current CPU usage of the system, value range [0, 1]
    public double cpuUsageSystem;

    /// Current memory usage of the app, value range [0, 1]
    public double memoryUsageApp;

    /// Current memory usage of the system, value range [0, 1]
    public double memoryUsageSystem;

    /// Current memory used of the app, in MB
    public double memoryUsedApp;
}

/**
     * Beauty configuration options.
     *
     * Configure the parameters of skin peeling, whitening and sharpening
     */
public class ZegoBeautifyOption {

    /// The sample step size of beauty peeling, the value range is [0,1], default 0.2
    public double polishStep;

    /// Brightness parameter for beauty and whitening, the larger the value, the brighter the brightness, ranging from [0,1], default 0.5
    public double whitenFactor;

    /// Beauty sharpening parameter, the larger the value, the stronger the sharpening, value range [0,1], default 0.1
    public double sharpenFactor;
}

/**
     * Mix stream audio configuration.
     *
     * Configure video frame rate, bitrate, and resolution for mixer task
     */
public class ZegoMixerAudioConfig {

    /// Audio bitrate in kbps, default is 48 kbps, cannot be modified after starting a mixer task
    public int bitrate;

    /// Audio channel, default is Mono
    public ZegoAudioChannel channel;

    /// codec ID, default is ZegoAudioCodecIDDefault
    public ZegoAudioCodecID codecID;

    /// Multi-channel audio stream mixing mode. If [ZegoAudioMixMode] is selected as [Focused], the SDK will select 4 input streams with [isAudioFocus] set as the focus voice highlight. If it is not selected or less than 4 channels are selected, it will automatically fill in 4 channels
    public ZegoAudioMixMode mixMode;

    public ZegoMixerAudioConfig() {
        bitrate = 48;
        channel = ZegoAudioChannel.Mono;
        codecID = ZegoAudioCodecID.Default;
        mixMode = ZegoAudioMixMode.Raw;
    }
}

/**
     * Mix stream video config object.
     *
     * Configure video frame rate, bitrate, and resolution for mixer task
     */
public class ZegoMixerVideoConfig {

    /// Video resolution width
    public int width;

    /// Video resolution height
    public int height;

    /// Video FPS, cannot be modified after starting a mixer task
    public int fps;

    /// Video bitrate in kbps
    public int bitrate;

    /// Video quality, this value is valid when the video rate control mode parameter is set to constant quality. The valid value ranges from 0 to 51. The default value is 23. If you want better video quality, lower the quality value based on 23 to test the adjustment. If you want a smaller file size, test the adjustment by increasing the high quality value at the base of 23. Take the file size under the value x as an example. The file size under the value x + 6 is half the size of the file size under the value x, and the file size under the value x-6 is twice the size of the file size under the value x.
    public int quality;

    /// Video bitrate control mode
    public ZegoVideoRateControlMode rateControlMode;

    public ZegoMixerVideoConfig() {
        width = 360;
        height = 640;
        fps = 15;
        bitrate = 600;
        quality = 23;
        rateControlMode = ZegoVideoRateControlMode.ConstantRate;
    }

    public ZegoMixerVideoConfig(int width, int height, int fps, int bitrate) {
        this.width = width;
        this.height = height;
        this.fps = fps;
        this.bitrate = bitrate;
        this.quality = 23;
        this.rateControlMode = ZegoVideoRateControlMode.ConstantRate;
    }
}

/**
     * Mix stream output video config object.
     *
     * Description: Configure the video parameters, coding format and bitrate of mix stream output.
     * Use cases: Manual mixed stream scenario, such as Co-hosting.
     */
public class ZegoMixerOutputVideoConfig {

    /// Mix stream output video coding format, supporting H.264 and h.265 coding.
    public ZegoVideoCodecID videoCodecID;

    /// Mix stream output video bitrate in kbps. The default value is the bitrate configured in [ZegoMixerVideoConfig].
    public int bitrate;

    /// Mix stream video encode profile. Default value is [ZegoEncodeProfileDefault].
    public ZegoEncodeProfile encodeProfile;

    /// The video encoding delay of mixed stream output, Valid value range [0, 2000], in milliseconds. The default value is 0.
    public int encodeLatency;

    public ZegoMixerOutputVideoConfig() {
        this.videoCodecID = ZegoVideoCodecID.Default;
        this.bitrate = 0;
        this.encodeProfile = ZegoEncodeProfile.Default;
        this.encodeLatency = 0;
    }
}

/**
     * Font style.
     *
     * Description: Font style configuration, can be used to configure font type, font size, font color, font transparency.
     * Use cases: Set text watermark in manual stream mixing scene, such as Co-hosting.
     */
public class ZegoFontStyle {

    /// Font type. Required: False. Default value: Source han sans [ZegoFontTypeSourceHanSans]
    public ZegoFontType type;

    /// Font size in px. Required: False. Default value: 24. Value range: [12,100].
    public int size;

    /// Font color, the calculation formula is: R + G x 256 + B x 65536, the value range of R (red), G (green), and B (blue) [0,255]. Required: False. Default value: 16777215(white). Value range: [0,16777215].
    public int color;

    /// Font transparency. Required: False. Default value: 0. Value range: [0,100], 100 is completely opaque, 0 is completely transparent.
    public int transparency;

    /// Whether the font has a border. Required: False. Default value: False. Value range: True/False.
    public bool border;

    /// Font border color, the calculation formula is: R + G x 256 + B x 65536, the value range of R (red), G (green), and B (blue) [0,255]. Required: False. Default value: 0. Value range: [0,16777215].
    public int borderColor;

    public ZegoFontStyle() {
        this.type = ZegoFontType.SourceHanSans;
        this.size = 24;
        this.color = 16777215;
        this.transparency = 0;
        this.border = false;
        this.borderColor = 0;
    }
}

/**
     * Label info.
     *
     * Description: Font style configuration, can be used to configure font type, font si-e, font color, font transparency.
     * Use cases: Set text watermark in manual stream mixing scene, such as Co-hosting.
     */
public class ZegoLabelInfo {

    /// Text content, support for setting simplified Chinese, English, half-width, not full-width. Required: True.Value range: Maximum support for displaying 100 Chinese characters and 300 English characters.
    public string text;

    /// The distance between the font and the left border of the output canvas, in px. Required: False. Default value: 0.
    public int left;

    /// The distance between the font and the top border of the output canvas, in px. Required: False. Default value: 0.
    public int top;

    /// Font style. Required: False.
    public ZegoFontStyle font;

    public ZegoLabelInfo(string text) {
        this.text = text;
        this.left = 0;
        this.top = 0;
        this.font = new ZegoFontStyle();
    }
}

/**
     * Set the image information of a single input stream in the mux.
     *
     * Available since: 2.19.0
     * Description: Sets a picture for the content of a single input stream, which is used in place of the video, i.e. the video is not displayed when the picture is used. The `layout` layout in [ZegoMixerInput] for image multiplexing.
     * Use case: The developer needs to temporarily turn off the camera to display the image during the video connection to the microphone, or display the picture when the audio is connected to the microphone.
     * Restrictions: Image size is limited to 1M.
     */
public class ZegoMixerImageInfo {

    /// The image path, if not empty, the image will be displayed, otherwise, the video will be displayed. JPG and PNG formats are supported. There are 2 ways to use it: 1. URI: Provide the picture to ZEGO technical support for configuration. After the configuration is complete, the picture URI will be provided, for example: preset-id://xxx.jpg. 2. URL: Only HTTP protocol is supported.
    public string url;

    public ZegoMixerImageInfo(string url) { this.url = url; }
}

/**
     * Mixer input.
     *
     * Configure the mix stream input stream ID, type, and the layout
     */
public class ZegoMixerInput {

    /// Stream ID, a string of up to 256 characters. Caution: You cannot include URL keywords, otherwise publishing stream and playing stream will fails. Only support numbers, English characters and '-', '_'.
    public string streamID;

    /// Mix stream content type
    public ZegoMixerInputContentType contentType;

    /// Stream layout. When the mixed stream is an audio stream (that is, the ContentType parameter is set to the audio mixed stream type). Developers do not need to assign a value to this field, just use the SDK default.
    public ZegoRect layout;

    /// If enable soundLevel in mix stream task, an unique soundLevelID is need for every stream
    public uint soundLevelID;

    /// Input stream volume, valid range [0, 200], default is 100
    public uint volume;

    /// Whether the focus voice is enabled in the current input stream, the sound of this stream will be highlighted if enabled
    public bool isAudioFocus;

    /// The direction of the audio. Valid direction is between 0 to 360. Set -1 means disable. Default value is -1
    public int audioDirection;

    /// Text watermark.
    public ZegoLabelInfo label;

    /// Video view render mode.
    public ZegoMixRenderMode renderMode;

    /// User image information.
    public ZegoMixerImageInfo imageInfo;

    /// Description: Video frame corner radius, in px. Required: False. Value range: Does not exceed the width and height of the video screen set by the [layout] parameter. Default value: 0.
    public uint cornerRadius;

    public ZegoMixerInput(string streamID, ZegoMixerInputContentType contentType, ZegoRect layout) {
        this.streamID = streamID;
        this.contentType = contentType;
        this.layout = layout;
        this.soundLevelID = 0;
        this.volume = 100;
        this.isAudioFocus = false;
        this.audioDirection = -1;
        this.label = new ZegoLabelInfo("");
        this.renderMode = ZegoMixRenderMode.Fill;
        this.imageInfo = new ZegoMixerImageInfo("");
        this.cornerRadius = 0;
    }

    public ZegoMixerInput(string streamID, ZegoMixerInputContentType contentType, ZegoRect layout,
                          uint soundLevelID) {
        this.streamID = streamID;
        this.contentType = contentType;
        this.layout = layout;
        this.soundLevelID = soundLevelID;
        this.volume = 100;
        this.isAudioFocus = false;
        this.audioDirection = -1;
        this.label = new ZegoLabelInfo("");
        this.renderMode = ZegoMixRenderMode.Fill;
        this.imageInfo = new ZegoMixerImageInfo("");
        this.cornerRadius = 0;
    }
}

/**
     * Mixer output object, currently, a mixed-stream task only supports a maximum of four video streams with different resolutions.
     *
     * Configure mix stream output target URL or stream ID
     */
public class ZegoMixerOutput {

    /// Mix stream output target, URL or stream ID, if set to be URL format, only RTMP URL surpported, for example rtmp://xxxxxxxx, addresses with two identical mixed-stream outputs cannot be passed in.
    public string target;

    /// Mix stream output video config
    public ZegoMixerOutputVideoConfig videoConfig;

    public ZegoMixerOutput(string target) {
        this.target = target;
        this.videoConfig = new ZegoMixerOutputVideoConfig();
    }
}

/**
     * Watermark object.
     *
     * Configure a watermark image URL and the layout of the watermark in the screen.
     */
public class ZegoWatermark {

    /// The path of the watermark image. Support local file absolute path (file://xxx). The format supports png, jpg.
    public string imageURL;

    /// Watermark image layout
    public ZegoRect layout;
}

/**
     * Mix stream task object.
     *
     * This class is the configuration class of the stream mixing task. When a stream mixing task is requested to the ZEGO RTC server, the configuration of the stream mixing task is required.
     * This class describes the detailed configuration information of this stream mixing task.
     */
public class ZegoMixerTask {

    /// Mix stream task ID
    public string taskID;

    /// Mix stream audio config
    public ZegoMixerAudioConfig audioConfig;

    /// Mix stream audio config
    public ZegoMixerVideoConfig videoConfig;

    /// Mix stream task input list
    public List<ZegoMixerInput> inputList;

    /// Mix stream task output list
    public List<ZegoMixerOutput> outputList;

    /// Mix stream wate rmark
    public ZegoWatermark watermark;

    /// Mix stream background color, The color value corresponding to RGBA is 0xRRGGBBAA, and setting the transparency of the background color is currently not supported. The AA in 0xRRGGBBAA is 00. For example, select RGB as \#87CEFA as the background color, this parameter passes 0x87CEFA00.
    public int backgroundColor;

    /// Mix stream background image URL
    public string backgroundImageURL;

    /// Enable or disable sound level callback for the task. If enabled, then the remote player can get the soundLevel of every stream in the inputlist by [onMixerSoundLevelUpdate] callback.
    public bool enableSoundLevel;

    /// The stream mixing alignment mode
    public ZegoStreamAlignmentMode streamAlignmentMode;

    /// User data, the length of user data should not be more than 1000 bytes,After setting, the streaming party can obtain the SEI content by listening to the callback of [onPlayerRecvSEI].
    public IntPtr userData;

    /// User data length, not greater than 1000.Note that only data with length will be read by SDK. If the length is greater than the actual length of data, the SDK will read the data according to the actual length of data.
    public uint userDataLength;

    /// Set advanced configuration, such as specifying video encoding and others. If you need to use it, contact ZEGO technical support.
    public Dictionary<string, string> advancedConfig;

    /// Sets the lower limit of the interval range for the adaptive adjustment of the stream playing cache of the stream mixing server. In the real-time chorus KTV scenario, slight fluctuations in the network at the push end may cause the mixed stream to freeze. At this time, when the audience pulls the mixed stream, there is a high probability of the problem of freeze. By adjusting the lower limit of the interval range for the adaptive adjustment of the stream playing cache of the stream mixing server, it can optimize the freezing problem that occurs when playing mixing streams at the player end, but it will increase the delay. It is not set by default, that is, the server uses its own configuration values. It only takes effect for the new input stream setting, and does not take effect for the input stream that has already started mixing.
    public int minPlayStreamBufferLength;

    /**
         * Create a mix stream task object with TaskID
         */
    public ZegoMixerTask(string taskID) {
        this.taskID = taskID;
        inputList = new List<ZegoMixerInput>();
        outputList = new List<ZegoMixerOutput>();
        audioConfig = new ZegoMixerAudioConfig();
        videoConfig = new ZegoMixerVideoConfig();
        backgroundImageURL = "";
        streamAlignmentMode = ZegoStreamAlignmentMode.None;
        advancedConfig = new Dictionary<string, string>();
        minPlayStreamBufferLength = -1;
    }
}

/**
     * Configuration for start sound level monitor.
     */
public class ZegoSoundLevelConfig {

    /// Monitoring time period of the sound level, in milliseconds, has a value range of [100, 3000]. Default is 100 ms.
    public uint millisecond;

    /// Set whether the sound level callback includes the VAD detection result.
    public bool enableVAD;
}

/**
     * Sound level info object.
     */
public class ZegoSoundLevelInfo {

    /// Sound level value.
    public float soundLevel;

    /// Whether the stream corresponding to StreamID contains voice, 0 means noise, 1 means normal voice. This value is valid only when the [enableVAD] parameter in the [ZegoSoundLevelConfig] configuration is set to true when calling [startSoundLevelMonitor].
    public int vad;
}

/**
     * Auto mix stream task object.
     *
     * Description: When using [StartAutoMixerTask] function to start an auto stream mixing task to the ZEGO RTC server, user need to set this parameter to configure the auto stream mixing task, including the task ID, room ID, audio configuration, output stream list, and whether to enable the sound level callback.
     * Use cases: This configuration is required when an auto stream mixing task is requested to the ZEGO RTC server.
     * Caution: As an argument passed when [StartAutoMixerTask] function is called.
     */
public class ZegoAutoMixerTask {

    /// The taskID of the auto mixer task.Description: Auto stream mixing task id, must be unique in a room.Use cases: User need to set this parameter when initiating an auto stream mixing task.Required: Yes.Recommended value: Set this parameter based on requirements.Value range: A string up to 256 bytes.Caution: When starting a new auto stream mixing task, only one auto stream mixing task ID can exist in a room, that is, to ensure the uniqueness of task ID. You are advised to associate task ID with room ID. You can directly use the room ID as the task ID.Cannot include URL keywords, for example, 'http' and '?' etc, otherwise publishing stream and playing stream will fail. Only support numbers, English characters and '~', '!', '@', '$', '%', '^', '&', '*', '(', ')', '_', '+', '=', '-', '`', ';', '’', ',', '.', '<', '>', '/', '\'.
    public string taskID;

    /// The roomID of the auto mixer task.Description: Auto stream mixing task id.Use cases: User need to set this parameter when initiating an auto stream mixing task.Required: Yes.Recommended value: Set this parameter based on requirements.Value range: A string up to 128 bytes.Caution: Only support numbers, English characters and '~', '!', '@', '#', '$', '%', '^', '&', '*', '(', ')', '_', '+', '=', '-', '`', ';', '’', ',', '.', '<', '>', '/', '\'.If you need to communicate with the Web SDK, please do not use '%'.
    public string roomID;

    /// The audio config of the auto mixer task.Description: The audio config of the auto mixer task.Use cases: If user needs special requirements for the audio config of the auto stream mixing task, such as adjusting the audio bitrate, user can set this parameter as required. Otherwise, user do not need to set this parameter.Required: No.Default value: The default audio bitrate is `48 kbps`, the default audio channel is `ZEGO_AUDIO_CHANNEL_MONO`, the default encoding ID is `ZEGO_AUDIO_CODEC_ID_DEFAULT`, and the default multi-channel audio stream mixing mode is `ZEGO_AUDIO_MIX_MODE_RAW`.Recommended value: Set this parameter based on requirements.
    public ZegoMixerAudioConfig audioConfig;

    /// The output list of the auto mixer task.Description: The output list of the auto stream mixing task, items in the list are URL or stream ID, if the item set to be URL format, only RTMP URL surpported, for example rtmp://xxxxxxxx.Use cases: User need to set this parameter to specify the mix stream output target when starting an auto stream mixing task.Required: Yes.
    public List<ZegoMixerOutput> outputList;

    /// Enable or disable sound level callback for the task. If enabled, then the remote player can get the sound level of every stream in the inputlist by [onAutoMixerSoundLevelUpdate] callback.Description: Enable or disable sound level callback for the task.If enabled, then the remote player can get the sound level of every stream in the inputlist by [onAutoMixerSoundLevelUpdate] callback.Use cases: This parameter needs to be configured if user need the sound level information of every stream when an auto stream mixing task started.Required: No.Default value: `false`.Recommended value: Set this parameter based on requirements.
    public bool enableSoundLevel;

    /// Stream mixing alignment mode.
    public ZegoStreamAlignmentMode streamAlignmentMode;

    /**
         * Create a auto mix stream task object
         */
    public ZegoAutoMixerTask() {
        this.taskID = "";
        this.roomID = "";
        outputList = new List<ZegoMixerOutput>();
        audioConfig = new ZegoMixerAudioConfig();
        enableSoundLevel = false;
        streamAlignmentMode = ZegoStreamAlignmentMode.None;
    }
}

/**
     * Broadcast message info.
     *
     * The received object of the room broadcast message, including the message content, message ID, sender, sending time
     */
public class ZegoBroadcastMessageInfo {

    /// message content
    public string message;

    /// message id
    public ulong messageID;

    /// Message send time, UNIX timestamp, in milliseconds.
    public ulong sendTime;

    /// Message sender.Please do not fill in sensitive user information in this field, including but not limited to mobile phone number, ID number, passport number, real name, etc.
    public ZegoUser fromUser;
}

/**
     * Barrage message info.
     *
     * The received object of the room barrage message, including the message content, message ID, sender, sending time
     */
public class ZegoBarrageMessageInfo {

    /// message content
    public string message;

    /// message id
    public string messageID;

    /// Message send time, UNIX timestamp, in milliseconds.
    public ulong sendTime;

    /// Message sender.Please do not fill in sensitive user information in this field, including but not limited to mobile phone number, ID number, passport number, real name, etc.
    public ZegoUser fromUser;
}

/**
     * Object for video frame fieldeter.
     *
     * Including video frame format, width and height, etc.
     */
public class ZegoVideoFrameParam {

    /// Video frame format
    public ZegoVideoFrameFormat format;

    /// Number of bytes per line (for example: BGRA only needs to consider strides [0], I420 needs to consider strides [0,1,2])
    public int[] strides;

    /// Video frame width. When use custom video capture, the video data meeting the 32-bit alignment can obtain the maximum performance. Taking BGRA as an example, width * 4 is expected to be multiple of 32.
    public int width;

    /// Video frame height
    public int height;

    /// The rotation direction of the video frame, the SDK rotates clockwise
    public int rotation;
}

/**
     * Parameter object for audio frame.
     *
     * Including the sampling rate and channel of the audio frame
     */
public class ZegoAudioFrameParam {

    /// Sampling Rate
    public ZegoAudioSampleRate sampleRate = ZegoAudioSampleRate.Unknown;

    /// Audio channel, default is Mono
    public ZegoAudioChannel channel = ZegoAudioChannel.Mono;
}

/**
     * Audio configuration.
     *
     * Configure audio bitrate, audio channel, audio encoding for publishing stream
     */
public class ZegoAudioConfig {

    /// Audio bitrate in kbps, default is 48 kbps. The settings before and after publishing stream can be effective
    public int bitrate;

    /// Audio channel, default is Mono. The setting only take effect before publishing stream
    public ZegoAudioChannel channel;

    /// codec ID, default is ZegoAudioCodecIDDefault. The setting only take effect before publishing stream
    public ZegoAudioCodecID codecID;

    /**
         * Create a default audio configuration (ZegoAudioConfigPresetStandardQuality, 48 kbps, Mono, ZegoAudioCodecIDDefault)
         */
    public ZegoAudioConfig() : this(ZegoAudioConfigPreset.StandardQuality) {}

    /**
         * Create a audio configuration with preset enumeration values
         */
    public ZegoAudioConfig(ZegoAudioConfigPreset presetType) {
        codecID = ZegoAudioCodecID.Default;
        switch (presetType) {
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

/**
     * Record config.
     */
public class ZegoDataRecordConfig {

    /// The path to save the recording file, absolute path, need to include the file name, the file name need to specify the suffix, currently supports .mp4/.flv/.aac format files, if multiple recording for the same path, will overwrite the file with the same name. The maximum length should be less than 1024 bytes.
    public string filePath;

    /// Type of recording media
    public ZegoDataRecordType recordType;
}

/**
     * File recording progress.
     */
public class ZegoDataRecordProgress {

    /// Current recording duration in milliseconds
    public ulong duration;

    /// Current recording file size in byte
    public ulong currentFileSize;
}

/**
     * The NTP info
     */
public class ZegoNetworkTimeInfo {

    /// Network timestamp after synchronization, 0 indicates not yet synchronized
    public ulong timestamp;

    /// The max deviation
    public int maxDeviation;
}

/**
     * AudioEffectPlayer play configuration.
     */
public class ZegoAudioEffectPlayConfig {

    /// The number of play counts. When set to 0, it will play in an infinite loop until the user invoke [stop]. The default is 1, which means it will play only once.
    public uint playCount;

    /// Whether to mix audio effects into the publishing stream, the default is false.
    public bool isPublishOut;
}

/**
     * Precise seek configuration
     */
public class ZegoAccurateSeekConfig {

    /// The timeout time for precise search; if not set, the SDK internal default is set to 5000 milliseconds, the effective value range is [2000, 10000], the unit is ms
    public ulong timeout;

    public ZegoAccurateSeekConfig() { timeout = 5000; }
}

/**
     * Media player network cache information
     */
public class ZegoNetWorkResourceCache {

    /// Cached duration, unit ms
    public uint time;

    /// Cached size, unit byte
    public uint size;
}

/**
     * CopyrightedMusic play configuration.
     */
public class ZegoCopyrightedMusicConfig {

    /// User object instance, configure userID, userName. Note that the user ID set here needs to be consistent with the user ID set when logging in to the room, otherwise the request for the copyright music background service will fail.
    public ZegoUser user;
}

/**
     * The configuration of requesting resource.
     */
public class ZegoCopyrightedMusicRequestConfig {

    /// the ID of the song.
    public string songID;

    /// VOD billing mode.
    public ZegoCopyrightedMusicBillingMode mode;

    /// Copyright music resource song copyright provider.
    public ZegoCopyrightedMusicVendorID vendorID;

    /// The room ID, the single-room mode can not be passed, and the corresponding room ID must be passed in the multi-room mode. Indicate in which room to order song/accompaniment/accompaniment clip/accompaniment segment.
    public string roomID;

    /// The master ID, which must be passed when the billing mode is billed by host. Indicate which homeowner to order song/accompaniment/accompaniment clip/accompaniment segment.
    public string masterID;

    /// The scene ID, indicate the actual business. For details, please consult ZEGO technical support.
    public int sceneID;
}

}
