
namespace RestApi.Repositories.Implementations
{
    public class BaseRepository<TDbModel> : IBaseRepository<TDbModel> where TDbModel : BaseModel
    {
        private ApplicationContext _context { get; set; }
        private DbSet<TDbModel> _dbSet;

        public BaseRepository(ApplicationContext Dbcontext)
        {
            _context = Dbcontext;
            _dbSet = _context.Set<TDbModel>();
        }
        public TDbModel Get(int id)
            => _dbSet.FirstOrDefault(x => x.Id == id);
        
        public List<TDbModel> GetRange(int firstId, int lastId)
            => _dbSet.Where(x => (x.Id >= firstId && x.Id <= lastId) || 
                                 (x.Id <= firstId && x.Id >= lastId)).ToList();
        
    }
}   
