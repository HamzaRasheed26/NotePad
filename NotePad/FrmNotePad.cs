namespace NotePad
{

    public partial class FrmNotePad : Form
    {
        private bool flagBold = false;
        private bool flagItalic = false;
        private bool flagUline = false;

        public FrmNotePad()
        {
            InitializeComponent();
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void btnBold_Click(object sender, EventArgs e)
        {
            if (flagBold == false)
            {
                richTxtMain.SelectionFont = new Font(cbFontStyle.Text, (int)numSize.Value, FontStyle.Bold);
                //btnBold.BackColor = Color.Green;
                flagBold = true;
            }
            else if(flagBold == true)
            {
                richTxtMain.SelectionFont = new Font(cbFontStyle.Text, (int)numSize.Value, FontStyle.Regular);
                
                flagBold = false;
            }
            flagItalic = false;
            flagUline = false;

        }

        private void btnItalic_Click(object sender, EventArgs e)
        {
            if (flagItalic == false)
            {
                richTxtMain.SelectionFont = new Font(cbFontStyle.Text, (int)numSize.Value, FontStyle.Italic);
                flagItalic = true;
            }
            else if (flagItalic == true)
            {
                richTxtMain.SelectionFont = new Font(cbFontStyle.Text, (int)numSize.Value, FontStyle.Regular);
                flagItalic = false;
            }
            flagBold = false;
            flagUline = false;
        }

        private void btnUnderline_Click(object sender, EventArgs e)
        {
            if (flagUline == false)
            {
                richTxtMain.SelectionFont = new Font(cbFontStyle.Text, (int)numSize.Value, FontStyle.Underline);
                flagUline = true;
            }
            else if (flagUline == true)
            {
                richTxtMain.SelectionFont = new Font(cbFontStyle.Text, (int)numSize.Value, FontStyle.Regular);
                flagUline = false;
            }
            flagBold = false;
            flagItalic = false;
        }

        private void cbFontStyle_SelectedIndexChanged(object sender, EventArgs e)
        {
            string fontName = cbFontStyle.Text;

            richTxtMain.SelectionFont = new Font( fontName, (int)numSize.Value , richTxtMain.Font.Style);
        }

        private void FrmNotePad_Load(object sender, EventArgs e)
        {
            List<string> fonts = new List<string>();

            foreach (FontFamily font in FontFamily.Families)
            {
                fonts.Add(font.Name);
            }
            cbFontStyle.DataSource = fonts.ToList();

            // cbFontStyle.DataSource = FontFamily.Families.Select(c => new { c.Name }).ToList();

        }

        private void numSize_ValueChanged(object sender, EventArgs e)
        {
            int size = (int)numSize.Value;
            richTxtMain.SelectionFont = new Font(cbFontStyle.Text, size, richTxtMain.Font.Style) ;
        }

        private void menuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void richTxtMain_TextChanged(object sender, EventArgs e)
        {
            int words = richTxtMain.Text.Split(' ').Count();

            //lblWordsNo.Text = words.ToString();

            Word_Count();

            int lines  = richTxtMain.Lines.Count();
            lblLinesNo.Text = lines.ToString();
        }

        public void Word_Count()
        {
            int count = 0;
            string c = richTxtMain.Text;
            for (int i = 0; i < c.Length; i++)
                //each (char c in wordcount)
            {
                if (c[i] == ' ')
                {
                    if (c[i - 1] != ' ')
                    {
                        count++; ;
                    }
                }
                lblWordsNo.Text = count.ToString();
            }
        }

    }
}