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
    public partial class Form19 : Form
    {
        public Form19()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 form = new Form2();
            form.Show();
            form.BringToFront();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            try
            {
                if (textBox1.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox2.Text != "")
                {
                    using (var connection = new OleDbConnection())
                    {
                        connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=""F:\college\third year\software engneering\project\implementation\library system database.accdb""";
                        connection.Open();
                        using (var cmd = new OleDbCommand())
                        {



                            cmd.Connection = connection;
                            cmd.CommandText = "update Book set bookName='" + textBox1.Text + "'" +
                    ",author='" + textBox3.Text + "',place='" + textBox4.Text + "' where bookID=" + textBox2.Text;

                            if (cmd.ExecuteNonQuery() > 0)
                            {
                                MessageBox.Show("record updated");

                            }

                        }
                    }


                }
                else { MessageBox.Show("data is required"); }
            }
            catch (Exception ex)
            {
                MessageBox.Show("error: " + ex.Message);
            }

        }
    }
}
