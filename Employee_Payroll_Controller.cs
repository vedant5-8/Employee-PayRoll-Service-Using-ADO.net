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
                    "Phone BIGINT," +
                    "Address VARCHAR(200)," +
                    "Department VARCHAR(100)," +
                    "Deduction INT," +
                    "Taxable_Pay INT," +
                    "Income_Tax INT," +
                    "Net_Pay INT," +
                    ");";
                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.ExecuteNonQuery();
                Console.WriteLine("Table Created Successfully.");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        // UC 3: Insert new records using ADO.net

        public static void InsertRecords()
        {
            try
            {
                SqlConnection con = new SqlConnection(@"data source=DESKTOP-4VPJFH9\SQLEXPRESS;initial catalog=EmployeePayrollService;integrated security=true");
                Employee_Payroll_Model model = new Employee_Payroll_Model();
                Console.WriteLine("Enter Name: ");
                model.Name = Console.ReadLine();
                Console.WriteLine("Enter Salary: ");
                model.Salary = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Start Date in given format (yyyy-MM-dd):");
                model.StartDate = Convert.ToDateTime(Console.ReadLine());
                Console.WriteLine("Enter Gender: ");
                model.Gender = Console.ReadLine();
                Console.WriteLine("Enter Phone: ");
                model.Phone = Convert.ToInt64(Console.ReadLine());
                Console.WriteLine("Enter Address: ");
                model.Address = Console.ReadLine();
                Console.WriteLine("Enter Department: ");
                model.Department = Console.ReadLine();
                Console.WriteLine("Enter Deduction: ");
                model.Deduction = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Taxable pay: ");
                model.Taxable_Pay = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Income Tax: ");
                model.Income_Tax = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Net Pay: ");
                model.Net_Pay = Convert.ToInt32(Console.ReadLine());
                con.Open();

                string Query = "INSERT INTO Employee_Payroll VALUES (" +
                    "'" + model.Name + "', " +
                    "'" + model.Salary + "'," +
                    "'" + model.StartDate + "'," +
                    "'" + model.Gender + "'," +
                    "'" + model.Phone + "'," +
                    "'" + model.Address + "'," +
                    "'" + model.Department + "'," +
                    "'" + model.Deduction + "'," +
                    "'" + model.Taxable_Pay + "'," +
                    "'" + model.Income_Tax + "'," +
                    "'" + model.Net_Pay + "');";

                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.ExecuteNonQuery();
                Console.WriteLine("Record Inserted Successfully.");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

    }
}
