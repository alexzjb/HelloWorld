using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DAL
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            using (var db = new FrameWorkEntitiesContext())
            {
                //var user = db.sys_User.SqlQuery("SELECT * FROM sys_User WHERE LoginName like '%alex%'");
                var user = db.sys_User.Where(p => p.LoginName.Contains("alex")).OrderBy(p => p.UserID);
                foreach (var p in user)
                {
                    this.Text=string.Format("UserID:{0},NameCN:{1}", p.UserID, p.NameCN);
                }
            }
        }
    }
}
