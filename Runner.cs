using System;
using System.Linq;

namespace EmployeeLINQ
{
    public class Runner
    {
        static void Main(string[] args)
        {
            string connectionString = "Data Source=DESKTOP-9TNLIB5\\SQLEXPRESS;Initial Catalog=ado_db;Integrated Security=true;";



            bool state = true;
            while (state)
            {
                Console.WriteLine("1. Insert Data");
                Console.WriteLine("2. Delete Data");
                Console.WriteLine("3. Update Data");
                Console.WriteLine("4. Print Data");
                Console.WriteLine("5. Exit");

                int option = int.Parse(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        Employee employee = new Employee();

                        Console.WriteLine("Enter name");
                        employee.EmployeeName = Console.ReadLine();

                        Console.WriteLine("Enter gender");
                        employee.EmployeeGender = Console.ReadLine();

                        Console.WriteLine("Enter age");
                        employee.EmployeeAge = int.Parse(Console.ReadLine());

                        Console.WriteLine("Enter salary");
                        employee.EmployeeSalary = int.Parse(Console.ReadLine());

                        Console.WriteLine("Enter city");
                        employee.EmployeeCity = Console.ReadLine();

                        if (InsertData(employee, connectionString))
                            Console.WriteLine("Insertion done successfully.");
                        else
                            Console.WriteLine("Insertion failed");

                        break;

                    case 2:
                        Console.WriteLine("Enter ID of Employee to delete");
                        int EmployeeID = int.Parse(Console.ReadLine());

                        if (DeleteData(EmployeeID, connectionString))
                            Console.WriteLine("Deletion done successfully.");
                        else
                            Console.WriteLine("Deletion failed");

                        break;

                    case 3:
                        Console.WriteLine("Enter ID of Employee to update");
                        EmployeeID = int.Parse(Console.ReadLine());

                        employee = new Employee();

                        Console.WriteLine("Enter name");
                        employee.EmployeeName = Console.ReadLine();

                        Console.WriteLine("Enter gender");
                        employee.EmployeeGender = Console.ReadLine();

                        Console.WriteLine("Enter age");
                        employee.EmployeeAge = int.Parse(Console.ReadLine());

                        Console.WriteLine("Enter salary");
                        employee.EmployeeSalary = int.Parse(Console.ReadLine());

                        Console.WriteLine("Enter city");
                        employee.EmployeeCity = Console.ReadLine();

                        employee.EmployeeID = EmployeeID;

                        if (UpdateData(employee, connectionString))
                            Console.WriteLine("Updation done successfully.");
                        else
                            Console.WriteLine("Updation failed");

                        break;

                    case 4:
                        DisplayData(connectionString);
                        break;

                    default:
                        state = false;
                        break;
                }

            }
        }


        static bool InsertData(Employee employee, string connectionString)
        {
            try
            {
                EmployeeDataContext db = new EmployeeDataContext(connectionString);
                db.Employees.InsertOnSubmit(employee);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }


        static bool DeleteData(int EmployeeID, string connectionString)
        {
            try
            {
                EmployeeDataContext db = new EmployeeDataContext(connectionString);
                var employee = db.Employees.FirstOrDefault(e => e.EmployeeID == EmployeeID);
                if (employee != null)
                {
                    db.Employees.DeleteOnSubmit(employee);
                    db.SubmitChanges();
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }

        }

        static bool UpdateData(Employee updatedEmployee, string connectionString)
        {
            try
            {

                EmployeeDataContext db = new EmployeeDataContext(connectionString);
                var employee = db.Employees.FirstOrDefault(e => e.EmployeeID == updatedEmployee.EmployeeID);
                if (employee != null)
                {
                    employee.EmployeeName = updatedEmployee.EmployeeName;
                    employee.EmployeeGender = updatedEmployee.EmployeeGender;
                    employee.EmployeeAge = updatedEmployee.EmployeeAge;
                    employee.EmployeeSalary = updatedEmployee.EmployeeSalary;
                    employee.EmployeeCity = updatedEmployee.EmployeeCity;
                    db.SubmitChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        static void DisplayData(string connectionString)
        {
            try
            {
                EmployeeDataContext db = new EmployeeDataContext(connectionString);

                // Query all employees
                var query = from emp in db.Employees
                            select emp;

                Console.WriteLine("EmployeeID\tName\tGender\tAge\tSalary\tCity");

                foreach (var employee in query)
                {
                    Console.WriteLine($"{employee.EmployeeID}\t\t{employee.EmployeeName}\t{employee.EmployeeGender}\t{employee.EmployeeAge}\t{employee.EmployeeSalary}\t{employee.EmployeeCity}");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

    }
}


