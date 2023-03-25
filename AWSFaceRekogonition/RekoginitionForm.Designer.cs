namespace AWSFaceRekogonition
{
    partial class RekoginitionForm
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
            this.videoSourcePlayer = new AForge.Controls.VideoSourcePlayer();
            this.wecamLbl = new System.Windows.Forms.Label();
            this.picBox = new System.Windows.Forms.PictureBox();
            this.cameraComboBox = new System.Windows.Forms.ComboBox();
            this.startBtn = new System.Windows.Forms.Button();
            this.snapshotBtn = new System.Windows.Forms.Button();
            this.stopBtn = new System.Windows.Forms.Button();
            this.openBtn = new System.Windows.Forms.Button();
            this.videoPanel = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.picBox)).BeginInit();
            this.videoPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // videoSourcePlayer
            // 
            this.videoSourcePlayer.AutoSizeControl = true;
            this.videoSourcePlayer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.videoSourcePlayer.BorderColor = System.Drawing.Color.Transparent;
            this.videoSourcePlayer.Location = new System.Drawing.Point(55, 93);
            this.videoSourcePlayer.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.videoSourcePlayer.Name = "videoSourcePlayer";
            this.videoSourcePlayer.Size = new System.Drawing.Size(322, 242);
            this.videoSourcePlayer.TabIndex = 0;
            this.videoSourcePlayer.Text = "videoSourcePlayer";
            this.videoSourcePlayer.VideoSource = null;
            this.videoSourcePlayer.NewFrame += new AForge.Controls.VideoSourcePlayer.NewFrameHandler(this.videoSourcePlayer_NewFrame);
            // 
            // wecamLbl
            // 
            this.wecamLbl.AutoSize = true;
            this.wecamLbl.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.wecamLbl.Location = new System.Drawing.Point(17, 33);
            this.wecamLbl.Name = "wecamLbl";
            this.wecamLbl.Size = new System.Drawing.Size(83, 23);
            this.wecamLbl.TabIndex = 1;
            this.wecamLbl.Text = "WebCam";
            // 
            // picBox
            // 
            this.picBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picBox.Location = new System.Drawing.Point(478, 75);
            this.picBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.picBox.Name = "picBox";
            this.picBox.Size = new System.Drawing.Size(437, 431);
            this.picBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBox.TabIndex = 2;
            this.picBox.TabStop = false;
            // 
            // cameraComboBox
            // 
            this.cameraComboBox.FormattingEnabled = true;
            this.cameraComboBox.Location = new System.Drawing.Point(207, 32);
            this.cameraComboBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cameraComboBox.Name = "cameraComboBox";
            this.cameraComboBox.Size = new System.Drawing.Size(247, 28);
            this.cameraComboBox.TabIndex = 3;
            // 
            // startBtn
            // 
            this.startBtn.Location = new System.Drawing.Point(184, 529);
            this.startBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.startBtn.Name = "startBtn";
            this.startBtn.Size = new System.Drawing.Size(86, 31);
            this.startBtn.TabIndex = 4;
            this.startBtn.Text = "Start";
            this.startBtn.UseVisualStyleBackColor = true;
            this.startBtn.Click += new System.EventHandler(this.startBtn_Click);
            // 
            // snapshotBtn
            // 
            this.snapshotBtn.Location = new System.Drawing.Point(277, 529);
            this.snapshotBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.snapshotBtn.Name = "snapshotBtn";
            this.snapshotBtn.Size = new System.Drawing.Size(86, 31);
            this.snapshotBtn.TabIndex = 5;
            this.snapshotBtn.Text = "Snapshot";
            this.snapshotBtn.UseVisualStyleBackColor = true;
            this.snapshotBtn.Click += new System.EventHandler(this.snapshotBtn_Click);
            // 
            // stopBtn
            // 
            this.stopBtn.Location = new System.Drawing.Point(369, 529);
            this.stopBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.stopBtn.Name = "stopBtn";
            this.stopBtn.Size = new System.Drawing.Size(86, 31);
            this.stopBtn.TabIndex = 6;
            this.stopBtn.Text = "Stop";
            this.stopBtn.UseVisualStyleBackColor = true;
            this.stopBtn.Click += new System.EventHandler(this.stopBtn_Click);
            // 
            // openBtn
            // 
            this.openBtn.Location = new System.Drawing.Point(830, 529);
            this.openBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.openBtn.Name = "openBtn";
            this.openBtn.Size = new System.Drawing.Size(86, 31);
            this.openBtn.TabIndex = 7;
            this.openBtn.Text = "Open image";
            this.openBtn.UseVisualStyleBackColor = true;
            this.openBtn.Click += new System.EventHandler(this.openBtn_Click);
            // 
            // videoPanel
            // 
            this.videoPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.videoPanel.Controls.Add(this.videoSourcePlayer);
            this.videoPanel.Location = new System.Drawing.Point(20, 75);
            this.videoPanel.Name = "videoPanel";
            this.videoPanel.Size = new System.Drawing.Size(435, 431);
            this.videoPanel.TabIndex = 8;
            // 
            // RekoginitionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(935, 579);
            this.Controls.Add(this.videoPanel);
            this.Controls.Add(this.openBtn);
            this.Controls.Add(this.stopBtn);
            this.Controls.Add(this.snapshotBtn);
            this.Controls.Add(this.startBtn);
            this.Controls.Add(this.cameraComboBox);
            this.Controls.Add(this.picBox);
            this.Controls.Add(this.wecamLbl);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "RekoginitionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Rekoginition";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RekoginitionForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.picBox)).EndInit();
            this.videoPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private AForge.Controls.VideoSourcePlayer videoSourcePlayer;
        private Label wecamLbl;
        private PictureBox picBox;
        private ComboBox cameraComboBox;
        private Button startBtn;
        private Button snapshotBtn;
        private Button stopBtn;
        private Button openBtn;
        private Panel videoPanel;
    }
}