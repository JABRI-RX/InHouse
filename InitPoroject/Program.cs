using InitPoroject.Data;
using InitPoroject.Interface;
using InitPoroject.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var myPolicy = "AllowFrontEnd";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: myPolicy,
        policy =>
        {
            policy.WithOrigins("*")
                .WithMethods("POST","GET","PUT","DELETE")
                .AllowAnyHeader();
        });
});
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(options =>
{
    // options.UseSqlServer(builder.Configuration.GetConnectionString("sqlserver"));
    options.UseSqlite(builder.Configuration.GetConnectionString("sqlite"));
});
builder.Services.AddScoped<IProductRepository, ProductRepository>();
var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    scope.ServiceProvider.SeedData();
}
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors(myPolicy);
app.MapControllers();
app.Run();
 