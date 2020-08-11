using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading;
using static ZEGO.IZegoEventHandler;
//current version 0.9.1
namespace ZEGO
{
    public abstract class ZegoExpressEngine { 
        /**
        * Set the advanced engine configuration, which will only take effect before create engine
        *
        * Developers need to call this interface to set advanced function configuration when they need advanced functions of the engine.
        *
        * @param config Advanced engine configuration
        */
        public static void SetEngineConfig(ZegoEngineConfig config)
        {
            ZegoExpressEngineImpl.SetEngineConfig(config);
        }

        /**
         * Create engine singleton instance
         *
         * The engine needs to be created and initialized before calling other APIs. The SDK only supports the creation of one instance of ZegoExpressEngine. Multiple calls to this interface return the same object.
         *
         * @param appID Application ID issued by ZEGO for developers, please apply from the ZEGO Admin Console https://console-express.zego.im/. The value ranges from 0 to 4294967295.
         * @param appSign Application signature for each AppID, please apply from the ZEGO Admin Console. Application signature is a 64 character string. Each character has a range of '0' ~ '9', 'a' ~ 'z'.
         * @param isTestEnv Choose to use a test environment or a formal commercial environment, the formal environment needs to submit work order configuration in the ZEGO management console. The test environment is for test development, with a limit of 30 rooms and 230 users. Official environment App is officially launched. ZEGO will provide corresponding server resources according to the configuration records submitted by the developer in the management console. The test environment and the official environment are two sets of environments and cannot be interconnected.
         * @param scenario The application scenario. Developers can choose one of ZegoScenario based on the scenario of the app they are developing, and the engine will preset a more general setting for specific scenarios based on the set scenario. After setting specific scenarios, developers can still call specific api to set specific parameters if they have customized parameter settings.
         * @param application Android Application Context
         * @param eventHandler Event notification callback. [null] means not receiving any callback notifications.It can also be managed later via [setEventHandler]
         * @return Engine singleton instance
         */
        public static ZegoExpressEngine CreateEngine(uint appId, string appSign, bool isTestEnv, ZegoScenario scenario, SynchronizationContext uiThreadContext)
        {
            return ZegoExpressEngineImpl.CreateEngine(appId, appSign, isTestEnv, scenario,uiThreadContext);
        }

        /**
         * Destroy engine singleton object asynchronously
         *
         * Used to release resources used by ZegoExpressEngine.
         *
         * @param callback Notification callback for destroy engine completion. Developers can listen to this callback to ensure that device hardware resources are released. This callback is only used to notify the completion of the release of internal resources of the engine. Developers cannot release resources related to the engine within this callback. If the developer only uses SDK to implement audio and video functions, this parameter can be passed [null].
         */
        public static void DestroyEngine(IZegoDestroyCompletionCallback onDestroyCompletion = null)
        {
            ZegoExpressEngineImpl.DestroyEngine(onDestroyCompletion);
        }

        /**
        * Get SDK version number
        *
        * When the SDK is running, the developer finds that it does not match the expected situation and submits the problem and related logs to the ZEGO technical staff for locating. The ZEGO technical staff may need the information of the engine version to assist in locating the problem.
        * Developers can also collect this information as the version information of the engine used by the app, so that the SDK corresponding to each version of the app on the line.
        *
        * @return SDK version
        */
        public static string GetVersion()
        {
            return ZegoExpressEngineImpl.GetVersion();
        }

        /**
        * Returns engine singleton instance
        *
        * If the engine has not been created or has been destroyed, returns [null].
        *
        * @return Engine singleton instance
        */
        public static ZegoExpressEngine GetEngine()
        {
            return ZegoExpressEngineImpl.GetEngine();
        }

