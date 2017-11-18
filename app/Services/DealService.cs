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
               Name = "AUTOMATIC TRANSMISSION SERVICE"
           }
         }; 
       }
    }
}
