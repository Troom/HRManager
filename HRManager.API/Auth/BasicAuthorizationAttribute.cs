using Microsoft.AspNetCore.Authorization;

namespace HRManager.Application.Auth
{
    public class BasicAuthorizationAttribute : AuthorizeAttribute
    {
        public BasicAuthorizationAttribute()
        {
            Policy = "BasicAuthentication";
        }
    }
}
