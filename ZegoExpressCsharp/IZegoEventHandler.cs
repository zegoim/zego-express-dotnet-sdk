using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
namespace ZEGO
{

    public class IZegoEventHandler
    {
        /**
         * The callback for obtaining debugging error information.
         *
         * Available since: 1.1.0
         * Description: When the SDK functions are not used correctly, the callback prompts for detailed error information.
         * Trigger: Notify the developer when an exception occurs in the SDK.
         * Restrictions: None.
         * Caution: None.
         *
         * @param errorCode Error code, please refer to the error codes document https://docs.zegocloud.com/en/5548.html for details.
         * @param funcName Function name.
         * @param info Detailed error information.
         */
        public delegate void OnDebugError(int errorCode, string funcName, string info);

        /**
         * The callback triggered when the audio/video engine state changes.
         *
         * Available since: 1.1.0
         * Description: Callback notification of audio/video engine status update. When audio/video functions are enabled, such as preview, push streaming, local media player, audio data observering, etc., the audio/video engine will enter the start state. When you exit the room or disable all audio/video functions , The audio/video engine will enter the stop state.
         * Trigger: The developer called the relevant function to change the state of the audio and video engine. For example: 1. Called ZegoExpressEngine's [startPreview], [stopPreview], [startPublishingStream], [stopPublishingStream], [startPlayingStream], [stopPlayingStream], [startAudioDataObserver], [stopAudioDataObserver] and other functions. 2. The related functions of MediaPlayer are called. 3. The [LogoutRoom] function was called. 4. The related functions of RealTimeSequentialDataManager are called.
         * Restrictions: None.
         * Caution:
         *   1. When the developer calls [destroyEngine], this notification will not be triggered because the resources of the SDK are completely released.
         *   2. If there is no special need, the developer does not need to pay attention to this callback.
         *
         * @param state The audio/video engine state.
         */
        public delegate void OnEngineStateUpdate(ZegoEngineState state);

        /**
         * The callback triggered when the room connection state changes.
         *
         * Available since: 1.1.0
         * Description: This callback is triggered when the connection status of the room changes, and the reason for the change is notified.For versions 2.18.0 and above, it is recommended to use the onRoomStateChanged callback instead of the onRoomStateUpdate callback to monitor room state changes.
         * Use cases: Developers can use this callback to determine the status of the current user in the room.
         * When to trigger:
         *  1. The developer will receive this notification when calling the [loginRoom], [logoutRoom], [switchRoom] functions.
         *  2. This notification may also be received when the network condition of the user's device changes (SDK will automatically log in to the room when disconnected, please refer to [Does ZEGO SDK support a fast reconnection for temporary disconnection] for details](https://docs.zegocloud.com/faq/reconnect?product=ExpressVideo&platform=all).
         * Restrictions: None.
         * Caution: If the connection is being requested for a long time, the general probability is that the user's network is unstable.
         * Related APIs: [loginRoom]、[logoutRoom]、[switchRoom]
         *
         * @param roomID Room ID, a string of up to 128 bytes in length.
         * @param state Changed room state.
         * @param errorCode Error code, For details, please refer to [Common Error Codes](https://docs.zegocloud.com/article/5548).
         * @param extendedData Extended Information with state updates. When the room login is successful, the key "room_session_id" can be used to obtain the unique RoomSessionID of each audio and video communication, which identifies the continuous communication from the first user in the room to the end of the audio and video communication. It can be used in scenarios such as call quality scoring and call problem diagnosis.
         */
        public delegate void OnRoomStateUpdate(string roomID, ZegoRoomState state, int errorCode, string extendedData);

        /**
         * The callback triggered when the number of other users in the room increases or decreases.
         *
         * Available since: 1.1.0
         * Description: When other users in the room are online or offline, which causes the user list in the room to change, the developer will be notified through this callback.
         * Use cases: Developers can use this callback to update the user list display in the room in real time.
         * When to trigger:
         *   1. When the user logs in to the room for the first time, if there are other users in the room, the SDK will trigger a callback notification with `updateType` being [ZegoUpdateTypeAdd], and `userList` is the other users in the room at this time.
         *   2. The user is already in the room. If another user logs in to the room through the [loginRoom] or [switchRoom] functions, the SDK will trigger a callback notification with `updateType` being [ZegoUpdateTypeAdd].
         *   3. If other users log out of this room through the [logoutRoom] or [switchRoom] functions, the SDK will trigger a callback notification with `updateType` being [ZegoUpdateTypeDelete].
         *   4. The user is already in the room. If another user is kicked out of the room from the server, the SDK will trigger a callback notification with `updateType` being [ZegoUpdateTypeDelete].
         * Restrictions: If developers need to use ZEGO room users notifications, please ensure that the [ZegoRoomConfig] sent by each user when logging in to the room has the [isUserStatusNotify] property set to true, otherwise the callback notification will not be received.
         * Related APIs: [loginRoom]、[logoutRoom]、[switchRoom]
         *
         * @param roomID Room ID where the user is logged in, a string of up to 128 bytes in length.
         * @param updateType Update type (add/delete).
         * @param userList List of users changed in the current room.
         */
        public delegate void OnRoomUserUpdate(string roomID, ZegoUpdateType updateType, List<ZegoUser> userList, uint userCount);

        /**
         * The callback triggered every 30 seconds to report the current number of online users.
         *
         * Available since: 1.7.0
         * Description: This method will notify the user of the current number of online users in the room.
         * Use cases: Developers can use this callback to show the number of user online in the current room.
         * When to call /Trigger: After successfully logging in to the room.
         * Restrictions: None.
         * Caution: 1. This function is called back every 30 seconds. 2. Because of this design, when the number of users in the room exceeds 500, there will be some errors in the statistics of the number of online people in the room.
         *
         * @param roomID Room ID where the user is logged in, a string of up to 128 bytes in length.
         * @param count Count of online users.
         */
        public delegate void OnRoomOnlineUserCountUpdate(string roomID, int count);

