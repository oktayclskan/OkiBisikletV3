using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeriTabaniIslem
{
    public class Bisikletler
    {
        public int ID { get; set; }
        public string Marka { get; set; }
        public string Model { get; set; }
        public string Agirlik { get; set; }
        public int KategoriID { get; set; }
        public int SuspansiyonID { get; set; }
        public int RenkID { get; set; }
        public int VitesID { get; set; }
        public int GovdeID { get; set; }
        public decimal Fiyat { get; set; }
    }
}
