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
        public clsVol()
        {
        }

        public DataSet listeVols(string depart, string arrivee)
        {
            SqlConnection MyC = new SqlConnection();
            MyC.ConnectionString = "Data Source=(local);Initial Catalog=Vols ;Integrated Security=True";
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
            MyAdapt.Fill(myDS, "liste_Vols");
            MyAdapt.Dispose();
            MyCom.Dispose();
            MyC.Close();
            return myDS;
        }
    }
}
