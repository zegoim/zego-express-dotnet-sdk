using System;
using static ZEGO.IZegoCopyrightedMusicHandler;

namespace ZEGO
{

    public abstract class ZegoCopyrightedMusic
    {
        /**
         * Initialize the copyrighted music module.
         *
         * Available since: 2.13.0
         * Description: Initialize the copyrighted music so that you can use the function of the copyrighted music later.
         * When to call: After initializing the copyrighted music [createCopyrightedMusic].
         * Caution: 1. The real user information must be passed in, otherwise the song resources cannot be obtained for playback. 2. The user ID set when initializing copyrighted music needs to be the same as the user ID set when logging in to the room.
         *
         * @param config the copyrighted music configuration.
         * @param callback init result
         */
        public abstract void InitCopyrightedMusic(ZegoCopyrightedMusicConfig config, OnCopyrightedMusicInit callback);

        /**
         * Get cache size.
         *
         * Available since: 2.13.0
         * Description: When using this module, some cache files may be generated, and the size of the cache file can be obtained through this interface.
         * Use case: Used to display the cache size of the App.
         * When to call: After initializing the copyrighted music [createCopyrightedMusic].
         *
         * @return cache file size, in byte.
         */
        public abstract ulong GetCacheSize();

        /**
         * Clear cache.
         *
         * Available since: 2.13.0
         * Description: When using this module, some cache files may be generated, which can be cleared through this interface.
         * Use case: Used to clear the cache of the App.
         * When to call: After initializing the copyrighted music [createCopyrightedMusic].
         */
        public abstract void ClearCache();

        /**
         * Send extended feature request.
         *
         * Available since: 2.13.0
         * Description: Initialize the copyrighted music so that you can use the function of the copyrighted music later.
         * Use case: Used to get a list of songs.
         * When to call: After initializing the copyrighted music success [initCopyrightedMusic].
         *
         * @param command request command, details about the commands supported.
         * @param param request parameters, each request command has corresponding request parameters.
         * @param callback send extended feature request result
         */
        public abstract void SendExtendedRequest(string command, string param, OnCopyrightedMusicSendExtendedRequest callback);

        /**
         * Get lyrics in lrc format.
         *
         * Available since: 3.2.1
         * Description: Get lyrics in lrc format, support parsing lyrics line by line.
         * Use case: Used to display lyrics line by line.
         * When to call: After initializing the copyrighted music success [initCopyrightedMusic].
         *
         * @param songID the ID of the song or accompaniment, the song and accompaniment of a song share the same ID.
         * @param vendorID Copyright music resource song copyright provider.
         * @param callback get lyrics result
         */
        public abstract void GetLrcLyric(string songID, ZegoCopyrightedMusicVendorID vendorID, OnCopyrightedMusicGetLrcLyric callback);

        /**
         * Get lyrics in krc format.
         *
         * Available since: 2.13.0
         * Description: Get lyrics in krc format, support parsing lyrics word by word.
         * Use case: Used to display lyrics word by word.
         * When to call: After initializing the copyrighted music success [initCopyrightedMusic].
         *
         * @param krcToken The krcToken obtained by calling requestAccompaniment.
         * @param callback get lyrics result.
         */
        public abstract void GetKrcLyricByToken(string krcToken, OnCopyrightedMusicGetKrcLyricByToken callback);

        /**
         * Download song or accompaniment.
         *
         * Available since: 2.13.0
         * Description: Download a song or accompaniment. It can only be played after downloading successfully.
         * Use case: Get copyrighted accompaniment for local playback and sharing.
         * When to call: After initializing the copyrighted music success [initCopyrightedMusic].
         * Caution: Loading songs or accompaniment resources is affected by the network.
         *
         * @param resourceID the resource ID corresponding to the song or accompaniment.
         * @param callback download song or accompaniment result.
         */
        public abstract void Download(string resourceID, OnCopyrightedMusicDownload callback);

        /**
         * Get the playing time of a song or accompaniment file.
         *
         * Available since: 2.13.0
         * Description: Get the playing time of a song or accompaniment file.
         * Use case: Can be used to display the playing time information of the song or accompaniment on the view.
         * When to call: After initializing the copyrighted music success [initCopyrightedMusic].
         *
         * @param resourceID the resource ID corresponding to the song or accompaniment.
         */
        public abstract ulong GetDuration(string resourceID);

