using MySql.Data.MySqlClient;
using PW_3_4.Database;
using PW_3_4.MyEntity;
using System;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;

namespace PW_3_4.Database
{
    public abstract class EntityDAO : Entity
    {
        public abstract void Add();
        public abstract void Remove();
        public abstract void Change();
        public abstract void Find();
        protected abstract void Update<T>(string operation, T entity, int Id);
        public abstract void GetList();
       
    }

}
