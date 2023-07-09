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

        // UC3: Insert records in EmployeePayroll table
        public static void InsertRecord()
        {
            try
            {
                SqlConnection con = new SqlConnection(@"data source=DESKTOP-4VPJFH9\SQLEXPRESS;initial catalog=EmployeePayrollService;integrated security=true");
                con.Open();

                EmployeePayroll model = new EmployeePayroll();

                Console.WriteLine("Enter Employee Details: \n");
                Console.Write("Enter Name: ");
                model.Emp_Name = Console.ReadLine();

                Console.Write("Enter Phone Number: ");
                model.Phone_Number = Console.ReadLine();

                Console.Write("Enter Gender: ");
                model.Gender = Console.ReadLine();

                Console.Write("Enter Start Date in format (yyyy-MM-dd):");
                model.Start_Date = Convert.ToDateTime(Console.ReadLine());

                Console.Write("Enter Salary: ");
                model.Salary = decimal.Parse(Console.ReadLine());

                string Query = "INSERT INTO EmployeePayroll (Emp_Name, Phone_Number, Gender, Start_Date, Salary) VALUES " +
                    "(@Emp_Name, @Phone_Number, @Gender, @Start_Date, @Salary)";

                SqlCommand cmd = new SqlCommand(Query, con);

                cmd.Parameters.AddWithValue("@Emp_Name", model.Emp_Name);
                cmd.Parameters.AddWithValue("@Phone_Number", model.Phone_Number);
                cmd.Parameters.AddWithValue("@Gender", model.Gender);
                cmd.Parameters.AddWithValue("@Start_Date", model.Start_Date);
                cmd.Parameters.AddWithValue("@Salary", model.Salary);

                int rowsAffected = cmd.ExecuteNonQuery();
                Console.WriteLine("{0} rows are inserted.", rowsAffected);
                Console.WriteLine("Record Inserted Successfully.");
                con.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

    }
}
