using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.IO;

namespace teklogin
{
    public partial class PrintStudentsForm : Form
    {
        public PrintStudentsForm()
        {
            InitializeComponent();
        }
        Student student = new Student();


        private void PrintStudentsForm_Load(object sender, EventArgs e)
        {
            FillGrid(new MySqlCommand("select *from student"));

            if (radioButtonNO.Checked)
            {
                dateTimePicker1.Enabled = false;
                dateTimePicker2.Enabled = false;
            }
        }
        //create a function to populate the datagridview
        public void FillGrid(MySqlCommand command)
        {
            //MySqlCommand command = new MySqlCommand("select *from student");
            dataGridView1.ReadOnly = true;
            DataGridViewImageColumn picCol = new DataGridViewImageColumn();
            dataGridView1.RowTemplate.Height = 80;
            dataGridView1.DataSource = student.getStudent(command);
            picCol = (DataGridViewImageColumn)dataGridView1.Columns[7];//is the image column index
            picCol.ImageLayout = DataGridViewImageCellLayout.Stretch;
            dataGridView1.AllowUserToAddRows = false;



        }

        private void radioButtonNO_CheckedChanged(object sender, EventArgs e)
        {
            dateTimePicker1.Enabled = false;
            dateTimePicker2.Enabled = false;
        }

        private void radioButtonYes_CheckedChanged(object sender, EventArgs e)
        {
            dateTimePicker1.Enabled = true;
            dateTimePicker2.Enabled = true;
        }

        private void buttonGo_Click(object sender, EventArgs e)
        {
            //display data on the datagridview depending what the user have selected

            MySqlCommand command;
            string query;

            //check if the radioButtonYes is checked that mean the user want to use a data range
            if (radioButtonYes.Checked == true)
            {
                //get the datavalues
                string date1 = dateTimePicker1.Value.ToString("yyyy-MM-dd");
                string date2 = dateTimePicker2.Value.ToString("yyyy-MM-dd");
                if (radioButtonMale.Checked == true)
                {
                    query = "select *from student where birthday between '" + date1 + "'and '" + date2 + "' and gender='Male'";
                }
                else if (radioButtonFemale.Checked == true)
                {
                    query = "select *from student where birthday between '" + date1 + "'and '" + date2 + "' and gender='Femele'";
                }
                else
                {
                    query = "select *from student where birthday between '" + date1 + "'and '" + date2 + "'";
                }

                command = new MySqlCommand(query);
                FillGrid(command);
            }

            else//display data without birthdate range
            {
                if (radioButtonMale.Checked == true)
                {
                    query = "select *from student where gender='Male'";
                }
                else if (radioButtonFemale.Checked == true)
                {
                    query = "select *from student where gender='Femele'";
                }
                else
                {
                    query = "select *from student ";
                }

                command = new MySqlCommand(query);
                FillGrid(command);
            }
        }

       
        //print data from datagridview to text file
        private void buttonPrintStudent_Click(object sender, EventArgs e)
        {

            //our file path
            //file name=Students_list.text
            //location desktop
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\Students_list.text";
            using (var writer = new StreamWriter(path))
            {
                //check if the file exist
                if (!File.Exists(path))
                {
                    File.Create(path);
                }

                DateTime bdate;
                for (int i = 0; i < dataGridView1.Rows.Count; i++)//rows
                {

                    for (int j = 0; j < dataGridView1.Columns.Count - 1; j++)//columns
                    {
                        if (j == 6)//birthdate column
                        {
                            bdate = Convert.ToDateTime(dataGridView1.Rows[i].Cells[j].Value.ToString());
                            writer.Write("\t" + bdate.ToString("yyyy-MM-dd") + "\t" + "|");
                        }
                        else if (j == dataGridView1.Columns.Count - 2)//last column
                        {
                            writer.Write("\t" + dataGridView1.Rows[i].Cells[j].Value.ToString());
                        }
                        else
                        {
                            writer.Write("\t" + dataGridView1.Rows[i].Cells[j].Value.ToString() + "\t" + "|");

                        }


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