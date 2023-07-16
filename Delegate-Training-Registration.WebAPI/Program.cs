using Delegate_Training_Registration.BusinessServices.Mappers;
using Delegate_Training_Registration.BusinessServices.Service_Contract;
using Delegate_Training_Registration.BusinessServices.Services;
using Delegate_Training_Registration.DataAccess.Contracts;
using Delegate_Training_Registration.DataAccess.Data;
using Delegate_Training_Registration.DataAccess.Repositories;
using Delegate_Training_Registration.WebAPI.API_Extentsions;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

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

	  builder.Services.AddAutoMapper(Assembly.GetAssembly(typeof(DelegateTrainingRegistrationMapper)));
	  builder.Services.AddScoped<ICourseService, CourseService>();
	  builder.Services.AddScoped<ITrainingService, TrainingService>();
	  builder.Services.AddScoped<IPersonService, PersonService>();
	  builder.Services.AddScoped<IPhysicalAddressService, PhysicalAddressService>();
	  builder.Services.AddScoped<IRegisterDelegateTrainingService, RegisterDelegateTrainingService>();
	  builder.Services.AddScoped<IRepositoryManager, RepositoryManager>();

	  // content negotiation config between client & server.
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