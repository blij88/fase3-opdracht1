using PhoneShop.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace PhoneShop.Business.Repositories
{
    internal class EFRepository<T> : Data.Interfaces.IRepository<T> where T : class
    {
        public Func<SqlDataReader, T> Mapper { set => throw new NotImplementedException(); }

        public void ExecuteNonQuery(SqlCommand command)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> ExecuteStoredProc(SqlCommand command, string CountColName = "TotalCount")
        {
            throw new NotImplementedException();
        }

        public void GetDataCount(int count)
        {
            throw new NotImplementedException();
        }

        public T GetRecord(SqlCommand command)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetRecords(SqlCommand command)
        {
            throw new NotImplementedException();
        }

        public void Status(bool IsError, string strErrMsg)
        {
            throw new NotImplementedException();
        }
    }
}
