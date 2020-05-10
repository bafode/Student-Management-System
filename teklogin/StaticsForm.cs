using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace teklogin
{
    public partial class StaticsForm : Form
    {
        public StaticsForm()
        {
            InitializeComponent();
        }
        //color variables
        Color panTotalColor;
        Color panMaleColor;
        Color panFemaleColor;
        private void StaticsForm_Load(object sender, EventArgs e)
        {
            //get the panels color
            panTotalColor = panelTotalStudent.BackColor;
            panMaleColor = panelTotalMale.BackColor;
            panFemaleColor = paneltotalFemale.BackColor;

            //Display the values
            Student student = new Student();
            double totalstudents = Convert.ToDouble(student.totalStudent());
            double totalMaleStudent = Convert.ToDouble(student.totalMale());
            double totalFemelStudent = Convert.ToDouble(student.totalFemale());

            //count the percentage
            double malePercentage = totalMaleStudent * 100 / totalstudents;
            double femalePercentage = totalFemelStudent * 100 / totalstudents;

            labelTotalStudent.Text = "Total Students: " + totalstudents;
            labelTotalmale.Text = "Male: " + malePercentage.ToString("0.00") + "%";
            labelTotalFemel.Text = "Female: " + femalePercentage.ToString("0.00") + "%";
        }

        private void labelTotalStudent_MouseEnter(object sender, EventArgs e)
        {
            panelTotalStudent.BackColor = Color.White;
            labelTotalStudent.ForeColor = panTotalColor;
        }

        private void labelTotalStudent_MouseLeave(object sender, EventArgs e)
        {
            panelTotalStudent.BackColor = panTotalColor;
            labelTotalStudent.ForeColor = Color.White;
        }

        private void labelTotalmale_MouseEnter(object sender, EventArgs e)
        {
            panelTotalMale.BackColor = Color.White;
            labelTotalmale.ForeColor = panMaleColor;
        }

        private void labelTotalmale_MouseLeave(object sender, EventArgs e)
        {
            panelTotalMale.BackColor = panMaleColor;
            labelTotalmale.ForeColor = Color.White;
        }

        private void labelTotalFemel_MouseEnter(object sender, EventArgs e)
        {
            paneltotalFemale.BackColor = Color.White;
            labelTotalFemel.ForeColor = panFemaleColor;
        }

        private void labelTotalFemel_MouseLeave(object sender, EventArgs e)
        {
            paneltotalFemale.BackColor = panFemaleColor;
           labelTotalFemel.ForeColor = Color.White;
        }
    }
}
