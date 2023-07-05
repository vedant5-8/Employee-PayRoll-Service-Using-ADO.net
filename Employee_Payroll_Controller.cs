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

                string Query = "CREATE TABLE Employee_Payroll(" +
                    "Emp_Id INT IDENTITY(1,1) PRIMARY KEY," +
                    "Emp_Name VARCHAR(50)," +
                    "Phone_Number BIGINT," +
                    "Start_Date date," +
                    "Address VARCHAR(200)," +
                    "City VARCHAR(100)," +
                    "State VARCHAR(100)," +
                    "Department VARCHAR(100)," +
                    "Basic_Pay FLOAT," +
                    "Deduction FLOAT," +
                    "Taxable_Pay FLOAT," +
                    "Income_Tax FLOAT," +
                    "Net_Pay AS (Basic_Pay - Deduction - Income_Tax));";

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
