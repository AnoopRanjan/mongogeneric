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
    [RoutePrefix("api/template")]
    public class TemplateController : ApiController
    {

        private readonly IService<Template> _template;

        public TemplateController()
        {
            _template = new TemplateService();

        }

        public HttpResponseMessage Get(string id)
        {
            if (id == "0")

            {
                Template template = new Template();
                //mr.MaterialRequisitionId = id;

                return Request.CreateResponse(HttpStatusCode.OK, template);
            }
            else
            {
                var template = _template.Get(id);
                if (template != null)
                    return Request.CreateResponse(HttpStatusCode.OK, template);
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "UserTrip not found for provided id.");
            }

        }



        [HttpGet]       
        public HttpResponseMessage Get()
        {

            var templates = _template.GetAll();
            if (templates != null)
                return Request.CreateResponse(HttpStatusCode.OK, templates);
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Block not found for provided id.");

        }

        [HttpPost]
        public HttpResponseMessage Post([FromBody]Template template)
        {
            template.TmlId = "";
            _template.Insert(template);
            return Request.CreateResponse(HttpStatusCode.OK, template);
        }

        [HttpPut]
        // [Route("edit/{BlockId}")]

        public HttpResponseMessage Put([FromBody]Template template)
        {
            // department.DepId =department.ObjectId;
            _template.Update(template);
            return Request.CreateResponse(HttpStatusCode.OK, template);
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public void Delete(string id)
        {

            _template.Delete(id);

        }

       
        [HttpGet]
        [Route("templateTyreDropDown")]
        public HttpResponseMessage TemplateTyreDropDown()
        {
            var template = _template.GetAll(); 
            var results = template.ToList()
           .Select(s => new Template
           {
               //  IsActive = s.IsActive,
               TemplateId = s.TemplateId,
               TemplateContent = s.TemplateContent,
               Title = s.Title,
               CellData = s.CellData

           });
            return Request.CreateResponse(HttpStatusCode.OK, results);
        }

    }
}
