using Artanis.Model.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Artanis.Repository.Common
{
    public interface IBaseRepository<T> 
    {
        ResponseModel<int> Insert(T entityu);
    }
}
