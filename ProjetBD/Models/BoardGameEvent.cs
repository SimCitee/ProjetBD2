using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OracleClient;
using ProjetBD.Collections;
using ProjetBD.Database;

namespace ProjetBD.Models {
    public class BoardGameEvent : ModelBase {

        private const String QRY_SELECT = "SELECT EVENTS.ID, EVENTS.NAME, EVENTS.DESCRIPTION, EVENTS.DATESTART FROM EVENTS WHERE EVENTS.ID = {0}";
        private const String QRY_INSERT = "INSERT INTO EVENTS(NAME, DESCRIPTION, DATESTART) VALUES('{0}', '{1}', '{2}')";
        private const String QRY_FULL_INSERT = "INSERT INTO EVENTS(ID, NAME, DESCRIPTION, DATESTART) VALUES('{0}', '{1}', '{2}', '{3}')";
        private const String QRY_UPDATE = "UPDATE EVENTS SET NAME = '{0}', DESCRIPTION = '{1}', DATESTART = '{2}' WHERE Id = '{3}'";
        private const String QRY_DELETE = "DELETE FROM EVENTS WHERE ID = '{0}'";
        private const String QRY_LOCK = "LOCK TABLE EVENTS IN EXCLUSIVE MODE";

        private BoardGameEvent _mementoBoardGameEvent;
        private Int32 _id;
        private String _name;
        private String _description;
        private DateTime _date;
        private List<Player> _playerList;
        private List<BoardGame> _boardGameList;

        public BoardGameEvent() {
        }

        public BoardGameEvent(String name, String description, DateTime date) {
            _name = name;
            _description = description;
            _date = date;
        }

        public BoardGameEvent(String name, String description, DateTime date, Int32 id)
            : this(name, description, date) {
            _id = id;
        }

        public Int32 Id {
            get { return _id; }
            set { _id = value; }
        }

        public String Name {
            get { return _name; }
            set { _name = value; }
        }

        public String Description {
            get { return _description; }
            set { _description = value; }
        }

        public DateTime Datestart {
            get { return _date; }
            set { _date = value; }
        }

        public List<Player> PlayerList {
            get {
                if (_playerList == null)
                    _playerList = new List<Player>();

                return _playerList;
            }
        }

        public List<BoardGame> BoardGameList {
            get {
                if (_boardGameList == null)
                    _boardGameList = new List<BoardGame>();

                return _boardGameList;
            }
        }

        public BoardGameEvent Memento {
            get {
                if (_mementoBoardGameEvent == null) {
                    _mementoBoardGameEvent = new BoardGameEvent();
                }

                return _mementoBoardGameEvent;
            }
        }

        public override void Insert(Database.DatabaseHelper dbHelper) {
            try {
                OracleCommand command = dbHelper.Connection.CreateCommand();
                command.CommandText = QRY_LOCK;
                command.ExecuteNonQuery();

                command.CommandText = String.Format(QRY_INSERT, Name, Description, Datestart);
                command.ExecuteNonQuery();

                dbHelper.LogTransaction(LogActions.Undo, String.Format(QRY_DELETE, Id));
                dbHelper.LogTransaction(LogActions.Redo, String.Format(QRY_INSERT, Name, Description, Datestart));

                dbHelper.Transaction.Commit();

                BoardGameEventCollection.Instance().BoardgameEvents.Add(this);
            }
            catch (OracleException e) {
                throw e;
            }
        }

        public override void Update(Database.DatabaseHelper dbHelper) {
            try {
                OracleCommand command = dbHelper.Connection.CreateCommand();
                command.CommandText = String.Format(QRY_UPDATE, Name, Description, Datestart, Id);
                command.ExecuteNonQuery();

                dbHelper.LogTransaction(LogActions.Undo, String.Format(QRY_UPDATE, Memento.Name, Memento.Description, Memento.Datestart, Memento.Id));
                dbHelper.LogTransaction(LogActions.Redo, command.CommandText);

                dbHelper.Transaction.Commit();
            }
            catch (OracleException e) {
                Name = Memento.Name;
                Description = Memento.Description;
                Datestart = Memento.Datestart;
                throw e;
            }
        }

        public override void Delete(Database.DatabaseHelper dbHelper) {
            try {
                OracleCommand command = dbHelper.Connection.CreateCommand();
                command.CommandText = QRY_LOCK;
                command.ExecuteNonQuery();

                command.CommandText = String.Format(QRY_DELETE, Id);
                command.ExecuteNonQuery();

                dbHelper.LogTransaction(LogActions.Undo, String.Format(QRY_FULL_INSERT, Id, Name, Description, Datestart));
                dbHelper.LogTransaction(LogActions.Redo, command.CommandText);

                dbHelper.Transaction.Commit();

                BoardGameEventCollection.Instance().BoardgameEvents.Remove(this);
            }
            catch (OracleException e) {
                Name = Memento.Name;
                Description = Memento.Description;
                Datestart = Memento.Datestart;
                throw e;
            }
        }

        public override void Lock(Database.DatabaseHelper dbHelper) {
            try {
                OracleCommand command = dbHelper.Connection.CreateCommand();
                command.CommandText = String.Format(QRY_SELECT + " FOR UPDATE", this.Id);
                command.ExecuteScalar();
                Memento.Id = Id;
                Memento.Name = Name;
                Memento.Description = Description;
                Memento.Datestart = Datestart;
            }
            catch (OracleException e) {
                throw e;
            }
        }
    }
}