using Delegate_Training_Registration.DataAccess.Contracts;
using Delegate_Training_Registration.DataAccess.Data;
using Delegate_Training_Registration.DataAccess.Repositories;
using Delegate_Training_Registration.WebAPI.API_Extentsions;
using Microsoft.EntityFrameworkCore;

namespace Delegate_Training_Registration.WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddDbContext<DelegateTrainingRegistrationContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DelegateTrainingRegistrationConnection"));
            });

            builder.Services.AddScoped<IRepositoryManager, RepositoryManager>();
            builder.Services.AddControllers(configs =>
                {
                    configs.RespectBrowserAcceptHeader = true;
                    configs.ReturnHttpNotAcceptable = true;
                }
            ).AddXmlDataContractSerializerFormatters();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseGlobalErrorHandlingMiddleware();

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}