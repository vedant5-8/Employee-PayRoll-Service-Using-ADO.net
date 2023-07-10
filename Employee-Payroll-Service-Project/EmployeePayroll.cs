
namespace Employee_Payroll_Service
{
    public class EmployeePayroll
    {
        public int Emp_ID { get; set; }
        public string Emp_Name { get; set; }
        public string Phone_Number { get; set; }
        public string Gender { get; set; }
        public DateTime Start_Date { get; set; }
        public decimal Salary { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public decimal Deduction { get; set; }
        public decimal Taxable_Pay { get; set; }
        public decimal Income_Tax { get; set; }
        public decimal Net_Pay { get; set; }
    }
}
