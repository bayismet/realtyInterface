using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using GMap.NET.MapProviders;

namespace RealtyInterface
{
    public partial class Form4 : Form
    {
        public Form4(AdsModel ad)
        {
            InitializeComponent();
            textBox1.Text = ad.title;
            comboBox1.SelectedIndex = ad.status - 1;
            textBox2.Text = ad.price.ToString();
            comboBox2.SelectedIndex = ad.currency - 1;
            comboBox3.SelectedIndex = ad.type - 1;
            textBox3.Text = ad.area.ToString();
            richTextBox1.Text = ad.description;
            textBox4.Text = ad.lang.ToString();
            textBox5.Text = ad.lat.ToString();
            gMap(ad);

        }
        void gMap(AdsModel ad)
        {
            gmaps.MapProvider = GMap.NET.MapProviders.GoogleMapProvider.Instance;
            GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerOnly;
            gmaps.DragButton = MouseButtons.Left;
            gmaps.ShowCenter = false;
            GMapOverlay markers = new GMapOverlay("markers");
            gmaps.Position = new GMap.NET.PointLatLng(ad.lat, ad.lang);
            GMapMarker marker = new GMarkerGoogle(
                new PointLatLng(ad.lat, ad.lang),
                GMarkerGoogleType.orange_dot);

            markers.Markers.Add(marker);
            gmaps.Overlays.Add(markers);
        }

    }
}
