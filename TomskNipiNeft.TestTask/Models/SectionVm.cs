using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TomskNipiNeft.TestTask.Models
{
    public class SectionVm
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }
        [DisplayName("Аббревиатура")]
        public string Abbreviation { get; set; }
    }
}