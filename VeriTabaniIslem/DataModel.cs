using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace VeriTabaniIslem
{
    public class DataModel
    {
        SqlConnection con; SqlCommand cmd;

        public DataModel()
        {
            con = new SqlConnection(ConnectionStrings.LConStr);
            cmd = con.CreateCommand();
        }
        
        public bool KategoriEkle(Kategoriler k)
        {
            try
            {
                cmd.CommandText = "INSERT INTO Kategoriler (KategoriTur)Values (@kategoriTur)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@kategoriTur", k.KategoriTur);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }
        
        public bool BisikletEkle(Bisikletler b)
        {
            try
            {
                cmd.CommandText = "INSERT INTO Bisikletler(Marka,Model,Agirlik,Kategori_ID,Suspansiyon_ID,Renk_ID,Vites_ID,Govde_ID,Fiyat)VALUES (@marka,@model,@agırlık,@kategoriID,@suspansiyonID,@renkID,@vitesID,@govdeID,@fiyat)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@marka",b.Marka);
                cmd.Parameters.AddWithValue("@model", b.Model);
                cmd.Parameters.AddWithValue("@agırlık", b.Agirlik);
                cmd.Parameters.AddWithValue("@kategoriID", b.KategoriID);
                cmd.Parameters.AddWithValue("@suspansiyonID", b.SuspansiyonID);
                cmd.Parameters.AddWithValue("@renkID", b.RenkID);
                cmd.Parameters.AddWithValue("@vitesID", b.VitesID);
                cmd.Parameters.AddWithValue("@govdeID", b.GovdeID);
                cmd.Parameters.AddWithValue("@fiyat", b.Fiyat);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }
        public List<Bisikletler> BisikletListele()
        {
            List<Bisikletler> bisikletler = new List<Bisikletler>();
            try
            {
                cmd.CommandText = "SELECT ID,Marka,Model,Agirlik,Kategori_ID,Suspansiyon_ID,Renk_ID,Vites_ID,Govde_ID,Fiyat FROM Bisikletler";
                cmd.Parameters.Clear();
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                
                while (reader.Read())
                {
                    Bisikletler bsklt = new Bisikletler();
                    bsklt.ID = reader.GetInt32(0);
                    bsklt.Marka = reader.GetString(1);
                    bsklt.Model = reader.GetString(2);
                    bsklt.Agirlik = reader.GetString(3);
                    bsklt.KategoriID = reader.GetInt32(4);
                    bsklt.SuspansiyonID = reader.GetInt32(5);
                    bsklt.RenkID = reader.GetInt32(6);
                    bsklt.VitesID = reader.GetInt32(7);
                    bsklt.GovdeID = reader.GetInt32(8);
                    bsklt.Fiyat = reader.GetDecimal(9);
                    bisikletler.Add(bsklt);
                }
                return bisikletler;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }
        public List<Kategoriler> KategoriListele()
        {
            List<Kategoriler> kategoriler = new List<Kategoriler>();
            try
            {
                cmd.CommandText = "SELECT ID,KategoriTur FROM Kategoriler";
                cmd.Parameters.Clear();
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Kategoriler k = new Kategoriler();
                    k.ID = reader.GetInt32(0);
                    k.KategoriTur = reader.GetString(1);
                    kategoriler.Add(k);
                }
                return kategoriler;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }
        public List<Suspansiyonlar> SuspansiyonListele()
        {
            List<Suspansiyonlar> suspansiyonlar = new List<Suspansiyonlar>();
            try
            {
                cmd.CommandText = "SELECT ID,Marka,Model,Fiyat FROM Suspansiyonlar ";
                cmd.Parameters.Clear();
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                
                while (reader.Read())
                {
                    Suspansiyonlar s = new Suspansiyonlar();
                    s.ID = reader.GetInt32(0);
                    s.Marka = reader.GetString(1);
                    s.Model = reader.GetString(2);
                    s.Fiyat = reader.GetDecimal(3);
                    suspansiyonlar.Add(s);
                }
                return suspansiyonlar;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }
        public List<Renkler> RenkListele()
        {
            List<Renkler> renkler = new List<Renkler>();
            try
            {
                cmd.CommandText = "SELECT ID,Renk FROM Renkler";
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Renkler r = new Renkler();
                    r.ID = reader.GetInt32(0);
                    r.Renk = reader.GetString(1);
                    renkler.Add(r);
                }
                return renkler;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }
        public List<GovdeTurleri> GovdeTurListele()
        {
            List<GovdeTurleri> govdeturleri = new List<GovdeTurleri>();
            try
            {
                cmd.CommandText = "SELECT ID,Govde_Tur FROM GovdeTur";
                cmd.Parameters.Clear();
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    GovdeTurleri g = new GovdeTurleri();
                    g.ID = reader.GetInt32(0);
                    g.Govdetur = reader.GetString(1);
                    govdeturleri.Add(g);
                }
                return govdeturleri;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }
        public List<VitesSecenekler> VitesSecenekListele()
        {
            List<VitesSecenekler> vitesSecenekler = new List<VitesSecenekler>();
            try
            {
                cmd.CommandText = "SELECT ID, Vites FROM VitesSecenekler";
                cmd.Parameters.Clear();
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    VitesSecenekler vs = new VitesSecenekler();
                    vs.Id = reader.GetInt32(0);
                    vs.Vites = reader.GetString(1);
                    vitesSecenekler.Add(vs);

                }
                return vitesSecenekler;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public bool MarkaUpdateEt(Bisikletler u)
        {
            try
            {

                cmd.CommandText = "UPDATE Bisikletler SET Marka = @marka where ID =@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@marka", u.Marka);
                cmd.Parameters.AddWithValue("@id", u.ID);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                con.Close();
            }
            
        }
        public bool ModelUpdateET(Bisikletler u)
        {
            try
            {
                cmd.CommandText = "UPDATE Bisikletler Set Model = @model where ID = @id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@model", u.Model);
                cmd.Parameters.AddWithValue("@id", u.ID);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                con.Close();
            }
            
        }
        public bool AgırlıkUpdateEt(Bisikletler u)
        {
            try
            {
                cmd.CommandText = "Update Bisikletler SET Agirlik =@agirlik WHERE ID = @id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@agirlik",u.Agirlik);
                cmd.Parameters.AddWithValue("@id", u.ID);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }
        public bool KategoriUpdateEt(Bisikletler u)
        {
            try
            {
                cmd.CommandText = "UPDATE Bisikletler SET Kategori_ID =@kategoriId WHERE ID =@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@kategoriId", u.KategoriID);
                cmd.Parameters.AddWithValue("@id", u.ID);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }
        public bool SuspansiyonUpdateET(Bisikletler u)
        {
            try
            {
                cmd.CommandText = "UPDATE Bisikletler SET Suspansiyon_ID =@suspansiyonId WHERE ID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@suspansiyonId",u.SuspansiyonID);
                cmd.Parameters.AddWithValue("@id",u.ID);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }
        public bool RenkUpdateEt(Bisikletler u)
        {
            try
            {
                cmd.CommandText = "UPDATE Bisikletler SET Renk_ID =@renkId WHERE ID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@renkId", u.RenkID);
                cmd.Parameters.AddWithValue("@id", u.ID);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }
        public bool VitesUpdateEt(Bisikletler u)
        {
            try
            {
                cmd.CommandText = "UPDATE Bisikletler SET Vites_ID =@vitesId Where ID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@vitesId",u.VitesID);
                cmd.Parameters.AddWithValue("@id",u.ID);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }
        public bool GovdeUpdateEt(Bisikletler u)
        {
            try
            {
                cmd.CommandText = "UPDATE Bisikletler SET Govde_ID =@govdeId Where ID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@govdeId", u.GovdeID);
                cmd.Parameters.AddWithValue("@id", u.ID);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }
        public bool FiyatUpdateEt(Bisikletler u)
        {
            try
            {
                cmd.CommandText = "Update Bisikletler Set Fiyat =@fiyat Where ID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@fiyat", u.Fiyat);
                cmd.Parameters.AddWithValue("@id", u.ID);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                con.Close();
            }
            

        }
        public bool BisikletDelete(Bisikletler u)
        {
            try
            {
                cmd.CommandText = "Delete Bisikletler Where ID =@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", u.ID);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }
        
    }
}

