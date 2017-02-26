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
    [RoutePrefix("api/task")]
    public class TaskController : ApiController
    {

        private readonly IService<TaskList> _task;

        public TaskController()
        {
            _task = new TaskService();

        }


        //post
        [HttpPost]
        [Route("createTask")]
        public HttpResponseMessage Post([FromBody] TaskList model)
        {

            try
            {
                if (model != null)
                {
                    model.TaskId = ObjectId.GenerateNewId();


                    model.HTACOrderNumber = generateHTAC();

                    _task.Insert(model);

                    return Request.CreateResponse(HttpStatusCode.OK);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "model cannot be null.");
                }

            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Something went wrong!");
            }


        }


        private string generateHTAC()
        {
            try
            {

                var tasks = _task.GetAll();

                DateTime date = DateTime.Now;
                var countTask = tasks.ToList().Count+1;
                
                string month;
                if(date.Month>=9)
                {
                    month = ("" + 00 + "" + date.Month);
                }
                else
                {
                    month = ("" + 0+ "" + date.Month);

                }

                if (countTask > 0)
                {
                    if (countTask >= 0 && countTask <= 9)
                    {
                        return ("" + 00 + "" + countTask.ToString() + "" + month.ToString() + "" + date.Year.ToString());
                    }
                    else
                    if (countTask >= 10 && countTask <= 99)
                    {

                        return ("" + 0 + "" + countTask.ToString() + "" + month.ToString() + "" + date.Year.ToString());
                    }
                    else
                    if (countTask >= 100 && countTask <= 999)
                    {
                        return ("" + countTask.ToString() + "" + month.ToString() + "" + date.Year.ToString());
                    }
                    else
                        return ("" + 1000 + "" + month.ToString() + "" + date.Year);
                }
                else
                {
                    return ("" + (001).ToString() + "" + month.ToString() + "" + date.Year);
                }

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [HttpGet]
        public HttpResponseMessage getAllTaskList()
        {

            try
            {
                var tasks = _task.GetAll().Select(s => new TaskListReturnModel
                {
                    DateOfReceiptOfSample = s.DateOfReceiptOfSample,
                    HTACOrderNumber=s.HTACOrderNumber,
                    ListOfLabsAssigned=s.ListOfLabsAssigned,
                    Orginator=s.Orginator,
                    SampleDetails=s.SampleDetails,
                    
                    TaskTempId=s.TaskId.ToString(),
                    Remarks=s.Remarks
                    
                }).ToList();
                return Request.CreateResponse(HttpStatusCode.OK, tasks);
            }
            catch(Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Something went wrong!");
            }
        }


       
    }
}
