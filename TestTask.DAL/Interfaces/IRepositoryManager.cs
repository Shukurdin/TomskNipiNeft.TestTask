using System;
using TestTask.DAL.Entities;
using TestTask.DAL.Identity;

namespace TestTask.DAL.Interfaces
{
    public interface IRepositoryManager : IDisposable
    {
        ApplicationUserManager UserManager { get; set; }
        ApplicationRoleManager RoleMaanger { get; set; }
        IUserProfileManager UserProfileManager { get; set; }
        ISectionRepository SectionRepository { get; }
        IRepositoryBase<SectionInfo> SectionInfoRepository { get; }
        void Save();
    }
}
