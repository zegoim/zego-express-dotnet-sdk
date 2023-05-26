using System;
namespace ZEGO
{

    public class IZegoCopyrightedMusicHandler
    {
        /**
         * Callback for download song or accompaniment progress rate.
         *
         * @param copyrightedMusic Copyrighted music instance that triggers this callback.
         * @param resourceID The resource ID of the song or accompaniment that triggered this callback.
         * @param progressRate download progress rate.
         */
        public delegate void OnDownloadProgressUpdate(ZegoCopyrightedMusic copyrightedMusic, string resourceID, float progressRate);


    }
    /**
     * Callback for copyrighted music init.
     *
     * @param errorCode Error code, please refer to the error codes document https://docs.zegocloud.com/en/5548.html for details.
     */
    public delegate void OnCopyrightedMusicInit(int errorCode);

    /**
     * Callback of sending extended feature request.
     *
     * @param errorCode Error code, please refer to the error codes document https://docs.zegocloud.com/en/5548.html for details.
     * @param command request command.
     * @param result request result, each request command has corresponding request result.
     */
    public delegate void OnCopyrightedMusicSendExtendedRequest(int errorCode, string command, string result);

    /**
     * Get lrc format lyrics complete callback.
     *
     * @param errorCode Error code, please refer to the error codes document https://docs.zegocloud.com/en/5548.html for details.
     * @param lyrics lrc format lyrics.
     */
    public delegate void OnCopyrightedMusicGetLrcLyric(int errorCode, string lyrics);

    /**
     * Get krc format lyrics complete callback.
     *
     * @param errorCode Error code, please refer to the error codes document https://docs.zegocloud.com/en/5548.html for details.
     * @param lyrics krc format lyrics.
     */
    public delegate void OnCopyrightedMusicGetKrcLyricByToken(int errorCode, string lyrics);

    /**
     * Callback for request song.
     *
     * @param errorCode Error code, please refer to the error codes document https://docs.zegocloud.com/en/5548.html for details.
     * @param resource The JSON string returned by the song ordering service, including song resource information.
     */
    public delegate void OnCopyrightedMusicRequestSong(int errorCode, string resource);

    /**
     * Callback for request accompaniment.
     *
     * @param errorCode Error code, please refer to the error codes document https://docs.zegocloud.com/en/5548.html for details.
     * @param resource accompany resource information.
     */
    public delegate void OnCopyrightedMusicRequestAccompaniment(int errorCode, string resource);

    /**
     * Callback for request accompaniment clip.
     *
     * @param errorCode Error code, please refer to the error codes document https://docs.zegocloud.com/en/5548.html for details.
     * @param resource accompany clip resource information.
     */
    public delegate void OnCopyrightedMusicRequestAccompanimentClip(int errorCode, string resource);

    /**
     * Callback for acquire songs or accompaniment through authorization token.
     *
     * @param errorCode Error code, please refer to the error codes document https://docs.zegocloud.com/en/5548.html for details.
     * @param resource song or accompany resource information.
     */
    public delegate void OnCopyrightedMusicGetMusicByToken(int errorCode, string resource);

    /**
     * Callback of requesting music resource.
     *
     * @param errorCode Error code, please refer to the error codes document https://docs.zegocloud.com/en/5548.html for details.
     * @param resource The JSON string returned by the song ordering service, including music resource information.
     */
    public delegate void OnCopyrightedMusicRequestResource(int errorCode, string resource);

    /**
     * Callback of getting shared music resource.
     *
     * @param errorCode Error code, please refer to the error codes document https://docs.zegocloud.com/en/5548.html for details.
     * @param resource The JSON string returned by the song ordering service, including music resource information.
     */
    public delegate void OnCopyrightedMusicGetSharedResource(int errorCode, string resource);

    /**
     * Callback for download song or accompaniment.
     *
     * @param errorCode Error code, please refer to the error codes document https://docs.zegocloud.com/en/5548.html for details.
     */
    public delegate void OnCopyrightedMusicDownload(int errorCode);


}
