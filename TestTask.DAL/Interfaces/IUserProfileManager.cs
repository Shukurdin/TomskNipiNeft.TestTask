using TestTask.DAL.Entities;

namespace TestTask.DAL.Interfaces
{
    public interface IUserProfileManager
    {
        void Create(UserProfile userProfile);
    }
}