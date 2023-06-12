using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZEGO;
using static ZegoCsharpWinformDemo.ZegoUtil;

namespace ZegoCsharpWinformDemo.Examples.DebugAndConfig
{
    public partial class Setting : UserControl
    {
        private ZegoExpressEngine engine;
        private SynchronizationContext context;

        public Setting()
        {
            InitializeComponent();
        }

        private void Setting_Load(object sender, EventArgs e)
        {
            ZegoUtil.InitLogViewControl(richTextBox_LogView);

            InitUI();
        }

        private void InitUI()
        {
            textBox_AppID.Text = String.Format("{0}", KeyCenter.appID());
            textBox_AppSign.Text = String.Format("{0}", KeyCenter.appSign());
            textBox_UserID.Text = ZegoUtil.UserID();
            labe_SDKVersion.Text = ZegoExpressEngine.GetVersion();
            label_DemoVersion.Text = String.Format("{0}", Application.ProductVersion);
            numericUpDown_LogSize.Value = 5 * 1024 * 1024;
            textBox_LogPath.Text = Application.UserAppDataPath;
        }
        private void button_SetLogConfig_Click(object sender, EventArgs e)
        {
            ZegoLogConfig log_config = new ZegoLogConfig
            {
                logPath = textBox_LogPath.Text,
                logSize = (ulong)numericUpDown_LogSize.Value
            };
            ZegoExpressEngine.SetLogConfig(log_config);

            ZegoUtil.PrintLogToView(String.Format("SetLogConfig, logPath:{0}, logSize:{1}", log_config.logPath, log_config.logSize));
        }

        private void button_SetUserConfig_Click(object sender, EventArgs e)
        {
            UserConfig cc = new UserConfig
            {
                app_id_ = uint.Parse(textBox_AppID.Text),
                app_sign_ = textBox_AppSign.Text,
                user_id_ = textBox_UserID.Text
            };
            UpdateUserConfigByUi(cc);

            ZegoUtil.PrintLogToView(String.Format("UpdateUserConfigByUi, app_id_:{0}, app_sign_:{1}, user_id_:{2}", cc.app_id_, cc.app_sign_, cc.user_id_));
        }

        private void button_SetEngineConfig_Click(object sender, EventArgs e)
        {
            ZegoEngineConfig config = new ZegoEngineConfig();

            string engine_config_str = textBox_EngineConfig.Text;

            var bytes = Encoding.Convert(Encoding.Default, Encoding.UTF8, Encoding.Default.GetBytes(engine_config_str));
            string engine_config_str_utf8 = Encoding.UTF8.GetString(bytes);

            string[] config_list = engine_config_str_utf8.Split(';');
            foreach(var item in config_list)
            {
                string[] one_config = item.Split('=');
                if(one_config.Length == 2)
                {
                    string key = one_config[0];
                    string value = one_config[1];

                    config.advancedConfig.Add(key, value);

                    ZegoUtil.PrintLogToView(String.Format("SetEngineConfig: {0}={1}", key, value));
                }
            }
            
            ZegoExpressEngine.SetEngineConfig(config);
        }

        private void button_SetLogPath_Click(object sender, EventArgs e)
        {
            folderBrowserDialog_SelectLogPath.ShowDialog();
            string path = folderBrowserDialog_SelectLogPath.SelectedPath;
            string encoding = Encoding.Default.EncodingName;

            //var bytes = Encoding.Convert(Encoding.Default, Encoding.UTF8, Encoding.Default.GetBytes(path));
            //string path_utf8 = Encoding.UTF8.GetString(bytes);
            textBox_LogPath.Text = path;
        }
    }
}