        public OnDownloadProgressUpdate onDownloadProgressUpdate;

        /**
         * [Deprecated] Request a song. Deprecated since 3.0.2, please use the [requestResource] function instead.
         *
         * Available since: 2.13.0
         * Description: By requesting a song, you can not only obtain basic information about a song (such as duration, song name, and artist), but also obtain the resource ID for local playback, share_token for sharing with others, and related authentication information. Support by the time, by the user monthly, by the room monthly subscription three ways.
         * Use case: Get copyrighted songs for local playback and sharing.
         * When to call: After initializing the copyrighted music success [initCopyrightedMusic].
         * Caution: This interface will trigger billing. A song may have three sound qualities: normal, high-definition, and lossless. Each sound quality has a different resource file, and each resource file has a unique resource ID.
         *
         * @deprecated Deprecated since 3.0.2, please use the [requestResource] function instead.
         * @param config request configuration.
         * @param callback request a song result
         */
        [Obsolete("Deprecated since 3.0.2, please use the [requestResource] function instead.",false)]
        public abstract void RequestSong(ZegoCopyrightedMusicRequestConfig config, OnCopyrightedMusicRequestSong callback);

        /**
         * [Deprecated] Request accompaniment. Deprecated since 3.0.2, please use the [requestResource] function instead.
         *
         * Available since: 2.13.0
         * Description: You can get the accompaniment resources of the song corresponding to the songID, including resource_id, krc_token, share_token, etc. Supports click-by-point accompaniment.
         * Use case: Get copyrighted accompaniment for local playback and sharing.
         * When to call: After initializing the copyrighted music success [initCopyrightedMusic].
         * Caution: This interface will trigger billing.
         *
         * @deprecated Deprecated since 3.0.2, please use the [requestResource] function instead.
         * @param config request configuration.
         * @param callback request accompaniment result.
         */
        [Obsolete("Deprecated since 3.0.2, please use the [requestResource] function instead.",false)]
        public abstract void RequestAccompaniment(ZegoCopyrightedMusicRequestConfig config, OnCopyrightedMusicRequestAccompaniment callback);

        /**
         * [Deprecated] Get a song or accompaniment. Deprecated since 3.0.2, please use the [getSharedResource] function instead.
         *
         * Available since: 2.13.0
         * Description: After the user successfully obtains the song/accompaniment/accompaniment clip resource, he can get the corresponding shareToken, share the shareToken with other users, and other users call this interface to obtain the shared music resources.
         * Use case: In the online KTV scene, after receiving the song or accompaniment token shared by the lead singer, the chorus obtains the corresponding song or accompaniment through this interface, and then plays it on the local end.
         * When to call: After initializing the copyrighted music success [initCopyrightedMusic].
         *
         * @deprecated Deprecated since 3.0.2, please use the [getSharedResource] function instead.
         * @param shareToken access the corresponding authorization token for a song or accompaniment.
         * @param callback get a song or accompaniment result.
         */
        [Obsolete("Deprecated since 3.0.2, please use the [getSharedResource] function instead.",false)]
        public abstract void GetMusicByToken(string shareToken, OnCopyrightedMusicGetMusicByToken callback);

        /**
         * [Deprecated] Get lyrics in lrc format. Deprecated since 3.2.1, please use the method with the same name with [vendorID] parameter instead.
         *
         * Available since: 2.13.0
         * Description: Get lyrics in lrc format, support parsing lyrics line by line.
         * Use case: Used to display lyrics line by line.
         * When to call: After initializing the copyrighted music success [initCopyrightedMusic].
         *
         * @deprecated Deprecated since 2.14.0, please use the method with the same name with [vendorID] parameter instead.
         * @param songID the ID of the song or accompaniment, the song and accompaniment of a song share the same ID.
         * @param callback get lyrics result
         */
        [Obsolete("Deprecated since 2.14.0, please use the method with the same name with [vendorID] parameter instead.",false)]
        public abstract void GetLrcLyric(string songID, OnCopyrightedMusicGetLrcLyric callback);


    }

}
