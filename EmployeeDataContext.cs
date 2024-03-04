using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace EmployeeLINQ
{
    [Database(Name = "ado_db")]
    public class EmployeeDataContext : DataContext
    {
        public Table<Employee> Employees;

        public EmployeeDataContext(string connection) : base(connection)
        {
        }
    }
}
