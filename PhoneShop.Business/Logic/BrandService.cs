using PhoneShop.Business.Extensions;
using PhoneShop.Business.Interfaces;
using PhoneShop.Data.Entities;
using PhoneShop.Data.Interfaces;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.CodeAnalysis;

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


                var result = brandRepository.Get(name);

                if (result == null)
                {
                    Create(new Brand {  });
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
