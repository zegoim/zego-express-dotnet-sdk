using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZEGO
{
    public delegate void OnMediaPlayerStateUpdate(ZegoMediaPlayer mediaPlayer, ZegoMediaPlayerState state, int errorCode);
    public delegate void OnMediaPlayerNetworkEvent(ZegoMediaPlayer mediaPlayer, ZegoMediaPlayerNetworkEvent networkEvent);
    public delegate void OnMediaPlayerPlayingProgress(ZegoMediaPlayer mediaPlayer, ulong millisecond);
    public delegate void OnLoadResourceCallback(int errorCode);
    public delegate void OnSeekToTimeCallback(int errorCode);
    public delegate void OnAudioFrame(ZegoMediaPlayer mediaPlayer, IntPtr data, uint dataLength, ZegoAudioFrameParam param);
    public delegate void OnVideoFrame(ZegoMediaPlayer mediaPlayer, IntPtr[] data, uint[] dataLength, ZegoVideoFrameParam param);//dataLength is uint array,fixed Length is 4

}
