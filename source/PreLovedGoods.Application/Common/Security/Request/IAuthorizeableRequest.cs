using MediatR;

namespace PreLovedGoods.Application.Common.Security.Request;

public interface IAuthorizeableRequest<T> : IRequest<T>
{
    Guid UserId { get; }
}