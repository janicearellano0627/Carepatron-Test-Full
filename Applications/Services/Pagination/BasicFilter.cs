using Newtonsoft.Json;

namespace Application.Services.Pagination
{
    public class BasicFilter : IFilter
    {
        public int Page { get; set; } = 1;
        public int Limit { get; set; } = 10;

        public object Clone()
        {
            var jsonString = JsonConvert.SerializeObject(this);
            return JsonConvert.DeserializeObject(jsonString, GetType());
        }
    }
}
