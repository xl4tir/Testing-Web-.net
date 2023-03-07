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
    public class TestingRepository : ITesting
    {

        private readonly AppDBContext _db;

        public TestingRepository(AppDBContext db)
        {
            this._db = db;
        }


        public IEnumerable<Testing> Testings => throw new NotImplementedException();

        public async Task Create(Testing entity)
        {
            await _db.Testing.AddAsync(entity);
            await _db.SaveChangesAsync();

            
        }

        public async Task DeleteAsync(Testing entity)
        {
             _db.Testing.Remove(entity);
            await _db.SaveChangesAsync();
            
        }

        public async Task<Testing> Get(int id)
        {
            return await _db.Testing.FirstOrDefaultAsync(x => x.Id == id);
        }

        public IQueryable<Testing> GetAll()
        {
            return _db.Testing;
        }

        public async Task<Testing> GetByName(string name)
        {
            return await _db.Testing.FirstOrDefaultAsync(x => x.Name == name);
        }

        public async Task<List<Testing>> Select()
        {
            return await _db.Testing.ToListAsync();
        }

        

        public async Task<List<Testing>> SelectWithInclude()
        {
            return await _db.Testing.Include(x => x.User).Include(x => x.Subject).Include(x => x.Grade).ToListAsync();
        }

        public async Task<Testing> Update(Testing entity)
        {
            _db.Testing.Update(entity);
            await _db.SaveChangesAsync();

            return entity;
        }

        Task IBaseRepository<Testing>.Create(Testing entity)
        {
            throw new NotImplementedException();
        }

        


        public async Task<List<Testing>> SelectAllByAuthor(long AuthorId)
        {
            return await _db.Testing.Where(p => p.UserId == AuthorId).ToListAsync();
        }


}
}
