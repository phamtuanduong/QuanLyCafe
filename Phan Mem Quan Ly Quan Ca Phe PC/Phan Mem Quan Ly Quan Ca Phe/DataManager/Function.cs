using Org.BouncyCastle.Operators;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Phan_Mem_Quan_Ly_Quan_Ca_Phe.DataManager
{
     class Function
    {
        protected SqlConnection getConnection()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=.\sqlexpress;Initial Catalog=DB_CafeManagement;Integrated Security=True";
            return con;
        }

        public DataSet getData(String query)
        {
            SqlConnection con = getConnection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = query;
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        public void setData(String query)
        {
            SqlConnection con = getConnection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            con.Open();
            cmd.CommandText = query;
            cmd.ExecuteNonQuery();
            con.Close();
        }

        //SqlConnection con = new SqlConnection(@"Data Source=.\sqlexpress;Initial Catalog=DB_CafeManagement;Integrated Security=True");
        //con.Open();
        //SqlCommand cmd = new SqlCommand(query,con);
        //cmd.Parameters.AddWithValue("@temp", (string)(g2txtItemName.Text));
        //SqlDataReader da = cmd.ExecuteReader();
        //while (da.Read())
        //{
        //    g2txtPrice.Text = da.GetValue(0).ToString();   
        //}
        //con.Close();
    }
}
