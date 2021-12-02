using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace ZEGO
{
    public class ZegoConstans
    {

#if UNITY_STANDALONE_WIN || UNITY_EDITOR
        public const string LIB_NAME = "ZegoExpressEngine";
#else

#if UNITY_IPHONE
		public const string LIB_NAME = "__Internal";
#elif UNITY_STANDALONE_OSX
        public const string LIB_NAME = "ZegoExpressEngine";
#else
        public const string LIB_NAME = "ZegoExpressEngine";
#endif
#endif
        //public const string ZEGO_CALLBACK_GAME_OBJ_NAME = "ZEGO_CALLBACK_GAME_OBJECT";

        public const CallingConvention ZEGO_CALLINGCONVENTION = CallingConvention.Cdecl;
        public const int ZEGO_EXPRESS_MAX_COMMON_LEN = 512;
        public const int ZEGO_EXPRESS_MAX_APPSIGN_LEN = 64;
        public const int ZEGO_EXPRESS_MAX_USERID_LEN = 64;
        public const int ZEGO_EXPRESS_MAX_USERNAME_LEN = 256;
        public const int ZEGO_EXPRESS_MAX_ROOMID_LEN = 128;
        public const int ZEGO_EXPRESS_MAX_TOKEN_LEN = 512;
        public const int ZEGO_EXPRESS_MAX_MIX_INPUT_COUNT = 12;
        public const int ZEGO_EXPRESS_MAX_STREAM_LEN = 256;
        public const int ZEGO_EXPRESS_MAX_MIXER_TASK_LEN = 256;
        public const int ZEGO_EXPRESS_MAX_EXTRA_INFO_LEN = 1024;
        public const int ZEGO_EXPRESS_MAX_DEVICE_ID_LEN = 256;
        public const int ZEGO_EXPRESS_MAX_URL_COUNT = 10;
        public const int ZEGO_EXPRESS_MAX_URL_LEN = 1024;
        public const int ZEGO_EXPRESS_MAX_IMAGE_PATH = 512;
        public const int ZEGO_EXPRESS_MAX_MESSAGE_LEN = 1024;
        public const int ZEGO_EXPRESS_MAX_CUSTOM_CMD_LEN = 1024;
        public const int ZEGO_EXPRESS_MAX_MEDIAPLAYER_INSTANCE_COUNT = 4;
        public const int ZEGO_EXPRESS_MAX_ROOM_EXTRA_INFO_KEY_LEN = 128;
        public const int ZEGO_EXPRESS_MAX_ROOM_EXTRA_INFO_VALUE_LEN = 4096;

        public const string MOUDLE_U3D = "u3d";
        public const string MODULE_DOT_NET = "dotnet";

        public const string MODULE = MODULE_DOT_NET;

        //module
        /// ZEGO_EXPRESS_MODULE_COMMON -> (0)
        public const int ZEGO_EXPRESS_MODULE_COMMON = 0;

        /// ZEGO_EXPRESS_MODULE_ENGINE -> (1)
        public const int ZEGO_EXPRESS_MODULE_ENGINE = 1;

        /// ZEGO_EXPRESS_MODULE_ROOM -> (2)
        public const int ZEGO_EXPRESS_MODULE_ROOM = 2;

        /// ZEGO_EXPRESS_MODULE_PUBLISHER -> (3)
        public const int ZEGO_EXPRESS_MODULE_PUBLISHER = 3;

        /// ZEGO_EXPRESS_MODULE_PLAYER -> (4)
        public const int ZEGO_EXPRESS_MODULE_PLAYER = 4;

        /// ZEGO_EXPRESS_MODULE_MIXER -> (5)
        public const int ZEGO_EXPRESS_MODULE_MIXER = 5;

        /// ZEGO_EXPRESS_MODULE_DEVICE -> (6)
        public const int ZEGO_EXPRESS_MODULE_DEVICE = 6;

        /// ZEGO_EXPRESS_MODULE_PREPROCESS -> (7)
        public const int ZEGO_EXPRESS_MODULE_PREPROCESS = 7;

        /// ZEGO_EXPRESS_MODULE_MEDIAPLAYER -> (8)
        public const int ZEGO_EXPRESS_MODULE_MEDIAPLAYER = 8;

        /// ZEGO_EXPRESS_MODULE_IM -> (9)
        public const int ZEGO_EXPRESS_MODULE_IM = 9;

        /// ZEGO_EXPRESS_MODULE_RECORD -> (10)
        public const int ZEGO_EXPRESS_MODULE_RECORD = 10;

        /// ZEGO_EXPRESS_MODULE_CUSTOMVIDEOIO -> (11)
        public const int ZEGO_EXPRESS_MODULE_CUSTOMVIDEOIO = 11;

        /// ZEGO_EXPRESS_MODULE_CUSTOMAUDIOIO -> (12)
        public const int ZEGO_EXPRESS_MODULE_CUSTOMAUDIOIO = 12;

        /// ZEGO_EXPRESS_MODULE_MEDIAPUBLISHER -> (13)
        public const int ZEGO_EXPRESS_MODULE_MEDIAPUBLISHER = 13;

        public const int ZEGO_EXPRESS_MODULE_AUDIOEFFECTPLAYER = 14;

        public const int ZEGO_EXPRESS_MODULE_UTILITIES = 15;

        public const int ZEGO_EXPRESS_MODULE_RANGEAUDIO = 16;

        public const int ZEGO_EXPRESS_MODULE_COPYRIGHTEDMUSIC = 17;
    }
}