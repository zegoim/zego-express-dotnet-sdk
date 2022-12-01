using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Drawing;


namespace ZegoCsharpWinformDemo
{
    public struct UserConfig
    {
        public uint app_id_;
        public string app_sign_;
        public string user_id_;
    }

    public class ZegoUtil
    {
        private static RichTextBox log_view_control = null;
        private static Label room_state_control = null;
        private static UserConfig user_config_ = new UserConfig();
        private static bool update_user_config_by_ui = false;

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
            if (room_state_control != null)
            {
                if (room_state == ZEGO.ZegoRoomState.Connected)
                {
                    room_state_control.Text = "Connected";
                }
                else if (room_state == ZEGO.ZegoRoomState.Connecting)
                {
                    room_state_control.Text = "Connecting";
                }
                else if (room_state == ZEGO.ZegoRoomState.Disconnected)
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
            if (level == LogLevel.LOG_ERROR)
            {
                color = Color.IndianRed;
            }
            else if (level == LogLevel.LOG_INFO)
            {
                color = Color.LightGray;
            }
            else if (level == LogLevel.LOG_SUCCESS)
            {
                color = Color.Green;
            }
            else if (level == LogLevel.LOG_WARN)
            {
                color = Color.DarkGoldenrod;
            }
            return color;
        }

        public static LogLevel GetLogLevel(int errorCode)
        {
            if (errorCode == 0)
            {
                return LogLevel.LOG_SUCCESS;
            }
            else
            {
                return LogLevel.LOG_ERROR;
            }
        }

        public static void UpdateUserConfigByUi(UserConfig config)
        {
            update_user_config_by_ui = true;

            user_config_.app_id_ = config.app_id_;
            user_config_.app_sign_ = config.app_sign_;
            user_config_.user_id_ = config.user_id_;
        }

        public static uint AppID()
        {
            if(update_user_config_by_ui)
            {
                return user_config_.app_id_;
            }
            else
            {
                return KeyCenter.appID();
            }
        }

        public static string AppSign()
        {
            if (update_user_config_by_ui)
            {
                return user_config_.app_sign_;
            }
            else
            {
                return KeyCenter.appSign();
            }
        }

        public static string UserID()
        {
            if (update_user_config_by_ui)
            {
                return user_config_.user_id_;
            }
            else
            {
                return string.Format("{0}_{1}", DeviceName(), new Random().Next(0, 99999));
            }
        }
    }
}
