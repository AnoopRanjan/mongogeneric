using MongoDB.Driver;
using CI.QUEST.DataModel.Models;
using CI.QUEST.DataModel.Repository;
using System.Configuration;

namespace CI.QUEST.DataModel.UnitOfWork
{
    public class StudentsUnitOfWork
    {
        private MongoDatabase _database;

        protected Repository<Student> _students;
        public Repository<Expense> _expenses;
        public Repository<GridOption> _gridOptions;
        public Repository<Scenario> _scenario;
        public Repository<dynamic> _expensesDynamic;
        public Repository<DynamicExpense> _dynamicExpenses;
        public StudentsUnitOfWork()
        {
            var connectionString = ConfigurationManager.AppSettings["MongoDBConectionString"];
            var client = new MongoClient(connectionString);
            var server = client.GetServer(); 
            var databaseName = ConfigurationManager.AppSettings["MongoDBDatabaseName"];
            _database = server.GetDatabase(databaseName);
        }
        public Repository<Student> CI.QUEST
        {
            get
            {
                if (_students == null)
                    _students = new Repository<Student>(_database, "");

                return _students;
            }
        }
        public Repository<Expense> Expenses
        {
            get
            {
                if (_expenses == null)
                    _expenses = new Repository<Expense>(_database, "expenses");

                return _expenses;
            }
        }
        public Repository<GridOption> GridOptions
        {
            get
            {
                if (_gridOptions == null)
                    _gridOptions = new Repository<GridOption>(_database, "gridOptions");

                return _gridOptions;
            }
        }

        public Repository<Scenario> Scenarios
        {
            get
            {
                if (_scenario == null)
                    _scenario = new Repository<Scenario>(_database, "scenarios");

                return _scenario;
            }
        }

        public Repository<dynamic> expensesDynamic
        {
            get
            {
                if (_expensesDynamic == null)
                    _expensesDynamic = new Repository<dynamic>(_database, "expenses");

                return _expensesDynamic;
            }
        }
        //Dynamic expense
        public Repository<DynamicExpense> dynamicExpenses
        {
            get
            {
                if (_dynamicExpenses == null)
                    _dynamicExpenses = new Repository<DynamicExpense>(_database, "expenses");

                return _dynamicExpenses;
            }
        }


    }
}
