

using HelpingHands_API.Data;
using HelpingHands_API.Models;
using HelpingHands_API.Repository;
using HelpingHands_API.Repository.IRepostiory;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace HelpingHands_API.Repository
{
    public class EnquiryRepository : Repository<Enquiry>, IEnquiryRepository
    {
        private readonly ApplicationDbContext _db;
        public EnquiryRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

  
        public async Task<Enquiry> UpdateAsync(Enquiry entity)
        {
         
            _db.Enquiries.Update(entity);
            await _db.SaveChangesAsync();
            return entity;
        }
    }
}
