
namespace ZegoCsharpWinformDemo.Examples
{
    partial class CopyrightedMusic
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
            this.panel1 = new System.Windows.Forms.Panel();
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.checkBox_Repeat = new System.Windows.Forms.CheckBox();
            this.checkBox_EnableAux = new System.Windows.Forms.CheckBox();
            this.trackBar_Volume = new System.Windows.Forms.TrackBar();
            this.progressBar_MediaPlay = new System.Windows.Forms.ProgressBar();
            this.button_Stop = new System.Windows.Forms.Button();
            this.button_Resume = new System.Windows.Forms.Button();
            this.button_Pause = new System.Windows.Forms.Button();
            this.button_Play = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox_BillingMode = new System.Windows.Forms.ComboBox();
            this.button_GetKrcLyric = new System.Windows.Forms.Button();
            this.button_GetLrcLyric = new System.Windows.Forms.Button();
            this.button_GetSong = new System.Windows.Forms.Button();
            this.button_GetAccompaniment = new System.Windows.Forms.Button();
            this.button_Download = new System.Windows.Forms.Button();
            this.textBox_CacheSize = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.progressBar_Download = new System.Windows.Forms.ProgressBar();
            this.button_ClearCache = new System.Windows.Forms.Button();
            this.button_SendRequest = new System.Windows.Forms.Button();
            this.listBox_ResourceIDList = new System.Windows.Forms.ListBox();
            this.listBox_SoundIDList = new System.Windows.Forms.ListBox();
            this.listBox_RequestList = new System.Windows.Forms.ListBox();
            this.richTextBox_LogView = new System.Windows.Forms.RichTextBox();
            this.panel6 = new System.Windows.Forms.Panel();
            this.button_StartPublishing = new System.Windows.Forms.Button();
            this.button_LoginRoom = new System.Windows.Forms.Button();
            this.textBox_PublishStreamID = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox_UserID = new System.Windows.Forms.TextBox();
            this.textBox_RoomID = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_MusicToken = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_Volume)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(382, 281);
            this.panel1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pictureBox1.Location = new System.Drawing.Point(3, 77);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(376, 201);
            this.pictureBox1.TabIndex = 11;
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
            this.panel4.Location = new System.Drawing.Point(3, 40);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(376, 31);
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
            this.panel5.Size = new System.Drawing.Size(376, 31);
            this.panel5.TabIndex = 9;
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
            this.label_RoomState.Size = new System.Drawing.Size(154, 12);
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
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.checkBox_Repeat);
            this.panel2.Controls.Add(this.checkBox_EnableAux);
            this.panel2.Controls.Add(this.trackBar_Volume);
            this.panel2.Controls.Add(this.progressBar_MediaPlay);
            this.panel2.Controls.Add(this.button_Stop);
            this.panel2.Controls.Add(this.button_Resume);
            this.panel2.Controls.Add(this.button_Pause);
            this.panel2.Controls.Add(this.button_Play);
            this.panel2.Location = new System.Drawing.Point(391, 323);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(406, 87);
            this.panel2.TabIndex = 1;
            // 
            // checkBox_Repeat
            // 
            this.checkBox_Repeat.AutoSize = true;
            this.checkBox_Repeat.Location = new System.Drawing.Point(93, 3);
            this.checkBox_Repeat.Name = "checkBox_Repeat";
            this.checkBox_Repeat.Size = new System.Drawing.Size(60, 16);
            this.checkBox_Repeat.TabIndex = 9;
            this.checkBox_Repeat.Text = "Repeat";
            this.checkBox_Repeat.UseVisualStyleBackColor = true;
            this.checkBox_Repeat.CheckedChanged += new System.EventHandler(this.checkBox_Repeat_CheckedChanged);
            // 
            // checkBox_EnableAux
            // 
            this.checkBox_EnableAux.AutoSize = true;
            this.checkBox_EnableAux.Location = new System.Drawing.Point(3, 3);
            this.checkBox_EnableAux.Name = "checkBox_EnableAux";
            this.checkBox_EnableAux.Size = new System.Drawing.Size(84, 16);
            this.checkBox_EnableAux.TabIndex = 8;
            this.checkBox_EnableAux.Text = "Enable Aux";
            this.checkBox_EnableAux.UseVisualStyleBackColor = true;
            this.checkBox_EnableAux.CheckedChanged += new System.EventHandler(this.checkBox_EnableAux_CheckedChanged);
            // 
            // trackBar_Volume
            // 
            this.trackBar_Volume.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBar_Volume.AutoSize = false;
            this.trackBar_Volume.Location = new System.Drawing.Point(327, 32);
            this.trackBar_Volume.Name = "trackBar_Volume";
            this.trackBar_Volume.Size = new System.Drawing.Size(76, 23);
            this.trackBar_Volume.TabIndex = 7;
            this.trackBar_Volume.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBar_Volume.Scroll += new System.EventHandler(this.trackBar_Volume_Scroll);
            // 
            // progressBar_MediaPlay
            // 
            this.progressBar_MediaPlay.Location = new System.Drawing.Point(3, 61);
            this.progressBar_MediaPlay.Name = "progressBar_MediaPlay";
            this.progressBar_MediaPlay.Size = new System.Drawing.Size(400, 23);
            this.progressBar_MediaPlay.TabIndex = 4;
            // 
            // button_Stop
            // 
            this.button_Stop.Location = new System.Drawing.Point(246, 32);
            this.button_Stop.Name = "button_Stop";
            this.button_Stop.Size = new System.Drawing.Size(75, 23);
            this.button_Stop.TabIndex = 3;
            this.button_Stop.Text = "停止";
            this.button_Stop.UseVisualStyleBackColor = true;
            this.button_Stop.Click += new System.EventHandler(this.button_Stop_Click);
            // 
            // button_Resume
            // 
            this.button_Resume.Location = new System.Drawing.Point(165, 32);
            this.button_Resume.Name = "button_Resume";
            this.button_Resume.Size = new System.Drawing.Size(75, 23);
            this.button_Resume.TabIndex = 2;
            this.button_Resume.Text = "恢复";
            this.button_Resume.UseVisualStyleBackColor = true;
            this.button_Resume.Click += new System.EventHandler(this.button_Resume_Click);
            // 
            // button_Pause
            // 
            this.button_Pause.Location = new System.Drawing.Point(84, 32);
            this.button_Pause.Name = "button_Pause";
            this.button_Pause.Size = new System.Drawing.Size(75, 23);
            this.button_Pause.TabIndex = 1;
            this.button_Pause.Text = "暂停";
            this.button_Pause.UseVisualStyleBackColor = true;
            this.button_Pause.Click += new System.EventHandler(this.button_Pause_Click);
            // 
            // button_Play
            // 
            this.button_Play.Location = new System.Drawing.Point(3, 32);
            this.button_Play.Name = "button_Play";
            this.button_Play.Size = new System.Drawing.Size(75, 23);
            this.button_Play.TabIndex = 0;
            this.button_Play.Text = "播放";
            this.button_Play.UseVisualStyleBackColor = true;
            this.button_Play.Click += new System.EventHandler(this.button_Play_Click);
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.comboBox_BillingMode);
            this.panel3.Controls.Add(this.textBox_MusicToken);
            this.panel3.Controls.Add(this.button_GetKrcLyric);
            this.panel3.Controls.Add(this.button_GetLrcLyric);
            this.panel3.Controls.Add(this.button_GetSong);
            this.panel3.Controls.Add(this.button_GetAccompaniment);
            this.panel3.Controls.Add(this.button_Download);
            this.panel3.Controls.Add(this.textBox_CacheSize);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.progressBar_Download);
            this.panel3.Controls.Add(this.button_ClearCache);
            this.panel3.Controls.Add(this.button_SendRequest);
            this.panel3.Controls.Add(this.listBox_ResourceIDList);
            this.panel3.Controls.Add(this.listBox_SoundIDList);
            this.panel3.Controls.Add(this.listBox_RequestList);
            this.panel3.Location = new System.Drawing.Point(391, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(406, 314);
            this.panel3.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(127, 156);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 10;
            this.label2.Text = "计费模式";
            // 
            // comboBox_BillingMode
            // 
            this.comboBox_BillingMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_BillingMode.FormattingEnabled = true;
            this.comboBox_BillingMode.Location = new System.Drawing.Point(127, 174);
            this.comboBox_BillingMode.Name = "comboBox_BillingMode";
            this.comboBox_BillingMode.Size = new System.Drawing.Size(114, 20);
            this.comboBox_BillingMode.TabIndex = 9;
            this.comboBox_BillingMode.SelectedIndexChanged += new System.EventHandler(this.comboBox_BillingMode_SelectedIndexChanged);
            // 
            // button_GetKrcLyric
            // 
            this.button_GetKrcLyric.Location = new System.Drawing.Point(288, 286);
            this.button_GetKrcLyric.Name = "button_GetKrcLyric";
            this.button_GetKrcLyric.Size = new System.Drawing.Size(115, 23);
            this.button_GetKrcLyric.TabIndex = 8;
            this.button_GetKrcLyric.Text = "Get KrcLyric";
            this.button_GetKrcLyric.UseVisualStyleBackColor = true;
            this.button_GetKrcLyric.Click += new System.EventHandler(this.button_GetKrcLyric_Click);
            // 
            // button_GetLrcLyric
            // 
            this.button_GetLrcLyric.Location = new System.Drawing.Point(126, 258);
            this.button_GetLrcLyric.Name = "button_GetLrcLyric";
            this.button_GetLrcLyric.Size = new System.Drawing.Size(115, 23);
            this.button_GetLrcLyric.TabIndex = 8;
            this.button_GetLrcLyric.Text = "Get LrcLyric";
            this.button_GetLrcLyric.UseVisualStyleBackColor = true;
            this.button_GetLrcLyric.Click += new System.EventHandler(this.button_GetLrcLyric_Click);
            // 
            // button_GetSong
            // 
            this.button_GetSong.Location = new System.Drawing.Point(126, 229);
            this.button_GetSong.Name = "button_GetSong";
            this.button_GetSong.Size = new System.Drawing.Size(115, 23);
            this.button_GetSong.TabIndex = 8;
            this.button_GetSong.Text = "Get Song";
            this.button_GetSong.UseVisualStyleBackColor = true;
            this.button_GetSong.Click += new System.EventHandler(this.button_GetSong_Click);
            // 
            // button_GetAccompaniment
            // 
            this.button_GetAccompaniment.Location = new System.Drawing.Point(126, 200);
            this.button_GetAccompaniment.Name = "button_GetAccompaniment";
            this.button_GetAccompaniment.Size = new System.Drawing.Size(115, 23);
            this.button_GetAccompaniment.TabIndex = 7;
            this.button_GetAccompaniment.Text = "Get Accompaniment";
            this.button_GetAccompaniment.UseVisualStyleBackColor = true;
            this.button_GetAccompaniment.Click += new System.EventHandler(this.button_GetAccompaniment_Click);
            // 
            // button_Download
            // 
            this.button_Download.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button_Download.Location = new System.Drawing.Point(246, 172);
            this.button_Download.Name = "button_Download";
            this.button_Download.Size = new System.Drawing.Size(156, 23);
            this.button_Download.TabIndex = 6;
            this.button_Download.Text = "Download";
            this.button_Download.UseVisualStyleBackColor = true;
            this.button_Download.Click += new System.EventHandler(this.button_Download_Click);
            // 
            // textBox_CacheSize
            // 
            this.textBox_CacheSize.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_CacheSize.Location = new System.Drawing.Point(247, 230);
            this.textBox_CacheSize.Name = "textBox_CacheSize";
            this.textBox_CacheSize.ReadOnly = true;
            this.textBox_CacheSize.Size = new System.Drawing.Size(153, 21);
            this.textBox_CacheSize.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(247, 215);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "Cache Size(byte)";
            // 
            // progressBar_Download
            // 
            this.progressBar_Download.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar_Download.Location = new System.Drawing.Point(246, 156);
            this.progressBar_Download.Name = "progressBar_Download";
            this.progressBar_Download.Size = new System.Drawing.Size(156, 10);
            this.progressBar_Download.TabIndex = 3;
            // 
            // button_ClearCache
            // 
            this.button_ClearCache.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button_ClearCache.Location = new System.Drawing.Point(247, 257);
            this.button_ClearCache.Name = "button_ClearCache";
            this.button_ClearCache.Size = new System.Drawing.Size(157, 23);
            this.button_ClearCache.TabIndex = 2;
            this.button_ClearCache.Text = "Clear Cache";
            this.button_ClearCache.UseVisualStyleBackColor = true;
            this.button_ClearCache.Click += new System.EventHandler(this.button_ClearCache_Click);
            // 
            // button_SendRequest
            // 
            this.button_SendRequest.Location = new System.Drawing.Point(3, 258);
            this.button_SendRequest.Name = "button_SendRequest";
            this.button_SendRequest.Size = new System.Drawing.Size(117, 23);
            this.button_SendRequest.TabIndex = 1;
            this.button_SendRequest.Text = "Send Request";
            this.button_SendRequest.UseVisualStyleBackColor = true;
            this.button_SendRequest.Click += new System.EventHandler(this.button_SendRequest_Click);
            // 
            // listBox_ResourceIDList
            // 
            this.listBox_ResourceIDList.FormattingEnabled = true;
            this.listBox_ResourceIDList.ItemHeight = 12;
            this.listBox_ResourceIDList.Location = new System.Drawing.Point(246, 3);
            this.listBox_ResourceIDList.Name = "listBox_ResourceIDList";
            this.listBox_ResourceIDList.Size = new System.Drawing.Size(156, 148);
            this.listBox_ResourceIDList.TabIndex = 0;
            this.listBox_ResourceIDList.SelectedIndexChanged += new System.EventHandler(this.listBox_ResourceIDList_SelectedIndexChanged);
            // 
            // listBox_SoundIDList
            // 
            this.listBox_SoundIDList.FormattingEnabled = true;
            this.listBox_SoundIDList.ItemHeight = 12;
            this.listBox_SoundIDList.Location = new System.Drawing.Point(126, 3);
            this.listBox_SoundIDList.Name = "listBox_SoundIDList";
            this.listBox_SoundIDList.Size = new System.Drawing.Size(114, 148);
            this.listBox_SoundIDList.TabIndex = 0;
            this.listBox_SoundIDList.SelectedIndexChanged += new System.EventHandler(this.listBox_SoundIDList_SelectedIndexChanged);
            // 
            // listBox_RequestList
            // 
            this.listBox_RequestList.FormattingEnabled = true;
            this.listBox_RequestList.ItemHeight = 12;
            this.listBox_RequestList.Location = new System.Drawing.Point(3, 3);
            this.listBox_RequestList.Name = "listBox_RequestList";
            this.listBox_RequestList.Size = new System.Drawing.Size(117, 244);
            this.listBox_RequestList.TabIndex = 0;
            this.listBox_RequestList.SelectedIndexChanged += new System.EventHandler(this.listBox_RequestList_SelectedIndexChanged);
            // 
            // richTextBox_LogView
            // 
            this.richTextBox_LogView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox_LogView.BackColor = System.Drawing.SystemColors.InfoText;
            this.richTextBox_LogView.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.richTextBox_LogView.ForeColor = System.Drawing.SystemColors.Info;
            this.richTextBox_LogView.Location = new System.Drawing.Point(3, 416);
            this.richTextBox_LogView.Name = "richTextBox_LogView";
            this.richTextBox_LogView.ReadOnly = true;
            this.richTextBox_LogView.Size = new System.Drawing.Size(794, 181);
            this.richTextBox_LogView.TabIndex = 4;
            this.richTextBox_LogView.Text = "";
            // 
            // panel6
            // 
            this.panel6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel6.Controls.Add(this.button_StartPublishing);
            this.panel6.Controls.Add(this.button_LoginRoom);
            this.panel6.Controls.Add(this.textBox_PublishStreamID);
            this.panel6.Controls.Add(this.label7);
            this.panel6.Controls.Add(this.textBox_UserID);
            this.panel6.Controls.Add(this.textBox_RoomID);
            this.panel6.Controls.Add(this.label3);
            this.panel6.Controls.Add(this.label4);
            this.panel6.Location = new System.Drawing.Point(3, 290);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(382, 120);
            this.panel6.TabIndex = 6;
            // 
            // button_StartPublishing
            // 
            this.button_StartPublishing.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button_StartPublishing.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button_StartPublishing.Location = new System.Drawing.Point(3, 86);
            this.button_StartPublishing.Name = "button_StartPublishing";
            this.button_StartPublishing.Size = new System.Drawing.Size(374, 23);
            this.button_StartPublishing.TabIndex = 9;
            this.button_StartPublishing.Text = "Start Publishing";
            this.button_StartPublishing.UseVisualStyleBackColor = true;
            this.button_StartPublishing.Click += new System.EventHandler(this.button_StartPublishing_Click);
            // 
            // button_LoginRoom
            // 
            this.button_LoginRoom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button_LoginRoom.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button_LoginRoom.Location = new System.Drawing.Point(3, 30);
            this.button_LoginRoom.Name = "button_LoginRoom";
            this.button_LoginRoom.Size = new System.Drawing.Size(374, 23);
            this.button_LoginRoom.TabIndex = 6;
            this.button_LoginRoom.Text = "Login Room";
            this.button_LoginRoom.UseVisualStyleBackColor = true;
            this.button_LoginRoom.Click += new System.EventHandler(this.button_LoginRoom_Click);
            // 
            // textBox_PublishStreamID
            // 
            this.textBox_PublishStreamID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_PublishStreamID.Location = new System.Drawing.Point(116, 59);
            this.textBox_PublishStreamID.Name = "textBox_PublishStreamID";
            this.textBox_PublishStreamID.Size = new System.Drawing.Size(261, 21);
            this.textBox_PublishStreamID.TabIndex = 8;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label7.Location = new System.Drawing.Point(3, 62);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(107, 12);
            this.label7.TabIndex = 7;
            this.label7.Text = "Publish Stream ID";
            // 
            // textBox_UserID
            // 
            this.textBox_UserID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_UserID.Location = new System.Drawing.Point(215, 3);
            this.textBox_UserID.Name = "textBox_UserID";
            this.textBox_UserID.Size = new System.Drawing.Size(162, 21);
            this.textBox_UserID.TabIndex = 5;
            // 
            // textBox_RoomID
            // 
            this.textBox_RoomID.Location = new System.Drawing.Point(55, 3);
            this.textBox_RoomID.Name = "textBox_RoomID";
            this.textBox_RoomID.Size = new System.Drawing.Size(107, 21);
            this.textBox_RoomID.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(8, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "RoomID";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(168, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 4;
            this.label4.Text = "UserID";
            // 
            // textBox_MusicToken
            // 
            this.textBox_MusicToken.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_MusicToken.Location = new System.Drawing.Point(3, 288);
            this.textBox_MusicToken.Name = "textBox_MusicToken";
            this.textBox_MusicToken.Size = new System.Drawing.Size(279, 21);
            this.textBox_MusicToken.TabIndex = 8;
            // 
            // CopyrightedMusic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.richTextBox_LogView);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "CopyrightedMusic";
            this.Size = new System.Drawing.Size(800, 600);
            this.Load += new System.EventHandler(this.CopyrightedMusic_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_Volume)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label_RoomID;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label_RoomState;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label_StreamID;
        private System.Windows.Forms.Label label_StreamIDLabel;
        private System.Windows.Forms.Label label_ViewName;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.RichTextBox richTextBox_LogView;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Button button_LoginRoom;
        private System.Windows.Forms.TextBox textBox_UserID;
        private System.Windows.Forms.TextBox textBox_RoomID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button_StartPublishing;
        private System.Windows.Forms.TextBox textBox_PublishStreamID;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ProgressBar progressBar_MediaPlay;
        private System.Windows.Forms.Button button_Stop;
        private System.Windows.Forms.Button button_Resume;
        private System.Windows.Forms.Button button_Pause;
        private System.Windows.Forms.Button button_Play;
        private System.Windows.Forms.TrackBar trackBar_Volume;
        private System.Windows.Forms.CheckBox checkBox_EnableAux;
        private System.Windows.Forms.CheckBox checkBox_Repeat;
        private System.Windows.Forms.Button button_SendRequest;
        private System.Windows.Forms.ListBox listBox_RequestList;
        private System.Windows.Forms.ListBox listBox_ResourceIDList;
        private System.Windows.Forms.ListBox listBox_SoundIDList;
        private System.Windows.Forms.Button button_ClearCache;
        private System.Windows.Forms.ProgressBar progressBar_Download;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_CacheSize;
        private System.Windows.Forms.Button button_Download;
        private System.Windows.Forms.Button button_GetAccompaniment;
        private System.Windows.Forms.Button button_GetKrcLyric;
        private System.Windows.Forms.Button button_GetLrcLyric;
        private System.Windows.Forms.Button button_GetSong;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox_BillingMode;
        private System.Windows.Forms.TextBox textBox_MusicToken;
    }
}
