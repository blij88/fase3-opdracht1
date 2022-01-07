using PhoneShop.Data.Entities;

namespace PhoneShop.Data.Interfaces
{
    public interface IBrandService
    {
        void Create(Brand brand);
        Brand GetOrCreate(string name);
    }
}