using UI.Models.KYC;

namespace UI.Models.Users_KYC
{
    public class PersonalInfo : AuditBase
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public int EducationLevelId { get; set; }
        public int EmploymentStatusId { get; set; }

        public string? Designation { get; set; }
        public string? EmployeerName { get; set; }
        public string? EmployeerAddress { get; set; }
        public string? EmployeerContactDetails { get; set; }


        public virtual EducationLevel EducationLevel { get; set; }
        public virtual EmploymentStatus EmploymentStatus { get; set; }
    }
}
