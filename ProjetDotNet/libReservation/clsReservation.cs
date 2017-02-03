using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetDotNet.libReservation
{
    public class clsReservation
    {
        public clsReservation()
        {
        }

        public int reservationVol(string nom, string prenom, int idVol)
        {
            SqlConnection MyC = new SqlConnection();
            MyC.ConnectionString = "Data Source=(local);Initial Catalog=Vols ;Integrated Security=True";
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

        public int reservationHotel(string nom, string prenom, int idHotel)
        {
            SqlConnection MyC = new SqlConnection();
            MyC.ConnectionString = "Data Source=(local);Initial Catalog=Hotels ;Integrated Security=True";
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
