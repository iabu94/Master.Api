namespace MRX.Master.Api.DTOs
{
    public class ChoiceDto
    {
        public string Choice { get; set; }
        public bool IsAnswer { get; set; }
        public long QuestionId { get; set; }
    }
}
