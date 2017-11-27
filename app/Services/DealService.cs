using System;
using System.Collections.Generic;
using app.Models;

namespace app.Services
{
    public class DealService
    {
       public List<Deal> GetAll(){
           return new List<Deal>(){
            new Deal(){
               Id = 1,
               BusinessId = 2,
               Name = "AUTOMATIC TRANSMISSION SERVICE",
               Phone = "(123) 456-7891",
               StreetAddress = "345 S Main Street",
               City = "Bootsnippville",
               State = "UT",
               Details = new List<string>()
               {
                   "Add up to 5 quarts of motor oil (per specification)",
                   "Complimentary multi-point inspection",
                   "Drain and refill trnasmission fluid",
                   "System inspection"
               },
               Disclaimer = @"Using Genuine Oil Filter and 
                            multigrade oil up to vehicle specification. Lube as 
                            necessary. Ester Oil or Synthetic available at additional 
                            cost. Excludes hazardous waste fee, tax and shop supplies, 
                            where applicable. Offer not valid with previous charges or 
                            with any other offers or specials. Customer must offer at 
                            time of write-up. No cash value.",
               Code = "GBWO2",
               
           }
         }; 
       }
    }
}
