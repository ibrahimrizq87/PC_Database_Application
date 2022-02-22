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
    public partial class Form16 : Form
    {
        public Form16()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (var connection = new OleDbConnection())
                {
                    connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=""F:\college\third year\software engneering\project\implementation\library system database.accdb""";
                    connection.Open();
                    using (var cmd = new OleDbCommand())
                    {


                        cmd.Connection = connection;
                        cmd.CommandText = "delete from borrowing where bookID=" + textBox1.Text;

                        if (cmd.ExecuteNonQuery() > 0)
                        {
                            MessageBox.Show("record is deleted from database");

                        }

                    }
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Not add:ed error is : " + ex.Message);
            }
            try
            {
                using (var connection = new OleDbConnection())
                {
                    connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=""F:\college\third year\software engneering\project\implementation\library system database.accdb""";
                    connection.Open();
                    using (var cmd = new OleDbCommand())
                    {
                       

                        cmd.Connection = connection;
                        cmd.CommandText = "insert into return (bookID,userID,BorrowingDate,fine) " +
                            "values('" + textBox1.Text + "','" + textBox2.Text + "','" + dateTimePicker1.Text + "','" + textBox3.Text + "')";

                        if (cmd.ExecuteNonQuery() > 0)
                        {
                            MessageBox.Show("record is added");

                        }

                    }
                }


            }
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

        private void button3_Click(object sender, EventArgs e)
        {
            OleDbDataAdapter ad;
            DataSet ds;

            try
            {
                using (var connection = new OleDbConnection())
                {
                    connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=""F:\college\third year\software engneering\project\implementation\library system database.accdb""";
                    connection.Open();
                    using (var cmd = new OleDbCommand())
                    {



                        ad = new OleDbDataAdapter("select * from return", connection);
                        ds = new DataSet();
                        ad.Fill(ds, "return");
                        dataGridView1.DataSource = ds.Tables["return"];



                    }
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("error: " + ex.Message);
            }
        }
    }
}
