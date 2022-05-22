using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SP_Management.Classes.Commands;
using SP_Management.Controls.Tables;
using SP_Management.Classes.Employee;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.IO;
using System.Drawing;

namespace SP_Management.Pages.HumanResourcePage
{
    public partial class UserlistPage : UserControl
    {
        GetAll getEmployees;
        Employees[] SourceEmpData;
        Employees[] EmpData;
        public UserlistPage()
        {
            InitializeComponent();
            getEmployees = new GetAll();
            SourceEmpData = getEmployees.GetEmployee();
            EmpData = SourceEmpData;
            HeaderTable header = new HeaderTable();
            header.CreateHeader(
                new float[]{5.83F,16.21F, 16.21F ,13.41F, 13.41F, 13.41F, 13.41F, 8.11F }
                ,new string[]{ "ID","FirstName","LastName","Position","Department","TelPhone","Email","Action"},
                HeaderPanel);
            AddTable();
            /* Control[] control =
             {
                 new Label(){ Text = "ID",Dock = DockStyle.Fill,BackColor=Color.FromArgb(62, 148, 239)},
                 new Label(){ Text = "FirstName",Dock = DockStyle.Fill,BackColor=Color.FromArgb(62, 148, 239)},
                 new Label(){ Text = "LastName",Dock = DockStyle.Fill,BackColor=Color.FromArgb(62, 148, 239)},
                 new Label(){ Text = "TelePhone",Dock = DockStyle.Fill,BackColor=Color.FromArgb(62, 148, 239)},
                 new Label(){ Text = "Department",Dock = DockStyle.Fill,BackColor=Color.FromArgb(62, 148, 239)},
                 new Label(){ Text = "Position",Dock = DockStyle.Fill,BackColor=Color.FromArgb(62, 148, 239)},
                 new Label(){ Text = "Email",Dock = DockStyle.Fill,BackColor=Color.FromArgb(62, 148, 239)},
                 new PictureBox(){ SizeMode = PictureBoxSizeMode.Zoom,Dock = DockStyle.Fill },
                 new PictureBox(){ SizeMode = PictureBoxSizeMode.Zoom,Dock = DockStyle.Fill },
             };
             int[] size =
             {
                 0.1,
             };
             HearderTable hearderTable = new HearderTable(size, control);
             hearderTable.Dock = DockStyle.Top;
             TablePanel.Controls.Add(hearderTable);*/
        }

        void AddTable(string sort = "asc")
        {
            BodyPanel.Controls.Clear();
            if(sort == "asc")
            {
                EmpData = EmpData.OrderBy(e=>e.EmpID).ToArray();
            }
            else if(sort == "desc")
            {
                EmpData = EmpData.OrderByDescending(e => e.EmpID).ToArray(); ;
            }
            foreach (var Emp in EmpData)
            {
                /*UserListTable userListTable = new UserListTable(Emp);*/
                BodyTable bodyTable = new BodyTable();
                bodyTable.CreateBody(
                    new float[] { 
                        5.83F, 16.21F, 16.21F, 13.41F, 13.41F, 13.41F, 13.41F, 4.05F,4.05F 
                    },new string[] {
                    Emp.EmpID,Emp.EmpFName,Emp.EmpLName,Emp.EmpPosition,Emp.EmpDepartment,Emp.EmpPhone,Emp.EmpEmail
                    },BodyPanel,new System.Drawing.Image[]{Properties.Resources.PencillIcon,Properties.Resources.DeleteIcon});
               /* userListTable.Dock = DockStyle.Top;
                userListTable.Tag = Emp.EmpID;
                userListTable.BackColor = Color.White;
                userListTable.ForeColor = Color.Black;*/
                BodyPanel.Controls.Add(bodyTable.Body);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Route.index.OpenNewUserPage();   
        }

        private void button1_Click(object sender, EventArgs e)
        {
            EmpData = !(SearchBar.Text == "")? SourceEmpData.Where(emps => emps.EmpFName.Contains(SearchBar.Text)).ToArray() : SourceEmpData;
            AddTable("desc");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AddTable("desc");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AddTable("asc");
        }

        private void ToPdfBtn_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("y.txt");
           /* try
            {
                *//* string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);*//*
                string path = @"test.pdf";
                ExportDataTableToPdf(getEmployees.EmplyeeData, path, "Employees List");
                System.Diagnostics.Process.Start(path);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message");
            }*/
        }

        private void ExportDataTableToPdf(DataTable dtblTable, string strPdfPath, string strHeader)
        {
            System.IO.FileStream fs = new FileStream(strPdfPath, FileMode.Create, FileAccess.Write, FileShare.None);
            Document document = new Document();
            document.SetPageSize(iTextSharp.text.PageSize.A4);
            PdfWriter writer = PdfWriter.GetInstance(document, fs);
            document.Open();

            //Report Header
            BaseFont bfntHead = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            iTextSharp.text.Font fntHead = new iTextSharp.text.Font(bfntHead, 16, 1, BaseColor.GRAY);
            Paragraph prgHeading = new Paragraph();
            prgHeading.Alignment = Element.ALIGN_CENTER;
            prgHeading.Add(new Chunk(strHeader.ToUpper(), fntHead));
            document.Add(prgHeading);

            //Author
            Paragraph prgAuthor = new Paragraph();
            BaseFont btnAuthor = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            iTextSharp.text.Font fntAuthor = new iTextSharp.text.Font(btnAuthor, 8, 2, BaseColor.GRAY);
            prgAuthor.Alignment = Element.ALIGN_RIGHT;
            prgAuthor.Add(new Chunk("Author : Dotnet Mob", fntAuthor));
            prgAuthor.Add(new Chunk("\nRun Date : " + DateTime.Now.ToShortDateString(), fntAuthor));
            document.Add(prgAuthor);

            //Add a line seperation
            Paragraph p = new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(0.0F, 100.0F, BaseColor.BLACK, Element.ALIGN_LEFT, 1)));
            document.Add(p);

            //Add line break
            document.Add(new Chunk("\n", fntHead));

            //Write the table
            PdfPTable table = new PdfPTable(dtblTable.Columns.Count);
            //Table header
            BaseFont btnColumnHeader = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            iTextSharp.text.Font fntColumnHeader = new iTextSharp.text.Font(btnColumnHeader, 10, 1, BaseColor.WHITE);
            for (int i = 0; i < dtblTable.Columns.Count; i++)
            {
                PdfPCell cell = new PdfPCell();
                cell.BackgroundColor = BaseColor.GRAY;
                cell.AddElement(new Chunk(dtblTable.Columns[i].ColumnName.ToUpper(), fntColumnHeader));
                table.AddCell(cell);
            }
            //table Data
            for (int i = 0; i < dtblTable.Rows.Count; i++)
            {
                for (int j = 0; j < dtblTable.Columns.Count; j++)
                {
                    table.AddCell(dtblTable.Rows[i][j].ToString());
                }
            }

            document.Add(table);
            document.Close();
            writer.Close();
            fs.Close();
        }
    }
}
