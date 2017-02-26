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
    public class LabsService : IService<Lab>
    {

        private readonly UnitOfWork _sUnitOfwork;

        public LabsService()
        {
            _sUnitOfwork = new UnitOfWork();
        }

        public Lab Get(string id)
        {
            return _sUnitOfwork.labs.Get(ObjectId.Parse(id));
        }

        public IQueryable<Lab> GetAll()
        {
            return _sUnitOfwork.labs.GetAll();
        }

        public void Delete(string id)
        {
            _sUnitOfwork.labs.Delete(s => s.LabId, ObjectId.Parse(id));
        }

        public void Insert(Lab lab)
        {
            _sUnitOfwork.labs.Add(lab);
        }

        public void Update(Lab lab)
        {
            _sUnitOfwork.labs.Update(s => s.LabId, lab.LabId, lab);
        }


    }
}
