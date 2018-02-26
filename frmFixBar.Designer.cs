namespace StickNote
{
    partial class frmFixBar
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
            this.SuspendLayout();
            // 
            // frmFixBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(10, 809);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmFixBar";
            this.Text = "frmFixBar";
            this.Load += new System.EventHandler(this.frmFixBar_Load);
            this.Leave += new System.EventHandler(this.frmFixBar_Leave);
            this.MouseLeave += new System.EventHandler(this.frmFixBar_MouseLeave);
            this.MouseHover += new System.EventHandler(this.frmFixBar_MouseHover); 
            this.ResumeLayout(false);

        }

        #endregion
    }
}