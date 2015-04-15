using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using ProjetBD.Collections;
using ProjetBD.Database;

namespace ProjetBD.Models {
    public class BoardGameEvent : ModelBase {

        private const String QRY_SELECT = "SELECT EVENTS.ID, EVENTS.NAME, EVENTS.DESCRIPTION, EVENTS.DATESTART FROM EVENTS WHERE EVENTS.ID = {0}";
        private const String QRY_SELECT_PLAYERS = "SELECT EVENT_PLAYER.PLAYER_ID FROM EVENT_PLAYER WHERE EVENT_ID = {0}";
        private const String QRY_SELECT_BOARDGAMES = "SELECT BOARDGAME_EVENT.BOARDGAME_ID FROM BOARDGAME_EVENT WHERE EVENT_ID = {0}";
        private const String QRY_INSERT = "INSERT INTO EVENTS(NAME, DESCRIPTION, DATESTART) VALUES('{0}', '{1}', '{2}') RETURNING ID INTO :output";
        private const String QRY_INSERT_PLAYER = "INSERT INTO EVENT_PLAYER(EVENT_ID, PLAYER_ID) VALUES('{0}', '{1}')";
        private const String QRY_INSERT_BOARDGAME = "INSERT INTO BOARDGAME_EVENT(BOARDGAME_ID, EVENT_ID) VALUES('{0}', '{1}')";
        private const String QRY_FULL_INSERT = "INSERT INTO EVENTS(ID, NAME, DESCRIPTION, DATESTART) VALUES('{0}', '{1}', '{2}', '{3}')";
        private const String QRY_UPDATE = "UPDATE EVENTS SET NAME = '{0}', DESCRIPTION = '{1}', DATESTART = '{2}' WHERE Id = '{3}'";
        private const String QRY_DELETE = "DELETE FROM EVENTS WHERE ID = '{0}'";
        private const String QRY_DELETE_PLAYER = "DELETE FROM EVENT_PLAYER WHERE EVENT_ID = '{0}' AND PLAYER_ID = '{1}'";
        private const String QRY_DELETE_BOARDGAME = "DELETE FROM BOARDGAME_EVENT WHERE BOARDGAME_ID = '{0}' AND EVENT_ID = '{1}'";
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

        public String EventNameDate {
            get {
                return _name + " " + _date.ToString("dd-MM-yy");
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

        public override void Insert(DatabaseHelper dbHelper) {
            try {
                OracleDecimal output;
                OracleCommand command = dbHelper.Connection.CreateCommand();
                command.CommandText = QRY_LOCK;
                command.ExecuteNonQuery();

                command.CommandText = String.Format(QRY_INSERT, Name, Description, Datestart.ToString("yy-MM-dd"));
                command.Parameters.Add("output", OracleDbType.Decimal, ParameterDirection.ReturnValue);
                command.ExecuteNonQuery();

                output = (OracleDecimal)command.Parameters["output"].Value;

                dbHelper.LogTransaction(LogActions.Undo, String.Format(QRY_DELETE, output.ToInt32()));
                dbHelper.LogTransaction(LogActions.Redo, String.Format(QRY_INSERT, Name, Description, Datestart));

                dbHelper.Transaction.Commit();

                BoardGameEventCollection.Instance().BoardgameEvents.Add(this);
            }
            catch (OracleException e) {
                throw e;
            }
        }

        public override void Update(DatabaseHelper dbHelper) {
            try {
                OracleCommand command = dbHelper.Connection.CreateCommand();
                command.CommandText = String.Format(QRY_UPDATE, Name, Description, Datestart.ToString("yy-MM-dd"), Id);
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

        public override void Delete(DatabaseHelper dbHelper) {
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

        public void LoadPlayersFromDatabase(OracleConnection connection) {
            try {
                OracleCommand command = connection.CreateCommand();
                command.CommandText = String.Format(QRY_SELECT_PLAYERS, _id);

                connection.Open();

                OracleDataReader reader = command.ExecuteReader();

                while (reader.Read()) {
                    _playerList.Add(PlayerCollection.Instance().Players.Where(s => s.Id == Int32.Parse(reader["PLAYER_ID"].ToString())).First());
                }
            }
            catch (OracleException e) {
                throw e;
            }
        }

        public void LoadBoardGamesFromDatabase(OracleConnection connection) {
            try {
                OracleCommand command = connection.CreateCommand();
                command.CommandText = String.Format(QRY_SELECT_BOARDGAMES, _id);

                connection.Open();

                OracleDataReader reader = command.ExecuteReader();

                while (reader.Read()) {
                    _boardGameList.Add(BoardGameCollection.Instance().BoardGames.Where(s => s.Id == Int32.Parse(reader["BOARDGAME_ID"].ToString())).First());
                }
            }
            catch (OracleException e) {
                throw e;
            }
        }

        public void AddPlayerToPlayerList(Player newPlayer, OracleConnection connection) {
            try {
                OracleCommand command = connection.CreateCommand();
                command.CommandText = String.Format(QRY_INSERT_PLAYER, _id, newPlayer.Id);

                connection.Open();

                command.ExecuteNonQuery();

                _playerList.Add(newPlayer);
            }
            catch (OracleException e) {
                throw e;
            }
        }

        public void RemovePlayerFromPlayerList(Player oldPlayer, OracleConnection connection) {
            try {
                OracleCommand command = connection.CreateCommand();
                command.CommandText = String.Format(QRY_DELETE_PLAYER, _id, oldPlayer.Id);

                connection.Open();

                command.ExecuteNonQuery();

                _playerList.Remove(oldPlayer);
            }
            catch (OracleException e) {
                throw e;
            }
        }

        public void AddBoardGameToBoardGameList(BoardGame newBoardGame, OracleConnection connection) {
            try {
                OracleCommand command = connection.CreateCommand();
                command.CommandText = String.Format(QRY_INSERT_BOARDGAME, newBoardGame.Id, _id);

                connection.Open();

                command.ExecuteNonQuery();

                _boardGameList.Add(newBoardGame);
            }
            catch (OracleException e) {
                throw e;
            }
        }

        public void RemoveBoardGameFromBoardGameList(BoardGame oldBoardGame, OracleConnection connection) {
            try {
                OracleCommand command = connection.CreateCommand();
                command.CommandText = String.Format(QRY_DELETE_BOARDGAME, oldBoardGame.Id, _id);

                connection.Open();

                command.ExecuteNonQuery();

                _boardGameList.Remove(oldBoardGame);
            }
            catch (OracleException e) {
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