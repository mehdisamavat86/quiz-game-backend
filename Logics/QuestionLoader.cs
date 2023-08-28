using RandomQuestionApi.Models;

namespace RandomQuestionApi.Logics
{
    public interface IQuestionLoader
    {
        IList<QuestionLibraryModel> Load();
    }

    public class QuestionLoader : ObjectSerializer, IQuestionLoader
    {
        const string questionLibraryPath = "question-library.json";
        public QuestionLoader() 
        { 
        }

        public IList<QuestionLibraryModel> Load()
        {
            try
            {
                var content = File.ReadAllText(questionLibraryPath);
                var result = Deserialize<IList<QuestionLibraryModel>>(content);
                if (result == null) 
                {
                    throw new Exception("Null result");
                }

                return result;
            }

            catch (Exception ex) 
            {
                throw new Exception($"Can not read questions. \n {ex.Message}");
            }
            
        }
    }
}
