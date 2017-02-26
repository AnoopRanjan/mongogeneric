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
   public class TemplateService: IService<Template>
    {


        private readonly UnitOfWork _sUnitOfwork;

        public TemplateService()
        {
            _sUnitOfwork = new UnitOfWork();
        }

        public Template Get(string id)
        {
            return _sUnitOfwork.Templates.Get(ObjectId.Parse(id));
        }

        public IQueryable<Template> GetAll()
        {
            return _sUnitOfwork.Templates.GetAll();
        }

        public void Delete(string id)
        {
            _sUnitOfwork.Templates.Delete(s => s.TemplateId, ObjectId.Parse(id));
        }

        public void Insert(Template tmplt)
        {
            _sUnitOfwork.Templates.Add(tmplt);
        }

        public void Update(Template tmplt)
        {
            _sUnitOfwork.Templates.Update(s => s.TemplateId, tmplt.TemplateId, tmplt);
        }

        public void Delete(Template tmplt)
        {
            throw new NotImplementedException();
        }
       
    }
}