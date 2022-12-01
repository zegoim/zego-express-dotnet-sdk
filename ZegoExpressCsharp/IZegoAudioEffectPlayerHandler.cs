
namespace ZEGO
{

    public class IZegoAudioEffectPlayerHandler
    {
        /**
         * Audio effect playback state callback.
         *
         * Available since: 1.16.0
         * Description: This callback is triggered when the playback state of a audio effect of the audio effect player changes.
         * Trigger: This callback is triggered when the playback status of the audio effect changes.
         * Restrictions: None.
         *
         * @param audioEffectPlayer Audio effect player instance that triggers this callback.
         * @param audioEffectID The ID of the audio effect resource that triggered this callback.
         * @param state The playback state of the audio effect.
         * @param errorCode Error code, please refer to the error codes document https://docs.zegocloud.com/en/5548.html for details.
         */
        public delegate void OnAudioEffectPlayStateUpdate(ZegoAudioEffectPlayer audioEffectPlayer, uint audioEffectID, ZegoAudioEffectPlayState state, int errorCode);


    }
    /**
     * Callback for audio effect player loads resources.
     *
     * @param errorCode Error code, please refer to the error codes document https://docs.zegocloud.com/en/5548.html for details.
     */
    public delegate void OnAudioEffectPlayerLoadResourceCallback(int errorCode);

    /**
     * Callback for audio effect player seek to playback progress.
     *
     * @param errorCode Error code, please refer to the error codes document https://docs.zegocloud.com/en/5548.html for details.
     */
    public delegate void OnAudioEffectPlayerSeekToCallback(int errorCode);


}
