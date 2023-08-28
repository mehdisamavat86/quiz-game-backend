using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace RandomQuestionApi.Logics
{

    public abstract class ObjectSerializer
    {
        public string Serialize(object value)
        {
            JsonSerializerSettings settings = new()
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };
            return JsonConvert.SerializeObject(value, settings);
        }

        public T? Deserialize<T>(string value) where T : class
        {
            JsonSerializerSettings settings = new()
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };
            return JsonConvert.DeserializeObject<T>(value, settings);
        }

    }
}
