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

        public void OnDebugError(int errorCode, string funcName, string info)
        {
            if (onDebugError != null)
                onDebugError(errorCode, funcName, info);
        }

        public void OnRoomStateUpdate(string roomID, ZegoRoomState state, int errorCode, string extendedData)
        {
            if (onRoomStateUpdate != null)
                onRoomStateUpdate(roomID, state, errorCode, extendedData);
        }

        public void OnPublisherStateUpdate(string streamID, ZegoPublisherState state, int errorCode, string extendedData)
        {
            if (onPublisherStateUpdate != null)
                onPublisherStateUpdate(streamID, state, errorCode, extendedData);
        }
        public void OnPlayerStateUpdate(string streamID, ZegoPlayerState state, int errorCode, string extendedData)
        {
            if (onPlayerStateUpdate != null)
                onPlayerStateUpdate(streamID, state, errorCode, extendedData);
        }

        public void OnRoomStreamUpdate(string roomID, ZegoUpdateType updateType, List<ZegoStream> streamList, string extendedData)
        {
            if (onRoomStreamUpdate != null)
                onRoomStreamUpdate(roomID, updateType, streamList, extendedData);
        }

        public void OnCopyrightedMusicDownloadProgressUpdate(ZegoCopyrightedMusic copyrightedMusic, string resourceID, float progressRate)
        {
            if (onCopyrightedMusicDownloadProgressUpdate != null)
            {
                onCopyrightedMusicDownloadProgressUpdate(copyrightedMusic, resourceID, progressRate);
            }
        }

        public void OnPublisherRelayCDNStateUpdate(string streamID, List<ZegoStreamRelayCDNInfo> infoList)
        {
            if (onPublisherRelayCDNStateUpdate != null)
            {
                onPublisherRelayCDNStateUpdate(streamID, infoList);
            }
        }

        public void OnRoomUserUpdate(string roomID, ZegoUpdateType updateType, List<ZegoUser> userList, uint userCount)
        {
            if (onRoomUserUpdate != null)
            {
                onRoomUserUpdate(roomID, updateType, userList, userCount);
            }
        }

    }

    class ZegoEventHandlerWithLog
    {
        private ZegoExpressEngine engine;
        ZegoEventHandler event_handler;

        public ZegoEventHandlerWithLog()
        {

        }

        public void SetZegoEventHandler(ZegoExpressEngine eng, ZegoEventHandler handler)
        {
            if (eng == null || handler == null)
            {
                throw new Exception("engine or event handler can not be null!");
            }
            engine = eng;
            event_handler = handler;

            engine.onDebugError = OnDebugError;
            engine.onRoomStateUpdate = OnRoomStateUpdate;
            engine.onPublisherStateUpdate = OnPublisherStateUpdate;
            engine.onPlayerStateUpdate = OnPlayerStateUpdate;
            engine.onRoomStreamUpdate = OnRoomStreamUpdate;
            engine.onCopyrightedMusicDownloadProgressUpdate = OnCopyrightedMusicDownloadProgressUpdate;
            engine.onPublisherRelayCDNStateUpdate = OnPublisherRelayCDNStateUpdate;
            engine.onRoomUserUpdate = OnRoomUserUpdate;
    }

        public void OnDebugError(int errorCode, string funcName, string info)
        {
            LogLevel level = ZegoUtil.GetLogLevel(errorCode);
            ZegoUtil.PrintLogToView(string.Format("OnDebugError, errorCode:{0}, funcName:{1}, info:{2}", errorCode, funcName, info), level);
            event_handler.OnDebugError(errorCode, funcName, info);
        }

        public void OnRoomStateUpdate(string roomID, ZegoRoomState state, int errorCode, string extendedData)
        {
            ZegoUtil.PrintLogToView(string.Format("onRoomStateUpdate,roomID:{0}, state:{1}, errorCode:{2}, extendedData:{3}", roomID, state, errorCode, extendedData));
            event_handler.OnRoomStateUpdate(roomID, state, errorCode, extendedData);
        }

        public void OnPublisherStateUpdate(string streamID, ZegoPublisherState state, int errorCode, string extendedData)
        {
            ZegoUtil.PrintLogToView(string.Format("OnPublisherStateUpdate, streamID:{0}, state:{1}, errorCode:{2}, extendedData:{3}", streamID, state, errorCode, extendedData));
            event_handler.OnPublisherStateUpdate(streamID, state, errorCode, extendedData);
        }

        public void OnPlayerStateUpdate(string streamID, ZegoPlayerState state, int errorCode, string extendedData)
        {
            ZegoUtil.PrintLogToView(string.Format("OnPlayerStateUpdate, streamID:{0}, state:{1}, errorCode:{2}, extendedData:{3}", streamID, state, errorCode, extendedData));
            event_handler.OnPlayerStateUpdate(streamID, state, errorCode, extendedData);
        }

        public void OnRoomStreamUpdate(string roomID, ZegoUpdateType updateType, List<ZegoStream> streamList, string extendedData)
        {
            streamList.ForEach((stream) =>
            {
                ZegoUtil.PrintLogToView(string.Format("OnRoomStreamUpdate, roomID:{0}, updateType:{1}, streamID:{2}, extendedData:{3}", roomID, updateType, stream.streamID, extendedData));
            });
            event_handler.OnRoomStreamUpdate(roomID, updateType, streamList, extendedData);
        }

        public void OnCopyrightedMusicDownloadProgressUpdate(ZegoCopyrightedMusic copyrightedMusic, string resourceID, float progressRate)
        {
            event_handler.OnCopyrightedMusicDownloadProgressUpdate(copyrightedMusic, resourceID, progressRate);
        }

        public void OnPublisherRelayCDNStateUpdate(string streamID, List<ZegoStreamRelayCDNInfo> infoList)
        {
            infoList.ForEach((cdn_info) =>
            {
                ZegoUtil.PrintLogToView(string.Format("OnPublisherRelayCDNStateUpdate, streamID:{0}, url:{1}, state:{2}, updateReason:{3}, stateTime{4}", streamID, cdn_info.url, cdn_info.state, cdn_info.updateReason, cdn_info.stateTime));
            });
            event_handler.OnPublisherRelayCDNStateUpdate(streamID, infoList);
        }

        public void OnRoomUserUpdate(string roomID, ZegoUpdateType updateType, List<ZegoUser> userList, uint userCount)
        {
            userList.ForEach((user) =>
            {
                ZegoUtil.PrintLogToView(string.Format("OnRoomUserUpdate, roomID:{0}, updateType:{1}, userID:{2}", roomID, updateType, user.userID));
            });
            event_handler.onRoomUserUpdate(roomID, updateType, userList, userCount);
        }
    }

}
