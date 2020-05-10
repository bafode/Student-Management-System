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
using System.IO;

namespace teklogin
{
    public partial class StudentListForm : Form
    {
        Student student = new Student();
        public StudentListForm()
        {
            InitializeComponent();
        }

        private void StudentListForm_Load(object sender, EventArgs e)
        {
            //populate the datagrid view with student data
            MySqlCommand command = new MySqlCommand("select *from student");
            dataGridView1.ReadOnly = true;
            DataGridViewImageColumn picCol = new DataGridViewImageColumn();
            dataGridView1.RowTemplate.Height = 80;
            dataGridView1.DataSource = student.getStudent(command);
            picCol = (DataGridViewImageColumn)dataGridView1.Columns[7];//is the image column index
            picCol.ImageLayout = DataGridViewImageCellLayout.Stretch;
            dataGridView1.AllowUserToAddRows=false;



        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            //display the selected student in the new form to edit/remove 
            UpdateDelateStudentForm frm = new UpdateDelateStudentForm();
            frm.textBoxId.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            frm.textboxfirstname.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            frm.textBoxlastname.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            frm.textBoxPhone.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            frm.textBoxAdress.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            //for gender
            if(dataGridView1.CurrentRow.Cells[5].Value.ToString()=="Femele")
            {
                frm.radioButtonFemele.Checked = true;
            }
           

            frm.dateTimePickerBitthday.Value=(DateTime)dataGridView1.CurrentRow.Cells[6].Value;

            //the image
            byte[] pic;
            pic = (byte[])dataGridView1.CurrentRow.Cells[7].Value;
            student.Picture = new MemoryStream(pic);
            frm.pictureBoxStudentImage.Image = Image.FromStream(student.Picture);
            frm.Show();

            
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            //refresh the datagridview data
            MySqlCommand command = new MySqlCommand("select *from student");
            dataGridView1.ReadOnly = true;
            DataGridViewImageColumn picCol = new DataGridViewImageColumn();
            dataGridView1.RowTemplate.Height = 80;
            dataGridView1.DataSource = student.getStudent(command);
            picCol = (DataGridViewImageColumn)dataGridView1.Columns[7];//is the image column index
            picCol.ImageLayout = DataGridViewImageCellLayout.Stretch;
            dataGridView1.AllowUserToAddRows = false;

        }
    }
}
