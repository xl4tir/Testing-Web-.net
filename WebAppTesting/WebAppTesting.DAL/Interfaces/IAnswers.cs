using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAppTesting.Domain.Entity;

namespace WebAppTesting.DAL.Interfaces
{
    public interface IAnswers
    {
        IEnumerable<Answers> GetsById(int Testingid);
    }
}
