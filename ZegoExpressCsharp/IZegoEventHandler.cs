using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
namespace ZEGO
{
    public class IZegoEventHandler
    {
        /**
         * Callback for asynchronous destruction completion
         *
         * In general, developers do not need to listen to this callback.
         */
        public delegate void IZegoDestroyCompletionCallback();

        /**
         * Room status change callback
         *
         * This callback is triggered when the connection status of the room changes, and the reason for the change is notified. Developers can use this callback to determine the status of the current user in the room. If the connection is being requested for a long time, the general probability is that the user's network is unstable.
         *
         * @param roomID Room ID, a string of up to 128 bytes in length.
         * @param state Changed room state
         * @param errorCode Error code, please refer to the [common error code document](https://doc-en.zego.im/en/308.html) for details
         * @param extendedData Extended Information with state updates. As the standby, only an empty json table is currently returned
         */
        public delegate void OnRoomStateUpdate(string roomId, ZegoRoomState state, int errorCode, string extendedData);




        /**
        * The callback triggered when the number of streams published by the other users in the same room increases or decreases.
        *
        * When a user logs in to a room for the first time, there are other users in the room who are publishing streams, and will receive a stream list of the added type.
        * When the user is already in the room, other users in this room will trigger this callback to notify the changed stream list when adding or deleting streams.
        * Developers can use this callback to determine if there are other users in the same room who have added or stopped streaming, in order to implement active play stream [startPlayingStream] or active stop playing stream [stopPlayingStream], and use simultaneous Changes to Streaming render UI widget;
        *
        * @param roomID Room ID where the user is logged in, a string of up to 128 bytes in length.
        * @param updateType Update type (add/delete)
        * @param streamList Updated stream list
        * @param extendedData Extended information with stream updates.
        */
        public delegate void OnRoomStreamUpdate(string roomID, ZegoUpdateType updateType, List<ZegoStream> streamList, string extendedData);


        /**
         * Publish stream state callback
         *
         * After publishing the stream successfully, the notification of the publish stream state change can be obtained through the callback interface.
         * You can roughly judge the user's uplink network status based on whether the state parameter is in [PUBLISH_REQUESTING].
         * ExtendedData is extended information with state updates. If you use ZEGO's CDN content distribution network, after the stream is successfully published, the keys of the content of this parameter are flv_url_list, rtmp_url_list, hls_url_list. These correspond to the publishing stream URLs of the flv, rtmp, and hls protocols.
         *
         * @param streamID Stream ID
         * @param state Status of publishing stream
         * @param errorCode The error code corresponding to the status change of the publish stream. Please refer to the common error code documentation [https://doc-en.zego.im/en/308.html] for details.
         * @param extendedData Extended information with state updates.
         */
        public delegate void OnPublisherStateUpdate(string streamId, ZegoPublisherState state, int errorCode, string extendedData);


        /**
         * Play stream state callback
         *
         * After publishing the stream successfully, the notification of the publish stream state change can be obtained through the callback interface.
         * You can roughly judge the user's downlink network status based on whether the state parameter is in [PLAY_REQUESTING].
         *
         * @param streamID stream ID
         * @param state Current play state
         * @param errorCode The error code corresponding to the status change of the playing stream. Please refer to the common error code documentation [https://doc-en.zego.im/en/308.html] for details.
         * @param extendedData Extended Information with state updates. As the standby, only an empty json table is currently returned
         */
        public delegate void OnPlayerStateUpdate(string streamId, ZegoPlayerState state, int errorCode, string extendedData);

        /**
         * Notification callback for other users in the room to increase or decrease
         *
         * Note that the callback is only triggered when the isUserStatusNotify parameter in the ZegoRoomConfig passed loginRoom function is true. Developers can use this callback to determine the situation of users in the room.
         * When a user logs in to a room for the first time, other users already exist in this room, and a user list of the type of addition is received.
         * When the user is already in the room, other users in this room will trigger this callback to notify the changed users when they enter or exit the room.
         *
         * @param roomID Room ID where the user is logged in, a string of up to 128 bytes in length.
         * @param updateType Update type (add/delete)
         * @param userList List of users changed in the current room
         */
        public delegate void OnRoomUserUpdate(string roomId, ZegoUpdateType updateType, List<ZegoUser> userList, uint userCount);




