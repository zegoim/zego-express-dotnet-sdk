using System;
using System.Collections.Concurrent;
//using AOT;
using static ZEGO.ZegoExpressEngineImpl;
using static ZEGO.ZegoImplCallChangeUtil;
using static ZEGO.ZegoCallBackChangeUtil;
using System.Threading;
namespace ZEGO
{
    public class ZegoAudioEffectPlayerImpl : ZegoAudioEffectPlayer
    {
        public ConcurrentDictionary<int, OnAudioEffectPlayerSeekToCallback> onAudioEffectPlayerSeekToCallbackDics = new ConcurrentDictionary<int, OnAudioEffectPlayerSeekToCallback>();
        public ConcurrentDictionary<int, OnAudioEffectPlayerLoadResourceCallback> onAudioEffectPlayerLoadResourceCallbackDics = new ConcurrentDictionary<int, OnAudioEffectPlayerLoadResourceCallback>();
        private static object zegoAudioEffectPlayerLock = new object();
        private int CheckZegoAudioEffectPlayer(ZegoAudioEffectPlayer audioEffectPlayer)
        {
            int index = GetIndexFromObject<ZegoAudioEffectPlayer>(audioEffectPlayerAndIndex, audioEffectPlayer);
            if (index < 0)
            {
                throw new Exception("may be you had already destroyed the audioEffectPlayer or create the ZegoAudioEffectPlayer but no use ZegoExpressEngine.CreateAudioEffectPlayer");
            }
            return index;
        }
        public override ulong GetCurrentProgress(uint audioEffectID)
        {
            if (enginePtr != null)
            {
                int index = CheckZegoAudioEffectPlayer(this);
                ulong result = IExpressAudioEffectPlayerInternal.zego_express_audio_effect_player_get_current_progress(audioEffectID, (ZegoAudioEffectPlayerInstanceIndex)index);
                string log = string.Format("AudioEffectPlayer GetCurrentProgress audioEffectID:{0} result:{1}", audioEffectID, result);
                ZegoUtil.ZegoPrivateLog(0, log, false, 0);
                return result;
            }

            return 0;

        }

        public override int GetIndex()
        {
            if (enginePtr != null)
            {
                int index = CheckZegoAudioEffectPlayer(this);
                string log = string.Format("AudioEffectPlayer GetIndex index:{0} ", index);
                ZegoUtil.ZegoPrivateLog(0, log, false, 0);
                return index;
            }
            return -1;
        }

        public override ulong GetTotalDuration(uint audioEffectID)
        {
            if (enginePtr != null)
            {
                int index = CheckZegoAudioEffectPlayer(this);
                ulong result = IExpressAudioEffectPlayerInternal.zego_express_audio_effect_player_get_total_duration(audioEffectID, (ZegoAudioEffectPlayerInstanceIndex)index);
                string log = string.Format("AudioEffectPlayer GetTotalDuration audioEffectID:{0} result:{1}", audioEffectID, result);
                ZegoUtil.ZegoPrivateLog(0, log, false, 0);
                return result;
            }

            return 0;
        }

        public override void LoadResource(uint audioEffectID, string path, OnAudioEffectPlayerLoadResourceCallback onAudioEffectPlayerLoadResourceCallback)
        {
            if (enginePtr != null)
            {
                lock (zegoAudioEffectPlayerLock)
                {
                    int index = CheckZegoAudioEffectPlayer(this);
                    int seq = IExpressAudioEffectPlayerInternal.zego_express_audio_effect_player_load_resource(audioEffectID, path, (ZegoAudioEffectPlayerInstanceIndex)index);
                    string log = string.Format("AudioEffectPlayer LoadResource audioEffectID:{0} path:{1} seq:{2} ", audioEffectID, path, seq);
                    onAudioEffectPlayerLoadResourceCallbackDics.AddOrUpdate(seq, onAudioEffectPlayerLoadResourceCallback, (key, oldValue) => onAudioEffectPlayerLoadResourceCallback);
                    ZegoUtil.ZegoPrivateLog(0, log, false, 0);
                }
            }
        }

