using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace Milanov
{
    public class RegLogSystem
    {
        SqlConnection con;
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        DataTable dt;
        DataRow dr;
        SqlCommandBuilder cmdBuilder;

        public string GetUsers(string username, string password)
        {
            bool checkLogin = false;
            string test = string.Empty;

            con = new SqlConnection(ConfigurationManager.ConnectionStrings["Milanov_DB"].ConnectionString);
            cmd.CommandText = "SELECT * FROM USERS";
            cmd.Connection = con;
            da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            dt = ds.Tables[0];
            cmdBuilder = new SqlCommandBuilder(da);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dr = dt.Rows[i];

                if (dr.ItemArray[1].Equals(username))
                {
                    test = dr.ItemArray[1].ToString();
                    checkLogin = true;
                    break;
                }
            }

            //return checkLogin;
            return test;
            //return dt.Rows[0].ItemArray[1].ToString();
        }
    }
}