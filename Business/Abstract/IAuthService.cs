using Core.Utilities.Results;
using Core.Utilities.Security.JWT;
using Entities.DTOs;
using User = Core.Entities.Concrete.User;

namespace Business.Abstract
{
    public interface IAuthService
    {
        IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password);
        IDataResult<User> Login(UserForLoginDto userForLoginDto);
        IResult UserExists(string email);
        IDataResult<AccessToken> CreateAccessToken(User user);
        IDataResult<UserForUpdateDto> Update(UserForUpdateDto userForUpdate);
    }
}
