namespace RandomQuestionApi.ViewModels
{   
    public class UserAnswerViewModel
    {
        public IList<UserAnswerModel> Answers { get; set; } = new List<UserAnswerModel>();
    }

    public class UserAnswerModel
    {
        public string QuestionId { get; set; } = string.Empty;
        public string AnswerId { get; set; } = string.Empty;
    }

}
