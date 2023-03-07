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
    public class AnswersService : IAnswersService
    {

        private readonly IAnswers _answers;

        public AnswersService(IAnswers answers)
        {
            _answers = answers;


        }

        public  IBaseResponse<IEnumerable<Answers>> GetAnswersByIdTestings(int TestingId)
        {
            var baseResponse = new BaseResponse<IEnumerable<Answers>>();

            try
            {
                var answers =  _answers.GetsById(TestingId);
                if (answers == null)
                {
                    baseResponse.Description = "Знайдено 0 елементів";
                    baseResponse.StatusCode = StatusCode.OK;

                    return baseResponse;
                }

                baseResponse.Data = answers;
                baseResponse.StatusCode = StatusCode.OK;

                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<IEnumerable<Answers>>()
                {
                    Description = $"[GetTestings] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }
    }
}
