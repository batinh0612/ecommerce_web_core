using Ecommerce.Service.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Admin.CustomHandler
{
    public class RolesAuthorizationHandler : AuthorizationHandler<RolesAuthorizationRequirement>, IAuthorizationHandler
    {
        private readonly IUserService userService;

        public RolesAuthorizationHandler(IUserService userService)
        {
            this.userService = userService;
        }
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context,
                                                       RolesAuthorizationRequirement requirement)
        {
            if (context.User == null || !context.User.Identity.IsAuthenticated)
            {
                context.Fail();
                return Task.CompletedTask;
            }

            var validRole = false;
            if (requirement.AllowedRoles == null ||
                requirement.AllowedRoles.Any() == false)
            {
                validRole = true;
            }
            else
            {
                var claims = context.User.Claims;
                var userName = claims.FirstOrDefault(c => c.Type == "Username").Value;
                var roles = requirement.AllowedRoles;

                //validRole = new Users().GetUsers().Where(p => roles.Contains(p.Role) && p.UserName == userName).Any();
                validRole = userService.GetAll().Where( x => roles.Contains(x.Role.Name) && x.Username == userName).Any();
            }

            if (validRole)
            {
                context.Succeed(requirement);
            }
            else
            {
                context.Fail();
            }
            return Task.CompletedTask;
        }
    }
}
