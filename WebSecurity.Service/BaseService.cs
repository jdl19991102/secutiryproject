using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using System.Data.SqlClient;
using System.Text;
using WebSecurity.Interface;
using WebSecurity.Interface.Extend;
using Microsoft.Extensions.Options;
using Z.Dapper.Plus;
using Dapper.Contrib.Extensions;

namespace WebSecurity.Service
{
   public class BaseService: IBaseService
    {

        IDbConnection _DbConnection = new SqlConnection("Database=SecuityProject;Server=192.168.2.221;Integrated Security=false;Uid=sa;Password=sa;");

        public BaseService(IOptionsMonitor<DBConnectionOption> options)
        {
            _DbConnection.ConnectionString = options.CurrentValue.Connection;
           
        }

        #region Insert新增
        public bool Insert<T>(T t) where T : class {

           
            return _DbConnection.Insert<T>(t) > 0;
        }
        public bool Insert(string sql, DynamicParameters parameters)
        {
            return _DbConnection.Execute(sql,parameters) > 0;
        }

       public  IEnumerable<T> BulkInsert<T>(IEnumerable<T> ts)
        {
            DapperPlusActionSet<T> result = _DbConnection.BulkInsert(ts);
            return result.Current;
        }
        #endregion

        #region Delete删除 
        public bool Delete<T>(int Id) where T : class
        {
            T t = _DbConnection.Get<T>(Id);
            return _DbConnection.Delete<T>(t);
        }
        public bool Delete(string sql, DynamicParameters parameters)
        {
            return _DbConnection.Execute(sql,parameters) > 0;
        }
       public  void BulkDelete<T>(IEnumerable<T> list)
        {
            _DbConnection.BulkDelete<T>(list);
        }
      
       
        #endregion

        #region Update更新
        public bool Update<T>(T t) where T : class
        {
            return _DbConnection.Update<T>(t);
        }

        public T BulkUpdate<T>(IEnumerable<T> list) where T : class
        {
            DapperPlusActionSet<T> result = _DbConnection.BulkUpdate<T>(list);
            return result.CurrentItem;
        }




        #endregion

        #region Query查询
        public T Get<T>(int Id) where T : class
        
        {
            var check=_DbConnection.Get<T>(Id);
            return check;
        }
        public IEnumerable<T> Query<T>(string sql)
        {
            return _DbConnection.Query<T>(sql);
        }
        public IEnumerable<T> GetAll<T>()where T:class {
            return _DbConnection.GetAll<T>();
        }



        #endregion





        public void Dispose()
        {
           
        }




    }
}
