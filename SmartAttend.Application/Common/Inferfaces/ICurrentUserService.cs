namespace SmartAttend.Application.Common.Inferfaces
{
    public interface ICurrentUserService
    {
        bool IsAuthenticated { get; }
        int AccountId { get; }
        string? UserId { get; }
        string? Email { get; }
        int UserRoleId { get; }
        string? FirstName { get; }
        string? LastName { get; }
        int? CustomerId { get; }
        string? PhoneNumber { get; }
        string CorrelationId { get; }
        string? AzureObjectId { get; }
    }

}
