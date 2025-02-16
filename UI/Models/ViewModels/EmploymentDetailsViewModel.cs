namespace UI.Models.ViewModels
{
    public class EmploymentDetailsViewModel
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public bool Employee { get; set; }
        public bool SelfEmployed { get; set; }
        public bool Unemployed { get; set; }
        public bool Retired { get; set; }
        public bool Student { get; set; }
        public bool Housewife { get; set; }
        public string Others { get; set; }
    }

}
