using System.Collections.Generic;

namespace TomskNipiNeft.TestTask.Models
{
    public class SectionPageViewModel
    {
        public IEnumerable<SectionVm> Sections { get; set; }
        public PageInfo PageInfo { get; set; }
    }
}