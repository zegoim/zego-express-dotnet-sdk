namespace ZegoCsharpWinformDemo.Examples.DebugAndConfig
{
    partial class Setting
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label_DemoVersion = new System.Windows.Forms.Label();
            this.labe_SDKVersion = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label15 = new System.Windows.Forms.Label();
            this.button_SetEngineConfig = new System.Windows.Forms.Button();
            this.textBox_EngineConfig = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.textBox_AppID = new System.Windows.Forms.TextBox();
            this.textBox_UserID = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.button_SetUserConfig = new System.Windows.Forms.Button();
            this.textBox_AppSign = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.folderBrowserDialog_SelectLogPath = new System.Windows.Forms.FolderBrowserDialog();
            this.button_SetLogConfig = new System.Windows.Forms.Button();
            this.button_SetLogPath = new System.Windows.Forms.Button();
            this.textBox_LogPath = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.numericUpDown_LogSize = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.richTextBox_LogView = new System.Windows.Forms.RichTextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_LogSize)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label_DemoVersion
            // 
            this.label_DemoVersion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label_DemoVersion.AutoSize = true;
            this.label_DemoVersion.Location = new System.Drawing.Point(41, 44);
            this.label_DemoVersion.Name = "label_DemoVersion";
            this.label_DemoVersion.Size = new System.Drawing.Size(0, 12);
            this.label_DemoVersion.TabIndex = 6;
            // 
            // labe_SDKVersion
            // 
            this.labe_SDKVersion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labe_SDKVersion.AutoSize = true;
            this.labe_SDKVersion.Location = new System.Drawing.Point(35, 23);
            this.labe_SDKVersion.Name = "labe_SDKVersion";
            this.labe_SDKVersion.Size = new System.Drawing.Size(0, 12);
            this.labe_SDKVersion.TabIndex = 5;
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 44);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(29, 12);
            this.label13.TabIndex = 4;
            this.label13.Text = "Demo";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(156, 23);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(0, 12);
            this.label14.TabIndex = 3;
            // 
            // label16
            // 
            this.label16.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label16.Location = new System.Drawing.Point(3, 3);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(54, 12);
            this.label16.TabIndex = 0;
            this.label16.Text = "Version";
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.label_DemoVersion);
            this.panel4.Controls.Add(this.labe_SDKVersion);
            this.panel4.Controls.Add(this.label13);
            this.panel4.Controls.Add(this.label14);
            this.panel4.Controls.Add(this.label15);
            this.panel4.Controls.Add(this.label16);
            this.panel4.Location = new System.Drawing.Point(3, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(961, 66);
            this.panel4.TabIndex = 15;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(6, 23);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(23, 12);
            this.label15.TabIndex = 1;
            this.label15.Text = "SDK";
            // 
            // button_SetEngineConfig
            // 
            this.button_SetEngineConfig.Location = new System.Drawing.Point(57, 100);
            this.button_SetEngineConfig.Name = "button_SetEngineConfig";
            this.button_SetEngineConfig.Size = new System.Drawing.Size(126, 23);
            this.button_SetEngineConfig.TabIndex = 7;
            this.button_SetEngineConfig.Text = "Set Engine Config";
            this.button_SetEngineConfig.UseVisualStyleBackColor = true;
            this.button_SetEngineConfig.Click += new System.EventHandler(this.button_SetEngineConfig_Click);
            // 
            // textBox_EngineConfig
            // 
            this.textBox_EngineConfig.Location = new System.Drawing.Point(3, 46);
            this.textBox_EngineConfig.Multiline = true;
            this.textBox_EngineConfig.Name = "textBox_EngineConfig";
            this.textBox_EngineConfig.Size = new System.Drawing.Size(224, 48);
            this.textBox_EngineConfig.TabIndex = 5;
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(3, 23);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(224, 12);
            this.label11.TabIndex = 1;
            this.label11.Text = "(Input format:AA=BB;CC=DD;)";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label12.Location = new System.Drawing.Point(3, 3);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(96, 12);
            this.label12.TabIndex = 0;
            this.label12.Text = "Engine Config";
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.button_SetEngineConfig);
            this.panel3.Controls.Add(this.textBox_EngineConfig);
            this.panel3.Controls.Add(this.label11);
            this.panel3.Controls.Add(this.label12);
            this.panel3.Location = new System.Drawing.Point(209, 181);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(230, 129);
            this.panel3.TabIndex = 13;
            // 
            // textBox_AppID
            // 
            this.textBox_AppID.Location = new System.Drawing.Point(66, 18);
            this.textBox_AppID.Name = "textBox_AppID";
            this.textBox_AppID.Size = new System.Drawing.Size(131, 21);
            this.textBox_AppID.TabIndex = 10;
            // 
            // textBox_UserID
            // 
            this.textBox_UserID.Location = new System.Drawing.Point(66, 73);
            this.textBox_UserID.Name = "textBox_UserID";
            this.textBox_UserID.Size = new System.Drawing.Size(131, 21);
            this.textBox_UserID.TabIndex = 9;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(6, 77);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(47, 12);
            this.label19.TabIndex = 8;
            this.label19.Text = "User ID";
            // 
            // button_SetUserConfig
            // 
            this.button_SetUserConfig.Location = new System.Drawing.Point(46, 100);
            this.button_SetUserConfig.Name = "button_SetUserConfig";
            this.button_SetUserConfig.Size = new System.Drawing.Size(104, 23);
            this.button_SetUserConfig.TabIndex = 7;
            this.button_SetUserConfig.Text = "Set User Config";
            this.button_SetUserConfig.UseVisualStyleBackColor = true;
            this.button_SetUserConfig.Click += new System.EventHandler(this.button_SetUserConfig_Click);
            // 
            // textBox_AppSign
            // 
            this.textBox_AppSign.Location = new System.Drawing.Point(66, 46);
            this.textBox_AppSign.Name = "textBox_AppSign";
            this.textBox_AppSign.Size = new System.Drawing.Size(131, 21);
            this.textBox_AppSign.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 50);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "App Sign";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 23);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 12);
            this.label7.TabIndex = 1;
            this.label7.Text = "App ID";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(3, 3);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(82, 12);
            this.label8.TabIndex = 0;
            this.label8.Text = "User Config";
            // 
            // button_SetLogConfig
            // 
            this.button_SetLogConfig.Location = new System.Drawing.Point(285, 73);
            this.button_SetLogConfig.Name = "button_SetLogConfig";
            this.button_SetLogConfig.Size = new System.Drawing.Size(104, 23);
            this.button_SetLogConfig.TabIndex = 7;
            this.button_SetLogConfig.Text = "Set Log Config";
            this.button_SetLogConfig.UseVisualStyleBackColor = true;
            this.button_SetLogConfig.Click += new System.EventHandler(this.button_SetLogConfig_Click);
            // 
            // button_SetLogPath
            // 
            this.button_SetLogPath.Location = new System.Drawing.Point(394, 44);
            this.button_SetLogPath.Name = "button_SetLogPath";
            this.button_SetLogPath.Size = new System.Drawing.Size(39, 23);
            this.button_SetLogPath.TabIndex = 6;
            this.button_SetLogPath.Text = "...";
            this.button_SetLogPath.UseVisualStyleBackColor = true;
            this.button_SetLogPath.Click += new System.EventHandler(this.button_SetLogPath_Click);
            // 
            // textBox_LogPath
            // 
            this.textBox_LogPath.Location = new System.Drawing.Point(66, 46);
            this.textBox_LogPath.Name = "textBox_LogPath";
            this.textBox_LogPath.Size = new System.Drawing.Size(322, 21);
            this.textBox_LogPath.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 46);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 4;
            this.label4.Text = "Log Path";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(156, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "Bytes";
            // 
            // numericUpDown_LogSize
            // 
            this.numericUpDown_LogSize.Location = new System.Drawing.Point(65, 19);
            this.numericUpDown_LogSize.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.numericUpDown_LogSize.Minimum = new decimal(new int[] {
            -2147483648,
            0,
            0,
            -2147483648});
            this.numericUpDown_LogSize.Name = "numericUpDown_LogSize";
            this.numericUpDown_LogSize.Size = new System.Drawing.Size(85, 21);
            this.numericUpDown_LogSize.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "Log Size";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(3, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "Log Config";
            // 
            // richTextBox_LogView
            // 
            this.richTextBox_LogView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox_LogView.BackColor = System.Drawing.SystemColors.InfoText;
            this.richTextBox_LogView.ForeColor = System.Drawing.SystemColors.Info;
            this.richTextBox_LogView.Location = new System.Drawing.Point(3, 316);
            this.richTextBox_LogView.Name = "richTextBox_LogView";
            this.richTextBox_LogView.ReadOnly = true;
            this.richTextBox_LogView.Size = new System.Drawing.Size(961, 160);
            this.richTextBox_LogView.TabIndex = 14;
            this.richTextBox_LogView.Text = "";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.textBox_AppID);
            this.panel2.Controls.Add(this.textBox_UserID);
            this.panel2.Controls.Add(this.label19);
            this.panel2.Controls.Add(this.button_SetUserConfig);
            this.panel2.Controls.Add(this.textBox_AppSign);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Location = new System.Drawing.Point(3, 181);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 129);
            this.panel2.TabIndex = 12;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.button_SetLogConfig);
            this.panel1.Controls.Add(this.button_SetLogPath);
            this.panel1.Controls.Add(this.textBox_LogPath);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.numericUpDown_LogSize);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(3, 75);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(436, 100);
            this.panel1.TabIndex = 11;
            // 
            // Setting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.richTextBox_LogView);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Setting";
            this.Size = new System.Drawing.Size(967, 479);
            this.Load += new System.EventHandler(this.Setting_Load);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_LogSize)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label_DemoVersion;
        private System.Windows.Forms.Label labe_SDKVersion;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button button_SetEngineConfig;
        private System.Windows.Forms.TextBox textBox_EngineConfig;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox textBox_AppID;
        private System.Windows.Forms.TextBox textBox_UserID;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Button button_SetUserConfig;
        private System.Windows.Forms.TextBox textBox_AppSign;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog_SelectLogPath;
        private System.Windows.Forms.Button button_SetLogConfig;
        private System.Windows.Forms.Button button_SetLogPath;
        private System.Windows.Forms.TextBox textBox_LogPath;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numericUpDown_LogSize;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox richTextBox_LogView;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
    }
}
