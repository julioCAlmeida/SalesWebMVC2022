using SalesWebMVC2022.Data;
using SalesWebMVC2022.Models;

namespace SalesWebMVC2022.Services
{
    public class DepartmentService
    {
        private readonly SalesWebMVC2022Context _context;

        public DepartmentService(SalesWebMVC2022Context context)
        {
            _context = context;
        }

        public List<Department> FindAll()
        {
            return _context.Department.OrderByDescending(x => x.Id).ToList();
        }
    }
}
