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

        // UC4: Update data in Employee_Payroll table

        public static void UpdateRecord()
        {

            try
            {
                SqlConnection con = new SqlConnection(@"data source=DESKTOP-4VPJFH9\SQLEXPRESS;initial catalog=EmployeePayrollService;integrated security=true");
                con.Open();

                Employee_Payroll_Model model = new Employee_Payroll_Model();

                Console.Write("To Edit Records Enter Your Name: ");
                string name = Console.ReadLine();

                while (true)
                {
                    string Query = String.Empty;
                    Console.WriteLine("\nSelect an option: ");
                    Console.WriteLine("1. Update Name");
                    Console.WriteLine("2. Update Phone Number: ");
                    Console.WriteLine("3. Update Gender");
                    Console.WriteLine("4. Update Start Date (yyyy-mm-dd): ");
                    Console.WriteLine("5. Update Address");
                    Console.WriteLine("6. Update City");
                    Console.WriteLine("7. Update State");
                    Console.WriteLine("8. Update Department");
                    Console.WriteLine("9. Update Basic Pay");
                    Console.WriteLine("10. Update Deduction");
                    Console.WriteLine("11. Update Taxable Pay");
                    Console.WriteLine("12. Update Income Tax");
                    Console.WriteLine("0. Exit");
                    Console.Write("==> ");
                    int option = Convert.ToInt32(Console.ReadLine());

                    switch (option)
                    {
                        case 1:
                            Console.Write("Enter New Name: ");
                            string Name = Console.ReadLine();
                            Query = "UPDATE Employee_Payroll SET Emp_Name='" + Name + "' WHERE Emp_Name= '" + name + "';";
                            break;
                        case 2:
                            Console.Write("Enter New Phone Number: ");
                            long PhoneNumber = Convert.ToInt64(Console.ReadLine());
                            Query = "UPDATE Employee_Payroll SET Phone_Number='" + PhoneNumber + "' WHERE Emp_Name= '" + name + "';";
                            break;
                        case 3:
                            Console.Write("Enter New Gender ('M' = Male, 'F' = Female): ");
                            string Gender = Console.ReadLine();
                            Query = "UPDATE Employee_Payroll SET Gender='" + Gender + "' WHERE Emp_Name= '" + name + "';";
                            break;
                        case 4:
                            Console.Write("Enter New Start Date: ");
                            DateTime StartDate = Convert.ToDateTime(Console.ReadLine());
                            Query = "UPDATE Employee_Payroll SET Start_Date='" + StartDate + "' WHERE Emp_Name= '" + name + "';";
                            break;
                        case 5:
                            Console.Write("Enter New Address: ");
                            string Address = Console.ReadLine();
                            Query = "UPDATE Employee_Payroll SET Address='" + Address + "' WHERE Emp_Name= '" + name + "';";
                            break;
                        case 6:
                            Console.Write("Enter New City: ");
                            string City = Console.ReadLine();
                            Query = "UPDATE Employee_Payroll SET City='" + City + "' WHERE Emp_Name= '" + name + "';";
                            break;
                        case 7:
                            Console.Write("Enter New State: ");
                            string State = Console.ReadLine();
                            Query = "UPDATE Employee_Payroll SET State='" + State + "' WHERE Emp_Name= '" + name + "';";
                            break;
                        
                        case 8:
                            Console.Write("Enter New Department: ");
                            string Department = Console.ReadLine();
                            Query = "UPDATE Employee_Payroll SET Department='" + Department + "' WHERE Emp_Name= '" + name + "';";
                            break;
                        case 9:
                            Console.Write("Enter New Basic Pay: ");
                            double BasicPay = Convert.ToSingle(Console.ReadLine());
                            Query = "UPDATE Employee_Payroll SET Basic_Pay='" + BasicPay + "' WHERE Emp_Name= '" + name + "';";
                            break;
                        case 10:
                            Console.Write("Enter New Deduction: ");
                            double Deduction = Convert.ToSingle(Console.ReadLine());
                            Query = "UPDATE Employee_Payroll SET Deduction='" + Deduction + "' WHERE Emp_Name= '" + name + "';";
                            break;
                        case 11:
                            Console.Write("Enter New Taxable Pay: ");
                            double TaxablePay = Convert.ToSingle(Console.ReadLine());
                            Query = "UPDATE Employee_Payroll SET Taxable_Pay='" + TaxablePay + "' WHERE Emp_Name= '" + name + "';";
                            break;
                        case 12:
                            Console.Write("Enter New Income Tax: ");
                            double IncomeTax = Convert.ToSingle(Console.ReadLine());
                            Query = "UPDATE Employee_Payroll SET Income_Tax='" + IncomeTax + "' WHERE Emp_Name= '" + name + "';";
                            break;
                        case 0:
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("\nEnter valid option.");
                            break;
                    }

                    SqlCommand cmd = new SqlCommand(Query, con);
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Record Updated Successfully.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        // UC5: Retrive All Data from Employee_Payroll table.
        public static void RetriveAllRecords()
        {
            try
            {
                SqlConnection con = new SqlConnection(@"data source=DESKTOP-4VPJFH9\SQLEXPRESS;initial catalog=EmployeePayrollService;integrated security=true");
                con.Open();

                Employee_Payroll_Model model = new Employee_Payroll_Model();

                string Query = "SELECT * FROM Employee_Payroll";

                SqlCommand cmd = new SqlCommand(Query, con);

                SqlDataReader sqlDataReader = cmd.ExecuteReader();

                if (sqlDataReader.HasRows)
                {
                    Console.WriteLine("\nRecords Retrived from Database: ");

                    while (sqlDataReader.Read())
                    {
                        model.EmpId = sqlDataReader.GetInt32(0);
                        model.EmpName = sqlDataReader.GetString(1);
                        model.PhoneNumber = sqlDataReader.GetInt64(2);
                        model.Gender = sqlDataReader.GetString(3);
                        model.StartDate = sqlDataReader.GetDateTime(4);
                        model.Address = sqlDataReader.GetString(5);
                        model.City = sqlDataReader.GetString(6);
                        model.State = sqlDataReader.GetString(7);
                        model.Department = sqlDataReader.GetString(8);
                        model.BasicPay = sqlDataReader.GetDouble(9);
                        model.Deduction = sqlDataReader.GetDouble(10);
                        model.TaxablePay = sqlDataReader.GetDouble(11);
                        model.IncomeTax = sqlDataReader.GetDouble(12);
                        model.NetPay = sqlDataReader.GetDouble(13);

                        Console.WriteLine("EmpID: " + model.EmpId);
                        Console.WriteLine("EmpName: " + model.EmpName);
                        Console.WriteLine("Phone Number: " + model.PhoneNumber);
                        Console.WriteLine("Gender: " + model.Gender);
                        Console.WriteLine("Start Date: " + model.StartDate);
                        Console.WriteLine("Address: " + model.Address);
                        Console.WriteLine("City: " + model.City);
                        Console.WriteLine("State: " + model.State);
                        Console.WriteLine("Department: " + model.Department);
                        Console.WriteLine("Basic Pay: " + model.BasicPay);
                        Console.WriteLine("Deduction: " + model.Deduction);
                        Console.WriteLine("Taxable Pay: " + model.TaxablePay);
                        Console.WriteLine("Income Tax: " + model.IncomeTax);
                        Console.WriteLine("Net Pay: " + model.NetPay);
                        Console.WriteLine();

                    }

                }
                else
                {
                    Console.WriteLine("Record Not Found in Employee_Payroll Table");
                }

                sqlDataReader.Close();
                con.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        // UC6: Retrive All Data from Employee_Payroll table.
        public static void RetriveRecordsByRangeOfDate()
        {

            try
            {
                SqlConnection con = new SqlConnection(@"data source=DESKTOP-4VPJFH9\SQLEXPRESS;initial catalog=EmployeePayrollService;integrated security=true");
                con.Open();

                Employee_Payroll_Model model = new Employee_Payroll_Model();

                Console.WriteLine("Enter Staring Date: ");
                DateTime StartingDate = Convert.ToDateTime(Console.ReadLine());
                Console.WriteLine("Enter Ending Date: ");
                DateTime EndingDate = Convert.ToDateTime(Console.ReadLine());

                string Query = "SELECT * FROM Employee_Payroll WHERE Start_Date BETWEEN '" + StartingDate + "' AND '" + EndingDate + "';";

                SqlCommand cmd = new SqlCommand(Query, con);

                SqlDataReader sqlDataReader = cmd.ExecuteReader();

                if (sqlDataReader.HasRows)
                {
                    Console.WriteLine("\nRecords Retrived from Database by date of ranges from {0} to {1}: ", StartingDate, EndingDate);

                    while (sqlDataReader.Read())
                    {
                        model.EmpId = sqlDataReader.GetInt32(0);
                        model.EmpName = sqlDataReader.GetString(1);
                        model.PhoneNumber = sqlDataReader.GetInt64(2);
                        model.Gender = sqlDataReader.GetString(3);
                        model.StartDate = sqlDataReader.GetDateTime(4);
                        model.Address = sqlDataReader.GetString(5);
                        model.City = sqlDataReader.GetString(6);
                        model.State = sqlDataReader.GetString(7);
                        model.Department = sqlDataReader.GetString(8);
                        model.BasicPay = sqlDataReader.GetDouble(9);
                        model.Deduction = sqlDataReader.GetDouble(10);
                        model.TaxablePay = sqlDataReader.GetDouble(11);
                        model.IncomeTax = sqlDataReader.GetDouble(12);
                        model.NetPay = sqlDataReader.GetDouble(13);

                        Console.WriteLine("EmpID: " + model.EmpId);
                        Console.WriteLine("EmpName: " + model.EmpName);
                        Console.WriteLine("Phone Number: " + model.PhoneNumber);
                        Console.WriteLine("Gender: " + model.Gender);
                        Console.WriteLine("Start Date: " + model.StartDate);
                        Console.WriteLine("Address: " + model.Address);
                        Console.WriteLine("City: " + model.City);
                        Console.WriteLine("State: " + model.State);
                        Console.WriteLine("Department: " + model.Department);
                        Console.WriteLine("Basic Pay: " + model.BasicPay);
                        Console.WriteLine("Deduction: " + model.Deduction);
                        Console.WriteLine("Taxable Pay: " + model.TaxablePay);
                        Console.WriteLine("Income Tax: " + model.IncomeTax);
                        Console.WriteLine("Net Pay: " + model.NetPay);
                        Console.WriteLine();

                    }

                }
                else
                {
                    Console.WriteLine("Record Not Found in Employee_Payroll Table");
                }

                sqlDataReader.Close();
                con.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

    }
}
