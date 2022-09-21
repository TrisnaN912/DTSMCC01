using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DTSMCC01
{
    public class Employee
    {
        SqlConnection sqlConnection;
        string connectionString = "Data Source=NARUTO;Initial Catalog=DTSMCC01;User ID=Admin;Password=1234567890;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        void GetAllEmployee()
        {
            sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandText = "select * from Employee";


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

        void InsertEmployee(Models.Employee employee)
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
                        "insert into Employee " +
                        "(EmployeeId, Name, Email) " +
                        "VALUES (@EmployeeId, @Name, @Email)";

                    SqlParameter sqlParameter1 = new SqlParameter();
                    sqlParameter1.ParameterName = "@EmployeeId";
                    sqlParameter1.Value = employee.EmployeeId;

                    SqlParameter sqlParameter2 = new SqlParameter();
                    sqlParameter2.ParameterName = "@Name";
                    sqlParameter2.Value = employee.Name;

                    SqlParameter sqlParameter3 = new SqlParameter();
                    sqlParameter3.ParameterName = "@Email";
                    sqlParameter3.Value = employee.Email;

                    sqlCommand.Parameters.Add(sqlParameter1);
                    sqlCommand.Parameters.Add(sqlParameter2);
                    sqlCommand.Parameters.Add(sqlParameter3);

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

        void UpdateEmployee(Models.Employee employee)
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
                        "update Employee " +
                        "set Name = @Name " +
                        "where EmployeeId = @EmployeeId";

                    SqlParameter sqlParameter1 = new SqlParameter();
                    sqlParameter1.ParameterName = "@EmployeeId";
                    sqlParameter1.Value = employee.EmployeeId;

                    SqlParameter sqlParameter2 = new SqlParameter();
                    sqlParameter2.ParameterName = "@Name";
                    sqlParameter2.Value = employee.Name;

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

        void DeleteEmployee(Models.Employee employee)
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
                        "delete from Employee " +
                        "where EmployeeId = @EmployeeId";

                    SqlParameter sqlParameter1 = new SqlParameter();
                    sqlParameter1.ParameterName = "@EmployeeId";
                    sqlParameter1.Value = employee.EmployeeId;


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
