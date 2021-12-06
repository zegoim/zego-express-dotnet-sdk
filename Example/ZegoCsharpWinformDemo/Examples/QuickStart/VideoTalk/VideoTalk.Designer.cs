
namespace ZegoCsharpWinformDemo.Examples
{
    partial class VideoTalk
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage_LoginRoom = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button_LoginRoom = new System.Windows.Forms.Button();
            this.textBox_PublishStreamID = new System.Windows.Forms.TextBox();
            this.textBox_UserID = new System.Windows.Forms.TextBox();
            this.textBox_RoomID = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage_VideoTalk = new System.Windows.Forms.TabPage();
            this.button_Stop = new System.Windows.Forms.Button();
            this.richTextBox_LogView = new System.Windows.Forms.RichTextBox();
            this.pictureBox_Remote = new System.Windows.Forms.PictureBox();
            this.pictureBox_Local = new System.Windows.Forms.PictureBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label_StreamID = new System.Windows.Forms.Label();
            this.label_StreamIDLabel = new System.Windows.Forms.Label();
            this.label_ViewName = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label_RemoteUserID = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label_RemoteStreamID = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label_RoomID = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label_RoomState = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage_LoginRoom.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabPage_VideoTalk.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Remote)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Local)).BeginInit();
            this.panel4.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabControl1.Controls.Add(this.tabPage_LoginRoom);
            this.tabControl1.Controls.Add(this.tabPage_VideoTalk);
            this.tabControl1.ItemSize = new System.Drawing.Size(0, 1);
            this.tabControl1.Location = new System.Drawing.Point(3, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(794, 594);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage_LoginRoom
            // 
            this.tabPage_LoginRoom.Controls.Add(this.panel1);
            this.tabPage_LoginRoom.Location = new System.Drawing.Point(4, 5);
            this.tabPage_LoginRoom.Name = "tabPage_LoginRoom";
            this.tabPage_LoginRoom.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_LoginRoom.Size = new System.Drawing.Size(786, 585);
            this.tabPage_LoginRoom.TabIndex = 0;
            this.tabPage_LoginRoom.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button_LoginRoom);
            this.panel1.Controls.Add(this.textBox_PublishStreamID);
            this.panel1.Controls.Add(this.textBox_UserID);
            this.panel1.Controls.Add(this.textBox_RoomID);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(103, 103);
            this.panel1.Margin = new System.Windows.Forms.Padding(100);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(580, 379);
            this.panel1.TabIndex = 0;
            // 
            // button_LoginRoom
            // 
            this.button_LoginRoom.Location = new System.Drawing.Point(257, 332);
            this.button_LoginRoom.Name = "button_LoginRoom";
            this.button_LoginRoom.Size = new System.Drawing.Size(75, 23);
            this.button_LoginRoom.TabIndex = 3;
            this.button_LoginRoom.Text = "Login Room";
            this.button_LoginRoom.UseVisualStyleBackColor = true;
            this.button_LoginRoom.Click += new System.EventHandler(this.button_LoginRoom_Click);
            // 
            // textBox_PublishStreamID
            // 
            this.textBox_PublishStreamID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_PublishStreamID.Location = new System.Drawing.Point(157, 289);
            this.textBox_PublishStreamID.Name = "textBox_PublishStreamID";
            this.textBox_PublishStreamID.Size = new System.Drawing.Size(373, 21);
            this.textBox_PublishStreamID.TabIndex = 2;
            // 
            // textBox_UserID
            // 
            this.textBox_UserID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_UserID.Location = new System.Drawing.Point(157, 204);
            this.textBox_UserID.Name = "textBox_UserID";
            this.textBox_UserID.Size = new System.Drawing.Size(373, 21);
            this.textBox_UserID.TabIndex = 2;
            // 
            // textBox_RoomID
            // 
            this.textBox_RoomID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_RoomID.Location = new System.Drawing.Point(157, 124);
            this.textBox_RoomID.Name = "textBox_RoomID";
            this.textBox_RoomID.Size = new System.Drawing.Size(373, 21);
            this.textBox_RoomID.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.Location = new System.Drawing.Point(50, 292);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(101, 12);
            this.label7.TabIndex = 1;
            this.label7.Text = "Publish StreamID";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.Location = new System.Drawing.Point(50, 207);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(101, 12);
            this.label5.TabIndex = 1;
            this.label5.Text = "UserID";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.Location = new System.Drawing.Point(50, 127);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "RoomID";
            // 
            // label6
            // 
            this.label6.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label6.Location = new System.Drawing.Point(50, 253);
            this.label6.Margin = new System.Windows.Forms.Padding(50, 0, 50, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(480, 24);
            this.label6.TabIndex = 1;
            this.label6.Text = "The StreamID should be generated by the developer and must be globally unique und" +
    "er the same AppID";
            // 
            // label4
            // 
            this.label4.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label4.Location = new System.Drawing.Point(50, 168);
            this.label4.Margin = new System.Windows.Forms.Padding(50, 0, 50, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(480, 24);
            this.label4.TabIndex = 1;
            this.label4.Text = "UserID should be generated by the developer and must be globally unique under the" +
    " same AppID";
            // 
            // label3
            // 
            this.label3.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label3.Location = new System.Drawing.Point(50, 88);
            this.label3.Margin = new System.Windows.Forms.Padding(50, 0, 50, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(480, 24);
            this.label3.TabIndex = 1;
            this.label3.Text = "If you want to talk to other users, you need to join the same room, which means t" +
    "hat the RoomIDs of both parties should be the same";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Font = new System.Drawing.Font("宋体", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(574, 47);
            this.label1.TabIndex = 0;
            this.label1.Text = "Login Room";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabPage_VideoTalk
            // 
            this.tabPage_VideoTalk.Controls.Add(this.button_Stop);
            this.tabPage_VideoTalk.Controls.Add(this.richTextBox_LogView);
            this.tabPage_VideoTalk.Controls.Add(this.pictureBox_Remote);
            this.tabPage_VideoTalk.Controls.Add(this.pictureBox_Local);
            this.tabPage_VideoTalk.Controls.Add(this.panel4);
            this.tabPage_VideoTalk.Controls.Add(this.panel2);
            this.tabPage_VideoTalk.Controls.Add(this.panel5);
            this.tabPage_VideoTalk.Location = new System.Drawing.Point(4, 5);
            this.tabPage_VideoTalk.Name = "tabPage_VideoTalk";
            this.tabPage_VideoTalk.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_VideoTalk.Size = new System.Drawing.Size(786, 585);
            this.tabPage_VideoTalk.TabIndex = 1;
            this.tabPage_VideoTalk.UseVisualStyleBackColor = true;
            // 
            // button_Stop
            // 
            this.button_Stop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_Stop.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_Stop.ForeColor = System.Drawing.Color.Red;
            this.button_Stop.Location = new System.Drawing.Point(492, 327);
            this.button_Stop.Name = "button_Stop";
            this.button_Stop.Size = new System.Drawing.Size(288, 23);
            this.button_Stop.TabIndex = 13;
            this.button_Stop.Text = "Stop";
            this.button_Stop.UseVisualStyleBackColor = true;
            this.button_Stop.Click += new System.EventHandler(this.button_Stop_Click);
            // 
            // richTextBox_LogView
            // 
            this.richTextBox_LogView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox_LogView.BackColor = System.Drawing.SystemColors.InfoText;
            this.richTextBox_LogView.ForeColor = System.Drawing.SystemColors.Info;
            this.richTextBox_LogView.Location = new System.Drawing.Point(6, 356);
            this.richTextBox_LogView.Name = "richTextBox_LogView";
            this.richTextBox_LogView.ReadOnly = true;
            this.richTextBox_LogView.Size = new System.Drawing.Size(774, 223);
            this.richTextBox_LogView.TabIndex = 12;
            this.richTextBox_LogView.Text = "";
            // 
            // pictureBox_Remote
            // 
            this.pictureBox_Remote.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox_Remote.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox_Remote.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pictureBox_Remote.Location = new System.Drawing.Point(492, 43);
            this.pictureBox_Remote.Name = "pictureBox_Remote";
            this.pictureBox_Remote.Size = new System.Drawing.Size(288, 278);
            this.pictureBox_Remote.TabIndex = 11;
            this.pictureBox_Remote.TabStop = false;
            // 
            // pictureBox_Local
            // 
            this.pictureBox_Local.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox_Local.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox_Local.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pictureBox_Local.Location = new System.Drawing.Point(6, 80);
            this.pictureBox_Local.Name = "pictureBox_Local";
            this.pictureBox_Local.Size = new System.Drawing.Size(480, 270);
            this.pictureBox_Local.TabIndex = 11;
            this.pictureBox_Local.TabStop = false;
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.label_StreamID);
            this.panel4.Controls.Add(this.label_StreamIDLabel);
            this.panel4.Controls.Add(this.label_ViewName);
            this.panel4.Location = new System.Drawing.Point(6, 43);
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
            this.label_ViewName.Text = "预览";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label_RemoteUserID);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.label_RemoteStreamID);
            this.panel2.Controls.Add(this.label13);
            this.panel2.Location = new System.Drawing.Point(492, 6);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(288, 31);
            this.panel2.TabIndex = 9;
            // 
            // label_RemoteUserID
            // 
            this.label_RemoteUserID.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label_RemoteUserID.Location = new System.Drawing.Point(50, 10);
            this.label_RemoteUserID.Name = "label_RemoteUserID";
            this.label_RemoteUserID.Size = new System.Drawing.Size(73, 12);
            this.label_RemoteUserID.TabIndex = 1;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label10.Location = new System.Drawing.Point(3, 10);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 12);
            this.label10.TabIndex = 0;
            this.label10.Text = "用户ID";
            // 
            // label_RemoteStreamID
            // 
            this.label_RemoteStreamID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label_RemoteStreamID.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label_RemoteStreamID.Location = new System.Drawing.Point(164, 10);
            this.label_RemoteStreamID.Name = "label_RemoteStreamID";
            this.label_RemoteStreamID.Size = new System.Drawing.Size(119, 12);
            this.label_RemoteStreamID.TabIndex = 0;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label13.Location = new System.Drawing.Point(129, 10);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(29, 12);
            this.label13.TabIndex = 0;
            this.label13.Text = "流ID";
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
            this.panel5.Location = new System.Drawing.Point(6, 6);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(480, 31);
            this.panel5.TabIndex = 9;
            // 
            // label_RoomID
            // 
            this.label_RoomID.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label_RoomID.Location = new System.Drawing.Point(50, 10);
            this.label_RoomID.Name = "label_RoomID";
            this.label_RoomID.Size = new System.Drawing.Size(73, 12);
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
            this.label_RoomState.Location = new System.Drawing.Point(188, 10);
            this.label_RoomState.Name = "label_RoomState";
            this.label_RoomState.Size = new System.Drawing.Size(287, 12);
            this.label_RoomState.TabIndex = 0;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label8.Location = new System.Drawing.Point(129, 10);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 0;
            this.label8.Text = "房间状态";
            // 
            // VideoTalk
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Name = "VideoTalk";
            this.Size = new System.Drawing.Size(800, 600);
            this.Load += new System.EventHandler(this.VideoTalk_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage_LoginRoom.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabPage_VideoTalk.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Remote)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Local)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage_LoginRoom;
        private System.Windows.Forms.TabPage tabPage_VideoTalk;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_RoomID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_PublishStreamID;
        private System.Windows.Forms.TextBox textBox_UserID;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button_LoginRoom;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label_RoomID;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label_RoomState;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label_StreamID;
        private System.Windows.Forms.Label label_StreamIDLabel;
        private System.Windows.Forms.Label label_ViewName;
        private System.Windows.Forms.PictureBox pictureBox_Local;
        private System.Windows.Forms.RichTextBox richTextBox_LogView;
        private System.Windows.Forms.PictureBox pictureBox_Remote;
        private System.Windows.Forms.Button button_Stop;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label_RemoteUserID;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label_RemoteStreamID;
        private System.Windows.Forms.Label label13;
    }
}
