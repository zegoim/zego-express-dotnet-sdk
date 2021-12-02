using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Concurrent;
using static ZEGO.ZegoExpressEngineImpl;
using static ZEGO.ZegoImplCallChangeUtil;
using static ZEGO.ZegoUtil;
using static ZEGO.ZegoConstans;

namespace ZEGO
{
    class ZegoCopyrightedMusicImpl: ZegoCopyrightedMusic
    {
        private ConcurrentDictionary<int, OnCopyrightedMusicSendExtendedRequest> onCopyrightedMusicSendExtendedRequestDics = new ConcurrentDictionary<int, OnCopyrightedMusicSendExtendedRequest>();
        private ConcurrentDictionary<int, OnCopyrightedMusicGetLrcLyric> onCopyrightedMusicGetLrcLyricDics = new ConcurrentDictionary<int, OnCopyrightedMusicGetLrcLyric>();
        private ConcurrentDictionary<int, OnCopyrightedMusicGetKrcLyricByToken> onCopyrightedMusicGetKrcLyricByTokenDics = new ConcurrentDictionary<int, OnCopyrightedMusicGetKrcLyricByToken>();
        private ConcurrentDictionary<int, OnCopyrightedMusicRequestSong> onCopyrightedMusicRequestSongDics = new ConcurrentDictionary<int, OnCopyrightedMusicRequestSong>();
        private ConcurrentDictionary<int, OnCopyrightedMusicRequestAccompaniment> onCopyrightedMusicRequestAccompanimentDics = new ConcurrentDictionary<int, OnCopyrightedMusicRequestAccompaniment>();
        private ConcurrentDictionary<int, OnCopyrightedMusicGetMusicByToken> onCopyrightedMusicGetMusicByTokenDics = new ConcurrentDictionary<int, OnCopyrightedMusicGetMusicByToken>();
        private ConcurrentDictionary<int, OnCopyrightedMusicDownload> onCopyrightedMusicDownloadDics = new ConcurrentDictionary<int, OnCopyrightedMusicDownload>();
        public override void InitCopyrightedMusic(ZegoCopyrightedMusicConfig config, OnCopyrightedMusicInit callback)
        {
            zego_copyrighted_music_config music_config = ChangeZegoCopyrightedMusicConfigClassToStruct(config);
            IExpressCopyrightedMusic.zego_express_copyrighted_music_init(music_config);

            string log = string.Format("InitCopyrightedMusic, userID:{0}, userName:{1}, result:{2}", config.user.userID, config.user.userName, 0);
            ZegoPrivateLog(0, log, true, ZEGO_EXPRESS_MODULE_COPYRIGHTEDMUSIC);
        }

        public override ulong GetCacheSize()
        {
            string log = string.Format("GetCacheSize, result:{0}", 0);
            ZegoPrivateLog(0, log, true, ZEGO_EXPRESS_MODULE_COPYRIGHTEDMUSIC);
            return IExpressCopyrightedMusic.zego_express_copyrighted_music_get_cache_size();
        }

        public override void ClearCache()
        {
            int result = IExpressCopyrightedMusic.zego_express_copyrighted_music_clear_cache();

            string log = string.Format("ClearCache, result:{0}", result);
            ZegoPrivateLog(result, log, true, ZEGO_EXPRESS_MODULE_COPYRIGHTEDMUSIC);
        }

        public override void SendExtendedRequest(string command, string param, OnCopyrightedMusicSendExtendedRequest callback)
        {
            int seq = IExpressCopyrightedMusic.zego_express_copyrighted_music_send_extended_request(command, param);
            string log = string.Format("SendExtendedRequest, result:{0}", 0);
            ZegoPrivateLog(0, log, true, ZEGO_EXPRESS_MODULE_COPYRIGHTEDMUSIC);
            onCopyrightedMusicSendExtendedRequestDics.AddOrUpdate(seq, callback, (key, old_value)=> callback);
        }

        public override void GetLrcLyric(string songID, OnCopyrightedMusicGetLrcLyric callback)
        {
            int seq = IExpressCopyrightedMusic.zego_express_copyrighted_music_get_lrc_lyric(songID);
            string log = string.Format("GetLrcLyric, songID:{0}, result:{1}", songID, 0);
            ZegoPrivateLog(0, log, true, ZEGO_EXPRESS_MODULE_COPYRIGHTEDMUSIC);
            onCopyrightedMusicGetLrcLyricDics.AddOrUpdate(seq, callback, (key,old_value)=>callback);
        }

