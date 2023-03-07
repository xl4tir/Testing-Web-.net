using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAppTesting.DAL.Interfaces;
using WebAppTesting.Domain.Entity;

namespace WebAppTesting.DAL.Repositories
{
    public class TestsRepository : ITests
    {

        private readonly AppDBContext _db;

        public TestsRepository(AppDBContext db)
        {
            this._db = db;
        }

        
        public IEnumerable<Tests> GetsById(int id) => _db.Tests.Where(p => p.testingID == id);
        
    }
}