        public override void Pause(uint audioEffectID)
        {
            if (enginePtr != null)
            {
                int index = CheckZegoAudioEffectPlayer(this);
                int result = IExpressAudioEffectPlayerInternal.zego_express_audio_effect_player_pause(audioEffectID, (ZegoAudioEffectPlayerInstanceIndex)index);
                string log = string.Format("AudioEffectPlayer Pause audioEffectID:{0}  result:{1}", audioEffectID, result);
                ZegoUtil.ZegoPrivateLog(result, log, true, ZegoConstans.ZEGO_EXPRESS_MODULE_AUDIOEFFECTPLAYER);

            }
        }

        public override void PauseAll()
        {
            if (enginePtr != null)
            {
                int index = CheckZegoAudioEffectPlayer(this);
                int result = IExpressAudioEffectPlayerInternal.zego_express_audio_effect_player_pause_all((ZegoAudioEffectPlayerInstanceIndex)index);
                string log = string.Format("AudioEffectPlayer PauseAll result:{0}", result);
                ZegoUtil.ZegoPrivateLog(result, log, true, ZegoConstans.ZEGO_EXPRESS_MODULE_AUDIOEFFECTPLAYER);

            }
        }

        public override void Resume(uint audioEffectID)
        {
            if (enginePtr != null)
            {
                int index = CheckZegoAudioEffectPlayer(this);
                int result = IExpressAudioEffectPlayerInternal.zego_express_audio_effect_player_resume(audioEffectID, (ZegoAudioEffectPlayerInstanceIndex)index);
                string log = string.Format("AudioEffectPlayer Resume audioEffectID:{0}  result:{1}", audioEffectID, result);
                ZegoUtil.ZegoPrivateLog(result, log, true, ZegoConstans.ZEGO_EXPRESS_MODULE_AUDIOEFFECTPLAYER);

            }
        }

        public override void ResumeAll()
        {
            if (enginePtr != null)
            {
                int index = CheckZegoAudioEffectPlayer(this);
                int result = IExpressAudioEffectPlayerInternal.zego_express_audio_effect_player_resume_all((ZegoAudioEffectPlayerInstanceIndex)index);
                string log = string.Format("AudioEffectPlayer ResumeAll result:{0}", result);
                ZegoUtil.ZegoPrivateLog(result, log, true, ZegoConstans.ZEGO_EXPRESS_MODULE_AUDIOEFFECTPLAYER);

            }
        }

        public override void SeekTo(uint audioEffectID, ulong millisecond, OnAudioEffectPlayerSeekToCallback onAudioEffectPlayerSeekToCallback)
        {
            if (enginePtr != null)
            {
                lock (zegoAudioEffectPlayerLock)
                {
                    int index = CheckZegoAudioEffectPlayer(this);
                    int seq = IExpressAudioEffectPlayerInternal.zego_express_audio_effect_player_seek_to(audioEffectID, millisecond, (ZegoAudioEffectPlayerInstanceIndex)index);
                    string log = string.Format("AudioEffectPlayer SeekTo audioEffectID:{0} millisecond:{1} seq:{2} ", audioEffectID, millisecond, seq);
                    onAudioEffectPlayerSeekToCallbackDics.AddOrUpdate(seq, onAudioEffectPlayerSeekToCallback, (key, oldValue) => onAudioEffectPlayerSeekToCallback);
                    ZegoUtil.ZegoPrivateLog(0, log, false, 0);
                }
            }
        }

        public override void SetVolume(uint audioEffectID, int volume)
        {
            if (enginePtr != null)
            {
                int index = CheckZegoAudioEffectPlayer(this);
                int result = IExpressAudioEffectPlayerInternal.zego_express_audio_effect_player_set_volume(audioEffectID, volume, (ZegoAudioEffectPlayerInstanceIndex)index);
                string log = string.Format("AudioEffectPlayer SetVolume audioEffectID:{0} volume:{1}  result:{2}", audioEffectID, volume, result);
                ZegoUtil.ZegoPrivateLog(result, log, true, ZegoConstans.ZEGO_EXPRESS_MODULE_AUDIOEFFECTPLAYER);

            }
        }