        /**
        * Login room with token param. You must log in to the room before startPublishingStream and startPlayingStream the stream.
        *
        * To prevent the app from being impersonated by a malicious user, you can add authentication before logging in to the room, that is, the [token] parameter in the ZegoRoomConfig object passed in by the [config] parameter.
        * Different users who log in to the same room can get room related notifications in the same room (eg [onRoomUserUpdate], [onRoomStreamUpdate], etc.), and users in one room cannot receive room signaling notifications in another room.
        * Messages sent in one room (eg apis [setStreamExtraInfo], [sendBroadcastMessage], [sendBarrageMessage], [sendCustomCommand], etc.) cannot be received callback ((eg [onRoomStreamExtraInfoUpdate], [onIMRecvBroadcastMessage], [onIMRecvBarrageMessage], [onIMRecvCustomCommand], etc) in other rooms. Currently, SDK does not provide the ability to send messages across rooms. Developers can integrate the SDK of third-party IM to achieve.
        * SDK supports startPlayingStream audio and video streams from different rooms under the same appID, that is, startPlayingStream audio and video streams across rooms. Since ZegoExpressEngine's room related callback notifications are based on the same room, when developers want to startPlayingStream streams across rooms, developers need to maintain related messages and signaling notifications by themselves.
        * If the network is temporarily interrupted due to network quality reasons, the SDK will automatically reconnect internally. You can get the current connection status of the local room by listening to the [onRoomStateUpdate] callback method, and other users in the same room will receive [onRoomUserUpdate] callback notification.
        * It is strongly recommended that userID corresponds to the user ID of the business APP, that is, a userID and a real user are fixed and unique, and should not be passed to the SDK in a random userID. Because the unique and fixed userID allows ZEGO technicians to quickly locate online problems.
        *
        * @param roomID Room ID, a string of up to 128 bytes in length. Only support numbers, English characters and '~', '!', '@', '#', '$', '%', '^', '&', '*', '(', ')', '_', '+', '=', '-', '`', ';', '’', ',', '.', '<', '>', '/', '\'
        * @param user User object instance, configure userID, userName. Note that the userID needs to be globally unique with the same appID, otherwise the user who logs in later will kick out the user who logged in first.
        * @param config Advanced room configuration
        */
        public abstract void LoginRoom(string roomId, ZegoUser user, ZegoRoomConfig config = null);

        /**
         * Logout room
         *
         * Exiting the room will stop all publishing and playing streams for user, and then SDK will auto stop local preview UI. After calling this interface, you will receive [onRoomStateUpdate] callback notification successfully exits the room, while other users in the same room will receive the [onRoomUserUpdate] callback notification.
         *
         * @param roomID Room ID, a string of up to 128 bytes in length. Only support numbers, English characters and '~', '!', '@', '#', '$', '%', '^', '&', '*', '(', ')', '_', '+', '=', '-', '`', ';', '’', ',', '.', '<', '>', '/', '\'
         */
        public abstract void LogoutRoom(string roomId);

        /**
         * Start publishing stream, you can call this api to publish the another stream.
         *
         * This interface allows users to publish their local audio and video streams to the ZEGO real-time audio and video cloud. Other users in the same room can use the streamID to play the audio and video streams for intercommunication.
         * Before you start to publish the stream, you need to join the room first by calling [loginRoom]. Other users in the same room can get the streamID by monitoring the [onRoomStreamUpdate] event callback after the local user publishing stream successfully.
         * In the case of poor network quality, user publish may be interrupted, and the SDK will attempt to reconnect. You can learn about the current state and error information of the stream published by monitoring the [onPublisherStateUpdate] event.
         *
         * @param streamID Stream ID, a string of up to 256 characters, needs to be globally unique within the entire AppID. If in the same AppID, different users publish each stream and the stream ID is the same, which will cause the user to publish the stream failure. You cannot include URL keywords, otherwise publishing stream and playing stream will fails. Only support numbers, English characters and '~', '!', '@', '#', '$', '%', '^', '&', '*', '(', ')', '_', '+', '=', '-', '`', ';', '’', ',', '.', '<', '>', '/', '\'.
         * @param channel Publish stream channel
         */
        public abstract void StartPublishingStream(string streamID, ZegoPublishChannel channel = ZegoPublishChannel.Main);

        /**
        * Stop publishing stream of the specified channel
        *
        * This interface allows the user to stop sending local audio and video streams and end the call.
        * If the user has initiated publish flow, this interface must be called to stop the publish of the current stream before publishing the new stream (new streamID), otherwise the new stream publish will return a failure.
        * After stopping streaming, the developer should stop the local preview based on whether the business situation requires it.
        * Use this API to stop publishing stream of aux channel.
        *
        * @param channel Publish stream channel
        */
        public abstract void StopPublishingStream(ZegoPublishChannel channel = ZegoPublishChannel.Main);


        /**
         * Start/Update local preview. You can call this api to set params when publishing another streams
         *
         * The user can see his own local image by calling this interface. The preview function does not require you to log in to the room or publish the stream first. But after exiting the room, SDK internally actively stops previewing by default.
         * You can set the mirror mode of the preview by calling the [setVideoMirrorMode] interface. The default preview setting is image mirrored.
         * When this api is called, the audio and video engine module inside SDK will start really, and it will start to try to collect audio and video. 
         *
         * 
         * @param channel Publish stream channel
         */
        public abstract void StartPreview(ZegoCanvas canvas, ZegoPublishChannel channel = ZegoPublishChannel.Main);


