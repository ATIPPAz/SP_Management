using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SP_Management.Others;
using SP_Management.Controls.Tables;
using SP_Management.SqlActions;

namespace SP_Management.Pages.PackingPage
{
    public partial class OrderListsPacking : UserControl
    {
        public OrderListsPacking()
        {
            InitializeComponent();
        }

        private void OrderLists_Load(object sender, EventArgs e)
        {
            HeaderTable header = new HeaderTable();
           
                
                    header.CreateHeader(new float[] { 10, 20, 15, 15, 10, 10 }, new string[] { "OrderID", "OrderDate", "CreateDate", "ShipID", "Remark", "Ation" }, HeaderPanel);
                
            CreateBody();


        }
        DataTable Orderlist;
        void CreateBody()
        {
            BodyPanel.Controls.Clear();
            BodyTable body = new BodyTable();
            GetOne getOrder = new GetOne();
             Orderlist = getOrder.GetData(Table: new string[] { "Orders" }, CallTable: new string[] { "o" }, ColumnSelect: "OrStatusID", IDSelect: "OS02");
            foreach (DataRow item in Orderlist.Rows)
            {
                body.CreateBody(
                    Size: new float[] { 10, 20, 15, 15, 10, 10 },
                    BodyText: new string[] {
                        item["OrderID"].ToString(),
                        item["OrderDate"].ToString(),
                        item["CreateDate"].ToString(),
                        item["ShipID"].ToString(),
                        item["Annotation"].ToString()
                    },
                    img: new Image[] { Properties.Resources.Correct },
                    panel: BodyPanel);
                Update updateStatud = new Update();
                body.EditBtn.Click += new EventHandler((object o, EventArgs e) =>
                {
                    updateStatud.Updatedata(SelectRowUpdate: "OrderID", SelectValue: item["OrderID"].ToString(), Table: "Orders", ColoumnUpdate: new string[] { "OrStatusID" }, ColumnValue: new string[] { "OS03" });
                    CreateBody();
                });
            }

                }

        private void ToPdfBtn_Click(object sender, EventArgs e)
        {
            Pdf p = new Pdf();
            p.print(Orderlist, "OrderList");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Excel ex = new Excel();
            ex.Print(Orderlist);
        }
    }
        }
    

