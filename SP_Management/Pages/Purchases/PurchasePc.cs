using SP_Management.Controls.Tables;
using SP_Management.Others;
using SP_Management.SqlActions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SP_Management.Pages.Purchases
{
    public partial class PurchasePc : UserControl
    {
        public PurchasePc()
        {
            InitializeComponent();
            HeaderTable header = new HeaderTable();
            header.CreateHeader(
                   Size: new float[]{
                        20,20,20,20,20
                   },
                   HeaderText: new string[]
                   {
                        "PurchID","Created","EmployeeID","Remark","Action"
                   },
                   panel: HeaderPanel
               );
            AddTable();
        }
        DataTable table;
        void AddTable()
        {

            BodyPanel.Controls.Clear();
            BodyTable body = new BodyTable();
            GetOne getProduct = new GetOne();
             table = getProduct.GetData(
                Table: new string[] { "Purchases" }
                , ColumnSelect: "StatusID",
                IDSelect: "ST002",
                CallTable: new string[] { "p" }
                );
            foreach (DataRow item in table.Rows)
            {
                body.CreateBody(
                   Size: new float[] { 20, 20, 20, 20, 10, 10 },
                   BodyText: new string[] {
                        item["PurchID"].ToString(),
                        item["CreatePur"].ToString(),
                        item["EmpCrePur"].ToString(),
                        item["Annotation"].ToString()
                   },
                   img: new Image[] { Properties.Resources.PencillIcon, Properties.Resources.DeleteIcon },
                   panel: BodyPanel);

                //edit
                Insert updateStatud = new Insert();
                body.EditBtn.Click += new EventHandler((object o, EventArgs e) =>
                {
                    //opendialog
                    //updateStatud.Updatedata(SelectRowUpdate: "OrderID", SelectValue: item["OrderID"].ToString(), Table: "Orders", ColoumnUpdate: new string[] { "OrStatusID" }, ColumnValue: new string[] { "OS03" });
                    Route.index.OpenNewUserPage();
                    AddTable();
                });
                //update
                Delete delete = new Delete();
                body.DeleteBtn.Click += new EventHandler((object o, EventArgs e) =>
                {
                    delete.DeleteData(
                        Table: "Purchases",
                        ColumnSelect: new string[] {
                    "PurchID"
                    }, ColumnValue: new string[] {
                     item["PurchID"].ToString()
                    });
                    AddTable();
                });
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Pdf pdf = new Pdf();
            pdf.print(table,"Purchase");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Excel ex = new Excel();
            ex.Print(table);
        }
    }
}
