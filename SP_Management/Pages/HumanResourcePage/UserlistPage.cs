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
using System.IO;
using System.Drawing;
using System.Windows.Controls;
using System.Web;
using Font = iTextSharp.text.Font;
using SP_Management.Others;
using SP_Management.Models.Employee;
using SP_Management.SqlActions;

namespace SP_Management.Pages.HumanResourcePage
{
    public partial class UserlistPage : System.Windows.Forms.UserControl
    {
        DataTable SourceEmpDataTable;
        DataTable EmpDataTable;
        Employee[] SourceEmpData;
        Employee[] EmpData;
        public UserlistPage()
        {
            InitializeComponent();
            GetAll getdate = new GetAll();
            SourceEmpDataTable = getdate.GetData("Employees");
            EmpDataTable = SourceEmpDataTable.Copy();
            Console.WriteLine(EmpDataTable.Rows.Count);
            SourceEmpData = new Employee[EmpDataTable.Rows.Count];
            int idx = 0;
            foreach (DataRow item in EmpDataTable.Rows)
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
            EmpData = SourceEmpData;
            HeaderTable header = new HeaderTable();
            header.CreateHeader(
                new float[] { 5.83F, 16.21F, 16.21F, 13.41F, 13.41F, 13.41F, 13.41F, 8.11F }
                , new string[] { "ID", "FirstName", "LastName", "Position", "Department", "TelPhone", "Email", "Action" },
                HeaderPanel);
            AddTable();
        }

        public void AddTable(string sort = "asc")
        {
            BodyPanel.Controls.Clear();
            if (sort == "asc")
            {
                EmpData = EmpData.OrderBy(e => e.EmpID).ToArray();
            }
            else if (sort == "desc")
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
                    },
                    new string[] {
                        Emp.EmpID,Emp.EmpFName,Emp.EmpLName,Emp.EmpPosition,Emp.EmpDepartment,Emp.EmpPhone,Emp.EmpEmail
                    },
                    BodyPanel,
                    new System.Drawing.Image[] { Properties.Resources.PencillIcon, Properties.Resources.DeleteIcon }
                );
                bodyTable.EditBtn.Click += new EventHandler((object o, EventArgs e) => Route.index.OpenEditUserPage(Emp.EmpID));
                bodyTable.DeleteBtn.Click += new EventHandler((object o, EventArgs e) => MessageBox.Show(Emp.EmpID));
                BodyPanel.Controls.Add(bodyTable.Body);
            }
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
            var cvt = new FontConverter();
            string s = cvt.ConvertToString(new System.Drawing.Font("Nirmala UI", 14.25F, FontStyle.Regular));
            BaseFont bfntHead = BaseFont.CreateFont(HttpContext.Current.Server.MapPath("~/Fonts/ANGSA_0.TTF"), BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
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

        }
        public static void ExportFromGridView(DataTable gvControl, string strPdfPath, string strHeader)
        {
            /*System.IO.FileStream fs = new FileStream(strPdfPath, FileMode.Create, FileAccess.Write, FileShare.None);
            Document document = new Document();
            document.SetPageSize(iTextSharp.text.PageSize.A4);
            PdfWriter writer = PdfWriter.GetInstance(document, fs);
            document.Open();*/
            // สร้าง BaseFont 
            BaseFont bf = BaseFont.CreateFont(HttpContext.Current.Server.MapPath("~/THSarabun.ttf"), BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
            // กำหนดขนาดของ Pdf
            Document pdfDoc = new Document(PageSize.A4, 10, 10, 10, 10);

            try
            {
                // สร้าง instance ของ PdfWriter
                PdfWriter.GetInstance(pdfDoc, System.Web.HttpContext.Current.Response.OutputStream);
                pdfDoc.Open();

                // สร้าง Font จาก BaseFont 
                Font fnt = new Font(bf, 11);

                // สร้าง PdfTable จาก GridView Control
                PdfPTable PdfTable = new PdfPTable(gvControl.Columns.Count);
                PdfPCell PdfPCell = null;

                // Write Header ที่ PdfCell ใน PdfTable
                for (int i = 0; i < gvControl.Columns.Count; i++)
                {
                    PdfPCell cell = new PdfPCell();
                    cell.BackgroundColor = BaseColor.GRAY;
                    cell.AddElement(new Chunk(gvControl.Columns[i].ColumnName.ToUpper(), fnt));
                    PdfTable.AddCell(cell);
                }

                // Write Data ที่ PdfCell ใน PdfTable
                for (int i = 0; i < gvControl.Rows.Count; i++)
                {
                    for (int j = 0; j < gvControl.Columns.Count; j++)
                    {
                        PdfPCell = new PdfPCell(new Phrase(new Chunk(gvControl.Rows[i][j].ToString(), fnt)));
                        PdfTable.AddCell(PdfPCell);
                    }
                }

                // Add PdfTable ลง pdfDoc
                pdfDoc.Add(PdfTable);
                // Close document
                pdfDoc.Close();
                // กำหนด ContentType เป็น application/pdf เพื่อ Response เป็น Pdf
                HttpContext.Current.Response.ContentType = "application/pdf";
                // กำหนดชื่อไฟล์ที่ต้องการ Export
                HttpContext.Current.Response.AddHeader("content-disposition", "attachment; filename=" + DateTime.Now.ToString("yyyyMMdd") + ".pdf");
                // Export Pdf
                System.Web.HttpContext.Current.Response.Write(pdfDoc);

                HttpContext.Current.Response.Flush();
                HttpContext.Current.Response.End();

            }
            catch (Exception ex)
            {
                HttpContext.Current.Response.Write(ex.ToString());
            }
        }

        private void SearchBtn_Click(object sender, EventArgs e)
        {
            EmpData = !(SearchBar.Text == "") ? SourceEmpData.Where(emps => emps.EmpFName.Contains(SearchBar.Text)).ToArray() : SourceEmpData;
            /* DataView dv = new DataView(SourceEmpDataTable);
             dv.RowFilter = $"EmpFName = {SearchBar.Text}"; // query example = "id = 10"
             EmpDataTable = dv.ToTable();*/
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