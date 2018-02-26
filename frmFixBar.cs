using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace StickNote
{
    public partial class frmFixBar : Form
    {
        frmNote m_Note;
        int m_Width = 9;
        bool m_FlagHide = true;

        public frmFixBar()
        {
            InitializeComponent();
            m_Note = new frmNote();
            m_Note.Hide();
        }

        private void frmFixBar_Load(object sender, EventArgs e)
        {
            this.TopMost = true;
            this.ShowInTaskbar = false;

            this.Width = m_Width;
            this.Left = Screen.PrimaryScreen.WorkingArea.Width - (m_Width - 2);
            this.Top = 0;
            this.Height = Screen.PrimaryScreen.WorkingArea.Height;
        }

        private void frmFixBar_MouseHover(object sender, EventArgs e)
        {
            if (m_FlagHide)
            {
                m_FlagHide = false;
                m_Note.Show();
            }
            else
            {
                m_FlagHide = true;
                m_Note.Hide();
            }
        }
         

        private void frmFixBar_Leave(object sender, EventArgs e)
        {
            //m_Note.Hide();
        }

        private void frmFixBar_MouseLeave(object sender, EventArgs e)
        {
            //m_Note.Hide();
        }
    }
}
