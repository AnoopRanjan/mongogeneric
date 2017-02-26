using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CI.Tyre.DataModel.Models
{
     public class Template
    {

        [BsonElement("_id")]
        public ObjectId TemplateId { get; set; }

        

        [BsonIgnore]
        public string TmlId
        {
            get { return TemplateId.ToString(); }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    TemplateId = ObjectId.GenerateNewId();
                }
                else
                    TemplateId = ObjectId.Parse(value);
            }
        }



        public string TemplateContent { get; set; }


        public string Title { get; set; }

        public string CellData { get; set; }       


    }
}
