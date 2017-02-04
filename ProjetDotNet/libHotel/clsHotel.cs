using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetDotNet.libHotel
{
    public class clsHotel
    {

        private string connectionStringHotel = "Data Source=laptop-hhto2271\\sqlexpress;Initial Catalog=Hotels;User ID=sa;Password=password";
        private SqlTransaction myTransaction;
        private SqlConnection MyC;
        private SqlCommand MyCom;

        public clsHotel()
        {
            this.myTransaction = null;
            this.MyC = null;
            this.MyCom = null;
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

            int res = -1;

            try
            {
                MyC = new SqlConnection();
                MyC.ConnectionString = connectionStringHotel;
                MyC.Open();
                myTransaction = MyC.BeginTransaction();

                MyCom = new SqlCommand("sp_reserverHotel", MyC);
                MyCom.Transaction = myTransaction;
                MyCom.CommandType = CommandType.StoredProcedure;
                MyCom.Parameters.Add("@Nom", SqlDbType.NChar);
                MyCom.Parameters["@Nom"].Value = nom;
                MyCom.Parameters.Add("@Prenom", SqlDbType.NChar);
                MyCom.Parameters["@Prenom"].Value = prenom;
                MyCom.Parameters.Add("@IdHotel", SqlDbType.Int);
                MyCom.Parameters["@IdHotel"].Value = idHotel;

                MyCom.ExecuteNonQuery();

                res = 0;
            } catch(Exception e)
            {

            }

            return res;
        }

        public void commit()
        {

                this.myTransaction.Commit();
                endTransaction();
        }

        public void rollback()
        {
            this.myTransaction.Rollback();
            endTransaction();
        }

        public void endTransaction()
        {
            this.MyCom.Dispose();
            this.MyC.Close();
        }
    }

}
