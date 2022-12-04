namespace RestApi.DbStuff.Repositories.Interfaces
{
    public interface IBaseRepository<TDbModel> where TDbModel : BaseModel
    {
        public List<TDbModel> GetRange(int firstItem, int lastItem);
        public List<TDbModel> GetAll();
    }
}
