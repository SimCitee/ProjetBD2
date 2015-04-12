using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OracleClient;
using ProjetBD.Database;
using ProjetBD.Collections;

namespace ProjetBD.Models {
    public class Player : ModelBase {

        private static Player _mementoPlayer;

        private const String QRY_SELECT = "SELECT Players.Id, Players.Firstname, Players.Lastname FROM Players WHERE Players.Id = {0}";
        private const String QRY_INSERT = "INSERT INTO Players(Firstname, Lastname) VALUES('{0}', '{1}')";
        private const String QRY_FULL_INSERT = "INSERT INTO Players(Id, Firstname, Lastname) VALUES('{0}', '{1}', '{2}')";
        private const String QRY_UPDATE = "UPDATE Players SET Firstname = '{0}', Lastname = '{1}' WHERE Id = '{2}'";
        private const String QRY_DELETE = "DELETE FROM Players WHERE Id = '{0}'";
        private const String QRY_LOCK   = "LOCK TABLE Players IN EXCLUSIVE MODE";

        private Int32 _id;
        private String _firstName;
        private String _lastName;

        public Player() {
        }

        public Player(String firstName, String lastName) {
            _firstName = firstName;
            _lastName = lastName;
        }

        public Player(String firstName, String lastName, Int32 id)
            : this(firstName, lastName) {
            _id = id;
        }

        public Int32 Id {
            get { return _id; }
            set { _id = value; }
        }

        public String FirstName {
            get { return _firstName; }
            set { _firstName = value; }
        }

        public String LastName {
            get { return _lastName; }
            set { _lastName = value; }
        }

        public Player Memento {
            get {
                if (_mementoPlayer == null) {
                    _mementoPlayer = new Player();
                }

                return _mementoPlayer;
            }
        }

        public override void Insert(DatabaseHelper dbHelper) {
            try {
                OracleCommand command = dbHelper.Connection.CreateCommand();
                command.CommandText = QRY_LOCK;
                command.ExecuteNonQuery();

                command.CommandText = String.Format(QRY_INSERT, FirstName, LastName);
                command.ExecuteNonQuery();

                dbHelper.LogTransaction(LogActions.Undo, String.Format(QRY_DELETE, Id));
                dbHelper.LogTransaction(LogActions.Redo, String.Format(QRY_INSERT, FirstName, LastName));

                dbHelper.Transaction.Commit();

                PlayerCollection.Instance().Players.Add(this);
            }
            catch (OracleException e) {
                throw e;
            }
        }

        public override void Update(DatabaseHelper dbHelper) {
            try {
                OracleCommand command = dbHelper.Connection.CreateCommand();
                command.CommandText = String.Format(QRY_UPDATE, FirstName, LastName, Id);
                command.ExecuteNonQuery();

                dbHelper.LogTransaction(LogActions.Undo, String.Format(QRY_UPDATE, Memento.FirstName, Memento.LastName, Memento.Id));
                dbHelper.LogTransaction(LogActions.Redo, command.CommandText);

                dbHelper.Transaction.Commit();
            }
            catch (OracleException e) {
                FirstName = Memento.FirstName;
                LastName = Memento.LastName;
                throw e;
            }
        }

        public override void Delete(DatabaseHelper dbHelper) {
            try {
                OracleCommand command = dbHelper.Connection.CreateCommand();
                command.CommandText = QRY_LOCK;
                command.ExecuteNonQuery();

                command.CommandText = String.Format(QRY_DELETE, Id);
                command.ExecuteNonQuery();

                dbHelper.LogTransaction(LogActions.Undo, String.Format(QRY_FULL_INSERT, Id, FirstName, LastName));
                dbHelper.LogTransaction(LogActions.Redo, command.CommandText);

                dbHelper.Transaction.Commit();

                PlayerCollection.Instance().Players.Remove(this);
            }
            catch (OracleException e) {
                FirstName = Memento.FirstName;
                LastName = Memento.LastName;
                throw e;
            }
        }

        public override void Lock(Database.DatabaseHelper dbHelper) {
            throw new NotImplementedException();
        }
    }
}
