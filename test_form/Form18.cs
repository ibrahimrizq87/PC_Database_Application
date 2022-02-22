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
    public partial class Form18 : Form
    {
        public Form18()
        {
            InitializeComponent();
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
                            cmd.CommandText = "insert into Book (bookID,bookName,author,place) " +
                                "values('" + textBox2.Text + "','" + textBox1.Text + "','" + textBox3.Text + "','" + textBox4.Text + "')";

                            if (cmd.ExecuteNonQuery() > 0)
                            {
                                MessageBox.Show("record is added");

                            }

                        }
                    }


                }else { MessageBox.Show("data is required"); } }
            catch (Exception ex)
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
    }
}
