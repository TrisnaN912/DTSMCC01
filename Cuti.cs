using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DTSMCC01
{
    public class Cuti
    {
        SqlConnection sqlConnection;
        string connectionString = "Data Source=NARUTO;Initial Catalog=DTSMCC01;User ID=Admin;Password=1234567890;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        void GetAllCuti()
        {
            sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandText = "select * from Cuti";


            try
            {
                sqlConnection.Open();
                using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                {
                    if (sqlDataReader.HasRows)
                    {
                        while (sqlDataReader.Read())
                        {
                            Console.WriteLine(sqlDataReader[0] + " - " + sqlDataReader[1] + " - " + sqlDataReader[2] + " - " + sqlDataReader[3] + " - " + sqlDataReader[4] + " - " + sqlDataReader[5]);
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

        void InsertCuti(Models.Cuti cuti)
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
                        "insert into Cuti " +
                        "(IdCuti, EmployeeId, IdJenisCuti, StartDate, EndDate, Status) " +
                        "VALUES (@IdCuti, @EmployeeId, @IdJenisCuti, @StartDate, @EndDate, @Status)";

                    SqlParameter sqlParameter1 = new SqlParameter();
                    sqlParameter1.ParameterName = "@IdCuti";
                    sqlParameter1.Value = cuti.IdCuti;

                    SqlParameter sqlParameter2 = new SqlParameter();
                    sqlParameter2.ParameterName = "@EmployeeId";
                    sqlParameter2.Value = cuti.EmployeeId;

                    SqlParameter sqlParameter3 = new SqlParameter();
                    sqlParameter2.ParameterName = "@IdJenisCuti";
                    sqlParameter2.Value = cuti.IdJenisCuti;

                    SqlParameter sqlParameter4 = new SqlParameter();
                    sqlParameter2.ParameterName = "@StartDate";
                    sqlParameter2.Value = cuti.StartDate;

                    SqlParameter sqlParameter5 = new SqlParameter();
                    sqlParameter2.ParameterName = "@EndDate";
                    sqlParameter2.Value = cuti.EndDate;

                    SqlParameter sqlParameter6 = new SqlParameter();
                    sqlParameter2.ParameterName = "@Status";
                    sqlParameter2.Value = cuti.Status;

                    sqlCommand.Parameters.Add(sqlParameter1);
                    sqlCommand.Parameters.Add(sqlParameter2);
                    sqlCommand.Parameters.Add(sqlParameter3);
                    sqlCommand.Parameters.Add(sqlParameter4);
                    sqlCommand.Parameters.Add(sqlParameter5);
                    sqlCommand.Parameters.Add(sqlParameter6);

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

        void UpdateCuti(Models.Cuti cuti)
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
                        "update Cuti " +
                        "set Status = @Status " +
                        "where IdCuti = @IdCuti";

                    SqlParameter sqlParameter1 = new SqlParameter();
                    sqlParameter1.ParameterName = "@IdCuti";
                    sqlParameter1.Value = cuti.IdCuti;

                    SqlParameter sqlParameter2 = new SqlParameter();
                    sqlParameter2.ParameterName = "@Status";
                    sqlParameter2.Value = cuti.Status;

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

        void DeleteCuti(Models.Cuti cuti)
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
                        "delete from Cuti " +
                        "where IdCuti = @IdCuti";

                    SqlParameter sqlParameter1 = new SqlParameter();
                    sqlParameter1.ParameterName = "@IdCuti";
                    sqlParameter1.Value = cuti.IdCuti;


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
