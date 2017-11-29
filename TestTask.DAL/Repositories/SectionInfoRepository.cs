using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using TestTask.DAL.EF;
using TestTask.DAL.Entities;
using TestTask.DAL.Interfaces;

namespace TestTask.DAL.Repositories
{
    public class SectionInfoRepository : IRepositoryBase<SectionInfo>
    {
        private readonly ConferenceContext _ctx;

        public SectionInfoRepository(ConferenceContext ctx)
        {
            _ctx = ctx;
        }

        public void Create(SectionInfo section)
        {
            _ctx.SectionsInfo.Add(section);
        }

        public void Delete(int id)
        {
            var sectionInfo = _ctx.SectionsInfo.Find(id);
            if (sectionInfo != null) _ctx.SectionsInfo.Remove(sectionInfo);
        }

        public IEnumerable<SectionInfo> Find(Func<SectionInfo, bool> predicate)
        {
            return _ctx.SectionsInfo.Where(predicate).ToList();
        }

        public SectionInfo Get(int id)
        {
            return _ctx.SectionsInfo.Find(id);
        }

        public IEnumerable<SectionInfo> GetAll()
        {
            return _ctx.SectionsInfo;
        }

        public void Update(SectionInfo section)
        {
            _ctx.Entry(section).State = EntityState.Modified;
        }
    }
}
