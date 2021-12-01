using System;
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
         * Restrictions: The real user information must be passed in, otherwise the song resources cannot be obtained for playback.
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
         * When to call: After initializing the copyrighted music [createCopyrightedMusic].
         *
         * @param command request command, see details for specific supported commands.
         * @param param request parameters, each request command has corresponding request parameters, see details.
         * @param callback send extended feature request result
         */
        public abstract void SendExtendedRequest(string command, string param, OnCopyrightedMusicSendExtendedRequest callback);

        /**
         * Get lyrics in lrc format.
         *
         * Available since: 2.13.0
         * Description: Get lyrics in lrc format, support parsing lyrics line by line.
         * Use case: Used to display lyrics line by line.
         * When to call: After initializing the copyrighted music [createCopyrightedMusic].
         *
         * @param songID the ID of the song or accompaniment, the song and accompaniment of a song share the same ID.
         * @param callback get lyrics result
         */
        public abstract void GetLrcLyric(string songID, OnCopyrightedMusicGetLrcLyric callback);

        /**
         * Get lyrics in krc format.
         *
         * Available since: 2.13.0
         * Description: Get lyrics in krc format, support parsing lyrics word by word.
         * Use case: Used to display lyrics word by word.
         * When to call: After initializing the copyrighted music [createCopyrightedMusic].
         *
         * @param krcToken The krcToken obtained by calling requestAccompaniment.
         * @param callback get lyrics result.
         */
        public abstract void GetKrcLyricByToken(string krcToken, OnCopyrightedMusicGetKrcLyricByToken callback);

        /**
         * Request a song.
         *
         * Available since: 2.13.0
         * Description: Support three ways to request a song, pay-per-use, monthly billing by user, and monthly billing by room.
         * Use case: Get copyrighted songs for local playback and sharing.
         * When to call: After initializing the copyrighted music [createCopyrightedMusic].
         * Restrictions: This interface will trigger billing. A song may have three sound qualities: normal, high-definition, and lossless. Each sound quality has a different resource file, and each resource file has a unique resource ID.
         *
         * @param config request configuration.
         * @param callback request a song result
         */
        public abstract void RequestSong(ZegoCopyrightedMusicRequestConfig config, OnCopyrightedMusicRequestSong callback);

        /**
         * Request accompaniment.
         *
         * Available since: 2.13.0
         * Description: Support three ways to request accompaniment, pay-per-use, monthly billing by user, and monthly billing by room.
         * Use case: Get copyrighted accompaniment for local playback and sharing.
         * When to call: After initializing the copyrighted music [createCopyrightedMusic].
         * Restrictions: This interface will trigger billing.
         *
         * @param config request configuration.
         * @param callback request accompaniment result.
         */
        public abstract void RequestAccompaniment(ZegoCopyrightedMusicRequestConfig config, OnCopyrightedMusicRequestAccompaniment callback);

        /**
         * Get a song or accompaniment.
         *
         * Available since: 2.13.0
         * Description: Obtain a corresponding song or accompaniment through a song or accompaniment token shared by others.
         * Use case: In the online KTV scene, after receiving the song or accompaniment token shared by the lead singer, the chorus obtains the corresponding song or accompaniment through this interface, and then plays it on the local end.
         * When to call: After initializing the copyrighted music [createCopyrightedMusic].
         *
         * @param shareToken access the corresponding authorization token for a song or accompaniment.
         * @param callback get a song or accompaniment result.
         */
        public abstract void GetMusicByToken(string shareToken, OnCopyrightedMusicGetMusicByToken callback);

        /**
         * Download song or accompaniment.
         *
         * Available since: 2.13.0
         * Description: Download a song or accompaniment. It can only be played after downloading successfully.
         * Use case: Get copyrighted accompaniment for local playback and sharing.
         * When to call: After initializing the copyrighted music [createCopyrightedMusic].
         * Restrictions: Loading songs or accompaniment resources is affected by the network.
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
         * When to call: After initializing the copyrighted music [createCopyrightedMusic].
         *
         * @param resourceID the resource ID corresponding to the song or accompaniment.
         */
        public abstract ulong GetDuration(string resourceID);


    }

}
