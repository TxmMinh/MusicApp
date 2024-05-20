namespace MobileMusicApp
{
    partial class SongControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SongControl));
            this.lblSongName = new System.Windows.Forms.Label();
            this.lblSinger = new System.Windows.Forms.Label();
            this.btnMoreInfo = new System.Windows.Forms.PictureBox();
            this.btnDownLoad = new System.Windows.Forms.PictureBox();
            this.btnPlaylist = new System.Windows.Forms.PictureBox();
            this.btnLove = new System.Windows.Forms.PictureBox();
            this.axWindowsMediaPlayer1 = new AxWMPLib.AxWindowsMediaPlayer();
            this.btnPlay = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.btnMoreInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDownLoad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPlaylist)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnLove)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPlay)).BeginInit();
            this.SuspendLayout();
            // 
            // lblSongName
            // 
            this.lblSongName.AutoSize = true;
            this.lblSongName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSongName.Location = new System.Drawing.Point(15, 19);
            this.lblSongName.Name = "lblSongName";
            this.lblSongName.Size = new System.Drawing.Size(125, 25);
            this.lblSongName.TabIndex = 0;
            this.lblSongName.Text = "Song Name";
            // 
            // lblSinger
            // 
            this.lblSinger.AutoSize = true;
            this.lblSinger.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSinger.Location = new System.Drawing.Point(16, 58);
            this.lblSinger.Name = "lblSinger";
            this.lblSinger.Size = new System.Drawing.Size(57, 20);
            this.lblSinger.TabIndex = 2;
            this.lblSinger.Text = "Singer";
            // 
            // btnMoreInfo
            // 
            this.btnMoreInfo.Image = global::MobileMusicApp.Properties.Resources._9057190_more_o_icon;
            this.btnMoreInfo.Location = new System.Drawing.Point(600, 44);
            this.btnMoreInfo.Name = "btnMoreInfo";
            this.btnMoreInfo.Size = new System.Drawing.Size(35, 37);
            this.btnMoreInfo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnMoreInfo.TabIndex = 8;
            this.btnMoreInfo.TabStop = false;
            // 
            // btnDownLoad
            // 
            this.btnDownLoad.Image = global::MobileMusicApp.Properties.Resources._2849815_download_multimedia_file_document_icon1;
            this.btnDownLoad.Location = new System.Drawing.Point(536, 44);
            this.btnDownLoad.Name = "btnDownLoad";
            this.btnDownLoad.Size = new System.Drawing.Size(35, 37);
            this.btnDownLoad.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnDownLoad.TabIndex = 7;
            this.btnDownLoad.TabStop = false;
            this.btnDownLoad.Click += new System.EventHandler(this.btnDownLoad_Click);
            // 
            // btnPlaylist
            // 
            this.btnPlaylist.Image = global::MobileMusicApp.Properties.Resources._4781840___add_circle_create_expand_icon;
            this.btnPlaylist.Location = new System.Drawing.Point(472, 44);
            this.btnPlaylist.Name = "btnPlaylist";
            this.btnPlaylist.Size = new System.Drawing.Size(35, 37);
            this.btnPlaylist.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnPlaylist.TabIndex = 6;
            this.btnPlaylist.TabStop = false;
            // 
            // btnLove
            // 
            this.btnLove.Image = global::MobileMusicApp.Properties.Resources._3643770_favorite_white_icon;
            this.btnLove.Location = new System.Drawing.Point(411, 44);
            this.btnLove.Name = "btnLove";
            this.btnLove.Size = new System.Drawing.Size(35, 37);
            this.btnLove.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnLove.TabIndex = 5;
            this.btnLove.TabStop = false;
            this.btnLove.Click += new System.EventHandler(this.btnLove_Click);
            // 
            // axWindowsMediaPlayer1
            // 
            this.axWindowsMediaPlayer1.Enabled = true;
            this.axWindowsMediaPlayer1.Location = new System.Drawing.Point(118, 47);
            this.axWindowsMediaPlayer1.Name = "axWindowsMediaPlayer1";
            this.axWindowsMediaPlayer1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axWindowsMediaPlayer1.OcxState")));
            this.axWindowsMediaPlayer1.Size = new System.Drawing.Size(194, 49);
            this.axWindowsMediaPlayer1.TabIndex = 4;
            this.axWindowsMediaPlayer1.Visible = false;
            // 
            // btnPlay
            // 
            this.btnPlay.Image = global::MobileMusicApp.Properties.Resources._352074_circle_play_icon;
            this.btnPlay.Location = new System.Drawing.Point(353, 44);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(35, 37);
            this.btnPlay.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnPlay.TabIndex = 3;
            this.btnPlay.TabStop = false;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // SongControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkCyan;
            this.Controls.Add(this.btnMoreInfo);
            this.Controls.Add(this.btnDownLoad);
            this.Controls.Add(this.btnPlaylist);
            this.Controls.Add(this.btnLove);
            this.Controls.Add(this.axWindowsMediaPlayer1);
            this.Controls.Add(this.btnPlay);
            this.Controls.Add(this.lblSinger);
            this.Controls.Add(this.lblSongName);
            this.Name = "SongControl";
            this.Size = new System.Drawing.Size(648, 103);
            ((System.ComponentModel.ISupportInitialize)(this.btnMoreInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDownLoad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPlaylist)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnLove)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPlay)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSongName;
        private System.Windows.Forms.Label lblSinger;
        private System.Windows.Forms.PictureBox btnPlay;
        private AxWMPLib.AxWindowsMediaPlayer axWindowsMediaPlayer1;
        private System.Windows.Forms.PictureBox btnLove;
        private System.Windows.Forms.PictureBox btnPlaylist;
        private System.Windows.Forms.PictureBox btnDownLoad;
        private System.Windows.Forms.PictureBox btnMoreInfo;
    }
}
