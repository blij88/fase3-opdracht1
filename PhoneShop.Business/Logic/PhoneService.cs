using PhoneShop.Business.Interfaces;
using PhoneShop.Data.Entities;
using PhoneShop.Data.Interfaces;
using System;
using System.Collections.Generic;

namespace PhoneShop.Business.Logic
{
    public class PhoneService : IPhoneService
    {

        private readonly IRepository<Phone> phoneRepository;
        private readonly IBrandService brandService;

        public PhoneService(IRepository<Phone> phoneRepository, IBrandService brandService)
        {
            this.phoneRepository = phoneRepository;
            this.brandService = brandService;
        }

        public Phone Get(int id)
        {
            if (id <= 0) return null;
            return phoneRepository.Get(id);

        }

        public IEnumerable<Phone> Get()
        {
            {
                return phoneRepository.GetQueryIncludes(a => a.Brand);
            }
        }

        public IEnumerable<Phone> Search(string query)
        {
            if (string.IsNullOrEmpty(query))
                throw new ArgumentNullException(nameof(query));

            var moviesFromDb = phoneRepository.GetQueryIncludes(a => a.Brand);

            return moviesFromDb;
        }

        public void Create(Phone phone)
        {
            var found = phoneRepository
                .Get(phone.Id);

            if (found != null)
                throw new Exception($"Phone {phone.Brand.Name} - {phone.Type} already exists");

            brandService.GetOrCreate(phone.Brand.Name);


            phoneRepository.Create(phone);
        }

        public void Create(List<Phone> phones)
        {
            foreach (var item in phones)
                Create(item);
        }

        public void Delete(int id)
        {
            if (id <= 0)
                throw new ArgumentNullException(nameof(id));


            phoneRepository.Delete(id);
        }

    }
}
