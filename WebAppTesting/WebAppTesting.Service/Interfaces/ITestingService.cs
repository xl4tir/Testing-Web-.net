using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAppTesting.Domain.Entity;
using WebAppTesting.Domain.Response;
using WebAppTesting.Domain.ViewModel.Testing;

namespace WebAppTesting.Service.Interfaces
{
    public interface ITestingService
    {
        Task<IBaseResponse<IEnumerable<Testing>>> GetTestings();
        Task<IBaseResponse<Testing>> GetTesting(int id);

        Task<IBaseResponse<Testing>> GetTestingByName(string name);

        Task<IBaseResponse<bool>> DeleteTesting(int id);

        Task<IBaseResponse<TestingViewModel>> CreateTesting(TestingViewModel testingViewModel);

        Task<IBaseResponse<Testing>> Edit(int id, TestingViewModel model);

        Task<IBaseResponse<IEnumerable<Testing>>> GetTestingWithIncludeUser();

        Task<IBaseResponse<IEnumerable<TestingNameIdDateViewModel>>> SelectAllTestingsByAuthor(long AuthorId);

        Task<IBaseResponse<bool>> DeleteTesting(long _userId, int _testingId);
    }
}
