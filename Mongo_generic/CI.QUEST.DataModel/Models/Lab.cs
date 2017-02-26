using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CI.Tyre.DataModel.Models
{
   public class Lab
    {

        [BsonElement("_id")]
        public ObjectId LabId { get; set; }

        [BsonIgnore]
        public string LabTempId { get; set; }

        public string LabName { get; set; }

        public string LabCode { get; set; }



    }
}
