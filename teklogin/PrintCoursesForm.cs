using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace teklogin
{
    public partial class PrintCoursesForm : Form
    {
        public PrintCoursesForm()
        {
            InitializeComponent();
        }

        private void PrintCoursesForm_Load(object sender, EventArgs e)
        {
            //populate the datagridview with cours

            Course course = new Course();
            dataGridView1.DataSource = course.GetAll();
        }


        //print data from datagridview to text file
        private void buttonPrintCourses_Click(object sender, EventArgs e)
        {


            //our file path
            //file name=Courses_list.text
            //location desktop
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\Courses_list.text";
            using (var writer = new StreamWriter(path))
            {
                //check if the file exist
                if (!File.Exists(path))
                {
                    File.Create(path);
                }

                for (int i = 0; i < dataGridView1.Rows.Count; i++)//rows
                {

                    for (int j = 0; j < dataGridView1.Columns.Count; j++)//columns
                    {
                        writer.Write("\t" + dataGridView1.Rows[i].Cells[j].Value+ "\t" + "|");

                    }
                    writer.WriteLine();
                    writer.WriteLine("-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
                }

                writer.Close();
                MessageBox.Show("Data exported");
            }

        }



    }
}
