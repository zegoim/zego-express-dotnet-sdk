using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Collections.Concurrent;
using System.Runtime.InteropServices;
using static ZEGO.ZegoExpressEngineImpl;
using static ZEGO.ZegoImplCallChangeUtil;
using static ZEGO.ZegoCallBackChangeUtil;
using static ZEGO.ZegoUtil;
using static ZEGO.ZegoConstans;

namespace ZEGO
{
    public class ZegoCopyrightedMusicImpl: ZegoCopyrightedMusic
    {
        private static ConcurrentDictionary<int, OnCopyrightedMusicSendExtendedRequest> onCopyrightedMusicSendExtendedRequestDics = new ConcurrentDictionary<int, OnCopyrightedMusicSendExtendedRequest>();
        private static ConcurrentDictionary<int, OnCopyrightedMusicGetLrcLyric> onCopyrightedMusicGetLrcLyricDics = new ConcurrentDictionary<int, OnCopyrightedMusicGetLrcLyric>();
        private static ConcurrentDictionary<int, OnCopyrightedMusicGetKrcLyricByToken> onCopyrightedMusicGetKrcLyricByTokenDics = new ConcurrentDictionary<int, OnCopyrightedMusicGetKrcLyricByToken>();
        private static ConcurrentDictionary<int, OnCopyrightedMusicRequestSong> onCopyrightedMusicRequestSongDics = new ConcurrentDictionary<int, OnCopyrightedMusicRequestSong>();
        private static ConcurrentDictionary<int, OnCopyrightedMusicRequestAccompaniment> onCopyrightedMusicRequestAccompanimentDics = new ConcurrentDictionary<int, OnCopyrightedMusicRequestAccompaniment>();
        private static ConcurrentDictionary<int, OnCopyrightedMusicGetMusicByToken> onCopyrightedMusicGetMusicByTokenDics = new ConcurrentDictionary<int, OnCopyrightedMusicGetMusicByToken>();
        private static ConcurrentDictionary<int, OnCopyrightedMusicDownload> onCopyrightedMusicDownloadDics = new ConcurrentDictionary<int, OnCopyrightedMusicDownload>();
        private static ConcurrentDictionary<int, OnCopyrightedMusicInit> onCopyrightedMusicInitDics = new ConcurrentDictionary<int, OnCopyrightedMusicInit>();
        public override void InitCopyrightedMusic(ZegoCopyrightedMusicConfig config, OnCopyrightedMusicInit callback)
        {
            zego_copyrighted_music_config music_config = ChangeZegoCopyrightedMusicConfigClassToStruct(config);
            int req = IExpressCopyrightedMusicInternal.zego_express_copyrighted_music_init(music_config);

            string log = string.Format("InitCopyrightedMusic, userID:{0}, userName:{1}, result:{2}", config.user.userID, config.user.userName, 0);
            ZegoPrivateLog(0, log, true, ZEGO_EXPRESS_MODULE_COPYRIGHTEDMUSIC);
            onCopyrightedMusicInitDics.AddOrUpdate(req, callback, (key, old_value)=>callback);
        }

        public override ulong GetCacheSize()
        {
            string log = string.Format("GetCacheSize, result:{0}", 0);
            ZegoPrivateLog(0, log, true, ZEGO_EXPRESS_MODULE_COPYRIGHTEDMUSIC);
            return IExpressCopyrightedMusicInternal.zego_express_copyrighted_music_get_cache_size();
        }

        public override void ClearCache()
        {
            int result = IExpressCopyrightedMusicInternal.zego_express_copyrighted_music_clear_cache();

            string log = string.Format("ClearCache, result:{0}", result);
            ZegoPrivateLog(result, log, true, ZEGO_EXPRESS_MODULE_COPYRIGHTEDMUSIC);
        }

        public override void SendExtendedRequest(string command, string param, OnCopyrightedMusicSendExtendedRequest callback)
        {
            int seq = IExpressCopyrightedMusicInternal.zego_express_copyrighted_music_send_extended_request(command, param);
            string log = string.Format("SendExtendedRequest, result:{0}", 0);
            ZegoPrivateLog(0, log, true, ZEGO_EXPRESS_MODULE_COPYRIGHTEDMUSIC);
            onCopyrightedMusicSendExtendedRequestDics.AddOrUpdate(seq, callback, (key, old_value)=> callback);
        }