        /**
         * Publish stream quality callback
         *
         * After the successful publish, the callback will be received every 3 seconds. Through the callback, the collection frame rate, bit rate, RTT, packet loss rate and other quality data of the published audio and video stream can be obtained, and the health of the publish stream can be monitored in real time.
         * You can monitor the health of the published audio and video streams in real time according to the quality parameters of the callback api, in order to show the uplink network status in real time on the device UI interface.
         * If you does not know how to use the parameters of this callback api, you can only pay attention to the level field of the quality parameter, which is a comprehensive value describing the uplink network calculated by SDK based on the quality parameters.
         *
         * @param streamID Stream ID
         * @param quality Published stream quality, including audio and video frame rate, bit rate, resolution, RTT, etc.
         */
        public delegate void OnPublisherQualityUpdate(string streamId, ZegoPublishStreamQuality quality);



        /**
         * First frame callback notification for local audio captured
         *
         * After the startPublishingStream interface is called successfully, the SDK will receive this callback notification when it collects the first frame of audio data.
         * In the case of no startPublishingStream audio and video stream or preview, the first startPublishingStream audio and video stream or first preview, that is, when the engine of the audio and video module inside SDK starts, it will collect audio data of the local device and receive this callback.
         * Developers can use this callback to determine whether SDK has actually collected audio data. If the callback is not received, the audio capture device is occupied or abnormal.
         */
        public delegate void OnPublisherCapturedAudioFirstFrame();


        /**
         * First frame callback notification for local video captured.
         *
         * After the startPublishingStream interface is called successfully, the SDK will receive this callback notification when it collects the first frame of video data.
         * In the case of no startPublishingStream video stream or preview, the first startPublishingStream video stream or first preview, that is, when the engine of the audio and video module inside SDK starts, it will collect video data of the local device and receive this callback.
         * Developers can use this callback to determine whether SDK has actually collected video data. If the callback is not received, the video capture device is occupied or abnormal.
         *
         * @param channel Publishing stream channel.If you only publish one audio and video stream, you can ignore this parameter.
         */
        public delegate void OnPublisherCapturedVideoFirstFrame(ZegoPublishChannel channel);



        /**
         * Video captured size change callback notification
         *
         * After the successful publish, the callback will be received if there is a change in the video capture resolution in the process of publishing the stream.
         * When the audio and video stream is not published or previewed for the first time, the publishing stream or preview first time, that is, the engine of the audio and video module inside the SDK is started, the video data of the local device will be collected, and the collection resolution will change at this time.
         * You can use this callback to remove the cover of the local preview UI and similar operations.You can also dynamically adjust the scale of the preview view based on the resolution of the callback.
         *
         * @param width Video capture resolution width
         * @param height Video capture resolution width
         * @param channel Publishing stream channel.If you only publish one audio and video stream, you can ignore this parameter.
         */
        public delegate void OnPublisherVideoSizeChanged(int width, int height, ZegoPublishChannel channel);






        /**
         * Play stream quality callback
         *
         * After calling the startPlayingStream successfully, this callback will be triggered every 3 seconds. The collection frame rate, bit rate, RTT, packet loss rate and other quality data  can be obtained, such the health of the publish stream can be monitored in real time.
         * You can monitor the health of the played audio and video streams in real time according to the quality parameters of the callback api, in order to show the downlink network status on the device UI interface in real time.
         * If you does not know how to use the various parameters of the callback api, you can only focus on the level field of the quality parameter, which is a comprehensive value describing the downlink network calculated by SDK based on the quality parameters.
         *
         * @param streamID Stream ID
         * @param quality Playing stream quality, including audio and video frame rate, bit rate, resolution, RTT, etc.
         */
        public delegate void OnPlayerQualityUpdate(string streamId, ZegoPlayStreamQuality quality);


        /**
         * Play media event callback
         *
         * This callback is triggered when an event such as audio and video jamming and recovery occurs in the playing stream.
         * You can use this callback to make statistics on stutters or to make friendly displays in the UI interface of the app.
         *
         * @param streamID Stream ID
         * @param event Play media event callback
         */
        public delegate void OnPlayerMediaEvent(string streamId, ZegoPlayerMediaEvent mediaEvent);



        /**
         * First frame callback notification for remote audio received
         *
         * After the startPlayingStream interface is called successfully, the SDK will receive this callback notification when it collects the first frame of audio data.
         *
         * @param streamID Stream ID
         */
        public delegate void OnPlayerRecvAudioFirstFrame(string streamId);



