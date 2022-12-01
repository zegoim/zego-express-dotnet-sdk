using static ZEGO.IZegoAudioEffectPlayerHandler;

namespace ZEGO
{

    public abstract class ZegoAudioEffectPlayer
    {
        /**
         * Start playing audio effect.
         *
         * Available since: 1.16.0
         * Description: Start playing audio effect. The default is only played once and is not mixed into the publishing stream, if you want to change this please modify [config] param.
         * Use cases: When you need to play short sound effects, such as applause, cheers, etc., you can use this interface to achieve, and further configure the number of plays through the [config] parameter, and mix the sound effects into the push stream.
         * When to call: It can be called after [createAudioEffectPlayer].
         * Restrictions: None.
         *
         * @param audioEffectID Description: ID for the audio effect. The SDK uses audioEffectID to control the playback of sound effects. The SDK does not force the user to pass in this parameter as a fixed value. It is best to ensure that each sound effect can have a unique ID. The recommended methods are static self-incrementing ID or the hash of the incoming sound effect file path.
         * @param path The absolute path of the local resource. <br>Value range: "assets://"、"ipod-library://" and network url are not supported. Set path as null or "" if resource is loaded already using [loadResource].
         * @param config Audio effect playback configuration. <br>Default value: Set null will only be played once, and will not be mixed into the publishing stream.
         */
        public abstract void Start(uint audioEffectID, string path, ZegoAudioEffectPlayConfig config);

        /**
         * Stop playing audio effect.
         *
         * Available since: 1.16.0
         * Description: Stop playing the specified audio effect [audioEffectID].
         * When to call: The specified [audioEffectID] is [start].
         * Restrictions: None.
         *
         * @param audioEffectID ID for the audio effect.
         */
        public abstract void Stop(uint audioEffectID);

        /**
         * Pause playing audio effect.
         *
         * Available since: 1.16.0
         * Description: Pause playing the specified audio effect [audioEffectID].
         * When to call: The specified [audioEffectID] is [start].
         * Restrictions: None.
         *
         * @param audioEffectID ID for the audio effect.
         */
        public abstract void Pause(uint audioEffectID);

        /**
         * Resume playing audio effect.
         *
         * Available since: 1.16.0
         * Description: Resume playing the specified audio effect [audioEffectID].
         * When to call: The specified [audioEffectID] is [pause].
         * Restrictions: None.
         *
         * @param audioEffectID ID for the audio effect.
         */
        public abstract void Resume(uint audioEffectID);

        /**
         * Stop playing all audio effect.
         *
         * Available since: 1.16.0
         * Description: Stop playing all audio effect.
         * When to call: Some audio effects are Playing.
         * Restrictions: None.
         */
        public abstract void StopAll();

        /**
         * Pause playing all audio effect.
         *
         * Available since: 1.16.0
         * Description: Pause playing all audio effect.
         * When to call: It can be called after [createAudioEffectPlayer].
         * Restrictions: None.
         */
        public abstract void PauseAll();

        /**
         * Resume playing all audio effect.
         *
         * Available since: 1.16.0
         * Description: Resume playing all audio effect.
         * When to call: It can be called after [pauseAll].
         * Restrictions: None.
         */
        public abstract void ResumeAll();

        /**
         * Set the specified playback progress.
         *
         * Available since: 1.16.0
         * Description: Set the specified audio effect playback progress. Unit is millisecond.
         * When to call: The specified [audioEffectID] is[start], and not finished.
         * Restrictions: None.
         *
         * @param audioEffectID ID for the audio effect.
         * @param millisecond Point in time of specified playback progress.
         * @param onAudioEffectPlayerSeekToCallback The result of seek.
         */
        public abstract void SeekTo(uint audioEffectID, ulong millisecond, OnAudioEffectPlayerSeekToCallback onAudioEffectPlayerSeekToCallback);

