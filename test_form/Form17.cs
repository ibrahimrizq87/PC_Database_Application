using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace test_form
{
    public partial class Form17 : Form
    {
        public Form17()
        {
            InitializeComponent();
        }
        OleDbConnection connection;
        OleDbCommand cmd;
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox2.Text != "")
                {
                    connection = new OleDbConnection();
                    connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=""F:\college\third year\software engneering\project\implementation\library system database.accdb""";

                    cmd = new OleDbCommand();
                    cmd.Connection = connection;
                    connection.Open();

                    cmd.CommandText = "update user1 set name='" + textBox1.Text + "'" +
                        ",FAuthor='" + textBox3.Text + "',FBook='" + textBox4.Text + "' where id=" + textBox2.Text;

                    int a = cmd.ExecuteNonQuery();
                    if (a > 0)
                    {
                        MessageBox.Show("record updated");
                    }
                    else
                    {
                        MessageBox.Show("error");

                    }
                }
                else { MessageBox.Show("data is required"); } }
            catch (Exception ex) {
                MessageBox.Show("error is : " + ex);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 form = new Form2();
            form.Show();
            form.BringToFront();
        }
    }
}
