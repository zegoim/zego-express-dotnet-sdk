using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZEGO;

namespace ZegoCsharpWinformDemo.Common
{
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
        }

        public void OnDebugError(int errorCode, string funcName, string info)
        {
            ZegoUtil.PrintLogToView(string.Format("OnDebugError, errorCode:{0}, funcName:{1}, info:{2}", errorCode, funcName, info));
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
    }

    class ZegoEventHandler
    {
        public IZegoEventHandler.OnDebugError onDebugError;
        public IZegoEventHandler.OnRoomStateUpdate onRoomStateUpdate;
        public IZegoEventHandler.OnPublisherStateUpdate onPublisherStateUpdate;

        public ZegoEventHandler()
        {

        }

        public void OnDebugError(int errorCode, string funcName, string info) 
        {
            if(onDebugError != null)
                onDebugError(errorCode, funcName, info);
        }

        public void OnRoomStateUpdate(string roomID, ZegoRoomState state, int errorCode, string extendedData)
        {
            if (onRoomStateUpdate != null)
                onRoomStateUpdate(roomID, state, errorCode, extendedData);
        }

        public void OnPublisherStateUpdate(string streamID, ZegoPublisherState state, int errorCode, string extendedData)
        {
            if(onPublisherStateUpdate != null)
                onPublisherStateUpdate(streamID, state, errorCode, extendedData);
        }
    }
}
