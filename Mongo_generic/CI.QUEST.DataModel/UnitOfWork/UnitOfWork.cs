using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CI.Tyre.DataModel.QuestRepository;
using MongoDB.Driver;
using CI.Tyre.DataModel.Models;

namespace CI.Tyre.DataModel.UnitOfWork
{
    public class UnitOfWork
    {
        private MongoDatabase _database;


        public TyreRepository<Template> _templates;
        public TyreRepository<TemplateWithData> _templatesWithData;

        public TyreRepository<Lab> _labs;
        public TyreRepository<LabTest> _labTests;
        public TyreRepository<TaskList> _tasks;
        public UnitOfWork()
        {
            var connectionString = ConfigurationManager.AppSettings["MongoDBConectionString"];
            var client = new MongoClient(connectionString);
            var server = client.GetServer();
            var databaseName = ConfigurationManager.AppSettings["MongoDBDatabaseName"];
            _database = server.GetDatabase(databaseName);
        }


        //Template 
        public TyreRepository<Template> Templates
        {
            get
            {
                if (_templates == null)
                    _templates = new TyreRepository<Template>(_database, "Template");

                return _templates;
            }
        }

        //Template Data
        public TyreRepository<TemplateWithData> TemplateWithDatas
        {
            get
            {
                if (_templatesWithData == null)
                    _templatesWithData = new TyreRepository<TemplateWithData>(_database, "TemplateWithData");

                return _templatesWithData;
            }
        }

        public TyreRepository<Lab> labs
        {
            get
            {
                if (_labs == null)
                    _labs = new TyreRepository<Lab>(_database, "Labs");

                return _labs;
            }
        }

        public TyreRepository<LabTest> labTest
        {
            get
            {
                if (_labTests == null)
                    _labTests = new TyreRepository<LabTest>(_database, "LabTest");

                return _labTests;
            }
        }

        public TyreRepository<TaskList> task
        {
            get
            {
                if (_tasks == null)
                    _tasks = new TyreRepository<TaskList>(_database, "TaskList");

                return _tasks;
            }
        }
    }
}
