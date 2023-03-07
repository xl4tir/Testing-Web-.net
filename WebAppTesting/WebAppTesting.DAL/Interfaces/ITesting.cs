using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAppTesting.Domain.Entity;

namespace WebAppTesting.DAL.Interfaces
{
    public interface ITesting : IBaseRepository<Testing>
    {

        Task<Testing> GetByName(string name);
        IEnumerable<Testing> Testings { get; }

        Task<List<Testing>> SelectWithInclude();

        Task<List<Testing>> SelectAllByAuthor(long AuthorId);
    }
}
