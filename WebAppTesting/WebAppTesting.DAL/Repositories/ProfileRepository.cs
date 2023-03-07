using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAppTesting.DAL.Interfaces;
using WebAppTesting.Domain.Entity;

namespace WebAppTesting.DAL.Repositories
{
    public class ProfileRepository : IBaseRepository<Profile>
    {
        private readonly AppDBContext _db;

        public ProfileRepository(AppDBContext db)
        {
            this._db = db;
        }


        public async Task Create(Profile entity)
        {
            await _db.Profiles.AddAsync(entity);
            await _db.SaveChangesAsync();
        }

        public IQueryable<Profile> GetAll()
        {
            return _db.Profiles;
        }

        public async Task DeleteAsync(Profile entity)
        {
            _db.Profiles.Remove(entity);
            await _db.SaveChangesAsync();
        }

        public async Task<Profile> Update(Profile entity)
        {
            _db.Profiles.Update(entity);
            await _db.SaveChangesAsync();

            return entity;
        }

        public Task<Profile> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Profile>> Select()
        {
            throw new NotImplementedException();
        }

        
    }
}
