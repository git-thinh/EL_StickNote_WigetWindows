using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace StickNote
{
    public partial class frmNote : Form
    { 
        int m_Height = Screen.PrimaryScreen.WorkingArea.Height - 99;
        int m_Width = Screen.PrimaryScreen.WorkingArea.Width / 5;
        Color m_ColorKey = Color.OrangeRed;
        Color m_ColorKeyHover = Color.White;
        Color m_ColorValue = Color.Gray;
        string m_FileRoot = "";
        string m_FileStick = "";

        public frmNote()
        {
            InitializeComponent();
            form_Modal();
        }

        #region [ TASKBAR ]

        private enum TaskBarLocation { TOP, BOTTOM, LEFT, RIGHT }
        private TaskBarLocation GetTaskBarLocation()
        {
            TaskBarLocation taskBarLocation = TaskBarLocation.BOTTOM;
            bool taskBarOnTopOrBottom = (Screen.PrimaryScreen.WorkingArea.Width == Screen.PrimaryScreen.Bounds.Width);
            if (taskBarOnTopOrBottom)
            {
                if (Screen.PrimaryScreen.WorkingArea.Top > 0) taskBarLocation = TaskBarLocation.TOP;
            }
            else
            {
                if (Screen.PrimaryScreen.WorkingArea.Left > 0)
                {
                    taskBarLocation = TaskBarLocation.LEFT;
                }
                else
                {
                    taskBarLocation = TaskBarLocation.RIGHT;
                }
            }
            return taskBarLocation;
        }
        #endregion

        #region [ SCROLL ]

        Control event_scroll_actcontrol;
        Point event_scroll_preloc;

        void event_scroll_Mousedown(object sender, MouseEventArgs e)
        {
            event_scroll_actcontrol = sender as Control;
            event_scroll_preloc = e.Location;
            Cursor = Cursors.Default;
        }

        void event_scroll_MouseMove(object sender, MouseEventArgs e)
        {
            if (event_scroll_actcontrol == null || event_scroll_actcontrol != sender)
                return;
            var location = event_scroll_actcontrol.Location;
            //location.Offset(e.Location.X - preloc.X, e.Location.Y - preloc.Y);
            int top = e.Location.Y - event_scroll_preloc.Y;
            location.Offset(0, top);
            event_scroll_actcontrol.Location = location;
            f_label_move_scrollTo(location.Y);
        }

        void event_scroll_MouseUp(object sender, MouseEventArgs e)
        {
            event_scroll_actcontrol = null;
            Cursor = Cursors.Default;
        }

        #endregion

        #region [ CONFIG ]

        void f_config_Open()
        {
            new frmConfig().ShowDialog();
        }

        private void uiLabelConfig_Click(object sender, EventArgs e)
        {
            f_config_Open();
        }

        #endregion

        #region [ FORM ]

        void f_form_Close()
        {
            this.Close();
        }

        void f_form_Init()
        {
            this.ShowInTaskbar = false;

            this.DoubleBuffered = true;
            this.FormBorderStyle = FormBorderStyle.None;
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.MouseWheel += event_form_OnMouseWheel;
            this.TopMost = true;
            this.Width = m_Width;
            this.Height = m_Height;
            int barHeight = Screen.PrimaryScreen.Bounds.Height - Screen.PrimaryScreen.WorkingArea.Height;
            this.Top = barHeight;
            if (GetTaskBarLocation() == TaskBarLocation.TOP)
                this.Top = barHeight * 2;
            this.Left = Screen.PrimaryScreen.WorkingArea.Width - (m_Width + 9);
            //f_config_Open();

            uiPanelItems.FlowDirection = FlowDirection.TopDown;
            uiPanelItems.AutoScroll = true;
            uiPanelItems.WrapContents = false;
            uiPanelItems.Width = m_Width + 55;
            uiPanelItems.MouseWheel += event_items_MouseWheel; 
        }

        private void frmNote_Load(object sender, EventArgs e)
        {
            f_form_Init();
        }
        private void uiLabelClose_Click(object sender, EventArgs e)
        {
            f_form_Close();
        }

        private void frmNote_MouseHover(object sender, EventArgs e)
        {
            form_Light();
        }

        private void frmNote_MouseLeave(object sender, EventArgs e)
        {
            form_Modal();
        }

        void form_Light() {
            this.Opacity = 1;
        }

        void form_Modal() {
            //this.Opacity = 0.3;
            this.Hide();
        }

        #endregion

        #region [ FORM RESIZE ]

        private const int cGrip = 16;      // Grip size
        private const int cCaption = 32;   // Caption bar height;

        protected override void OnPaint(PaintEventArgs e)
        {
            Rectangle rc = new Rectangle(this.ClientSize.Width - cGrip, this.ClientSize.Height - cGrip, cGrip, cGrip);
            ControlPaint.DrawSizeGrip(e.Graphics, this.BackColor, rc);
            rc = new Rectangle(0, 0, this.ClientSize.Width, cCaption);
            e.Graphics.FillRectangle(Brushes.Black, rc);
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x84)
            {  // Trap WM_NCHITTEST
                Point pos = new Point(m.LParam.ToInt32());
                pos = this.PointToClient(pos);
                if (pos.Y < cCaption)
                {
                    m.Result = (IntPtr)2;  // HTCAPTION
                    return;
                }
                if (pos.X >= this.ClientSize.Width - cGrip && pos.Y >= this.ClientSize.Height - cGrip)
                {
                    m.Result = (IntPtr)17; // HTBOTTOMRIGHT
                    return;
                }
            }
            base.WndProc(ref m);
        }

        #endregion

        #region [ FORM MOVE ]

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        private void move_App_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        #endregion

        #region [ PANEL ITEMS ]

        public void AddItem(string word, string mean)
        {
            int width = m_Width - uiLabelScrollBar.Width;

            GrowLabel l2 = new GrowLabel()
            {
                Text = mean,
                Font = new Font("Arial", 11, FontStyle.Italic),
                AutoSize = false,
                Width = width,
                Margin = new Padding(0, 2, 0, 0),
                Padding = new Padding(20, 0, 0, 0),
                ForeColor = m_ColorValue,
                TextAlign = ContentAlignment.TopRight, 
            };
            GrowLabel l1 = new GrowLabel()
            {
                Text = word,
                Font = new Font("Arial", 17, FontStyle.Regular),
                AutoSize = false,
                Width = width,
                Margin = new Padding(0, 10, 0, 0),
                ForeColor = m_ColorKey, 
                MaximumSize = new Size(width, 299)
            };
            l1.MouseDoubleClick += (se, ev) =>
            {
                uiPanelItems.Controls.Remove(l1);
                uiPanelItems.Controls.Remove(l2);
            };

            l1.MouseHover += (se, ev) =>
            {
                form_Light();
                l1.ForeColor = m_ColorKeyHover;
            };
            l1.MouseLeave += (se, ev) =>
            { 
                l1.ForeColor = m_ColorKey;
            };
            l2.MouseHover += (se, ev) =>
            {
                form_Light();
                l1.ForeColor = m_ColorKeyHover;
            };
            l2.MouseLeave += (se, ev) =>
            { 
                l1.ForeColor = m_ColorKey;
            };

            uiPanelItems.Controls.Add(l1);
            uiPanelItems.Controls.Add(l2);
        }

        private void uiPanelItems_MouseHover(object sender, EventArgs e)
        {
            form_Light();
        }
        private void uiPanelItems_MouseLeave(object sender, EventArgs e)
        {
            //form_Modal();
        }

        private void event_items_MouseWheel(object sender, MouseEventArgs e)
        {
            int sm = uiPanelItems.VerticalScroll.Maximum;
            int s = uiPanelItems.VerticalScroll.Value;
            int h = uiPanelItems.Height;
            int top = (h * s) / sm;
            uiLabelScrollBar.Top = top + uiLabelClose.Height;
        }

        private void event_form_OnMouseWheel(object sender, MouseEventArgs e)
        {
            uiPanelItems.Focus();
        }

        void f_label_move_scrollTo(int top)
        {
            if (top < 0)
            {
                top = 0;
                uiLabelScrollBar.Top = uiLabelClose.Height;
            }

            int sm = uiPanelItems.VerticalScroll.Maximum;
            int h = uiPanelItems.Height;

            if (top + uiLabelScrollBar.Height >= h)
            {
                uiPanelItems.VerticalScroll.Value = sm;
                uiLabelScrollBar.Top = (uiLabelClose.Height + h) - uiLabelScrollBar.Height;
            }

            //top h
            // ? sm 
            int s = (top * sm) / h;
            if (s > sm) s = sm;
            uiPanelItems.VerticalScroll.Value = s;
        }

        #endregion

        void file_Open() {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK) 
            {
                m_FileRoot = openFileDialog1.FileName;
                file_Reload();
            } 
        }

        void file_Reload() {

            try
            {
                uiPanelItems.Controls.Clear();
                string[] lines = File.ReadAllLines(m_FileRoot);
                foreach (string line in lines)
                {
                    string[] a = line.Split('=');
                    if (a.Length > 1)
                        AddItem(a[0].Trim(), a[1].Trim());
                }
                //for (int i = 0; i < 99; i++) AddItem("Text " + i, "Mean " + i);
            }
            catch (IOException)
            {
            }
        }

        private void uiLabelLoadFile_Click(object sender, EventArgs e)
        {
            file_Open();
        }

        private void uiLabelRefresh_Click(object sender, EventArgs e)
        {
            file_Reload();
        }
    }
}
