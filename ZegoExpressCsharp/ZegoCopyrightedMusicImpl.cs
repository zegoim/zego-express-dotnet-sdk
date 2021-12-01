using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZEGO
{
    class ZegoCopyrightedMusicImpl: ZegoCopyrightedMusic
    {
        public override void InitCopyrightedMusic(ZegoCopyrightedMusicConfig config, OnCopyrightedMusicInit callback)
        {

        }

        public override ulong GetCacheSize()
        {
            ulong cache_size = 0;

            return cache_size;
        }

        public override void ClearCache()
        {

        }

        public override void SendExtendedRequest(string command, string param, OnCopyrightedMusicSendExtendedRequest callback)
        {

        }

        public override void GetLrcLyric(string songID, OnCopyrightedMusicGetLrcLyric callback)
        {

        }

        public override void GetKrcLyricByToken(string krcToken, OnCopyrightedMusicGetKrcLyricByToken callback)
        {

        }

        public override void RequestSong(ZegoCopyrightedMusicRequestConfig config, OnCopyrightedMusicRequestSong callback)
        {

        }

        public override void RequestAccompaniment(ZegoCopyrightedMusicRequestConfig config, OnCopyrightedMusicRequestAccompaniment callback)
        {

        }

        public override void GetMusicByToken(string shareToken, OnCopyrightedMusicGetMusicByToken callback)
        {

        }

        public override void Download(string resourceID, OnCopyrightedMusicDownload callback)
        {

        }

        public override ulong GetDuration(string resourceID)
        {
            ulong duration = 0;

            return duration;
        }
    }
}
