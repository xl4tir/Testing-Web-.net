using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAppTesting.Domain.Entity;
using WebAppTesting.Domain.Response;

namespace WebAppTesting.Service.Interfaces
{
    public interface ITestsService
    {
        IBaseResponse<IEnumerable<Tests>> GetTestsByTestingId(int id);
    }
}
