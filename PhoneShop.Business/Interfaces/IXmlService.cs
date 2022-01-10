using PhoneShop.Data.Entities;
using System.Collections.Generic;
using System.IO;

namespace PhoneShop.Business.Interfaces
{
    public interface IXmlService
    {
        List<Phone> Read(TextReader xml);
        string GetConnectionString(string location);
    }
}
