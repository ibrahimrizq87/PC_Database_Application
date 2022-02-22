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
    public partial class Form15 : Form
    {
        public Form15()
        {
            InitializeComponent();
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



                        
                          

                            ad = new OleDbDataAdapter("select * from user1 where id="+textBox1.Text, connection);
                            ds = new DataSet();
                            ad.Fill(ds, "user1");
                            dataGridView1.DataSource = ds.Tables["user1"];

                        

                    }
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Not saved: " + ex.Message);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 form = new Form2();
            form.Show();
            form.BringToFront();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
