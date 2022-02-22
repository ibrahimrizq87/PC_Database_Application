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
    public partial class Form9 : Form
    {
        public Form9()
        {
            InitializeComponent();
        }

        private void Form9_Load(object sender, EventArgs e)
        {

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
                        cmd.CommandText = "insert into usersInHall (userID) " +
                            "values('" + textBox1.Text + "')";

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
            try
            {
                using (var connection = new OleDbConnection())
                {
                    connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=""F:\college\third year\software engneering\project\implementation\library system database.accdb""";
                    connection.Open();
                    using (var cmd = new OleDbCommand())
                    {



                        cmd.Connection = connection;
                        cmd.CommandText = "delete from usersInHall where userID=" + textBox1.Text;

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

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                OleDbDataAdapter ad;
                DataSet ds;

                OleDbConnection connection;
                connection = new OleDbConnection();
                connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=""F:\college\third year\software engneering\project\implementation\library system database.accdb""";
                connection.Open();
                ad = new OleDbDataAdapter("select * from usersInHall ", connection);
                ds = new DataSet();
                ad.Fill(ds, "usersInHall");
                dataGridView1.DataSource = ds.Tables["usersInHall"];
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("error is: " + ex);
            }
        }
    }
}