        [Obsolete]
        public override void GetLrcLyric(string songID, OnCopyrightedMusicGetLrcLyric callback)
        {
            int seq = IExpressCopyrightedMusicInternal.zego_express_copyrighted_music_get_lrc_lyric(songID);
            string log = string.Format("GetLrcLyric, songID:{0}, result:{1}", songID, 0);
            ZegoPrivateLog(0, log, true, ZEGO_EXPRESS_MODULE_COPYRIGHTEDMUSIC);
            onCopyrightedMusicGetLrcLyricDics?.AddOrUpdate(seq, callback, (key,old_value)=>callback);
        }

        public override void GetLrcLyric(string songID, ZegoCopyrightedMusicVendorID vendorID, OnCopyrightedMusicGetLrcLyric callback)
        {
            int seq = -1;
            int error = IExpressCopyrightedMusicInternal.zego_express_copyrighted_music_get_lrc_lyric_with_vendor(songID, (zego_copyrighted_music_vendor_id)vendorID, ref seq);
            //ZegoUtil.ZegoPrivateLog(result, string.Format("GetLrcLyric, seq:{0}", seq), true, ZegoConstans.ZEGO_EXPRESS_MODULE_COPYRIGHTEDMUSIC);
            if (error != 0)
            {
                callback?.Invoke(error, "");
            }
            else
            {
                if (callback != null)
                {
                    onCopyrightedMusicGetLrcLyricDics?.AddOrUpdate(seq, callback, (key, old_value) => callback);
                }
            }
        }

        public override void GetKrcLyricByToken(string krcToken, OnCopyrightedMusicGetKrcLyricByToken callback)
        {
            int seq = IExpressCopyrightedMusicInternal.zego_express_copyrighted_music_get_krc_lyric_by_token(krcToken);
            string log = string.Format("GetKrcLyricByToken, krcToken:{0}, result:{1}", krcToken, 0);
            ZegoPrivateLog(0, log, true, ZEGO_EXPRESS_MODULE_COPYRIGHTEDMUSIC);
            onCopyrightedMusicGetKrcLyricByTokenDics.AddOrUpdate(seq, callback, (key, old_value) => callback);
        }

        public override void RequestSong(ZegoCopyrightedMusicRequestConfig config, OnCopyrightedMusicRequestSong callback)
        {
            zego_copyrighted_music_request_config request_config = ChangeZegoCopyrightedMusicRequestConfigClassToStruct(config);
            int seq = IExpressCopyrightedMusicInternal.zego_express_copyrighted_music_request_song(request_config);
            string log = string.Format("RequestSong, songID:{0},mode:{1}, result:{1}", config.songID, config.mode, 0);
            ZegoPrivateLog(0, log, true, ZEGO_EXPRESS_MODULE_COPYRIGHTEDMUSIC);
            onCopyrightedMusicRequestSongDics.AddOrUpdate(seq, callback, (key, old_value) => callback);
        }

        public override void RequestAccompaniment(ZegoCopyrightedMusicRequestConfig config, OnCopyrightedMusicRequestAccompaniment callback)
        {
            zego_copyrighted_music_request_config request_config = ChangeZegoCopyrightedMusicRequestConfigClassToStruct(config);
            int seq = IExpressCopyrightedMusicInternal.zego_express_copyrighted_music_request_accompaniment(request_config);
            string log = string.Format("RequestAccompaniment, songID:{0},mode:{1}, result:{1}", config.songID, config.mode, 0);
            ZegoPrivateLog(0, log, true, ZEGO_EXPRESS_MODULE_COPYRIGHTEDMUSIC);
            onCopyrightedMusicRequestAccompanimentDics.AddOrUpdate(seq, callback, (key, old_value) => callback);
        }

        public override void GetMusicByToken(string shareToken, OnCopyrightedMusicGetMusicByToken callback)
        {
            int seq = IExpressCopyrightedMusicInternal.zego_express_copyrighted_music_get_music_by_token(shareToken);
            string log = string.Format("GetMusicByToken, shareToken:{0},result:{1}", shareToken, 0);
            ZegoPrivateLog(0, log, true, ZEGO_EXPRESS_MODULE_COPYRIGHTEDMUSIC);
            onCopyrightedMusicGetMusicByTokenDics.AddOrUpdate(seq, callback, (key, old_value) => callback);
        }

