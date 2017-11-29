using TestTask.DAL.EF;
using TestTask.DAL.Entities;
using TestTask.DAL.Interfaces;

namespace TestTask.DAL.Repositories
{
    public class UserProfileManager : IUserProfileManager
    {
        private readonly ConferenceContext _ctx;

        public UserProfileManager(ConferenceContext ctx)
        {
            _ctx = ctx;
        }

        public void Create(UserProfile userProfile)
        {
            _ctx.UserProfiles.Add(userProfile);
            _ctx.SaveChanges();
        }
    }
}