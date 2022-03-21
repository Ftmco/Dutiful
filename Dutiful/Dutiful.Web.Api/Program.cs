using Service.Injection;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DutifulContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DutifulConnection")));
builder.Services.AddDependencies();

WebApplication app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.UseCors(x =>
{
    x.AllowAnyHeader()
    .AllowAnyMethod()
    .AllowAnyOrigin();
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

await app.RunAsync();