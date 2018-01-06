using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RealtyInterface
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();

        }
        DAL dal = new DAL();
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int flag = 0;
                dataGridView1.DataSource = dal.getDataTable("SELECT * FROM Users");

                foreach (DataGridViewRow item in dataGridView1.Rows)
                {
                    if (item.Cells[1].Value != null)
                        if (item.Cells["Username"].Value.ToString() == textBox1.Text
                            && item.Cells["Password"].Value.ToString() == textBox2.Text)
                            flag = int.Parse(item.Cells["Role"].Value.ToString());
                }
                if (flag == 1)
                {
                    Form1 form1 = new Form1(true);
                    form1.Show();
                    this.Hide();
                    MessageBox.Show("Successfully logged in as admin!");
                }
                else if (flag == 2)
                {
                    Form1 form1 = new Form1(false);
                    form1.Show();
                    this.Hide();
                    MessageBox.Show("Successfully logged in as user!");

                }
                else { MessageBox.Show("Wrong username or password!"); }
            }
            catch (Exception) { MessageBox.Show("Wrong username or password!"); }
        }
    }
}
