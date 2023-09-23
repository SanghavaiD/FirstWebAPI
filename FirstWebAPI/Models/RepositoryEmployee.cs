using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Extensions;
using System.Diagnostics.Contracts;

namespace FirstWebAPI.Models
{
    public class RepositoryEmployee
    {
        private NorthwindContext _context;
        public RepositoryEmployee(NorthwindContext context)
        {
            _context = context;
        }
        public List<Employee> GetEmployees()
        {
            return _context.Employees.ToList();
        }
        public int AddEmployees(Employee emp)
        {
            Employee? foundEmp = _context.Employees.Find(emp.EmployeeId);
            if (foundEmp != null)
            {
                throw new Exception("Failed to add Employess.Duplicate Id");
            }
            EntityState es = _context.Entry(emp).State;
            Console.WriteLine($"EntityState B4Add:{es.GetDisplayName()}");
            _context.Employees.Add(emp);
            es = _context.Entry(emp).State;
            Console.WriteLine($"EntityState AfterAdd:{es.GetDisplayName()}");
            int result = _context.SaveChanges();
            es = _context.Entry(emp).State;
            Console.WriteLine($"EntityState After SaveChanges:{es.GetDisplayName()}");
            return result;

            //_context.Employees.Add(emp);
            //_context.SaveChanges();
            //return emp;
        }
        public Employee FindEmployeeById(int id)
        {

            Employee employee = _context.Employees.Find(id);
            return employee;

        }
        public int UpdateEmployee(Employee updatedEmployee)
        {
            EntityState es = _context.Entry(updatedEmployee).State;
            Console.WriteLine($"EntityState B4Add:{es.GetDisplayName()}");
            _context.Employees.Add(updatedEmployee);
            es = _context.Entry(updatedEmployee).State;
            Console.WriteLine($"EntityState AfterAdd:{es.GetDisplayName()}");
            int result = _context.SaveChanges();
            es = _context.Entry(updatedEmployee).State;
            Console.WriteLine($"EntityState After SaveChanges:{es.GetDisplayName()}");
            return result;

            //_context.Employees.Update(updatedEmployee);
            //_context.SaveChanges();
            //return updatedEmployee;
        }
        public int DeleteEmployee(int id)
        {
            Employee empdelete = _context.Employees.Find(id);
            EntityState es = EntityState.Detached;
            int result = 0;
            if (empdelete != null)
            {
                es = _context.Entry(empdelete).State;
                Console.WriteLine($"EntityState before Delete:{es.GetDisplayName()}");
                _context.Employees.Remove(empdelete);//dbcontext.entity."add" used to attach
                es = _context.Entry(empdelete).State;
                Console.WriteLine($"EntityState After Delete:{es.GetDisplayName()}");
                result = _context.SaveChanges();
                es = _context.Entry(empdelete).State;
                Console.WriteLine($"EntityState After Save changes:{es.GetDisplayName()}");
            }
            return result;
        }
    }
}

