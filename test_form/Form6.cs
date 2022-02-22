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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 user = new Form2();
            user.Show();
            user.BringToFront();
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



                        ad = new OleDbDataAdapter("select * from buy", connection);
                        ds = new DataSet();
                        ad.Fill(ds, "buy");
                        dataGridView1.DataSource = ds.Tables["buy"];



                    }
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Not found: " + ex.Message);
            }
        }
    }
}
