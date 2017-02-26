using MongoDB.Bson;
using CI.Tyre.DataModel.Models;
using System.Collections.Generic;
using System.Linq;

namespace CI.Tyre.Services
{
    public interface IService<T> where T : class
    {
        void Insert(T student);
        T Get(string id);
        IQueryable<T> GetAll();
       void Delete(string id);
        //void Delete(T student);
        void Update(T student);
        //List<dynamic> GetDynamicData();
        //void UpdateOneAsyn(T student);
    }
}
