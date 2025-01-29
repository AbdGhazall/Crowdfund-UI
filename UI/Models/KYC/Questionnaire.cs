using System.ComponentModel;

namespace UI.Models.KYC
{
    public class Questionnaire : AuditBase
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ArabicTitle { get; set; }
        public string Description { get; set; }
        public QuestionType QuestionType { get; set; }
        public string ArabicDescription { get; set; }
    }

    //question type enum
    public enum QuestionType
    {
        [Description("Characters(Max:200)")]
        Text = 1,

        [Description("Date")]
        Date = 2,

        [Description("Numeric, Decimal, Double")]
        Number = 3,

        [Description("0 or 1")]
        Boolean = 4
    }

    //get enum QuestionType description attribute value
    public static class QuestionTypeExtensions
    {
        public static string GetDisplayName(this QuestionType questionType)
        {
            var type = typeof(QuestionType);
            var memInfo = type.GetMember(questionType.ToString());
            var attributes = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
            return ((DescriptionAttribute)attributes[0]).Description;
        }
    }
}