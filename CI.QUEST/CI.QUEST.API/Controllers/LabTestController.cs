using CI.Tyre.DataModel.Models;
using CI.Tyre.Services;
using CI.Tyre.WebAPI.Models;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CI.Tyre.WebAPI.Controllers
{
    [RoutePrefix("api/LabTest")]
    public class LabTestController : ApiController
    {
        private readonly IService<LabTest> _labTest;
        private readonly IService<Lab> _lab;
        public LabTestController()
        {
            _labTest = new LabTestService();
            _lab = new LabsService();
        }

        [HttpPost]
        [Route("createLabTest")]
        public HttpResponseMessage Post([FromBody]LabTest labModel)
        {
            try
            {
                if (labModel != null)
                {
                    
                    labModel.LabTestId = ObjectId.GenerateNewId();
                    var lab = _lab.GetAll().Where(s => s.LabName == labModel.LabName);

                    if (lab.Any())
                    {
                        labModel.LabTempId = (lab.FirstOrDefault(s => s.LabName == labModel.LabName).LabId).ToString();
                        _labTest.Insert(labModel);
                        return Request.CreateResponse(HttpStatusCode.OK);
                    }
                    else
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Lab cannot be found.");
                    }
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Model cannot be null.");
                }

            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Something went wrong! Try Later.");
            }
        }


        //put
        [HttpPut]
        [Route("updateLabTest")]
        public HttpResponseMessage Put([FromBody]LabTest labModel)
        {
            try
            {
                if (labModel != null)
                {
                    labModel.LabTestId = ObjectId.Parse(labModel.LabTestTempId);
                    var lab = _lab.GetAll().Where(s => s.LabName == labModel.LabName);
                    if (lab.Any())
                    {
                        labModel.LabTempId = (lab.FirstOrDefault(s => s.LabName == labModel.LabName).LabId).ToString();
                    
                        _labTest.Update(labModel);
                        return Request.CreateResponse(HttpStatusCode.OK);
                    }
                    else
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Lab cannot be found.");
                    }
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Model cannot be null.");
                }

            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Something went wrong! Try Later.");
            }
        }


        //put
        [HttpGet]
        [Route("getAll")]
        public HttpResponseMessage getAll()
        {
            try
            {

                var labs = _labTest.GetAll().Select(s => new LabTestReturnModel
                {
                    LabTestTempId = s.LabTestId.ToString(),
                    INRAmount = s.INRAmount,
                    LabTempId = s.LabTempId,
                    LabName = s.LabName,
                    LabTestCode = s.LabTestCode,
                    LabTestName = s.LabTestName,
                    USDAmount = s.USDAmount

                }).ToList();
                return Request.CreateResponse(HttpStatusCode.OK, labs);

            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Something went wrong! Try Later.");
            }
        }





    }
}
