using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using Model;
namespace MvcThreeModel
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint, true);
        }

        private void button_register_Click(object sender, EventArgs e)
        {
            register r = new register();
            r.Show();
            this.Hide();
        }

        private void btLogin_Click(object sender, EventArgs e)
        {
            string username = tbAccount.Text.Trim();
            string password = tbPassword.Text.Trim();
            if (username =="")
            {
                MessageBox.Show("账号不能为空！");
            }
            else if (password =="")
            {
                MessageBox.Show("密码不能为空!");
            }
            else
            {
               TeacherBll teabll = new TeacherBll();
               Teacher tea = teabll.GetUserInfoModel(username, password);
                if (tea != null)
                {
                    Main t = new Main(tbAccount.Text.Trim());
                    t.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("登录失败，账号或密码错误","错误提示",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }
        }

        private void login_Load(object sender, EventArgs e)
        {
            
             skinEngine1.SkinFile = Application.StartupPath + @"\DiamondGreen.ssk";
        }

        
    }
}