        /**
        * Stop local preview
        *
        * This api can be called to stop previewing when there is no need to see the preview locally.
        *
        * @param channel Publish stream channel
        */
        public abstract void StopPreview(ZegoPublishChannel channel = ZegoPublishChannel.Main);

        /**
         * Set the orientation of video
         *
         * This interface sets the orientation of the video. The captued image is rotated 90, 180 or 270 degrees counterclockwise compared to the forward direction of the phone. After rotation, it is automatically adjusted to match the encoded image resolution.
         *
         * @param orientation Video orientation
         */
        public abstract void SetAppOrientation(ZegoOrientation orientation, ZegoPublishChannel channel = ZegoPublishChannel.Main);


        

        /**
         * Stop playing stream
         *
         * This interface allows the user to stop playing the stream. When stopped, the attributes set for this stream previously, such as [setPlayVolume], [mutePlayStreamAudio], [mutePlayStreamVideo], etc., will be invalid and need to be reset when playing the the stream next time.
         *
         * @param streamID Stream ID
         */
        public abstract void StopPlayingStream(string streamId);

        /**
        * Set up video configuration. You can call this api to publish another streams
        *
        * This api can be used to set the video frame rate, bit rate, video capture resolution, and video encoding output resolution. If you do not call this api, the default resolution is 360p, the bit rate is 600 kbps, and the frame rate is 15 fps.
        * It is necessary to set the relevant video configuration before publishing the stream, and only support the modification of the encoding resolution and the bit rate after publishing the stream.
        * Developers should note that the wide and high resolution of the mobile end is opposite to the wide and high resolution of the PC. For example, in the case of 360p, the resolution of the mobile end is 360x640, and the resolution of the PC end is 640x360.
        *
        * @param config Video configuration, the SDK provides a common setting combination of resolution, frame rate and bit rate, they also can be customized.
        * @param channel Publish stream channel
        */
        public abstract void SetVideoConfig(ZegoVideoConfig config, ZegoPublishChannel channel = ZegoPublishChannel.Main);

        /**
         * Set mirror mode. You can call this api to set params when publishing another streams
         *
         * This interface can be called to set whether the local preview video and the published video have mirror mode enabled.
         *
         * @param mirrorMode Mirror mode for previewing or publishing the stream
         * @param channel Publish stream channel
         */
        public abstract void SetVideoMirrorMode(ZegoVideoMirrorMode mirrorMode, ZegoPublishChannel channel = ZegoPublishChannel.Main);

        /**
         * Set up audio configuration
         *
         * You can set the combined value of the audio codec, bit rate, and audio channel through this interface. If this interface is not called, the default is standard quality mode. Should be used before publishing.
         * If the preset value cannot meet the developer's scenario, the developer can set the parameters according to the business requirements.
         *
         * @param config Audio config
         */
        public abstract void SetAudioConfig(ZegoAudioConfig config);

        /**
         * Stop or resume sending a audio stream. You can call this api to set params when publishing another streams
         *
         * This interface can be called when publishing the stream to publish only the video stream without publishing the audio. The SDK still collects and processes the audio, but does not send the audio data to the network. It can be set before publishing.
         * If you stop sending audio streams, the remote user that play stream of local user publishing stream can receive `Mute` status change notification by monitoring [onRemoteMicStateUpdate] callbacks,
         *
         * @param mute Whether to stop sending audio streams, true means that only the video stream is sent without sending the audio stream, and false means that the audio and video streams are sent simultaneously. The default is false.
         * @param channel Publish stream channel
         */
        public abstract void MutePublishStreamAudio(bool mute, ZegoPublishChannel channel = ZegoPublishChannel.Main);

        /**
         * Stop or resume sending a video stream. You can call this api to set params when publishing another streams
         *
         * When publishing the stream, this interface can be called to publish only the audio stream without publishing the video stream. The local camera can still work normally, and can normally capture, preview and process the video picture, but does not send the video data to the network. It can be set before publishing.
         * If you stop sending video streams locally, the remote user that play stream of local user publishing stream can receive `Mute` status change notification by monitoring [onRemoteCameraStateUpdate] callbacks,
         *
         * @param mute Whether to stop sending video streams, true means that only the audio stream is sent without sending the video stream, and false means that the audio and video streams are sent at the same time. The default is false.
         * @param channel Publish stream channel
         */
        public abstract void MutePublishStreamVideo(bool mute, ZegoPublishChannel channel = ZegoPublishChannel.Main);
        /**
         * Enable or disable traffic control
         *
         * Traffic control enables SDK to dynamically adjust the bitrate of audio and video streaming according to its own and peer current network environment status.
         * Automatically adapt to the current network environment and fluctuations, so as to ensure the smooth publishing of stream.
         *
         * @param enable Whether to enable traffic control. The default is ture.
         * @param property Adjustable property of traffic control, bitmask format. Should be one or the combinations of [ZegoTrafficControlProperty] enumeration. [AdaptiveFPS] as default.
         */
        public abstract void EnableTrafficControl(bool enable, int property);