        /**
         * The callback triggered when the number of streams published by the other users in the same room increases or decreases.
         *
         * Available since: 1.1.0
         * Description: When other users in the room start streaming or stop streaming, the streaming list in the room changes, and the developer will be notified through this callback.
         * Use cases: This callback is used to monitor stream addition or stream deletion notifications of other users in the room. Developers can use this callback to determine whether other users in the same room start or stop publishing stream, so as to achieve active playing stream [startPlayingStream] or take the initiative to stop the playing stream [stopPlayingStream], and use it to change the UI controls at the same time.
         * When to trigger:
         *   1. When the user logs in to the room for the first time, if there are other users publishing streams in the room, the SDK will trigger a callback notification with `updateType` being [ZegoUpdateTypeAdd], and `streamList` is an existing stream list.
         *   2. The user is already in the room. if another user adds a new push, the SDK will trigger a callback notification with `updateType` being [ZegoUpdateTypeAdd].
         *   3. The user is already in the room. If other users stop streaming, the SDK will trigger a callback notification with `updateType` being [ZegoUpdateTypeDelete].
         *   4. The user is already in the room. If other users leave the room, the SDK will trigger a callback notification with `updateType` being [ZegoUpdateTypeDelete].
         * Restrictions: None.
         *
         * @param roomID Room ID where the user is logged in, a string of up to 128 bytes in length.
         * @param updateType Update type (add/delete).
         * @param streamList Updated stream list.
         * @param extendedData Extended information with stream updates.When receiving a stream deletion notification, the developer can convert the string into a json object to get the stream_delete_reason field, which is an array of stream deletion reasons, and the stream_delete_reason[].code field may have the following values: 1 (the user actively stops publishing stream) ; 2 (user heartbeat timeout); 3 (user repeated login); 4 (user kicked out); 5 (user disconnected); 6 (removed by the server).
         */
        public delegate void OnRoomStreamUpdate(string roomID, ZegoUpdateType updateType, List<ZegoStream> streamList, string extendedData);

        /**
         * The callback triggered when there is an update on the extra information of the streams published by other users in the same room.
         *
         * Available since: 1.1.0
         * Description: All users in the room will be notified by this callback when the extra information of the stream in the room is updated.
         * Use cases: Users can realize some business functions through the characteristics of stream extra information consistent with stream life cycle.
         * When to call /Trigger: When a user publishing the stream update the extra information of the stream in the same room, other users in the same room will receive the callback.
         * Restrictions: None.
         * Caution: Unlike the stream ID, which cannot be modified during the publishing process, the stream extra information can be updated during the life cycle of the corresponding stream ID.
         * Related APIs: Users who publish stream can set extra stream information through [setStreamExtraInfo].
         *
         * @param roomID Room ID where the user is logged in, a string of up to 128 bytes in length.
         * @param streamList List of streams that the extra info was updated.
         */
        public delegate void OnRoomStreamExtraInfoUpdate(string roomID, List<ZegoStream> streamList);

        /**
         * The callback triggered when there is an update on the extra information of the room.
         *
         * Available since: 1.1.0
         * Description: After the room extra information is updated, all users in the room will be notified except update the room extra information user.
         * Use cases: Extra information for the room.
         * When to call /Trigger: When a user update the room extra information, other users in the same room will receive the callback.
         * Restrictions: None.
         * Related APIs: Users can update room extra information through [setRoomExtraInfo] function.
         *
         * @param roomID Room ID where the user is logged in, a string of up to 128 bytes in length.
         * @param roomExtraInfoList List of the extra info updated.
         */
        public delegate void OnRoomExtraInfoUpdate(string roomID, List<ZegoRoomExtraInfo> roomExtraInfoList);

        /**
         * The callback triggered when the state of stream publishing changes.
         *
         * Available since: 1.1.0
         * Description: After calling the [startPublishingStream] successfully, the notification of the publish stream state change can be obtained through the callback function. You can roughly judge the user's uplink network status based on whether the state parameter is in [PUBLISH_REQUESTING].
         * Caution: The parameter [extendedData] is extended information with state updates. If you use ZEGO's CDN content distribution network, after the stream is successfully published, the keys of the content of this parameter are [flv_url_list], [rtmp_url_list], [hls_url_list], these correspond to the publishing stream URLs of the flv, rtmp, and hls protocols.
         * Related callbacks: After calling the [startPlayingStream] successfully, the notification of the play stream state change can be obtained through the callback function [onPlayerStateUpdate]. You can roughly judge the user's downlink network status based on whether the state parameter is in [PLAY_REQUESTING].
         *
         * @param streamID Stream ID.
         * @param state State of publishing stream.
         * @param errorCode The error code corresponding to the status change of the publish stream, please refer to the error codes document https://docs.zegocloud.com/en/5548.html for details.
         * @param extendedData Extended information with state updates, include playing stream CDN address.
         */
        public delegate void OnPublisherStateUpdate(string streamID, ZegoPublisherState state, int errorCode, string extendedData);

        /**
         * Callback for current stream publishing quality.
         *
         * Available since: 1.1.0
         * Description: After calling the [startPublishingStream] successfully, the callback will be received every 3 seconds default(If you need to change the time, please contact the instant technical support to configure). Through the callback, the collection frame rate, bit rate, RTT, packet loss rate and other quality data of the published audio and video stream can be obtained, and the health of the publish stream can be monitored in real time.You can monitor the health of the published audio and video streams in real time according to the quality parameters of the callback function, in order to show the uplink network status in real time on the device UI.
         * Caution: If you does not know how to use the parameters of this callback function, you can only pay attention to the [level] field of the [quality] parameter, which is a comprehensive value describing the uplink network calculated by SDK based on the quality parameters.
         * Related callbacks: After calling the [startPlayingStream] successfully, the callback [onPlayerQualityUpdate] will be received every 3 seconds. You can monitor the health of play streams in real time based on quality data such as frame rate, code rate, RTT, packet loss rate, etc.
         *
         * @param streamID Stream ID.
         * @param quality Publishing stream quality, including audio and video framerate, bitrate, RTT, etc.
         */
        public delegate void OnPublisherQualityUpdate(string streamID, ZegoPublishStreamQuality quality);

