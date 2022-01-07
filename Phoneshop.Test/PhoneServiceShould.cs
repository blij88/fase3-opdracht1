using Moq;
using PhoneShop.Business.Logic;
using PhoneShop.Data.Entities;
using PhoneShop.Data.Interfaces;
using System.Collections.Generic;
using System.Data.SqlClient;
using Xunit;

namespace Phoneshop.Test
{

    public class PhoneServiceShould
    {
        private PhoneService phoneService;


        public PhoneServiceShould()
        {
            var repoMock = new Mock<IRepository<Phone>>();
            repoMock.Setup(r => r.GetRecord(It.IsAny<SqlCommand>())).Returns(new Phone() { Id = 1 });
            repoMock.Setup(r => r.GetRecords(It.IsAny<SqlCommand>())).Returns(new List<Phone>() { new Phone() { Id = 1 } });

            var brand = new Mock<IBrandService>();
            brand.Setup(b=> b.GetOrCreate(It.IsAny<string>())).Returns(new Brand() { Id = 1 });

            phoneService = new PhoneService(repoMock.Object, brand.Object);

        }

        [Fact]
        public void GetSinglePhone()
        {
            var phone = phoneService.Get(1);
            Assert.Equal(1 , phone.Id);
        }
        [Fact]
        public void GetAboveOrEqualtoZero()
        {
            var phone = phoneService.Get(-1);
            Assert.Null(phone);
        }

        [Fact]
        public void GetAllPhones()
        {
            var phones = phoneService.Get();
            Assert.NotEmpty(phones);
        }

        [Fact]
        public void SearchAllPhones()
        {
            var phones = phoneService.Search("blahblah");
            Assert.NotEmpty(phones);
        }
        [Fact]
        public void SearchNullThrowsException()
        {
           Assert.Throws<System.ArgumentNullException>(()=> phoneService.Search(null));
        }

        [Fact]
        public void NotCreatePhoneAlreadyExisting()
        {
            Assert.ThrowsAny<System.Exception>(() => phoneService.Create(new Phone()));
        }

        [Fact]
        public void NotDeletPhoneWithIdLessThanOrEqualToZero()
        {
            Assert.Throws<System.ArgumentNullException>(() => phoneService.Delete(-5));

            Assert.Throws<System.ArgumentNullException>(() => phoneService.Delete(0));
        }


    }
}
