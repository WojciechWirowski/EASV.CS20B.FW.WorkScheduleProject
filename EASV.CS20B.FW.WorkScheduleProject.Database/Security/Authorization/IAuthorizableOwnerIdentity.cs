namespace EASV.CS20B.FW.WorkScheduleProject.Database.Security.Authorization
{
    public interface IAuthorizableOwnerIdentity
    {
        long GetAuthorizedOwnerId();

        string GetAuthorizedOwnerName();
    }
}