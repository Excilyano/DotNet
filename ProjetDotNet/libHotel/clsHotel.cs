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
        public clsHotel()
        {
        }

        public DataSet liste_Hotels(string ville)
        {
            SqlConnection MyC = new SqlConnection();
            MyC.ConnectionString = "Data Source=(local);Initial Catalog=Hotels ;Integrated Security=True";
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
    }
}
