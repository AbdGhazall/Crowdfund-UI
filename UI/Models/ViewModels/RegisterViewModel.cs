using System.ComponentModel.DataAnnotations;

namespace UI.Models.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateOnly BirthDate { get; set; }

        [MaxLength(12)]
        public string? CivilId { get; set; }

        [MaxLength(50)]
        public string PACIId { get; set; } = string.Empty;

        public bool IsClassified { get; set; }

        [Required]
        public int PlaceOfBirthId { get; set; }

        [Required]
        public int SocialStatusId { get; set; }

        [Required]
        public int InvestorTypeId { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords do not match.")]
        public string ConfirmPassword { get; set; }
    }
}