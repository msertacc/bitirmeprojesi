using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace API.Filters
{
	public class ExceptionFilter: IExceptionFilter
	{
		public void OnException(ExceptionContext context)
		{
			context.HttpContext.Response.ContentType = "application/json";
			context.HttpContext.Response.Headers.AcceptCharset = "utf-8";
			context.HttpContext.Response.StatusCode = Convert.ToInt32(HttpStatusCode.BadRequest);
			context.ExceptionHandled = true;
			context.Result = new JsonResult(context.Exception.Message);
		}
	}
}
