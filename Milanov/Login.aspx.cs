using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Milanov
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        RegLogSystem rlSystem = new RegLogSystem();
        string m_Username, m_Password;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_Login_Click(object sender, EventArgs e)
        {
            bool checkLogin;
            m_Username = txt_Username.Text;
            m_Password = txt_Password.Text;

            //checkLogin = rlSystem.GetUsers(m_Username, m_Password);

            //if (checkLogin == true)
            //{
            //    lbl_CheckLogin.Text = "Login Succesfull";
            //}
            //else
            //{
            //    lbl_CheckLogin.Text = "Login Failed";
            //}

            lbl_CheckLogin.Text = rlSystem.GetUsers(m_Username, m_Password);
        }
    }
}