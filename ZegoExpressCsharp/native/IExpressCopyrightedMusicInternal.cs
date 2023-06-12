using System;
using System.Runtime.InteropServices;
using static ZEGO.ZegoConstans;

namespace ZEGO {
public class IExpressCopyrightedMusicInternal {
    [DllImport(ZegoConstans.LIB_NAME, EntryPoint = "zego_express_create_copyrighted_music",
               CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
    public static extern int zego_express_create_copyrighted_music();

    [DllImport(ZegoConstans.LIB_NAME, EntryPoint = "zego_express_destroy_copyrighted_music",
               CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
    public static extern int zego_express_destroy_copyrighted_music();

    [DllImport(ZegoConstans.LIB_NAME, EntryPoint = "zego_express_copyrighted_music_init",
               CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
    public static extern int
    zego_express_copyrighted_music_init(zego_copyrighted_music_config config, ref int seq);

    [DllImport(ZegoConstans.LIB_NAME, EntryPoint = "zego_express_copyrighted_music_get_cache_size",
               CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
    public static extern int zego_express_copyrighted_music_get_cache_size(ref ulong size);

    [DllImport(ZegoConstans.LIB_NAME, EntryPoint = "zego_express_copyrighted_music_clear_cache",
               CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
    public static extern int zego_express_copyrighted_music_clear_cache();

    [DllImport(ZegoConstans.LIB_NAME,
               EntryPoint = "zego_express_copyrighted_music_send_extended_request",
               CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
    public static extern int zego_express_copyrighted_music_send_extended_request(
        [In()][MarshalAs(UnmanagedType.CustomMarshaler,
                         MarshalTypeRef = typeof(ZegoUtil.UTF8StringMarshaler))] string command,
        [In()][MarshalAs(UnmanagedType.CustomMarshaler,
                         MarshalTypeRef = typeof(ZegoUtil.UTF8StringMarshaler))] string param,
        ref int sequence);

    [DllImport(ZegoConstans.LIB_NAME, EntryPoint = "zego_express_copyrighted_music_get_lrc_lyric",
               CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
    public static extern int zego_express_copyrighted_music_get_lrc_lyric(
        [In()][MarshalAs(UnmanagedType.CustomMarshaler,
                         MarshalTypeRef = typeof(ZegoUtil.UTF8StringMarshaler))] string song_id,
        ref int sequence);

    [DllImport(ZegoConstans.LIB_NAME,
               EntryPoint = "zego_express_copyrighted_music_get_krc_lyric_by_token",
               CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
    public static extern int zego_express_copyrighted_music_get_krc_lyric_by_token(
        [In()][MarshalAs(UnmanagedType.CustomMarshaler,
                         MarshalTypeRef = typeof(ZegoUtil.UTF8StringMarshaler))] string krc_token,
        ref int sequence);

    [DllImport(ZegoConstans.LIB_NAME, EntryPoint = "zego_express_copyrighted_music_request_song",
               CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
    public static extern int
    zego_express_copyrighted_music_request_song(zego_copyrighted_music_request_config config,
                                                ref int sequence);

    [DllImport(ZegoConstans.LIB_NAME,
               EntryPoint = "zego_express_copyrighted_music_request_accompaniment",
               CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
    public static extern int zego_express_copyrighted_music_request_accompaniment(
        zego_copyrighted_music_request_config config, ref int sequence);

    [DllImport(ZegoConstans.LIB_NAME,
               EntryPoint = "zego_express_copyrighted_music_request_accompaniment_clip",
               CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
    public static extern int zego_express_copyrighted_music_request_accompaniment_clip(
        zego_copyrighted_music_request_config config, ref int sequence);

    [DllImport(ZegoConstans.LIB_NAME,
               EntryPoint = "zego_express_copyrighted_music_get_music_by_token",
               CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
    public static extern int zego_express_copyrighted_music_get_music_by_token(
        [In()][MarshalAs(UnmanagedType.CustomMarshaler,
                         MarshalTypeRef = typeof(ZegoUtil.UTF8StringMarshaler))] string share_token,
        ref int sequence);

    [DllImport(ZegoConstans.LIB_NAME, EntryPoint = "zego_express_copyrighted_music_download",
               CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
    public static extern int zego_express_copyrighted_music_download(
        [In()][MarshalAs(UnmanagedType.CustomMarshaler,
                         MarshalTypeRef = typeof(ZegoUtil.UTF8StringMarshaler))] string resource_id,
        ref int sequence);

    [DllImport(ZegoConstans.LIB_NAME, EntryPoint = "zego_express_copyrighted_music_query_cache",
               CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
    public static extern int zego_express_copyrighted_music_query_cache(
        [In()][MarshalAs(UnmanagedType.CustomMarshaler,
                         MarshalTypeRef = typeof(ZegoUtil.UTF8StringMarshaler))] string song_id,
        ZegoCopyrightedMusicType type, ref bool cache);

    [DllImport(ZegoConstans.LIB_NAME,
               EntryPoint = "zego_express_copyrighted_music_query_cache_with_vendor",
               CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
    public static extern int zego_express_copyrighted_music_query_cache_with_vendor(
        [In()][MarshalAs(UnmanagedType.CustomMarshaler,
                         MarshalTypeRef = typeof(ZegoUtil.UTF8StringMarshaler))] string song_id,
        ZegoCopyrightedMusicType type, zego_copyrighted_music_vendor_id vendor_id,
        ref bool is_cache);

    [DllImport(ZegoConstans.LIB_NAME, EntryPoint = "zego_express_copyrighted_music_get_duration",
               CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
    public static extern int zego_express_copyrighted_music_get_duration(
        [In()][MarshalAs(UnmanagedType.CustomMarshaler,
                         MarshalTypeRef = typeof(ZegoUtil.UTF8StringMarshaler))] string resource_id,
        ref ulong duration);

    [DllImport(ZegoConstans.LIB_NAME, EntryPoint = "zego_express_copyrighted_music_start_score",
               CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
    public static extern int zego_express_copyrighted_music_start_score(
        [In()][MarshalAs(UnmanagedType.CustomMarshaler,
                         MarshalTypeRef = typeof(ZegoUtil.UTF8StringMarshaler))] string resource_id,
        int pitch_value_interval);

    [DllImport(ZegoConstans.LIB_NAME, EntryPoint = "zego_express_copyrighted_music_pause_score",
               CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
    public static extern int zego_express_copyrighted_music_pause_score([In()][MarshalAs(
        UnmanagedType.CustomMarshaler,
        MarshalTypeRef = typeof(ZegoUtil.UTF8StringMarshaler))] string resource_id);

    [DllImport(ZegoConstans.LIB_NAME, EntryPoint = "zego_express_copyrighted_music_resume_score",
               CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
    public static extern int zego_express_copyrighted_music_resume_score([In()][MarshalAs(
        UnmanagedType.CustomMarshaler,
        MarshalTypeRef = typeof(ZegoUtil.UTF8StringMarshaler))] string resource_id);

    [DllImport(ZegoConstans.LIB_NAME, EntryPoint = "zego_express_copyrighted_music_stop_score",
               CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
    public static extern int zego_express_copyrighted_music_stop_score([In()][MarshalAs(
        UnmanagedType.CustomMarshaler,
        MarshalTypeRef = typeof(ZegoUtil.UTF8StringMarshaler))] string resource_id);

    [DllImport(ZegoConstans.LIB_NAME, EntryPoint = "zego_express_copyrighted_music_reset_score",
               CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
    public static extern int zego_express_copyrighted_music_reset_score([In()][MarshalAs(
        UnmanagedType.CustomMarshaler,
        MarshalTypeRef = typeof(ZegoUtil.UTF8StringMarshaler))] string resource_id);

    [DllImport(ZegoConstans.LIB_NAME,
               EntryPoint = "zego_express_copyrighted_music_get_previous_score",
               CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
    public static extern int zego_express_copyrighted_music_get_previous_score(
        [In()][MarshalAs(UnmanagedType.CustomMarshaler,
                         MarshalTypeRef = typeof(ZegoUtil.UTF8StringMarshaler))] string resource_id,
        ref int total_score);

    [DllImport(ZegoConstans.LIB_NAME,
               EntryPoint = "zego_express_copyrighted_music_get_average_score",
               CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
    public static extern int zego_express_copyrighted_music_get_average_score(
        [In()][MarshalAs(UnmanagedType.CustomMarshaler,
                         MarshalTypeRef = typeof(ZegoUtil.UTF8StringMarshaler))] string resource_id,
        ref int score);

    [DllImport(ZegoConstans.LIB_NAME, EntryPoint = "zego_express_copyrighted_music_get_total_score",
               CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
    public static extern int zego_express_copyrighted_music_get_total_score(
        [In()][MarshalAs(UnmanagedType.CustomMarshaler,
                         MarshalTypeRef = typeof(ZegoUtil.UTF8StringMarshaler))] string resource_id,
        ref int total_score);

    [DllImport(ZegoConstans.LIB_NAME,
               EntryPoint = "zego_express_copyrighted_music_get_standard_pitch",
               CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
    public static extern int zego_express_copyrighted_music_get_standard_pitch(
        [In()][MarshalAs(UnmanagedType.CustomMarshaler,
                         MarshalTypeRef = typeof(ZegoUtil.UTF8StringMarshaler))] string resource_id,
        ref int sequence);

    [DllImport(ZegoConstans.LIB_NAME,
               EntryPoint = "zego_express_copyrighted_music_get_current_pitch",
               CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
    public static extern int zego_express_copyrighted_music_get_current_pitch(
        [In()][MarshalAs(UnmanagedType.CustomMarshaler,
                         MarshalTypeRef = typeof(ZegoUtil.UTF8StringMarshaler))] string resource_id,
        ref int pitch);

    [UnmanagedFunctionPointer(ZegoConstans.ZEGO_CALLINGCONVENTION)]
    public delegate void zego_on_copyrighted_music_download_progress_update(
        int seq,
        [In()][MarshalAs(UnmanagedType.CustomMarshaler,
                         MarshalTypeRef = typeof(ZegoUtil.UTF8StringMarshaler))] string resource_id,
        float progress_rate, IntPtr user_context);

    [DllImport(ZegoConstans.LIB_NAME,
               EntryPoint = "zego_register_copyrighted_music_download_progress_update_callback",
               CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
    public static extern void zego_register_copyrighted_music_download_progress_update_callback(
        zego_on_copyrighted_music_download_progress_update callback_func, IntPtr user_context);

    [UnmanagedFunctionPointer(ZegoConstans.ZEGO_CALLINGCONVENTION)]
    public delegate void zego_on_copyrighted_music_current_pitch_value_update(
        [In()][MarshalAs(UnmanagedType.CustomMarshaler,
                         MarshalTypeRef = typeof(ZegoUtil.UTF8StringMarshaler))] string resource_id,
        int current_duration, int pitch_value, IntPtr user_context);

    [DllImport(ZegoConstans.LIB_NAME,
               EntryPoint = "zego_register_copyrighted_music_current_pitch_value_update_callback",
               CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
    public static extern void zego_register_copyrighted_music_current_pitch_value_update_callback(
        zego_on_copyrighted_music_current_pitch_value_update callback_func, IntPtr user_context);

    [UnmanagedFunctionPointer(ZegoConstans.ZEGO_CALLINGCONVENTION)]
    public delegate void zego_on_copyrighted_music_init(int seq, int error_code,
                                                        IntPtr user_context);

    [DllImport(ZegoConstans.LIB_NAME, EntryPoint = "zego_register_copyrighted_music_init_callback",
               CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
    public static extern void
    zego_register_copyrighted_music_init_callback(zego_on_copyrighted_music_init callback_func,
                                                  IntPtr user_context);

    [UnmanagedFunctionPointer(ZegoConstans.ZEGO_CALLINGCONVENTION)]
    public delegate void zego_on_copyrighted_music_send_extended_request(
        int seq, int error_code,
        [In()][MarshalAs(UnmanagedType.CustomMarshaler,
                         MarshalTypeRef = typeof(ZegoUtil.UTF8StringMarshaler))] string command,
        [In()][MarshalAs(UnmanagedType.CustomMarshaler,
                         MarshalTypeRef = typeof(ZegoUtil.UTF8StringMarshaler))] string result,
        IntPtr user_context);

    [DllImport(ZegoConstans.LIB_NAME,
               EntryPoint = "zego_register_copyrighted_music_send_extended_request_callback",
               CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
    public static extern void zego_register_copyrighted_music_send_extended_request_callback(
        zego_on_copyrighted_music_send_extended_request callback_func, IntPtr user_context);

    [UnmanagedFunctionPointer(ZegoConstans.ZEGO_CALLINGCONVENTION)]
    public delegate void zego_on_copyrighted_music_get_lrc_lyric(
        int seq, int error_code,
        [In()][MarshalAs(UnmanagedType.CustomMarshaler,
                         MarshalTypeRef = typeof(ZegoUtil.UTF8StringMarshaler))] string lyrics,
        IntPtr user_context);

    [DllImport(ZegoConstans.LIB_NAME,
               EntryPoint = "zego_register_copyrighted_music_get_lrc_lyric_callback",
               CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
    public static extern void zego_register_copyrighted_music_get_lrc_lyric_callback(
        zego_on_copyrighted_music_get_lrc_lyric callback_func, IntPtr user_context);

    [UnmanagedFunctionPointer(ZegoConstans.ZEGO_CALLINGCONVENTION)]
    public delegate void zego_on_copyrighted_music_get_krc_lyric_by_token(
        int seq, int error_code,
        [In()][MarshalAs(UnmanagedType.CustomMarshaler,
                         MarshalTypeRef = typeof(ZegoUtil.UTF8StringMarshaler))] string lyrics,
        IntPtr user_context);

    [DllImport(ZegoConstans.LIB_NAME,
               EntryPoint = "zego_register_copyrighted_music_get_krc_lyric_by_token_callback",
               CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
    public static extern void zego_register_copyrighted_music_get_krc_lyric_by_token_callback(
        zego_on_copyrighted_music_get_krc_lyric_by_token callback_func, IntPtr user_context);

    [UnmanagedFunctionPointer(ZegoConstans.ZEGO_CALLINGCONVENTION)]
    public delegate void zego_on_copyrighted_music_request_song(
        int seq, int error_code,
        [In()][MarshalAs(UnmanagedType.CustomMarshaler,
                         MarshalTypeRef = typeof(ZegoUtil.UTF8StringMarshaler))] string resource,
        IntPtr user_context);

    [DllImport(ZegoConstans.LIB_NAME,
               EntryPoint = "zego_register_copyrighted_music_request_song_callback",
               CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
    public static extern void zego_register_copyrighted_music_request_song_callback(
        zego_on_copyrighted_music_request_song callback_func, IntPtr user_context);

    [UnmanagedFunctionPointer(ZegoConstans.ZEGO_CALLINGCONVENTION)]
    public delegate void zego_on_copyrighted_music_request_accompaniment(
        int seq, int error_code,
        [In()][MarshalAs(UnmanagedType.CustomMarshaler,
                         MarshalTypeRef = typeof(ZegoUtil.UTF8StringMarshaler))] string resource,
        IntPtr user_context);

    [DllImport(ZegoConstans.LIB_NAME,
               EntryPoint = "zego_register_copyrighted_music_request_accompaniment_callback",
               CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
    public static extern void zego_register_copyrighted_music_request_accompaniment_callback(
        zego_on_copyrighted_music_request_accompaniment callback_func, IntPtr user_context);

    [UnmanagedFunctionPointer(ZegoConstans.ZEGO_CALLINGCONVENTION)]
    public delegate void zego_on_copyrighted_music_request_accompaniment_clip(
        int seq, int error_code,
        [In()][MarshalAs(UnmanagedType.CustomMarshaler,
                         MarshalTypeRef = typeof(ZegoUtil.UTF8StringMarshaler))] string resource,
        IntPtr user_context);

    [DllImport(ZegoConstans.LIB_NAME,
               EntryPoint = "zego_register_copyrighted_music_request_accompaniment_clip_callback",
               CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
    public static extern void zego_register_copyrighted_music_request_accompaniment_clip_callback(
        zego_on_copyrighted_music_request_accompaniment_clip callback_func, IntPtr user_context);

    [UnmanagedFunctionPointer(ZegoConstans.ZEGO_CALLINGCONVENTION)]
    public delegate void zego_on_copyrighted_music_get_music_by_token(
        int seq, int error_code,
        [In()][MarshalAs(UnmanagedType.CustomMarshaler,
                         MarshalTypeRef = typeof(ZegoUtil.UTF8StringMarshaler))] string resource,
        IntPtr user_context);

    [DllImport(ZegoConstans.LIB_NAME,
               EntryPoint = "zego_register_copyrighted_music_get_music_by_token_callback",
               CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
    public static extern void zego_register_copyrighted_music_get_music_by_token_callback(
        zego_on_copyrighted_music_get_music_by_token callback_func, IntPtr user_context);

    [UnmanagedFunctionPointer(ZegoConstans.ZEGO_CALLINGCONVENTION)]
    public delegate void zego_on_copyrighted_music_download(int seq, int error_code,
                                                            IntPtr user_context);

    [DllImport(ZegoConstans.LIB_NAME,
               EntryPoint = "zego_register_copyrighted_music_download_callback",
               CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
    public static extern void zego_register_copyrighted_music_download_callback(
        zego_on_copyrighted_music_download callback_func, IntPtr user_context);

    [UnmanagedFunctionPointer(ZegoConstans.ZEGO_CALLINGCONVENTION)]
    public delegate void zego_on_copyrighted_music_get_standard_pitch(
        int seq, int error_code,
        [In()][MarshalAs(UnmanagedType.CustomMarshaler,
                         MarshalTypeRef = typeof(ZegoUtil.UTF8StringMarshaler))] string pitch,
        IntPtr user_context);

    [DllImport(ZegoConstans.LIB_NAME,
               EntryPoint = "zego_register_copyrighted_music_get_standard_pitch_callback",
               CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
    public static extern void zego_register_copyrighted_music_get_standard_pitch_callback(
        zego_on_copyrighted_music_get_standard_pitch callback_func, IntPtr user_context);

    [DllImport(ZegoConstans.LIB_NAME, EntryPoint = "zego_express_copyrighted_music_get_full_score",
               CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
    public static extern int zego_express_copyrighted_music_get_full_score(
        [In()][MarshalAs(UnmanagedType.CustomMarshaler,
                         MarshalTypeRef = typeof(ZegoUtil.UTF8StringMarshaler))] string resource_id,
        ref int full_score);

    [UnmanagedFunctionPointer(ZegoConstans.ZEGO_CALLINGCONVENTION)]
    public delegate void zego_on_copyrighted_music_request_resource(
        int seq, int error_code,
        [In()][MarshalAs(UnmanagedType.CustomMarshaler,
                         MarshalTypeRef = typeof(ZegoUtil.UTF8StringMarshaler))] string resource,
        IntPtr user_context);

    [DllImport(ZegoConstans.LIB_NAME,
               EntryPoint = "zego_register_copyrighted_music_request_resource_callback",
               CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
    public static extern void zego_register_copyrighted_music_request_resource_callback(
        zego_on_copyrighted_music_request_resource callback_func, IntPtr user_context);

    [UnmanagedFunctionPointer(ZegoConstans.ZEGO_CALLINGCONVENTION)]
    public delegate void zego_on_copyrighted_music_get_shared_resource(
        int seq, int error_code,
        [In()][MarshalAs(UnmanagedType.CustomMarshaler,
                         MarshalTypeRef = typeof(ZegoUtil.UTF8StringMarshaler))] string resource,
        IntPtr user_context);

    [DllImport(ZegoConstans.LIB_NAME,
               EntryPoint = "zego_register_copyrighted_music_get_shared_resource_callback",
               CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
    public static extern void zego_register_copyrighted_music_get_shared_resource_callback(
        zego_on_copyrighted_music_get_shared_resource callback_func, IntPtr user_context);

    [DllImport(ZegoConstans.LIB_NAME,
               EntryPoint = "zego_express_copyrighted_music_request_resource",
               CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
    public static extern int
    zego_express_copyrighted_music_request_resource(zego_copyrighted_music_request_config config,
                                                    zego_copyrighted_music_resource_type type,
                                                    ref int sequence);

    [DllImport(ZegoConstans.LIB_NAME,
               EntryPoint = "zego_express_copyrighted_music_get_shared_resource",
               CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
    public static extern int zego_express_copyrighted_music_get_shared_resource(
        zego_copyrighted_music_get_shared_config config, zego_copyrighted_music_resource_type type,
        ref int sequence);

    [DllImport(ZegoConstans.LIB_NAME,
               EntryPoint = "zego_express_copyrighted_music_get_lrc_lyric_with_vendor",
               CallingConvention = ZegoConstans.ZEGO_CALLINGCONVENTION)]
    public static extern int zego_express_copyrighted_music_get_lrc_lyric_with_vendor(
        [In()][MarshalAs(UnmanagedType.CustomMarshaler,
                         MarshalTypeRef = typeof(ZegoUtil.UTF8StringMarshaler))] string song_id,
        zego_copyrighted_music_vendor_id vendor_id, ref int sequence);
}
}