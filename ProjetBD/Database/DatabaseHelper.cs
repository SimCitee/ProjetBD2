using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OracleClient;

namespace ProjetBD.Database {
    class DatabaseHelper {
        private OracleConnection _connection;       // Oracle database connection
        private OracleTransaction _transaction;     // Pending transaction

        #region Properties
        public OracleConnection Connection { 
            get {
                return _connection;
            } 
        }

        public OracleTransaction Transaction {
            get {
                return _transaction;
            }
        }
        #endregion

        #region Class
        public DatabaseHelper(String connectionString) {
            try {
                _connection = new OracleConnection(connectionString);
            }
            catch (OracleException e) {
                throw e;
            }
        }
        #endregion
    }
}
