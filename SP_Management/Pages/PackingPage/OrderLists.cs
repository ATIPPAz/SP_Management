using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SP_Management.Controls.Tables;
namespace SP_Management.Pages.PackingPage
{
    public partial class OrderLists : UserControl
    {
        public OrderLists()
        {
            InitializeComponent();
        }

        private void OrderLists_Load(object sender, EventArgs e)
        {
            HeaderTable header = new HeaderTable();
            header.CreateHeader(new float[] { 25, 25, 25, 25 },new string[]{"ID","Name","LastName","age"},HeaderPanel);
            /*TableLayoutPanel tb = new TableLayoutPanel();
            tb.AutoSize = false;
            *//*tb.Size = new Size(1385, 50);
            tb.RowStyles.Clear();
            tb.ColumnStyles.Clear();*//*
            tb.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
            tb.RowCount = 1;
            tb.ColumnCount = 4;
            tb.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
            tb.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25));
            tb.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25));
            tb.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25));
            tb.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25));
            

            tb.Dock = DockStyle.Top;
            tb.BackColor = Color.Red;
            TextBox textBox1 = new TextBox();
            textBox1.Text = "I am a textBox1";
            textBox1.Dock = DockStyle.Fill;
            textBox1.ForeColor = Color.White;
            textBox1.BackColor = Color.Blue;
            TextBox textBox2 = new TextBox();
            textBox2.Text = "I am a textBox2";
            textBox2.Dock = DockStyle.Fill;
            textBox2.BackColor = Color.Blue;
            TextBox textBox3 = new TextBox();
            textBox3.Text = "I am a textBox3";
            textBox3.Dock = DockStyle.Fill;
            textBox3.Multiline = true;
            textBox3.BackColor = Color.Blue;
            TextBox textBox4 = new TextBox();
            textBox4.Text = "I am a textBox4";
            textBox4.Dock = DockStyle.Fill;
            textBox4.BackColor = Color.Blue;
            *//*tb.Controls.Add(textBox1, 0, 0);
            tb.Controls.Add(textBox2, 0, 1);
            tb.Controls.Add(textBox3, 0, 2);
            tb.Controls.Add(textBox4, 0, 3
            *//*
            tb.Controls.Add(textBox1, 0, 0);
            tb.Controls.Add(textBox2, 1, 0);
            tb.Controls.Add(textBox3, 2, 0);
            tb.Controls.Add(textBox4, 3, 0);
            panels.Controls.Add(tb);*/
        }
    }
}
