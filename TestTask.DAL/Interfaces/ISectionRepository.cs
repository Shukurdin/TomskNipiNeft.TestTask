using System.Collections.Generic;
using TestTask.DAL.Entities;

namespace TestTask.DAL.Interfaces
{
    public interface ISectionRepository : IRepositoryBase<Section>
    {
        IEnumerable<Section> GetAllWithInfo();
    }
}