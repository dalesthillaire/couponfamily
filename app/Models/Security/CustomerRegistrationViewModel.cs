using System.ComponentModel.DataAnnotations;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Newtonsoft.Json;

namespace app.Models.Security
{
    public class CustomerRegistrationViewModel
    {
        [Required]
        [DataType(DataType.Text)]
        public string Name { get; set; }

        // [DataType(DataType.PhoneNumber)]
        // public string PhoneNumber { get; set; }

        [Required]
        [EmailAddress]
        public string RegisterEmail { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string RegisterPassword { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string RegisterConfirmPassword { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string AccountType { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string Location { get; set; }
    }
}
