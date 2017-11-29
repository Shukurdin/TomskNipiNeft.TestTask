using System.Collections.Generic;
using System.Security.Claims;
using TestTask.BLL.DTO;
using TestTask.BLL.Infrastructure;

namespace TestTask.BLL.Interfaces
{
    public interface IUserService
    {
        OperationDetails Create(UserDto userDto);
        ClaimsIdentity Authenticate(UserDto userDto);
        void SetInitialData(UserDto adminDto, List<string> roles);
    }
}