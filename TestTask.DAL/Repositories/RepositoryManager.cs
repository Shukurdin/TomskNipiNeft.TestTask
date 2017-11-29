using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using TestTask.DAL.EF;
using TestTask.DAL.Entities;
using TestTask.DAL.Identity;
using TestTask.DAL.Interfaces;

namespace TestTask.DAL.Repositories
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly ConferenceContext _ctx;
        private SectionRepository _sectionRepository;
        private SectionInfoRepository _sectionInfoRepository;
        private bool _isDisposed;
        
        public ApplicationUserManager UserManager { get; set; }
        public ApplicationRoleManager RoleMaanger { get; set; }
        public IUserProfileManager UserProfileManager { get; set; }

        public RepositoryManager(string connectionString)
        {
            _ctx = new ConferenceContext(connectionString);
            UserManager = new ApplicationUserManager(new UserStore<ApplicationUser>(_ctx));
            RoleMaanger = new ApplicationRoleManager(new RoleStore<ApplicationRole>(_ctx));
            UserProfileManager = new UserProfileManager(_ctx);
        }
        
        public ISectionRepository SectionRepository => _sectionRepository
            ?? (_sectionRepository = new SectionRepository(_ctx));

        public IRepositoryBase<SectionInfo> SectionInfoRepository => _sectionInfoRepository
            ?? (_sectionInfoRepository = new SectionInfoRepository(_ctx));

        public virtual void Dispose(bool disposing)
        {
            if (this._isDisposed) return;
            if (disposing) _ctx.Dispose();
            this._isDisposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Save()
        {
            _ctx.SaveChanges();
        }

    }
}
