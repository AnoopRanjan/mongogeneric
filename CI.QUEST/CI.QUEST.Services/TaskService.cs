using CI.Tyre.DataModel.Models;
using CI.Tyre.DataModel.UnitOfWork;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CI.Tyre.Services
{
     public class TaskService :IService<TaskList>
    {
        private readonly UnitOfWork _sUnitOfwork;

        public TaskService()
        {
            _sUnitOfwork = new UnitOfWork();
        }

        public TaskList Get(string id)
        {
            return _sUnitOfwork.task.Get(ObjectId.Parse(id));
        }

        public IQueryable<TaskList> GetAll()
        {
            return _sUnitOfwork.task.GetAll();
        }

        public void Delete(string id)
        {
            _sUnitOfwork.task.Delete(s => s.TaskId, ObjectId.Parse(id));
        }

        public void Insert(TaskList Task)
        {
            _sUnitOfwork.task.Add(Task);
        }

        public void Update(TaskList Task)
        {
            _sUnitOfwork.task.Update(s => s.TaskId, Task.TaskId, Task);
        }

    }
}
