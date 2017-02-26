using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;


namespace CI.Tyre.DataModel.Models
{
   public class LabTest
    {
        [BsonElement("_id")]
        public ObjectId LabTestId { get; set; }

        [BsonIgnore]
        public string LabTestTempId { get; set; }

        public string LabTestName { get; set; }

        public string LabTestCode { get; set; }

        public string INRAmount { get; set; }

        public string USDAmount { get; set; }

        public string LabName { get; set; }

        public string LabTempId { get; set; }
    }
}
