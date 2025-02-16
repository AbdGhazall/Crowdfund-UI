using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UI.Models.Users_KYC
{
    public class EmploymentDetails
    {
        public int Id { get; set; }

        public Guid UserId { get; set; }

        //[ForeignKey("UserId")]
        //public ApplicationUser User { get; set; }

        public bool Employee { get; set; }

        public bool SelfEmployed { get; set; }

        public bool Unemployed { get; set; }

        public bool Retired { get; set; }

        public bool Student { get; set; }

        public bool Housewife { get; set; }

        [MaxLength(200)]
        public string Others { get; set; }

        [MaxLength(200)]
        public string Employer { get; set; }

        [MaxLength(50)]
        public string JobTitle { get; set; }

        [MaxLength(200)]
        public string WorkAddress { get; set; }

        [MaxLength(200)]
        public string NatureOfBusiness { get; set; }
    }
}