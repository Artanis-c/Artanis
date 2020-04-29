using Artanis.Core.Model;
using Artanis.Model.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Artanis.Repository.Common
{
    public interface IBaseRepository<T> where T:ITableModel
    {
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        ResponseModel<T> Insert(T entity);


        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="parms">要修改的字段</param>
        /// <param name="condition">修改的条件字符串不带where</param>
        /// <returns></returns>
        ResponseModel<int> Update(dynamic parms, string condition);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        ResponseModel<int> Delete(dynamic condition);

        /// <summary>
        /// 获取实体，包含全部字段
        /// </summary>
        /// <param name="condition">查询条件</param>
        /// <returns></returns>
        ResponseModel<T> GetEntity(dynamic condition);

        /// <summary>
        /// 获取实体，包含全部字段
        /// </summary>
        /// <param name="sqlCondition">字符串查询条件，不带where</param>
        /// <returns></returns>
        ResponseModel<T> GetEntity(string sqlCondition);
    }
}
