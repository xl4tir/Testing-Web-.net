using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using WebAppTesting.DAL.Interfaces;
using WebAppTesting.Domain.Entity;
using WebAppTesting.Domain.Enum;
using WebAppTesting.Domain.Helpers;
using WebAppTesting.Domain.Response;
using WebAppTesting.Domain.ViewModel.Account;
using WebAppTesting.Service.Interfaces;

namespace WebAppTesting.Service.Implementations
{
    public class AccountService : IAccountService
    {

        private readonly IBaseRepository<User> _userRepository;
        private readonly IBaseRepository<Profile> _profileRepository;


        public AccountService(IBaseRepository<User> userRepository, IBaseRepository<Profile> profileRepository)
        {
            _userRepository = userRepository;
            _profileRepository = profileRepository;

        }

        public async Task<BaseResponse<ClaimsIdentity>> Login(LoginViewModel model)
        {
            try
            {
                var user = await _userRepository.GetAll().FirstOrDefaultAsync(x => x.Name == model.Name);
                if (user == null)
                {
                    return new BaseResponse<ClaimsIdentity>()
                    {
                        Description = "Користувач не знайдений"
                    };
                }

                if (user.Password != HashPasswordHelper.HashPassword(model.Password))
                {
                    return new BaseResponse<ClaimsIdentity>()
                    {
                        Description = "Не вірний логін або пароль"
                    };
                }

                var result = Authenticate(user);

                return new BaseResponse<ClaimsIdentity>()
                {
                    Data = result,
                    StatusCode = StatusCode.OK
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<ClaimsIdentity>()
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public async Task<BaseResponse<ClaimsIdentity>> Register(RegisterViewModel model)
        {
            try
            {
                var user = await _userRepository.GetAll().FirstOrDefaultAsync(x => x.Name == model.Name);
                if (user != null)
                {
                    return new BaseResponse<ClaimsIdentity>()
                    {
                        Description = "Користувач з таким логіном уже існує",
                    };
                }

                user = new User()
                {
                    Name = model.Name,
                    Role = Role.User,
                    Password = HashPasswordHelper.HashPassword(model.Password),
                };



                await _userRepository.Create(user);

                user = await _userRepository.GetAll().FirstOrDefaultAsync(x => x.Name == user.Name);


                var profile = new Profile()
                {

                    UserId = user.Id,
                };
                await _profileRepository.Create(profile);
                var result = Authenticate(user);

                return new BaseResponse<ClaimsIdentity>()
                {
                    Data = result,
                    Description = "Об'єкт добавився",
                    StatusCode = StatusCode.OK
                };

            }
            catch (Exception ex)
            {
                
                return new BaseResponse<ClaimsIdentity>()
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }


        private ClaimsIdentity Authenticate(User user)
        {
            var claims = new List<Claim>
            {

                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Name),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role.ToString())
            };
            return new ClaimsIdentity(claims, "ApplicationCookie",
                ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
        }
    }
}