        /**
         * The callback triggered when the first audio frame is captured.
         *
         * Available since: 1.1.0
         * Description: This callback will be received when the SDK starts the microphone to capture the first frame of audio data. If this callback is not received, the audio capture device is occupied or abnormal.
         * Trigger: When the engine of the audio/video module inside the SDK starts, the SDK will go and collect the audio data from the local device and will receive the callback at that time.
         * Related callbacks: Determine if the SDK actually collected video data by the callback function [onPublisherCapturedVideoFirstFrame], determine if the SDK has rendered the first frame of video data collected by calling back [onPublisherRenderVideoFirstFrame].
         */
        public delegate void OnPublisherCapturedAudioFirstFrame();

        /**
         * The callback triggered when the first video frame is captured.
         *
         * Available since: 1.1.0
         * Description: The SDK will receive this callback when the first frame of video data is captured. If this callback is not received, the video capture device is occupied or abnormal.
         * Trigger: When the SDK's internal audio/video module's engine starts, the SDK will collect video data from the local device and will receive this callback.
         * Related callbacks: Determine if the SDK actually collected audio data by the callback function [onPublisherCapturedAudioFirstFrame], determine if the SDK has rendered the first frame of video data collected by calling back [onPublisherRenderVideoFirstFrame].
         * Note: This function is only available in ZegoExpressVideo SDK!
         *
         * @param channel Publishing stream channel.If you only publish one audio and video stream, you can ignore this parameter.
         */
        public delegate void OnPublisherCapturedVideoFirstFrame(ZegoPublishChannel channel);

        /**
         * The callback triggered when the video capture resolution changes.
         *
         * Available since: 1.1.0
         * Description: When the audio and video stream is not published [startPublishingStream] or previewed [startPreview] for the first time, the publishing stream or preview first time, that is, the engine of the audio and video module inside the SDK is started, the video data of the local device will be collected, and the collection resolution will change at this time.
         * Trigger: After the successful publish [startPublishingStream], the callback will be received if there is a change in the video capture resolution in the process of publishing the stream.
         * Use cases: You can use this callback to remove the cover of the local preview UI and similar operations.You can also dynamically adjust the scale of the preview view based on the resolution of the callback.
         * Caution: What is notified during external collection is the change in encoding resolution, which will be affected by flow control.
         * Note: This function is only available in ZegoExpressVideo SDK!
         *
         * @param width Video capture resolution width.
         * @param height Video capture resolution height.
         * @param channel Publishing stream channel.If you only publish one audio and video stream, you can ignore this parameter.
         */
        public delegate void OnPublisherVideoSizeChanged(int width, int height, ZegoPublishChannel channel);

        /**
         * The callback triggered when the state of relayed streaming to CDN changes.
         *
         * Available since: 1.1.0
         * Description: Developers can use this callback to determine whether the audio and video streams of the relay CDN are normal. If they are abnormal, further locate the cause of the abnormal audio and video streams of the relay CDN and make corresponding disaster recovery strategies.
         * Trigger: After the ZEGO RTC server relays the audio and video streams to the CDN, this callback will be received if the CDN relay status changes, such as a stop or a retry.
         * Caution: If you do not understand the cause of the abnormality, you can contact ZEGO technicians to analyze the specific cause of the abnormality.
         *
         * @param streamID Stream ID.
         * @param infoList List of information that the current CDN is relaying.
         */
        public delegate void OnPublisherRelayCDNStateUpdate(string streamID, List<ZegoStreamRelayCDNInfo> infoList);

        /**
         * The callback triggered when the state of stream playing changes.
         *
         * Available since: 1.1.0
         * Description: After calling the [startPlayingStream] successfully, the notification of the playing stream state change can be obtained through the callback function. You can roughly judge the user's downlink network status based on whether the state parameter is in [PLAY_REQUESTING].
         * When to trigger:  After calling the [startPublishingStream], this callback is triggered when a playing stream's state changed.
         * Related callbacks: After calling the [startPublishingStream] successfully, the notification of the publish stream state change can be obtained through the callback function [onPublisherStateUpdate]. You can roughly judge the user's uplink network status based on whether the state parameter is in [PUBLISH_REQUESTING].
         *
         * @param streamID stream ID.
         * @param state State of playing stream.
         * @param errorCode The error code corresponding to the status change of the playing stream, please refer to the error codes document https://docs.zegocloud.com/en/5548.html for details.
         * @param extendedData Extended Information with state updates. As the standby, only an empty json table is currently returned.
         */
        public delegate void OnPlayerStateUpdate(string streamID, ZegoPlayerState state, int errorCode, string extendedData);

        /**
         * Callback for current stream playing quality.
         *
         * Available since: 1.1.0
         * Description: After calling the [startPlayingStream] successfully, this callback will be triggered every 3 seconds. The collection frame rate, bit rate, RTT, packet loss rate and other quality data can be obtained, and the health of the played audio and video streams can be monitored in real time.
         * Use cases: You can monitor the health of the played audio and video streams in real time according to the quality parameters of the callback function, in order to show the downlink network status on the device UI in real time.
         * Caution: If you does not know how to use the various parameters of the callback function, you can only focus on the level field of the quality parameter, which is a comprehensive value describing the downlink network calculated by SDK based on the quality parameters.
         * Related callbacks: After calling the [startPublishingStream] successfully, a callback [onPublisherQualityUpdate] will be received every 3 seconds. You can monitor the health of publish streams in real time based on quality data such as frame rate, code rate, RTT, packet loss rate, etc.
         *
         * @param streamID Stream ID.
         * @param quality Playing stream quality, including audio and video framerate, bitrate, RTT, etc.
         */
        public delegate void OnPlayerQualityUpdate(string streamID, ZegoPlayStreamQuality quality);

