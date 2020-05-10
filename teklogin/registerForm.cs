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
    public partial class registerForm : Form
    {
        public registerForm()
        {
            InitializeComponent();
            this.ActiveControl = label1;
        }

        private void labelClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        User user = new User();
        private void labelClose_MouseEnter(object sender, EventArgs e)
        {
            labelClose.ForeColor = Color.White;
        }

        private void labelClose_MouseLeave(object sender, EventArgs e)
        {
            labelClose.ForeColor = Color.Black;
        }

        private void textboxfirstname_Enter(object sender, EventArgs e)
        {
            user.First_name = textboxfirstname.Text;

            if(user.First_name.ToLower().Trim().Equals("first name"))
            {
                textboxfirstname.Text = "";
                textboxfirstname.ForeColor = Color.Black;
            }
        }

        private void textboxfirstname_Leave(object sender, EventArgs e)
        {
            user.First_name = textboxfirstname.Text;
            if (user.First_name.ToLower().Trim().Equals("first name")||user.First_name.Trim().Equals(""))
            {
                textboxfirstname.Text = "first name";
                textboxfirstname.ForeColor = Color.Gray;
            }
        }

        private void textBoxlastname_Enter(object sender, EventArgs e)
        {
            user.Last_name = textBoxlastname.Text;
            if (user.Last_name.ToLower().Trim().Equals("last name"))
            {
                textBoxlastname.Text = "";
                textBoxlastname.ForeColor = Color.Black;
            }
        }

        private void textBoxlastname_Leave(object sender, EventArgs e)
        {
            user.Last_name = textBoxlastname.Text;
            if (user.Last_name.ToLower().Trim().Equals("last name")||user.Last_name.Trim().Equals(""))
            {
                textBoxlastname.Text = "last name";
                textBoxlastname.ForeColor = Color.Gray;
            }
        }

        private void textBoxEmail_Enter(object sender, EventArgs e)
        {
            user.Email = textBoxEmail.Text;
            if (user.Email.ToLower().Trim().Equals("address email"))
            {
                textBoxEmail.Text = "";
                textBoxEmail.ForeColor = Color.Black;
            }
        }

        private void textBoxEmail_Leave(object sender, EventArgs e)
        {
            user.Email = textBoxEmail.Text;
            if (user.Email.ToLower().Trim().Equals("address email") ||user.Email.Trim().Equals(""))
            {
                textBoxEmail.Text = "address email";
                textBoxEmail.ForeColor = Color.Gray;
            }
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

        private void textBoxCpassword_Enter(object sender, EventArgs e)
        {
            user.CPassword = textBoxCpassword.Text;
            if (user.CPassword.ToLower().Trim().Equals("confirm password"))
            {
                textBoxCpassword.Text = "";
                textBoxCpassword.UseSystemPasswordChar = true;
                textBoxCpassword.ForeColor = Color.Black;
            }
        }
        
        private void textBoxCpassword_Leave(object sender, EventArgs e)
        {
            user.CPassword = textBoxCpassword.Text;
            if (user.CPassword.ToLower().Trim().Equals("confirm password")||user.CPassword.Trim().Equals(""))
            {
                textBoxCpassword.Text = "confirm password";
                textBoxCpassword.UseSystemPasswordChar = false;
                textBoxCpassword.ForeColor = Color.Gray;
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label5_MouseEnter(object sender, EventArgs e)
        {
            label5.ForeColor = Color.White;
        }

        private void label5_MouseLeave(object sender, EventArgs e)
        {
            label5.ForeColor = Color.Black;
        }

        private void labelGoToLogin_MouseEnter(object sender, EventArgs e)
        {
            labelGoToLogin.ForeColor = Color.Yellow;
        }

        private void labelGoToLogin_MouseLeave(object sender, EventArgs e)
        {
            labelGoToLogin.ForeColor = Color.White;
        }

        private void labelGoToLogin_Click(object sender, EventArgs e)
        {
            this.Hide();
            loginForm frm = new loginForm();
            frm.Show();
        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            user.First_name = textboxfirstname.Text;
            user.Last_name = textBoxlastname.Text;
            user.Email = textBoxEmail.Text;
            user.Username = textBoxUsername.Text;
            user.Password = textBoxPassword.Text;

            if (!CheckTextBoxesValues())
            {
                if(textBoxPassword.Text.Equals(textBoxCpassword.Text))
                {
                    if (user.checkUsername())
                    {
                        MessageBox.Show("username already exister select diffrent one", "diplicate username", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                    }
                    else
                    {
                        if(user.Insert())
                        {
                            MessageBox.Show("your account has been created ", "acount created", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Error");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Wrong Confirmation password", "password error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
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
            user.CPassword = textBoxCpassword.Text;
            if (user.First_name.Equals("first name") || user.Last_name.Equals("last name") ||
                user.Email.Equals("address email") || user.Username.Equals("") ||
                user.Password.Equals("password") || user.CPassword.Equals("confirm password"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

       
        private void labelExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void labelExit_MouseEnter(object sender, EventArgs e)
        {
            labelExit.ForeColor = Color.White;
        }

        private void labelExit_MouseLeave(object sender, EventArgs e)
        {
            labelExit.ForeColor = Color.Black;
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }
    }
}
