using PhoneShop.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Phoneshop.Test
{
    public class PhoneShould
    {
        [Fact]
        public void CreateFullNameFromBrandAndType()
        {
            var phone = new Phone() { Type = "test", Brand = new Brand() { Name = "test" } };

            Assert.Equal("test test",phone.FullName);
        }
    }
}