        /**
         * First frame callback notification for remote video  received
         *
         * After the startPlayingStream interface is called successfully, the SDK will receive this callback notification when it collects the first frame of video  data.
         *
         * @param streamID Stream ID
         */
        public delegate void OnPlayerRecvVideoFirstFrame(string streamId);



        /**
         * First video frame is rendered
         *
         * After the startPlayingStream interface is called successfully, the SDK will receive this callback notification when it rendered the first frame of video  data.
         * You can use this callback to count time consuming that take the first frame time or update the playback stream.
         *
         * @param streamID Stream ID
         */
        public delegate void OnPlayerRenderVideoFirstFrame(string streamId);


        /**
         * playing stream resolution change callback
         *
         * If there is a change in the video resolution of the playing stream, the callback will be triggered, and the user can adjust the display for that stream dynamically.
         * If the publishing stream end triggers the internal stream flow control of SDK due to a network problem, the encoding resolution of the streaming end may be dynamically reduced, and this callback will also be received at this time.
         * If the stream is only audio data, the callback will not be received.
         * This callback will be triggered when the played audio and video stream is actually rendered to the set UI play canvas. You can use this callback notification to update or switch UI components that actually play the stream.
         *
         * @param streamID Stream ID
         * @param width The width of the video
         * @param height The height of the video
         */
        public delegate void OnPlayerVideoSizeChanged(string streamId, int width, int height);


        /**
         * Receive room broadcast message notification
         *
         * @param roomID Room ID
         * @param messageList list of received messages.
         */
        public delegate void OnIMRecvBroadcastMessage(string roomId, List<ZegoBroadcastMessageInfo> messageList);



        /**
         * Receive room custom command notification
         *
         * @param roomID Room ID
         * @param fromUser Sender of the command
         * @param command Command content received
         */
        public delegate void OnIMRecvCustomCommand(string roomId, ZegoUser fromUser, string command);


        /**
         * Receive room barrage message notification
         *
         * @param roomID Room ID
         * @param messageList list of received messages.
         */
        public delegate void OnIMRecvBarrageMessage(string roomId, List<ZegoBarrageMessageInfo> messageList);


        /**
         * Callback for sending broadcast messages
         *
         * @param errorCode Error code, please refer to the common error code document [https://doc-en.zego.im/en/308.html] for details
         * @param messageID ID of this message
         */
        public delegate void OnIMSendBroadcastMessageResult(int errorCode, ulong messageId);


        /**
         * Callback for sending custom command
         *
         * @param errorCode Error code, please refer to the common error code document [https://doc-en.zego.im/en/308.html] for details
         */
        public delegate void OnIMSendCustomCommandResult(int errorCode);


        /**
         * Callback for sending barrage message
         *
         * @param errorCode Error code, please refer to the common error code document [https://doc-en.zego.im/en/308.html] for details
         * @param messageID ID of this message
         */
        public delegate void OnIMSendBarrageMessageResult(int errorCode, string messageId);


        /**
         * Callback for add/remove CDN URL
         *
         * @param errorCode Error code, please refer to the common error code document [https://doc-en.zego.im/en/308.html] for details
         */
        public delegate void OnPublisherUpdateCdnUrlResult(int errorCode);


        /**
         * Add/Remove CDN address status callback
         *
         * After the ZEGO real-time audio and video cloud relays the audio and video streams to the CDN, this callback will be received if the CDN relay status changes, such as a stop or a retry.
         * Developers can use this callback to determine whether the audio and video streams of the relay CDN are normal. If they are abnormal, further locate the cause of the abnormal audio and video streams of the relay CDN and make corresponding disaster recovery strategies.
         * If you do not understand the cause of the abnormality, you can contact ZEGO technicians to analyze the specific cause of the abnormality.
         *
         * @param streamID Stream ID
         * @param infoList List of information that the current CDN is relaying
         */
        public delegate void OnPublisherRelayCDNStateUpdate(string streamID, List<ZegoStreamRelayCDNInfo> infoList);


        /**
         * Captured sound level update callback
         *
         * Callback notification period is 100 ms'
         *
         * @param soundLevel Locally captured sound level value, ranging from 0.0 to 100.0
         */
        public delegate void OnCapturedSoundLevelUpdate(float soundLevel);


