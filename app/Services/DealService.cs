using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Security.Cryptography.X509Certificates;
using app.Models;

namespace app.Services
{
    
    public class DealService
    {
        private readonly ApplicationDbContext _context;

        public DealService(ApplicationDbContext context)
        {
            _context = context;
        }
        public Deal GetDealById(int id)
        {
            return _context.Deals.FirstOrDefault(x => x.Id == id);
        }
       public List<Deal> GetAll()
       {
           return _context.Deals.ToList();
       }
    }
}
