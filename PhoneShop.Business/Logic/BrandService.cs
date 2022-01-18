using PhoneShop.Business.Interfaces;
using PhoneShop.Data.Entities;
using PhoneShop.Data.Interfaces;
using System;

namespace PhoneShop.Business.Logic
{
    public class BrandService : IBrandService
    {
        private readonly IRepository<Brand> brandRepository;

        public BrandService(IRepository<Brand> brandRepository)
        {
            this.brandRepository = brandRepository;
        }

        public Brand GetOrCreate(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException(nameof(name));


            var result = brandRepository.Get(b => b.Name == name);

            if (result == null)
            {
                Create(new Brand(){Name = name });
                return GetOrCreate(name);
            }

            return result;
        }

        public void Create(Brand brand)
        {
            brandRepository.Create(brand);
        }
    }
}
