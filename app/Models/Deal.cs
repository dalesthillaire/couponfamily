using System;
using app.Models;
using app.Models.Security;
using Microsoft.AspNetCore.Razor.Language.Extensions;

namespace app.Models
{
    public class Deal
    {
       public int Id { get; set; }
       public AppUser Creator { get; set; }
       public string Name { get; set; } 
       public string Detail { get; set; }
       public string Disclaimer { get; set; }
       public double Cost { get; set; }
       public string CostDescription { get; set; }
       public DateTime StartDate { get; set; }
       public DateTime Expiration { get; set; }
       public string Code { get; set; }
       public bool IsSponsored { get; set; }
       public bool IsActive { get; set; }
       public string ImageUrl { get; set; }
    }
}
