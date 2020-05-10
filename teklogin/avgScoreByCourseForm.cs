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
    public partial class avgScoreByCourseForm : Form
    {
        public avgScoreByCourseForm()
        {
            InitializeComponent();
        }

        private void avgScoreByCourseForm_Load(object sender, EventArgs e)
        {
            //populate the datagridview with average by score
            Score score = new Score();
            dataGridView1.DataSource = score.getAvgByScore();
        }
    }
}
