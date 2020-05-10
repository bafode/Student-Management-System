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
using MySql.Data.MySqlClient;


namespace teklogin
{
    public partial class UpdateDelateStudentForm : Form
    {
        public UpdateDelateStudentForm()
        {
            InitializeComponent();
        }
        Student student = new Student();

        private void label17_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void label17_MouseEnter(object sender, EventArgs e)
        {
            label17.ForeColor = Color.White;
        }

        private void label17_MouseLeave(object sender, EventArgs e)
        {
            label17.ForeColor = Color.Yellow;
        }

        private void buttonUploadImage_Click(object sender, EventArgs e)
        {
            //browse image from your computer

            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "select image (*.jpg;*.png;*.gif)|*.jpg;*.png;*.gif";
            if (opf.ShowDialog() == DialogResult.OK)
            {
                pictureBoxStudentImage.Image = Image.FromFile(opf.FileName);
            }
        }

        private void buttonFind_Click(object sender, EventArgs e)
        {
            //search student by id
            try
            {
                student.Id= Convert.ToInt32(textBoxId.Text);
                MySqlCommand command = new MySqlCommand("select student_id,first_name,last_name,phone,address,gender,birthday,picture from student where student_id=" + student.Id);
                DataTable table = new DataTable();
                table = student.getStudent(command);
                if (table.Rows.Count > 0)
                {
                    textboxfirstname.Text = table.Rows[0]["first_name"].ToString();
                    textBoxlastname.Text = table.Rows[0]["last_name"].ToString();
                    textBoxPhone.Text = table.Rows[0]["phone"].ToString();
                    textBoxAdress.Text = table.Rows[0]["address"].ToString();

                    dateTimePickerBitthday.Value = (DateTime)table.Rows[0]["birthday"];

                    //gender
                    if (table.Rows[0]["gender"].ToString() == "Femele")
                    {
                        radioButtonFemele.Checked = true;
                    }
                    else
                    {
                        radioButtonMale.Checked = true;
                    }

                    //image
                    byte[] pic = (byte[])table.Rows[0]["picture"];
                    student.Picture = new MemoryStream(pic);
                    pictureBoxStudentImage.Image = Image.FromStream(student.Picture);
                }
            }
            catch
            {

                MessageBox.Show("Enter a valid student Id", "Invalid Student Id", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void buttonEditStudent_Click(object sender, EventArgs e)
        {
            //update student 

            try
            {
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

                    if (student.Update())
                    {
                        MessageBox.Show("the student informations updated", "edit student ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Error", "edit student", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Empty fields", "edit student", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch
            {

                MessageBox.Show("Please Enter a valid student Id", "Edit Student ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       
        bool Verify()
        {
            if (textboxfirstname.Text.Trim().Equals("") ||
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
                        //clear fields
                        textBoxId.Text = "";
                        textboxfirstname.Text = "";
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

        //allow only number on keypress
        private void textBoxId_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)&& !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void label19_Click(object sender, EventArgs e)
        {

        }
    }
}
