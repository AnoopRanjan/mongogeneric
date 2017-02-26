using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CI.Tyre.DataModel.Models
{
    public  class TaskList
    {
        [BsonElement("_id")]
        public ObjectId TaskId { get; set; }

        public string TaskTempId { get; set; }

        //[BsonIgnore]
        //public string TaskName { get; set; }

        public string  HTACOrderNumber { get; set; }

        public string SampleDetails { get; set; }

        public string Orginator { get; set; }
        public string DateOfReceiptOfSample { get; set; }

        public string ListOfLabsAssigned { get; set; }

        public string Remarks { get; set; }
       
    }
}
