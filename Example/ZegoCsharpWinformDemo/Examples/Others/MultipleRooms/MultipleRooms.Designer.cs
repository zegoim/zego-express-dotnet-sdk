
namespace ZegoCsharpWinformDemo.Examples
{
    partial class MultipleRooms
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
            this.panel4 = new System.Windows.Forms.Panel();
            this.label_StreamID = new System.Windows.Forms.Label();
            this.label_StreamIDLabel = new System.Windows.Forms.Label();
            this.label_ViewName = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label_RoomID = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label_RoomState = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.pictureBox_Remote = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button_LoginRoom2 = new System.Windows.Forms.Button();
            this.textBox_RoomID2 = new System.Windows.Forms.TextBox();
            this.button_LoginRoom1 = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.textBox_RoomID1 = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.button_StartPublishing = new System.Windows.Forms.Button();
            this.textBox_PublishStreamID = new System.Windows.Forms.TextBox();
            this.textBox_PublishRoomID = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.listBox_RoomStreams = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Remote)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // richTextBox_LogView
            // 
            this.richTextBox_LogView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox_LogView.BackColor = System.Drawing.SystemColors.InfoText;
            this.richTextBox_LogView.ForeColor = System.Drawing.SystemColors.Info;
            this.richTextBox_LogView.Location = new System.Drawing.Point(3, 396);
            this.richTextBox_LogView.Name = "richTextBox_LogView";
            this.richTextBox_LogView.ReadOnly = true;
            this.richTextBox_LogView.Size = new System.Drawing.Size(794, 201);
            this.richTextBox_LogView.TabIndex = 4;
            this.richTextBox_LogView.Text = "";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pictureBox1.Location = new System.Drawing.Point(3, 223);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(362, 159);
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.label_StreamID);
            this.panel4.Controls.Add(this.label_StreamIDLabel);
            this.panel4.Controls.Add(this.label_ViewName);
            this.panel4.Location = new System.Drawing.Point(3, 186);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(365, 31);
            this.panel4.TabIndex = 9;
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
            this.panel5.Size = new System.Drawing.Size(365, 31);
            this.panel5.TabIndex = 10;
            // 
            // label_RoomID
            // 
            this.label_RoomID.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label_RoomID.Location = new System.Drawing.Point(50, 10);
            this.label_RoomID.Name = "label_RoomID";
            this.label_RoomID.Size = new System.Drawing.Size(102, 12);
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
            this.label_RoomState.Location = new System.Drawing.Point(217, 10);
            this.label_RoomState.Name = "label_RoomState";
            this.label_RoomState.Size = new System.Drawing.Size(143, 12);
            this.label_RoomState.TabIndex = 0;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label8.Location = new System.Drawing.Point(158, 10);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 0;
            this.label8.Text = "房间状态";
            // 
            // pictureBox_Remote
            // 
            this.pictureBox_Remote.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox_Remote.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox_Remote.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pictureBox_Remote.Location = new System.Drawing.Point(3, 164);
            this.pictureBox_Remote.Name = "pictureBox_Remote";
            this.pictureBox_Remote.Size = new System.Drawing.Size(407, 218);
            this.pictureBox_Remote.TabIndex = 11;
            this.pictureBox_Remote.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.button_LoginRoom2);
            this.panel1.Controls.Add(this.textBox_RoomID2);
            this.panel1.Controls.Add(this.button_LoginRoom1);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.textBox_RoomID1);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(373, 387);
            this.panel1.TabIndex = 12;
            // 
            // button_LoginRoom2
            // 
            this.button_LoginRoom2.Location = new System.Drawing.Point(178, 137);
            this.button_LoginRoom2.Name = "button_LoginRoom2";
            this.button_LoginRoom2.Size = new System.Drawing.Size(98, 23);
            this.button_LoginRoom2.TabIndex = 17;
            this.button_LoginRoom2.Text = "Login Room 2";
            this.button_LoginRoom2.UseVisualStyleBackColor = true;
            this.button_LoginRoom2.Click += new System.EventHandler(this.button_LoginRoom2_Click);
            // 
            // textBox_RoomID2
            // 
            this.textBox_RoomID2.Location = new System.Drawing.Point(72, 137);
            this.textBox_RoomID2.Name = "textBox_RoomID2";
            this.textBox_RoomID2.Size = new System.Drawing.Size(100, 21);
            this.textBox_RoomID2.TabIndex = 16;
            // 
            // button_LoginRoom1
            // 
            this.button_LoginRoom1.Location = new System.Drawing.Point(178, 92);
            this.button_LoginRoom1.Name = "button_LoginRoom1";
            this.button_LoginRoom1.Size = new System.Drawing.Size(98, 23);
            this.button_LoginRoom1.TabIndex = 17;
            this.button_LoginRoom1.Text = "Login Room 1";
            this.button_LoginRoom1.UseVisualStyleBackColor = true;
            this.button_LoginRoom1.Click += new System.EventHandler(this.button_LoginRoom1_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(8, 142);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(47, 12);
            this.label12.TabIndex = 15;
            this.label12.Text = "Room ID";
            // 
            // textBox_RoomID1
            // 
            this.textBox_RoomID1.Location = new System.Drawing.Point(72, 92);
            this.textBox_RoomID1.Name = "textBox_RoomID1";
            this.textBox_RoomID1.Size = new System.Drawing.Size(100, 21);
            this.textBox_RoomID1.TabIndex = 16;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label14.Location = new System.Drawing.Point(56, 171);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(101, 12);
            this.label14.TabIndex = 14;
            this.label14.Text = "Publish and play";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label10.Location = new System.Drawing.Point(54, 123);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(77, 12);
            this.label10.TabIndex = 14;
            this.label10.Text = "Login Room 2";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold);
            this.label13.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label13.Location = new System.Drawing.Point(8, 171);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(40, 12);
            this.label13.TabIndex = 13;
            this.label13.Text = "Step3";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 97);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 12);
            this.label7.TabIndex = 15;
            this.label7.Text = "Room ID";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold);
            this.label9.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label9.Location = new System.Drawing.Point(8, 123);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(40, 12);
            this.label9.TabIndex = 13;
            this.label9.Text = "Step2";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(54, 78);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 12);
            this.label5.TabIndex = 14;
            this.label5.Text = "Login Room 1";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold);
            this.label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label6.Location = new System.Drawing.Point(8, 78);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 12);
            this.label6.TabIndex = 13;
            this.label6.Text = "Step1";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(7, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(363, 41);
            this.label4.TabIndex = 12;
            this.label4.Text = "Support logging in multi rooms.Please contact ZEGO technical support for the maxi" +
    "mum number of rooms supported. ";
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panel3.Controls.Add(this.button_StartPublishing);
            this.panel3.Controls.Add(this.textBox_PublishStreamID);
            this.panel3.Controls.Add(this.textBox_PublishRoomID);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Location = new System.Drawing.Point(56, 282);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(263, 100);
            this.panel3.TabIndex = 11;
            // 
            // button_StartPublishing
            // 
            this.button_StartPublishing.Location = new System.Drawing.Point(22, 74);
            this.button_StartPublishing.Name = "button_StartPublishing";
            this.button_StartPublishing.Size = new System.Drawing.Size(208, 23);
            this.button_StartPublishing.TabIndex = 4;
            this.button_StartPublishing.Text = "Start Publishing";
            this.button_StartPublishing.UseVisualStyleBackColor = true;
            this.button_StartPublishing.Click += new System.EventHandler(this.button_StartPublishing_Click);
            // 
            // textBox_PublishStreamID
            // 
            this.textBox_PublishStreamID.Location = new System.Drawing.Point(90, 47);
            this.textBox_PublishStreamID.Name = "textBox_PublishStreamID";
            this.textBox_PublishStreamID.Size = new System.Drawing.Size(140, 21);
            this.textBox_PublishStreamID.TabIndex = 3;
            // 
            // textBox_PublishRoomID
            // 
            this.textBox_PublishRoomID.Location = new System.Drawing.Point(90, 14);
            this.textBox_PublishRoomID.Name = "textBox_PublishRoomID";
            this.textBox_PublishRoomID.Size = new System.Drawing.Size(140, 21);
            this.textBox_PublishRoomID.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 1;
            this.label3.Text = "Stream ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "Room ID";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.listBox_RoomStreams);
            this.panel2.Controls.Add(this.pictureBox_Remote);
            this.panel2.Location = new System.Drawing.Point(382, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(415, 387);
            this.panel2.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 13;
            this.label1.Text = "远端流列表";
            // 
            // listBox_RoomStreams
            // 
            this.listBox_RoomStreams.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBox_RoomStreams.FormattingEnabled = true;
            this.listBox_RoomStreams.ItemHeight = 12;
            this.listBox_RoomStreams.Location = new System.Drawing.Point(3, 24);
            this.listBox_RoomStreams.Name = "listBox_RoomStreams";
            this.listBox_RoomStreams.Size = new System.Drawing.Size(409, 136);
            this.listBox_RoomStreams.TabIndex = 12;
            this.listBox_RoomStreams.SelectedIndexChanged += new System.EventHandler(this.listBox_RoomStreams_SelectedIndexChanged);
            // 
            // MultipleRooms
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.richTextBox_LogView);
            this.Name = "MultipleRooms";
            this.Size = new System.Drawing.Size(800, 600);
            this.Load += new System.EventHandler(this.MultipleRooms_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Remote)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox_LogView;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label_StreamID;
        private System.Windows.Forms.Label label_StreamIDLabel;
        private System.Windows.Forms.Label label_ViewName;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label_RoomID;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label_RoomState;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.PictureBox pictureBox_Remote;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ListBox listBox_RoomStreams;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button button_StartPublishing;
        private System.Windows.Forms.TextBox textBox_PublishStreamID;
        private System.Windows.Forms.TextBox textBox_PublishRoomID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button_LoginRoom1;
        private System.Windows.Forms.TextBox textBox_RoomID1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button_LoginRoom2;
        private System.Windows.Forms.TextBox textBox_RoomID2;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
    }
}
