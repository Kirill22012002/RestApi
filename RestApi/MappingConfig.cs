namespace RestApi
{
    public static class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                /*config.CreateMap<dbModel, viewModel>()*/
            });

            return mappingConfig;
        }
    }
}
