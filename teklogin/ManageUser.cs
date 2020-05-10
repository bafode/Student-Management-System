using System;
using System.Windows.Forms;

namespace teklogin
{
    public partial class ManageUser : Form
    {
        public ManageUser()
        {
            InitializeComponent();
        }
        User user = new User();

        private void ManageUser_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = user.GetAll();
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {

            textBoxId.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textboxfirstname.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBoxlastname.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBoxUsername.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBoxAdress.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            textBoxEmail.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            textBoxPassword.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();


        }

        private void buttonAddStudent_Click(object sender, EventArgs e)
        {
           
            user.First_name = textboxfirstname.Text;
            user.Last_name = textBoxlastname.Text;
            user.Email = textBoxEmail.Text;
            user.Username = textBoxUsername.Text;
            user.Password = textBoxPassword.Text;
            user.Address = textBoxAdress.Text;

            if (!CheckTextBoxesValues())
            {
              
                    if (user.checkUsername())
                    {
                        MessageBox.Show("username already exister select diffrent one", "diplicate username", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                    }
                    else
                    {
                        if (user.Insert())
                        {
                            MessageBox.Show("your account has been created ", "acount created", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            dataGridView1.DataSource = user.GetAll();
                    }
                        else
                        {
                            MessageBox.Show("Error");
                        }
                    }
             
            }
            else
            {
                MessageBox.Show("Entrer your information first", "Data empty", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }



        //Create a function to Check if fields are empty
        public Boolean CheckTextBoxesValues()
        {
            user.First_name = textboxfirstname.Text;
            user.Last_name = textBoxlastname.Text;
            user.Email = textBoxEmail.Text;
            user.Username = textBoxUsername.Text;
            user.Password = textBoxPassword.Text;
            if (user.First_name.Equals("") || user.Last_name.Equals("") ||
                user.Email.Equals("") || user.Username.Equals("") ||
                user.Password.Equals(""))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            try
            {
                user.Id = int.Parse(textBoxId.Text);
                user.First_name = textboxfirstname.Text;
                user.Last_name = textBoxlastname.Text;
                user.Email = textBoxEmail.Text;
                user.Username = textBoxUsername.Text;
                user.Password = textBoxPassword.Text;
                user.Address = textBoxAdress.Text;
                if (!CheckTextBoxesValues())
                {

                    if (user.checkUsername())
                    {
                        MessageBox.Show("username already exister select diffrent one", "diplicate username", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                    }
                    else
                    {
                        if (user.Update())
                        {
                            MessageBox.Show("The user informations update", "edit user", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            dataGridView1.DataSource = user.GetAll();
                        }
                        else
                        {
                            MessageBox.Show("Error");
                        }
                    }

                }
                else
                {
                    MessageBox.Show("Entrer your information first", "Data empty", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                }

            }
            catch 
            {

                MessageBox.Show("Entrer your information first", "Data empty", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            try
            {
                user.Id = int.Parse(textBoxId.Text);
                if (MessageBox.Show("Are you sure you want to delete this User", "delete User", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (user.Delete())
                    {
                        MessageBox.Show("User Delated", "delate user", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dataGridView1.DataSource = user.GetAll();

                    }
                    else
                    {
                        MessageBox.Show("User Not Delated", "Delete user", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
            }
            catch 
            {

                MessageBox.Show("Incorrect User Id", "Data empty", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            string s = textBoxSearch.Text;
           dataGridView1.DataSource=user.Search(s);
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            textBoxId.Text = "";
            textboxfirstname.Text = "";
            textBoxlastname.Text = "";
            textBoxUsername.Text = "";
            textBoxAdress.Text = "";
            textBoxEmail.Text = "";
            textBoxPassword.Text = "";
            dataGridView1.DataSource = user.GetAll();
        }
    }
}
