
using Employee_Payroll_Service;

// Employee_Payroll_Controller.CreateDatabase();

// Employee_Payroll_Controller.CreateTable();

// Employee_Payroll_Controller.Alter_Table_Address_City_Country();

// Employee_Payroll_Controller.Alter_Table_Payroll();

// Employee_Payroll_Controller.CreateTableDepartment();

// Employee_Payroll_Controller.AlterEmployeePayrollWithDeptID();


while (true)
{
    Console.WriteLine("Select an Option: ");
    Console.WriteLine("1. Insert Employee Payroll Records");
    Console.WriteLine("2. Insert Department Records");
    Console.WriteLine("3. Update Employee Payroll Records");
    Console.WriteLine("4. Retrieve All Employee Payroll Records");
    Console.WriteLine("5. Delete record by Name");
    Console.WriteLine("6. Retrieve All Records by Range of Dates");
    Console.WriteLine("7. Aggregate Queries");
    Console.WriteLine("8. Retrieve All Department Records");
    Console.WriteLine("0. Exit");
    Console.WriteLine("==>");
    int option = Convert.ToInt32(Console.ReadLine());

    switch (option)
    {
        case 1:
            Employee_Payroll_Controller.InsertRecord();
            break;
        case 2:
            Employee_Payroll_Controller.InsertDepartmentRecord();
            break;
        case 3:
            Employee_Payroll_Controller.UpdateRecord();
            break;
        case 4:
            Employee_Payroll_Controller.RetriveAllRecords();
            break;
        case 5:
            Employee_Payroll_Controller.DeleteRecord();
            break;
        case 6:
            Employee_Payroll_Controller.RetriveRecordsByRangeOfDate();
            break;
        case 7:
            Employee_Payroll_Controller.AggregateQueries();
            break;
        case 8:
            Employee_Payroll_Controller.RetriveAllDepartmentRecords();
            break;
        case 0:
            Environment.Exit(0);
            break;
        default:
            Console.WriteLine("\nEnter valid option.");
            break;
    }
}
