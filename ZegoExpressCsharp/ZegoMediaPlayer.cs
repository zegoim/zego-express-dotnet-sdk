using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZEGO
{
    public abstract class ZegoMediaPlayer
    {
        /**
        * 播放器播放状态回调
        *
        * @param mediaPlayer 回调的播放器实例
        * @param state 播放器状态
        * @param errorCode 错误码，详情请参考常用错误码文档 [https://doc-zh.zego.im/zh/308.html]
        */
        public OnMediaPlayerStateUpdate onMediaPlayerStateUpdate;
        /**
        * 播放器网络状态事件回调
        *
        * @param mediaPlayer 回调的播放器实例
        * @param networkEvent 网络状态事件
        */

        public OnMediaPlayerNetworkEvent onMediaPlayerNetworkEvent;
        /**
         * 播放器播放进度回调
         *
         * @param mediaPlayer 回调的播放器实例
         * @param millisecond 进度，单位为毫秒
         */

        public OnMediaPlayerPlayingProgress onMediaPlayerPlayingProgress;

        public OnLoadResourceCallback onLoadResourceCallback;

        public ConcurrentDictionary<int, OnSeekToTimeCallback> seekToTimeCallbackDic = new ConcurrentDictionary<int, OnSeekToTimeCallback>();

        public OnAudioFrame onAudioFrame;
        public OnVideoFrame onVideoFrame;

        public abstract void LoadResource(string path, OnLoadResourceCallback onLoadResourceCallback);
        public abstract void EnableRepeat(bool enable);

        public abstract void Start();

        public abstract void Pause();

        public abstract void Resume();

        public abstract void Stop();
        public abstract ZegoMediaPlayerState GetCurrentState();

        public abstract void SeekTo(ulong millisecond, OnSeekToTimeCallback onSeekToTimeCallback);

        public abstract void EnableAux(bool enable);
        public abstract void MuteLocal(bool mute);
        public abstract void SetPlayerCanvas(ZegoCanvas canvas);
        public abstract void SetVolume(int volume);

        public abstract void SetProgressInterval(ulong millisecond);
        public abstract ulong GetTotalDuration();
        public abstract ulong GetCurrentProgress();

        public abstract int GetIndex();

        public abstract void SetVideoHandler(OnVideoFrame onVideoFrame, ZegoVideoFrameFormat format);

        public abstract void SetAudioHandler(OnAudioFrame onAudioFrame);
        public abstract void SetPlayVolume(int volume);
        public abstract void SetPublishVolume(int volume);

        public abstract int GetPlayVolume();
        public abstract int GetPublishVolume();

        public abstract void loadCopyrightedMusicResourceWithPosition(string resourceID, ulong startPosition, OnLoadResourceCallback callback);
    }
}
