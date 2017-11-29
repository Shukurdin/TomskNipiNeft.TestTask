using Newtonsoft.Json;

namespace TestTask.BLL.DTO
{
    [JsonObject]
    public class SectionDto
    {
        [JsonIgnore]
        public int Id { get; set; }
        [JsonProperty("section")]
        public string Abbreviation { get; set; }
        [JsonProperty("info")]
        public SectionInfoDto SectionInfo { get; set; }

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}