        public override void GetKrcLyricByToken(string krcToken, OnCopyrightedMusicGetKrcLyricByToken callback)
        {
            int seq = IExpressCopyrightedMusic.zego_express_copyrighted_music_get_krc_lyric_by_token(krcToken);
            string log = string.Format("GetKrcLyricByToken, krcToken:{0}, result:{1}", krcToken, 0);
            ZegoPrivateLog(0, log, true, ZEGO_EXPRESS_MODULE_COPYRIGHTEDMUSIC);
            onCopyrightedMusicGetKrcLyricByTokenDics.AddOrUpdate(seq, callback, (key, old_value) => callback);
        }

        public override void RequestSong(ZegoCopyrightedMusicRequestConfig config, OnCopyrightedMusicRequestSong callback)
        {
            zego_copyrighted_music_request_config request_config = ChangeZegoCopyrightedMusicRequestConfigClassToStruct(config);
            int seq = IExpressCopyrightedMusic.zego_express_copyrighted_music_request_song(request_config);
            string log = string.Format("RequestSong, songID:{0},mode:{1}, result:{1}", config.songID, config.mode, 0);
            ZegoPrivateLog(0, log, true, ZEGO_EXPRESS_MODULE_COPYRIGHTEDMUSIC);
            onCopyrightedMusicRequestSongDics.AddOrUpdate(seq, callback, (key, old_value) => callback);
        }

        public override void RequestAccompaniment(ZegoCopyrightedMusicRequestConfig config, OnCopyrightedMusicRequestAccompaniment callback)
        {
            zego_copyrighted_music_request_config request_config = ChangeZegoCopyrightedMusicRequestConfigClassToStruct(config);
            int seq = IExpressCopyrightedMusic.zego_express_copyrighted_music_request_accompaniment(request_config);
            string log = string.Format("RequestAccompaniment, songID:{0},mode:{1}, result:{1}", config.songID, config.mode, 0);
            ZegoPrivateLog(0, log, true, ZEGO_EXPRESS_MODULE_COPYRIGHTEDMUSIC);
            onCopyrightedMusicRequestAccompanimentDics.AddOrUpdate(seq, callback, (key, old_value) => callback);
        }

        public override void GetMusicByToken(string shareToken, OnCopyrightedMusicGetMusicByToken callback)
        {
            int seq = IExpressCopyrightedMusic.zego_express_copyrighted_music_get_music_by_token(shareToken);
            string log = string.Format("GetMusicByToken, shareToken:{0},result:{1}", shareToken, 0);
            ZegoPrivateLog(0, log, true, ZEGO_EXPRESS_MODULE_COPYRIGHTEDMUSIC);
            onCopyrightedMusicGetMusicByTokenDics.AddOrUpdate(seq, callback, (key, old_value) => callback);
        }

        public override void Download(string resourceID, OnCopyrightedMusicDownload callback)
        {
            int seq = IExpressCopyrightedMusic.zego_express_copyrighted_music_download(resourceID);
            string log = string.Format("Download, resourceID:{0},result:{1}", resourceID, 0);
            ZegoPrivateLog(0, log, true, ZEGO_EXPRESS_MODULE_COPYRIGHTEDMUSIC);
            onCopyrightedMusicDownloadDics.AddOrUpdate(seq, callback, (key, old_value) => callback);
        }

        public override ulong GetDuration(string resourceID)
        {
            string log = string.Format("GetDuration, resourceID:{0}, result:{1}", resourceID, 0);
            ZegoPrivateLog(0, log, true, ZEGO_EXPRESS_MODULE_COPYRIGHTEDMUSIC);
            return IExpressCopyrightedMusic.zego_express_copyrighted_music_get_duration(resourceID);
        }

        public void ClearAllAfterDestroy()
        {
            onCopyrightedMusicSendExtendedRequestDics.Clear();
            onCopyrightedMusicGetLrcLyricDics.Clear();
            onCopyrightedMusicGetKrcLyricByTokenDics.Clear();
            onCopyrightedMusicRequestSongDics.Clear();
            onCopyrightedMusicRequestAccompanimentDics.Clear();
            onCopyrightedMusicGetMusicByTokenDics.Clear();
            onCopyrightedMusicDownloadDics.Clear();
        }
    }
}
