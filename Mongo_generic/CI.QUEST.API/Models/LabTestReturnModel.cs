using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CI.Tyre.WebAPI.Models
{
    public class LabTestReturnModel
    {
        public string LabTestTempId { get; set; }

        public string LabTestName { get; set; }

        public string LabTestCode { get; set; }

        public string INRAmount { get; set; }

        public string USDAmount { get; set; }

        public string LabName { get; set; }

        public string LabTempId { get; set; }
    }
}