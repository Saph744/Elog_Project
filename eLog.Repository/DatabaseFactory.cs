using eLog.Domain.Configuration;
using System.Data.Common;
using System.Data;
using eLog.Domain.Data;
using System.Data.SqlClient;

namespace eLog.Repository
{
    /*
    * Returns Connection and DbContext
    * Inject this over DbContext injection.
    * */

    public class DatabaseFactory : IDatabaseFactory
    {
        private IDbConnection _connection;
        private eLogDBContext _context;
        private IDbTransaction _dbTransaction;
        public DatabaseFactory(IConnectionSetting setting)
        {
            ConnectionString = setting.Get();
        }
        public string ConnectionString { get; set; }

        public IDbConnection Connection
        {
            get
            {
                if (_connection == null)
                {
                    _connection = new SqlConnection(ConnectionString);
                }
                return _connection;
            }
        }

        public eLogDBContext Context
        {
            get
            {
                if (_context == null)
                {
                    _context = new eLogDBContext(Connection as DbConnection, true);
                }
                return _context;
            }
        }

        public IDbTransaction Transaction
        {
            get
            {
                return _dbTransaction;
            }
        }

        public void ChangeConnection(IDbConnection toConnection)
        {
            _connection = toConnection;
        }
        public void ChangeContext(eLogDBContext tocontext)
        {
            _context = tocontext;
        }

        public void ChangeTransaction(IDbTransaction toTransaction)
        {
            _dbTransaction = toTransaction;
        }
    }

    public interface IDatabaseFactory
    {
        string ConnectionString { get; }
        IDbConnection Connection { get; }
        eLogDBContext Context { get; }
        IDbTransaction Transaction { get; }

        void ChangeConnection(IDbConnection toConnection);
        void ChangeContext(eLogDBContext tocontext);
        void ChangeTransaction(IDbTransaction toTransaction);
    }

}
