using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAppTesting.DAL.Interfaces;
using WebAppTesting.Domain.Entity;

namespace WebAppTesting.DAL.Repositories
{
    public class UserRepository : IBaseRepository<User>
    {
        private readonly AppDBContext _db;

        public UserRepository(AppDBContext db)
        {
            this._db = db;
        }

        public IQueryable<User> GetAll()
        {
            return _db.Users;
        }

        public async Task DeleteAsync(User entity)
        {
            _db.Users.Remove(entity);
            await _db.SaveChangesAsync();
        }

        public async Task Create(User entity)
        {
            await _db.Users.AddAsync(entity);
            await _db.SaveChangesAsync();
        }

        public async Task<User> Update(User entity)
        {
            _db.Users.Update(entity);
            await _db.SaveChangesAsync();

            return entity;
        }

        

        public Task<User> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<User>> Select()
        {
            throw new NotImplementedException();
        }

        
    }
}
