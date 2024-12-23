using Assessment.Models.Data;
using Assessment.Repository.Implementation;
using Assessment.Repository.Interfaces;
using Assessment.UnitConversionAPI.Middlewares;
using Microsoft.EntityFrameworkCore;

namespace Assessment.UnitConversionAPI
{
    public class Startup
    {
        public IConfiguration _configuration { get; }
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(o => o.AddPolicy("MyCORSPolicy", builder => {
                builder.WithOrigins(_configuration.GetSection("CustomAllowedHosts").ToString().Split(new char[','])).AllowAnyMethod().AllowAnyHeader().AllowCredentials();
            }));

            services.AddControllers();           
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            services.AddScoped<IUnitTypeRepository, UnitTypeRepository>();
            services.AddScoped<IUnitDetailsRepository, UnitDetailsRepository>();
            services.AddScoped<IConversionHistoryRepository, ConversionHistoryRepository>();
            //builder.Services.AddScoped<IUnitConversionRepository, UnitConversionRepository>();
            services.AddAutoMapper(System.Reflection.Assembly.Load("Assessment.Repository"));            
            services.AddDbContext<UnitConversionDbContext>(o => o.UseSqlServer(_configuration.GetConnectionString("DB_CONNECTION_STRING")));
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseMiddleware<ExceptionMiddleware>();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.DefaultModelsExpandDepth(-1);
                c.DocExpansion(Swashbuckle.AspNetCore.SwaggerUI.DocExpansion.None);

            });
            app.UseCors("MyCORSPolicy");
            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }


    }
}