        /**
         * The callback triggered when a media event occurs during streaming playing.
         *
         * Available since: 1.1.0
         * Description: This callback is used to receive pull streaming events.
         * Use cases: You can use this callback to make statistics on stutters or to make friendly displays in the UI of the app.
         * When to trigger:  After calling the [startPublishingStream], this callback is triggered when an event such as audio and video jamming and recovery occurs in the playing stream.
         *
         * @param streamID Stream ID.
         * @param mediaEvent Specific events received when playing the stream.
         */
        public delegate void OnPlayerMediaEvent(string streamID, ZegoPlayerMediaEvent mediaEvent);

        /**
         * The callback triggered when the first audio frame is received.
         *
         * Available since: 1.1.0
         * Description: After the [startPlayingStream] function is called successfully, this callback will be called when SDK received the first frame of audio data.
         * Use cases: Developer can use this callback to count time consuming that take the first frame time or update the UI for playing stream.
         * Trigger: This callback is triggered when SDK receives the first frame of audio data from the network.
         * Related callbacks: After a successful call to [startPlayingStream], the callback function [onPlayerRecvVideoFirstFrame] determines whether the SDK has received the video data, and the callback [onPlayerRenderVideoFirstFrame] determines whether the SDK has rendered the first frame of the received video data.
         *
         * @param streamID Stream ID.
         */
        public delegate void OnPlayerRecvAudioFirstFrame(string streamID);

        /**
         * The callback triggered when the first video frame is received.
         *
         * Available since: 1.1.0
         * Description: After the [startPlayingStream] function is called successfully, this callback will be called when SDK received the first frame of video data.
         * Use cases: Developer can use this callback to count time consuming that take the first frame time or update the UI for playing stream.
         * Trigger: This callback is triggered when SDK receives the first frame of video data from the network.
         * Related callbacks: After a successful call to [startPlayingStream], the callback function [onPlayerRecvAudioFirstFrame] determines whether the SDK has received the audio data, and the callback [onPlayerRenderVideoFirstFrame] determines whether the SDK has rendered the first frame of the received video data.
         * Note: This function is only available in ZegoExpressVideo SDK!
         *
         * @param streamID Stream ID.
         */
        public delegate void OnPlayerRecvVideoFirstFrame(string streamID);

        /**
         * The callback triggered when the first video frame is rendered.
         *
         * Available since: 1.1.0
         * Description: After the [startPlayingStream] function is called successfully, this callback will be called when SDK rendered the first frame of video data.
         * Use cases: Developer can use this callback to count time consuming that take the first frame time or update the UI for playing stream.
         * Trigger: This callback is triggered when SDK rendered the first frame of video data from the network.
         * Related callbacks: After a successful call to [startPlayingStream], the callback function [onPlayerRecvAudioFirstFrame] determines whether the SDK has received the audio data, and the callback [onPlayerRecvVideoFirstFrame] determines whether the SDK has received the video data.
         * Note: This function is only available in ZegoExpressVideo SDK!
         *
         * @param streamID Stream ID.
         */
        public delegate void OnPlayerRenderVideoFirstFrame(string streamID);

        /**
         * The callback triggered when the stream playback resolution changes.
         *
         * Available since: 1.1.0
         * Description: After the [startPlayingStream] function is called successfully, the play resolution will change when the first frame of video data is received, or when the publisher changes the encoding resolution by calling [setVideoConfig], or when the network traffic control strategies work.
         * Use cases: Developers can update or switch the UI components that actually play the stream based on the final resolution of the stream.
         * Trigger: After the [startPlayingStream] function is called successfully, this callback is triggered when the video resolution changes while playing the stream.
         * Caution: If the stream is only audio data, the callback will not be triggered.
         * Note: This function is only available in ZegoExpressVideo SDK!
         *
         * @param streamID Stream ID.
         * @param width Video decoding resolution width.
         * @param height Video decoding resolution height.
         */
        public delegate void OnPlayerVideoSizeChanged(string streamID, int width, int height);

        /**
         * The callback triggered when Supplemental Enhancement Information is received.
         *
         * Available since: 1.1.0
         * Description: After the [startPlayingStream] function is called successfully, when the remote stream sends SEI (such as directly calling [sendSEI], audio mixing with SEI data, and sending custom video capture encoded data with SEI, etc.), the local end will receive this callback.
         * Trigger: After the [startPlayingStream] function is called successfully, when the remote stream sends SEI, the local end will receive this callback.
         * Caution: 1. Since the video encoder itself generates an SEI with a payload type of 5, or when a video file is used for publishing, such SEI may also exist in the video file. Therefore, if the developer needs to filter out this type of SEI, it can be before [createEngine] Call [ZegoEngineConfig.advancedConfig("unregister_sei_filter", "XXXXX")]. Among them, unregister_sei_filter is the key, and XXXXX is the uuid filter string to be set. 2. When [mutePlayStreamVideo] or [muteAllPlayStreamVideo] is called to set only the audio stream to be pulled, the SEI will not be received.
         *
         * @deprecated This function will switch the ui thread callback data, which may cause sei data exceptions. It will be deprecated in version 3.4.0 and above. Please use the [onPlayerSyncRecvSEI] function instead.
         * @param streamID Stream ID.
         * @param data SEI content.
         */
        [Obsolete("This function will switch the ui thread callback data, which may cause sei data exceptions. It will be deprecated in version 3.4.0 and above. Please use the [onPlayerSyncRecvSEI] function instead.",false)]
        public delegate void OnPlayerRecvSEI(string streamID, byte[] data);

