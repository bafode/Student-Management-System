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
    public partial class AddStudentForm : Form
    {
        public AddStudentForm()
        {
            InitializeComponent();
        }

        Student student = new Student();
        private void label8_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void label8_MouseEnter(object sender, EventArgs e)
        {
            label8.ForeColor = Color.White;
        }

        private void label8_MouseLeave(object sender, EventArgs e)
        {
            label8.ForeColor = Color.Yellow;
        }

        private void textboxfirstname_Enter(object sender, EventArgs e)
        {
            student.First_name = textboxfirstname.Text;
            if (student.First_name.ToLower().Trim().Equals("first name"))
            {
                textboxfirstname.Text = "";
                textboxfirstname.ForeColor = Color.Black;
            }
        }

        private void textboxfirstname_Leave(object sender, EventArgs e)
        {
            student.First_name = textboxfirstname.Text;
            if (student.First_name.ToLower().Trim().Equals("first name")||student.First_name.Trim().Equals(""))
            {
                textboxfirstname.Text = "first name";
                textboxfirstname.ForeColor = Color.Gray;
            }
        }

        private void textBoxlastname_Enter(object sender, EventArgs e)
        {
            student.Last_name = textBoxlastname.Text;
            if (student.Last_name.ToLower().Trim().Equals("last name"))
            {
                textBoxlastname.Text = "";
                textBoxlastname.ForeColor = Color.Black;
            }

        }

        private void textBoxlastname_Leave(object sender, EventArgs e)
        {
            student.Last_name = textBoxlastname.Text;
            if (student.Last_name.ToLower().Trim().Equals("last name") || student.Last_name.Trim().Equals(""))
            {
                textBoxlastname.Text = "last name";
                textBoxlastname.ForeColor = Color.Gray;
            }
        }

        private void textBoxAdress_Enter(object sender, EventArgs e)
        {
            student.Address = textBoxAdress.Text;
            if (student.Address.ToLower().Trim().Equals("address"))
            {
                textBoxAdress.Text = "";
                textBoxAdress.ForeColor = Color.Black;
            }
        }

        private void textBoxAdress_Leave(object sender, EventArgs e)
        {
            student.Address= textBoxAdress.Text;
            if (student.Address.ToLower().Trim().Equals("address")||student.Address.Trim().Equals(""))
            {
                textBoxAdress.Text = "address";
                textBoxAdress.ForeColor = Color.Gray;
            }
        }

        private void textBoxPhone_Enter(object sender, EventArgs e)
        {
           student.Phone=textBoxPhone.Text;
            if (student.Phone.ToLower().Trim().Equals("phone"))
            {
               textBoxPhone.Text = "";
                textBoxPhone.ForeColor = Color.Black;
            }
        }

        private void textBoxPhone_Leave(object sender, EventArgs e)
        {
            student.Phone = textBoxPhone.Text;
            if (student.Phone.ToLower().Trim().Equals("phone")||student.Phone.Trim().Equals(""))
            {
                textBoxPhone.Text = "phone";
                textBoxPhone.ForeColor = Color.Gray;
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonAddStudent_Click(object sender, EventArgs e)
        {
            try
            {
                //add a new student
                //  Student student = new Student();
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
            catch
            {

                MessageBox.Show("Please Enter correct values", "Add Student ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonUploadImage_Click(object sender, EventArgs e)
        {
            //browse image from your computer

            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "select image (*.jpg;*.png;*.gif)|*.jpg;*.png;*.gif";
            if(opf.ShowDialog()==DialogResult.OK)
            {
                pictureBoxStudentImage.Image = Image.FromFile(opf.FileName);
            }
        }
        //create function to verify data
        bool Verify()
        {
            if(textboxfirstname.Text.Trim().Equals("first name")||textboxfirstname.Text.Trim().Equals("")||
                textBoxlastname.Text.Trim().Equals("last name")||textBoxlastname.Text.Trim().Equals("")||
                textBoxAdress.Text.Trim().Equals("address") || textBoxAdress.Text.Trim().Equals("")||
                textBoxPhone.Text.Trim().Equals("phone")|| textBoxPhone.Text.Trim().Equals("")||
                pictureBoxStudentImage.Image==null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
