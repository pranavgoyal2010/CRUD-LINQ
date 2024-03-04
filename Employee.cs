using System.Data.Linq.Mapping;

namespace EmployeeLINQ
{
    [Table(Name = "Employee1")]
    public class Employee
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int EmployeeID { get; set; }

        [Column]
        public string EmployeeName { get; set; }

        [Column]
        public string EmployeeGender { get; set; }

        [Column]
        public int EmployeeAge { get; set; }

        [Column]
        public int EmployeeSalary { get; set; }

        [Column]
        public string EmployeeCity { get; set; }

    }
}