        /**
         * The callback triggered when the state of relayed streaming of the mixed stream to CDN changes.
         *
         * Available since: 1.2.1
         * Description: The general situation of the mixing task on the ZEGO RTC server will push the output stream to the CDN using the RTMP protocol, and the state change during the push process will be notified from the callback function.
         * Use cases: It is often used when multiple video images are required to synthesize a video using mixed streaming, such as education, live teacher and student images.
         * When to trigger: After the developer calls the [startMixerTask] function to start mixing, when the ZEGO RTC server pushes the output stream to the CDN, there is a state change.
         * Restrictions: None.
         * Related callbacks: Develop can get the sound update notification of each single stream in the mixed stream through [OnMixerSoundLevelUpdate].
         * Related APIs: Develop can start a mixed flow task through [startMixerTask].
         *
         * @param taskID The mixing task ID. Value range: the length does not exceed 256. Caution: This parameter is in string format and cannot contain URL keywords, such as 'http' and '?' etc., otherwise the push and pull flow will fail. Only supports numbers, English characters and'~','!','@','$','%','^','&','*','(',')','_' ,'+','=','-','`',';',''',',','.','<','>','/','\'.
         * @param infoList List of information that the current CDN is being mixed.
         */
        public delegate void OnMixerRelayCDNStateUpdate(string taskID, List<ZegoStreamRelayCDNInfo> infoList);

        /**
         * The callback triggered when the sound level of any input stream changes in the stream mixing process.
         *
         * Available since: 1.2.1
         * Description: Developers can use this callback to display the effect of which stream’s anchor is talking on the UI interface of the mixed stream of the audience.
         * Use cases: It is often used when multiple video images are required to synthesize a video using mixed streaming, such as education, live teacher and student images.
         * When to trigger: After the developer calls the [startPlayingStream] function to start playing the mixed stream. Callback notification period is 100 ms.
         * Restrictions: The callback is triggered every 100 ms, and the trigger frequency cannot be set.Due to the high frequency of this callback, please do not perform time-consuming tasks or UI operations in this callback to avoid stalling.
         * Related callbacks: [OnMixerRelayCDNStateUpdate] can be used to get update notification of mixing stream repost CDN status.
         * Related APIs: Develop can start a mixed flow task through [startMixerTask].
         *
         * @param soundLevels The sound key-value pair of each single stream in the mixed stream, the key is the soundLevelID of each single stream, and the value is the sound value of the corresponding single stream. Value range: The value range of value is 0.0 ~ 100.0.
         */
        public delegate void OnMixerSoundLevelUpdate(Dictionary<uint, float> soundLevels);

        /**
         * The local captured audio sound level callback.
         *
         * Available since: 1.1.0
         * Description: The local captured audio sound level callback.
         * Trigger: After you start the sound level monitor by calling [startSoundLevelMonitor].
         * Caution:
         *   1. The callback notification period is the parameter value set when the [startSoundLevelMonitor] is called. The callback value is the default value of 0 When you have not called the interface [startPublishingStream] and [startPreview].
         *   2. This callback is a high-frequency callback, and it is recommended not to do complex logic processing inside the callback.
         * Related APIs: Start sound level monitoring via [startSoundLevelMonitor]. Monitoring remote played audio sound level by callback [onRemoteSoundLevelUpdate]
         *
         * @param soundLevel Locally captured sound level value, ranging from 0.0 to 100.0.
         */
        public delegate void OnCapturedSoundLevelUpdate(float soundLevel);

        /**
         * The remote playing streams audio sound level callback.
         *
         * Available since: 1.1.0
         * Description: The remote playing streams audio sound level callback.
         * Trigger: After you start the sound level monitor by calling [startSoundLevelMonitor], you are in the state of playing the stream [startPlayingStream].
         * Caution: The callback notification period is the parameter value set when the [startSoundLevelMonitor] is called.
         * Related APIs: Start sound level monitoring via [startSoundLevelMonitor]. Monitoring local captured audio sound by callback [onCapturedSoundLevelUpdate] or [onCapturedSoundLevelInfoUpdate].
         *
         * @param soundLevels Remote sound level hash map, key is the streamID, value is the sound level value of the corresponding streamID, value ranging from 0.0 to 100.0.
         */
        public delegate void OnRemoteSoundLevelUpdate(Dictionary<string, float> soundLevels);

        /**
         * The local captured audio spectrum callback.
         *
         * Available since: 1.1.0
         * Description: The local captured audio spectrum callback.
         * Trigger: After you start the audio spectrum monitor by calling [startAudioSpectrumMonitor].
         * Caution: The callback notification period is the parameter value set when the [startAudioSpectrumMonitor] is called. The callback value is the default value of 0 When you have not called the interface [startPublishingStream] and [startPreview].
         * Related APIs: Start audio spectrum monitoring via [startAudioSpectrumMonitor]. Monitoring remote played audio spectrum by callback [onRemoteAudioSpectrumUpdate]
         *
         * @param audioSpectrum Locally captured audio spectrum value list. Spectrum value range is [0-2^30].
         */
        public delegate void OnCapturedAudioSpectrumUpdate(float[] audioSpectrum);

        /**
         * The remote playing streams audio spectrum callback.
         *
         * Available since: 1.1.0
         * Description: The remote playing streams audio spectrum callback.
         * Trigger: After you start the audio spectrum monitor by calling [startAudioSpectrumMonitor], you are in the state of playing the stream [startPlayingStream].
         * Caution: The callback notification period is the parameter value set when the [startAudioSpectrumMonitor] is called.
         * Related APIs: Start audio spectrum monitoring via [startAudioSpectrumMonitor]. Monitoring local played audio spectrum by callback [onCapturedAudioSpectrumUpdate].
         *
         * @param audioSpectrums Remote audio spectrum hash map, key is the streamID, value is the audio spectrum list of the corresponding streamID. Spectrum value range is [0-2^30]
         */
        public delegate void OnRemoteAudioSpectrumUpdate(Dictionary<string, float[]> audioSpectrums);

