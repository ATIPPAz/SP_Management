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
using SP_Management.Controls.Tables;
namespace SP_Management.Pages.PackingPage
{
    public partial class OrderLists : UserControl
    {
        public OrderLists()
        {
            InitializeComponent();
        }

        private void OrderLists_Load(object sender, EventArgs e)
        {
            HeaderTable header = new HeaderTable();
            header.CreateHeader(new float[] { 25, 25, 25, 25 },new string[]{"ID","Name","LastName","age"},HeaderPanel);
            if(MiddleStore.EmpRule =="D001"||MiddleStore.EmpRule == "D004"|| MiddleStore.EmpRule == "D007" || MiddleStore.EmpRule == "D008" )
            {
                if(MiddleStore.EmpRule == "D001")
                {
                    //ห้ามกดปุ่มดูได้อย่างเดียว ออเดอร์ทุกอย่าง select * from order o 
                }
                else if (MiddleStore.EmpRule == "D004")
                {
                    //ห้ามกดปุ่มดูได้อย่างเดียว ออเดอร์ทุกอย่าง select * from order o 
                }
                else if (MiddleStore.EmpRule == "D007")
                {
                    //ดูได้ออเดอร์ที่จ่ายเเล้ว select * from order o where o.OrStatusID = 'OS002'
                }
                else if (MiddleStore.EmpRule == "D008")
                {
                    //ดูได้ออเดอร์เเพ็คเเล้ว select * from order o where o.OrStatusID = 'OS003'
                }
            }
        }
    }
}
