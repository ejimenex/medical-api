using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Interface
{
    public interface IGetData<T>
    {
        IEnumerable<T> GetData();
    }
}
