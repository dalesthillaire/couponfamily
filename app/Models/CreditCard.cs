using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace app.Models
{
    public class CreditCard
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public string CVV { get; set; }
        public string ExpirationDate { get; set; }
    }
}