        /**
         * Remote sound level update callback
         *
         * Callback notification period is 100 ms'
         *
         * @param soundLevels Remote sound level hash map, key is the streamID, value is the sound level value of the corresponding streamID, value ranging from 0.0 to 100.0
         */
        public delegate void OnRemoteSoundLevelUpdate(Dictionary<string, float> soundLevels);


        /**
         * Captured audio spectrum update callback
         *
         * Callback notification period is 100 ms'
         *
         * @param audioSpectrum Locally captured audio spectrum value list. Spectrum value range is [0-2^30]
         */
        public delegate void OnCapturedAudioSpectrumUpdate(float[] audioSpectrum);



        /**
         * Remote audio spectrum update callback
         *
         * Callback notification period is 100 ms'
         *
         * @param audioSpectrums Remote audio spectrum hash map, key is the streamID, value is the audio spectrum list of the corresponding streamID. Spectrum value range is [0-2^30]
         */
        public delegate void OnRemoteAudioSpectrumUpdate(Dictionary<string, float[]> audioSpectrums);


        /**
         * Receive SEI
         *
         * If sendSEI was called on remote, this callback will be triggered.
         * If only the pure audio stream is played, the SEI information sent by the streaming end will not be received.
         *
         * @param streamID Stream ID
         * @param data SEI content
         */
        public delegate void OnPlayerRecvSEI(string streamID, byte[] data);


        /**
         * Debug error message callback
         *
         * When the APIs are not used correctly, the callback prompts for detailed error information, which is controlled by the [setDebugVerbose] interface
         *
         * @param errorCode Error code, please refer to the common error code document [https://doc-en.zego.im/en/308.html] for details
         * @param funcName Function name
         * @param info Detailed error information
         */
        public delegate void OnDebugError(int errorCode, string funcName, string info);

        /**
        * Stream extra information update notification
        *
        * When a user publishing the stream update the extra information of the stream in the same room, other users in the same room will receive the callback.
        * The stream extra information is an extra information identifier of the stream ID. Unlike the stream ID, which cannot be modified during the publishing process, the stream extra information can be modified midway through the stream corresponding to the stream ID.
        * Developers can synchronize variable content related to stream IDs based on stream additional information.
        *
        * @param roomID Room ID where the user is logged in, a string of up to 128 bytes in length.
        * @param streamList List of streams that the extra info was updated.
        */
        public delegate void OnRoomStreamExtraInfoUpdate(string roomId, List<ZegoStream> streamList);


        /**
         * Callback for updating stream extra information
         *
         * @param errorCode Error code, please refer to the common error code document [https://doc-en.zego.im/en/308.html] for details
         */
        public delegate void OnPublisherSetStreamExtraInfoResult(int errorCode);
        /**
         * The callback for obtaining the locally captured video frames (Raw Data).
         *
         * @param data Raw data of video frames (eg: RGBA only needs to consider data[0], I420 needs to consider data[0,1,2])
         * @param dataLength Data length (eg: RGBA only needs to consider dataLength[0], I420 needs to consider dataLength[0,1,2])，dataLength is uint array,fixed Length is 4
         * @param param Video frame parameters
         * @param flipMode video flip mode
         * @param channel Publishing stream channel
         */
        public delegate void OnCapturedVideoFrameRawData(IntPtr[] data, uint[] dataLength, ZegoVideoFrameParam param, ZegoVideoFlipMode flipMode, ZegoPublishChannel channel);
        /**
         * The callback for obtaining the video frames (Raw Data) of the remote stream. Different streams can be identified by streamID.
         *
         * @param data Raw data of video frames (eg: RGBA only needs to consider data[0], I420 needs to consider data[0,1,2])
         * @param dataLength Data length (eg: RGBA only needs to consider dataLength[0], I420 needs to consider dataLength[0,1,2])，dataLength is uint array,fixed Length is 4
         * @param param Video frame parameters
         * @param streamID Stream ID
         */
        public delegate void OnRemoteVideoFrameRawData(string streamID, IntPtr[] data, uint[] dataLength, ZegoVideoFrameParam param);
        /**
         * Results of starting a mixer task
         *
         * @param errorCode Error code, please refer to the common error code document [https://doc-en.zego.im/en/308.html] for details
         * @param extendedData Extended Information
         */
        public delegate void OnMixerStartResult(int errorCode, string extendedData);
        /**
         * Results of stoping a mixer task
         *
         * @param errorCode Error code, please refer to the common error code document [https://doc-en.zego.im/en/308.html] for details
         */
        public delegate void OnMixerStopResult(int errorCode);
        /**
        * The callback triggered when the SDK is ready to receive captured video data. Only those video data that is sent to the SDK after this callback is received is valid.
        *
        * @param channel Publishing stream channel
        */
        public delegate void OnCustomVideoCaptureStart(ZegoPublishChannel channel);
        /**
        * The callback triggered when SDK stops receiving captured video data.
        *
        * @param channel Publishing stream channel
        */
        public delegate void OnCustomVideoCaptureStop(ZegoPublishChannel channel);
        /**
         * The callback for obtaining the audio data captured by the local microphone.
         *
         * In non-custom audio capture mode, the SDK capture the microphone's sound, but the developer may also need to get a copy of the The audio data captured by the SDK SDK is available through this callback.
         * On the premise of calling [setAudioDataHandler] to set the listener callback, after calling [enableAudioDataCallback] to set the mask 0x01, this callback will be triggered only when it is in the publishing stream state.
         *
         * @param data audio data of pcm format
         * @param dataLength length of data
         * @param param param of audio frame
         */
        public delegate void OnCapturedAudioData(IntPtr data, uint dataLength, ZegoAudioFrameParam param);
       
