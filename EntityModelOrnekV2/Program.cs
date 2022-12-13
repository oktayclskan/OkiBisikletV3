using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeriTabaniIslem;


namespace EntityModelOrnekV2
{
    class Program
    {
        static void Main(string[] args)
        {
            
            DataModel dm = new DataModel();
            Bisikletler b = new Bisikletler();
            Bisikletler u = new Bisikletler();


            #region Konsoldan alınan kategori yi ekle s

            //Console.WriteLine("Eklemek İstediğiniz Kategori Adını Yapınız");
            //string kategori = Console.ReadLine();
            //Kategoriler k = new Kategoriler();
            //k.KategoriTur =kategori ;

            //if (dm.KategoriEkle(k))
            //{
            //    Console.WriteLine("Ekleme işlemi başarılı");
            //}
            //else
            //{
            //    Console.WriteLine("Ekleme işlemi başarısız");
            //}


            #endregion
            Console.WriteLine("");
            Console.WriteLine("                     ***      OKİ BİSİKLET      ***");
            Console.WriteLine("");
            //Console.WriteLine("    LÜTFEM İŞLEM SEÇİNİZ");
            //Console.WriteLine("");
            Console.WriteLine("1. )" + "BİSİKLET SATIN AL");
            Console.WriteLine("       ");
            Console.WriteLine("    ");
            Console.WriteLine("2. )" + "ADMİN PANELİ");
            string panel = Console.ReadLine();
            #region Admin paneli
            if (panel=="2")
            {
                Console.WriteLine("LÜTFEN ŞİFREYİ GİRİNİZ");
                string sifre = Console.ReadLine();
                if (sifre=="1626")
                {
                    Console.WriteLine("1 .) " + "* BİSİKLET EKLE * ");
                    Console.WriteLine(" * ");
                    Console.WriteLine("2 .) " + "* GÜNCELLEME İŞLEMLERİ *");
                    Console.WriteLine(" * ");
                    Console.WriteLine("3 .) " + "* BİSİKLET KALDIR *");
                    Console.WriteLine(" ");
                    string secenek = Console.ReadLine();
                    Console.Clear();
                    if (secenek == "1")
                    {
                        Console.WriteLine("");
                        Console.WriteLine("                                             ***      OKİ BİSİKLET      ***");
                        Console.WriteLine("");
                        Console.WriteLine("  EKLEMEK İSTEDİĞİNİZ BİSİKLETİN MARKASINI YAZINIZ");
                        string marka = Console.ReadLine();

                        b.Marka = marka;

                        Console.WriteLine("  EKLEMEK İSTEDİĞİNİZ BİSİKLETİN MODEL YAZINIZ");
                        string model = Console.ReadLine();
                        b.Model = model;

                        Console.WriteLine("  EKLEMEK İSTEDİĞİNİZ BİSİKLETİN AĞIRLIĞINI YAZINIZ");
                        string agırlık = Console.ReadLine();
                        b.Agirlik = agırlık;

                        Console.Clear();
                        List<Kategoriler> kategoriler = dm.KategoriListele();
                        foreach (Kategoriler item in kategoriler)
                        {
                            Console.WriteLine(item.ID + ".) " + item.KategoriTur);
                            Console.WriteLine("            *                  ");
                        }
                        Console.WriteLine(" KATEGORİSİNİ BELİRTİNİZ");
                        int KategoriId = Convert.ToInt32(Console.ReadLine());
                        b.KategoriID = KategoriId;
                        Console.Clear();
                        List<Suspansiyonlar> suspansiyonlar = dm.SuspansiyonListele();
                        foreach (Suspansiyonlar item in suspansiyonlar)
                        {
                            Console.WriteLine($"{item.ID}.){item.Marka} {item.Model} Fiyat = {item.Fiyat}");
                            Console.WriteLine("            *                  ");
                        }
                        Console.WriteLine("  SÜSPANSİYONUNU SEÇİNİZ");
                        int suspansiyonID = Convert.ToInt32(Console.ReadLine());
                        b.SuspansiyonID = suspansiyonID;
                        Console.Clear();
                        List<Renkler> renkler = dm.RenkListele();
                        foreach (Renkler item in renkler)
                        {
                            Console.WriteLine($"{item.ID}.) {item.Renk}");
                            Console.WriteLine("            *                  ");
                        }
                        Console.WriteLine("  RENKGİNİ SEÇİNİZ");
                        int renkID = Convert.ToInt32(Console.ReadLine());
                        b.RenkID = renkID;
                        Console.Clear();
                        List<GovdeTurleri> govdeturleri = dm.GovdeTurListele();
                        foreach (GovdeTurleri item in govdeturleri)
                        {
                            Console.WriteLine($"{item.ID}.)  {item.Govdetur}");
                            Console.WriteLine("            *                  ");
                        }
                        Console.WriteLine("  GÖVDE TÜRÜNÜ BELİRTİNİZ");
                        int govdeTur = Convert.ToInt32(Console.ReadLine());
                        b.GovdeID = govdeTur;
                        Console.Clear();
                        List<VitesSecenekler> vitessecenek = dm.VitesSecenekListele();
                        foreach (VitesSecenekler item in vitessecenek)
                        {
                            Console.WriteLine($"{item.Id}.) {item.Vites}");
                            Console.WriteLine("            *                  ");
                        }
                        Console.WriteLine("  VİTES SEÇİNİZ");
                        int vitesıd = Convert.ToInt32(Console.ReadLine());
                        b.VitesID = vitesıd;

                        Console.WriteLine("  FİYATINI BELİRTİNİZ");
                        decimal fiyat = Convert.ToDecimal(Console.ReadLine());
                        b.Fiyat = fiyat;

                        if (dm.BisikletEkle(b))
                        {
                            Console.WriteLine("  BİSİKLETİNİZ EKLENMİŞTİR");
                            Console.WriteLine("");
                        }
                        else
                        {
                            Console.WriteLine("  BİSİKLET EKLERKEN HATA OLUŞTU");
                        }
                    }
                    if (secenek == "2")
                    {
                        Console.WriteLine("");
                        Console.WriteLine("                     ***      OKİ BİSİKLET      ***");
                        Console.WriteLine("");


                        List<Bisikletler> bisikletlerr = dm.BisikletListele();
                        foreach (Bisikletler item in bisikletlerr)
                        {

                            Console.WriteLine($"{item.ID}.)\n \t* Marka = {item.Marka}\n \t* Model = {item.Model}\n \t* Ağırlık ={item.Agirlik}\n \t* KategoriID = {item.KategoriID}\n \t* SüspansiyonId = {item.SuspansiyonID}\n \t* RenkId = {item.RenkID}\n \t* VitesId = {item.VitesID}\n \t* GövdeId = {item.GovdeID}\n \t* Fiyat = {item.Fiyat}");
                            Console.WriteLine("");

                        }
                        Console.WriteLine("GÜNCELLEMEK İSTEDİĞİNİZ VEYA SİLMEK İSTEDİĞİNİZ BİSİKLETİN ID'SİNİ YAZINIZ");
                        u.ID = Convert.ToInt32(Console.ReadLine());
                        Console.Clear();
                        Console.WriteLine("");
                        Console.WriteLine("");
                        Console.WriteLine("1" + ".) " + "* MARKA GÜNCELLE *");
                        Console.WriteLine("");
                        Console.WriteLine("2" + ".)" + "* MODEL GÜNCELLE *");
                        Console.WriteLine("");
                        Console.WriteLine("3" + ".)" + "* AĞIRLIK GÜNCELLE *");
                        Console.WriteLine("");
                        Console.WriteLine("4" + ".)" + "* KATEGORİ GÜNCELLE *");
                        Console.WriteLine("");
                        Console.WriteLine("5" + ".)" + "* SÜSPANSİYON GÜNCELLE *");
                        Console.WriteLine("");
                        Console.WriteLine("6" + ".)" + "* RENK GÜNCELLE *");
                        Console.WriteLine("");
                        Console.WriteLine("7" + ".)" + "* VİTES GÜNCELLE *");
                        Console.WriteLine("");
                        Console.WriteLine("8" + ".)" + "* GÖVDE TÜR GÜNCELLE *");
                        Console.WriteLine("");
                        Console.WriteLine("9" + ".)" + "* FİYAT GÜNCELLE *");
                        Console.WriteLine("");

                        Console.WriteLine("YAPMAK İSTEDĞİNİZ İŞLEMİ SEÇİNİZ");

                        string gncll = Console.ReadLine();
                        Console.Clear();



                        if (gncll == "1")
                        {
                            Console.WriteLine("Güncellemek istediğiniz Markayı Yazınız");
                            u.Marka = Console.ReadLine();

                            if (dm.MarkaUpdateEt(u))
                            {
                                Console.WriteLine("başarılı");
                            }
                            else
                            {
                                Console.WriteLine("Başarısız");
                            }
                        }
                        else if (gncll == "2")
                        {
                            Console.WriteLine("Güncellemek istediğiniz Modeli Yazınız");
                            u.Model = Console.ReadLine();
                            if (dm.ModelUpdateET(u))
                            {
                                Console.WriteLine("Başarılı");
                            }
                            else
                            {
                                Console.WriteLine("Başarısız");
                            }
                        }
                        else if (gncll == "3")
                        {
                            Console.WriteLine("GÜNCEL AĞIRLIĞI YAZINIZ");
                            u.Agirlik = Console.ReadLine();
                            if (dm.AgırlıkUpdateEt(u))
                            {
                                Console.WriteLine("Başarılı");
                            }
                            else
                            {
                                Console.WriteLine("Başarısız");
                            }
                        }
                        else if (gncll == "4")
                        {
                            List<Kategoriler> kategoriler = dm.KategoriListele();
                            foreach (Kategoriler item in kategoriler)
                            {
                                Console.WriteLine(item.ID + ".) " + item.KategoriTur);
                            }
                            Console.WriteLine("GÜNCEL KATEGORİYİ SEÇİNİZ");
                            u.KategoriID = Convert.ToInt32(Console.ReadLine());

                            if (dm.KategoriUpdateEt(u))
                            {
                                Console.WriteLine("Başarılı");
                            }
                            else
                            {
                                Console.WriteLine("Başarısız");
                            }
                        }
                        else if (gncll == "5")
                        {
                            List<Suspansiyonlar> suspansiyonlar = dm.SuspansiyonListele();
                            foreach (Suspansiyonlar item in suspansiyonlar)
                            {
                                Console.WriteLine(item.ID + ".)" + item.Marka + " " + item.Model + " " + item.Fiyat);
                                Console.WriteLine("");
                            }
                            Console.WriteLine("GÜNCEL SÜSPANSİYONU SEÇİNİZ");
                            int suspsn = Convert.ToInt32(Console.ReadLine());
                            u.SuspansiyonID = suspsn;
                            if (dm.SuspansiyonUpdateET(u))
                            {
                                Console.WriteLine("BAŞARILI");
                            }
                            else
                            {
                                Console.WriteLine("BAŞARISIZ");
                            }
                        }
                        else if (gncll == "6")
                        {
                            List<Renkler> renkler = dm.RenkListele();
                            foreach (Renkler item in renkler)
                            {
                                Console.WriteLine(item.ID + ".)" + item.Renk);
                                Console.WriteLine("");
                            }
                            Console.WriteLine("GÜNCEL RENK SEÇİNİZ");
                            int rnk = Convert.ToInt32(Console.ReadLine());
                            u.RenkID = rnk;
                            if (dm.RenkUpdateEt(u))
                            {
                                Console.WriteLine("BAŞARILI");
                            }
                            else
                            {
                                Console.WriteLine("BAŞARISIZ");
                            }
                        }
                        else if (gncll == "7")
                        {
                            List<VitesSecenekler> vitesSecenek = dm.VitesSecenekListele();
                            foreach (VitesSecenekler item in vitesSecenek)
                            {
                                Console.WriteLine(item.Id + ".)" + item.Vites);
                                Console.WriteLine("");
                            }
                            Console.WriteLine("GÜNCEL VİTES SECENEĞİNİ SEÇİNİZ");
                            int vitssecenek = Convert.ToInt32(Console.ReadLine());
                            u.VitesID = vitssecenek;
                            if (dm.VitesUpdateEt(u))
                            {
                                Console.WriteLine("BAŞARILI");
                            }
                            else
                            {
                                Console.WriteLine("BAŞARISIZ");
                            }
                        }
                        else if (gncll == "8")
                        {
                            List<GovdeTurleri> govdeTurleri = dm.GovdeTurListele();
                            foreach (GovdeTurleri item in govdeTurleri)
                            {
                                Console.WriteLine(item.ID + ".)" + item.Govdetur);
                                Console.WriteLine("");
                            }
                            Console.WriteLine("GÜNCEL GOVDE TÜR'Ü SEÇİNİZ");
                            int govdeTr = Convert.ToInt32(Console.ReadLine());
                            u.GovdeID = govdeTr;
                            if (dm.GovdeUpdateEt(u))
                            {
                                Console.WriteLine("Başarılı");
                            }
                            else
                            {
                                Console.WriteLine("Başarısız");
                            }
                        }
                        else if (gncll == "9")
                        {
                            Console.WriteLine("GÜNCEL FİYATI GİRİNİZ");
                            decimal Fiyat = Convert.ToDecimal(Console.ReadLine());
                            u.Fiyat = Fiyat;
                            if (dm.FiyatUpdateEt(u))
                            {
                                Console.WriteLine("BAŞARILI");
                            }
                            else
                            {
                                Console.WriteLine("BAŞARISIZ");
                            }
                        }
                    }
                    if (secenek == "3")
                    {
                        List<Bisikletler> bisikletlerr = dm.BisikletListele();
                        foreach (Bisikletler item in bisikletlerr)
                        {
                            Console.WriteLine($"{item.ID}.) {item.Marka} {item.Model} {item.Agirlik} {item.KategoriID} {item.SuspansiyonID} {item.RenkID} {item.VitesID} {item.GovdeID} {item.Fiyat}");
                            Console.WriteLine("");
                        }
                        Console.WriteLine("KALDIRMAK İSTEDİĞİNİZ BİSİKLETİN ID'SİNİ SEÇİNİZ");
                        u.ID = Convert.ToInt32(Console.ReadLine());
                        if (dm.BisikletDelete(u))
                        {
                            Console.WriteLine("Başarılı");
                        }
                        else
                        {
                            Console.WriteLine("Başarısız");
                        }
                    }
                }
            }
               
            #endregion
            #region Satın aldır
            if (panel=="1")
            {
                List<Bisikletler> bisikletler = dm.BisikletListele();
                
                foreach (Bisikletler item in bisikletler)
                {

                    Console.WriteLine($"{item.ID}.)\n \t* Marka = {item.Marka}\n \t* Model = {item.Model}\n \t* Ağırlık ={item.Agirlik}\n \t* KategoriID = {item.KategoriID}\n \t* SüspansiyonId = {item.SuspansiyonID}\n \t* RenkId = {item.RenkID}\n \t* VitesId = {item.VitesID}\n \t* GövdeId = {item.GovdeID}\n \t* Fiyat = {item.Fiyat}");
                    Console.WriteLine("");

                }
                Console.WriteLine("SATIN ALMAK İSTEDİĞİNİZ BİSİKLETİN İD'SİNİ YAZINIZ");
                u.ID = Convert.ToInt32(Console.ReadLine());
                

            }

            

            #endregion
        }
    }
}
