using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using TestTask.DAL.EF;
using TestTask.DAL.Entities;
using TestTask.DAL.Interfaces;

namespace TestTask.DAL.Repositories
{
    public class SectionRepository : ISectionRepository
    {
        private readonly ConferenceContext _ctx;

        public SectionRepository(ConferenceContext ctx)
        {
            _ctx = ctx;
        }

        public void Create(Section section)
        {
            _ctx.Sections.Add(section);
        }

        public void Delete(int id)
        {
            var section = _ctx.Sections.Find(id);
            if (section != null) _ctx.Sections.Remove(section);
        }

        public IEnumerable<Section> Find(Func<Section, bool> predicate)
        {
            return _ctx.Sections.Where(predicate).ToList();
        }

        public Section Get(int id)
        {
            return _ctx.Sections.Find(id);
        }

        public IEnumerable<Section> GetAll()
        {
            return _ctx.Sections;
        }

        public IEnumerable<Section> GetAllWithInfo()
        {
            return _ctx.Sections.Include(s => s.SectionInfo);
        }

        public void Update(Section section)
        {
            _ctx.Entry(section).State = EntityState.Modified;
        }
    }
}
