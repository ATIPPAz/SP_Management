using SP_Management.SqlActions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SP_Management.Others
{
    public static class Route
    {
        public static Login Login;
        public static SPM index;
        public static bool isStartUp = true;
        public static Form StartUp()
        {
            index = new SPM();
            Login = new Login();
            index.Opacity = 0;
            Login.Show();
            Login.TopMost = true;
            return index;
        }
        public static void CreateLoginPage(Form form)
        {
            Login = new Login();
            isStartUp = true;
            Login.Show();
            Login.TopMost = true;
            index.Opacity = 0;
            if(form != null)
            {
            form.Close();
            }
            index.Hide();
        }
        public static void CloseLoginForm()
        {
            Login.Close();
            Login.Dispose();
        }
        public static void OpenIndex()
        {
            
            DataTable EmplyeeData = new DataTable();
            var getdata = new GetOne();
            EmplyeeData = getdata.GetData(ColumnSelect: "EmpID", Table: new string[] { "Employees" }, CallTable: new string[] { "e" }, IDSelect: MiddleStore.EmpID);
            foreach (DataRow item in EmplyeeData.Rows)
            {
                MiddleStore.EmpRuleID = item["DeptID"].ToString();
                // MiddleStore.EmpID = 
            }
            index.Opacity = 1;
            index.Show();
            MiddleStore.EmpRule = (MiddleStore.EmpRuleID == "D04") ? "Packing" : (MiddleStore.EmpRuleID == "D09") ? "God" : (MiddleStore.EmpRuleID == "D08") ? "Shipping" : (MiddleStore.EmpRuleID == "D01") ? "Exclusive" : (MiddleStore.EmpRuleID == "D02") ? "Finance" : (MiddleStore.EmpRuleID == "D03") ? "Warehouse" : (MiddleStore.EmpRuleID == "D05") ? "Purchase" : (MiddleStore.EmpRuleID == "D06") ? "Hr" : "";
            index.LoadMenuListBtn();
        }
        public static void CloseIndex()
        {
            index.Close();
            Application.Exit();
        }
    }
}
