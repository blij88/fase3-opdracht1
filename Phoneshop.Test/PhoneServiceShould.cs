using Moq;
using PhoneShop.Business.Interfaces;
using PhoneShop.Business.Logic;
using PhoneShop.Data.Entities;
using PhoneShop.Data.Interfaces;
using System.Collections.Generic;
using Xunit;

namespace Phoneshop.Test
{

    public class PhoneServiceShould
    {
        private Mock<IBrandService> localBrand;
        private PhoneService phoneService;
        private Phone samplePhone;
        private Mock<IRepository<Phone>> localMock;

        public PhoneServiceShould()
        {
            var repoMock = new Mock<IRepository<Phone>>();
            repoMock.Setup(r => r.GetQueryIncludes(It.IsNotNull<System.Linq.Expressions.Expression<System.Func<Phone, object>>>())).Returns(new List<Phone>() { new Phone() { Id = 1 } });
            localMock = repoMock;

            var brand = new Mock<IBrandService>();
            brand.Setup(b => b.GetOrCreate(It.IsAny<string>())).Returns(new Brand() { Id = 1 });
            localBrand = brand;

            phoneService = new PhoneService(repoMock.Object, brand.Object);

            samplePhone = new Phone() { Id = 1, Description = "ghagdjwhj", Type = "vgjfaje", Price = 78, Stock = 9, Brand = new Brand() { Name = "hjfehejkf", Id = 1 }, BrandId = 1 };
        }

        [Fact]
        public void GetSinglePhone()
        {

            localMock.Setup(r => r.Get(It.IsAny<int>())).Returns(samplePhone);
            var phone = phoneService.Get(samplePhone.Id);
            Assert.Equal(samplePhone.Id, phone.Id);
        }
        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void NotGetWithIdBelowOrEqualtoZero(int id)
        {

            localMock.Setup(r => r.Get(It.IsAny<int>())).Returns(samplePhone);


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
            Assert.Throws<System.ArgumentNullException>(() => phoneService.Search(null));
        }

        [Fact]
        public void NotCreateAPhoneThatAlreadyExists()
        {

            localMock.Setup(r => r.Get(It.IsAny<int>())).Returns(samplePhone);


            Assert.ThrowsAny<System.Exception>(() =>
            phoneService.Create(samplePhone));
        }
        [Fact]
        public void CreateANewPhone()
        {

            localMock.Setup(r => r.Get(It.IsAny<int>())).Returns((Phone)null);


            phoneService.Create(samplePhone);


            localBrand.Verify(b => b.GetOrCreate(It.IsAny<string>()), Times.Once);
            localMock.Verify(r => r.Create(It.IsAny<Phone>()), Times.Once);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void NotDeletPhoneWithIdLessThanOrEqualToZero(int id)
        {
            Assert.Throws<System.ArgumentNullException>(() => phoneService.Delete(id));
        }
        [Fact]
        public void DeleteAPhone()
        {
            localMock.Setup(r => r.Get(It.IsAny<int>())).Returns(samplePhone);

            phoneService.Delete(samplePhone.Id);

            localMock.Verify(r => r.Delete(It.IsAny<int>()), Times.Once);
        }
        [Fact]
        public void CreateAListOfPhones()
        {
            //setup
            localMock.Setup(r => r.Get(It.IsAny<int>())).Returns((Phone)null);


            phoneService.Create(new List<Phone>() {
                samplePhone,
                samplePhone });

            localMock.Verify(r => r.Create(It.IsAny<Phone>()), Times.Exactly(2));


        }
    }
}
