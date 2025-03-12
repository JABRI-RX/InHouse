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
    // if(builder.Environment.IsDevelopment())
        options.UseSqlServer(builder.Configuration.GetConnectionString("sqlserver"));
    // else
    //     options.UseSqlServer(builder.Configuration.GetConnectionString("sqlserver"));
            
});
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IClientRepository,ClientRepository>();
builder.Services.AddScoped<IVoitureRepository,VoitureRepository>();
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

 