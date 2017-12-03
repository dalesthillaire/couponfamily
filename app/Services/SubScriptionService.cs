using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using app.Models;
using app.Models.Security;

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

        //add a new subscription 
        public void AddSubscription(AppUser business, AppUser subscriber)
        {
            //get the business from the subscriptions
            var result = _context.Subscriptions.FirstOrDefault(x => x.Business.Id == business.Id);
            //no one has subscribed to the business yet
            if (result == null)
            {
                var subscription = new Subscription() {Business = business, Customers = new List<AppUser>()};
                subscription.Customers.Add(subscriber);
                _context.Subscriptions.Add(subscription);
                _context.SaveChanges();
            }
            else
            {
                //add a new subscriber to the business
                result.Customers.Add(subscriber);
                _context.SaveChanges();
            }
        }
    }
}