using Microsoft.AspNetCore.Mvc;
using RandomQuestionApi.Logics;
using RandomQuestionApi.ViewModels;

namespace RandomQuestionApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RandomQuestionController : ControllerBase
    {        
        private readonly ILogger<RandomQuestionController> _logger;
        private readonly IQuestionFactory _questionFactory;
        public RandomQuestionController(IQuestionFactory questionFactory,
                                        ILogger<RandomQuestionController> logger)
        {
            _logger = logger;
            _questionFactory = questionFactory;
        }

        [HttpGet("{numberOfQuestions}")]
        public QuestionViewModel Get(int numberOfQuestions = 3)
        {
            return _questionFactory.GenerateQuestions(numberOfQuestions);            
        }

        [HttpPost]
        public FinalResultViewModel Post([FromBody] UserAnswerViewModel userAnswers)
        {
            return _questionFactory.CheckAnswers(userAnswers.Answers);
        }
    }
}