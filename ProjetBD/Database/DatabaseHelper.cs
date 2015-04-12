using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OracleClient;
using ProjetBD.Models;

namespace ProjetBD.Database {

    public static class LogActions {
        public static String Undo = "Undo";
        public static String Redo = "Redo";
        public static String Started = "Started";
        public static String Confirmed = "Confirmed";
        public static String Cancelled = "Cancelled";
    }

    public class DatabaseHelper {
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

        #region Methods
        public void Insert(ModelBase model) {
            try {
                Connection.Open();
                _transaction = Connection.BeginTransaction();

                LogTransaction(LogActions.Started);
                model.Insert(this);
                LogTransaction(LogActions.Confirmed, String.Empty);
            }
            catch (OracleException e) {
                _transaction.Rollback();
                LogTransaction(LogActions.Cancelled, String.Empty);
                throw e;
            }
            finally {
                if (Connection != null) {
                    Connection.Close();
                }

                _transaction = null;
            }
        }

        public void Delete(ModelBase model) {
            try {
                Connection.Open();
                _transaction = Connection.BeginTransaction();

                LogTransaction(LogActions.Started);
                model.Delete(this);
                LogTransaction(LogActions.Confirmed, String.Empty);
            }
            catch (OracleException e) {
                _transaction.Rollback();
                LogTransaction(LogActions.Cancelled, String.Empty);
                throw e;
            }
            finally {
                if (Connection != null) {
                    Connection.Close();
                }

                _transaction = null;
            }
        }

        public void LockBeforeUpdate(ModelBase model) {
            try {
                Connection.Open();
                _transaction = Connection.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);

                LogTransaction(LogActions.Started);
                model.Lock(this);
            }
            catch (OracleException e) {
                _transaction.Rollback();
                LogTransaction(LogActions.Cancelled);
                throw e;
            }
            finally {
                _transaction = null;

                if (Connection != null) {
                    Connection.Close();
                }
            }
        }

        public void PushUpdate(ModelBase model) {
            try {
                model.Update(this);
                LogTransaction(LogActions.Confirmed);
            }
            catch (OracleException e) {
                _transaction.Rollback();
                LogTransaction(LogActions.Cancelled);
                throw e;
            }
            finally {
                _transaction = null;

                if (Connection != null) {
                    Connection.Close();
                }
            }
        }

        public void CancelUpdate() {
            try {
                if (_transaction != null && Connection.State == System.Data.ConnectionState.Open) {
                    _transaction.Rollback();
                    LogTransaction(LogActions.Cancelled);
                }
            }
            catch (OracleException e) {
                throw e;
            }
            finally {
                _transaction = null;

                if (Connection != null) {
                    Connection.Close();
                }
            }
        }

        private void LogTransaction(String logAction) {
            LogTransaction(logAction, String.Empty);
        }

        public void LogTransaction(String logAction, String commandString) {
            OracleCommand command = Connection.CreateCommand();
            commandString = commandString.Replace("'", "\'");
            command.CommandText = String.Format("INSERT INTO LOGS(ACTION, COMMAND) VALUES('{0}','{1}')", logAction, commandString);
            command.ExecuteNonQuery();
        }
        #endregion
    }
}
