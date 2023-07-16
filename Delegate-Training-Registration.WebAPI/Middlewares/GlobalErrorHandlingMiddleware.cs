using Delegate_Training_Registration.WebAPI.API_Custom_Extentsions;
using System.Net;
using System.Text.Json;

namespace Delegate_Training_Registration.WebAPI.API_Extentsions
{
  // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
  public class GlobalErrorHandlingMiddleware
  {
	private readonly RequestDelegate _next;

	public GlobalErrorHandlingMiddleware(RequestDelegate next)
	{
	  _next = next;
	}

	public async Task Invoke(HttpContext httpContext)
	{
	  try
	  {
		await _next(httpContext);
	  }
	  catch (Exception error)
	  {
		var response = httpContext.Response;
		response.ContentType = "application/json";

		// use to retrieve bubbled up exception.
		//var errorResponse = httpContext.Features.Get<IExceptionHandlerPathFeature>();
		//var requestedResourcePath = errorResponse.Path;

		ErrorDetail errorDetail = new ErrorDetail();
		string errorResponseType = "";
		switch (error)
		{
		  case BadHttpRequestException badHttpRequest:
			response.StatusCode = (int)HttpStatusCode.BadRequest;
			errorResponseType = "Bad Request";
			break;

		  case KeyNotFoundException keyNotFound:
			response.StatusCode = (int)HttpStatusCode.NotFound;
			errorResponseType = "Resource Not Found";
			break;

		  default:
			response.StatusCode = (int)HttpStatusCode.InternalServerError;
			errorResponseType = "Internal server error, developers to review it";
			break;
		}

		errorDetail.message = error.Message;
		errorDetail.type = errorResponseType;
		errorDetail.code = response.StatusCode;
		errorDetail.origin = "";
		//errorDetail.origin = requestedResourcePath;

		var errorResultResponse = JsonSerializer.Serialize(new { error = errorDetail });
		await response.WriteAsync(errorResultResponse);
	  }
	}
  }

  // Extension method used to add the middleware to the HTTP request pipeline.
  public static class GlobalErrorHandlingMiddlewareExtensions
  {
	public static IApplicationBuilder UseGlobalErrorHandlingMiddleware(this IApplicationBuilder builder)
	{
	  return builder.UseMiddleware<GlobalErrorHandlingMiddleware>();
	}
  }
}
