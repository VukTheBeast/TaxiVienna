using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace TaxiWebSite.Models
{
    public class BookingDataModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public string value { get; set; }
        public string label { get; set; }
    }
    
        public class BookingModel
    {
        static private string m_connectionString = WebConfigurationManager.ConnectionStrings["taxiConnectionString"].ConnectionString;

        static public IList<BookingDataModel> ListaUlica(String id, string tekst)
        {
            IList<BookingDataModel> ListaUlica = new List<BookingDataModel>();

            SqlConnection conn = new SqlConnection(m_connectionString);
            SqlCommand cmd = new SqlCommand("ListaUlica", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("id", id));
            cmd.Parameters.Add(new SqlParameter("tekst", tekst));

            SqlDataReader reader;

            try
            {
                BookingDataModel podaci;
                conn.Open();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    podaci = new BookingDataModel();
                    podaci.value = Convert.ToString(reader["Id"]);
                    podaci.label = Convert.ToString(reader["Name"]);

                    ListaUlica.Add(podaci);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
                cmd.Dispose();
            }
            return ListaUlica;
        }

        static public IList<BookingDataModel> ListaOblasti(string id)
        {
            IList<BookingDataModel> ListaOblasti = new List<BookingDataModel>();

            SqlConnection conn = new SqlConnection(m_connectionString);
            SqlCommand cmd = new SqlCommand("ListaOblasti", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("id", id));
            

            SqlDataReader reader;

            try
            {
                BookingDataModel podaci;
                conn.Open();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    podaci = new BookingDataModel();
                    podaci.id = Convert.ToInt32(reader["Id"]);
                    podaci.name = Convert.ToString(reader["Name"]);

                    ListaOblasti.Add(podaci);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
                cmd.Dispose();
            }
            return ListaOblasti;
        }

    }
}