        /**
         * Set the minimum video bitrate for traffic control
         *
         * Set how should SDK send video data when the network conditions are poor and the minimum video bitrate cannot be met.
         * When this api is not called, the SDK will automatically adjust the sent video data frames according to the current network uplink conditions by default.
         *
         * @param bitrate Minimum video bitrate (kbps)
         * @param mode Video sending mode below the minimum bitrate.
         */
        public abstract void SetMinVideoBitrateForTrafficControl(int bitrate, ZegoTrafficControlMinVideoBitrateMode mode);


        /**
        * Set the captured volume for publishing stream
        *
        * This interface is used to set the audio collection volume. The local user can control the volume of the audio stream sent to the far end. It can be set before publishing.
        *
        * @param volume Volume percentage. The range is 0 to 100. Default value is 100.
        */
        public abstract void SetCaptureVolume(int volume);


        /**
        * On/off hardware encoding
        *
        * Whether to use the hardware encoding function when publishing the stream, the GPU is used to encode the stream and to reduce the CPU usage. The setting can take effect before the stream published. If it is set after the stream published, the stream should be stopped first before it takes effect.
        * Because hard-coded support is not particularly good for a few models, SDK uses software encoding by default. If the developer finds that the device is hot when publishing a high-resolution audio and video stream during testing of some models, you can consider calling this interface to enable hard coding.
        *
        * @param enable Whether to enable hardware encoding, true: enable hardware encoding, false: disable hardware encoding
        */
        public abstract void EnableHardwareEncoder(bool enable);


        /**
         * Set debug details switch and language
         *
         * The debug switch is set to on and the language is English by default.
         *
         * @param enable Detailed debugging information switch
         * @param language Debugging information language
         */
        public abstract void SetDebugVerbose(bool enable, ZegoLanguage language);

        /**
         * Upload logs to ZEGO server
         *
         * By default, SDK creates and prints log files in the app's default directory. Each log file defaults to a maximum of 5MB. Three log files are written over and over in a circular fashion. When calling this interface, SDK will auto package and upload the log files to the ZEGO server.
         * Developers can provide a business “feedback” channel in the app. When users feedback problems, they can call this interface to upload the local log information of SDK to help locate user problems.
         */
        public abstract void UploadLog();

        /**
         * set capture pipeline scale mode. Whether the video data is scaled immediately when it is acquired or scaled when it is encoded.
         *
         * This interface needs to be set before previewing or streaming.
         * The main effect is whether the local preview is affected when the acquisition resolution is different from the encoding resolution.
         *
         * @param mode capture scale mode
         */
        public abstract void SetCapturePipelineScaleMode(ZegoCapturePipelineScaleMode mode);

        /**
         * Set the playback volume of the stream
         *
         * This interface is used to set the playback volume of the stream. Need to be called after calling startPlayingStream.
         * You need to reset after [stopPlayingStream] and [startPlayingStream].
         *
         * @param streamID Stream ID
         * @param volume Volume percentage. The value ranges from 0 to 100, and the default value is 100.
         */
        public abstract void SetPlayVolume(string streamId, int volume);

        /**
         * Stop/resume playing the audio data of the stream
         *
         * This api can be used to stop playing/retrieving the audio data of the stream. Need to be called after calling startPlayingStream.
         * This api is only effective for playing stream from ZEGO real-time audio and video cloud (not ZEGO CDN or third-party CDN).
         *
         * @param streamID Stream ID
         * @param mute mute flag, true: mute play stream video, false: resume play stream video
         */
        public abstract void MutePlayStreamAudio(string streamId, bool mute);

        /**
         * Stop/resume playing the video data of the stream
         *
         * This interface can be used to stop playing/retrieving the video data of the stream. Need to be called after calling startPlayingStream.
         * This api is only effective for playing stream from ZEGO real-time audio and video cloud (not ZEGO CDN or third-party CDN).
         *
         * @param streamID Stream ID
         * @param mute mute flag, true: mute play stream video, false: resume play stream video
         */
        public abstract void MutePlayStreamVideo(string streamId, bool mute);

