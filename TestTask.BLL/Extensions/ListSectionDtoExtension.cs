using System.Collections.Generic;
using Newtonsoft.Json;
using TestTask.BLL.DTO;

namespace TestTask.BLL.Extensions
{
    public static class ListSectionDtoExtension
    {
        public static string ToJson(this IEnumerable<SectionDto> sections)
        {
            return JsonConvert.SerializeObject(sections);
        }
    }
}