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
    public class LabTestService : IService<LabTest>
    {

        private readonly UnitOfWork _sUnitOfwork;

        public LabTestService()
        {
            _sUnitOfwork = new UnitOfWork();
        }

        public LabTest Get(string id)
        {
            return _sUnitOfwork.labTest.Get(ObjectId.Parse(id));
        }

        public IQueryable<LabTest> GetAll()
        {
            return _sUnitOfwork.labTest.GetAll();
        }

        public void Delete(string id)
        {
            _sUnitOfwork.labTest.Delete(s => s.LabTestId, ObjectId.Parse(id));
        }

        public void Insert(LabTest lab)
        {
            _sUnitOfwork.labTest.Add(lab);
        }

        public void Update(LabTest lab)
        {
            _sUnitOfwork.labTest.Update(s => s.LabTestId, lab.LabTestId, lab);
        }


    }
}
