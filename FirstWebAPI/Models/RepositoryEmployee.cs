using Microsoft.Data.SqlClient;
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
            return _context.Employees.ToList() ;
        }
        public Employee AddEmployees(Employee emp)
        {

            _context.Employees.Add(emp);
            _context.SaveChanges();
            return emp;
        }
        public Employee FindEmployeeById(int id)
        {
            Employee employee = _context.Employees.Find(id);
            return employee;
        }
        public Employee UpdateEmployee(Employee updatedEmployee)
        {

            _context.Employees.Update(updatedEmployee);
            _context.SaveChanges();
            return updatedEmployee;
        }
        public void DeleteEmployee(int employeeId)
        {
            var employeeToDelete = _context.Employees.Find(employeeId);



            if (employeeToDelete != null)
            {
                _context.Employees.Remove(employeeToDelete);
                _context.SaveChanges();
            }
            else
            {
                Console.WriteLine("Employee not exists");
            }
        }
    }
}
