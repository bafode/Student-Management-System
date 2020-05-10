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
    
    public partial class mainForm : Form
    {
        public mainForm()
        {
            InitializeComponent();
        }

        private void labelClose_MouseEnter(object sender, EventArgs e)
        {
            labelClose.ForeColor = Color.White;
        }

        private void labelClose_MouseLeave(object sender, EventArgs e)
        {
            labelClose.ForeColor = Color.Yellow;
        }

        private void labelClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void addNToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //this.Hide();
            AddStudentForm frm = new AddStudentForm();
            frm.Show(this);
        }

        private void studentListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StudentListForm frm = new StudentListForm();
            frm.Show(this);

        }

        private void editRemoveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateDelateStudentForm frm = new UpdateDelateStudentForm();
            frm.Show(this);
        }

        private void staticsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StaticsForm frm = new StaticsForm();
            frm.Show(this);
        }

        private void manageStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManageStudentsForm frm = new ManageStudentsForm();
            frm.Show();
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrintStudentsForm frm = new PrintStudentsForm();
            frm.Show(this);
        }

        private void addCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddCourseForm frm = new AddCourseForm();
            frm.Show(this);
        }

        private void removeCourseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RemoveCourseForm frm = new RemoveCourseForm();
            frm.Show(this);
        }

        private void editCourseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditCourseForm frm = new EditCourseForm();
            frm.Show(this);
        }

        private void manageCourseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManageCoursesForm frm = new ManageCoursesForm();
            frm.Show(this);
        }

        private void printCourseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrintCoursesForm frm = new PrintCoursesForm();
            frm.Show(this);
        }

        private void addScoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddScoreForm frm = new AddScoreForm();
            frm.Show(this);
        }

        private void removeScoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RemoveScoreForm frm = new RemoveScoreForm();
            frm.Show(this);
        }

        private void manageScoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManageScoreForm frm = new ManageScoreForm();
            frm.Show(this);
        }

        private void sCOREToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void avgScoreByCoursToolStripMenuItem_Click(object sender, EventArgs e)
        {
            avgScoreByCourseForm frm = new avgScoreByCourseForm();
            frm.Show(this);
        }

        private void printToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            PrintScoreForm frm = new PrintScoreForm();
            frm.Show(this);
        }

        private void manageUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManageUser frm = new ManageUser();
            frm.Show(this);
        }
    }
}