        /**
         * On/off hardware decoding
         *
         * Turn on hardware decoding and use hardware to improve decoding efficiency. Need to be called before calling startPlayingStream.
         * Because hard-decoded support is not particularly good for a few models, SDK uses software decoding by default. If the developer finds that the device is hot when playing a high-resolution audio and video stream during testing of some models, you can consider calling this interface to enable hard decoding.
         *
         * @param enable Whether to turn on hardware decoding switch, true: enable hardware decoding, false: disable hardware decoding. The default is false
         */
        public abstract void EnableHardwareDecoder(bool enable);


        /**
        * On/off frame order detection
        *
        * @param enable Whether to turn on frame order detection, true: enable check poc,not support B frames, false: disable check poc, support B frames but the screen may temporary splash. The default is true
        */
        public abstract void EnableCheckPoc(bool enable);


        /**
         * Switch front and rear camera
         *
         * This interface is used to control the front or rear camera
         *
         * @param enable Whether to use the front camera, true: use the front camera, false: use the the rear camera. The default value is true
         */
        public abstract void UseFrontCamera(bool enable, ZegoPublishChannel channel = ZegoPublishChannel.Main);


        /**
         * Send room broadcast message
         *
         * The total sending frequency limit of [sendBroadcastMessage] and [sendCustomCommand] is 600 times per minute by default.
         * Users of up to the first 500 advanced rooms in the same room can receive it, which is generally used when the number of live broadcast rooms is less than 500.
         *
         * @param roomID Room ID, a string of up to 128 bytes in length. Only support numbers, English characters and '~', '!', '@', '#', '$', '%', '^', '&', '*', '(', ')', '_', '+', '=', '-', '`', ';', '’', ',', '.', '<', '>', '/', '\'
         * @param message Message content, no longer than 256 bytes
         * @param callback Send broadcast message result callback
         */
        public abstract void SendBroadcastMessage(string roomId, string message, OnIMSendBroadcastMessageResult onIMSendBroadcastMessageResult);

        /**
         * Send room barrage message
         *
         * There is no limit on the number of transmissions, but the server will actively drop messages if it is sent too frequently.
         * It can be received by users with more than 500 people in the same room, but it is not reliable, that is, when there are many users in the room or messages are sent frequently between users, the users who receive the messages may not be able to receive them. Generally used for sending live barrage.
         *
         * @param roomID Room ID, a string of up to 128 bytes in length. Only support numbers, English characters and '~', '!', '@', '#', '$', '%', '^', '&', '*', '(', ')', '_', '+', '=', '-', '`', ';', '’', ',', '.', '<', '>', '/', '\'
         * @param message Message content, no longer than 256 bytes
         * @param callback Send barrage message result callback
         */
        public abstract void SendBarrageMessage(string roomId, string message, OnIMSendBarrageMessageResult onIMSendBarrageMessageResult);

        /**
         * Send custom command
         *
         * The total sending frequency limit of [sendBroadcastMessage] and [sendCustomCommand] is 600 times per minute by default.
         * The type of point-to-point signaling in the same room is generally used for remote control signaling or message sending between users.
         *
         * @param roomID Room ID, a string of up to 128 bytes in length. Only support numbers, English characters and '~', '!', '@', '#', '$', '%', '^', '&', '*', '(', ')', '_', '+', '=', '-', '`', ';', '’', ',', '.', '<', '>', '/', '\'
         * @param command Custom command content, no longer than 256 bytes
         * @param toUserList The users who will receive the command
         * @param callback Send command result callback
         */
        public abstract void SendCustomCommand(string roomId, string command, List<ZegoUser> toUserList, OnIMSendCustomCommandResult onIMSendCustomCommandResult);


        /**
        * Start playing stream
        *
        * This interface allows users to play audio and video streams both from the ZEGO real-time audio and video cloud and from third-party cdn.
        * Before starting to play the stream, you need to join the room first, you can get the new streamID in the room by listening to the [onRoomStreamUpdate] event callback.
        * In the case of poor network quality, user play may be interrupted, the SDK will try to reconnect, and the current play status and error information can be obtained by listening to the [onPlayerStateUpdate] event.
        * Playing the stream ID that does not exist, the SDK continues to try to play after executing this interface. After the stream ID is successfully published, the audio and video stream can be actually played.
        * The developer can update the player canvas by calling this interface again (the streamID must be the same).
        *
        * @param streamID Stream ID, a string of up to 256 characters. You cannot include URL keywords, otherwise publishing stream and playing stream will fails. Only support numbers, English characters and '~', '!', '@', '#', '$', '%', '^', '&', '*', '(', ')', '_', '+', '=', '-', '`', ';', '’', ',', '.', '<', '>', '/', '\'.
        * @param config Advanced player configuration
        */
        public abstract void StartPlayingStream(string streamId,ZegoCanvas canvas,ZegoPlayerConfig config=null);


