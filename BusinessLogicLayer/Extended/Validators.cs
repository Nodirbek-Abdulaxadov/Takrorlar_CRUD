using BusinessLogicLayer.Dtos.Computer;
using DataAccessLayer.Entities;

namespace BusinessLogicLayer.Extended;
public static class Validators
{
    public static bool IsValid(this AddComputerDto dto)
        => !string.IsNullOrEmpty(dto.Name) &&
           !string.IsNullOrEmpty(dto.Description) &&
           !string.IsNullOrEmpty(dto.Brand) &&
           dto.Price > 0 &&
           !string.IsNullOrEmpty(dto.ImageUrl);

    public static bool IsEquals(this Computer? x, Computer? y)
        => x.Name == y.Name &&
           x.Description == y.Description &&
           x.Price == y.Price &&
           x.ImageUrl == y.ImageUrl &&
           x.Brand == y.Brand;
}