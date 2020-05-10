using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace teklogin
{
    public partial class RemoveCourseForm : Form
    {
        public RemoveCourseForm()
        {
            InitializeComponent();
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {

            try
            {
                Course course = new Course();
                course.Id = Convert.ToInt32(textBoxCourseId.Text);

                

                if (MessageBox.Show("Are you sure you want to remove this cours?", "delete course", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    if (course.Delete())
                    {
                        MessageBox.Show("Course Deleted", "Remove Course", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Course Not Deleted", "Remove Course", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
            catch
            {

                MessageBox.Show("Enter a valid course id", "Remove Course", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
           
        }

        private void RemoveCourseForm_Load(object sender, EventArgs e)
        {

        }
    }
}
