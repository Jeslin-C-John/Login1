using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Login.Models
{
    public class userDbHandle
    {
        private SqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["UserConn"].ToString();
            con = new SqlConnection(constring);
        }

        public void adduser(LoginModel insert)
        {
            connection();
            SqlCommand cmd = new SqlCommand("InsertUser", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Name", insert.name);
            cmd.Parameters.AddWithValue("@Password", insert.password);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}