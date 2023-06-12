using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using ZEGO;
using ZegoCsharpWinformDemo.Examples;

namespace ZegoCsharpWinformDemo
{
    public partial class HomePage : Form
    {
        private UserControl current_page;

        Random ran = new Random();

        private static Dictionary<string, DemoPage> page_dics = new Dictionary<string, DemoPage>() {
            { "推流", DemoPage.PAGE_OTHERS_MULTIPLE_ROOM},
            { "拉流", DemoPage.PAGE_OTHERS_MULTIPLE_ROOM},
            { "多房间", DemoPage.PAGE_OTHERS_MULTIPLE_ROOM}
        };

        public HomePage()
        {
            InitializeComponent();

            // Init Language

            // Init UI
            InitUi();
        }

        private void InitUi()
        {
            //string testStr = System.property
            listBox_Quickstart.Items.Add("视频通话");
            listBox_Quickstart.Items.Add("推流");
            listBox_Quickstart.Items.Add("拉流");
            listBox_Others.Items.Add("多房间");
            listBox_Others.Items.Add("版权音乐");
            listBox_DebugAndSetting.Items.Add("设置");
        }

        private void Load_1(object sender, EventArgs e)
        {
            string version = ZegoExpressEngine.GetVersion();
            System.Diagnostics.Debug.WriteLine("version:" + version);

            //ZegoLogConfig config = new ZegoLogConfig();
            //config.logPath = @"C:\Users\zego\Downloads\中文路径";
            //ZegoExpressEngine.SetLogConfig(config);
        }

        

        private void listBox_Quickstart_SelectedIndexChanged(object sender, EventArgs e)
        {
            var item = listBox_Quickstart.SelectedItem;

            ShowPage(item);
        }

        private void ShowPage(object item)
        {
            if (item == null)
            {
                return;
            }

            string page_title = item.ToString();

            // Dispose old window
            if (current_page != null)
            {
                current_page.Dispose();
                current_page = null;
            }

            panel1.Controls.Clear();

            if (page_title == "视频通话")
            {
                current_page = new VideoTalk();
            }
            else if (page_title == "推流")
            {
                current_page = new Publishing();
            }
            else if (page_title == "拉流")
            {
                current_page = new Playing();
            }
            else if (page_title == "多房间")
            {
                current_page = new MultipleRooms();
            }
            else if(page_title == "版权音乐")
            {
                current_page = new CopyrightedMusic();
            }
            else if(page_title == "设置")
            {
                current_page = new Examples.DebugAndConfig.Setting();
            }

            current_page.Dock = DockStyle.Fill;
            panel1.Controls.Add(current_page);
        }

        private void listBox_Others_SelectedIndexChanged(object sender, EventArgs e)
        {
            var item = listBox_Others.SelectedItem;

            ShowPage(item);
        }

        private void listBox_DebugAndSetting_SelectedIndexChanged(object sender, EventArgs e)
        {

            var item = listBox_DebugAndSetting.SelectedItem;

            ShowPage(item);
        }
    }
}
