using System.Collections.Generic;
using System.Linq;
using app.Models;

namespace app.Services
{
    public class SubScriptionService
    {
        private readonly ApplicationDbContext _context;

        public SubScriptionService(ApplicationDbContext context)
        {
            _context = context;
        }
        public List<Subscription> GetAll()
        {
            return _context.Subscriptions.ToList();
        }

    }
}