
namespace ZegoCsharpWinformDemo.Examples
{
    partial class Playing
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
            DestroyEngine();
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.richTextBox_LogView = new System.Windows.Forms.RichTextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label_RoomID = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label_RoomState = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label_StreamID = new System.Windows.Forms.Label();
            this.label_StreamIDLabel = new System.Windows.Forms.Label();
            this.label_ViewName = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button_LoginRoom = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_UserID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_RoomID = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.checkBox_Audio = new System.Windows.Forms.CheckBox();
            this.checkBox_Video = new System.Windows.Forms.CheckBox();
            this.comboBox_ViewMode = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.button_StartPlaying = new System.Windows.Forms.Button();
            this.textBox_PlayStreamID = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // richTextBox_LogView
            // 
            this.richTextBox_LogView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox_LogView.BackColor = System.Drawing.SystemColors.InfoText;
            this.richTextBox_LogView.ForeColor = System.Drawing.SystemColors.Info;
            this.richTextBox_LogView.Location = new System.Drawing.Point(3, 353);
            this.richTextBox_LogView.Name = "richTextBox_LogView";
            this.richTextBox_LogView.ReadOnly = true;
            this.richTextBox_LogView.Size = new System.Drawing.Size(794, 244);
            this.richTextBox_LogView.TabIndex = 4;
            this.richTextBox_LogView.Text = "";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pictureBox1.Location = new System.Drawing.Point(3, 77);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(480, 270);
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // panel5
            // 
            this.panel5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.label_RoomID);
            this.panel5.Controls.Add(this.label11);
            this.panel5.Controls.Add(this.label_RoomState);
            this.panel5.Controls.Add(this.label8);
            this.panel5.Location = new System.Drawing.Point(3, 3);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(480, 31);
            this.panel5.TabIndex = 9;
            // 
            // label_RoomID
            // 
            this.label_RoomID.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label_RoomID.Location = new System.Drawing.Point(50, 10);
            this.label_RoomID.Name = "label_RoomID";
            this.label_RoomID.Size = new System.Drawing.Size(99, 12);
            this.label_RoomID.TabIndex = 1;
            this.label_RoomID.Text = "1213123";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label11.Location = new System.Drawing.Point(3, 10);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(41, 12);
            this.label11.TabIndex = 0;
            this.label11.Text = "房间ID";
            // 
            // label_RoomState
            // 
            this.label_RoomState.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label_RoomState.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label_RoomState.Location = new System.Drawing.Point(214, 10);
            this.label_RoomState.Name = "label_RoomState";
            this.label_RoomState.Size = new System.Drawing.Size(261, 12);
            this.label_RoomState.TabIndex = 0;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label8.Location = new System.Drawing.Point(155, 10);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 0;
            this.label8.Text = "房间状态";
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.label_StreamID);
            this.panel4.Controls.Add(this.label_StreamIDLabel);
            this.panel4.Controls.Add(this.label_ViewName);
            this.panel4.Location = new System.Drawing.Point(3, 40);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(480, 31);
            this.panel4.TabIndex = 10;
            // 
            // label_StreamID
            // 
            this.label_StreamID.AutoSize = true;
            this.label_StreamID.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label_StreamID.Location = new System.Drawing.Point(73, 11);
            this.label_StreamID.Name = "label_StreamID";
            this.label_StreamID.Size = new System.Drawing.Size(0, 12);
            this.label_StreamID.TabIndex = 0;
            // 
            // label_StreamIDLabel
            // 
            this.label_StreamIDLabel.AutoSize = true;
            this.label_StreamIDLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label_StreamIDLabel.Location = new System.Drawing.Point(38, 11);
            this.label_StreamIDLabel.Name = "label_StreamIDLabel";
            this.label_StreamIDLabel.Size = new System.Drawing.Size(29, 12);
            this.label_StreamIDLabel.TabIndex = 0;
            this.label_StreamIDLabel.Text = "流ID";
            // 
            // label_ViewName
            // 
            this.label_ViewName.AutoSize = true;
            this.label_ViewName.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label_ViewName.Location = new System.Drawing.Point(3, 11);
            this.label_ViewName.Name = "label_ViewName";
            this.label_ViewName.Size = new System.Drawing.Size(29, 12);
            this.label_ViewName.TabIndex = 0;
            this.label_ViewName.Text = "拉流";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Location = new System.Drawing.Point(489, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(308, 344);
            this.panel2.TabIndex = 11;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.button_LoginRoom);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.textBox_UserID);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.textBox_RoomID);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(298, 103);
            this.panel1.TabIndex = 5;
            // 
            // button_LoginRoom
            // 
            this.button_LoginRoom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button_LoginRoom.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button_LoginRoom.Location = new System.Drawing.Point(3, 64);
            this.button_LoginRoom.Name = "button_LoginRoom";
            this.button_LoginRoom.Size = new System.Drawing.Size(290, 23);
            this.button_LoginRoom.TabIndex = 6;
            this.button_LoginRoom.Text = "登录房间";
            this.button_LoginRoom.UseVisualStyleBackColor = true;
            this.button_LoginRoom.Click += new System.EventHandler(this.button_LoginRoom_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(49, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "Login Room";
            // 
            // textBox_UserID
            // 
            this.textBox_UserID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_UserID.Location = new System.Drawing.Point(211, 36);
            this.textBox_UserID.Name = "textBox_UserID";
            this.textBox_UserID.Size = new System.Drawing.Size(82, 21);
            this.textBox_UserID.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold);
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "Step1";
            // 
            // textBox_RoomID
            // 
            this.textBox_RoomID.Location = new System.Drawing.Point(57, 36);
            this.textBox_RoomID.Name = "textBox_RoomID";
            this.textBox_RoomID.Size = new System.Drawing.Size(101, 21);
            this.textBox_RoomID.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(10, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "RoomID";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(164, 39);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 4;
            this.label4.Text = "UserID";
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.checkBox_Audio);
            this.panel3.Controls.Add(this.checkBox_Video);
            this.panel3.Controls.Add(this.comboBox_ViewMode);
            this.panel3.Controls.Add(this.label10);
            this.panel3.Controls.Add(this.button_StartPlaying);
            this.panel3.Controls.Add(this.textBox_PlayStreamID);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Location = new System.Drawing.Point(3, 112);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(298, 152);
            this.panel3.TabIndex = 4;
            // 
            // checkBox_Audio
            // 
            this.checkBox_Audio.AutoSize = true;
            this.checkBox_Audio.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.checkBox_Audio.Location = new System.Drawing.Point(89, 127);
            this.checkBox_Audio.Name = "checkBox_Audio";
            this.checkBox_Audio.Size = new System.Drawing.Size(48, 16);
            this.checkBox_Audio.TabIndex = 11;
            this.checkBox_Audio.Text = "音频";
            this.checkBox_Audio.UseVisualStyleBackColor = true;
            this.checkBox_Audio.CheckedChanged += new System.EventHandler(this.checkBox_Audio_CheckedChanged);
            // 
            // checkBox_Video
            // 
            this.checkBox_Video.AutoSize = true;
            this.checkBox_Video.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.checkBox_Video.Location = new System.Drawing.Point(5, 127);
            this.checkBox_Video.Name = "checkBox_Video";
            this.checkBox_Video.Size = new System.Drawing.Size(48, 16);
            this.checkBox_Video.TabIndex = 12;
            this.checkBox_Video.Text = "视频";
            this.checkBox_Video.UseVisualStyleBackColor = true;
            this.checkBox_Video.CheckedChanged += new System.EventHandler(this.checkBox_Video_CheckedChanged);
            // 
            // comboBox_ViewMode
            // 
            this.comboBox_ViewMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_ViewMode.FormattingEnabled = true;
            this.comboBox_ViewMode.Location = new System.Drawing.Point(74, 94);
            this.comboBox_ViewMode.Name = "comboBox_ViewMode";
            this.comboBox_ViewMode.Size = new System.Drawing.Size(219, 20);
            this.comboBox_ViewMode.TabIndex = 10;
            this.comboBox_ViewMode.SelectedIndexChanged += new System.EventHandler(this.comboBox_ViewMode_SelectedIndexChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label10.Location = new System.Drawing.Point(3, 97);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 12);
            this.label10.TabIndex = 9;
            this.label10.Text = "视图模式";
            // 
            // button_StartPlaying
            // 
            this.button_StartPlaying.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button_StartPlaying.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button_StartPlaying.Location = new System.Drawing.Point(3, 65);
            this.button_StartPlaying.Name = "button_StartPlaying";
            this.button_StartPlaying.Size = new System.Drawing.Size(290, 23);
            this.button_StartPlaying.TabIndex = 6;
            this.button_StartPlaying.Text = "开始拉流";
            this.button_StartPlaying.UseVisualStyleBackColor = true;
            this.button_StartPlaying.Click += new System.EventHandler(this.button_StartPlaying_Click);
            // 
            // textBox_PlayStreamID
            // 
            this.textBox_PlayStreamID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_PlayStreamID.Location = new System.Drawing.Point(116, 38);
            this.textBox_PlayStreamID.Name = "textBox_PlayStreamID";
            this.textBox_PlayStreamID.Size = new System.Drawing.Size(177, 21);
            this.textBox_PlayStreamID.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label6.Location = new System.Drawing.Point(49, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(143, 12);
            this.label6.TabIndex = 3;
            this.label6.Text = "Start Publishing Stream";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label7.Location = new System.Drawing.Point(3, 41);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(89, 12);
            this.label7.TabIndex = 4;
            this.label7.Text = "Play Stream ID";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold);
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(3, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "Step2";
            // 
            // Playing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.richTextBox_LogView);
            this.Name = "Playing";
            this.Size = new System.Drawing.Size(800, 600);
            this.Load += new System.EventHandler(this.Playing_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox_LogView;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label_RoomID;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label_RoomState;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label_StreamID;
        private System.Windows.Forms.Label label_StreamIDLabel;
        private System.Windows.Forms.Label label_ViewName;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button_LoginRoom;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_UserID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_RoomID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button button_StartPlaying;
        private System.Windows.Forms.TextBox textBox_PlayStreamID;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBox_ViewMode;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckBox checkBox_Audio;
        private System.Windows.Forms.CheckBox checkBox_Video;
    }
}
