namespace StickNote
{
    partial class frmNote
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
            this.uiPanelItems = new System.Windows.Forms.FlowLayoutPanel();
            this.uiLabelScrollBar = new System.Windows.Forms.Label();
            this.uiLabelClose = new System.Windows.Forms.Label();
            this.uiLabelConfig = new System.Windows.Forms.Label();
            this.uiLabelLoadFile = new System.Windows.Forms.Label();
            this.uiLabelRefresh = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // uiPanelItems
            // 
            this.uiPanelItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uiPanelItems.BackColor = System.Drawing.SystemColors.InfoText;
            this.uiPanelItems.Location = new System.Drawing.Point(10, 10);
            this.uiPanelItems.Name = "uiPanelItems";
            this.uiPanelItems.Size = new System.Drawing.Size(284, 543);
            this.uiPanelItems.TabIndex = 0;
            this.uiPanelItems.MouseLeave += new System.EventHandler(this.uiPanelItems_MouseLeave);
            this.uiPanelItems.MouseHover += new System.EventHandler(this.uiPanelItems_MouseHover);
            this.uiPanelItems.MouseMove += new System.Windows.Forms.MouseEventHandler(this.move_App_MouseDown);
            // 
            // uiLabelScrollBar
            // 
            this.uiLabelScrollBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.uiLabelScrollBar.BackColor = System.Drawing.Color.Gray;
            this.uiLabelScrollBar.Location = new System.Drawing.Point(288, 7);
            this.uiLabelScrollBar.Name = "uiLabelScrollBar";
            this.uiLabelScrollBar.Size = new System.Drawing.Size(13, 15);
            this.uiLabelScrollBar.TabIndex = 1;
            this.uiLabelScrollBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.event_scroll_Mousedown);
            this.uiLabelScrollBar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.event_scroll_MouseMove);
            this.uiLabelScrollBar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.event_scroll_MouseUp);
            // 
            // uiLabelClose
            // 
            this.uiLabelClose.BackColor = System.Drawing.Color.Black;
            this.uiLabelClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiLabelClose.ForeColor = System.Drawing.SystemColors.Control;
            this.uiLabelClose.Location = new System.Drawing.Point(0, -3);
            this.uiLabelClose.Name = "uiLabelClose";
            this.uiLabelClose.Size = new System.Drawing.Size(35, 13);
            this.uiLabelClose.TabIndex = 2;
            this.uiLabelClose.Text = "Close";
            this.uiLabelClose.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.uiLabelClose.Click += new System.EventHandler(this.uiLabelClose_Click);
            // 
            // uiLabelConfig
            // 
            this.uiLabelConfig.BackColor = System.Drawing.Color.Black;
            this.uiLabelConfig.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiLabelConfig.ForeColor = System.Drawing.SystemColors.Control;
            this.uiLabelConfig.Location = new System.Drawing.Point(36, -3);
            this.uiLabelConfig.Name = "uiLabelConfig";
            this.uiLabelConfig.Size = new System.Drawing.Size(37, 13);
            this.uiLabelConfig.TabIndex = 3;
            this.uiLabelConfig.Text = "Config";
            this.uiLabelConfig.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.uiLabelConfig.Click += new System.EventHandler(this.uiLabelConfig_Click);
            // 
            // uiLabelLoadFile
            // 
            this.uiLabelLoadFile.BackColor = System.Drawing.Color.Black;
            this.uiLabelLoadFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiLabelLoadFile.ForeColor = System.Drawing.SystemColors.Control;
            this.uiLabelLoadFile.Location = new System.Drawing.Point(74, -2);
            this.uiLabelLoadFile.Name = "uiLabelLoadFile";
            this.uiLabelLoadFile.Size = new System.Drawing.Size(24, 12);
            this.uiLabelLoadFile.TabIndex = 4;
            this.uiLabelLoadFile.Text = "File";
            this.uiLabelLoadFile.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.uiLabelLoadFile.Click += new System.EventHandler(this.uiLabelLoadFile_Click);
            // 
            // uiLabelRefresh
            // 
            this.uiLabelRefresh.BackColor = System.Drawing.Color.Black;
            this.uiLabelRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiLabelRefresh.ForeColor = System.Drawing.SystemColors.Control;
            this.uiLabelRefresh.Location = new System.Drawing.Point(99, -2);
            this.uiLabelRefresh.Name = "uiLabelRefresh";
            this.uiLabelRefresh.Size = new System.Drawing.Size(45, 12);
            this.uiLabelRefresh.TabIndex = 5;
            this.uiLabelRefresh.Text = "Refresh";
            this.uiLabelRefresh.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.uiLabelRefresh.Click += new System.EventHandler(this.uiLabelRefresh_Click);
            // 
            // frmNote
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(301, 555);
            this.Controls.Add(this.uiLabelRefresh);
            this.Controls.Add(this.uiLabelLoadFile);
            this.Controls.Add(this.uiLabelConfig);
            this.Controls.Add(this.uiLabelClose);
            this.Controls.Add(this.uiLabelScrollBar);
            this.Controls.Add(this.uiPanelItems);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmNote";
            this.ShowInTaskbar = false;
            this.Text = "Form1";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmNote_Load);
            this.MouseLeave += new System.EventHandler(this.frmNote_MouseLeave);
            this.MouseHover += new System.EventHandler(this.frmNote_MouseHover);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.move_App_MouseDown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel uiPanelItems;
        private System.Windows.Forms.Label uiLabelScrollBar;
        private System.Windows.Forms.Label uiLabelClose;
        private System.Windows.Forms.Label uiLabelConfig;
        private System.Windows.Forms.Label uiLabelLoadFile;
        private System.Windows.Forms.Label uiLabelRefresh;
    }
}

