using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TomskNipiNeft.TestTask.Models
{
    public class SectionInfoVm
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }
        [DisplayName("Название")]
        public string Name { get; set; }
        [DisplayName("Город")]
        public string City { get; set; }
        [DisplayName("Местонахождение")]
        public string Location { get; set; }
    }
}