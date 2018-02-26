using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace StickNote
{
    public partial class frmConfig : Form
    {
        public frmConfig()
        {
            InitializeComponent();
        }
         
        int[] m_arrSize = new int[100 - 8];
        private SolidBrush FontForeColour; //Font's Colour
        private void frmConfig_Load(object sender, EventArgs e)
        {
            //Font
            uiListFonts1.DrawMode = DrawMode.OwnerDrawVariable;
            uiListFonts2.DrawMode = DrawMode.OwnerDrawVariable;
            FontFamily[] families = FontFamily.Families; //Obtain & Store System fonts Into Array 
            foreach (FontFamily family in families) //Loop Through System Fonts
            {
                var it = new FontCbo(new Font(family.Name, 12, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point));
                uiListFonts1.Items.Add(it); 
                uiListFonts2.Items.Add(it);
            }

            //Style
            uiRadioStyle_Regular1.Checked = true;
            uiRadioStyle_Regular2.Checked = true;

            //Size
            for (int i = 8; i < 100; i++)
            {
                uiListSize1.Items.Add(i);
                uiListSize2.Items.Add(i);
            }

            //Color
            uiListColor1.DrawMode = DrawMode.OwnerDrawVariable;
            uiListColor2.DrawMode = DrawMode.OwnerDrawVariable;
            foreach (string CurrColourName in System.Enum.GetNames(typeof(System.Drawing.KnownColor))) 
            {
                Color co = Color.FromName(CurrColourName);
                uiListColor1.Items.Add(co); 
                uiListColor2.Items.Add(co);
            }

        }
         
        private void event_font_DrawItem(object sender, DrawItemEventArgs e)
        {
            ListBox uiList = sender as ListBox;
            Brush FontBrush; //Brush To Be used

            //If No Current Colour
            if (FontForeColour == null)
            {
                FontForeColour = new SolidBrush(e.ForeColor); //Set ForeColour
            }
            else
            {
                if (!FontForeColour.Color.Equals(e.ForeColor)) //Fore Colour Changed, Create New Brush
                {
                    FontForeColour.Dispose(); //Dispose Old Brush
                    FontForeColour = new SolidBrush(e.ForeColor); //Create New Brush
                }
            }

            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected) //Set Appropriate Brush
            {
                FontBrush = SystemBrushes.HighlightText;
            }
            else
            {
                FontBrush = FontForeColour;
            }

            Font font = ((FontCbo)uiList.Items[e.Index]).FCFont; //Current item's Font
            e.DrawBackground(); //Redraw Item Background
            e.Graphics.DrawString(font.Name, font, FontBrush, e.Bounds.X, e.Bounds.Y); //Draw Current Font
            e.DrawFocusRectangle(); //Draw Focus Rectangle Around It

        }
         
        private void event_font_MeasureItem(object sender, MeasureItemEventArgs e)
        {
            ListBox uiList = sender as ListBox;
            Font font = ((FontCbo)uiList.Items[e.Index]).FCFont; //Get Current Font In ComboBox

            SizeF stringSize = e.Graphics.MeasureString(font.Name, font); //determine Its Size

            e.ItemHeight = (int)stringSize.Height; //Set Appropriate Height
            e.ItemWidth = (int)stringSize.Width; //Set Appropriate Width
        }
         
        protected void event_color_MeasureItem(object sender, System.Windows.Forms.MeasureItemEventArgs e)
        {
            //Random ColourRnd = new Random(); //Set A Random value
            //e.ItemHeight = ColourRnd.Next(20, 40); 
            e.ItemHeight = 20; 
        }
         
        protected void event_color_DrawItem(object sender, System.Windows.Forms.DrawItemEventArgs e)
        {
            ListBox uiControl = (ListBox)sender;

            if (e.Index < 0) //Don't We Have A List ¿
            {
                e.DrawBackground();
                e.DrawFocusRectangle();
                return;
            }
            //Get Colour Object From Items List 
            Color CurrColour = (Color)uiControl.Items[e.Index];

            //Create A Rectangle To Fit New Item 
            Rectangle ColourSize = new Rectangle(0, e.Bounds.Top , e.Bounds.Width, e.Bounds.Height );

            Brush ColourBrush; //New Colour Brush To Draw With

            e.DrawBackground(); //Draw Item's Background
            e.DrawFocusRectangle(); //Draw Item's Focus Rectangle

            if (e.State == System.Windows.Forms.DrawItemState.Selected) //If Item Selected
            {
                ColourBrush = Brushes.White; //Change To White
            }
            else
            {
                ColourBrush = Brushes.Black; //Change Back to Black
            }

            e.Graphics.DrawRectangle(new Pen(CurrColour), ColourSize); //Draw New Item Rectangle With Current Colour
            e.Graphics.FillRectangle(new SolidBrush(CurrColour), ColourSize); //Fill New Item rectangle With Current Colour

            //Add Border Around Rectangle
            //ColourSize.Inflate(1, 1); //Border Size
            //e.Graphics.DrawRectangle(Pens.Black, ColourSize); //Draw New Border

            //Draw Current Colour Name, In The Middle 
            //e.Graphics.DrawString(CurrColour.Name, uiControl.Font, ColourBrush, e.Bounds.Height + 5, ((e.Bounds.Height - uiControl.Font.Height) / 2) + e.Bounds.Top);
            e.Graphics.DrawString(CurrColour.Name, uiControl.Font, ColourBrush, 0, ((e.Bounds.Height - uiControl.Font.Height) / 2) + e.Bounds.Top);
        }

        private void uiListColor1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string name = uiListColor1.SelectedItem.ToString().Split('[')[1].Split(']')[0].Trim();
            Color co = Color.FromName(name);
            uiLabel_SelectColor1.BackColor = co;
        }

        private void uiButtonSave_Click(object sender, EventArgs e)
        {

        }

        private void uiListColor2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string name = uiListColor2.SelectedItem.ToString().Split('[')[1].Split(']')[0].Trim();
            Color co = Color.FromName(name);
            uiLabel_SelectColor2.BackColor = co; 
        }
    }
}
