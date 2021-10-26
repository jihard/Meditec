using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace LibraryManager
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-GALAGKM\SQLEXPRESS01;Initial Catalog=testdb;Integrated Security=True");
        private void button1_Click(object sender, EventArgs e)
        {
            if (Inputdata())
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("INSERT INTO Librarytable(ID,BookName,BookAuthor) VALUES (@ID,@BookName,@BookAuthor)", con);
                cmd.Parameters.AddWithValue("@ID", int.Parse(textBox1.Text));
                cmd.Parameters.AddWithValue("@BookName", textBox2.Text);
                cmd.Parameters.AddWithValue("@BookAuthor", textBox3.Text);
                cmd.ExecuteNonQuery();
                con.Close();

                BindData();
                dataGridView1.Refresh();
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox1.Focus();
                MessageBox.Show("Data saved", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataGridView1.Refresh();
            }
        }

        void BindData()
        {
            SqlCommand command = new SqlCommand("select * from Librarytable", con);
            SqlDataAdapter sd = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            sd.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private bool Inputdata()
        {
            if (textBox1.Text == string.Empty)
            {
                MessageBox.Show("Fields are empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (UpdateData())
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("UPDATE Librarytable SET BookName=@BookName, BookAuthor=@BookAuthor WHERE ID=@ID", con);
                cmd.Parameters.AddWithValue("@ID", int.Parse(textBox1.Text));
                cmd.Parameters.AddWithValue("@BookName", textBox2.Text);
                cmd.Parameters.AddWithValue("@BookAuthor", textBox3.Text);
                cmd.ExecuteNonQuery();
                con.Close();

                BindData();
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                MessageBox.Show("Data updated");
            }
        }
        private bool UpdateData()
        {
            if (textBox1.Text == string.Empty)
            {
                MessageBox.Show("Fields are empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (DeleteData())
            {
                SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-GALAGKM\SQLEXPRESS01;Initial Catalog=testdb;Integrated Security=True");
                con.Open();

                if (MessageBox.Show("Do you want to delete data?", "Deleting data", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    SqlCommand cmd = new SqlCommand("DELETE Librarytable WHERE ID=@ID", con);
                    cmd.Parameters.AddWithValue("@ID", int.Parse(textBox1.Text));
                    cmd.ExecuteNonQuery();
                    con.Close();
                    BindData();
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    MessageBox.Show("Data Deleted");
                }
            }
        }

        private bool DeleteData()
        {
            if (textBox1.Text == string.Empty)
            {
                MessageBox.Show("Book ID not specified", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.librarytableTableAdapter.Fill(this.testdbDataSet.Librarytable);
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-GALAGKM\SQLEXPRESS01;Initial Catalog=testdb;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Librarytable", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (SearchData())
            {
                SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-GALAGKM\SQLEXPRESS01;Initial Catalog=testdb;Integrated Security=True");
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Librarytable WHERE BookAuthor=@BookAuthor", con);
                cmd.Parameters.AddWithValue("@BookAuthor", textBox3.Text);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
        }

        private bool SearchData()
        {
            if (textBox3.Text == string.Empty)
            {
                MessageBox.Show("Book author is not not specified", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
    }
}
