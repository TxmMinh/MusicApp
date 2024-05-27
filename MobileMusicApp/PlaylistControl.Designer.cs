namespace MobileMusicApp
{
    partial class PlaylistControl
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
            this.addToPlaylist = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.addToPlaylist)).BeginInit();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(137, 26);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(53, 25);
            this.lblName.TabIndex = 2;
            this.lblName.Text = "label";
            // 
            // addToPlaylist
            // 
            this.addToPlaylist.BackColor = System.Drawing.SystemColors.Control;
            this.addToPlaylist.Image = global::MobileMusicApp.Properties.Resources._8673564_ic_fluent_note_add_filled_icon;
            this.addToPlaylist.Location = new System.Drawing.Point(3, 3);
            this.addToPlaylist.Name = "addToPlaylist";
            this.addToPlaylist.Size = new System.Drawing.Size(80, 70);
            this.addToPlaylist.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.addToPlaylist.TabIndex = 1;
            this.addToPlaylist.TabStop = false;
            this.addToPlaylist.Click += new System.EventHandler(this.addToPlaylist_Click);
            // 
            // PlaylistControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Teal;
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.addToPlaylist);
            this.Name = "PlaylistControl";
            this.Size = new System.Drawing.Size(402, 76);
            ((System.ComponentModel.ISupportInitialize)(this.addToPlaylist)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox addToPlaylist;
        private System.Windows.Forms.Label lblName;
    }
}
