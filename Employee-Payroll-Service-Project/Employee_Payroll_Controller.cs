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
            EmployeePayroll model = new EmployeePayroll();

            try
            {
                SqlConnection con = new SqlConnection(@"data source=DESKTOP-4VPJFH9\SQLEXPRESS;initial catalog=EmployeePayrollService;integrated security=true");
                con.Open();

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

        // UC4: Update data in EmployeePayroll table

        public static void UpdateRecord()
        {
            EmployeePayroll model = new EmployeePayroll();

            try
            {
                SqlConnection con = new SqlConnection(@"data source=DESKTOP-4VPJFH9\SQLEXPRESS;initial catalog=EmployeePayrollService;integrated security=true");
                con.Open();

                Console.Write("To Edit Records Enter Your Name: ");
                model.Emp_Name = Console.ReadLine();

                while (true)
                {
                    string Query = String.Empty;
                    Console.WriteLine("\nSelect an option: ");
                    Console.WriteLine("1. Update Name");
                    Console.WriteLine("2. Update Phone Number");
                    Console.WriteLine("3. Update Gender");
                    Console.WriteLine("4. Update Start Date (yyyy-mm-dd)");
                    Console.WriteLine("5. Update Salary");
                    Console.WriteLine("0. Exit");
                    Console.Write("==> ");
                    int option = Convert.ToInt32(Console.ReadLine());

                    switch (option)
                    {
                        case 1:
                            Console.Write("Enter New Name: ");
                            model.Emp_Name = Console.ReadLine();
                            Query = "UPDATE EmployeePayroll SET Emp_Name = @Emp_Name WHERE Emp_Name= @Emp_Name;";
                            break;
                        case 2:
                            Console.Write("Enter New Phone Number: ");
                            model.Phone_Number = Console.ReadLine();
                            Query = "UPDATE EmployeePayroll SET Phone_Number = @Phone_Number WHERE Emp_Name= @Emp_Name;";
                            break;
                        case 3:
                            Console.Write("Enter New Gender: ");
                            model.Gender = Console.ReadLine();
                            Query = "UPDATE EmployeePayroll SET Gender = @Gender WHERE Emp_Name= @Emp_Name;";
                            break;
                        case 4:
                            Console.Write("Enter New Start Date (yyyy-mm-dd): ");
                            model.Start_Date = Convert.ToDateTime(Console.ReadLine());
                            Query = "UPDATE EmployeePayroll SET Start_Date = @Start_Date WHERE Emp_Name= @Emp_Name;";
                            break;
                        case 5:
                            Console.Write("Enter new salary: ");
                            model.Salary = decimal.Parse(Console.ReadLine());
                            Query = "UPDATE EmployeePayroll SET Salary = @Salary WHERE Emp_Name= @Emp_Name;";
                            break;
                        case 0:
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("\nEnter valid option.");
                            break;
                    }

                    SqlCommand cmd = new SqlCommand(Query, con);

                    cmd.Parameters.AddWithValue("@Emp_Name", model.Emp_Name);

                    switch (option)
                    {
                        case 1:
                            cmd.Parameters.AddWithValue("@Emp_Name", model.Emp_Name);
                            break;
                        case 2:
                            cmd.Parameters.AddWithValue("@Phone_Number", model.Phone_Number);
                            break;
                        case 3:
                            cmd.Parameters.AddWithValue("@Gender", model.Gender);
                            break;
                        case 4:
                            cmd.Parameters.AddWithValue("@Start_Date", model.Start_Date);
                            break;
                        case 5:
                            cmd.Parameters.AddWithValue("@Salary", model.Salary);
                            break;
                    }

                    int rowsAffected = cmd.ExecuteNonQuery();
                    Console.WriteLine("{0} rows affected.", rowsAffected);
                    Console.WriteLine("Record Updated Successfully.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
        }

        // UC5: Retrive All Data from EmployeePayroll table.
        public static void RetriveAllRecords()
        {
            EmployeePayroll model = new EmployeePayroll();
            try
            {
                SqlConnection con = new SqlConnection(@"data source=DESKTOP-4VPJFH9\SQLEXPRESS;initial catalog=EmployeePayrollService;integrated security=true");
                con.Open();

                string Query = "SELECT * FROM EmployeePayroll";

                SqlCommand cmd = new SqlCommand(Query, con);

                SqlDataReader sqlDataReader = cmd.ExecuteReader();

                if (sqlDataReader.HasRows)
                {
                    Console.WriteLine("\nRecords Retrived from Database: ");

                    while (sqlDataReader.Read())
                    {
                        model.Emp_ID = sqlDataReader.GetInt32(0);
                        model.Emp_Name = sqlDataReader.GetString(1);
                        model.Phone_Number = sqlDataReader.GetString(2);
                        model.Gender = sqlDataReader.GetString(3);
                        model.Start_Date = sqlDataReader.GetDateTime(4);
                        model.Salary = sqlDataReader.GetDecimal(5);

                        Console.WriteLine("Employee ID: " + model.Emp_Name);
                        Console.WriteLine("Employee Name: " + model.Emp_Name);
                        Console.WriteLine("Phone Number: " + model.Phone_Number);
                        Console.WriteLine("Gender: " + model.Gender);
                        Console.WriteLine("Start Date: " + model.Start_Date);
                        Console.WriteLine("Salary: " + model.Salary);
                        Console.WriteLine();
                    }
                }
                else
                {
                    Console.WriteLine("Record Not Found in EmployeePayroll Table");
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
