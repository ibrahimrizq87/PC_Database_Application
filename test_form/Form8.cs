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
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try {
                OleDbDataAdapter ad;
                DataSet ds;

                OleDbConnection connection;
                connection = new OleDbConnection();
                connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=""F:\college\third year\software engneering\project\implementation\library system database.accdb""";
                connection.Open();
                ad = new OleDbDataAdapter("select * from Book where bookID like '" + textBox1.Text + "%'", connection);
                ds = new DataSet();
                ad.Fill(ds, "Book");
                dataGridView1.DataSource = ds.Tables["Book"];
                connection.Close();
            }
            catch (Exception ex) {
                MessageBox.Show("error is: "+ex );
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
