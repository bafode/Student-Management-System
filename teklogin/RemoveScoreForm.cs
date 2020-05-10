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
    public partial class RemoveScoreForm : Form
    {
        public RemoveScoreForm()
        {
            InitializeComponent();
        }
        Score score = new Score();
        private void RemoveScoreForm_Load(object sender, EventArgs e)
        {
            //populate the datagridview with stuents score
            dataGridView1.DataSource = score.getStudentScore();
        }

        private void buttonRemoveScore_Click(object sender, EventArgs e)
        {
            //remove the selected score 
            score.StudentId =int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            score.CourseId = int.Parse(dataGridView1.CurrentRow.Cells[3].Value.ToString());

            if (MessageBox.Show("Do you want to delete this score?", "Remove score", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                if (score.Delete())
                {
                    MessageBox.Show("Score Deleted", "Remove Score", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataGridView1.DataSource = score.getStudentScore();

                   
                }
                else
                {

                  MessageBox.Show(" Score Not Deleted", "Remove Score", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }
    }
}
