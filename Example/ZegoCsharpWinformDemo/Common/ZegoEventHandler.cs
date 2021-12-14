using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZEGO;

namespace ZegoCsharpWinformDemo.Common
{
    class ZegoEventHandler
    {
        private ZegoExpressEngine engine = null;    // SDK engine
        private bool is_print_to_view = false;      // print callback info to view or not

        // SDK callbacks
        public IZegoEventHandler.OnDebugError onDebugError;
        public IZegoEventHandler.OnRoomStateUpdate onRoomStateUpdate;
        public IZegoEventHandler.OnPublisherStateUpdate onPublisherStateUpdate;
        public IZegoEventHandler.OnPlayerStateUpdate onPlayerStateUpdate;
        public IZegoEventHandler.OnRoomStreamUpdate onRoomStreamUpdate;
        public IZegoEventHandler.OnCopyrightedMusicDownloadProgressUpdate onCopyrightedMusicDownloadProgressUpdate;
        public IZegoEventHandler.OnPublisherRelayCDNStateUpdate onPublisherRelayCDNStateUpdate;
        public IZegoEventHandler.OnRoomUserUpdate onRoomUserUpdate;

        public ZegoEventHandler()
        {

        }

        public void SetZegoEventHandler(ZegoExpressEngine eng, bool isPrintToView = true)
        {
            if (eng == null)
            {
                throw new Exception("engine can not be null!");
            }
            engine = eng;
            is_print_to_view = isPrintToView;

            engine.onDebugError = OnDebugError;
            engine.onRoomStateUpdate = OnRoomStateUpdate;
            engine.onPublisherStateUpdate = OnPublisherStateUpdate;
            engine.onPlayerStateUpdate = OnPlayerStateUpdate;
            engine.onRoomStreamUpdate = OnRoomStreamUpdate;
            engine.onCopyrightedMusicDownloadProgressUpdate = OnCopyrightedMusicDownloadProgressUpdate;
            engine.onPublisherRelayCDNStateUpdate = OnPublisherRelayCDNStateUpdate;
            engine.onRoomUserUpdate = OnRoomUserUpdate;
        }

        private void PrintLogToView(string log, LogLevel level = LogLevel.LOG_INFO)
        {
            if(is_print_to_view)
            {
                ZegoUtil.PrintLogToView(log, level);
            }
        }

        public void OnDebugError(int errorCode, string funcName, string info)
        {
            LogLevel level = ZegoUtil.GetLogLevel(errorCode);
            PrintLogToView(string.Format("OnDebugError, errorCode:{0}, funcName:{1}, info:{2}", errorCode, funcName, info), level);
            if (onDebugError!= null)
            {
                onDebugError(errorCode, funcName, info);
            }
        }

        public void OnRoomStateUpdate(string roomID, ZegoRoomState state, int errorCode, string extendedData)
        {
            PrintLogToView(string.Format("onRoomStateUpdate,roomID:{0}, state:{1}, errorCode:{2}, extendedData:{3}", roomID, state, errorCode, extendedData));
            if(onRoomStateUpdate != null)
            {
                onRoomStateUpdate(roomID, state, errorCode, extendedData);
            }
        }

        public void OnPublisherStateUpdate(string streamID, ZegoPublisherState state, int errorCode, string extendedData)
        {
            PrintLogToView(string.Format("OnPublisherStateUpdate, streamID:{0}, state:{1}, errorCode:{2}, extendedData:{3}", streamID, state, errorCode, extendedData));
            if(onPublisherStateUpdate != null)
            {
                onPublisherStateUpdate(streamID, state, errorCode, extendedData);
            }
        }

        public void OnPlayerStateUpdate(string streamID, ZegoPlayerState state, int errorCode, string extendedData)
        {
            PrintLogToView(string.Format("OnPlayerStateUpdate, streamID:{0}, state:{1}, errorCode:{2}, extendedData:{3}", streamID, state, errorCode, extendedData));
            if(onPlayerStateUpdate != null)
            {
                onPlayerStateUpdate(streamID, state, errorCode, extendedData);
            }
        }

        public void OnRoomStreamUpdate(string roomID, ZegoUpdateType updateType, List<ZegoStream> streamList, string extendedData)
        {
            streamList.ForEach((stream) =>
            {
                PrintLogToView(string.Format("OnRoomStreamUpdate, roomID:{0}, updateType:{1}, streamID:{2}, extendedData:{3}", roomID, updateType, stream.streamID, extendedData));
            });
            if(onRoomStreamUpdate != null)
            {
                onRoomStreamUpdate(roomID, updateType, streamList, extendedData);
            }
        }

        public void OnCopyrightedMusicDownloadProgressUpdate(ZegoCopyrightedMusic copyrightedMusic, string resourceID, float progressRate)
        {
            if(onCopyrightedMusicDownloadProgressUpdate != null)
            {
                onCopyrightedMusicDownloadProgressUpdate(copyrightedMusic, resourceID, progressRate);
            }
        }

        public void OnPublisherRelayCDNStateUpdate(string streamID, List<ZegoStreamRelayCDNInfo> infoList)
        {
            infoList.ForEach((cdn_info) =>
            {
                PrintLogToView(string.Format("OnPublisherRelayCDNStateUpdate, streamID:{0}, url:{1}, state:{2}, updateReason:{3}, stateTime{4}", streamID, cdn_info.url, cdn_info.state, cdn_info.updateReason, cdn_info.stateTime));
            });
            if(onPublisherRelayCDNStateUpdate != null)
            {
                onPublisherRelayCDNStateUpdate(streamID, infoList);
            }
        }

        public void OnRoomUserUpdate(string roomID, ZegoUpdateType updateType, List<ZegoUser> userList, uint userCount)
        {
            userList.ForEach((user) =>
            {
                PrintLogToView(string.Format("OnRoomUserUpdate, roomID:{0}, updateType:{1}, userID:{2}", roomID, updateType, user.userID));
            });
            if(onRoomUserUpdate != null)
            {
                onRoomUserUpdate(roomID, updateType, userList, userCount);
            }
        }
    }

}
