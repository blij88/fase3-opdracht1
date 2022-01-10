using Moq;
using PhoneShop.Business.Interfaces;
using PhoneShop.Business.Logic;
using PhoneShop.Data.Entities;
using System;
using System.Data.SqlClient;
using Xunit;

namespace Phoneshop.Test
{
    public class BrandServiceShould
    {
        private readonly BrandService brandService;
        private readonly string testName;
        private readonly Brand _testBrand;
        private readonly Mock<IRepository<Brand>> _mockRepo;

        public BrandServiceShould()
        {
            testName = "Motorola";
            _testBrand = new Brand() { Id = 1, Name = testName };
            var mockRepo = new Mock<IRepository<Brand>>();
            _mockRepo = mockRepo;

            brandService = new BrandService(mockRepo.Object);
        }

        [Fact]
        public void GetExistingBrand()
        {
            _mockRepo.Setup(r => r.GetRecord(It.IsAny<SqlCommand>())).Returns(_testBrand);
            var brand = brandService.GetOrCreate(testName);

            _mockRepo.Verify(r => r.GetRecord(It.IsAny<SqlCommand>()), Times.Once);
            Assert.Equal(testName, brand.Name);
        }
        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void ThrowExceptionwithEmptyStringOrNull(string name)
        {
            Assert.Throws<ArgumentNullException>(() => brandService.GetOrCreate(name));
        }
        [Fact]
        public void CreateIfBrandDoesNotExist()
        {
            
            Brand testBrand = null;
            _mockRepo.Setup(r => r.GetRecord(It.IsAny<SqlCommand>())).Returns(() =>testBrand).Callback(() => testBrand = _testBrand) ;


            var brand = brandService.GetOrCreate(testName);

            _mockRepo.Verify(r => r.GetRecord(It.IsAny<SqlCommand>()), Times.Exactly(2));
            _mockRepo.Verify(r => r.ExecuteNonQuery(It.IsAny<SqlCommand>()), Times.Once);
            Assert.Equal(testName, brand.Name);
        }

        [Fact]
        public void CreateNewBrand()
        {
            brandService.Create(_testBrand);
            _mockRepo.Verify(r => r.ExecuteNonQuery(It.IsAny<SqlCommand>()), Times.Once);
        }

    }
}
