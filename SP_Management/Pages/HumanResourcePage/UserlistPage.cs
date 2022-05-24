using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SP_Management.Controls.Tables;
using iTextSharp.text.pdf;
using iTextSharp.text;
using Font = iTextSharp.text.Font;
using System.IO;
using System.Drawing;
using System.Windows.Controls;
using System.Web;
using SP_Management.Others;
using SP_Management.Models.Employee;
using SP_Management.SqlActions;

namespace SP_Management.Pages.HumanResourcePage
{
    public partial class UserlistPage : System.Windows.Forms.UserControl
    {
        DataTable EmpDataTable;
        //Employee[] SourceEmpData;
        Employee[] EmpData;
        public UserlistPage()
        {
            InitializeComponent();
            HeaderTable header = new HeaderTable();
            header.CreateHeader(
                new float[] { 5.83F, 16.21F, 16.21F, 13.41F, 13.41F, 13.41F, 13.41F, 8.11F }
                , new string[] { "ID", "FirstName", "LastName", "Position", "Department", "TelPhone", "Email", "Action" },
                HeaderPanel);
            AscBtn.Hide();
            DescBtn.Hide();
            AddTable();
        }

        public void AddTable(string sort = "asc")
        {
            BodyPanel.Controls.Clear();
            GetAll getdate = new GetAll();
            EmpDataTable = getdate.GetData("Employees");
            //EmpDataTable = getdate.GetData("Employees");
            /*int idx = 0;*/
            /* foreach (DataRow item in EmpDataTable.Rows)
             {
                 SourceEmpData[idx] = new Employee();
                 SourceEmpData[idx].EmpID = item["EmpID"].ToString();
                 SourceEmpData[idx].EmpFName = item["EmpFName"].ToString();
                 SourceEmpData[idx].EmpLName = item["EmpLName"].ToString();
                 SourceEmpData[idx].EmpPhone = item["EmpPhone"].ToString();
                 SourceEmpData[idx].EmpDepartment = item["DeptID"].ToString();
                 SourceEmpData[idx].EmpPosition = item["PositionID"].ToString();
                 SourceEmpData[idx].EmpEmail = item["EmpEmail"].ToString();
                 idx += 1;
             }
             EmpData = SourceEmpData;*/
            /* if (sort == "asc")
             {
                 EmpData = EmpData.OrderBy(e => e.EmpID).ToArray();
             }
             else if (sort == "desc")
             {
                 EmpData = EmpData.OrderByDescending(e => e.EmpID).ToArray(); ;
             }*/
            foreach (DataRow item in EmpDataTable.Rows)
            {
                BodyTable bodyTable = new BodyTable();
                bodyTable.CreateBody(
                    new float[] {
                        5.83F, 16.21F, 16.21F, 13.41F, 13.41F, 13.41F, 13.41F, 4.05F,4.05F
                    },
                    new string[] {
                        item["EmpID"].ToString(),
                        item["EmpFName"].ToString(),
                        item["EmpLName"].ToString(),
                        item["PositionID"].ToString(),
                        item["DeptID"].ToString(),
                        item["EmpPhone"].ToString(),
                        item["EmpEmail"].ToString()
                    },
                    BodyPanel,
                    new System.Drawing.Image[] { Properties.Resources.PencillIcon, Properties.Resources.DeleteIcon }
                );
                Delete delete = new Delete();
                bodyTable.EditBtn.Click += new EventHandler((object o, EventArgs e) => { Route.index.OpenEditUserPage(item["EmpID"].ToString()); });
                bodyTable.DeleteBtn.Click += new EventHandler((object o, EventArgs e) => { delete.DeleteData("Employees", new string[] { "EmpID" }, new string[] { item["EmpID"].ToString() }); AddTable(); });
            }

            /*foreach (var Emp in EmpData)
            {
                BodyTable bodyTable = new BodyTable();
                bodyTable.CreateBody(
                    new float[] {
                        5.83F, 16.21F, 16.21F, 13.41F, 13.41F, 13.41F, 13.41F, 4.05F,4.05F
                    },
                    new string[] {
                        Emp.EmpID,Emp.EmpFName,Emp.EmpLName,Emp.EmpPosition,Emp.EmpDepartment,Emp.EmpPhone,Emp.EmpEmail
                    },
                    BodyPanel,
                    new System.Drawing.Image[] { Properties.Resources.PencillIcon, Properties.Resources.DeleteIcon }
                );
                Delete delete = new Delete();
                bodyTable.EditBtn.Click += new EventHandler((object o, EventArgs e) => { Route.index.OpenEditUserPage(Emp.EmpID); AddTable(); });
                bodyTable.DeleteBtn.Click += new EventHandler((object o, EventArgs e) => { delete.DeleteData("Employees", new string[] { "EmpID"},new string[] { Emp.EmpID }); AddTable(); });
            }*/
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Route.index.OpenNewUserPage();
        }

        private void button1_Click(object sender, EventArgs e)
        {



        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AddTable("asc");
        }

        private void ToPdfBtn_Click(object sender, EventArgs e)
        {
            try
            {
                /*string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);*/
                using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "PDF|*.pdf" })
                {

                    /*  string path = @"test.pdf";*/
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        ExportDataTableToPdf(EmpDataTable, sfd.FileName, "Employees List");
                        System.Diagnostics.Process.Start(sfd.FileName);
                    }

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message");
            }
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

        private void button5_Click(object sender, EventArgs e)
        {
            Excel ex = new Excel();
            ex.Print(EmpDataTable);
        }
       

        private void SearchBtn_Click(object sender, EventArgs e)
        {
            /* DataView dv = new DataView(SourceEmpDataTable);
             dv.RowFilter = $"EmpFName = {SearchBar.Text}"; // query example = "id = 10"
             EmpDataTable = dv.ToTable();*/




            /*EmpData = !(SearchBar.Text == "") ? SourceEmpData.Where(emps => emps.EmpFName.Contains(SearchBar.Text)).ToArray() : SourceEmpData;

            EmpDataTable.Rows.Clear();
            DataRow[] dr = new DataRow[EmpData.Length];
            int idx = 0;
            foreach (DataRow data in SourceEmpDataTable.Rows)
            {
                Console.WriteLine(data["EmpFName"]);
                if (data["EmpFName"].ToString().Contains(SearchBar.Text))
                {
                    EmpDataTable.Rows.Add(data.ItemArray);
                    dr[idx] = data;
                    idx++;
                }
            }
*/



            //EmpDataTable.Rows.Add(SourceEmpDataTable.Rows.Contains(SearchBar.Text));
            /*EmpDataTable = SourceEmpDataTable.Select("EmpID Like '%" + SearchBar.Text + "%'").CopyToDataTable();*/
            AddTable("desc");
        }

        private void DescBtn_Click(object sender, EventArgs e)
        {
            AddTable("desc");
        }

        private void AscBtn_Click(object sender, EventArgs e)
        {
            AddTable("asc");
        }
    }
}