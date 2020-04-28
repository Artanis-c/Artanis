using System;
using System.Collections.Generic;
using System.Text;

namespace Artanis.Model.Common
{
    public class ResponseModel<T>
    {

        public bool Successful { get; set; }

        public string Message { get; set; }

        public T data { get; set; }

        public ResponseModel<T> Ok(T data)
        {
            return new ResponseModel<T>
            {
                data = data,
                Message = "操作成功",
                Successful = true
            };
        }

        publicR

    }
}