        /**
         * The callback triggered when a local device exception occurred.
         *
         * Available since: 2.15.0
         * Description: The callback triggered when a local device exception occurs.
         * Trigger: This callback is triggered when the function of the local audio or video device is abnormal.
         *
         * @param exceptionType The type of the device exception.
         * @param deviceType The type of device where the exception occurred.
         * @param deviceID Device ID. Currently, only desktop devices are supported to distinguish different devices; for mobile devices, this parameter will return an empty string.
         */
        public delegate void OnLocalDeviceExceptionOccurred(ZegoDeviceExceptionType exceptionType, ZegoDeviceType deviceType, string deviceID);

        /**
         * The callback triggered when the state of the remote camera changes.
         *
         * Available since: 1.1.0
         * Description: The callback triggered when the state of the remote camera changes.
         * Use cases: Developers of 1v1 education scenarios or education small class scenarios and similar scenarios can use this callback notification to determine whether the camera device of the remote publishing stream device is working normally, and preliminary understand the cause of the device problem according to the corresponding state.
         * Trigger: When the state of the remote camera device changes, such as switching the camera, by monitoring this callback, it is possible to obtain an event related to the far-end camera, which can be used to prompt the user that the video may be abnormal.
         * Caution: This callback will not be called back when the remote stream is play from the CDN, or when custom video acquisition is used at the peer.
         * Note: This function is only available in ZegoExpressVideo SDK!
         *
         * @param streamID Stream ID.
         * @param state Remote camera status.
         */
        public delegate void OnRemoteCameraStateUpdate(string streamID, ZegoRemoteDeviceState state);

        /**
         * The callback triggered when the state of the remote microphone changes.
         *
         * Available since: 1.1.0
         * Description: The callback triggered when the state of the remote microphone changes.
         * Use cases: Developers of 1v1 education scenarios or education small class scenarios and similar scenarios can use this callback notification to determine whether the microphone device of the remote publishing stream device is working normally, and preliminary understand the cause of the device problem according to the corresponding state.
         * Trigger: When the state of the remote microphone device is changed, such as switching a microphone, etc., by listening to the callback, it is possible to obtain an event related to the remote microphone, which can be used to prompt the user that the audio may be abnormal.
         * Caution: This callback will not be called back when the remote stream is play from the CDN, or when custom audio acquisition is used at the peer (But the stream is not published to the ZEGO RTC server.).
         *
         * @param streamID Stream ID.
         * @param state Remote microphone status.
         */
        public delegate void OnRemoteMicStateUpdate(string streamID, ZegoRemoteDeviceState state);

        /**
         * The callback triggered when Broadcast Messages are received.
         *
         * Available since: 1.2.1
         * Description: This callback is used to receive broadcast messages sent by other users in the same room.
         * Use cases: Generally used when the number of people in the live room does not exceed 500
         * When to trigger: After calling [loginRoom] to log in to the room, if a user in the room sends a broadcast message via [sendBroadcastMessage] function, this callback will be triggered.
         * Restrictions: None
         * Caution: The broadcast message sent by the user will not be notified through this callback.
         * Related callbacks: You can receive room barrage messages through [onIMRecvBarrageMessage], and you can receive room custom signaling through [onIMRecvCustomCommand].
         *
         * @param roomID Room ID. Value range: The maximum length is 128 bytes.
         * @param messageList List of received messages. Value range: Up to 50 messages can be received each time.
         */
        public delegate void OnIMRecvBroadcastMessage(string roomID, List<ZegoBroadcastMessageInfo> messageList);

        /**
         * The callback triggered when Barrage Messages are received.
         *
         * Available since: 1.5.0
         * Description: This callback is used to receive barrage messages sent by other users in the same room.
         * Use cases: Generally used in scenarios where there is a large number of messages sent and received in the room and the reliability of the messages is not required, such as live barrage.
         * When to trigger: After calling [loginRoom] to log in to the room, if a user in the room sends a barrage message through the [sendBarrageMessage] function, this callback will be triggered.
         * Restrictions: None
         * Caution: Barrage messages sent by users themselves will not be notified through this callback. When there are a large number of barrage messages in the room, the notification may be delayed, and some barrage messages may be lost.
         * Related callbacks: Develop can receive room broadcast messages through [onIMRecvBroadcastMessage], and can receive room custom signaling through [onIMRecvCustomCommand].
         *
         * @param roomID Room ID. Value range: The maximum length is 128 bytes.
         * @param messageList List of received messages. Value range: Up to 50 messages can be received each time.
         */
        public delegate void OnIMRecvBarrageMessage(string roomID, List<ZegoBarrageMessageInfo> messageList);

        /**
         * The callback triggered when a Custom Command is received.
         *
         * Available since: 1.2.1
         * Description: This callback is used to receive custom command sent by other users in the same room.
         * Use cases: Generally used when the number of people in the live room does not exceed 500
         * When to trigger: After calling [loginRoom] to log in to the room, if other users in the room send custom signaling to the developer through the [sendCustomCommand] function, this callback will be triggered.
         * Restrictions: None
         * Caution: The custom command sent by the user himself will not be notified through this callback.
         * Related callbacks: You can receive room broadcast messages through [onIMRecvBroadcastMessage], and you can receive room barrage message through [onIMRecvBarrageMessage].
         *
         * @param roomID Room ID. Value range: The maximum length is 128 bytes.
         * @param fromUser Sender of the command.
         * @param command Command content received.Value range: The maximum length is 1024 bytes.
         */
        public delegate void OnIMRecvCustomCommand(string roomID, ZegoUser fromUser, string command);

