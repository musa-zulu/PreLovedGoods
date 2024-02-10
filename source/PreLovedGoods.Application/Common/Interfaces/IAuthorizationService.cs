using ErrorOr;
using PreLovedGoods.Application.Common.Security.Request;

namespace PreLovedGoods.Application.Common.Interfaces;

public interface IAuthorizationService
{
    ErrorOr<Success> AuthorizeCurrentUser<T>(
        IAuthorizeableRequest<T> request,
        List<string> requiredRoles,
        List<string> requiredPermissions,
        List<string> requiredPolicies);
}