        /**
         * Whether to publish stream directly to CDN without passing through Zego real-time video cloud server
         *
         * This api needs to be set before start publishing stream.
         * After calling this api to publish the audio and video stream directly to the CDN, calling [addPublishCdnUrl] and [removePublishCdnUrl] to dynamically repost to the CDN no longer takes effect, because these two API relay or stop the audio and video stream from the ZEGO real-time audio and video cloud If it is published to CDN, if the direct audio and video stream is directly published to the CDN, the audio and video stream cannot be dynamically relay to the CDN through the ZEGO real-time audio and video cloud.
         *
         * @param enable Whether to enable direct publish CDN, true: enable direct publish CDN, false: disable direct publish CDN
         * @param config CDN configuration, if null, use Zego's background default configuration
         */
        public abstract void EnablePublishDirectToCDN(bool enable, ZegoCDNConfig config, ZegoPublishChannel channel = ZegoPublishChannel.Main);




        /**
         * Add URL to relay to CDN
         *
         * You can call this api to publish the audio and video streams that have been published to the ZEGO real-time audio and video cloud to a custom CDN content distribution network that has high latency but supports high concurrent playing stream.
         * Because this called api is essentially a dynamic relay of the audio and video streams published to the ZEGO audio and video cloud to different CDNs, this api needs to be called after the audio and video stream is published to ZEGO real-time cloud successfully.
         * Since ZEGO's audio and video cloud service itself can be configured to support CDN(content distribution networks), this api is mainly used by developers who have CDN content distribution services themselves.
         * You can use ZEGO's CDN audio and video streaming content distribution service at the same time by calling this interface and then use the developer who owns the CDN content distribution service.
         * This interface supports dynamic relay to the CDN content distribution network, so developers can use this api as a disaster recovery solution for CDN content distribution services.
         * When the [enablePublishDirectToCDN] api is set to true to publish the stream straight to the CDN, then calling this interface will have no effect.
         *
         * @param streamID Stream ID
         * @param targetURL CDN relay address, supported address format rtmp.
         * @param callback The execution result notification of the relay CDN operation, and proceed to the next step according to the execution result.
         */
        public abstract void AddPublishCdnUrl(string streamID, string targetURL, OnPublisherUpdateCdnUrlResult onPublisherUpdateCdnUrlResult);



        /**
         * Delete the URL relayed to the CDN
         *
         * This api is called when a CDN relayed address has been added and needs to stop propagating the stream to the CDN.
         * This api does not stop publishing audio and video stream to the ZEGO audio and video cloud.
         *
         * @param streamID Stream ID
         * @param targetURL CDN relay address, supported address format rtmp, flv, hls
         * @param callback Remove CDN relay result notifications
         */
        public abstract void RemovePublishCdnUrl(string streamID, string targetURL, OnPublisherUpdateCdnUrlResult onPublisherUpdateCdnUrlResult);


        /**
         * Start the sound level monitor
         *
         * After starting monitoring, you can receive local audio sound level via [onCapturedSoundLevelUpdate] callback, and receive remote audio sound level via [onRemoteSoundLevelUpdate] callback.
         * Before entering the room, you can call [startPreview] with this api and combine it with [onCapturedSoundLevelUpdate] callback to determine whether the audio device is working properly.
         * [onCapturedSoundLevelUpdate] and [onRemoteSoundLevelUpdate] callback notification period is 100 ms.
         */
        public abstract void StartSoundLevelMonitor();


        /**
        * Stop the sound level monitor
        *
        * After the monitoring is stopped, the callback of the local/remote audio sound level will be stopped.
        */
        public abstract void StopSoundLevelMonitor();


        /**
         * Start the audio spectrum monitor
         *
         * After starting monitoring, you can receive local audio spectrum via [onCapturedAudioSpectrumUpdate] callback, and receive remote audio spectrum via [onRemoteAudioSpectrumUpdate] callback.
         * [onCapturedAudioSpectrumUpdate] and [onRemoteAudioSpectrumUpdate] callback notification period is 100 ms.
         */
        public abstract void StartAudioSpectrumMonitor();



