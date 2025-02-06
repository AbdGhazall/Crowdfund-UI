using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using UI.Models.KYC;

namespace UI.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
        }

        public DateTime CreatedAt { get; private set; } = DateTime.UtcNow.AddHours(3);

        [DataType(DataType.Date)]
        public DateOnly BirthDate { get; set; }

        [MaxLength(12)]
        [MinLength(12)]
        public string? CivilId { get; set; }

        [MaxLength(50)]
        public string PACIId { get; set; } = string.Empty;

        public bool IsClassified { get; set; } = false;

        public int PlaceOfBirthId { get; set; }

        public int SocialStatusId { get; set; }

        public int? InvestorTypeId { get; set; }

        [ForeignKey("PlaceOfBirthId")]
        public virtual Country PlaceOfBirth { get; set; }

        [ForeignKey("SocialStatusId")]
        public virtual SocialStatus SocialStatus { get; set; }

        [ForeignKey("InvestorTypeId")]
        public virtual InvestorTypeSetup InvestorType { get; set; }
    }
}