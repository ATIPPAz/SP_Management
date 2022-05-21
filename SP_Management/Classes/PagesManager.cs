using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SP_Management.Pages.HumanResource;
using System.Windows.Forms;
using SP_Management.Pages.HumanResourcePage;
namespace SP_Management.Classes
{
    public class PagesManager
    {
        static UserControl page = null;
        string FromCurrent = "";
        public static void OpenPage(string pageSelct,Panel panel)
        {
            CloseAnotherPage(panel);
            if(pageSelct !="")
            {
                if (pageSelct == "Userlist")
                {
                    page = new UserlistPage();
                }
                else if(pageSelct == "AddUser")
                {
                    page = new AddUserPage();
                }
                page.Dock = DockStyle.Fill;
                panel.Controls.Add(page);
            }
        }
        public static void CloseAnotherPage(Panel panel)
        {
            if(page != null)
            {
            panel.Controls.Remove(page);
                page.Dispose();
            }
        }
    }
}
