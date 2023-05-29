﻿using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ZEGO
{
    public class ZegoMediaPlayerImpl : ZegoMediaPlayer
    {
        public override void LoadResource(string path, OnLoadResourceCallback onLoadResourceCallback)
        {
            this.onLoadResourceCallback = onLoadResourceCallback;
            ZegoExpressEngineImpl.LoadResource(this, path);
        }

        public override void LoadCopyrightedMusicResourceWithPosition(string resourceID, ulong startPosition, OnLoadResourceCallback callback)
        {
            this.onLoadResourceCallback = callback;
            ZegoMediaPlayerInstanceIndex curIndex = ZegoExpressEngineImpl.GetIndexFromZegoMediaPlayer(this);
            int result = IExpressMediaPlayerInternal.zego_express_media_player_load_copyrighted_music_resource_with_position(resourceID, (IntPtr)startPosition, curIndex);
            string log = string.Format("loadCopyrightedMusicResourceWithPosition, resourceID:{0}  startPosition:{1} ", resourceID, startPosition);
            ZegoUtil.ZegoPrivateLog(0, log, false, 0);
        }

        public override void EnableRepeat(bool enable)
        {
            ZegoExpressEngineImpl.EnableRepeat(this, enable);
        }
        public override void Start()
        {
            ZegoExpressEngineImpl.Start(this);
        }
        public override void Pause()
        {
            ZegoExpressEngineImpl.Pause(this);
        }
        public override void Resume()
        {
            ZegoExpressEngineImpl.Resume(this);
        }
        public override void Stop()
        {
            ZegoExpressEngineImpl.Stop(this);
        }
        public override ZegoMediaPlayerState GetCurrentState()
        {
            return ZegoExpressEngineImpl.GetCurrentState(this);
        }


        public override void SeekTo(ulong millisecond, OnSeekToTimeCallback onSeekToTimeCallback)
        {
            ZegoExpressEngineImpl.SeekTo(this, millisecond, onSeekToTimeCallback);
        }
        public override void EnableAux(bool enable)
        {
            ZegoExpressEngineImpl.EnableAux(this, enable);
        }
        public override void MuteLocal(bool mute)
        {
            ZegoExpressEngineImpl.MuteLocal(this, mute);
        }
        public override void SetPlayerCanvas(ZegoCanvas canvas)
        {
            ZegoExpressEngineImpl.SetPlayerCanvas(this, canvas);
        }
        public override void SetVolume(int volume)
        {
            ZegoExpressEngineImpl.SetVolume(this, volume);
        }

        public override void SetProgressInterval(ulong millisecond)
        {
            ZegoExpressEngineImpl.SetProgressInterval(this, millisecond);
        }

        public override ulong GetTotalDuration()
        {
            return ZegoExpressEngineImpl.GetTotalDuration(this);
        }
        public override ulong GetCurrentProgress()
        {
            return ZegoExpressEngineImpl.GetCurrentProgress(this);
        }
        public override int GetIndex()
        {
            return ZegoExpressEngineImpl.GetIndex(this);
        }
        public override void SetVideoHandler(OnVideoFrame onVideoFrame, ZegoVideoFrameFormat format)
        {
            this.onVideoFrame = onVideoFrame;
            ZegoExpressEngineImpl.SetVideoHandler(this, format, onVideoFrame);
        }
        public override void SetAudioHandler(OnAudioFrame onAudioFrame)
        {
            this.onAudioFrame = onAudioFrame;
            ZegoExpressEngineImpl.SetAudioHandler(this, onAudioFrame);
        }

        public override void SetPlayVolume(int volume)
        {
            ZegoExpressEngineImpl.SetMediaPlayerPlayVolume(this, volume);
        }

        public override void SetPublishVolume(int volume)
        {
            ZegoExpressEngineImpl.SetMediaPlayerPublishVolume(this, volume);
        }

        public override int GetPlayVolume()
        {
            return ZegoExpressEngineImpl.GetMediaPlayerPlayVolume(this);
        }

        public override int GetPublishVolume()
        {
            return ZegoExpressEngineImpl.GetMediaPlayerPublishVolume(this);
        }

        public override uint GetAudioTrackCount()
        {
            return ZegoExpressEngineImpl.GetAudioTrackCount(this);
        }

        public override void SetAudioTrackIndex(uint index)
        {
            ZegoExpressEngineImpl.SetAudioTrackIndex(this, index);
        }
    }
}
