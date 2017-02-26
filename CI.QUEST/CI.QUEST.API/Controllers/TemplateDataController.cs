using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CI.Tyre.DataModel.Models;
using CI.Tyre.Services;
using MongoDB.Bson;

namespace CI.Tyre.WebAPI.Controllers
{
    [RoutePrefix("api/templatedata")]
    public class TemplateDataController : ApiController
    {

        private readonly IService<TemplateWithData> _templateWithData;

        private readonly IService<TaskList> _task;

        public TemplateDataController()
        {
            _templateWithData = new TemplateWithDataService();
            _task = new TaskService();

        }

        public HttpResponseMessage Get(string id)
        {
            if (id == "0")

            {
                TemplateWithData templateWithData = new TemplateWithData();
                //mr.MaterialRequisitionId = id;

                return Request.CreateResponse(HttpStatusCode.OK, templateWithData);
            }
            else
            {
                var templateWithData = _templateWithData.Get(id);
                if (templateWithData != null)
                    return Request.CreateResponse(HttpStatusCode.OK, templateWithData);
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "UserTrip not found for provided id.");
            }

        }



        [HttpGet]       
        public HttpResponseMessage Get()
        {

            var templateWithDatas = _templateWithData.GetAll();
            if (templateWithDatas != null)
                return Request.CreateResponse(HttpStatusCode.OK, templateWithDatas);
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Block not found for provided id.");

        }

        [HttpPost]
        public HttpResponseMessage Post([FromBody]TemplateWithData templateWithData)
        {
            templateWithData.TmlWDataId = "";
            _templateWithData.Insert(templateWithData);
            return Request.CreateResponse(HttpStatusCode.OK, templateWithData);
        }

        [HttpPut]
        // [Route("edit/{BlockId}")]

        public HttpResponseMessage Put([FromBody]TemplateWithData templateWithData)
        {
            // department.DepId =department.ObjectId;
            _templateWithData.Update(templateWithData);
            return Request.CreateResponse(HttpStatusCode.OK, templateWithData);
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public void Delete(string id)
        {

            _templateWithData.Delete(id);

        }

        [HttpGet]
        [Route("templateTyreDropDown/{id}")]
        public HttpResponseMessage TemplateTyreDropDown(string id)
        {
            //get task from task list based on htac number
            var task = _task.GetAll().FirstOrDefault(s => s.TaskId == ObjectId.Parse(id));

            var taskHTACNumber = task.HTACOrderNumber;
            if (taskHTACNumber != null)
            {
                var templateWithData = _templateWithData.GetAll().Where(s => s.UniqueNumber.Trim().Contains(id));
                var results = templateWithData
               .ToList()
               .Select(s => new TemplateWithData
               {
               //  IsActive = s.IsActive,
               TemplateWithDataId = s.TemplateWithDataId,
                   TemplateWithDataContent = s.TemplateWithDataContent,
                   TmlWDataId = s.TmlWDataId,
                   UniqueNumber = s.UniqueNumber,
                   Objective = s.Objective,
                   SampleCondition = s.SampleCondition,
                   TestCondition = s.TestCondition,
                   TestMethodUsed = s.TestMethodUsed,
                   TestResults = s.TestResults,
                   Title = s.Title

               });
                return Request.CreateResponse(HttpStatusCode.OK, results);
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Block not found for provided id.");
            }
        }

        [HttpGet]
        [Route("templateTyreTableList/{id}")]
        public HttpResponseMessage TemplateTyreTableList(string id)
        {
            var templateWithData = _templateWithData.GetAll();
            var results = templateWithData
            .ToList()
            .Select(s => new TemplateWithData
            {
               //  IsActive = s.IsActive,
               TmlWDataId = s.TmlWDataId,
                TemplateWithDataContent = s.TemplateWithDataContent,
                UniqueNumber = s.UniqueNumber,
                Title=s.Title

            }).Where(f=>f.UniqueNumber==id);
           var TemplateWithDataContent = "";
            foreach (var item in results)
            {
               TemplateWithDataContent = TemplateWithDataContent + "<h4>"+item.Title+"</h4><br>";

               TemplateWithDataContent =  TemplateWithDataContent +"<table>"+ item.TemplateWithDataContent + "</table></br></br></br>";
            }

            var resultone = templateWithData           
           .Select(s => new TemplateWithData
           {
                //  IsActive = s.IsActive,
                TmlWDataId = s.TmlWDataId,               
               UniqueNumber = s.UniqueNumber,
               Objective = s.Objective,
               SampleCondition = s.SampleCondition,
               TestCondition =s.TestCondition,
               TestMethodUsed = s.TestMethodUsed,
               TestResults = s.TestResults,

           }).Where(f => f.UniqueNumber == id).Last();

            resultone.TemplateWithDataContent = TemplateWithDataContent;
            return Request.CreateResponse(HttpStatusCode.OK, resultone);
        }


    }
}