        /**
         * Stop the audio spectrum monitor
         *
         * After the monitoring is stopped, the callback of the local/remote audio spectrum will be stopped.
         */
        public abstract void StopAudioSpectrumMonitor();




        /**
         * Send SEI
         *
         * This interface can synchronize some other additional information while the developer publishes streaming audio and video streaming data while sending streaming media enhancement supplementary information.
         * Generally, for scenarios such as synchronizing music lyrics or precise layout of video canvas, you can choose to use this api.
         * After the anchor sends the SEI, the audience can obtain the SEI content by monitoring the callback of [onPlayerRecvSEI].
         * Since SEI information follows video frames or audio frames, and because of network problems, frames may be dropped, so SEI information may also be dropped. To solve this situation, it should be sent several times within the limited frequency.
         * Limit frequency: Do not exceed 30 times per second.
         * Note: This api is effective only when there is video data published. SEI information will not be sent without publishing video data.
         * The SEI data length is limited to 4096 bytes.
         *
         * @param data SEI data
         */
        public abstract void SendSEI(byte[] data, ZegoPublishChannel channel = ZegoPublishChannel.Main);



        /**
         * On/off beauty
         *
         * Identify the portraits in the video for beauty. It can be set before and after the start of the publish.
         *
         * @param featureBitmask Beauty features, bitmask format, you can choose to enable several features in [ZegoBeautifyFeature] at the same time
         */
        public abstract void EnableBeautify(int featureBitmask, ZegoPublishChannel channel = ZegoPublishChannel.Main);



        /**
         * Set beauty parameters
         *
         * @param option Beauty configuration options
         */
        public abstract void SetBeautifyOption(ZegoBeautifyOption option, ZegoPublishChannel channel = ZegoPublishChannel.Main);

        /**
         * Set stream extra information
         *
         * User this interface to set the extra info of the stream, the result will be notified via the [IZegoPublisherSetStreamExtraInfoCallback].
         * The stream extra information is an extra information identifier of the stream ID. Unlike the stream ID, which cannot be modified during the publishing process, the stream extra information can be modified midway through the stream corresponding to the stream ID.
         * Developers can synchronize variable content related to stream IDs based on stream additional information.
         *
         * @param extraInfo Stream extra information, a string of up to 1024 characters.
         * @param callback Set stream extra information execution result notification
         */
        public abstract void SetStreamExtraInfo(string extraInfo, OnPublisherSetStreamExtraInfoResult onPublisherSetStreamExtraInfoResult, ZegoPublishChannel channel = ZegoPublishChannel.Main);



        //public abstract void SetPublishWatermark(ZegoWatermark watermark, bool isPreviewVisible, zego_publish_channel channel=zego_publish_channel.zego_publish_channel_main);


        /**
         * Whether to mute (disable) microphone
         *
         * This api is used to control whether the collected audio data is used. When the microphone is muted (disabled), the data is collected and discarded, and the microphone is still occupied.
         * The microphone is still occupied because closing or opening the microphone on the hardware is a relatively heavy operation, and real users may have frequent operations. For trade-off reasons, this api simply discards the collected data.
         * If you really want SDK to give up occupy the microphone, you can call the [enableAudioCaptureDevice] interface.
         * Developers who want to control whether to use microphone on the UI should use this interface to avoid unnecessary performance overhead by using the [enableAudioCaptureDevice].
         *
         * @param mute Whether to mute (disable) the microphone, true: mute (disable) microphone, false: enable microphone. The default is false.
         */
        public abstract void MuteMicrophone(bool mute);



        /**
         * Whether to mute (disable) speaker audio output
         *
         * After mute speaker, all the SDK sounds will not play, including playing stream, mediaplayer, etc. But the SDK will still occupy the output device.
         *
         * @param mute Whether to mute (disable) speaker audio output, true: mute (disable) speaker audio output, false: enable speaker audio output. The default value is false
         */
        public abstract void MuteSpeaker(bool mute);



        /**
         * On/off camera
         *
         * This interface is used to control whether to start the camera acquisition. After the camera is turned off, video capture will not be performed. At this time, the publish stream will also have no video data.
         *
         * @param enable Whether to turn on the camera, true: turn on camera, false: turn off camera
         */
        public abstract void EnableCamera(bool enable, ZegoPublishChannel channel = ZegoPublishChannel.Main);

