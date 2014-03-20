using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Milanov
{
    public partial class Register : System.Web.UI.Page
    {
        string m_Username;
        string m_Password;
        string m_PasswordCheck;
        bool m_CorrectUsername = false;
        bool m_CorrectPassword = false;
        bool m_CorrectPasswordCheck = false;
        bool m_MasterCheck = false;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //Check if the username is within bounds
        public bool CheckUserName(string userName)
        {
            m_Username = userName;

            if(Regex.IsMatch(m_Username, @"^[a-zA-Z0-9]*$"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Check if the password is within bounds
        public bool CheckPassword(string password)
        {
            m_Password = password;

            if (Regex.IsMatch(m_Password, @"^[a-zA-Z0-9]*$"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Check if the password check is within bounds
        public bool CheckPasswordCheck(string passwordCheck)
        {
            m_PasswordCheck = passwordCheck;

            if (Regex.IsMatch(m_PasswordCheck, @"^[a-zA-Z0-9]*$"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Check if all are true
        public bool MasterCheck(bool username, bool password, bool passwordCheck)
        {
            if (username == true && password == true && passwordCheck == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Register user in the database
        public void RegisterUser(string userName, string password, string passwordCheck)
        {
            m_Username = userName;
            m_Password = password;
            m_PasswordCheck = passwordCheck;

            if (m_Password == m_PasswordCheck)
            {
                string sqlStr = @"INSERT INTO USERS (USERNAME, PASSWORD) 
                    VALUES (@NAME, @PASSWORD)";
                string connStr = ConfigurationManager.ConnectionStrings["Milanov_DB"]
                    .ConnectionString;

                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    using (SqlCommand cmd = new SqlCommand(sqlStr, conn))
                    {
                        cmd.Parameters.AddWithValue("@NAME", m_Username);
                        cmd.Parameters.AddWithValue("@PASSWORD", m_Password);//String.IsNullOrWhiteSpace(product.PRODUCT_TEXT) ? DBNull.Value : (object)product.PRODUCT_TEXT);

                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

        //Register Button
        protected void txt_Register_Click(object sender, EventArgs e)
        {
            m_MasterCheck = MasterCheck(CheckUserName(txt_Username.Text), 
                                        CheckPassword(txt_Password.Text), 
                                        CheckPasswordCheck(txt_PasswordCheck.Text));
            if (m_MasterCheck == true)
            {
                RegisterUser(txt_Username.Text, txt_Password.Text, txt_PasswordCheck.Text);
                string alert = "alert('Registering Succes!');";
                ScriptManager.RegisterStartupScript(this, GetType(), "JScript", alert, true);
            }
            else
            {
                string alert = "alert('Registering Failed!');";
                ScriptManager.RegisterStartupScript(this, GetType(), "JScript", alert, true);
            }
        }
    }
}