
namespace Employee_Payroll_Service
{
    public class Employee_Payroll_Model
    {
        public int EmpId { get; set; }
        public string EmpName { get; set; }
        public long PhoneNumber { get; set; }
        public string Gender { get; set; }
        public DateTime StartDate { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Department { get; set; }
        public double BasicPay { get; set; }
        public double Deduction { get; set; }
        public double TaxablePay { get; set; }
        public double IncomeTax { get; set; }
        public double NetPay { get; set; }
    }
}
