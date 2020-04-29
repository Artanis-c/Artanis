using System;
using System.Collections.Generic;
using System.Text;
/*
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * 
 *                                                                                 *
 *                                                                                 *
 * Author: Tom.cui                                                                 *
 *                                                                                 *
 * Date: 2020-04                                                                   *
 *                                                                                 *
 * Describe: 博客园地址：https://www.cnblogs.com/Tassdar/  本项目纯属个人爱好，    *
 * 喜欢的欢迎Start,不喜勿喷，欢迎提出优化建议，旨在为.net core 社区贡献一份力量    *
 *                                                                                 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * 
*/
namespace Artanis.Model.Common
{
    /// <summary>
    /// 通用标准返回体
    /// </summary>
    /// <typeparam name="T"></typeparam>
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

        public ResponseModel<T> Ok(T data,string msg)
        {
            return new ResponseModel<T>
            {
                data = data,
                Message = msg,
                Successful = true
            };
        }


        public ResponseModel<T> Fail()
        {
            return new ResponseModel<T>
            {
                Message = "操作失败",
                Successful = false
            };
        }

        public ResponseModel<T> Fail(string msg)
        {
            return new ResponseModel<T>
            {
                Message = msg,
                Successful = false
            };
        }

        public ResponseModel<T> Fail(T data)
        {
            return new ResponseModel<T>
            {
                data=data,
                Message = "操作失败",
                Successful = false
            };
        }

        public ResponseModel<T> Fail(T data, string msg)
        {
            return new ResponseModel<T>
            {
                Message = msg,
                Successful = false
            };
        }


    }
}
