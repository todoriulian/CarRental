using CarRental.Application.Common.Mapping;
using CarRental.Domain.Entities;

namespace CarRental.Application.CarCategories.Dtos
{
    public class CarCategoryDTO : IMapFrom<CarCategory>
    {
        public Guid Guid { get; set; }
        public string Description { get; set; } = null!;
    }
}