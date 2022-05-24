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
    public class BodyTable
    {
        public PictureBox EditBtn;
        public PictureBox DeleteBtn;
        public TableLayoutPanel Body;
        public void CreateBody(float[] Size, string[] BodyText, Panel panel,Image[] img,float Fontsize = 14.25F,string Fontfamily = "Nirmala UI", FontStyle Fontstyle = FontStyle.Bold, string BackColor = "255,255,255", string FontColor = "0,0,0", string HeaderColor = "255,255,255")
        {
            string[] Bcolor = BackColor.Split(',');
            string[] FColor = FontColor.Split(',');
            string[] HColor = HeaderColor.Split(',');
            
            int btncount = img.Length;
            int idxpic = 0;
            Body = new TableLayoutPanel();
            Body.Height = 30;
            //Body.CellBorderStyle = TableLayoutPanelCellBorderStyle.Outset;
            Body.AutoSize = false;
            Body.RowCount = 1;
            Body.ColumnCount = Size.Length;
            Body.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
            Body.BackColor = Color.FromArgb(Convert.ToInt32(HColor[0]), Convert.ToInt32(HColor[1]), Convert.ToInt32(HColor[2]));
            for (int i = 0; i < Size.Length; i++)
            {
                Body.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, Size[i]));
                if(i == Size.Length- btncount)
                {
                    if(idxpic == 0)
                    {
                        EditBtn = new PictureBox()
                        {
                            Image = img[idxpic],
                            Dock = DockStyle.Fill,
                            SizeMode = PictureBoxSizeMode.Zoom,
                            BackColor = Color.Transparent,
                            Cursor = Cursors.Hand,
                        };
                        Body.Controls.Add(EditBtn, i, 0);
                    }
                    else
                    {

                        DeleteBtn = new PictureBox()
                        {
                            Image = img[idxpic],
                            Dock = DockStyle.Fill,
                            SizeMode = PictureBoxSizeMode.Zoom,
                            BackColor = Color.Transparent,
                            Cursor = Cursors.Hand,
                        };
                        Body.Controls.Add(DeleteBtn, i, 0);
                    }
                    
                    btncount--;
                    idxpic++;
                }
                else
                {
                    Body.Controls.Add(new Label()
                    {
                        TextAlign = ContentAlignment.MiddleCenter,
                        Font = new Font(Fontfamily, Fontsize, Fontstyle),
                        Text = BodyText[i],
                        Dock = DockStyle.Fill,
                        ForeColor = Color.FromArgb(Convert.ToInt32(FColor[0]), Convert.ToInt32(FColor[1]), Convert.ToInt32(FColor[2])),
                        BackColor = Color.FromArgb(Convert.ToInt32(Bcolor[0]), Convert.ToInt32(Bcolor[1]), Convert.ToInt32(Bcolor[2])),
                    }, i, 0);
                }
            }
           
            Body.Dock = DockStyle.Top;
            panel.Controls.Add(Body);
        }
    }
}
