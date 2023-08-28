using RandomQuestionApi.ViewModels;

namespace RandomQuestionApi.Models
{
    public class QuestionLibraryModel
    {
        public string Id { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public IList<Answer> Answers { get; set; } = new List<Answer>();

        public QuestionModel ConvertToQuestionModel()
        {
            return new QuestionModel
            {
                Id = Id,
                Title = Title,
                ImageUrl = ImageUrl,
                AnswerOptions = Answers.Select(x => new AnswerOptionModel { Id = x.Id, Title = x.Title }).ToList()
            };
        }
    }

    public class Answer
    {
        public string Id { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public bool IsCorrect { get; set; } = false;
    }


}
