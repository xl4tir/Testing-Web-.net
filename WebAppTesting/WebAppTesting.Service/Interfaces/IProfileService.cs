using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAppTesting.Domain.Entity;
using WebAppTesting.Domain.Response;
using WebAppTesting.Domain.ViewModel.Profile;

namespace WebAppTesting.Service.Interfaces
{
    public interface IProfileService
    {
        Task<BaseResponse<ProfileViewModel>> GetProfile(string userName);

        Task<BaseResponse<Profile>> Save(ProfileViewModel model);


        
    }
}
