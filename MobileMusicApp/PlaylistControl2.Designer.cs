namespace MobileMusicApp
{
    partial class PlaylistControl2
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
            this.lblName = new System.Windows.Forms.Label();
            this.btnDeletePlaylist = new System.Windows.Forms.PictureBox();
            this.ShowPlaylist = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.btnDeletePlaylist)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ShowPlaylist)).BeginInit();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(137, 26);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(53, 25);
            this.lblName.TabIndex = 4;
            this.lblName.Text = "label";
            // 
            // btnDeletePlaylist
            // 
            this.btnDeletePlaylist.BackColor = System.Drawing.Color.Teal;
            this.btnDeletePlaylist.Image = global::MobileMusicApp.Properties.Resources._8664938_trash_can_delete_remove_icon;
            this.btnDeletePlaylist.Location = new System.Drawing.Point(331, 18);
            this.btnDeletePlaylist.Name = "btnDeletePlaylist";
            this.btnDeletePlaylist.Size = new System.Drawing.Size(33, 33);
            this.btnDeletePlaylist.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnDeletePlaylist.TabIndex = 5;
            this.btnDeletePlaylist.TabStop = false;
            this.btnDeletePlaylist.Click += new System.EventHandler(this.btnDeletePlaylist_Click);
            // 
            // ShowPlaylist
            // 
            this.ShowPlaylist.BackColor = System.Drawing.SystemColors.Control;
            this.ShowPlaylist.Image = global::MobileMusicApp.Properties.Resources._10132186_playlist_line_icon;
            this.ShowPlaylist.Location = new System.Drawing.Point(3, 3);
            this.ShowPlaylist.Name = "ShowPlaylist";
            this.ShowPlaylist.Size = new System.Drawing.Size(80, 70);
            this.ShowPlaylist.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ShowPlaylist.TabIndex = 3;
            this.ShowPlaylist.TabStop = false;
            this.ShowPlaylist.Click += new System.EventHandler(this.ShowPlaylist_Click);
            // 
            // PlaylistControl2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Teal;
            this.Controls.Add(this.btnDeletePlaylist);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.ShowPlaylist);
            this.Name = "PlaylistControl2";
            this.Size = new System.Drawing.Size(402, 76);
            ((System.ComponentModel.ISupportInitialize)(this.btnDeletePlaylist)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ShowPlaylist)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.PictureBox ShowPlaylist;
        private System.Windows.Forms.PictureBox btnDeletePlaylist;
    }
}
