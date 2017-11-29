using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestTask.DAL.Entities
{
    public class SectionInfo
    {
        [Key, ForeignKey("Section")]
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Location { get; set; }
        public Section Section { get; set; }
    }
}
