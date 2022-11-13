using Newtonsoft.Json;

namespace Zidy.Domain.Dto
{
    public class CustomerDto
    {
        [JsonProperty("data")]
        public Data Data { get; set; }

        [JsonProperty("numbers")]
        public long?[][] Sectors { get; set; }
    }

    public class Data
    {
        [JsonProperty("users")]
        public List<User> Users { get; set; }
    }

    public class User
    {
        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [JsonProperty("id")]
        public object Id { get; set; }

        [JsonProperty("FullName")]
        public string FullName { get; set; }
    }

}
