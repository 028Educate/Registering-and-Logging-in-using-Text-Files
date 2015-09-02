using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MultipleForms
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            CenterToScreen();
        }


        private void btnLogin_Click(object sender, EventArgs e)
        {
            if(File.Exists("users.txt"))
            {
                string[] users = File.ReadAllLines("users.txt");
                bool userFound = false;

                foreach(string user in users)
                {
                    string[] splitDetails = user.Split('~');

                    string username = splitDetails[0];
                    string password = splitDetails[1];

                    if((txtBoxUsername.Text == username) && (txtBoxPassword.Text == password))
                    {
                        userFound = true;
                        break;
                    }
                }

                if(userFound)
                {
                    Hide();
                    HomeForm home = new HomeForm();
                    home.Show();
                }
                else
                {
                    MessageBox.Show("User details are incorrect",
                                    "Incorrect details entered");
                }
            }
            else
            {
                MessageBox.Show("No users have been registered", "No users");
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            Hide();
            RegisterForm registerForm = new RegisterForm();
            registerForm.Show();
        }

    }
}
