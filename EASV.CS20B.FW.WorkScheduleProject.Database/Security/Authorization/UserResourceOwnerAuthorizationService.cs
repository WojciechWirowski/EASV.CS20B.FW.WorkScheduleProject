using System.Threading.Tasks;
using EASV.CS20B.FW.WorkScheduleProject.Database.Security.Authorization;
using Microsoft.AspNetCore.Authorization;


namespace EASV.CS20._3semester.FW.CrudForProductsAssignmentSecurity.Authorization
{
    public class UserResourceOwnerAuthorizationService : AuthorizationHandler<ResourceOwnerRequirement, IAuthorizableOwnerIdentity>, IAuthorizableOwnerIdentity
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, ResourceOwnerRequirement requirement,
            IAuthorizableOwnerIdentity resource)
        {
            string userName = context.User.Identity.Name;
            string resourceOwnerName = resource.GetAuthorizedOwnerName();
            if (userName != null && userName.Equals(resourceOwnerName))
            {
                context.Succeed(requirement);
            }
            
            return Task.CompletedTask;
        }

        public long GetAuthorizedOwnerId()
        {
            throw new System.NotImplementedException();
        }

        public string GetAuthorizedOwnerName()
        {
            throw new System.NotImplementedException();
        }
    }
    
    public class ResourceOwnerRequirement : IAuthorizationRequirement {}

}