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
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
            CenterToScreen();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string username = txtBoxUsername.Text;
            string password = txtBoxPassword.Text;
            string confirmedPassword = txtBoxConfirmedPassword.Text;

            if ((!string.IsNullOrEmpty(username)) && (!string.IsNullOrEmpty(password))
                && (!string.IsNullOrEmpty(confirmedPassword)))
            {
                if ((!username.Contains("~")) || (!password.Contains("~")))
                {
                    if (password == confirmedPassword)
                    {
                        FileStream fileStream = new FileStream("users.txt", FileMode.Append, FileAccess.Write);
                        StreamWriter streamWriter = new StreamWriter(fileStream);

                        try
                        {
                            streamWriter.WriteLine(username + "~" + password);

                            MessageBox.Show("User registered successfully", "Registration Successful");
                            txtBoxUsername.Text = "";
                            txtBoxPassword.Text = "";
                            txtBoxConfirmedPassword.Text = "";
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Error registering the user", "Please try again");
                        }
                        finally
                        {
                            streamWriter.Close();
                            fileStream.Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Passwords must match",
                                    "Incorrect Details");
                    }
                }
                else
                {
                    MessageBox.Show("Username and password must not contain any special characters i.e. ~", "~ entered");            
                }
            }
            else
            {
                MessageBox.Show("Please ensure all data is entered into the fields", 
                    "Details missing");
            }
           
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            Hide();
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
        }

    }
}
