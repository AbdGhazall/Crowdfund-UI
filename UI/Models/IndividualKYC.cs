namespace UI.Models
{
    public class IndividualKYC
    {

        public Guid UserId { get; set; }
        public int? ClientDetailsId { get; set; }
        public int? EmploymentDetailsId { get; set; }
        public int? IncomeAndInvestmentInformationId { get; set; }
        public int? AccountBeneficiariesAndControllersDetailsId { get; set; }
        public int? InsiderPersonsDetailsId { get; set; }
        public int? RelatedPartiesDetailsId { get; set; }
        public int? PoliticalPositionInformationId { get; set; }
        public int? BankAccountDetailsId { get; set; }
        public int? ClientClassificationId { get; set; }
        public int? DealWithFinancialInstitutionId { get; set; }

        public bool IsCompleted { get; set; } = false;
        public bool IsActive { get; set; } = true;

    }
}
