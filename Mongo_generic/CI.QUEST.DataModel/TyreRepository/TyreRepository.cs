using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;

namespace CI.Tyre.DataModel.QuestRepository
{
   public class TyreRepository<T> where T : class
    {
        private MongoDatabase _database;
        private string _tableName;
        private MongoCollection<T> _collection;



        public TyreRepository(MongoDatabase db, string tblName)
        {
            _database = db;
            _tableName = tblName;
            _collection = _database.GetCollection<T>(tblName);

        }
        /// <summary>
        /// Generic Get method to get record on the basis of id
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public T Get(ObjectId i)
        {
            return _collection.FindOneById(i);

        }

        /// <summary>
        /// Get all records 
        /// </summary>
        /// <returns></returns>
        public IQueryable<T> GetAll()
        {

            //var cursor = _database.GetCollection<dynamic>("expenses").FindAll();
            //var list= cursor.ToList();
            MongoCursor<T> cursor = _collection.FindAll();
            return cursor.AsQueryable<T>();

        }

        public List<dynamic> GetDynamicData()
        {

            var cursor = _database.GetCollection<dynamic>("quest").FindAll();
            return cursor.ToList(); ;

        }

        /// <summary>
        /// Generic add method to insert enities to collection 
        /// </summary>
        /// <param name="entity"></param>
        public void Add(T entity)
        {
            _collection.Insert(entity);
        }

        /// <summary>
        /// Generic delete method to delete record on the basis of id
        /// </summary>
        /// <param name="queryExpression"></param>
        /// <param name="id"></param>
        public void Delete(Expression<Func<T, ObjectId>> queryExpression, ObjectId id)
        {
            var query = Query<T>.EQ(queryExpression, id);
            _collection.Remove(query);
        }

        /// <summary>
        ///  Generic update method to delete record on the basis of id
        /// </summary>
        /// <param name="queryExpression"></param>
        /// <param name="id"></param>
        /// <param name="entity"></param>
        public void Update(Expression<Func<T, ObjectId>> queryExpression, ObjectId id, T entity)
        {
            var query = Query<T>.EQ(queryExpression, id);
            _collection.Update(query, Update<T>.Replace(entity));
        }

        //public void UpdateOneAsyn(Scenario entity)
        // {
        //     var query = Query<Scenario>.EQ("ScenarioId", entity.ScenarioId);
        //     var filter = Builders<BsonDocument>.Filter.Eq("ScenarioId", entity.ScenarioId);
        //     var update = Builders<BsonDocument>.Update.Set("entity.ExpenseData", entity.ExpenseData);
        //     _collection.Update(query,update,true);
        // }

        public T GetScenario(int i)
        {
            return _collection.FindOneById(i);

        }
    }
}
