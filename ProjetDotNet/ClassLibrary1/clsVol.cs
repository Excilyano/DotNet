﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace ProjetDotNet.libVol
{
    public class clsVol
    {
        private string connectionStringVol = "Data Source=laptop-hhto2271\\sqlexpress;Initial Catalog=Vols;User ID=sa;Password=password";
        private SqlTransaction myTransaction;
        private SqlConnection MyC;
        private SqlCommand MyCom;

        public clsVol()
        {
            this.myTransaction = null;
            this.MyC = null;
            this.MyCom = null;
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
            int res = -1;

            try
            {
                MyC = new SqlConnection();
                MyC.ConnectionString = connectionStringVol;
                MyC.Open();
                myTransaction = MyC.BeginTransaction();

                MyCom = new SqlCommand("sp_reserverVol", MyC);
                MyCom.Transaction = myTransaction;
                MyCom.CommandType = CommandType.StoredProcedure;
                MyCom.Parameters.Add("@Nom", SqlDbType.NChar);
                MyCom.Parameters["@Nom"].Value = nom;
                MyCom.Parameters.Add("@Prenom", SqlDbType.NChar);
                MyCom.Parameters["@Prenom"].Value = prenom;
                MyCom.Parameters.Add("@IdVol", SqlDbType.Int);
                MyCom.Parameters["@IdVol"].Value = idVol;

                MyCom.ExecuteNonQuery();

                res = 0;
            }catch(Exception e)
            {
            }

            return res;

        }

        public DataSet liste_Villes()
        {
            SqlConnection MyC = new SqlConnection();
            MyC.ConnectionString = connectionStringVol;
            MyC.Open();
            SqlCommand MyCom = new SqlCommand("sp_getVilles", MyC);
            MyCom.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter MyAdapt = new SqlDataAdapter();
            DataSet myDS = new DataSet();
            MyAdapt.SelectCommand = MyCom;
            MyAdapt.Fill(myDS, "liste_villes");
            MyAdapt.Dispose();
            MyCom.Dispose();
            MyC.Close();
            return myDS;
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
