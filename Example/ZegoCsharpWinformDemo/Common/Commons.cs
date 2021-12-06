using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZegoCsharpWinformDemo
{
    class Commons
    {

    }
    public enum LogLevel
    {
        LOG_SUCCESS = 0,
        LOG_INFO    = 1,
        LOG_WARN    = 2,
        LOG_ERROR   = 3
    }

    public enum DemoPage
    {
        PAGE_QUICK_START_PUBLISH = 0,   //推流
        PAGE_QUICK_START_PLAYING,       //拉流
        PAGE_OTHERS_MULTIPLE_ROOM,      //多房间
    }
}
