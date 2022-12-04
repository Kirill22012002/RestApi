var builder = WebApplication.CreateBuilder();

// Add services to the container.

builder.Services.AddMvc();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IBaseRepository<Book>, BaseRepository<Book>>();

var connectionString = @"Server=w12.hoster.by;TrustServerCertificate=True; DataBase=cvetulep_flowerDataBase;User Id=cvetulep_administrator; Password=17_29dqeB";
builder.Services.AddDbContext<ApplicationContext>(options =>
    options.UseSqlServer(connectionString));

IMapper mapper = MappingConfig.RegisterMaps().CreateMapper();

builder.Services.AddSingleton(mapper);

var app = builder.Build();

// Configure the HTTP request pipeline

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();