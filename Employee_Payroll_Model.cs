using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_Payroll_Service
{
    public class Employee_Payroll_Model
    {
        public int EmpId { get; set; }
        public string EmpName { get; set; }
        public long PhoneNumber { get; set; }
        public DateTime StartDate { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Department { get; set; }
        public float BasicPay { get; set; }
        public float Deduction { get; set; }
        public float TaxablePay { get; set; }
        public float IncomeTax { get; set; }
        public float NetPay { get; set; }
    }
}
