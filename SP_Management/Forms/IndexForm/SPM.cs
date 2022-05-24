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
using SP_Management.SqlActions;

namespace SP_Management
{
    public partial class SPM : Form
    {
        string ClickData = "";
        string EmpID = "";
        public SPM()
        {
            InitializeComponent();
            resizeMenuPanel();
            resizeMenuPanel();
            CloseAllSubMenu();
        }

        public void ReciptID(string id)
        {
            EmpID = id;
        }
       
        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit(); 
        }
        public void ExitApplication()
        {
            Application.Exit();
        }
        public void CloseDialog()
        {
            PagesManager.CloseDialog(DialogPanel);
        }
        private void SPM_Load(object sender, EventArgs e)
        {
            if (Route.isStartUp)
            {
                Route.isStartUp = false;
                Route.index.Hide();
            }
        }
        public void LoadMenuListBtn()
        {
            if (MiddleStore.EmpRuleID == "D01" || MiddleStore.EmpRuleID == "D09")
            {
                /*MarketingBtn.Show();
                CreateProductMktBtn.Show();
                CreatePurchaseMktBtn.Show();
                WarehouseBtn.Show();
                ReceiptionWhBtn.Show();
                RequisitionWhBtn.Show();
                PackingBtn.Show();
                OrderPkBtn.Show();
                RequisitionPkBtn.Show();
                PurchasePcBtn.Show();
                ReceiptionPcBtn.Show();
                PurchasingBtn.Show();
                FinanceBtn.Show();
                ExpensesFnBtn.Show();
                RevenueFnBtn.Show();
                HrBtn.Show();
                UserlistHrBtn.Show();
                ShippingBtn.Show();
                OrdersSpBtn.Show();*/
            }
            else if(MiddleStore.EmpRuleID == "D02")
            {
                MarketingBtn.Hide();
                CreateProductMktBtn.Hide();
                CreatePurchaseMktBtn.Hide();
                WarehouseBtn.Hide();
                ReceiptionWhBtn.Hide();
                RequisitionWhBtn.Hide();
                PackingBtn.Hide();
                OrderPkBtn.Hide();
                RequisitionPkBtn.Hide();
                PurchasePcBtn.Hide();
                ReceiptionPcBtn.Hide();
                PurchasingBtn.Hide();
                FinanceBtn.Show();
                /*ExpensesFnBtn.Show();
                RevenueFnBtn.Show();*/
                HrBtn.Hide();
                UserlistHrBtn.Hide();
                ShippingBtn.Hide();
                OrdersSpBtn.Hide();
            }
            else if (MiddleStore.EmpRuleID == "D03")
            {
                MarketingBtn.Hide();
                CreateProductMktBtn.Hide();
                CreatePurchaseMktBtn.Hide();
                /*WarehouseBtn.Show();
                ReceiptionWhBtn.Show();
                RequisitionWhBtn.Show();*/
                PackingBtn.Hide();
                OrderPkBtn.Hide();
                RequisitionPkBtn.Hide();
                PurchasePcBtn.Hide();
                ReceiptionPcBtn.Hide();
                PurchasingBtn.Hide();
                FinanceBtn.Hide();
                ExpensesFnBtn.Hide();
                RevenueFnBtn.Hide();
                HrBtn.Hide();
                UserlistHrBtn.Hide();
                ShippingBtn.Hide();
                OrdersSpBtn.Hide();
            }
            else if (MiddleStore.EmpRuleID == "D04")
            {
              /*  MarketingBtn.Show();
                CreateProductMktBtn.Show();
                CreatePurchaseMktBtn.Show();*/
                WarehouseBtn.Hide();
                ReceiptionWhBtn.Hide();
                RequisitionWhBtn.Hide();
                PackingBtn.Hide();
                //OrderPkBtn.Show();
                RequisitionPkBtn.Hide();
                PurchasePcBtn.Hide();
                ReceiptionPcBtn.Hide();
                PurchasingBtn.Hide();
                FinanceBtn.Hide();
                ExpensesFnBtn.Hide();
                RevenueFnBtn.Hide();
                HrBtn.Hide();
                UserlistHrBtn.Hide();
                ShippingBtn.Hide();
                OrdersSpBtn.Hide();
            }
            else if (MiddleStore.EmpRuleID == "D05")
            {
                MarketingBtn.Hide();
                CreateProductMktBtn.Hide();
                CreatePurchaseMktBtn.Hide();
                WarehouseBtn.Hide();
                ReceiptionWhBtn.Hide();
                RequisitionWhBtn.Hide();
                PackingBtn.Hide();
                OrderPkBtn.Hide();
                RequisitionPkBtn.Hide();
              /*  PurchasePcBtn.Show();
                ReceiptionPcBtn.Show();
                PurchasingBtn.Show();*/
                FinanceBtn.Hide();
                ExpensesFnBtn.Hide();
                RevenueFnBtn.Hide();
                HrBtn.Hide();
                UserlistHrBtn.Hide();
                ShippingBtn.Hide();
                OrdersSpBtn.Hide();
            }
            else if (MiddleStore.EmpRuleID == "D06")
            {
                MarketingBtn.Hide();
                CreateProductMktBtn.Hide();
                CreatePurchaseMktBtn.Hide();
                WarehouseBtn.Hide();
                ReceiptionWhBtn.Hide();
                RequisitionWhBtn.Hide();
                PackingBtn.Hide();
                OrderPkBtn.Hide();
                RequisitionPkBtn.Hide();
                PurchasePcBtn.Hide();
                ReceiptionPcBtn.Hide();
                PurchasingBtn.Hide();
                FinanceBtn.Hide();
                ExpensesFnBtn.Hide();
                RevenueFnBtn.Hide();
               /* HrBtn.Show();
                UserlistHrBtn.Show();*/
                ShippingBtn.Hide();
                OrdersSpBtn.Hide();
            }
            else if (MiddleStore.EmpRuleID == "D07")
            {
                MarketingBtn.Hide();
                CreateProductMktBtn.Hide();
                CreatePurchaseMktBtn.Hide();
                WarehouseBtn.Hide();
                ReceiptionWhBtn.Hide();
                RequisitionWhBtn.Hide();
                /*PackingBtn.Show();
                OrderPkBtn.Show();*/
                RequisitionPkBtn.Hide();
                PurchasePcBtn.Hide();
                ReceiptionPcBtn.Hide();
                PurchasingBtn.Hide();
                FinanceBtn.Hide();
                ExpensesFnBtn.Hide();
                RevenueFnBtn.Hide();
                HrBtn.Hide();
                UserlistHrBtn.Hide();
                ShippingBtn.Hide();
                OrdersSpBtn.Hide();
            }
            else if (MiddleStore.EmpRuleID == "D08")
            {
                MarketingBtn.Hide();
                CreateProductMktBtn.Hide();
                CreatePurchaseMktBtn.Hide();
                WarehouseBtn.Hide();
                ReceiptionWhBtn.Hide();
                RequisitionWhBtn.Hide();
                PackingBtn.Hide();
                OrderPkBtn.Hide();
                RequisitionPkBtn.Hide();
                PurchasePcBtn.Hide();
                ReceiptionPcBtn.Hide();
                PurchasingBtn.Hide();
                FinanceBtn.Hide();
                ExpensesFnBtn.Hide();
                RevenueFnBtn.Hide();
                HrBtn.Hide();
                UserlistHrBtn.Hide();
               /* ShippingBtn.Show();
                OrdersSpBtn.Show();*/
            }
           
            /*foreach (DataRow item in data)
            {
                
            }*/
        }
        private void Logoutbutton_Click(object sender, EventArgs e)
        {
            Toast.Success("Logout Success");
            Route.CreateLoginPage(null);
        }