        /**
         * Set volume for a single audio effect. Both the local play volume and the publish volume are set.
         *
         * Available since: 1.16.0
         * Description: Set volume for a single audio effect. Both the local play volume and the publish volume are set.
         * When to call: The specified [audioEffectID] is [start].
         * Restrictions: None.
         *
         * @param audioEffectID ID for the audio effect.
         * @param volume Volume. <br>Value range: The range is 0 ~ 200. <br>Default value: The default is 100.
         */
        public abstract void SetVolume(uint audioEffectID, int volume);

        /**
         * Set volume for all audio effect. Both the local play volume and the publish volume are set.
         *
         * Available since: 1.16.0
         * Description: Set volume for all audio effect. Both the local play volume and the publish volume are set.
         * When to call: It can be called after [createAudioEffectPlayer].
         * Restrictions: None.
         *
         * @param volume Volume. <br>Value range: The range is 0 ~ 200. <br>Default value: The default is 100.
         */
        public abstract void SetVolumeAll(int volume);

        /**
         * Get the total duration of the specified audio effect resource.
         *
         * Available since: 1.16.0
         * Description: Get the total duration of the specified audio effect resource. Unit is millisecond.
         * When to call: You should invoke this function after the audio effect resource already loaded, otherwise the return value is 0.
         * Restrictions: It can be called after [createAudioEffectPlayer].
         * Related APIs: [start], [loadResource].
         *
         * @param audioEffectID ID for the audio effect.
         * @return Unit is millisecond.
         */
        public abstract ulong GetTotalDuration(uint audioEffectID);

        /**
         * Get current playback progress.
         *
         * Available since: 1.16.0
         * Description: Get current playback progress of the specified audio effect. Unit is millisecond.
         * When to call: You should invoke this function after the audio effect resource already loaded, otherwise the return value is 0.
         * Restrictions: None.
         * Related APIs: [start], [loadResource].
         *
         * @param audioEffectID ID for the audio effect.
         */
        public abstract ulong GetCurrentProgress(uint audioEffectID);

        /**
         * Load audio effect resource.
         *
         * Available since: 1.16.0
         * Description: Load audio effect resource.
         * Use cases: In a scene where the same sound effect is played frequently, the SDK provides the function of preloading the sound effect file into the memory in order to optimize the performance of repeatedly reading and decoding the file.
         * When to call: It can be called after [createAudioEffectPlayer].
         * Restrictions: Preloading supports loading up to 15 sound effect files at the same time, and the duration of the sound effect files cannot exceed 30s, otherwise an error will be reported when loading.
         *
         * @param audioEffectID ID for the audio effect.
         * @param path the absolute path of the audio effect resource and cannot be null or "". <br>Value range: "assets://"、"ipod-library://" and network url are not supported.
         * @param onAudioEffectPlayerLoadResourceCallback load audio effect resource result.
         */
        public abstract void LoadResource(uint audioEffectID, string path, OnAudioEffectPlayerLoadResourceCallback onAudioEffectPlayerLoadResourceCallback);

        /**
         * Unload audio effect resource.
         *
         * Available since: 1.16.0
         * Description: Unload the specified audio effect resource.
         * When to call: After the sound effects are used up, related resources can be released through this function; otherwise, the SDK will release the loaded resources when the AudioEffectPlayer instance is destroyed.
         * Restrictions: None.
         * Related APIs: [loadResource].
         *
         * @param audioEffectID ID for the audio effect loaded.
         */
        public abstract void UnloadResource(uint audioEffectID);

        /**
         * Get audio effect player index.
         *
         * Available since: 1.16.0
         * Description: Get audio effect player index.
         * When to call: It can be called after [createAudioEffectPlayer].
         * Restrictions: None.
         *
         * @return Audio effect player index.
         */
        public abstract int GetIndex();

        public OnAudioEffectPlayStateUpdate onAudioEffectPlayStateUpdate;


    }

}
