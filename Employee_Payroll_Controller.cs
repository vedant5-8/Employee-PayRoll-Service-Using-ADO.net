using System.Data.SqlClient;

namespace Employee_Payroll_Service
{
    public class Employee_Payroll_Controller
    {
        // UC1: Create Databse EmployeePayrollService using ADO.net
        
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
                    "Name VARCHAR(50)," +
                    "Salary int," +
                    "StartDate date," +
                    "Gender VARCHAR(200)," +
                    "Phone INT," +
                    "Address VARCHAR(200)," +
                    "Department VARCHAR(100)," +
                    "Deduction INT," +
                    "Taxable_Pay INT," +
                    "Income_Tax INT," +
                    "Net_Pay INT," +
                    ")";
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
