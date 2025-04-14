namespace CarRental.Application.CarCategories.Dtos
{
    public class CarCategoryDTO
    {
        public Guid Guid { get; set; }
        public string Description { get; set; } = null!;
    }
}