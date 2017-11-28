using System.ComponentModel.DataAnnotations;

namespace app.Models.Security
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        public string RegisterEmail { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string RegisterPassword { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string RegisterConfirmPassword { get; set; }
    }
}
