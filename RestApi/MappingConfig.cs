namespace RestApi
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            return new MapperConfiguration(config =>
            {
                config.CreateMap<Book, BookViewModel>().ReverseMap();
            });
        }
    }
}
