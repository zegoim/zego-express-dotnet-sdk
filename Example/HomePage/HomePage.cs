using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using ZEGO;
using ZegoCsharpWinformDemo.Examples.QuickStart.Publishing;

namespace ZegoCsharpWinformDemo
{
    public partial class HomePage : Form
    {
        private ZegoExpressEngine engine;
        private UserControl current_page;

        Random ran = new Random();
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
            listBox_Quickstart.Items.Add("推流");
            listBox_Quickstart.Items.Add("拉流");
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

            string itemStr = item.ToString();

            // Dispose old window
            if(current_page != null)
            {
                current_page.Dispose();
                current_page = null;
            }

            panel1.Controls.Clear();

            switch(itemStr)
            {
                case "推流":
                {
                    current_page = new Publishing();
                    current_page.Dock = DockStyle.Fill;
                    panel1.Controls.Add(current_page);
                }break;
            }
            Console.WriteLine(itemStr);
        }
    }
}
