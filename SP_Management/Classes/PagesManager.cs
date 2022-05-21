using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SP_Management.Pages.HumanResourcePage;
namespace SP_Management.Classes
{
    public class PagesManager
    {
        static UserControl page = null;
        static string PageCurrent = "";
        public static void OpenPage(string pageSelct,Panel panel,bool close)
        {
            if (close)
            {
            CloseAnotherPage(panel);
            }
            if(pageSelct !="")
            {
                if (pageSelct == "Userlist" && PageCurrent!= "Userlist") 
                {
                    page = new UserlistPage();
                    PageCurrent = "Userlist";
                }
                else if(pageSelct == "AddUser" && PageCurrent != "AddUser")
                {
                    page = new AddUserPage();
                    PageCurrent = "AddUser";
                }
                page.Dock = DockStyle.Fill;
                panel.Controls.Add(page);
            }
        }

        public static void OpenPage(string pageSelct,string id, Panel panel, bool close)
        {
            if (close)
            {
                CloseAnotherPage(panel);
            }
            if (pageSelct != "")
            {
                if (pageSelct == "EditUser" && PageCurrent != "EditUser")
                {
                    page = new EditUserPage(id);
                    PageCurrent = "EditUser";
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
