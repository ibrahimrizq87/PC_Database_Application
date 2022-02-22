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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           

                try
                {
                if (textBox1.Text != "" && textBox3.Text != "" && textBox4.Text != "")
                {
                    using (var connection = new OleDbConnection())
                    {
                        connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=""F:\college\third year\software engneering\project\implementation\library system database.accdb""";
                        connection.Open();
                        using (var cmd = new OleDbCommand())
                        {



                            cmd.Connection = connection;
                            cmd.CommandText = "insert into buy (uid,bid,da,price) " +
                                "values('" + textBox4.Text + "','" + textBox1.Text + "','" + dateTimePicker1.Text + "','" + textBox3.Text + "')";

                            if (cmd.ExecuteNonQuery() > 0)
                            {
                                MessageBox.Show("record is added");

                            }

                        }
                    }



                }
                else {
                    MessageBox.Show("Data is required");
                }
            }catch (Exception ex)
            {
                MessageBox.Show("Not add:ed error is : " + ex.Message);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 user = new Form2();
            user.Show();
            user.BringToFront();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            
        }
    }
}
