using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using System;

namespace BPL.API.Controllers
{
    public class IdGenerator
    {
        [BsonId(IdGenerator = typeof(BsonObjectIdGenerator))]
        [NonSerialized]
        public BsonObjectId _id;

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public String ExpenseId
        {
            get
            {
                return this._id.ToString();
            }
        }

    }
}