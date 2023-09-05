using SalesWebMVC2022.Data;
using SalesWebMVC2022.Models;

namespace SalesWebMVC2022.Services
{
    public class SellerService
    {
        private readonly SalesWebMVC2022Context _context;

        public SellerService(SalesWebMVC2022Context context)
        {
            _context = context;
        }

        public List<Seller> FindAll()
        {
            return _context.Seller.ToList();
        }

        public void Insert(Seller obj)
        {
            _context.Add(obj);
            _context.SaveChanges();
        }
    }
}
