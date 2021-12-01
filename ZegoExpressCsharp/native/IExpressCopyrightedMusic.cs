using System;
using System.Runtime.InteropServices;
using static ZEGO.ZegoConstans;
using static ZEGO.ZegoUtil;

namespace ZEGO
{
    class IExpressCopyrightedMusic
    {
        /**
         * Creates a copyrighted music instance.
         *
         * Available since: 2.13.0
         * Description: Creates a copyrighted music instance.
         * Use case: Often used in online KTV chorus scenarios, users can use related functions by creating copyrighted music instance objects.
         * When to call: It can be called after the engine by [createEngine] has been initialized.
         * Restrictions: The SDK only supports the creation of one instance of CopyrightedMusic. Multiple calls to this function return the same object.
         *
         * @return copyrighted music instance, multiple calls to this function return the same object.
         */
        [DllImport(LIB_NAME, EntryPoint = "zego_express_create_copyrighted_music", CallingConvention = ZEGO_CALLINGCONVENTION)]
        public static extern void zego_express_create_copyrighted_music();


        /**
         * Destroys a copyrighted music instance.
         *
         * Available since: 2.13.0
         * Description: Destroys a copyrighted music instance.
         */
        [DllImport(ZegoConstans.LIB_NAME, EntryPoint = "zego_express_destroy_copyrighted_music", CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
        public static extern int zego_express_destroy_copyrighted_music();


        /**
         * Initialize the copyrighted music module.
         *
         * Available since: 2.13.0
         * Description: Initialize the copyrighted music so that you can use the function of the copyrighted music later.
         * When to call: After initializing the copyrighted music [createCopyrightedMusic].
         * Restrictions: The real user information must be passed in, otherwise the song resources cannot be obtained for playback.
         *
         * @param config the copyrighted music configuration.
         */
        [DllImport(ZegoConstans.LIB_NAME, EntryPoint = "zego_express_copyrighted_music_init", CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
        public static extern int zego_express_copyrighted_music_init(zego_copyrighted_music_config config);


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
        [DllImport(ZegoConstans.LIB_NAME, EntryPoint = "zego_express_copyrighted_music_get_cache_size", CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
        public static extern ulong zego_express_copyrighted_music_get_cache_size();


        /**
         * Clear cache.
         *
         * Available since: 2.13.0
         * Description: When using this module, some cache files may be generated, which can be cleared through this interface.
         * Use case: Used to clear the cache of the App.
         * When to call: After initializing the copyrighted music [createCopyrightedMusic].
         */
        [DllImport(ZegoConstans.LIB_NAME, EntryPoint = "zego_express_copyrighted_music_clear_cache", CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
        public static extern int zego_express_copyrighted_music_clear_cache();


        /**
         * Send extended feature request.
         *
         * Available since: 2.13.0
         * Description: Initialize the copyrighted music so that you can use the function of the copyrighted music later.
         * Use case: Used to get a list of songs.
         * When to call: After initializing the copyrighted music [createCopyrightedMusic].
         *
         * @param command request command, see details for specific supported commands.
         * @param params request parameters, each request command has corresponding request parameters, see details.
         */
        [DllImport(ZegoConstans.LIB_NAME, EntryPoint = "zego_express_copyrighted_music_send_extended_request", CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
        public static extern int zego_express_copyrighted_music_send_extended_request([In()][MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(ZegoUtil.UTF8StringMarshaler))] string command, [In()][MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(ZegoUtil.UTF8StringMarshaler))] string param);


        /**
         * Get lyrics in lrc format.
         *
         * Available since: 2.13.0
         * Description: Get lyrics in lrc format, support parsing lyrics line by line.
         * Use case: Used to display lyrics line by line.
         * When to call: After initializing the copyrighted music [createCopyrightedMusic].
         *
         * @param song_id the ID of the song or accompaniment, the song and accompaniment of a song share the same ID.
         */
        [DllImport(ZegoConstans.LIB_NAME, EntryPoint = "zego_express_copyrighted_music_get_lrc_lyric", CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
        public static extern int zego_express_copyrighted_music_get_lrc_lyric([In()][MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(ZegoUtil.UTF8StringMarshaler))] string song_id);


        /**
         * Get lyrics in krc format.
         *
         * Available since: 2.13.0
         * Description: Get lyrics in krc format, support parsing lyrics word by word.
         * Use case: Used to display lyrics word by word.
         * When to call: After initializing the copyrighted music [createCopyrightedMusic].
         *
         * @param krc_token The krcToken obtained by calling requestAccompaniment.
         */
        [DllImport(ZegoConstans.LIB_NAME, EntryPoint = "zego_express_copyrighted_music_get_krc_lyric_by_token", CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
        public static extern int zego_express_copyrighted_music_get_krc_lyric_by_token([In()][MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(ZegoUtil.UTF8StringMarshaler))] string song_id);


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
         */
        [DllImport(ZegoConstans.LIB_NAME, EntryPoint = "zego_express_copyrighted_music_request_song", CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
        public static extern int zego_express_copyrighted_music_request_song(zego_copyrighted_music_request_config config);


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
         */
        [DllImport(ZegoConstans.LIB_NAME, EntryPoint = "zego_express_copyrighted_music_request_accompaniment", CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
        public static extern int zego_express_copyrighted_music_request_accompaniment(zego_copyrighted_music_request_config config);


        /**
         * Get a song or accompaniment.
         *
         * Available since: 2.13.0
         * Description: Obtain a corresponding song or accompaniment through a song or accompaniment token shared by others.
         * Use case: In the online KTV scene, after receiving the song or accompaniment token shared by the lead singer, the chorus obtains the corresponding song or accompaniment through this interface, and then plays it on the local end.
         * When to call: After initializing the copyrighted music [createCopyrightedMusic].
         *
         * @param share_token access the corresponding authorization token for a song or accompaniment.
         */
        [DllImport(ZegoConstans.LIB_NAME, EntryPoint = "zego_express_copyrighted_music_get_music_by_token", CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
        public static extern int zego_express_copyrighted_music_get_music_by_token([In()][MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(ZegoUtil.UTF8StringMarshaler))] string share_token);


        /**
         * Download song or accompaniment.
         *
         * Available since: 2.13.0
         * Description: Download a song or accompaniment. It can only be played after downloading successfully.
         * Use case: Get copyrighted accompaniment for local playback and sharing.
         * When to call: After initializing the copyrighted music [createCopyrightedMusic].
         * Restrictions: Loading songs or accompaniment resources is affected by the network.
         *
         * @param resource_id the resource ID corresponding to the song or accompaniment.
         */
        [DllImport(ZegoConstans.LIB_NAME, EntryPoint = "zego_express_copyrighted_music_download", CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
        public static extern int zego_express_copyrighted_music_download([In()][MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(ZegoUtil.UTF8StringMarshaler))] string resource_id);


        /**
         * Get the playing time of a song or accompaniment file.
         *
         * Available since: 2.13.0
         * Description: Get the playing time of a song or accompaniment file.
         * Use case: Can be used to display the playing time information of the song or accompaniment on the view.
         * When to call: After initializing the copyrighted music [createCopyrightedMusic].
         *
         * @param resource_id the resource ID corresponding to the song or accompaniment.
         */
        [DllImport(LIB_NAME, EntryPoint = "zego_express_copyrighted_music_download", CallingConvention = ZEGO_CALLINGCONVENTION)]
        public static extern ulong zego_express_copyrighted_music_get_duration([In()][MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8StringMarshaler))] string resource_id);


        /**
         * Callback for download song or accompaniment progress rate.
         *
         * @param seq Sequence.
         * @param resource_id The resource ID of the song or accompaniment that triggered this callback.ZEGOEXP_API zego_seq EXP_CALL 
         * @param progress_rate download progress rate.
         * @param user_context Context of user.
         */
        [UnmanagedFunctionPointer(ZEGO_CALLINGCONVENTION)]
        public delegate void zego_on_copyrighted_music_download_progress_update(int seq, [In()][MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8StringMarshaler))] string resource_id, float progress_rate, IntPtr user_context);

        [DllImport(LIB_NAME, EntryPoint = "zego_register_copyrighted_music_download_progress_update_callback", CallingConvention = ZEGO_CALLINGCONVENTION)]
        public static extern void zego_register_copyrighted_music_download_progress_update_callback(zego_on_copyrighted_music_download_progress_update callback_func, IntPtr user_context);


        /**
         * Callback for copyrighted music init.
         *
         * @param seq Sequence.
         * @param error_code Error code, please refer to the error codes document https://doc-en.zego.im/en/5548.html for details.
         * @param user_context Context of user.
         */
        [UnmanagedFunctionPointer(ZEGO_CALLINGCONVENTION)]
        public delegate void zego_on_copyrighted_music_init(int seq, int error_code, IntPtr user_context);

        [DllImport(LIB_NAME, EntryPoint = "zego_register_copyrighted_music_init_callback", CallingConvention = ZEGO_CALLINGCONVENTION)]
        public static extern void zego_register_copyrighted_music_init_callback(zego_on_copyrighted_music_init callback_func, IntPtr user_context);


        /**
         * Callback for copyrighted music init.
         *
         * @param seq Sequence.
         * @param error_code Error code, please refer to the error codes document https://doc-en.zego.im/en/5548.html for details.
         * @param command request command, see details for specific supported commands.
         * @param result request result, each request command has corresponding request result, see details.
         * @param user_context Context of user.
         */
        [UnmanagedFunctionPointer(ZEGO_CALLINGCONVENTION)]
        public delegate void zego_on_copyrighted_music_send_extended_request(int seq, int error_code, [In()][MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8StringMarshaler))] string command, [In()][MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8StringMarshaler))] string result, IntPtr user_context);

        [DllImport(LIB_NAME, EntryPoint = "zego_register_copyrighted_music_send_extended_request_callback", CallingConvention = ZEGO_CALLINGCONVENTION)]
        public static extern void zego_register_copyrighted_music_send_extended_request_callback(zego_on_copyrighted_music_send_extended_request callback_func, IntPtr user_context);


        /**
         * Get lrc format lyrics complete callback.
         *
         * @param seq Sequence.
         * @param error_code Error code, please refer to the error codes document https://doc-en.zego.im/en/5548.html for details.
         * @param lyrics lrc format lyrics.
         * @param user_context Context of user.
         */
        [UnmanagedFunctionPointer(ZEGO_CALLINGCONVENTION)]
        public delegate void zego_on_copyrighted_music_get_lrc_lyric(int seq, int error_code, [In()][MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8StringMarshaler))] string lyrics, IntPtr user_context);

        [DllImport(LIB_NAME, EntryPoint = "zego_register_copyrighted_music_get_lrc_lyric_callback", CallingConvention = ZEGO_CALLINGCONVENTION)]
        public static extern void zego_register_copyrighted_music_get_lrc_lyric_callback(zego_on_copyrighted_music_get_lrc_lyric callback_func, IntPtr user_context);


        /**
         * Get krc format lyrics complete callback.
         *
         * @param seq Sequence.
         * @param error_code Error code, please refer to the error codes document https://doc-en.zego.im/en/5548.html for details.
         * @param lyrics krc format lyrics.
         * @param user_context Context of user.
         */
        [UnmanagedFunctionPointer(ZEGO_CALLINGCONVENTION)]
        public delegate void zego_on_copyrighted_music_get_krc_lyric_by_token(int seq, int error_code, [In()][MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8StringMarshaler))] string lyrics, IntPtr user_context);

        [DllImport(LIB_NAME, EntryPoint = "zego_register_copyrighted_music_get_krc_lyric_by_token_callback", CallingConvention = ZEGO_CALLINGCONVENTION)]
        public static extern void zego_register_copyrighted_music_get_krc_lyric_by_token_callback(zego_on_copyrighted_music_get_krc_lyric_by_token callback_func, IntPtr user_context);


        /**
         * Callback for request song.
         *
         * @param seq Sequence.
         * @param error_code Error code, please refer to the error codes document https://doc-en.zego.im/en/5548.html for details.
         * @param resource song resource information.
         * @param user_context Context of user.
         */
        [UnmanagedFunctionPointer(ZEGO_CALLINGCONVENTION)]
        public delegate void zego_on_copyrighted_music_request_song(int seq, int error_code, [In()][MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8StringMarshaler))] string resource, IntPtr user_context);

        [DllImport(LIB_NAME, EntryPoint = "zego_register_copyrighted_music_request_song_callback", CallingConvention = ZEGO_CALLINGCONVENTION)]
        public static extern void zego_register_copyrighted_music_request_song_callback(zego_on_copyrighted_music_request_song callback_func, IntPtr user_context);


        /**
         * Callback for request accompaniment.
         *
         * @param seq Sequence.
         * @param error_code Error code, please refer to the error codes document https://doc-en.zego.im/en/5548.html for details.
         * @param resource accompany resource information.
         * @param user_context Context of user.
         */
        [UnmanagedFunctionPointer(ZEGO_CALLINGCONVENTION)]
        public delegate void zego_on_copyrighted_music_request_accompaniment(int seq, int error_code, [In()][MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8StringMarshaler))] string resource, IntPtr user_context);

