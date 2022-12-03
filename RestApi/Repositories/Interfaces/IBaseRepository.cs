namespace RestApi.Repositories.Implementations
{
    public interface IBaseRepository<TDbModel> where TDbModel : BaseModel
    {
        public TDbModel Get(int id);
        public List<TDbModel> GetRange(int firstId, int lastId);
    }
}
