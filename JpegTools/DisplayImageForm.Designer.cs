namespace JpegTools
{
    partial class DisplayImageForm
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
            this.displayImage = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.displayImage)).BeginInit();
            this.SuspendLayout();
            // 
            // displayImage
            // 
            this.displayImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.displayImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.displayImage.Location = new System.Drawing.Point(0, 0);
            this.displayImage.Name = "displayImage";
            this.displayImage.Size = new System.Drawing.Size(284, 262);
            this.displayImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.displayImage.TabIndex = 0;
            this.displayImage.TabStop = false;
            // 
            // DisplayImageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.displayImage);
            this.Name = "DisplayImageForm";
            this.Text = "Display Image";
            ((System.ComponentModel.ISupportInitialize)(this.displayImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox displayImage;
    }
}