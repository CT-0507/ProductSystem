using Microsoft.AspNetCore.Mvc.Filters;

namespace ProductSystem.Filters
{
    public class UserLoginValidateAttribute : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            throw new System.NotImplementedException();
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var username = context.HttpContext.Request.Form["UserName"];
        }
    }
}
