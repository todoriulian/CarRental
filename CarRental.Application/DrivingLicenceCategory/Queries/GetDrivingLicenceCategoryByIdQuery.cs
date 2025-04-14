using AutoMapper;
using MediatR;
using CarRental.Application.Common.Exceptions;
using CarRental.Application.Common.Interfaces;
using CarRental.Application.DrivingLicenceCategory.Dtos;

namespace CarRental.Application.DrivingLicenceCategory.Queries
{
    public class GetDrivingLicenceCategoryByIdQuery : IRequest<DrivingLicenceCategoryDTO>
    {
        public Guid Id { get; set; }
    }

    public class GetDrivingLicenceCategoryByIdQueryHandler : IRequestHandler<GetDrivingLicenceCategoryByIdQuery, DrivingLicenceCategoryDTO>
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public GetDrivingLicenceCategoryByIdQueryHandler(
           IRepository repository,
           IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<DrivingLicenceCategoryDTO> Handle(GetDrivingLicenceCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            if (request.Id == Guid.Empty)
            {
                throw new Common.Exceptions.ApplicationException("Invalid Id");
            }

            var drivingLicenceCategory = await _repository.GetByIdAsync<Domain.Entities.DrivingLicenceCategory>(request.Id);

            return drivingLicenceCategory != null ? _mapper.Map<DrivingLicenceCategoryDTO>(drivingLicenceCategory) : throw new NotFoundException(nameof(DrivingLicenceCategory), request.Id);
        }
    }
}