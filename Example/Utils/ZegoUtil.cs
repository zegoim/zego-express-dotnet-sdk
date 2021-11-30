using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Drawing;


namespace ZegoCsharpWinformDemo
{
    class ZegoUtil
    {
        private static RichTextBox log_view_control = null;
        private static Label room_state_control = null;

        public static void InitLogViewControl(RichTextBox box)
        {
            log_view_control = box;
        }

        public static void InitRoomStateControl(Label label)
        {
            room_state_control = label;
        }

        public static void PrintLogToView(string log, LogLevel level = LogLevel.LOG_INFO)
        {
            if (log_view_control != null)
            {
                string log_all = string.Format("[{0:HH:mm:ss:ffff}]", DateTime.Now) + " " + log + "\n";
                log_view_control.Select(log_view_control.TextLength, log_all.Length);
                log_view_control.SelectionColor = GetLogFontColor(level);
                log_view_control.AppendText(log_all);
                log_view_control.ScrollToCaret();
            }
        }

        public static void SetRoomState(ZEGO.ZegoRoomState room_state)
        {
            if(room_state_control != null)
            {
                if(room_state == ZEGO.ZegoRoomState.Connected)
                {
                    room_state_control.Text = "Connected";
                }
                else if(room_state == ZEGO.ZegoRoomState.Connecting)
                {
                    room_state_control.Text = "Connecting";
                }
                else if(room_state == ZEGO.ZegoRoomState.Disconnected)
                {
                    room_state_control.Text = "Disconnected";
                }
            }
        }

        public static string DeviceName()
        {
            string name = Environment.UserName;
            string platform = Environment.OSVersion.Platform.ToString();
            return platform + "_" + name;
        }

        private static Color GetLogFontColor(LogLevel level)
        {
            Color color = Color.White;
            if(level == LogLevel.LOG_ERROR)
            {
                color = Color.IndianRed;
            }
            else if(level == LogLevel.LOG_INFO)
            {
                color = Color.LightGray;
            }
            else if(level == LogLevel.LOG_SUCCESS)
            {
                color = Color.Green;
            }
            else if(level == LogLevel.LOG_WARN)
            {
                color = Color.DarkGoldenrod;
            }
            return color;
        }

    }
}
