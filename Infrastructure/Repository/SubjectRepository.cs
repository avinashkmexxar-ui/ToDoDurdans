using Domain.Entity;
using Domain.interfaces;
using Infrastructure.Data; 

namespace Infrastructure.Repository
{
    public class SubjectRepository : Repository<Subject>, ISubjectRepository
    {
        private readonly ApplicationDbContext _db;
        public SubjectRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
    }
}
