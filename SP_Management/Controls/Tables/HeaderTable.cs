using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SP_Management.Controls.Tables
{
    public class HeaderTable
    {
        public void CreateHeader(float[] Size, string[] HeaderText,Panel panel, float Fontsize = 14.25F, string Fontfamily = "Nirmala UI", FontStyle Fontstyle = FontStyle.Bold, string BackColor = "62,148,239", string FontColor = "255,255,255", string HeaderColor = "255,255,255")
        {
            string[] Bcolor = BackColor.Split(',');
            string[] FColor = FontColor.Split(',');
            string[] HColor = HeaderColor.Split(',');

            TableLayoutPanel Header = new TableLayoutPanel();
            Header.AutoSize = false;
            Header.RowCount = 1;
            Header.ColumnCount = Size.Length;
            Header.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
            Header.BackColor = Color.FromArgb(Convert.ToInt32(HColor[0]), Convert.ToInt32(HColor[1]), Convert.ToInt32(HColor[2]));
            for (int i = 0; i < Size.Length; i++)
            {
                Header.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, Size[i]));
                Header.Controls.Add(new Label()
                {
                    TextAlign = ContentAlignment.MiddleCenter,
                    Font = new Font(Fontfamily, Fontsize, Fontstyle),
                    Text = HeaderText[i],
                    Dock = DockStyle.Fill,
                    ForeColor = Color.FromArgb(Convert.ToInt32(FColor[0]), Convert.ToInt32(FColor[1]), Convert.ToInt32(FColor[2])),
                    BackColor = Color.FromArgb(Convert.ToInt32(Bcolor[0]), Convert.ToInt32(Bcolor[1]), Convert.ToInt32(Bcolor[2])),
                }, i, 0);
            }
            Header.Dock = DockStyle.Fill;
            panel.Controls.Add(Header);
        }
    }
}
