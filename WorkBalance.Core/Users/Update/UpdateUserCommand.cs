using MediatR;
using System.ComponentModel.DataAnnotations;
using WorkBalance.Core.Common;
using WorkBalance.Core.Models;

namespace WorkBalance.Core.Users.Update
{
    public class UpdateUserCommand : IRequest<BaseHandlerResult<UserModel>>
    {
        [Range(1, int.MaxValue)]
        public int Id { get; set; }

        [Required]
        [MinLength(1)]
        public string? Name { get; set; }
    }
}
