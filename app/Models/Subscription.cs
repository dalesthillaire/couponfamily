using System.Collections.Generic;
using app.Models.Security;

namespace app.Models
{
    public class Subscription
    {
        public int Id { get; set; }
        public AppUser Business { get; set; }
        public List<AppUser> Customers { get; set; }
    }
}