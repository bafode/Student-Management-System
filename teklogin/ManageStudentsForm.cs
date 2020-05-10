using System;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.IO;
using System.Drawing.Imaging;

namespace teklogin
{
    public partial class ManageStudentsForm : Form
    {
        public ManageStudentsForm()
        {
            InitializeComponent();
        }

        Student student = new Student();
   

        private void ManageStudentsForm_Load(object sender, EventArgs e)
        {
            //populate the datagridview with student data
            FillGrid(new MySqlCommand("select *from student"));
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

            //show the total students depending on dgvi rows
            labelTotalStudents.Text = "Total Students: " + dataGridView1.RowCount; //dataGridView1.Rows.Count

        }
        //display student data on the datagridview
        private void dataGridView1_Click(object sender, EventArgs e)
        {
            textBoxId.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textboxfirstname.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBoxlastname.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBoxPhone.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBoxAdress.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            //gender
            if (dataGridView1.CurrentRow.Cells[5].Value.ToString()=="Male")
            {
                radioButtonMale.Checked = true;
            }
            else
            {
                radioButtonFemele.Checked = true;
            }
            dateTimePickerBitthday.Value = (DateTime)dataGridView1.CurrentRow.Cells[6].Value;
            byte[] pic = (byte[])dataGridView1.CurrentRow.Cells[7].Value;
            MemoryStream picture = new MemoryStream(pic);
            pictureBoxStudentImage.Image = Image.FromStream(picture);


        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            textBoxId.Text = "";
            textboxfirstname.Text ="";
            textBoxlastname.Text = "";
            textBoxPhone.Text ="";
            textBoxAdress.Text ="";
            radioButtonMale.Checked = true;
            dateTimePickerBitthday.Value = DateTime.Now;
            pictureBoxStudentImage.Image = null;
        }

        //browse and and display image grom your computer to imagebox
        private void buttonUpload_Click(object sender, EventArgs e)
        {
            //browse image from your computer

            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "select image (*.jpg;*.png;*.gif)|*.jpg;*.png;*.gif";
            if (opf.ShowDialog() == DialogResult.OK)
            {
                pictureBoxStudentImage.Image = Image.FromFile(opf.FileName);
            }
        }

        //save the image in your computer
        private void buttonDowload_Click(object sender, EventArgs e)
        {
            SaveFileDialog svf = new SaveFileDialog();
            //set the file image
            svf.FileName = "Student_" + textBoxId.Text;
            //chech if the picture box is empty
            if (pictureBoxStudentImage.Image==null)
            {
                MessageBox.Show("No image in the picture box");
            }
            else if (svf.ShowDialog()==DialogResult.OK)
            {
                pictureBoxStudentImage.Image.Save(svf.FileName + ("." + ImageFormat.Jpeg.ToString()));
            }
        }

        //research and display students in the datagridview
        private void buttonSearch_Click(object sender, EventArgs e)
        {
            string s = textBoxSearch.Text;
            dataGridView1.DataSource = student.Search(s);
            //show the total students depending on dgvi rows
            labelTotalStudents.Text = "Total Students: " + dataGridView1.RowCount; //dataGridView1.Rows.Count
          
        }

        //Edit selected student informations
        private void buttonEdit_Click(object sender, EventArgs e)
        {
            //update student 
          

        }

        //Remove selected student 
        private void buttonRemove_Click(object sender, EventArgs e)
        {
            //remove the selected student in the database
            try
            {
                student.Id = Convert.ToInt32(textBoxId.Text);
                //show a confirmation message before deleting the student
                if (MessageBox.Show("Are you sure you want to delete this student", "delete student", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (student.Delete())
                    {
                        MessageBox.Show("Student Delated", "delate student", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        FillGrid(new MySqlCommand("select *from student"));
                        //clear fields
                        textBoxId.Text = "";
                        //textboxfirstname.Text = "";
                        textBoxlastname.Text = "";
                        textBoxPhone.Text = "";
                        textBoxAdress.Text = "";
                        dateTimePickerBitthday.Value = DateTime.Now;
                        pictureBoxStudentImage.Image = null;
                    }
                    else
                    {
                        MessageBox.Show("Student Not Delated", "Delete Student", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }

            }
            catch
            {
                MessageBox.Show("Please Enter a valid student Id", "Delete Student ", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }


        //Add new student
        private void buttonAddStudent_Click(object sender, EventArgs e)
        {
            try
            {
                //add a new student
                student.First_name = textboxfirstname.Text;
                student.Last_name = textBoxlastname.Text;
                student.BirthDate = dateTimePickerBitthday.Value;
                student.Address = textBoxAdress.Text;
                student.Phone = textBoxPhone.Text;
                student.Gender = "Male";

                if (radioButtonFemele.Checked)
                {
                    student.Gender = "femele";
                }

                student.Picture = new MemoryStream();
                //we need to check the age of student it must be between 10 and 100 year
                int born_year = dateTimePickerBitthday.Value.Year;
                int this_year = DateTime.Now.Year;
                int d = this_year - born_year;
                if (d < 10 || d > 100)
                {
                    MessageBox.Show("the student age must be between 10 and 100 year", "invalid birth date", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (Verify())
                {
                    pictureBoxStudentImage.Image.Save(student.Picture, pictureBoxStudentImage.Image.RawFormat);

                    if (student.Insert())
                    {
                        MessageBox.Show("the new student has been added", "student added", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        FillGrid(new MySqlCommand("select *from student"));
                    }
                    else
                    {
                        MessageBox.Show("Error", "student added", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Empty fields", "student added", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Please Enter correct values", "Add Student ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //create function to verify data
        bool Verify()
        {
            if ( textboxfirstname.Text.Trim().Equals("") ||
                 textBoxlastname.Text.Trim().Equals("") ||
                 textBoxAdress.Text.Trim().Equals("") ||
                 textBoxPhone.Text.Trim().Equals("") ||
                 pictureBoxStudentImage.Image == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

