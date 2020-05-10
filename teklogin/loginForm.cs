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
    public partial class loginForm : Form
    {
        public loginForm()
        {
            InitializeComponent();
            this.textBoxPassword.Size = new Size(this.textBoxPassword.Size.Width, 50);
            this.ActiveControl = label1;

        }

        User user = new User();
        private void labelClose_MouseEnter(object sender, EventArgs e)
        {
            labelClose.ForeColor = Color.Red;

        }

        private void labelClose_MouseLeave(object sender, EventArgs e)
        {
            labelClose.ForeColor = Color.White;
        }

        private void labelClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textBoxUsername_Enter(object sender, EventArgs e)
        {
            user.Username = textBoxUsername.Text;
            if (user.Username.ToLower().Trim().Equals("username"))
            {
                textBoxUsername.Text = "";
                textBoxUsername.ForeColor = Color.Black;
            }
        }

        private void textBoxUsername_Leave(object sender, EventArgs e)
        {
            user.Username = textBoxUsername.Text;
            if (user.Username.ToLower().Trim().Equals("username")||user.Username.Trim().Equals(""))
            {
                textBoxUsername.Text = "username";
                textBoxUsername.ForeColor = Color.Gray;
            }
        }

        private void textBoxPassword_Enter(object sender, EventArgs e)
        {
            user.Password = textBoxPassword.Text;
            if (user.Password.ToLower().Trim().Equals("password"))
            {
                textBoxPassword.Text = "";
                textBoxPassword.UseSystemPasswordChar = true;
                textBoxPassword.ForeColor = Color.Black;
            }
        }

        private void textBoxPassword_Leave(object sender, EventArgs e)
        {
            user.Password = textBoxPassword.Text;
            if (user.Password.ToLower().Trim().Equals("password")||user.Password.Trim().Equals(""))
            {
                textBoxPassword.Text = "password";
                textBoxPassword.UseSystemPasswordChar = false;
                textBoxPassword.ForeColor = Color.Gray;
            }
        }

        private void labelGoToCreate_MouseEnter(object sender, EventArgs e)
        {
            labelGoToCreate.ForeColor = Color.Blue;
        }

        private void labelGoToCreate_MouseLeave(object sender, EventArgs e)
        {
            labelGoToCreate.ForeColor = Color.White;
        }

        private void labelGoToCreate_Click(object sender, EventArgs e)
        {
            this.Hide();
            registerForm frm = new registerForm();
            frm.Show();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            user.Username = textBoxUsername.Text;
            user.Password = textBoxPassword.Text;
            
            if(user.Login())
            {
                this.Hide();
                mainForm frm = new mainForm();
                frm.Show();
            }
            else
            {
                if(textBoxUsername.Text.Trim().Equals("username")||textBoxUsername.Text.Trim().Equals(""))
                {
                    MessageBox.Show("Enter your username to login ", "Empty username", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                }
                else if(textBoxPassword.Text.Trim().Equals("password")||textBoxPassword.Text.Trim().Equals(""))
                {
                    MessageBox.Show("Enter your password to login", "empty password", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("wrong username or password", "wrong data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }


            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
