using MediatR;
using System.ComponentModel.DataAnnotations;
using WorkBalance.Core.Common;

namespace WorkBalance.Core.Users.Delete
{
    public class DeleteUserCommand : IRequest<BaseHandlerResult>
    {
        [Range(1, int.MaxValue)]
        public int Id { get; set; }
    }
}
