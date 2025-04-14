using MediatR;
using CarRental.Application.Common.Interfaces;
using CarRental.Domain.Entities;

namespace CarRental.Application.Employees.Commands
{
    public record DeleteEmployeeCommand(Guid Id) : IRequest;

    public class DeleteEmployeeCommandHandler : IRequest<DeleteEmployeeCommand>
    {
        private readonly IRepository _repository;

        public DeleteEmployeeCommandHandler(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            _repository.SoftDelete<Employee>(request.Id);
            await _repository.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}