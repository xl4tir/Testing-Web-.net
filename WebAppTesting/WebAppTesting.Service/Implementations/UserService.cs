using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAppTesting.Domain.Response;
using WebAppTesting.Domain.ViewModel.User;
using WebAppTesting.Service.Interfaces;

namespace WebAppTesting.Service.Implementations
{
    class UserService : IUserService
    {
        public Task<IBaseResponse<bool>> DeleteUser(long id)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponse<IEnumerable<UserViewModel>>> GetUsers()
        {
            throw new NotImplementedException();
        }
    }
}
