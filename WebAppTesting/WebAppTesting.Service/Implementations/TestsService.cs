using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAppTesting.DAL.Interfaces;
using WebAppTesting.Domain.Entity;
using WebAppTesting.Domain.Enum;
using WebAppTesting.Domain.Response;
using WebAppTesting.Service.Interfaces;

namespace WebAppTesting.Service.Implementations
{
    public class TestsService : ITestsService
    {


        private readonly ITests _tests;

        public TestsService(ITests testing)
        {
            _tests = testing;


        }

        IBaseResponse<IEnumerable<Tests>> ITestsService.GetTestsByTestingId(int id)
        {

            try
            {


                var baseResponse = new BaseResponse<IEnumerable<Tests>>();

                var tests = _tests.GetsById(id);
                if (tests == null)
                {
                    baseResponse.Description = "Тестування не знайдено";
                    baseResponse.StatusCode = StatusCode.UserNotFound;
                    return (IBaseResponse<IEnumerable<Tests>>)baseResponse;
                }

                baseResponse.Data = tests;
                baseResponse.StatusCode = StatusCode.OK;
                return baseResponse;

            }
            catch (Exception ex)
            {
                return new BaseResponse<IEnumerable<Tests>>()
                {
                    Description = $"[GetTestings] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        

        }

        
    }
}
