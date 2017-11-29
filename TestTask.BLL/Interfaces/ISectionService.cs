using System.Collections.Generic;
using TestTask.BLL.DTO;

namespace TestTask.BLL.Interfaces
{
    public interface ISectionService
    {
        SectionDto GetSection(int? id);
        SectionDto GetSection(string abbreviation);
        SectionInfoDto GetSectionInfo(int? id);
        IEnumerable<SectionDto> GetSections(bool includeInfo = false);
        void AddOrUpdate(SectionDto sectionDto);
    }
}