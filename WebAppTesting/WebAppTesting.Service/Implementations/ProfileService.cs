using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAppTesting.DAL.Interfaces;
using WebAppTesting.Domain.Entity;
using WebAppTesting.Domain.Enum;
using WebAppTesting.Domain.Response;
using WebAppTesting.Domain.ViewModel.Profile;
using WebAppTesting.Service.Interfaces;

namespace WebAppTesting.Service.Implementations
{
    public class ProfileService : IProfileService
    {


        private readonly IBaseRepository<Profile> _profileRepository;

        public ProfileService(IBaseRepository<Profile> profileRepository)
        {
            _profileRepository = profileRepository;
        }




        public async Task<BaseResponse<ProfileViewModel>> GetProfile(string userName)
        {
            try
            {
                var profile = await _profileRepository.GetAll().Select(x => new ProfileViewModel()
                    {
                        Id = x.Id,
                        Address = x.Address,
                        Age = x.Age,
                        UserName = x.User.Name,
                        UserId = x.UserId
                })
                    .FirstOrDefaultAsync(x => x.UserName == userName);

                return new BaseResponse<ProfileViewModel>()
                {
                    Data = profile,
                    StatusCode = StatusCode.OK
                };
            }
            catch (Exception ex)
            {
                
                return new BaseResponse<ProfileViewModel>()
                {
                    StatusCode = StatusCode.InternalServerError,
                    Description = $"Внутрішня помилка: {ex.Message}"
                };
            }
        }

        public async Task<BaseResponse<Profile>> Save(ProfileViewModel model)
        {
            
                var profile = await _profileRepository.GetAll()
                    .FirstOrDefaultAsync(x => x.Id == model.Id);

                profile.Address = model.Address;
                profile.Age = model.Age;

                await _profileRepository.Update(profile);

                return new BaseResponse<Profile>()
                {
                    Data = profile,
                    Description = "Дані обновлено",
                    StatusCode = StatusCode.OK
                };
            
        }

        
    }
}