        /**
         * The callback for obtaining the mixed audio data. Such mixed auido data are generated by the SDK by mixing the audio data of all the remote streams pulled and the auido data captured locally.
         *
         * The audio data of all playing data is mixed with the data captured by the local microphone before it is sent to the loudspeaker, and calleback out in this way.
         * On the premise of calling [setAudioDataHandler] to set the listener callback, after calling [enableAudioDataCallback] to set the mask 0x04, this callback will be triggered only when it is in the publishing stream state or playing stream state.
         *
         * @param data audio data of pcm format
         * @param dataLength length of data
         * @param param param of audio frame
         */
        public delegate void OnMixedAudioData(IntPtr data, uint dataLength, ZegoAudioFrameParam param);


        /**
         * The callback for obtaining the audio data of all the streams playback by SDK.
         *
         * This method will callback all the mixed audio data to be playback. This callback can be used for that you needs to fetch all the mixed audio data to be playback to proccess.
         * On the premise of calling [setAudioDataHandler] to set the listener callback, after calling [enableAudioDataCallback] to set the mask 0x02, this callback will be triggered only when it is in the SDK inner audio and video engine started(called the [startPreivew] or [startPlayingStream] or [startPublishingStream]).
         * When the engine is started in the non-playing stream state or the media player is not used to play the media file, the audio data to be called back is muted audio data.
         *
         * @param data audio data of pcm format
         * @param dataLength length of data
         * @param param param of audio frame
         */
        public delegate void OnPlaybackAudioData(IntPtr data, uint dataLength, ZegoAudioFrameParam param);

        /// <summary>
        /// The callback triggered when the state of data recording (to a file) changes.
        /// </summary>
        /// <param name="state">
        /// File recording status, according to which you should determine the state of the file recording or the prompt of the UI.
        /// </param>
        /// <param name="errorCode">
        /// Error code, please refer to the Error Codes https://doc-en.zego.im/en/308.html for details
        /// </param>
        /// <param name="config">
        /// Record config
        /// </param>
        /// <param name="channel">
        /// Publishing stream channel
        /// </param>
        /// <param name="user_context">
        /// Context of user.
        /// </param>
        public delegate void OnCapturedDataRecordStateUpdate(ZegoDataRecordState state, int errorCode, ZegoDataRecordConfig config, ZegoPublishChannel channel);

        /// <summary>
        /// The callback to report the current recording progress.
        /// </summary>
        /// <param name="progress">
        /// File recording progress, which allows developers to hint at the UI, etc.
        /// </param>
        /// <param name="config">
        /// Record config
        /// </param>
        /// <param name="channel">
        /// Publishing stream channel
        /// </param>
        /// <param name="user_context">
        /// Context of user.
        /// </param>
        public delegate void OnCapturedDataRecordProgressUpdate(ZegoDataRecordProgress progress, ZegoDataRecordConfig config, ZegoPublishChannel channel);
    }
}
