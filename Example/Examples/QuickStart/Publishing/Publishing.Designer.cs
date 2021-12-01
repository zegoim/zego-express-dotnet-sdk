
namespace ZegoCsharpWinformDemo.Examples.QuickStart.Publishing
{
    partial class Publishing
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Publishing));
            this.richTextBox_LogView = new System.Windows.Forms.RichTextBox();
            this.button_StartPublishing = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_PublishStreamID = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.button_LoginRoom = new System.Windows.Forms.Button();
            this.textBox_UserID = new System.Windows.Forms.TextBox();
            this.textBox_RoomID = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.checkBox_Microphone = new System.Windows.Forms.CheckBox();
            this.checkBox_Camera = new System.Windows.Forms.CheckBox();
            this.comboBox_SwitchMicrophone = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.comboBox_SwitchCamera = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.comboBox_ViewMode = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.comboBox_MirrorMode = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
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
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // richTextBox_LogView
            // 
            resources.ApplyResources(this.richTextBox_LogView, "richTextBox_LogView");
            this.richTextBox_LogView.BackColor = System.Drawing.SystemColors.InfoText;
            this.richTextBox_LogView.ForeColor = System.Drawing.SystemColors.Info;
            this.richTextBox_LogView.Name = "richTextBox_LogView";
            this.richTextBox_LogView.ReadOnly = true;
            // 
            // button_StartPublishing
            // 
            resources.ApplyResources(this.button_StartPublishing, "button_StartPublishing");
            this.button_StartPublishing.Name = "button_StartPublishing";
            this.button_StartPublishing.UseVisualStyleBackColor = true;
            this.button_StartPublishing.Click += new System.EventHandler(this.button_StartPublishing_Click);
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // textBox_PublishStreamID
            // 
            resources.ApplyResources(this.textBox_PublishStreamID, "textBox_PublishStreamID");
            this.textBox_PublishStreamID.Name = "textBox_PublishStreamID";
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // button_LoginRoom
            // 
            resources.ApplyResources(this.button_LoginRoom, "button_LoginRoom");
            this.button_LoginRoom.Name = "button_LoginRoom";
            this.button_LoginRoom.UseVisualStyleBackColor = true;
            this.button_LoginRoom.Click += new System.EventHandler(this.button_LoginRoom_Click);
            // 
            // textBox_UserID
            // 
            resources.ApplyResources(this.textBox_UserID, "textBox_UserID");
            this.textBox_UserID.Name = "textBox_UserID";
            // 
            // textBox_RoomID
            // 
            resources.ApplyResources(this.textBox_RoomID, "textBox_RoomID");
            this.textBox_RoomID.Name = "textBox_RoomID";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // panel3
            // 
            resources.ApplyResources(this.panel3, "panel3");
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.checkBox_Microphone);
            this.panel3.Controls.Add(this.checkBox_Camera);
            this.panel3.Controls.Add(this.comboBox_SwitchMicrophone);
            this.panel3.Controls.Add(this.label14);
            this.panel3.Controls.Add(this.label13);
            this.panel3.Controls.Add(this.comboBox_SwitchCamera);
            this.panel3.Controls.Add(this.label12);
            this.panel3.Controls.Add(this.comboBox_ViewMode);
            this.panel3.Controls.Add(this.label10);
            this.panel3.Controls.Add(this.comboBox_MirrorMode);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Controls.Add(this.button_StartPublishing);
            this.panel3.Controls.Add(this.textBox_PublishStreamID);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Name = "panel3";
            // 
            // checkBox_Microphone
            // 
            resources.ApplyResources(this.checkBox_Microphone, "checkBox_Microphone");
            this.checkBox_Microphone.Name = "checkBox_Microphone";
            this.checkBox_Microphone.UseVisualStyleBackColor = true;
            this.checkBox_Microphone.CheckedChanged += new System.EventHandler(this.checkBox_Microphone_CheckedChanged);
            // 
            // checkBox_Camera
            // 
            resources.ApplyResources(this.checkBox_Camera, "checkBox_Camera");
            this.checkBox_Camera.Name = "checkBox_Camera";
            this.checkBox_Camera.UseVisualStyleBackColor = true;
            this.checkBox_Camera.CheckedChanged += new System.EventHandler(this.checkBox_Camera_CheckedChanged);
            // 
            // comboBox_SwitchMicrophone
            // 
            resources.ApplyResources(this.comboBox_SwitchMicrophone, "comboBox_SwitchMicrophone");
            this.comboBox_SwitchMicrophone.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_SwitchMicrophone.FormattingEnabled = true;
            this.comboBox_SwitchMicrophone.Name = "comboBox_SwitchMicrophone";
            this.comboBox_SwitchMicrophone.SelectedIndexChanged += new System.EventHandler(this.comboBox_SwitchMicrophone_SelectedIndexChanged);
            // 
            // label14
            // 
            resources.ApplyResources(this.label14, "label14");
            this.label14.Name = "label14";
            // 
            // label13
            // 
            resources.ApplyResources(this.label13, "label13");
            this.label13.Name = "label13";
            // 
            // comboBox_SwitchCamera
            // 
            resources.ApplyResources(this.comboBox_SwitchCamera, "comboBox_SwitchCamera");
            this.comboBox_SwitchCamera.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_SwitchCamera.FormattingEnabled = true;
            this.comboBox_SwitchCamera.Name = "comboBox_SwitchCamera";
            this.comboBox_SwitchCamera.SelectedIndexChanged += new System.EventHandler(this.comboBox_SwitchCamera_SelectedIndexChanged);
            // 
            // label12
            // 
            resources.ApplyResources(this.label12, "label12");
            this.label12.Name = "label12";
            // 
            // comboBox_ViewMode
            // 
            resources.ApplyResources(this.comboBox_ViewMode, "comboBox_ViewMode");
            this.comboBox_ViewMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_ViewMode.FormattingEnabled = true;
            this.comboBox_ViewMode.Name = "comboBox_ViewMode";
            this.comboBox_ViewMode.SelectedIndexChanged += new System.EventHandler(this.comboBox_ViewMode_SelectedIndexChanged);
            // 
            // label10
            // 
            resources.ApplyResources(this.label10, "label10");
            this.label10.Name = "label10";
            // 
            // comboBox_MirrorMode
            // 
            resources.ApplyResources(this.comboBox_MirrorMode, "comboBox_MirrorMode");
            this.comboBox_MirrorMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_MirrorMode.FormattingEnabled = true;
            this.comboBox_MirrorMode.Name = "comboBox_MirrorMode";
            this.comboBox_MirrorMode.SelectedIndexChanged += new System.EventHandler(this.comboBox_MirrorMode_SelectedIndexChanged);
            // 
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.label9.Name = "label9";
            // 
            // panel1
            // 
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.button_LoginRoom);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.textBox_UserID);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.textBox_RoomID);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Name = "panel1";
            // 
            // panel2
            // 
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Name = "panel2";
            // 
            // pictureBox1
            // 
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // panel4
            // 
            resources.ApplyResources(this.panel4, "panel4");
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.label_StreamID);
            this.panel4.Controls.Add(this.label_StreamIDLabel);
            this.panel4.Controls.Add(this.label_ViewName);
            this.panel4.Name = "panel4";
            // 
            // label_StreamID
            // 
            resources.ApplyResources(this.label_StreamID, "label_StreamID");
            this.label_StreamID.Name = "label_StreamID";
            // 
            // label_StreamIDLabel
            // 
            resources.ApplyResources(this.label_StreamIDLabel, "label_StreamIDLabel");
            this.label_StreamIDLabel.Name = "label_StreamIDLabel";
            // 
            // label_ViewName
            // 
            resources.ApplyResources(this.label_ViewName, "label_ViewName");
            this.label_ViewName.Name = "label_ViewName";
            // 
            // panel5
            // 
            resources.ApplyResources(this.panel5, "panel5");
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.label_RoomID);
            this.panel5.Controls.Add(this.label11);
            this.panel5.Controls.Add(this.label_RoomState);
            this.panel5.Controls.Add(this.label8);
            this.panel5.Name = "panel5";
            // 
            // label_RoomID
            // 
            resources.ApplyResources(this.label_RoomID, "label_RoomID");
            this.label_RoomID.Name = "label_RoomID";
            // 
            // label11
            // 
            resources.ApplyResources(this.label11, "label11");
            this.label11.Name = "label11";
            // 
            // label_RoomState
            // 
            resources.ApplyResources(this.label_RoomState, "label_RoomState");
            this.label_RoomState.Name = "label_RoomState";
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            // 
            // Publishing
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.richTextBox_LogView);
            this.Name = "Publishing";
            this.Load += new System.EventHandler(this.Publishing_Load);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.RichTextBox richTextBox_LogView;
        private System.Windows.Forms.Button button_LoginRoom;
        private System.Windows.Forms.TextBox textBox_UserID;
        private System.Windows.Forms.TextBox textBox_RoomID;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_StartPublishing;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox_PublishStreamID;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label_RoomID;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label_RoomState;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label_StreamID;
        private System.Windows.Forms.Label label_StreamIDLabel;
        private System.Windows.Forms.Label label_ViewName;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox comboBox_SwitchMicrophone;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox comboBox_SwitchCamera;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox comboBox_ViewMode;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox comboBox_MirrorMode;
        private System.Windows.Forms.CheckBox checkBox_Microphone;
        private System.Windows.Forms.CheckBox checkBox_Camera;
    }
}
