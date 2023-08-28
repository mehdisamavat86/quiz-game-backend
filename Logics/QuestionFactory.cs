using RandomQuestionApi.Models;
using RandomQuestionApi.ViewModels;

namespace RandomQuestionApi.Logics
{
    public interface IQuestionFactory
    {
        QuestionViewModel GenerateQuestions(int numberOfQuestions);
        FinalResultViewModel CheckAnswers(IList<UserAnswerModel> userAnswers);

    }

    public class QuestionFactory : IQuestionFactory
    {
        private readonly IQuestionLoader _questionLoader;
        public QuestionFactory(IQuestionLoader questionLoader) 
        { 
            _questionLoader = questionLoader;
        }

        public QuestionViewModel GenerateQuestions(int numberOfQuestions)
        {
            var result = new QuestionViewModel();
            if (numberOfQuestions <= 0)
            {
                result.ErrorMessage = $"{nameof(numberOfQuestions)} can not be equal or less than 0.";
                return result;
            }

            var allQuestions = _questionLoader.Load();            
            if (allQuestions.Count < numberOfQuestions) 
            {
                result.ErrorMessage = $"{nameof(numberOfQuestions)} are more than existing questions.";
                return result;
            }

            result.Questions = GetRandomQuestions(allQuestions, numberOfQuestions).ToList();            
            return result;
        }

        public FinalResultViewModel CheckAnswers(IList<UserAnswerModel> userAnswers)
        {
            if (userAnswers == null || userAnswers.Count == 0)
                return new FinalResultViewModel { ErrorMessage = $"Invalid answers" };

            var result = new FinalResultViewModel();
            var allQuestions = _questionLoader.Load();
            foreach(var answer in userAnswers) 
            { 
                var question = allQuestions.FirstOrDefault(x=> x.Id == answer.QuestionId);
                if (question == null) 
                {
                    return new FinalResultViewModel { ErrorMessage = $"Can not find question with id: {answer.QuestionId}" };
                }

                var correctAnswer = question.Answers.FirstOrDefault(_ => _.IsCorrect);
                result.Results.Add(new ResultModel
                {
                    Question = question.Title,
                    ImageUrl = question.ImageUrl,
                    CorrectAnswer = correctAnswer?.Title ?? "",
                    UserAnswer = question.Answers.FirstOrDefault(_=> _.Id == answer.AnswerId)?.Title ?? "",
                    WasCorrect = correctAnswer?.Id == answer.AnswerId
                });
            }

            return result;
        }

        private IList<QuestionModel> GetRandomQuestions(IList<QuestionLibraryModel> allQuestions, int numberOfQuestions)
        {
            var rng = new Random();
            var allQuestionCount = allQuestions.Count; 
            var indexes = new List<int>();
            var results = new List<QuestionModel>();

            while (results.Count < numberOfQuestions)
            {
                int i = rng.Next(0, allQuestionCount);
                if (indexes.Any(_ => _ == i)) //prevent to have repeat question
                    continue;

                indexes.Add(i);
                results.Add(allQuestions[i].ConvertToQuestionModel());
            }

            return results;
        }

       
    }
}
