using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Windows_Login_Registration_Foem
{
    public partial class Form1 : Form
    {
        SqlConnection con = new SqlConnection();

        public Form1()
        {
            InitializeComponent();
            con.ConnectionString= @"Data Source=(localdb)\MSSQLLocalDB; Initial Catalog=Banking; Integrated Security=true";
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            if(con.State==ConnectionState.Closed)
            {
                con.Open();
            }
            cmd.CommandText = "select Accno, Name,Address from Customers where Name=@name";
            cmd.Parameters.AddWithValue("@name", txtName.Text.Trim());
            SqlDataReader dr = cmd.ExecuteReader();
            if(dr.HasRows)
            {
                dr.Read();
                if (dr[2].ToString().Equals(txtPwd.Text.Trim()))
                {
                    lblMsg.Text = "you are successfully logged in";
                }
                else
                {
                    lblMsg.Text = "pasword is incorrect";
                }
            }
            else
            {
                lblMsg.Text = "User not found! First do a REgistration";
            }
            dr.Close();
            con.Close();
        }

        private void lnkReg_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
      
        {
        }
    }
}
