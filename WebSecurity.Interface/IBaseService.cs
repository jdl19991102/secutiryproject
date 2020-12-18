using System;
using System.Collections.Generic;
using System.Text;
using Dapper;

namespace WebSecurity.Interface
{
   public interface IBaseService:IDisposable
    {
        #region Insert新增
       public  bool Insert<T>(T t) where T : class;
        public bool Insert(string sql, DynamicParameters parameters);
        public IEnumerable<T> BulkInsert<T>(IEnumerable<T> ts);
        #endregion

        #region Delete删除
        public bool Delete<T>(int Id) where T : class;
        public bool Delete(string sql, DynamicParameters parameters);
        public void  BulkDelete<T>(IEnumerable<T> list);
        #endregion

        #region Update更新
        public bool Update<T>(T t) where T : class;

        public T BulkUpdate<T>(IEnumerable<T> list) where T:class;
        #endregion

        #region Query查询
        public IEnumerable<T> Query<T>(string sql);
        public T Get<T>(int Id) where T : class;

        public IEnumerable<T> GetAll<T>() where T:class;

       
        #endregion
    }
}
