using PhoneShop.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace PhoneShop.Business.Repositories
{
    internal class EFRepository<T> : IRepository<T> where T : class
    {
    }
}
