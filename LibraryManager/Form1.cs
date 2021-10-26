using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManager
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textUsername.Text == "User" && textPassword.Text == "Pass123")
            {
                new Form2().Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Incorrect username or password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textUsername.Clear();
                textPassword.Clear();
                textUsername.Focus();
            }
        }
        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