        [DllImport(LIB_NAME, EntryPoint = "zego_register_copyrighted_music_request_accompaniment_callback", CallingConvention = ZEGO_CALLINGCONVENTION)]
        public static extern void zego_register_copyrighted_music_request_accompaniment_callback(zego_on_copyrighted_music_request_accompaniment callback_func, IntPtr user_context);


        /**
         * Callback for acquire songs or accompaniment through authorization token.
         *
         * @param seq Sequence.
         * @param error_code Error code, please refer to the error codes document https://doc-en.zego.im/en/5548.html for details.
         * @param resource song or accompany resource information.
         * @param user_context Context of user.
         */
        [UnmanagedFunctionPointer(ZEGO_CALLINGCONVENTION)]
        public delegate void zego_on_copyrighted_music_get_music_by_token(int seq, int error_code, [In()][MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8StringMarshaler))] string resource, IntPtr user_context);

        [DllImport(LIB_NAME, EntryPoint = "zego_register_copyrighted_music_get_music_by_token_callback", CallingConvention = ZEGO_CALLINGCONVENTION)]
        public static extern void zego_register_copyrighted_music_get_music_by_token_callback(zego_on_copyrighted_music_get_music_by_token callback_func, IntPtr user_context);


        /**
         * Callback for download song or accompaniment.
         *
         * @param seq Sequence.
         * @param error_code Error code, please refer to the error codes document https://doc-en.zego.im/en/5548.html for details.
         * @param user_context Context of user.
         */
        [UnmanagedFunctionPointer(ZEGO_CALLINGCONVENTION)]
        public delegate void zego_on_copyrighted_music_download(int seq, int error_code, IntPtr user_context);

        [DllImport(LIB_NAME, EntryPoint = "zego_register_copyrighted_music_download_callback", CallingConvention = ZEGO_CALLINGCONVENTION)]
        public static extern void zego_register_copyrighted_music_download_callback(zego_on_copyrighted_music_download callback_func, IntPtr user_context);
    }
}
