using DTSMCC01.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DTSMCC01
{
    public class Konfirmasi
    {
        SqlConnection sqlConnection;
        string connectionString = "Data Source=NARUTO;Initial Catalog=DTSMCC01;User ID=Admin;Password=1234567890;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        void GetAllKonfirmasi()
        {
            sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandText = "select * from Konfirmasi";


            try
            {
                sqlConnection.Open();
                using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                {
                    if (sqlDataReader.HasRows)
                    {
                        while (sqlDataReader.Read())
                        {
                            Console.WriteLine(sqlDataReader[0] + " - " + sqlDataReader[1] + " - " + sqlDataReader[2]);
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

        void InsertKonfirmasi(Models.Konfirmasi konfirmasi)
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
                        "insert into Konfirmasi " +
                        "(IdCuti, Status) " +
                        "VALUES (@IdCuti, @Status)";

                    SqlParameter sqlParameter1 = new SqlParameter();
                    sqlParameter1.ParameterName = "@IdCuti";
                    sqlParameter1.Value = konfirmasi.IdCuti;

                    SqlParameter sqlParameter2 = new SqlParameter();
                    sqlParameter2.ParameterName = "@Status";
                    sqlParameter2.Value = konfirmasi.Status;

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

        void UpdateKonfirmasi(Models.Konfirmasi konfirmasi)
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
                        "update Konfirmasi " +
                        "set Status = @Status " +
                        "where IdKonfirmasi = @IdKonfirmasi";

                    SqlParameter sqlParameter1 = new SqlParameter();
                    sqlParameter1.ParameterName = "@IdKonfirmasi";
                    sqlParameter1.Value = konfirmasi.IdKonfirmasi;

                    SqlParameter sqlParameter2 = new SqlParameter();
                    sqlParameter2.ParameterName = "@Status";
                    sqlParameter2.Value = konfirmasi.Status;

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

        void DeleteKonfirmasi(Models.Konfirmasi konfirmasi)
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
                        "delete from Konfirmasi " +
                        "where IdKonfirmasi = @IdKonfirmasi";

                    SqlParameter sqlParameter1 = new SqlParameter();
                    sqlParameter1.ParameterName = "@IdKonfirmasi";
                    sqlParameter1.Value = konfirmasi.IdKonfirmasi;


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