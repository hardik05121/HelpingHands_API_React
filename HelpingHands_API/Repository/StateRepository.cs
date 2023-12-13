

using HelpingHands_API.Data;
using HelpingHands_API.Models;
using HelpingHands_API.Repository;
using HelpingHands_API.Repository.IRepostiory;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace HelpingHands_API.Repository
{
    public class StateRepository : Repository<State>, IStateRepository
    {
        private readonly ApplicationDbContext _db;
        public StateRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

  
        public async Task<State> UpdateAsync(State entity)
        {
         
            _db.States.Update(entity);
            await _db.SaveChangesAsync();
            return entity;
        }
    }
}
