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
    [RoutePrefix("api/lab")]
    public class LabController : ApiController
    {
        private readonly IService<Lab> _lab;
        public LabController()
        {
            _lab = new LabsService();

        }

        [HttpPost]
        [Route("createLab")]
        public HttpResponseMessage Post([FromBody]Lab labModel)
        {
            try
            {
               if(labModel!=null)
                {
                    labModel.LabId = ObjectId.GenerateNewId();
                    _lab.Insert(labModel);
                    return Request.CreateResponse(HttpStatusCode.OK);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Model cannot be null.");
                }

            }catch(Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Something went wrong! Try Later.");
            }
        }


        //put
        [HttpPut]
        [Route("updateLab")]
        public HttpResponseMessage Put([FromBody]Lab labModel)
        {
            try
            {
                if (labModel != null)
                {
                    labModel.LabId = ObjectId.Parse(labModel.LabTempId);
                    _lab.Update(labModel);
                    return Request.CreateResponse(HttpStatusCode.OK);
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
              
                var labs = _lab.GetAll().Select(s => new LabReturnModel {
                    LabCode = s.LabCode,
                    LabName = s.LabName,
                    LabTempId = s.LabId.ToString()
                    
              }).ToList();
            return Request.CreateResponse(HttpStatusCode.OK,labs);
               
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Something went wrong! Try Later.");
            }
        }





    }
}
