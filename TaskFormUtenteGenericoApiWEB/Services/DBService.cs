using Shared_Resources;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskFormUtenteGenericoBlazorAppApiWEB
{
    public class DBService
    {
        private string cnn = string.Empty;
        private int index = 0;  
        public DBService(string connectionString)
        {
            cnn = connectionString;
        }


        /// <summary>
        ///         GESTIONE DEI CAMPI PER STRING, DATETIME E INTERI
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public string GestioneCampo(string str)
        {
            return $"'{str.Replace("'", "''")}'";
        }
        public string GestioneCampo(DateTime str)
        {
            return $"'{str.ToString("yyyy-MM-dd HH:mm:ss",CultureInfo.InvariantCulture)}'";
        }
        public string GestioneCampo(int value)
        {
            return value.ToString();
        }
        /// <summary>
        /// Esegue una query su database e restituisce il DataSet
        /// </summary>
        /// <param name="query">query da eseguire</param>
        /// <returns></returns>
        public (Errore, DataSet) EseguiQuery(string query) //passo connectionString e la query
        {
            DataSet ds = new DataSet();
            Errore er = null;
            SqlConnection connection = new SqlConnection(cnn);

            try
            {

                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();

                    using(SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(ds);
                    }
                
            }
            catch (Exception ex)
            {
                er = new Errore(ex);
            }
            finally
            {
                if(connection != null)
                {
                    connection.Close();
                    connection.Dispose();
                }
                
            }

            return (er, ds);
        }
        /// <summary>
        /// Eseguiquery prevenendo mysql injection
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        //public (Errore, SqlCommand) PreventInjection(SqlCommand command, Object obj)
        //{
        //    Errore er = null;
        //    try
        //    {
        //        foreach (object o in obj)
        //        {
        //            command.Parameters.AddWithValue($"@{o.GetType}", o);
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        er = new Errore(e);
        //    }
        //    return (er, command);
        //}

        public (Errore, int) QueryInsert(string query)
        {
            object risultato = 0;
            int id = 0;
            Errore er = null;
            SqlConnection connection = new SqlConnection(cnn);

            try
            {
                query += "; SELECT SCOPE_IDENTITY()";
                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();

                risultato = command.ExecuteScalar();
                
                risultato = (risultato == DBNull.Value) ? null : risultato;
                id = Convert.ToInt32(risultato);

            }
            catch (Exception ex)
            {
                er = new Errore(ex);
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                    connection.Dispose();
                }

            }

            return (er, id);
        }

        public (Errore, int) QueryEliminaById(string query)
        {
            DataSet ds = new DataSet();
            int nRigheModificate = -1;
            Errore er = null;
            SqlConnection connection = new SqlConnection(cnn);

            try
            {

                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();

                nRigheModificate = command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                er = new Errore(ex);
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                    connection.Dispose();
                }

            }

            return (er, nRigheModificate);
        }


    }
}