        void resizeMenuPanel()
        {
            DisplayPanel.Width = (MenuListPanel.Width == 200) ? DisplayPanel.Width + 150 : DisplayPanel.Width - 150;
            DisplayPanel.Location = (MenuListPanel.Width == 200) ? new Point(DisplayPanel.Location.X - 150, DisplayPanel.Location.Y) : new Point(DisplayPanel.Location.X + 150, DisplayPanel.Location.Y);
           PanelManu.Width =  (MenuListPanel.Width == 200) ? 50 : 200;
            MenuListPanel.Width = (MenuListPanel.Width == 200) ? 50 : 200;
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

        private void UserlistHrBtn_Click(object sender, EventArgs e)
        {
            OpenUserList();
        }

        private void MinimumBtn_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void ExitBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void CreateProductMktBtn_Click(object sender, EventArgs e)
        {
            PagesManager.OpenPage("ProductListMk", DisplayPanel, true);
            DialogPanel.SendToBack();
        }
        public void OpenNewUserPage()
        {
            PagesManager.OpenDialog("AddUser", DialogPanel, false);
            DialogPanel.BringToFront();
        }
        public void OpenEditUserPage(string id)
        {
            PagesManager.OpenDialog("EditUser",id, DialogPanel, false);
            DialogPanel.BringToFront();
        }
        public void OpenUserList()
        {
            PagesManager.OpenPage("Userlist", DisplayPanel, true);
            DialogPanel.SendToBack();
        }

        private void OrderPkBtn_Click(object sender, EventArgs e)
        {
           
            PagesManager.OpenPage("OrderPk", DisplayPanel, true);
            DialogPanel.SendToBack();
        }

        private void OrdersSpBtn_Click(object sender, EventArgs e)
        {
           
            PagesManager.OpenPage("Shipping", DisplayPanel, true);
            DialogPanel.SendToBack();
        }
    }
}