        public override void SetVolumeAll(int volume)
        {
            if (enginePtr != null)
            {
                int index = CheckZegoAudioEffectPlayer(this);
                int result = IExpressAudioEffectPlayerInternal.zego_express_audio_effect_player_set_volume_all(volume, (ZegoAudioEffectPlayerInstanceIndex)index);
                string log = string.Format("AudioEffectPlayer SetVolumeAll volume:{0}  result:{1}", volume, result);
                ZegoUtil.ZegoPrivateLog(result, log, true, ZegoConstans.ZEGO_EXPRESS_MODULE_AUDIOEFFECTPLAYER);

            }
        }

        public override void Start(uint audioEffectID, string path, ZegoAudioEffectPlayConfig config)
        {
            if (enginePtr != null)
            {
                int index = CheckZegoAudioEffectPlayer(this);
                zego_audio_effect_play_config audio_Effect_Play_Config = ChangeZegoAudioEffectPlayConfigClassToStruct(config);
                IntPtr ptr = ZegoUtil.GetStructPointer(audio_Effect_Play_Config);
                int result = IExpressAudioEffectPlayerInternal.zego_express_audio_effect_player_start(audioEffectID, path, ptr, (ZegoAudioEffectPlayerInstanceIndex)index);
                ZegoUtil.ReleaseStructPointer(ptr);
                string log = string.Format("AudioEffectPlayer Start audioEffectID:{0} path:{1} result:{2}", audioEffectID, path, result);
                ZegoUtil.ZegoPrivateLog(result, log, true, ZegoConstans.ZEGO_EXPRESS_MODULE_AUDIOEFFECTPLAYER);

            }
        }


        public override void Stop(uint audioEffectID)
        {
            if (enginePtr != null)
            {
                int index = CheckZegoAudioEffectPlayer(this);
                int result = IExpressAudioEffectPlayerInternal.zego_express_audio_effect_player_stop(audioEffectID, (ZegoAudioEffectPlayerInstanceIndex)index);
                string log = string.Format("AudioEffectPlayer Stop audioEffectID:{0}  result:{1}", audioEffectID, result);
                ZegoUtil.ZegoPrivateLog(result, log, true, ZegoConstans.ZEGO_EXPRESS_MODULE_AUDIOEFFECTPLAYER);

            }
        }

        public override void StopAll()
        {
            if (enginePtr != null)
            {
                int index = CheckZegoAudioEffectPlayer(this);
                int result = IExpressAudioEffectPlayerInternal.zego_express_audio_effect_player_stop_all((ZegoAudioEffectPlayerInstanceIndex)index);
                string log = string.Format("AudioEffectPlayer StopAll  result:{0}", result);
                ZegoUtil.ZegoPrivateLog(result, log, true, ZegoConstans.ZEGO_EXPRESS_MODULE_AUDIOEFFECTPLAYER);

            }
        }

        public override void UnloadResource(uint audioEffectID)
        {
            if (enginePtr != null)
            {
                int index = CheckZegoAudioEffectPlayer(this);
                int result = IExpressAudioEffectPlayerInternal.zego_express_audio_effect_player_unload_resource(audioEffectID, (ZegoAudioEffectPlayerInstanceIndex)index);
                string log = string.Format("AudioEffectPlayer UnloadResource  result:{0}", result);
                ZegoUtil.ZegoPrivateLog(result, log, true, ZegoConstans.ZEGO_EXPRESS_MODULE_AUDIOEFFECTPLAYER);

            }
        }


