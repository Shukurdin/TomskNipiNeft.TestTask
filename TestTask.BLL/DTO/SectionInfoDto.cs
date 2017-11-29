using Newtonsoft.Json;

namespace TestTask.BLL.DTO
{
    [JsonObject]
    public class SectionInfoDto
    {
        [JsonIgnore]
        public int Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("city")]
        public string City { get; set; }
        [JsonProperty("location")]
        public string Location { get; set; }

        public bool IsEmpty => string.IsNullOrWhiteSpace(Name)
                               || string.IsNullOrWhiteSpace(City)
                               || string.IsNullOrWhiteSpace(Location);

    }
}