        /**
         * The callback triggered when the state of data recording (to a file) changes.
         *
         * Available since: 1.10.0
         * Description: The callback triggered when the state of data recording (to a file) changes.
         * Use cases: The developer should use this callback to determine the status of the file recording or for UI prompting.
         * When to trigger: After [startRecordingCapturedData] is called, if the state of the recording process changes, this callback will be triggered.
         * Restrictions: None.
         *
         * @param state File recording status.
         * @param errorCode Error code, please refer to the error codes document https://docs.zegocloud.com/en/5548.html for details.
         * @param config Record config.
         * @param channel Publishing stream channel.
         */
        public delegate void OnCapturedDataRecordStateUpdate(ZegoDataRecordState state, int errorCode, ZegoDataRecordConfig config, ZegoPublishChannel channel);

        /**
         * The callback to report the current recording progress.
         *
         * Available since: 1.10.0
         * Description: Recording progress update callback, triggered at regular intervals during recording.
         * Use cases: Developers can do UI hints for the user interface.
         * When to trigger: After [startRecordingCapturedData] is called, If configured to require a callback, timed trigger during recording.
         * Restrictions: None.
         *
         * @param progress File recording progress, which allows developers to hint at the UI, etc.
         * @param config Record config.
         * @param channel Publishing stream channel.
         */
        public delegate void OnCapturedDataRecordProgressUpdate(ZegoDataRecordProgress progress, ZegoDataRecordConfig config, ZegoPublishChannel channel);

        /**
         * Customize the notification of the start of video capture.
         *
         * Available since: 1.1.0
         * Description: The SDK informs that the video frame is about to be collected, and the video frame data sent to the SDK is valid after receiving the callback.
         * Use cases: Live data collected by non-cameras. For example, local video file playback, screen sharing, game live broadcast, etc.
         * When to Trigger: After calling [startPreview] or [startPublishingStream] successfully.
         * Caution: The video frame data sent to the SDK after receiving the callback is valid.
         * Related callbacks: Customize the end of capture notification [onCaptureStop].
         * Related APIs: Call [setCustomVideoCaptureHandler] to set custom video capture callback.
         *
         * @param channel Publishing stream channel.
         */
        public delegate void OnCustomVideoCaptureStart(ZegoPublishChannel channel);

        /**
         * Customize the notification of the end of the collection.
         *
         * Available since: 1.1.0
         * Description: The SDK informs that it is about to end the video frame capture.
         * Use cases: Live data collected by non-cameras. For example, local video file playback, screen sharing, game live broadcast, etc.
         * When to Trigger: After calling [stopPreview] or [stopPublishingStream] successfully.
         * Caution: If you call [startPreview] and [startPublishingStream] to start preview and push stream at the same time after you start custom capture, you should call [stopPreview] and [stopPublishingStream] to stop the preview and push stream before triggering the callback.
         * Related callbacks: Custom video capture start notification [onCaptureStart].
         * Related APIs: Call [setCustomVideoCaptureHandler] to set custom video capture callback.
         *
         * @param channel Publishing stream channel.
         */
        public delegate void OnCustomVideoCaptureStop(ZegoPublishChannel channel);

        /**
         * When custom video rendering is enabled, the original video frame data collected by the local preview is called back.
         *
         * Available since: 1.1.0
         * Description: When using custom video rendering, the SDK callbacks the original video frame data collected by the local preview, which is rendered by the developer.
         * Use cases: Use a cross-platform interface framework or game engine; need to obtain the video frame data collected or streamed by the SDK for special processing.
         * When to Trigger: When the local preview is turned on, when the SDK collects the local preview video frame data.
         * Related APIs: Call [setCustomVideoRenderHandler] to set custom video rendering callback.
         *
         * @param data Raw video frame data (eg: RGBA only needs to consider data[0], I420 needs to consider data[0,1,2]).
         * @param dataLength Data length (eg: RGBA only needs to consider dataLength[0], I420 needs to consider dataLength[0,1,2]).
         * @param param Video frame parameters.
         * @param flipMode video flip mode.
         * @param channel Publishing stream channel.
         */
        public delegate void OnCapturedVideoFrameRawData(ref IntPtr data, ref uint dataLength, ZegoVideoFrameParam param, ZegoVideoFlipMode flipMode, ZegoPublishChannel channel);

        /**
         * When custom video rendering is enabled, the remote end pulls the original video frame data to call back, and distinguishes different streams by streamID.
         *
         * Available since: 1.1.0
         * Description: When custom video rendering is enabled, the SDK calls back the remote end to pull the original video frame data, distinguishes different streams by streamID, and renders them by the developer.
         * Use cases: Use a cross-platform interface framework or game engine; need to obtain the video frame data collected or streamed by the SDK for special processing.
         * When to Trigger: After starting to stream, when the SDK receives the video frame data of the remote stream.
         * Related APIs: Call [setCustomVideoRenderHandler] to set custom video rendering callback.
         *
         * @param data Raw video frame data (eg: RGBA only needs to consider data[0], I420 needs to consider data[0,1,2]).
         * @param dataLength Data length (eg: RGBA only needs to consider dataLength[0], I420 needs to consider dataLength[0,1,2]).
         * @param param Video frame parameters.
         * @param streamID Stream ID.
         */
        public delegate void OnRemoteVideoFrameRawData(ref IntPtr data, ref uint dataLength, ZegoVideoFrameParam param, string streamID);

