namespace RandomQuestionApi.ViewModels
{
    public class QuestionViewModel : BaseViewModel
    {
        public IList<QuestionModel> Questions { get; set; } = new List<QuestionModel>();
    }

    public class QuestionModel
    {
        public string Id { get; set; } = "";
        public string Title { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;

        public IList<AnswerOptionModel> AnswerOptions { get; set; }  = new List<AnswerOptionModel>();
    }

    public class AnswerOptionModel
    {
        public string Id { get; set; } = "";
        public string Title { get; set; } = string.Empty;      
    }

}
