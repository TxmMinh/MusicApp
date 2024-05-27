namespace MobileMusicApp
{
    partial class ChatControl
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
            this.lblDateCreated = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.txtMess = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // lblDateCreated
            // 
            this.lblDateCreated.AutoSize = true;
            this.lblDateCreated.Location = new System.Drawing.Point(232, 14);
            this.lblDateCreated.Name = "lblDateCreated";
            this.lblDateCreated.Size = new System.Drawing.Size(44, 16);
            this.lblDateCreated.TabIndex = 5;
            this.lblDateCreated.Text = "label1";
            this.lblDateCreated.Click += new System.EventHandler(this.lblDateCreated_Click);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(18, 14);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(44, 16);
            this.lblName.TabIndex = 6;
            this.lblName.Text = "Name";
            this.lblName.Click += new System.EventHandler(this.label1_Click);
            // 
            // txtMess
            // 
            this.txtMess.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMess.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMess.Location = new System.Drawing.Point(21, 33);
            this.txtMess.Name = "txtMess";
            this.txtMess.Size = new System.Drawing.Size(314, 31);
            this.txtMess.TabIndex = 8;
            this.txtMess.Text = "";
            // 
            // ChatControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtMess);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblDateCreated);
            this.Name = "ChatControl";
            this.Size = new System.Drawing.Size(370, 74);
            this.Load += new System.EventHandler(this.ChatControl_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblDateCreated;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.RichTextBox txtMess;
    }
}
