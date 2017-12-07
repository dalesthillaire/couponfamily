using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace app.Models
{
    public class BusinessRegistrationViewModel
    {
        /*public IEnumerable<string> SelectedCities { get; set; }
        public IEnumerable<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem> Cities { get; set; }*/

        // businesses will need to enter their company registration and credit card information
        public int Id { get; set; }
        //public AppUser Creator { get; set; }
        [Required]
        [DataType(DataType.Text)]
        public string ContactName { get; set; }
        [Required]
        [DataType(DataType.Text)]
        public string Name { get; set; }
        [Required]
        [DataType(DataType.Text)]
        public string Phone { get; set; }
        [Required]
        [DataType(DataType.Text)]
        public string StreetAddress { get; set; }
        [Required]
        [DataType(DataType.Text)]
        public string City { get; set; }
        [Required]
        [DataType(DataType.Text)]
        public string State { get; set; }
        [Required]
        [DataType(DataType.Text)]
        public string Zip { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string Category { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime Expiration { get; set; }
        public bool AutoRenewSubscription { get; set; }
        public string ImageUrl { get; set; }

        // cc infoc
        [Required]
        [DataType(DataType.Text)]
        public string NameOnCard { get; set; }
        [Required]
        [DataType(DataType.Text)]
        public string Number { get; set; }
        [Required]
        [DataType(DataType.Text)]
        public string Cvv { get; set; }
        [Required]
        [DataType(DataType.Text)]
        public string ExpirationDate { get; set; }
    }
}
