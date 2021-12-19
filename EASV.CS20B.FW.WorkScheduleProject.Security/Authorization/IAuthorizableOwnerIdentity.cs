namespace EASV.CS20B.FW.WorkScheduleProject.Security.Authorization
{
    public interface IAuthorizableOwnerIdentity
    {
        long GetAuthorizedOwnerId();

        string GetAuthorizedOwnerName();
    }
}