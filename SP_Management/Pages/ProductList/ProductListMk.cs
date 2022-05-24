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

namespace SP_Management.Pages.ProductList
{
    public partial class ProductListMk : UserControl
    {
        public ProductListMk()
        {
            InitializeComponent();
             HeaderTable header = new HeaderTable();
            header.CreateHeader(
                   Size: new float[]{
                        20,25,10,10,20,10
                   },
                   HeaderText: new string[]
                   {
                        "Name","Description","Price","Qty","ImageUrl","Action"
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
                Table:new string []{ "Products","ProductDetails" }
                ,ColumnSelect:"ProdStatusID",
                IDSelect:"PS002",
                CallTable:new string[] {"p,pd"},
                JoinColumn:new string[]
                {
                    "ProdDetailID,ProdDetailID"
                }
                );
            foreach (DataRow item in table.Rows)
            {
                string propDeID = "";
                propDeID = item["ProdDetailID"].ToString();
                body.CreateBody(
                   Size: new float[] { 20, 25, 10, 10, 20,5,5 },
                   BodyText: new string[] {
                        item["ProdName"].ToString(),
                        item["ProdDest"].ToString(),
                        item["ProdPrice"].ToString(),
                        item["ProdQty"].ToString(),
                        item["ProdImage"].ToString(),
                   },
                   img: new Image[] { Properties.Resources.PencillIcon,Properties.Resources.Correct },
                   panel: BodyPanel);

                //edit
                Update updateStatud = new Update();
                body.EditBtn.Click += new EventHandler((object o, EventArgs e) =>
                {
                    //opendialog
                    //updateStatud.Updatedata(SelectRowUpdate: "OrderID", SelectValue: item["OrderID"].ToString(), Table: "Orders", ColoumnUpdate: new string[] { "OrStatusID" }, ColumnValue: new string[] { "OS03" });
                    AddTable();
                });
                //update
                body.DeleteBtn.Click += new EventHandler((object o, EventArgs e) =>
                     {
                         updateStatud.Updatedata(SelectRowUpdate: "ProdDetailID", SelectValue: item["ProdDetailID"].ToString(), Table: "ProductDetails", ColoumnUpdate: new string[] { "ProdStatusID" }, ColumnValue: new string[] { "PS001" });
                         AddTable();
                });
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Pdf pdf = new Pdf();
            pdf.print(table,"Product");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Excel ex = new Excel();
            ex.Print(table);
        }
    }
}
