using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace deneme2
{
    public partial class aramaSonuc : Form
    {
        public aramaSonuc()
        {
            InitializeComponent();
        }
        public string icerik;
        public string aramaMetni;
        private void aramaSonuc_Load(object sender, EventArgs e)
        {
            MatchCollection matches = Regex.Matches(icerik, aramaMetni);
            if (matches.Count > 0)
            {
                foreach (Match match in matches)
                {
                    richTextBox1.Text += "Eşleşme bulundu: " + match.Value + "\n";
                }
            }
        }

    }
}
