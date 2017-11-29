using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using AutoMapper;
using Microsoft.AspNet.Identity;
using TestTask.BLL.DTO;
using TestTask.BLL.Infrastructure;
using TestTask.BLL.Interfaces;
using TestTask.DAL.Entities;
using TestTask.DAL.Interfaces;

namespace TestTask.BLL.Services
{
    public class UserService : IUserService
    {
        public IRepositoryManager RepositoryManager { get; }

        public UserService(IRepositoryManager repository)
        {
            RepositoryManager = repository;
        }

        public OperationDetails Create(UserDto userDto)
        {
            var user = RepositoryManager.UserManager.FindByEmail(userDto.Email);
            if (user != null)
                return new OperationDetails(false, "User with such login already exists", "Email");

            user = new ApplicationUser{ Email = userDto.Email, UserName = userDto.Email };

            var errors = RepositoryManager.UserManager
                .Create(user, userDto.Password)
                .Errors.ToList();

            if(errors.Count > 0)
                return new OperationDetails(false, errors[0], string.Empty);

            RepositoryManager.UserManager.AddToRole(user.Id, userDto.Role);
            var userProfile = new UserProfile {Id = user.Id, Address = userDto.Address, Name = userDto.Name};
            RepositoryManager.UserProfileManager.Create(userProfile);
            RepositoryManager.Save();

            return new OperationDetails(true, "Registration successful", string.Empty);
        }

        public ClaimsIdentity Authenticate(UserDto userDto)
        {
            var user = RepositoryManager.UserManager.Find(userDto.Email, userDto.Password);
            return user == null ? null 
                : RepositoryManager.UserManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
        }

        public void SetInitialData(UserDto adminDto, List<string> roles)
        {
            foreach (var roleName in roles)
            {
                var role = RepositoryManager.RoleMaanger.FindByName(roleName);
                if(role != null) continue;

                RepositoryManager.RoleMaanger.Create(new ApplicationRole {Name = roleName});
            }

            Create(adminDto);
        }
    }
}