        /**
         * The callback for obtaining the audio data captured by the local microphone.
         *
         * Available: Since 1.1.0
         * Description: In non-custom audio capture mode, the SDK capture the microphone's sound, but the developer may also need to get a copy of the audio data captured by the SDK is available through this callback.
         * When to trigger: On the premise of calling [setAudioDataHandler] to set the listener callback, after calling [startAudioDataObserver] to set the mask 0b01 that means 1 << 0, this callback will be triggered only when it is in the publishing stream state.
         * Restrictions: None.
         * Caution: This callback is a high-frequency callback, please do not perform time-consuming operations in this callback.
         *
         * @param data Audio data in PCM format.
         * @param dataLength Length of the data.
         * @param param Parameters of the audio frame.
         */
        public delegate void OnCapturedAudioData(IntPtr data, uint dataLength, ZegoAudioFrameParam param);

        /**
         * The callback for obtaining the audio data of all the streams playback by SDK.
         *
         * Available: Since 1.1.0
         * Description: This function will callback all the mixed audio data to be playback. This callback can be used for that you needs to fetch all the mixed audio data to be playback to proccess.
         * When to trigger: On the premise of calling [setAudioDataHandler] to set the listener callback, after calling [startAudioDataObserver] to set the mask 0b10 that means 1 << 1, this callback will be triggered only when it is in the SDK inner audio and video engine started(called the [startPreivew] or [startPlayingStream] or [startPublishingStream]).
         * Restrictions: When playing copyrighted music, this callback will be disabled by default. If necessary, please contact ZEGO technical support.
         * Caution: This callback is a high-frequency callback. Please do not perform time-consuming operations in this callback. When the engine is not in the stream publishing state and the media player is not used to play media files, the audio data in the callback is muted audio data.
         *
         * @param data Audio data in PCM format.
         * @param dataLength Length of the data.
         * @param param Parameters of the audio frame.
         */
        public delegate void OnPlaybackAudioData(IntPtr data, uint dataLength, ZegoAudioFrameParam param);

        /**
         * Callback to get the audio data played by the SDK and the audio data captured by the local microphone. The audio data is the data mixed by the SDK.
         *
         * Available: Since 1.1.0
         * Description: The audio data played by the SDK is mixed with the data captured by the local microphone before being sent to the speaker, and is called back through this function.
         * When to trigger: On the premise of calling [setAudioDataHandler] to set the listener callback, after calling [startAudioDataObserver] to set the mask 0x04, this callback will be triggered only when it is in the publishing stream state or playing stream state.
         * Restrictions: When playing copyrighted music, this callback will be disabled by default. If necessary, please contact ZEGO technical support.
         * Caution: This callback is a high-frequency callback, please do not perform time-consuming operations in this callback.
         *
         * @param data Audio data in PCM format.
         * @param dataLength Length of the data.
         * @param param Parameters of the audio frame.
         */
        public delegate void OnMixedAudioData(IntPtr data, uint dataLength, ZegoAudioFrameParam param);

        /**
         * The callback for obtaining the audio data of each stream.
         *
         * Available: Since 1.1.0
         * Description: This function will call back the data corresponding to each playing stream. Different from [onPlaybackAudioData], the latter is the mixed data of all playing streams. If developers need to process a piece of data separately, they can use this callback.
         * When to trigger: On the premise of calling [setAudioDataHandler] to set up listening for this callback, calling [startAudioDataObserver] to set the mask 0x08 that is 1 << 3, and this callback will be triggered when the SDK audio and video engine starts to play the stream.
         * Restrictions: None.
         * Caution: This callback is a high-frequency callback, please do not perform time-consuming operations in this callback.
         *
         * @param data Audio data in PCM format.
         * @param dataLength Length of the data.
         * @param param Parameters of the audio frame.
         * @param streamID Corresponding stream ID.
         */
        public delegate void OnPlayerAudioData(IntPtr data, uint dataLength, ZegoAudioFrameParam param, string streamID);


    }
    /**
     * Callback for asynchronous destruction completion.
     *
     * In general, developers do not need to listen to this callback.
     */
    public delegate void IZegoDestroyCompletionCallback();

    /**
     * Callback for setting room extra information.
     *
     * @param errorCode Error code, please refer to the error codes document https://docs.zegocloud.com/en/5548.html for details.
     */
    public delegate void OnRoomSetRoomExtraInfoResult(int errorCode);

    /**
     * Callback for setting stream extra information.
     *
     * @param errorCode Error code, please refer to the error codes document https://docs.zegocloud.com/en/5548.html for details.
     */
    public delegate void OnPublisherSetStreamExtraInfoResult(int errorCode);

    /**
     * Callback for add/remove CDN URL.
     *
     * @param errorCode Error code, please refer to the error codes document https://docs.zegocloud.com/en/5548.html for details.
     */
    public delegate void OnPublisherUpdateCdnUrlResult(int errorCode);

    /**
     * Results of starting a mixer task.
     *
     * @param errorCode Error code, please refer to the error codes document https://docs.zegocloud.com/en/5548.html for details.
     * @param extendedData Extended Information
     */
    public delegate void OnMixerStartResult(int errorCode, string extendedData);

    /**
     * Results of stoping a mixer task.
     *
     * @param errorCode Error code, please refer to the error codes document https://docs.zegocloud.com/en/5548.html for details.
     */
    public delegate void OnMixerStopResult(int errorCode);

    /**
     * Callback for sending broadcast messages.
     *
     * @param errorCode Error code, please refer to the error codes document https://docs.zegocloud.com/en/5548.html for details.
     * @param messageID ID of this message
     */
    public delegate void OnIMSendBroadcastMessageResult(int errorCode, ulong messageID);

    /**
     * Callback for sending barrage message.
     *
     * @param errorCode Error code, please refer to the error codes document https://docs.zegocloud.com/en/5548.html for details.
     * @param messageID ID of this message
     */
    public delegate void OnIMSendBarrageMessageResult(int errorCode, string messageID);

    /**
     * Callback for sending custom command.
     *
     * @param errorCode Error code, please refer to the error codes document https://docs.zegocloud.com/en/5548.html for details.
     */
    public delegate void OnIMSendCustomCommandResult(int errorCode);


}
