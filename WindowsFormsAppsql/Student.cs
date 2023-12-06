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
using static System.Runtime.CompilerServices.RuntimeHelpers;

namespace WindowsFormsAppsql
{
    public partial class Student : Form
    {
        SqlConnection connection;
        SqlCommand command;
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable dt = new DataTable();

        string str = @"Data Source=DESKTOP-QK3DT1M;Initial Catalog=StudentManagementASM;Integrated Security=True";

        public Student()
        {
            InitializeComponent();
        }

        public void FillData()
        {
            command = connection.CreateCommand();
            command.CommandText = "select * from Student";
            adapter.SelectCommand = command;
            dt.Clear();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void Student_Load(object sender, EventArgs e)
        {
            connection = new SqlConnection(str);
            connection.Open();
            FillData();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                command = connection.CreateCommand();
                command.CommandText = "INSERT INTO Student VALUES (@ID, @Name, @BirthDate, @ClassID)";

                // Assuming dtBirth is a DateTimePicker or similar control
                command.Parameters.AddWithValue("@ID", txtID.Text);
                command.Parameters.AddWithValue("@Name", txtName.Text);
                command.Parameters.AddWithValue("@BirthDate", dtBirth.Value); // Use the Value property for DateTimePicker
                command.Parameters.AddWithValue("@ClassID", txtClassID.Text);

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
            catch (SqlException ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close();
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
                        command.CommandText = "UPDATE Student SET StudentName = @StudentName, Birthday = @BirthDate, ClassID = @ClassID WHERE StudentID = @StudentID";

                        command.Parameters.AddWithValue("@StudentID", txtID.Text);
                        command.Parameters.AddWithValue("@StudentName", txtName.Text);
                        command.Parameters.AddWithValue("@BirthDate", dtBirth.Text); // Assuming dtBirth is a TextBox, adjust accordingly
                        command.Parameters.AddWithValue("@ClassID", txtClassID.Text);

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
                        command.CommandText = "DELETE FROM Student WHERE StudentID = @StudentID";
                        command.Parameters.AddWithValue("@StudentID", txtID.Text);

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

            txtID.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
            txtName.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
            dtBirth.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
            txtClassID.Text = dataGridView1.Rows[i].Cells[3].Value.ToString();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}
