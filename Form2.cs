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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();

        }
        bool statee = false;
        AdsModel add;
        public Form2(bool state)
        {
            InitializeComponent();
            if (statee)
            {
                btnAdd.Text = "Update";
                this.Text = "Update Screen";
            }
        }
        public Form2(bool state, AdsModel ad)
        {
            InitializeComponent();
            statee = state;
            add = ad;
            if (state)
            {
                btnAdd.Text = "Update";
                textBox1.Text = ad.title;
                comboBox1.SelectedIndex = ad.status - 1;
                textBox2.Text = ad.price.ToString();
                comboBox2.SelectedIndex = ad.currency - 1;
                comboBox3.SelectedIndex = ad.type - 1;
                textBox3.Text = ad.area.ToString();
                richTextBox1.Text = ad.description;
                textBox4.Text = ad.lang.ToString();
                textBox5.Text = ad.lat.ToString();
                this.Text = "Update Screen";
            }



        }
        DAL dal = new DAL();
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!statee)
            {
                try
                {
                    dal.ExecuteCommand("INSERT INTO dbo.Ads (Title, Status, Price, Currency, Description, Type, Area,Lat,Long) VALUES (@title, @status, @price, @currency, @description, @type, @area,@lat,@long)", new List<Parameters> {
                new Parameters { Name = "@title", Value = textBox1.Text },
                new Parameters { Name = "@status", Value = comboBox1.SelectedIndex+1 },
                new Parameters { Name = "@price", Value = Convert.ToInt64(textBox2.Text) },
                new Parameters { Name = "@currency", Value = comboBox2.SelectedIndex+1 },
                new Parameters { Name = "@description", Value = richTextBox1.Text },
                new Parameters { Name = "@type", Value = comboBox3.SelectedIndex+1 },
                new Parameters { Name = "@area", Value = int.Parse(textBox3.Text) },
                new Parameters { Name = "@lat", Value = float.Parse(textBox4.Text) },
                new Parameters { Name = "@long", Value = float.Parse(textBox5.Text) }});
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    comboBox1.SelectedIndex = -1;
                    comboBox2.SelectedIndex = -1;
                    comboBox3.SelectedIndex = -1;
                    richTextBox1.Text = "";
                    MessageBox.Show("New record has been added successfully!");


                }
                catch (Exception ex) { MessageBox.Show("An error occured: " + ex.Message); }
            }
            else
            {
                try
                {
                    dal.ExecuteCommand("UPDATE dbo.Ads SET Title = @title, Status = @status, Price = @price, Currency = @currency, Description = @description, Type = @type, Area = @area, Lat = @lat, Long = @long WHERE Id = @id; ", new List<Parameters> {
                new Parameters { Name = "@title", Value = textBox1.Text },
                new Parameters { Name = "@status", Value = comboBox1.SelectedIndex+1 },
                new Parameters { Name = "@price", Value = Convert.ToInt64(textBox2.Text) },
                new Parameters { Name = "@currency", Value = comboBox2.SelectedIndex+1 },
                new Parameters { Name = "@description", Value = richTextBox1.Text },
                new Parameters { Name = "@type", Value = comboBox3.SelectedIndex+1 },
                new Parameters { Name = "@area", Value = int.Parse(textBox3.Text) },
                new Parameters { Name = "@id", Value = add.id },
                        new Parameters { Name = "@lat", Value = float.Parse(textBox4.Text) },
                new Parameters { Name = "@long", Value = float.Parse(textBox5.Text) }});
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    textBox5.Text = "";
                    comboBox1.SelectedIndex = -1;
                    comboBox2.SelectedIndex = -1;
                    comboBox3.SelectedIndex = -1;
                    richTextBox1.Text = "";
                    MessageBox.Show("Record has been updated successfully!");
                    this.Close();
                }
                catch (Exception ex) { MessageBox.Show("An error occured: " + ex.Message); }
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
