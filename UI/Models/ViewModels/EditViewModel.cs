using System.ComponentModel.DataAnnotations;
using UI.Models.Users_KYC;

namespace UI.Models.ViewModels
{
    public class EditViewModel

    {
        public EditViewModel()
        {
            EmploymentDetails = new EmploymentDetails();
        }

        [Required]
        public string Id { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateOnly BirthDate { get; set; }

        [Required]
        public int PlaceOfBirthId { get; set; }

        [Required]
        public int SocialStatusId { get; set; }

        [Required]
        public int InvestorTypeId { get; set; }

        public EmploymentDetails EmploymentDetails { get; set; }
    }
}