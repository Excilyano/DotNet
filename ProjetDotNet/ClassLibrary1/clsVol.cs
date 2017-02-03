using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace ProjetDotNet.libVol
{
    public class clsVol
    {
        private string connectionStringVol = "Data Source=LAPTOP-HHTO2271\\SQLEXPRESS;Initial Catalog=Vols;Integrated Security=True";

        public clsVol()
        {
        }

        public DataSet liste_Vols(string depart, string arrivee)
        {
            SqlConnection MyC = new SqlConnection();
            MyC.ConnectionString = connectionStringVol;
            MyC.Open();
            SqlCommand MyCom = new SqlCommand("sp_getVols", MyC);
            MyCom.CommandType = CommandType.StoredProcedure;
            MyCom.Parameters.Add("@Depart", SqlDbType.NChar);
            MyCom.Parameters["@Depart"].Value = depart;
            MyCom.Parameters.Add("@Arrivee", SqlDbType.NChar);
            MyCom.Parameters["@Arrivee"].Value = arrivee;
            SqlDataAdapter MyAdapt = new SqlDataAdapter();
            DataSet myDS = new DataSet();
            MyAdapt.SelectCommand = MyCom;
            MyAdapt.Fill(myDS, "liste_vols");
            MyAdapt.Dispose();
            MyCom.Dispose();
            MyC.Close();
            return myDS;
        }

        public int reservationVol(string nom, string prenom, int idVol)
        {
            SqlConnection MyC = new SqlConnection();
            MyC.ConnectionString = connectionStringVol;
            MyC.Open();
            SqlCommand MyCom = new SqlCommand("sp_reserverVol", MyC);
            MyCom.CommandType = CommandType.StoredProcedure;
            MyCom.Parameters.Add("@Nom", SqlDbType.NChar);
            MyCom.Parameters["@Nom"].Value = nom;
            MyCom.Parameters.Add("@Prenom", SqlDbType.NChar);
            MyCom.Parameters["@Prenom"].Value = prenom;
            MyCom.Parameters.Add("@IdVol", SqlDbType.Int);
            MyCom.Parameters["@IdVol"].Value = idVol;
            int Res = Convert.ToInt32(MyCom.ExecuteScalar());
            MyCom.Dispose();
            MyC.Close();
            return Res;
        }
    }
}
