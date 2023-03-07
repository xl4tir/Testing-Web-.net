using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAppTesting.Domain.Response;
using WebAppTesting.Domain.ViewModel.User;

namespace WebAppTesting.Service.Interfaces
{
    public interface IUserService
    {
        Task<BaseResponse<IEnumerable<UserViewModel>>> GetUsers();

        Task<IBaseResponse<bool>> DeleteUser(long id);

    }
}
