using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsAppsql
{
    public partial class Class : Form
    {
        SqlConnection connection;
        SqlCommand command;
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable dt = new DataTable();

        string str = @"Data Source=DESKTOP-QK3DT1M;Initial Catalog=StudentManagementASM;Integrated Security=True";

        public Class()
        {
            InitializeComponent();
        }

        public void FillData()
        {
            command = connection.CreateCommand();
            command.CommandText = "select * from Class";
            adapter.SelectCommand = command;
            dt.Clear();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void Class_Load(object sender, EventArgs e)
        {
            connection = new SqlConnection(str);
            connection.Open();
            FillData();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            command = connection.CreateCommand();
            command.CommandText = "insert into Class values('" + txtID.Text + "','" + txtCode.Text + "')";

            int rowsAffected = command.ExecuteNonQuery();
            if (rowsAffected > 0)
            {
                MessageBox.Show("Inserted Successfully!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Insertion failed! Check your data and try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            FillData();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dataGridView1.CurrentRow.Index;

            txtID.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
            txtCode.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            command = connection.CreateCommand();
            command.CommandText = "UPDATE Class SET ClassCode = '" + txtCode.Text + "' WHERE ClassID = '" + txtID.Text + "'";

            int rowsAffected = command.ExecuteNonQuery();
            if (rowsAffected > 0)
            {
                MessageBox.Show("Updated Successfully!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Update failed! The specified record was not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            FillData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            command = connection.CreateCommand();
            command.CommandText = "delete from Class where ClassID = '" + txtID.Text + "'";

            int rowsAffected = command.ExecuteNonQuery();
            if (rowsAffected > 0)
            {
                MessageBox.Show("Deleted Successfully!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Deletion failed! The specified record was not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            FillData();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 f = new Form2();
            f.ShowDialog();
            this.Dispose();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}
