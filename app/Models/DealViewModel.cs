using System;
using System.Collections.Generic;
using app.Models;

namespace app.Models
{

    public class DealViewModel{
       public int Id { get; set; } 
       public int BusinessId { get; set; } 
       public string Name { get; set; } 
       public List<string> Details { get; set; }
       public string Phone { get; set; } 
       public string StreetAddress { get; set; }
       public string City { get; set; }
       public string State { get; set; }
       public string Zip { get; set; }
       public string Disclaimer { get; set; }
       public double Cost { get; set; }
       public string CostDescription { get; set; }
       public DateTime StartDate { get; set; }
       public DateTime Expiration { get; set; }
       public string Code { get; set; }
       public bool IsSponsored { get; set; }
       public bool IsActive { get; set; }
    }
}
