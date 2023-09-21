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

    }
}
