using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C_Assingment
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            string Username = bunifuTextBox1.Text;
            string Passsword = bunifuTextBox2.Text;

            // Validate username
            if (Username.Length == 0)
            {
                MessageBox.Show("Please enter a username.");
                return;
            }

            // Validate password
            if (Passsword.Length == 0)
            {
                MessageBox.Show("Please enter a password.");
                return;
            }

            // Check if username and password are correct
            if (Username != "admin" || Passsword != "admin")
            {
                MessageBox.Show("Incorrect Username or Password");
                return;
            }

            // Redirect to dashboard if credentials are correct
            dashboard objdash = new dashboard();
            this.Hide();
            objdash.Show();
        }
        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            bunifuTextBox1.Text = " ";
            bunifuTextBox2.Text = " ";

        }



        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
