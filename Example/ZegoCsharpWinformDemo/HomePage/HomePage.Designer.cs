namespace ZegoCsharpWinformDemo
{
    partial class HomePage
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HomePage));
            this.label4 = new System.Windows.Forms.Label();
            this.listBox_Quickstart = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.listBox_Others = new System.Windows.Forms.ListBox();
            this.label6 = new System.Windows.Forms.Label();
            this.listBox_DebugAndSetting = new System.Windows.Forms.ListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.SystemColors.ControlLight;
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // listBox_Quickstart
            // 
            this.listBox_Quickstart.FormattingEnabled = true;
            resources.ApplyResources(this.listBox_Quickstart, "listBox_Quickstart");
            this.listBox_Quickstart.Name = "listBox_Quickstart";
            this.listBox_Quickstart.SelectedIndexChanged += new System.EventHandler(this.listBox_Quickstart_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.SystemColors.ControlLight;
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // listBox_Others
            // 
            this.listBox_Others.FormattingEnabled = true;
            resources.ApplyResources(this.listBox_Others, "listBox_Others");
            this.listBox_Others.Name = "listBox_Others";
            this.listBox_Others.SelectedIndexChanged += new System.EventHandler(this.listBox_Others_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.SystemColors.ControlLight;
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // listBox_DebugAndSetting
            // 
            this.listBox_DebugAndSetting.FormattingEnabled = true;
            resources.ApplyResources(this.listBox_DebugAndSetting, "listBox_DebugAndSetting");
            this.listBox_DebugAndSetting.Name = "listBox_DebugAndSetting";
            this.listBox_DebugAndSetting.SelectedIndexChanged += new System.EventHandler(this.listBox_DebugAndSetting_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // panel2
            // 
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.Controls.Add(this.listBox_DebugAndSetting);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.listBox_Others);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.listBox_Quickstart);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Name = "panel2";
            // 
            // HomePage
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "HomePage";
            this.Load += new System.EventHandler(this.Load_1);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox listBox_Quickstart;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListBox listBox_Others;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ListBox listBox_DebugAndSetting;
        private System.Windows.Forms.Panel panel2;
    }
}