using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealtyInterface
{
    public class AdsModel

    {
        public int id { get; set; }
        public string title { get; set; }
        public int status { get; set; }
        public int price { get; set; }
        public int currency { get; set; }
        public int type { get; set; }
        public int area { get; set; }
        public string description { get; set; }
        public float lat { get; set; }
        public float lang { get; set; }
        public AdsModel() { }
        public AdsModel(int id, string title, int status, int price, int currency, string description, int type, int area, float lat, float lang)
        {
            this.id = id;
            this.title = title;
            this.status = status;
            this.price = price;
            this.currency = currency;
            this.type = type;
            this.area = area;
            this.description = description;
            this.lat = lat;
            this.lang = lang;
        }
    }
}
