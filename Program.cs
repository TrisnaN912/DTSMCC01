using DTSMCC01.Models;
using System;
using System.Data.SqlClient;

namespace DTSMCC01
{
    public class Program
    {
        SqlConnection sqlConnection;
        string connectionString = "Data Source=NARUTO;Initial Catalog=DTSMCC01;User ID=Admin;Password=1234567890;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        static void Main(string[] args)
        {
            Program program = new Program();


            /*Employee employee = new Employee()
            {
                EmployeeId = 1,
                Name = "Afrika",
                Email = "tri@gmail.com"

            };
            program.InsertEmployee(employee);

            Employee employee1 = new Employee()
            {
                EmployeeId = 1,
                Name = "Mawar"
            };
            program.UpdateEmployee(employee);

            Employee employee2 = new Employee()
            {
                EmployeeId = 1
            };
            program.DeleteEmployee(employee);
            program.GetAllEmployee();*/

            /*JenisCuti jenis = new JenisCuti()
            {
                IdJenisCuti = 1,
                NamaJenisCuti = "Melahirkan"

            };
            program.InsertJenisCuti(jenis);

            JenisCuti jenis1 = new JenisCuti()
            {
                IdJenisCuti = 1,
                NamaJenisCuti = "Liburan"
            };
            program.UpdateJenisCuti(jenis);

            JenisCuti jenis2 = new JenisCuti()
            {
                IdJenisCuti = 1
            };
            program.DeleteJenisCuti(jenis);
            program.GetAllJenisCuti();*/

            /*Cuti cuti = new Cuti()
            {
                IdCuti = 2,
                EmployeeId = 1,
                IdJenisCuti = 1,
                StartDate = "04-09-2022",
                EndDate = "21-09-2022",
                Status = "Aktif"

            };
            program.InsertCuti(cuti);

            Cuti cuti1 = new Cuti()
            {
                IdCuti = 2,
                Status = "Non-Aktif"
            };
            program.UpdateCuti(cuti);

            Cuti cuti2 = new Cuti()
            {
                IdCuti = 2
            };
            program.DeleteJenisCuti(jenis);
            program.GetAllJenisCuti();*/

            /*Konfirmasi konfirmasi = new Konfirmasi()
            {
                IdCuti = 1,
                Status = "Belum Konfirmasi"

            };
            program.InsertKonfirmasi(konfirmasi);

            Konfirmasi konfirmasi = new Konfirmasi()
            {
                IdKonfirmasi = 1,
                Status = "Decline"
            };
            program.UpdateKonfirmasi(konfirmasi);

            Konfirmasi konfirmasi = new Konfirmasi()
            {
                IdKonfirmasi = 1
            };
            program.DeleteJenisCuti(jenis);
            program.GetAllJenisCuti();*/

        }

    }

    
}