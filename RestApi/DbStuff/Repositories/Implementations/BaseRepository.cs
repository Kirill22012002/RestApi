namespace RestApi.DbStuff.Repositories.Implementations
{
    public class BaseRepository<TDbModel> : IBaseRepository<TDbModel> where TDbModel : BaseModel
    {
        private ApplicationContext _context { get; set; }
        private DbSet<TDbModel> _dbSet;

        public BaseRepository(ApplicationContext context)
        {
            _context = context;
            _dbSet = _context.Set<TDbModel>();
        }
        public List<TDbModel> GetAll()
            => _dbSet.ToList();
        public List<TDbModel> GetRange(int firstItem, int lastItem)
        {
            if (firstItem > lastItem)
            {
                return _dbSet
                    .Skip(lastItem - 1)
                    .Take(firstItem - lastItem + 1)
                    .AsEnumerable()
                    .Reverse()
                    .ToList();
            }
            else
            {
                return _dbSet
                    .Skip(firstItem - 1)
                    .Take(lastItem - firstItem + 1)
                    .ToList();
            }
        }
    }
}
