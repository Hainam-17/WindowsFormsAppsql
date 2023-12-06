using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsAppsql
{
    public partial class Form1 : Form
    {
        SqlConnection connection;

        public Form1()
        {
            InitializeComponent();
            connection = new SqlConnection("Data Source=DESKTOP-QK3DT1M;Initial Catalog=StudentManagementASM;Integrated Security=True");
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnlog_Click(object sender, EventArgs e)
        {
            string username = txtuser.Text;
            string password = txtpass.Text;
            string query = "select * from Account where userName = @username and pass = @password";
            connection.Open();
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@username", SqlDbType.VarChar);
            cmd.Parameters["@username"].Value = username;
            cmd.Parameters.AddWithValue("@password", SqlDbType.VarChar);
            cmd.Parameters["@password"].Value = password;
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                MessageBox.Show(this, "Login Successfully !!!", "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
                Form2 f = new Form2();
                f.ShowDialog();
                this.Dispose();
            }
            else
            {
                MessageBox.Show(this, "Login Failed !!!", "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void cbpass_CheckedChanged(object sender, EventArgs e)
        {
            if (cbpass.Checked == true)
            {
                txtpass.PasswordChar = '\0';
            }
            else
            {
                txtpass.PasswordChar = '*';
            }
        }

       
    }
}
