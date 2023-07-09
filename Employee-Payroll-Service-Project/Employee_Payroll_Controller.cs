using System.Data.SqlClient;

namespace Employee_Payroll_Service
{
    public class Employee_Payroll_Controller
    {
        // UC1: Create Database EmployeePayrollService using ADO.net
        public static void CreateDatabase()
        {
            try
            {
                SqlConnection con = new SqlConnection(@"data source=DESKTOP-4VPJFH9\SQLEXPRESS;initial catalog=master;integrated security=true");
                con.Open();

                string Query = "CREATE DATABASE EmployeePayrollService;";
                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.ExecuteNonQuery();
                Console.WriteLine("Database Created Successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        // UC2: Create Table Employee_Payroll using ADO.net
        public static void CreateTable()
        {
            try
            {
                SqlConnection con = new SqlConnection(@"data source=DESKTOP-4VPJFH9\SQLEXPRESS;initial catalog=EmployeePayrollService;integrated security=true");
                con.Open();

                string Query = "CREATE TABLE EmployeePayroll(" +
                    "Emp_ID INT IDENTITY(1,1) PRIMARY KEY," +
                    "Emp_Name NVARCHAR(255)," +
                    "Phone_Number NVARCHAR(20)," +
                    "Gender VARCHAR(10)," +
                    "Start_Date DATE," +
                    "Salary DECIMAL(10,2));";

                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.ExecuteNonQuery();
                Console.WriteLine("Table Created Successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

    }
}
