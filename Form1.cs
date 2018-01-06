using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GMap.NET.MapProviders;
using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;

namespace RealtyInterface
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            prep();
        }

        public Form1(bool isAdmin)
        {
            InitializeComponent();
            this.isAdmin = isAdmin;
            prep();
        }
        DAL dal = new DAL();
        void visibles()
        {
            checkBox2.Visible = false;
            checkBox3.Visible = false;
            checkBox4.Visible = false;
            checkBox5.Visible = false;
            checkBox6.Visible = false;
            textBox1.Visible = false;
            textBox2.Visible = false;
            textBox3.Visible = false;
            textBox4.Visible = false;
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            label7.Visible = false;
            comboBox1.Visible = false;
            comboBox2.Visible = false;
            comboBox3.Visible = false;
            addToolStripMenuItem.Visible = isAdmin;
            updateToolStripMenuItem.Visible = isAdmin;
            deleteToolStripMenuItem.Visible = isAdmin;
            dgwDetails.Visible = false;
        }
        void gMap()
        {
            gmap.MapProvider = GMap.NET.MapProviders.GoogleMapProvider.Instance;
            GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerOnly;
            gmap.SetPositionByKeywords("Istanbul, Turkey");
            gmap.DragButton = MouseButtons.Left;
            gmap.ShowCenter = false;
            gmap.Position = new GMap.NET.PointLatLng(40.9277082, 29.1301233);
            GMapOverlay markers = new GMapOverlay("markers");
            foreach (DataGridViewRow item in dgwAds.Rows)
            {
                if (item.Cells["Id"].Value != null)
                {
                    if (int.Parse(item.Cells["Type"].Value.ToString()) == 1)
                    {
                        GMapMarker marker = new GMarkerGoogle(
                new PointLatLng(double.Parse(item.Cells[8].Value.ToString()), double.Parse(item.Cells[9].Value.ToString())),
                GMarkerGoogleType.green_pushpin);
                        marker.Tag = item.Cells["Id"].Value;
                        markers.Markers.Add(marker);

                    }
                    if (int.Parse(item.Cells["Type"].Value.ToString()) == 2)
                    {
                        GMapMarker marker = new GMarkerGoogle(
                new PointLatLng(double.Parse(item.Cells[8].Value.ToString()), double.Parse(item.Cells[9].Value.ToString())),
                GMarkerGoogleType.lightblue_pushpin);
                        marker.Tag = item.Cells["Id"].Value;
                        markers.Markers.Add(marker);

                    }
                    if (int.Parse(item.Cells["Type"].Value.ToString()) == 3)
                    {
                        GMapMarker marker = new GMarkerGoogle(
                new PointLatLng(double.Parse(item.Cells[8].Value.ToString()), double.Parse(item.Cells[9].Value.ToString())),
                GMarkerGoogleType.purple_pushpin);
                        marker.Tag = item.Cells["Id"].Value;
                        markers.Markers.Add(marker);

                    }
                    if (int.Parse(item.Cells["Type"].Value.ToString()) == 4)
                    {
                        GMapMarker marker = new GMarkerGoogle(
                new PointLatLng(double.Parse(item.Cells[8].Value.ToString()), double.Parse(item.Cells[9].Value.ToString())),
                GMarkerGoogleType.yellow_pushpin);
                        marker.Tag = item.Cells["Id"].Value;
                        markers.Markers.Add(marker);

                    }
                    if (int.Parse(item.Cells["Type"].Value.ToString()) == 5)
                    {
                        GMapMarker marker = new GMarkerGoogle(
                new PointLatLng(double.Parse(item.Cells[8].Value.ToString()), double.Parse(item.Cells[9].Value.ToString())),
                GMarkerGoogleType.pink_pushpin);
                        marker.Tag = item.Cells["Id"].Value;
                        markers.Markers.Add(marker);
                    }
                }
            }
            gmap.Overlays.Add(markers);
        }
        private void gmap_OnMarkerClick(GMapMarker item, MouseEventArgs e)
        {
            AdsModel ad = new AdsModel();
            dgwDetails.DataSource = dal.getDataTable("Select * FROM Ads WHERE Id = @ID; ", int.Parse(item.Tag.ToString()));
            ad.id = int.Parse(dgwDetails.Rows[0].Cells["Id"].Value.ToString());
            ad.title = dgwDetails.Rows[0].Cells["Title"].Value.ToString();
            ad.lang = float.Parse(dgwDetails.Rows[0].Cells["Long"].Value.ToString());
            ad.lat = float.Parse(dgwDetails.Rows[0].Cells["Lat"].Value.ToString());
            ad.price = int.Parse(dgwDetails.Rows[0].Cells["Price"].Value.ToString());
            ad.status = int.Parse(dgwDetails.Rows[0].Cells["Status"].Value.ToString());
            ad.type = int.Parse(dgwDetails.Rows[0].Cells["Type"].Value.ToString());
            ad.currency = int.Parse(dgwDetails.Rows[0].Cells["Currency"].Value.ToString());
            ad.area = int.Parse(dgwDetails.Rows[0].Cells["Area"].Value.ToString());
            ad.description = dgwDetails.Rows[0].Cells["Description"].Value.ToString();
            Form4 form4 = new Form4(ad);
            form4.Show();

        }
        void giveDataSource(string query)
        {
            dgwAds.DataSource = null;
            dgwAds.DataSource = dal.getDataTable(query);
            dgwAds.Columns[9].Visible = false;
            dgwAds.Columns[8].Visible = false;
            dgwAds.Columns[7].Visible = false;
            dgwAds.Columns[6].Visible = false;
            dgwAds.Columns[5].Visible = false;
            dgwAds.Columns[4].Visible = false;
            dgwAds.Columns[3].Visible = false;
            dgwAds.Columns[2].Visible = false;
        }
        string fQuery = "Select * from Ads WHERE NOT Status = 3";
        string sQuery = "Select * from Ads WHERE NOT Status = 3";
        bool isAdmin;
        void prep()
        {
            visibles();
            giveDataSource(fQuery);
            gMap();
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 form2 = new RealtyInterface.Form2();
            form2.Show();
        }
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int a = dal.ExecuteCommand("UPDATE Ads SET Status = 3 WHERE Id = @ID; ", new List<Parameters> {
            new Parameters { Name = "@ID", Value = int.Parse(dgwAds.SelectedRows[0].Cells[0].Value.ToString()) }});
            giveDataSource(sQuery);
        }
        private void checkBox1_CheckStateChanged(object sender, EventArgs e)
        {
            if (checkBox2.Visible)
            {
                checkBox2.Visible = false;
                checkBox3.Visible = false;
                checkBox4.Visible = false;
                checkBox5.Visible = false;
                checkBox6.Visible = false;
                checkBox2.Checked = false;
                checkBox3.Checked = false;
                checkBox4.Checked = false;
                checkBox5.Checked = false;
                checkBox6.Checked = false;
                sQuery = fQuery;

            }
            else
            {
                checkBox2.Visible = true;
                checkBox3.Visible = true;
                checkBox4.Visible = true;
                checkBox5.Visible = true;
                checkBox6.Visible = true;
                checkBox2.Checked = false;
                checkBox3.Checked = false;
                checkBox4.Checked = false;
                checkBox5.Checked = false;
                checkBox6.Checked = false;
                sQuery = fQuery;
            }
        }
        private void checkBox2_CheckStateChanged(object sender, EventArgs e)
        {
            label1.Visible = checkBox2.Checked;
            comboBox1.Visible = checkBox2.Checked;
        }
        private void checkBox3_CheckStateChanged(object sender, EventArgs e)
        {
            label2.Visible = checkBox3.Checked;
            comboBox2.Visible = checkBox3.Checked;
        }
        private void checkBox4_CheckStateChanged(object sender, EventArgs e)
        {
            label4.Visible = checkBox4.Checked;
            label5.Visible = checkBox4.Checked;
            textBox1.Visible = checkBox4.Checked;
            textBox2.Visible = checkBox4.Checked;
        }
        private void checkBox5_CheckStateChanged(object sender, EventArgs e)
        {
            label3.Visible = checkBox5.Checked;
            comboBox3.Visible = checkBox5.Checked;
        }
        private void checkBox6_CheckStateChanged(object sender, EventArgs e)
        {
            label6.Visible = checkBox6.Checked;
            label7.Visible = checkBox6.Checked;
            textBox3.Visible = checkBox6.Checked;
            textBox4.Visible = checkBox6.Checked;
        }
        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AdsModel ad = new AdsModel(
                int.Parse(dgwAds.SelectedRows[0].Cells[0].Value.ToString()),
                dgwAds.SelectedRows[0].Cells[1].Value.ToString(),
                int.Parse(dgwAds.SelectedRows[0].Cells[2].Value.ToString()),
                int.Parse(dgwAds.SelectedRows[0].Cells[3].Value.ToString()),
                int.Parse(dgwAds.SelectedRows[0].Cells[4].Value.ToString()),
                dgwAds.SelectedRows[0].Cells[5].Value.ToString(),
                int.Parse(dgwAds.SelectedRows[0].Cells[6].Value.ToString()),
                int.Parse(dgwAds.SelectedRows[0].Cells[7].Value.ToString()),
                float.Parse(dgwAds.SelectedRows[0].Cells[8].Value.ToString()),
                float.Parse(dgwAds.SelectedRows[0].Cells[9].Value.ToString())
                );
            Form2 form2 = new RealtyInterface.Form2(true, ad);
            form2.Show();


        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                sQuery = fQuery;
                if (checkBox2.Checked)
                {
                    int a = comboBox1.SelectedIndex + 1;
                    sQuery += " AND Status = " + a;

                }
                if (checkBox3.Checked)
                {
                    int a = comboBox2.SelectedIndex + 1;
                    sQuery += " AND Currency = " + a;

                }

                if (checkBox4.Checked)
                {
                    sQuery += " AND Price BETWEEN " + textBox1.Text + " AND " + textBox2.Text;
                }
                if (checkBox5.Checked)
                {
                    int a = comboBox3.SelectedIndex + 1;
                    sQuery += " AND Type = " + a;
                }
                if (checkBox6.Checked)
                {
                    sQuery += " AND Area BETWEEN " + textBox4.Text + " AND " + textBox3.Text;
                }

                try { giveDataSource(sQuery); }
                catch (Exception)
                {
                    MessageBox.Show("You've entered a wrong filter setting!");
                    giveDataSource(fQuery);
                }
            }
            else { giveDataSource(fQuery); }
        }
        private void detailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AdsModel ad = new AdsModel(
                int.Parse(dgwAds.SelectedRows[0].Cells[0].Value.ToString()),
                dgwAds.SelectedRows[0].Cells[1].Value.ToString(),
                int.Parse(dgwAds.SelectedRows[0].Cells[2].Value.ToString()),
                int.Parse(dgwAds.SelectedRows[0].Cells[3].Value.ToString()),
                int.Parse(dgwAds.SelectedRows[0].Cells[4].Value.ToString()),
                dgwAds.SelectedRows[0].Cells[5].Value.ToString(),
                int.Parse(dgwAds.SelectedRows[0].Cells[6].Value.ToString()),
                int.Parse(dgwAds.SelectedRows[0].Cells[7].Value.ToString()),
                float.Parse(dgwAds.SelectedRows[0].Cells[8].Value.ToString()),
                float.Parse(dgwAds.SelectedRows[0].Cells[9].Value.ToString()));
            Form4 form4 = new Form4(ad);
            form4.Show();
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
