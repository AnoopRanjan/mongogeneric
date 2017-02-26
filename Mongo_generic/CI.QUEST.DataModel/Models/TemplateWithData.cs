using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CI.Tyre.DataModel.Models
{
     public class TemplateWithData
    {

        [BsonElement("_id")]
        public ObjectId TemplateWithDataId { get; set; }

        

        [BsonIgnore]
        public string TmlWDataId
        {
            get { return TemplateWithDataId.ToString(); }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    TemplateWithDataId = ObjectId.GenerateNewId();
                }
                else
                    TemplateWithDataId = ObjectId.Parse(value);
            }
        }


        public string UniqueNumber{ get; set; }
        public string TemplateWithDataContent { get; set; }


        public string Title { get; set; }
        public string Objective { get; set; }
        public string SampleCondition { get; set; }
        public string TestCondition { get; set; }
        public string TestMethodUsed { get; set; }
        public string TestResults { get; set; }

        public string CellData { get; set; }


    }
}
