using System.ComponentModel.DataAnnotations;

namespace UI.Models
{
    public class RiskToleranceCode
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string ArabicDescription { get; set; }
    }
}
