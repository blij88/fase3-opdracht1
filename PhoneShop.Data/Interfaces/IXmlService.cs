using PhoneShop.Data.Entities;
using System.Collections.Generic;
using System.IO;

namespace PhoneShop.Data.Interfaces
{
    public interface IXmlService
    {
        List<Phone> Read(TextReader xml);
    }
}
