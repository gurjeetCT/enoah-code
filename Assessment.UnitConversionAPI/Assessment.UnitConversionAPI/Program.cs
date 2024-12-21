using Assessment.Models.Data;
using Assessment.Repository.Implementation;
using Assessment.Repository.Interfaces;
using Assessment.UnitConversionAPI.Middlewares;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors(o => o.AddPolicy("MyCORSPolicy", builder => {
    builder.WithOrigins("http://localhost:3000").AllowAnyMethod().AllowAnyHeader().AllowCredentials();
}));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IUnitTypeRepository, UnitTypeRepository>();
builder.Services.AddScoped<IUnitDetailsRepository, UnitDetailsRepository>();
builder.Services.AddScoped<IConversionHistoryRepository, ConversionHistoryRepository>();
//builder.Services.AddScoped<IUnitConversionRepository, UnitConversionRepository>();
builder.Services.AddAutoMapper(System.Reflection.Assembly.Load("Assessment.Repository"));
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<UnitConversionDbContext>(options => options.UseSqlServer(connectionString));
var app = builder.Build();
app.UseMiddleware<ExceptionMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.DefaultModelsExpandDepth(-1);
        c.DocExpansion(Swashbuckle.AspNetCore.SwaggerUI.DocExpansion.None);

    });
}
app.UseCors("MyCORSPolicy");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
