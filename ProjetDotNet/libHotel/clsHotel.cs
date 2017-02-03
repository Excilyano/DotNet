using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetDotNet.libHotel
{
    public class clsHotel
    {

        private string connectionStringHotel = "Data Source=LAPTOP-HHTO2271\\SQLEXPRESS;Initial Catalog=Hotels;Integrated Security=True";
        public clsHotel()
        {
        }

        public DataSet liste_Hotels(string ville)
        {
            SqlConnection MyC = new SqlConnection();
            MyC.ConnectionString = connectionStringHotel;
            MyC.Open();
            SqlCommand MyCom = new SqlCommand("sp_getHotels", MyC);
            MyCom.CommandType = CommandType.StoredProcedure;
            MyCom.Parameters.Add("@Ville", SqlDbType.NChar);
            MyCom.Parameters["@Ville"].Value = ville;
            SqlDataAdapter MyAdapt = new SqlDataAdapter();
            DataSet myDS = new DataSet();
            MyAdapt.SelectCommand = MyCom;
            MyAdapt.Fill(myDS, "liste_hotels");
            MyAdapt.Dispose();
            MyCom.Dispose();
            MyC.Close();
            return myDS;
        }

        public int reservationHotel(string nom, string prenom, int idHotel)
        {
            SqlConnection MyC = new SqlConnection();
            MyC.ConnectionString = connectionStringHotel;
            MyC.Open();
            SqlCommand MyCom = new SqlCommand("sp_reserverHotel", MyC);
            MyCom.CommandType = CommandType.StoredProcedure;
            MyCom.Parameters.Add("@Nom", SqlDbType.NChar);
            MyCom.Parameters["@Nom"].Value = nom;
            MyCom.Parameters.Add("@Prenom", SqlDbType.NChar);
            MyCom.Parameters["@Prenom"].Value = prenom;
            MyCom.Parameters.Add("@IdHotel", SqlDbType.Int);
            MyCom.Parameters["@IdHotel"].Value = idHotel;
            int Res = Convert.ToInt32(MyCom.ExecuteScalar());
            MyCom.Dispose();
            MyC.Close();
            return Res;
        }
    }
}
