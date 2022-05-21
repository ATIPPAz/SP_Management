using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SP_Management.Classes;

namespace SP_Management
{
    public partial class SPM : Form
    {
        string ClickData = "";
        public SPM()
        {
            InitializeComponent();
            resizeMenuPanel();
            CloseAllSubMenu();
        }

     

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit(); 
        }

      

        private void SPM_Load(object sender, EventArgs e)
        {
            if (Route.isStartUp)
            {
                Route.isStartUp = false;
                Route.index.Hide();
            }
            //Load data Employee
            string cmd = $"select * form dbo.Employees e Where e.EmpID = {MiddleStore.EmpID}";
            Sql.RunCommand(cmd);
            Sql._adapter.SelectCommand = Sql._command;
            DataTable EmplyeeData = new DataTable();
            Sql._adapter.Fill(EmplyeeData);
            //fillter with rule employee
            LoadMenuListBtn();
        }
        void LoadMenuListBtn()
        {
            /*foreach (DataRow item in data)
            {
                
            }*/
        }
        private void Logoutbutton_Click(object sender, EventArgs e)
        {
            Toast.Success("Logout Success");
            Route.CreateLoginPage(null);
           // Route.CreateLoginPage(this);
        }

        void resizeMenuPanel()
        {
            DisplayPanel.Width = (MenuListPanel.Width == 200) ? DisplayPanel.Width + 195 : DisplayPanel.Width - 195;
            DisplayPanel.Location = (MenuListPanel.Width == 200) ? new Point(DisplayPanel.Location.X - 195, DisplayPanel.Location.Y) : new Point(DisplayPanel.Location.X + 195, DisplayPanel.Location.Y);
            MenuListPanel.Width = (MenuListPanel.Width == 200) ? 0 : 200;
            if (MenuListPanel.Width == 200)
            {
                //showlist
            }
            else
            {
                //hideist show icon
            }
        }

        private void MenuListBtn_Click(object sender, EventArgs e)
        {
            resizeMenuPanel();
           /* foreach (Control c in ((Control)MenuListPanel).Controls)
            {
                if (c is Button)
                {
                    
                        Console.WriteLine("Name: " + c.Name + "  Back Color: " + c.BackColor);
                    
                }
            }*/
        }

        private void MarketingBtn_Click(object sender, EventArgs e)
        {
            ClickData = (ClickData== "Marketing") ?"" : "Marketing";
            ShowSubMenu();
        }
        void ShowSubMenu()
        {
            CloseAllSubMenu();
            if (ClickData == "Marketing")
            {
                CreateProductMktBtn.Show();
                CreatePurchaseMktBtn.Show();
            }
            else if (ClickData == "WareHouse")
            {
                ReceiptionWhBtn.Show();
                RequisitionWhBtn.Show();
            }
            else if (ClickData == "Packing")
            {
                OrderPkBtn.Show();
                RequisitionPkBtn.Show();
            }
            else if (ClickData == "Shipping")
            {
                OrdersSpBtn.Show();
            }
            else if (ClickData == "Hr")
            {
                UserlistHrBtn.Show();
            }
            else if (ClickData == "Finance")
            {
                ExpensesFnBtn.Show();
                RevenueFnBtn.Show();
            }
            else if (ClickData == "Purchasing")
            {
                PurchasePcBtn.Show();
                ReceiptionPcBtn.Show();
            }
            else if(ClickData=="") 
            {
                CloseAllSubMenu();
            }
        }
        void CloseAllSubMenu()
        {
            OrdersSpBtn.Hide();
            ExpensesFnBtn.Hide();
            RevenueFnBtn.Hide();
            PurchasePcBtn.Hide();
            ReceiptionPcBtn.Hide();
            CreateProductMktBtn.Hide();
            CreatePurchaseMktBtn.Hide();
            ReceiptionWhBtn.Hide();
            RequisitionWhBtn.Hide();
            OrderPkBtn.Hide();
            UserlistHrBtn.Hide();
            RequisitionPkBtn.Hide();
        }

        private void WarehouseBtn_Click(object sender, EventArgs e)
        {
            ClickData = (ClickData == "WareHouse") ? "" : "WareHouse";
            ShowSubMenu();
        }

        private void PackingBtn_Click(object sender, EventArgs e)
        {
            ClickData = (ClickData == "Packing") ? "" : "Packing";
            ShowSubMenu();
        }

        private void PurchasingBtn_Click(object sender, EventArgs e)
        {
            ClickData = (ClickData == "Purchasing") ? "" : "Purchasing";
            ShowSubMenu();
        }

        private void FinanceBtn_Click(object sender, EventArgs e)
        {
            ClickData = (ClickData == "Finance") ? "" : "Finance";
            ShowSubMenu();
        }

        private void HrBtn_Click(object sender, EventArgs e)
        {
            ClickData = (ClickData == "Hr") ? "" : "Hr";
            ShowSubMenu();
        }

        private void ShippingBtn_Click(object sender, EventArgs e)
        {
            ClickData = (ClickData == "Shipping") ? "" : "Shipping";
            ShowSubMenu();
        }
    }
}