        public abstract void EnableCustomVideoRender(bool enable, ZegoCustomVideoRenderConfig config);
        public abstract void StartMixerTask(ZegoMixerTask task, OnMixerStartResult onMixerStartResult);
        public abstract void StopMixerTask(ZegoMixerTask task, OnMixerStopResult onMixerStopResult);
        public abstract ZegoMediaPlayer CreateMediaPlayer();
        public abstract void DestroyMediaPlayer(ZegoMediaPlayer mediaPlayer);
        public abstract void EnableCustomVideoCapture(bool enable, ZegoCustomVideoCaptureConfig config, ZegoPublishChannel channel = ZegoPublishChannel.Main);
        public abstract void SendCustomVideoCaptureRawData(byte[] data, uint dataLength, ZegoVideoFrameParam param, ulong referenceTimeMillisecond, ZegoPublishChannel channel = ZegoPublishChannel.Main);

        public abstract ZegoDeviceInfo[] GetAudioDeviceList(ZegoAudioDeviceType deviceType);
        public abstract ZegoDeviceInfo[] GetVideoDeviceList();
        public abstract void UseAudioDevice(ZegoAudioDeviceType deviceType, string deviceID);
        public abstract void UseVideoDevice(string deviceID, ZegoPublishChannel channel = ZegoPublishChannel.Main);
        public abstract void EnableAudioDataCallback(bool enable, int callbackBitMask, ZegoAudioFrameParam param);
        public abstract void EnableCustomAudioIO(bool enable, ZegoCustomAudioConfig config, ZegoPublishChannel channel=ZegoPublishChannel.Main);
        public abstract void SendCustomAudioCaptureAACData(byte[] data, uint dataLength, uint configLength, ulong referenceTimeMillisecond, ZegoAudioFrameParam param, ZegoPublishChannel channel = ZegoPublishChannel.Main);
        public abstract void SendCustomAudioCapturePCMData(byte[] data, uint dataLength, ZegoAudioFrameParam param, ZegoPublishChannel channel=ZegoPublishChannel.Main);
        public abstract void FetchCustomAudioRenderPCMData(ref byte[] data, uint dataLength, ZegoAudioFrameParam param);
        public OnCustomVideoCaptureStart onCustomVideoCaptureStart;
        public OnCustomVideoCaptureStop onCustomVideoCaptureStop;
        public OnRoomStateUpdate onRoomStateUpdate;
        public OnPublisherStateUpdate onPublisherStateUpdate;
        public OnPlayerStateUpdate onPlayerStateUpdate;
        public OnPublisherQualityUpdate onPublisherQualityUpdate;
        public OnPublisherCapturedAudioFirstFrame onPublisherCapturedAudioFirstFrame;
        public OnPublisherCapturedVideoFirstFrame onPublisherCapturedVideoFirstFrame;
        public OnPublisherVideoSizeChanged onPublisherVideoSizeChanged;
        public OnRoomUserUpdate onRoomUserUpdate;
        public OnRoomStreamUpdate onRoomStreamUpdate;
        public OnPlayerQualityUpdate onPlayerQualityUpdate;
        public OnPlayerMediaEvent onPlayerMediaEvent;
        public OnPlayerRecvAudioFirstFrame onPlayerRecvAudioFirstFrame;
        public OnPlayerRecvVideoFirstFrame onPlayerRecvVideoFirstFrame;
        public OnPlayerRenderVideoFirstFrame onPlayerRenderVideoFirstFrame;
        public OnPlayerVideoSizeChanged onPlayerVideoSizeChanged;
        public OnIMRecvBroadcastMessage onIMRecvBroadcastMessage;
        public OnIMRecvCustomCommand onIMRecvCustomCommand;
        public OnIMRecvBarrageMessage onIMRecvBarrageMessage;
        public OnPublisherRelayCDNStateUpdate onPublisherRelayCDNStateUpdate;
        public OnCapturedSoundLevelUpdate onCapturedSoundLevelUpdate;
        public OnRemoteSoundLevelUpdate onRemoteSoundLevelUpdate;
        public OnCapturedAudioSpectrumUpdate onCapturedAudioSpectrumUpdate;
        public OnRemoteAudioSpectrumUpdate onRemoteAudioSpectrumUpdate;
        public OnPlayerRecvSEI onPlayerRecvSEI;
        public OnDebugError onDebugError;
        public OnRoomStreamExtraInfoUpdate onRoomStreamExtraInfoUpdate;
        public OnCapturedVideoFrameRawData onCapturedVideoFrameRawData;
        public OnRemoteVideoFrameRawData onRemoteVideoFrameRawData;
        public OnCapturedAudioData onCapturedAudioData;
        public OnRemoteAudioData onRemoteAudioData;
        public OnMixedAudioData onMixedAudioData;
    }
}
