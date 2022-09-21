using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DTSMCC01
{
    public class JenisCuti
    {
        SqlConnection sqlConnection;
        string connectionString = "Data Source=NARUTO;Initial Catalog=DTSMCC01;User ID=Admin;Password=1234567890;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        void GetAllJenisCuti()
        {
            sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandText = "select * from JenisCuti";


            try
            {
                sqlConnection.Open();
                using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                {
                    if (sqlDataReader.HasRows)
                    {
                        while (sqlDataReader.Read())
                        {
                            Console.WriteLine(sqlDataReader[0] + " - " + sqlDataReader[1]);
                        }
                    }
                    else
                    {
                        Console.WriteLine("No Data Found");
                    }
                    sqlDataReader.Close();
                }

                sqlConnection.Close();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.InnerException);
            }
        }

        void InsertJenisCuti(Models.JenisCuti jenis)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();

                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.Transaction = sqlTransaction;

                try
                {
                    sqlCommand.CommandText =
                        "insert into JenisCuti " +
                        "(IdJenisCuti, NamaJenisCuti) " +
                        "VALUES (@IdJenisCuti, @NamaJenisCuti)";

                    SqlParameter sqlParameter1 = new SqlParameter();
                    sqlParameter1.ParameterName = "@IdJenisCuti";
                    sqlParameter1.Value = jenis.IdJenisCuti;

                    SqlParameter sqlParameter2 = new SqlParameter();
                    sqlParameter2.ParameterName = "@NamaJenisCuti";
                    sqlParameter2.Value = jenis.NamaJenisCuti;

                    sqlCommand.Parameters.Add(sqlParameter1);
                    sqlCommand.Parameters.Add(sqlParameter2);

                    sqlCommand.ExecuteNonQuery();
                    sqlTransaction.Commit();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.InnerException);
                    try
                    {
                        sqlTransaction.Rollback();

                    }
                    catch (Exception exRollBack)
                    {
                        Console.WriteLine(exRollBack.Message);
                    }
                }
            }
        }

        void UpdateJenisCuti(Models.JenisCuti jenis)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();

                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.Transaction = sqlTransaction;

                try
                {
                    sqlCommand.CommandText =
                        "update JenisCuti " +
                        "set NamaJenisCuti = @NamaJenisCuti " +
                        "where IdJenisCuti = @IdJenisCuti";

                    SqlParameter sqlParameter1 = new SqlParameter();
                    sqlParameter1.ParameterName = "@IdJenisCuti";
                    sqlParameter1.Value = jenis.IdJenisCuti;

                    SqlParameter sqlParameter2 = new SqlParameter();
                    sqlParameter2.ParameterName = "@NamaJenisCuti";
                    sqlParameter2.Value = jenis.NamaJenisCuti;

                    sqlCommand.Parameters.Add(sqlParameter1);
                    sqlCommand.Parameters.Add(sqlParameter2);

                    sqlCommand.ExecuteNonQuery();
                    sqlTransaction.Commit();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.InnerException);
                    try
                    {
                        sqlTransaction.Rollback();

                    }
                    catch (Exception exRollBack)
                    {
                        Console.WriteLine(exRollBack.Message);
                    }
                }
            }
        }

        void DeleteJenisCuti(Models.JenisCuti jenis)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();

                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.Transaction = sqlTransaction;

                try
                {
                    sqlCommand.CommandText =
                        "delete from JenisCuti " +
                        "where IdJenisCuti = @IdJenisCuti";

                    SqlParameter sqlParameter1 = new SqlParameter();
                    sqlParameter1.ParameterName = "@IdJenisCuti";
                    sqlParameter1.Value = jenis.IdJenisCuti;


                    sqlCommand.Parameters.Add(sqlParameter1);

                    sqlCommand.ExecuteNonQuery();
                    sqlTransaction.Commit();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    try
                    {
                        sqlTransaction.Rollback();

                    }
                    catch (Exception exRollBack)
                    {
                        Console.WriteLine(exRollBack.Message);
                    }
                }

            }
        }
    }
}
