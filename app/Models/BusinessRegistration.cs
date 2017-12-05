using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using app.Models;
using app.Models.Security;
using Microsoft.AspNetCore.Razor.Language.Extensions;

namespace app.Models
{
    public class BusinessRegistration
    {
        public int Id { get; set; }
        //public AppUser Creator { get; set; }
        public string ContactName { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime Expiration { get; set; }
        public bool AutoRenewSubscription { get; set; }
        public string ImageUrl { get; set; }
    }
}
