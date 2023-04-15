using Microsoft.AspNetCore.Builder;

namespace Common.Extensions.ExceptionMiddleware
{
	public static class Startup
	{
		public static IApplicationBuilder UseGlobalExceptionHandler(this IApplicationBuilder app)
				=> app.UseMiddleware<ExceptionMiddleware>();
	}
}
