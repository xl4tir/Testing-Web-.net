using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAppTesting.Domain.Entity;

namespace WebAppTesting.DAL.Interfaces
{
    public interface ITests
    {
        IEnumerable<Tests> GetsById(int id);
    }
}
