using System.ComponentModel.DataAnnotations;

namespace UI.Models
{
    public class EditViewModel
    {
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
    }
}