        public override void Download(string resourceID, OnCopyrightedMusicDownload callback)
        {
            int seq = IExpressCopyrightedMusicInternal.zego_express_copyrighted_music_download(resourceID);
            string log = string.Format("Download, resourceID:{0},result:{1}", resourceID, 0);
            ZegoPrivateLog(0, log, true, ZEGO_EXPRESS_MODULE_COPYRIGHTEDMUSIC);
            onCopyrightedMusicDownloadDics.AddOrUpdate(seq, callback, (key, old_value) => callback);
        }

        public override ulong GetDuration(string resourceID)
        {
            string log = string.Format("GetDuration, resourceID:{0}, result:{1}", resourceID, 0);
            ZegoPrivateLog(0, log, true, ZEGO_EXPRESS_MODULE_COPYRIGHTEDMUSIC);
            return IExpressCopyrightedMusicInternal.zego_express_copyrighted_music_get_duration(resourceID);
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
            onCopyrightedMusicInitDics.Clear();
        }

        public static void zego_on_copyrighted_music_send_extended_request(int seq, int error_code, [In()][MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8StringMarshaler))] string command, [In()][MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8StringMarshaler))] string result, IntPtr user_context)
        {
            if (onCopyrightedMusicSendExtendedRequestDics == null) return;

            string log = string.Format("onCopyrightedMusicSendExtendedRequest, seq:{0}  error_code:{1} result{2}", seq, error_code, result);
            ZegoUtil.ZegoPrivateLog(error_code, log, true, ZEGO_EXPRESS_MODULE_COPYRIGHTEDMUSIC);
            var onCopyrightedMusicSendExtendedRequest = GetCallbackFromSeq(onCopyrightedMusicSendExtendedRequestDics, seq);
            if (onCopyrightedMusicSendExtendedRequest == null)
            {
                return;
            }

            context?.Post(new SendOrPostCallback((o) =>
            {
                onCopyrightedMusicSendExtendedRequest?.Invoke(error_code, command, result);
                onCopyrightedMusicSendExtendedRequestDics?.TryRemove(seq, out _);
            }), null);
        }

        public static void zego_on_copyrighted_music_init(int seq, int error_code, IntPtr user_context)
        {
            if (onCopyrightedMusicInitDics == null) return;

            string log = string.Format("onCopyrightedMusicInit, seq:{0}  error_code:{1} ", seq, error_code);
            ZegoUtil.ZegoPrivateLog(error_code, log, true, ZEGO_EXPRESS_MODULE_COPYRIGHTEDMUSIC);
            var onCopyrightedMusicInit = GetCallbackFromSeq(onCopyrightedMusicInitDics, seq);
            if (onCopyrightedMusicInit == null)
            {
                return;
            }

            context?.Post(new SendOrPostCallback((o) =>
            {
                onCopyrightedMusicInit?.Invoke(error_code, user_context);
                onCopyrightedMusicInitDics?.TryRemove(seq, out _);
            }), null);
        }

        public static void zego_on_copyrighted_music_request_accompaniment(int seq, int error_code, [In()][MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8StringMarshaler))] string resource, IntPtr user_context)
        {
            if (onCopyrightedMusicRequestAccompanimentDics == null) return;

            string log = string.Format("onCopyrightedMusicRequestAccompaniment, seq:{0}  error_code:{1} ", seq, error_code);
            ZegoUtil.ZegoPrivateLog(error_code, log, true, ZEGO_EXPRESS_MODULE_COPYRIGHTEDMUSIC);
            var onCopyrightedMusicRequestAccompaniment = GetCallbackFromSeq(onCopyrightedMusicRequestAccompanimentDics, seq);
            if (onCopyrightedMusicRequestAccompaniment == null)
            {
                return;
            }

            context?.Post(new SendOrPostCallback((o) =>
            {
                onCopyrightedMusicRequestAccompaniment?.Invoke(error_code, resource);
                onCopyrightedMusicRequestAccompanimentDics?.TryRemove(seq, out _);
            }), null);
        }

        public static void zego_on_copyrighted_music_request_song(int seq, int error_code, [In()][MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8StringMarshaler))] string resource, IntPtr user_context)
        {
            if (onCopyrightedMusicRequestSongDics == null) return;

            string log = string.Format("onCopyrightedMusicRequestSong, seq:{0}  error_code:{1} ", seq, error_code);
            ZegoPrivateLog(error_code, log, true, ZEGO_EXPRESS_MODULE_COPYRIGHTEDMUSIC);
            var callback = GetCallbackFromSeq(onCopyrightedMusicRequestSongDics, seq);
            if (callback == null)
            {
                return;
            }

            context?.Post(new SendOrPostCallback((o) =>
            {
                callback?.Invoke(error_code, resource);
                onCopyrightedMusicRequestAccompanimentDics?.TryRemove(seq, out _);
            }), null);
        }

        public static void zego_on_copyrighted_music_get_lrc_lyric(int seq, int error_code, [In()][MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8StringMarshaler))] string lyrics, IntPtr user_context)
        {
            if (onCopyrightedMusicGetLrcLyricDics == null) return;

            string log = string.Format("onCopyrightedMusicGetLrcLyric, seq:{0}  error_code:{1} ", seq, error_code);
            ZegoPrivateLog(error_code, log, true, ZEGO_EXPRESS_MODULE_COPYRIGHTEDMUSIC);
            var callback = GetCallbackFromSeq(onCopyrightedMusicGetLrcLyricDics, seq);
            if (callback == null)
            {
                return;
            }

            context?.Post(new SendOrPostCallback((o) =>
            {
                callback?.Invoke(error_code, lyrics);
                onCopyrightedMusicGetLrcLyricDics?.TryRemove(seq, out _);
            }), null);
        }

        public static void zego_on_copyrighted_music_get_krc_lyric_by_token(int seq, int error_code, [In()][MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8StringMarshaler))] string lyrics, IntPtr user_context)
        {
            if (onCopyrightedMusicGetKrcLyricByTokenDics == null) return;

            string log = string.Format("onCopyrightedMusicGetKrcLyricByToken, seq:{0}  error_code:{1} ", seq, error_code);
            ZegoPrivateLog(error_code, log, true, ZEGO_EXPRESS_MODULE_COPYRIGHTEDMUSIC);
            var callback = GetCallbackFromSeq(onCopyrightedMusicGetKrcLyricByTokenDics, seq);
            if (callback == null)
            {
                return;
            }

            context?.Post(new SendOrPostCallback((o) =>
            {
                callback?.Invoke(error_code, lyrics);
                onCopyrightedMusicGetKrcLyricByTokenDics?.TryRemove(seq, out _);
            }), null);
        }

        public static void zego_on_copyrighted_music_download(int seq, int error_code, IntPtr user_context)
        {
            if (onCopyrightedMusicDownloadDics == null) return;

            //string log = string.Format("onCopyrightedMusicDownload, seq:{0}  error_code:{1} ", seq, error_code);
            //ZegoPrivateLog(error_code, log, true, ZEGO_EXPRESS_MODULE_COPYRIGHTEDMUSIC);
            var callback = GetCallbackFromSeq(onCopyrightedMusicDownloadDics, seq);
            if (callback == null)
            {
                return;
            }

            context?.Post(new SendOrPostCallback((o) =>
            {
                callback?.Invoke(error_code);
                onCopyrightedMusicDownloadDics?.TryRemove(seq, out _);
            }), null);
        }

        public static void zego_on_copyrighted_music_download_progress_update(int seq, [In()][MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8StringMarshaler))] string resource_id, float progress_rate, IntPtr user_context)
        {
            if (enginePtr == null || enginePtr.onCopyrightedMusicDownloadProgressUpdate == null) return;
            //string log = string.Format("zego_on_remote_mic_state_update  stream_id:{0} state:{1}", stream_id, state);
            //ZegoUtil.ZegoPrivateLog(0, log, false, 0);
            context?.Post(new SendOrPostCallback((o) =>
            {
                enginePtr?.onCopyrightedMusicDownloadProgressUpdate?.Invoke(copyrighted_music_instance, resource_id, progress_rate);

            }), null);
        }

        public static void zego_on_copyrighted_music_get_music_by_token(int seq, int error_code, [In()][MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8StringMarshaler))] string resource, IntPtr user_context)
        {
            if (onCopyrightedMusicGetMusicByTokenDics == null) return;

            //string log = string.Format("onCopyrightedMusicDownload, seq:{0}  error_code:{1} ", seq, error_code);
            //ZegoPrivateLog(error_code, log, true, ZEGO_EXPRESS_MODULE_COPYRIGHTEDMUSIC);
            var callback = GetCallbackFromSeq(onCopyrightedMusicGetMusicByTokenDics, seq);
            if (callback == null)
            {
                return;
            }

            context?.Post(new SendOrPostCallback((o) =>
            {
                callback?.Invoke(error_code, resource);
                onCopyrightedMusicGetMusicByTokenDics?.TryRemove(seq, out _);
            }), null);
        }
    }
}
