using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAppTesting.DAL.Interfaces;
using WebAppTesting.Domain.Entity;
using WebAppTesting.Domain.Enum;
using WebAppTesting.Domain.ViewModel.Testing;
using WebAppTesting.Domain.Response;
using WebAppTesting.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace WebAppTesting.Service.Implementations
{
    public class TestingService : ITestingService
    {

        private readonly ITesting _testings;

        public TestingService(ITesting testing)
        {
            _testings = testing;




        }



        public async Task<IBaseResponse<TestingViewModel>> CreateTesting(TestingViewModel testingViewModel)
        {
            var baseResponse = new BaseResponse<TestingViewModel>();


            try
            {
                var testing = new Testing()
                {
                    Name = "Тест2",
                    UserId = 101,
                    GradeID = 13,
                    SubjectID = 13

                };

                await _testings.Create(testing);
            }
            catch (Exception ex)
            {
                return new BaseResponse<TestingViewModel>()
                {
                    Description = $"[CreateTesting] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
            return baseResponse;
        }


        public async Task<IBaseResponse<bool>> DeleteTesting(int id)
        {
            var baseResponse = new BaseResponse<bool>();

            try
            {
                var testing = await _testings.Get(id);
                if (testing == null)
                {
                    baseResponse.Description = "Тестування не знайдено";
                    baseResponse.StatusCode = StatusCode.UserNotFound;
                    baseResponse.Data = false;
                    return baseResponse;
                }

                await _testings.DeleteAsync(testing);

                return baseResponse;


            }
            catch (Exception ex)
            {
                return new BaseResponse<bool>()
                {
                    Description = $"[GetTesting] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public async Task<IBaseResponse<Testing>> Edit(int id, TestingViewModel model)
        {
            var baseResponse = new BaseResponse<Testing>();

            try
            {
                var testing = await _testings.Get(id);
                if (testing == null)
                {
                    baseResponse.Description = "Тестування не знайдено";
                    baseResponse.StatusCode = StatusCode.TestingNotFound;
                    return baseResponse;
                }

                testing.Name = model.Name;
                testing.GradeID = model.GradeID;

                await _testings.Update(testing);


                return baseResponse;

            }
            catch (Exception ex)
            {
                return new BaseResponse<Testing>()
                {
                    Description = $"[GetTesting] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public async Task<IBaseResponse<Testing>> GetTesting(int id)
        {
            var baseResponse = new BaseResponse<Testing>();

            try
            {
                var testing = await _testings.Get(id);
                if (testing == null)
                {
                    baseResponse.Description = "Тестування не знайдено";
                    baseResponse.StatusCode = StatusCode.UserNotFound;
                    return baseResponse;
                }

                baseResponse.StatusCode = StatusCode.OK;
                baseResponse.Data = testing;
                return baseResponse;

            }
            catch (Exception ex)
            {
                return new BaseResponse<Testing>()
                {
                    Description = $"[GetTesting] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }

        }



        public async Task<IBaseResponse<Testing>> GetTestingByName(string name)
        {
            var baseResponse = new BaseResponse<Testing>();

            try
            {
                var testing = await _testings.GetByName(name);
                if (testing == null)
                {
                    baseResponse.Description = "Тестування не знайдено";
                    baseResponse.StatusCode = StatusCode.UserNotFound;
                    return baseResponse;
                }

                baseResponse.Data = testing;
                return baseResponse;

            }
            catch (Exception ex)
            {
                return new BaseResponse<Testing>()
                {
                    Description = $"[GetTestingByName] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }

        }



        public async Task<IBaseResponse<IEnumerable<Testing>>> GetTestings()
        {
            var baseResponse = new BaseResponse<IEnumerable<Testing>>();

            try
            {
                var testings = await _testings.Select();
                if (testings.Count == 0)
                {
                    baseResponse.Description = "Знайдено 0 елементів";
                    baseResponse.StatusCode = StatusCode.OK;

                    return baseResponse;
                }

                baseResponse.Data = testings;
                baseResponse.StatusCode = StatusCode.OK;

                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<IEnumerable<Testing>>()
                {
                    Description = $"[GetTestings] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public async Task<IBaseResponse<IEnumerable<Testing>>> GetTestingWithIncludeUser()
        {
            var baseResponse = new BaseResponse<IEnumerable<Testing>>();

            try
            {
                var testings = await _testings.SelectWithInclude();
                if (testings.Count == 0)
                {
                    baseResponse.Description = "Знайдено 0 елементів";
                    baseResponse.StatusCode = StatusCode.OK;

                    return baseResponse;
                }

                baseResponse.Data = testings;
                baseResponse.StatusCode = StatusCode.OK;

                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<IEnumerable<Testing>>()
                {
                    Description = $"[GetTestings] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }


        public async Task<IBaseResponse<IEnumerable<TestingNameIdDateViewModel>>> SelectAllTestingsByAuthor(long AuthorId)
        {
            try
            {
                var authorsTestings =  await _testings.GetAll().Where(x => x.UserId == AuthorId).ToListAsync();

                var result = new List<TestingNameIdDateViewModel>();

                foreach (var _authorsTestings in authorsTestings)
                {
                    result.Add(new TestingNameIdDateViewModel() {Name = _authorsTestings.Name, 
                        Date = _authorsTestings.Date, Id = _authorsTestings.Id,
                         UserId = _authorsTestings.UserId});
                }

                return new BaseResponse<IEnumerable<TestingNameIdDateViewModel>>()
                {
                    Data = result,
                    Description = "Дані обновлено",
                    StatusCode = StatusCode.OK
                };
            }
            catch (Exception ex)
            {

                return new BaseResponse<IEnumerable<TestingNameIdDateViewModel>>()
                {
                    StatusCode = StatusCode.InternalServerError,
                    Description = $"Внутрішня помилка: {ex.Message}"
                };
            }
        }


        public async Task<IBaseResponse<bool>> DeleteTesting(long _userId, int _testingId)
        {
            try
            {
                var testing = await _testings.GetAll().FirstOrDefaultAsync(x => x.Id == _testingId && x.UserId == _userId);
                if (testing == null)
                {
                    return new BaseResponse<bool>
                    {
                        StatusCode = StatusCode.TestingNotFound,
                        Data = false
                    };
                }
                await _testings.DeleteAsync(testing);
                

                return new BaseResponse<bool>
                {
                    StatusCode = StatusCode.OK,
                    Data = true,
                    Description = "Тестування видалено"
                };
            }
            catch (Exception ex)
            {
                
                return new BaseResponse<bool>()
                {
                    StatusCode = StatusCode.InternalServerError,
                    Description = $"Внутрішня помилка: {ex.Message}"
                };
            }
        }

    }
}
