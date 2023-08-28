namespace RandomQuestionApi.ViewModels
{
    public class FinalResultViewModel : BaseViewModel
    {
        public IList<ResultModel> Results { get; set; } = new List<ResultModel>();
    }

    public class ResultModel : BaseViewModel
    {
        public string Question { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public string CorrectAnswer { get; set; } = string.Empty;
        public string UserAnswer { get; set; } = string.Empty;
        public bool WasCorrect { get; set; } = false;
    }

}
