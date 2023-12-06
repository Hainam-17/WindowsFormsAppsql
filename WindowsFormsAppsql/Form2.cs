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
    public partial class Form2 : Form
    {

        public Form2()
        {
            InitializeComponent();
          
        }

       

        private void btnClass_Click(object sender, EventArgs e)
        {
            this.Hide();
            Class c = new Class();
            c.ShowDialog();
            this.Dispose();
        }

        private void btnStudent_Click(object sender, EventArgs e)
        {
            this.Hide();
            Student s = new Student();
            s.ShowDialog();
            this.Dispose();
        }

        private void btnSubject_Click(object sender, EventArgs e)
        {
            this.Hide();
            Subject sb = new Subject();
            sb.ShowDialog();
            this.Dispose();
        }

        private void btnResult_Click(object sender, EventArgs e)
        {
            this.Hide();
            Result r = new Result();
            r.ShowDialog();
            this.Dispose();
        }

        private void btnClass_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Class c = new Class();
            c.ShowDialog();
            this.Dispose();
        }
    }
}
