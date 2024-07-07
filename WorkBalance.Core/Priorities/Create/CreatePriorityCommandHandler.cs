using MediatR;
using WorkBalance.Core.Models;
using WorkBalance.DataAccess;
using WorkBalance.Domain.Entities;

namespace WorkBalance.Core.Priorities.Create
{
    public class CreatePriorityCommandHandler : IRequestHandler<CreatePriorityCommand, BaseHandlerResult<PriorityModel>>
    {
        private readonly AppDbContext _db;

        public CreatePriorityCommandHandler(AppDbContext db)
        {
            _db = db;
        }

        public async Task<BaseHandlerResult<PriorityModel>> Handle(CreatePriorityCommand request, CancellationToken cancellationToken)
        {
            var priority = new Priority { Level = request.Level };

            await _db.AddAsync(priority, cancellationToken);
            await _db.SaveChangesAsync(cancellationToken);

            return BaseHandlerResult<PriorityModel>
                .SuccessResult(PriorityModel.Create(priority));
        }
    }
}
