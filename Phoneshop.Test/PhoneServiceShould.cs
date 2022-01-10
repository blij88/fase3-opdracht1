using Moq;
using PhoneShop.Business.Interfaces;
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
        private Mock<IBrandService> localBrand;
        private PhoneService phoneService;
        private Mock<IRepository<Phone>> localMock;

        public PhoneServiceShould()
        {
            var repoMock = new Mock<IRepository<Phone>>();
            repoMock.Setup(r => r.GetRecords(It.IsAny<SqlCommand>())).Returns(new List<Phone>() { new Phone() { Id = 1 } });
            localMock = repoMock;
            var brand = new Mock<IBrandService>();
            brand.Setup(b=> b.GetOrCreate(It.IsAny<string>())).Returns(new Brand() { Id = 1 });
            localBrand = brand;

            phoneService = new PhoneService(repoMock.Object, brand.Object);

        }

        [Fact]
        public void GetSinglePhone()
        {

            localMock.Setup(r => r.GetRecord(It.IsAny<SqlCommand>())).Returns(new Phone() { Id = 1 });
            var phone = phoneService.Get(1);
            Assert.Equal(1 , phone.Id);
        }
        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void GetAboveOrEqualtoZero(int id)
        {

            localMock.Setup(r => r.GetRecord(It.IsAny<SqlCommand>())).Returns(new Phone() { Id = 1 });


            var phone = phoneService.Get(id);
            
            
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
        public void NotCreateAPhoneThatAlreadyExisting()
        {

            localMock.Setup(r => r.GetRecord(It.IsAny<SqlCommand>())).Returns(new Phone() { Id = 1 });


            Assert.ThrowsAny<System.Exception>(() => phoneService.Create(new Phone()));
        }
        [Fact]
        public void CreateANewPhone()
        {

            localMock.Setup(r => r.GetRecord(It.IsAny<SqlCommand>())).Returns((Phone)null);


            phoneService.Create(new Phone() { Description = "ghagdjwhj", Type = "vgjfaje", Price = 78, Stock = 9, Brand = new Brand() { Name = "hjfehejkf", Id = 1 }, BrandId = 1 });


            localBrand.Verify(b => b.GetOrCreate(It.IsAny<string>()), Times.Once);
            localMock.Verify( r => r.ExecuteNonQuery(It.IsAny<SqlCommand>()), Times.Once);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void NotDeletPhoneWithIdLessThanOrEqualToZero(int id)
        {
            Assert.Throws<System.ArgumentNullException>(() => phoneService.Delete(id));
        }


    }
}