        public static void zego_on_audio_effect_player_seek_to(int seq, int error_code, ZegoAudioEffectPlayerInstanceIndex instance_index, System.IntPtr user_context)
        {
            lock (zegoAudioEffectPlayerLock)
            {
                ZegoAudioEffectPlayerImpl zegoAudioEffectPlayerImpl = (ZegoAudioEffectPlayerImpl)GetObjectFromIndex(audioEffectPlayerAndIndex, (int)instance_index);
                if (zegoAudioEffectPlayerImpl.onAudioEffectPlayerSeekToCallbackDics != null)
                {
                    string log = string.Format("zego_on_audio_effect_player_seek_to instance_index:{0} seq:{1} error_code:{2}", instance_index, seq, error_code);
                    ZegoUtil.ZegoPrivateLog(error_code, log, true, ZegoConstans.ZEGO_EXPRESS_MODULE_AUDIOEFFECTPLAYER);
                    OnAudioEffectPlayerSeekToCallback callback = GetCallbackFromSeq<OnAudioEffectPlayerSeekToCallback>(zegoAudioEffectPlayerImpl.onAudioEffectPlayerSeekToCallbackDics, seq);
                    if (callback == null)
                    {
                        return;
                    }

                    context?.Post(new SendOrPostCallback((o) =>
                    {
                        callback?.Invoke(error_code);
                        zegoAudioEffectPlayerImpl?.onAudioEffectPlayerSeekToCallbackDics?.TryRemove(seq, out _);
                    }), null);

                }
                else
                {
                    return;
                }
            }
        }


        public static void zego_on_audio_effect_player_load_resource(int seq, int error_code, ZegoAudioEffectPlayerInstanceIndex instance_index, System.IntPtr user_context)
        {
            lock (zegoAudioEffectPlayerLock)
            {
                ZegoAudioEffectPlayerImpl zegoAudioEffectPlayerImpl = (ZegoAudioEffectPlayerImpl)GetObjectFromIndex(audioEffectPlayerAndIndex, (int)instance_index);
                if (zegoAudioEffectPlayerImpl.onAudioEffectPlayerLoadResourceCallbackDics != null)
                {
                    string log = string.Format("zego_on_audio_effect_player_load_resource instance_index:{0} seq:{1} error_code:{2}", instance_index, seq, error_code);
                    ZegoUtil.ZegoPrivateLog(error_code, log, true, ZegoConstans.ZEGO_EXPRESS_MODULE_AUDIOEFFECTPLAYER);
                    OnAudioEffectPlayerLoadResourceCallback callback = GetCallbackFromSeq<OnAudioEffectPlayerLoadResourceCallback>(zegoAudioEffectPlayerImpl.onAudioEffectPlayerLoadResourceCallbackDics, seq);
                    if (callback == null)
                    {
                        return;
                    }

                    context?.Post(new SendOrPostCallback((o) =>
                    {
                        callback?.Invoke(error_code);
                        zegoAudioEffectPlayerImpl?.onAudioEffectPlayerLoadResourceCallbackDics?.TryRemove(seq, out _);
                    }), null);

                }
                else
                {
                    return;
                }
            }
        }

        public static void zego_on_audio_effect_play_state_update(uint audio_effect_id, ZegoAudioEffectPlayState state, int error_code, ZegoAudioEffectPlayerInstanceIndex instance_index, System.IntPtr user_context)
        {
            ZegoAudioEffectPlayerImpl zegoAudioEffectPlayerImpl = (ZegoAudioEffectPlayerImpl)GetObjectFromIndex(audioEffectPlayerAndIndex, (int)instance_index);
            if (zegoAudioEffectPlayerImpl.onAudioEffectPlayStateUpdate != null)
            {
                string log = string.Format("zego_on_audio_effect_play_state_update instance_index:{0} audio_effect_id:{1} state:{2} error_code:{3}", instance_index, audio_effect_id, state, error_code);
                ZegoUtil.ZegoPrivateLog(error_code, log, true, ZegoConstans.ZEGO_EXPRESS_MODULE_AUDIOEFFECTPLAYER);
                context?.Post(new SendOrPostCallback((o) =>
                {
                    zegoAudioEffectPlayerImpl?.onAudioEffectPlayStateUpdate?.Invoke(zegoAudioEffectPlayerImpl, audio_effect_id, state, error_code);
                }), null);

            }
            else
            {
                return;
            }
        }
    }
}
