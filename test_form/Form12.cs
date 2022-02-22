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
    public partial class Form12 : Form
    {
        public Form12()
        {
            InitializeComponent();
        }

        private void Form12_Load(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 form = new Form2();
            form.Show();
            form.BringToFront();

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
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



                        ad = new OleDbDataAdapter("select * from outOfDate", connection);
                        ds = new DataSet();
                        ad.Fill(ds, "outOfDate");
                        dataGridView2.DataSource = ds.Tables["outOfDate"];



                    }
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("error: " + ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
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
                        cmd.CommandText = "insert into outOfDate (bookID,bookName) " +
                            "values('" + textBox1.Text + "','" + textBox2.Text + "')";

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

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
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
                        cmd.CommandText = "delete from outOfDate where bookID=" + textBox1.Text;

                        if (cmd.ExecuteNonQuery() > 0)
                        {
                            MessageBox.Show("record is deleted");


                        }

                    }
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Not saved: " + ex.Message);
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
