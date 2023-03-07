using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAppTesting.DAL.Interfaces;
using WebAppTesting.Domain.Entity;

namespace WebAppTesting.DAL.Repositories
{
    public class AnswersRepository : IAnswers
    {

        private readonly AppDBContext _db;

        public AnswersRepository(AppDBContext db)
        {
            this._db = db;
        }


        IEnumerable<Answers> IAnswers.GetsById(int Testingid)
        {
            return
                from ans in _db.Answers
                join t in _db.Tests
                on ans.testID equals t.id
                where t.testingID == Testingid
                select ans;
        }
    }
}
