using System.Data.SqlClient;
using System.Reflection;
using System.Reflection.PortableExecutable;

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
                    "Gender VARCHAR(20)," +
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

        // UC3: Insert data in Employee_Payroll table

        public static void InsertRecord()
        {
            try
            {
                SqlConnection con = new SqlConnection(@"data source=DESKTOP-4VPJFH9\SQLEXPRESS;initial catalog=EmployeePayrollService;integrated security=true");
                con.Open();

                Employee_Payroll_Model model = new Employee_Payroll_Model();

                Console.Write("Enter Name: ");
                model.EmpName = Console.ReadLine();

                Console.Write("Enter Phone Number: ");
                model.PhoneNumber = Convert.ToInt64(Console.ReadLine());

                Console.Write("Enter Gender: ");
                model.Gender = Console.ReadLine();

                Console.Write("Enter Start Date in format (yyyy-MM-dd):");
                model.StartDate = Convert.ToDateTime(Console.ReadLine());

                Console.Write("Enter Address: ");
                model.Address = Console.ReadLine();

                Console.Write("Enter City: ");
                model.City = Console.ReadLine();

                Console.Write("Enter State: ");
                model.State = Console.ReadLine();

                Console.Write("Enter Department: ");
                model.Department = Console.ReadLine();

                Console.Write("Enter Basic Pay: ");
                model.BasicPay = Convert.ToSingle(Console.ReadLine());

                Console.Write("Enter Deduction: ");
                model.Deduction = Convert.ToSingle(Console.ReadLine());

                Console.Write("Enter Taxable Pay: ");
                model.TaxablePay = Convert.ToSingle(Console.ReadLine());

                Console.Write("Enter Income Tax: ");
                model.IncomeTax = Convert.ToSingle(Console.ReadLine());

                String Query = "INSERT INTO Employee_Payroll VALUES " +
                    "(@Emp_Name, @Phone_Number, @Gender, @Start_Date, @Address, @City, @State, @Department, @Basic_Pay, @Deduction, @Taxable_Pay, @Income_Tax)";

                SqlCommand cmd = new SqlCommand(Query, con);

                cmd.Parameters.AddWithValue("@Emp_Name", model.EmpName);
                cmd.Parameters.AddWithValue("@Phone_Number", model.PhoneNumber);
                cmd.Parameters.AddWithValue("@Gender", model.Gender);
                cmd.Parameters.AddWithValue("@Start_Date", model.StartDate);
                cmd.Parameters.AddWithValue("@Address", model.Address);
                cmd.Parameters.AddWithValue("@City", model.City);
                cmd.Parameters.AddWithValue("@State", model.State);
                cmd.Parameters.AddWithValue("@Department", model.Department);
                cmd.Parameters.AddWithValue("@Basic_Pay", model.BasicPay);
                cmd.Parameters.AddWithValue("@Deduction", model.Deduction);
                cmd.Parameters.AddWithValue("@Taxable_Pay", model.TaxablePay);
                cmd.Parameters.AddWithValue("@Income_Tax", model.IncomeTax);

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
