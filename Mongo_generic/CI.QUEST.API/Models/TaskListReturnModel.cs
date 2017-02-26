using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CI.Tyre.WebAPI.Models
{
    public class TaskListReturnModel
    {

        public string TaskTempId { get; set; }

        public string TaskName { get; set; }

        public string HTACOrderNumber { get; set; }

        public string SampleDetails { get; set; }

        public string Orginator { get; set; }
        public string DateOfReceiptOfSample { get; set; }

        public string ListOfLabsAssigned { get; set; }

        public string Remarks { get; set; }

    }
}