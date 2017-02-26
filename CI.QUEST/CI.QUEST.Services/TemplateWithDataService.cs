using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CI.Tyre.DataModel.Models;
using CI.Tyre.DataModel.UnitOfWork;
using CI.Tyre.Services;
using MongoDB.Bson;

namespace CI.Tyre.Services
{
   public class TemplateWithDataService: IService<TemplateWithData>
    {


        private readonly UnitOfWork _sUnitOfwork;

        public TemplateWithDataService()
        {
            _sUnitOfwork = new UnitOfWork();
        }

        public TemplateWithData Get(string id)
        {
            return _sUnitOfwork.TemplateWithDatas.Get(ObjectId.Parse(id));
        }

        public IQueryable<TemplateWithData> GetAll()
        {
            return _sUnitOfwork.TemplateWithDatas.GetAll();
        }

        public void Delete(string id)
        {
            _sUnitOfwork.TemplateWithDatas.Delete(s => s.TemplateWithDataId, ObjectId.Parse(id));
        }

        public void Insert(TemplateWithData tmplt)
        {
            _sUnitOfwork.TemplateWithDatas.Add(tmplt);
        }

        public void Update(TemplateWithData tmplt)
        {
            _sUnitOfwork.TemplateWithDatas.Update(s => s.TemplateWithDataId, tmplt.TemplateWithDataId, tmplt);
        }

        public void Delete(TemplateWithData tmplt)
        {
            throw new NotImplementedException();
        }
       
    }
}