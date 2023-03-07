using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using WebAppTesting.Domain.Response;
using WebAppTesting.Domain.ViewModel.Account;

namespace WebAppTesting.Service.Interfaces
{
    public interface IAccountService
    {

        Task<BaseResponse<ClaimsIdentity>> Register(RegisterViewModel model);

        Task<BaseResponse<ClaimsIdentity>> Login(LoginViewModel model);
    }
}
