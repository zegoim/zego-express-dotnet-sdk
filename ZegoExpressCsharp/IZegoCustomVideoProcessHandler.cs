using System;
namespace ZEGO {

public class IZegoCustomVideoProcessHandler {
    /**
         * Call back when the original video data is obtained.
         *
         * Available since: 2.2.0
         * Description: When the custom video pre-processing is turned on, after calling [setCustomVideoProcessHandler] to set the callback, the SDK receives the original video data and calls back to the developer. After the developer has processed the original image, he must call [sendCustomVideoProcessedRawData] to send the processed data back to the SDK, otherwise it will cause frame loss.
         * Use cases: After the developer collects the video data by himself or obtains the video data collected by the SDK, if the basic beauty and watermark functions of the SDK cannot meet the needs of the developer (for example, the beauty effect cannot meet the expectations), the ZegoEffects SDK can be used to perform the video Some special processing, such as beautifying, adding pendants, etc., this process is the pre-processing of custom video.
         * When to Trigger: When the custom video pre-processing is enabled, the SDK collects the original video data.
         * Restrictions: This interface takes effect when [enableCustomVideoProcessing] is called to enable custom video pre-processing and the bufferType of config is passed in [ZegoVideoBufferTypeRawData].
         * Platform differences: It only takes effect on the Windows platform.
         *
         * @param data Raw video data. RGB format data storage location is data[0], YUV format data storage location is Y component：data[0], U component：data[1], V component：data[2].
         * @param dataLength Raw video data length. RGB format data length storage location is dataLength[0], YUV format data storage location respectively Y component length：dataLength[0], U component length：dataLength[1], V component length：dataLength[2].
         * @param param Video frame parameters.
         * @param referenceTimeMillisecond Video frame reference time, UNIX timestamp, in milliseconds.
         * @param channel Publishing stream channel.
         */
    public delegate void OnCapturedUnprocessedRawData(ref IntPtr data, ref uint dataLength,
                                                      ZegoVideoFrameParam param,
                                                      ulong referenceTimeMillisecond,
                                                      ZegoPublishChannel channel);

    /**
         * Call back when the original video data of type [CVPixelBuffer] is obtained.
         *
         * Available since: 2.2.0
         * Description: When the custom video pre-processing is turned on, after calling [setCustomVideoProcessHandler] to set the callback, the SDK receives the original video data and calls back to the developer. After the developer has processed the original image, he must call [sendCustomVideoProcessedCVPixelbuffer] to send the processed data back to the SDK, otherwise it will cause frame loss.
         * Use cases: After the developer collects the video data by himself or obtains the video data collected by the SDK, if the basic beauty and watermark functions of the SDK cannot meet the needs of the developer (for example, the beauty effect cannot meet the expectations), the ZegoEffects SDK can be used to perform the video Some special processing, such as beautifying, adding pendants, etc., this process is the pre-processing of custom video.
         * When to Trigger: When the custom video pre-processing is enabled, the SDK collects the original video data.
         * Restrictions: This interface takes effect when [enableCustomVideoProcessing] is called to enable custom video pre-processing and the bufferType of config is passed in [ZegoVideoBufferTypeCVPixelBuffer].
         * Platform differences: It only takes effect on the iOS/macOS platform.
         *
         * @param buffer CVPixelBufferRef type data.
         * @param timestamp video frame reference time, UNIX timestamp.
         * @param channel Publishing stream channel.
         */
    public delegate void OnCapturedUnprocessedCVPixelBuffer(IntPtr buffer, ulong timestamp,
                                                            ZegoPublishChannel channel);

    /**
         * Call back when the original video data of type [Texture] is obtained.
         *
         * Available since: 2.2.0
         * Description: When the custom video pre-processing is turned on, after calling [setCustomVideoProcessHandler] to set the callback, the SDK receives the original video data and calls back to the developer. After the developer has processed the original image, he must call [sendCustomVideoProcessedTextureData] to send the processed data back to the SDK, otherwise it will cause frame loss.
         * Use cases: After the developer collects the video data by himself or obtains the video data collected by the SDK, if the basic beauty and watermark functions of the SDK cannot meet the needs of the developer (for example, the beauty effect cannot meet the expectations), the ZegoEffects SDK can be used to perform the video Some special processing, such as beautifying, adding pendants, etc., this process is the pre-processing of custom video.
         * When to Trigger: When the custom video pre-processing is enabled, the SDK collects the original video data.
         * Restrictions: This interface takes effect when [enableCustomVideoProcessing] is called to enable custom video pre-processing and the bufferType of config is passed in [ZegoVideoBufferTypeGLTexture2D].
         * Platform differences: It only takes effect on the Android platform.
         *
         * @param textureID Texture ID.
         * @param width Texture width
         * @param height Texture height
         * @param referenceTimeMillisecond video frame reference time, UNIX timestamp, in milliseconds.
         * @param channel Publishing stream channel
         */
    public delegate void OnCapturedUnprocessedTextureData(int textureID, int width, int height,
                                                          ulong referenceTimeMillisecond,
                                                          ZegoPublishChannel channel);
}

}
