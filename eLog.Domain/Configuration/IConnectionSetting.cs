using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eLog.Domain.Configuration
{
    public interface IConnectionSetting : ISettings
    {
        /// <summary>
        /// Get Connection String
        /// </summary>
        /// <returns>Connection string to SQL</returns>
        string Get();
    }

    public class ConnectionSetting : IConnectionSetting
    {
        protected string _connectionString;
        public ConnectionSetting(string connectionString)
        {
            _connectionString = connectionString;
            // For fix on Testing Module not getting Connection String
            //TODO: Remove this
            if (string.IsNullOrEmpty(connectionString))
            {
                _connectionString = "Data Source=192.168.1.101;Initial Catalog=eLog;Persist Security Info=True;User ID=elog;Password=Percoid@123;MultipleActiveResultSets=true";
            }
        }
        public string Get()
        {
            return _connectionString;
        }
    }

}
