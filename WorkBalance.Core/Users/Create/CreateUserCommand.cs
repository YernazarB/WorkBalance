using MediatR;
using System.ComponentModel.DataAnnotations;
using WorkBalance.Core.Common;
using WorkBalance.Core.Models;

namespace WorkBalance.Core.Users.Create
{
    public class CreateUserCommand : IRequest<BaseHandlerResult<UserModel>>
    {
        [Required]
        [MinLength(1)]
        public string? Name { get; set; }
    }
}
