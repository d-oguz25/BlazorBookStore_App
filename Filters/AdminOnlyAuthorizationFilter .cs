using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;

public class AdminOnlyAuthorizationFilter : IAuthorizationFilter
{
    public void OnAuthorization(AuthorizationFilterContext context)
    {
        var user = context.HttpContext.User;

        if (user == null || !user.IsInRole("Admin"))
        {
            context.Result = new ForbidResult(); // Yetkisiz erişimi engelle
        }
    }
}



