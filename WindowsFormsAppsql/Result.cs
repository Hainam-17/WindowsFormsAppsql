using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace WindowsFormsAppsql
{
    public partial class Result : Form
    {

        SqlConnection connection;
        SqlCommand command;
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable dt = new DataTable();

        string str = @"Data Source=DESKTOP-QK3DT1M;Initial Catalog=StudentManagementASM;Integrated Security=True";

        public Result()
        {
            InitializeComponent();
        }

        public void FillData()
        {
            command = connection.CreateCommand();
            command.CommandText = "select * from Result";
            adapter.SelectCommand = command;
            dt.Clear();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void Result_Load(object sender, EventArgs e)
        {
            connection = new SqlConnection(str);
            connection.Open();
            FillData();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection("Data Source=DESKTOP-QK3DT1M;Initial Catalog=StudentManagementASM;Integrated Security=True"))
                {
                    connection.Open();

                    using (SqlCommand command = connection.CreateCommand())
                    {
                        command.CommandText = "INSERT INTO Result VALUES (@SubjectID, @StudentID, @Mark)";

                        command.Parameters.AddWithValue("@SubjectID", txtSubjectID.Text);
                        command.Parameters.AddWithValue("@StudentID", txtStudentID.Text);
                        command.Parameters.AddWithValue("@Mark", float.Parse(txtMark.Text)); // Assuming txtMark.Text contains a valid float

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Inserted Successfully!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Insertion failed! Check your data and try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }

                FillData();
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection("Data Source=DESKTOP-QK3DT1M;Initial Catalog=StudentManagementASM;Integrated Security=True"))
                {
                    connection.Open();

                    using (SqlCommand command = connection.CreateCommand())
                    {
                        command.CommandText = "UPDATE Result SET SubjectID = @SubjectID, StudentID = @StudentID, Mark = @Mark";

                        command.Parameters.AddWithValue("@SubjectID", txtSubjectID.Text);
                        command.Parameters.AddWithValue("@StudentID", txtStudentID.Text);
                        command.Parameters.AddWithValue("@Mark", txtMark.Text);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Updated Successfully!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Update failed! The specified record was not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }

                FillData();
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection("Data Source=DESKTOP-QK3DT1M;Initial Catalog=StudentManagementASM;Integrated Security=True"))
                {
                    connection.Open();

                    using (SqlCommand command = connection.CreateCommand())
                    {
                        command.CommandText = "DELETE FROM Result WHERE SubjectID = @ID";
                        command.Parameters.AddWithValue("@ID", txtSubjectID.Text);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Deleted Successfully!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Deletion failed! The specified record was not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }

                FillData();
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 f = new Form2();
            f.ShowDialog();
            this.Dispose();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dataGridView1.CurrentRow.Index;

            txtSubjectID.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
            txtStudentID.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
            txtMark.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
        }
    }
}
