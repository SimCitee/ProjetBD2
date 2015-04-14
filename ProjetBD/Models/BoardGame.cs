using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OracleClient;
using ProjetBD.Database;
using ProjetBD.Collections;

namespace ProjetBD.Models {
    public class BoardGame : ModelBase {

        private const String QRY_SELECT = "SELECT BOARDGAMES.ID, BOARDGAMES.NAME, BOARDGAMES.MINIMUM_PLAYER_NUMBER, BOARDGAMES.MAXIMUM_PLAYER_NUMBER, BOARDGAMES.MINIMUM_AGE, BOARDGAMES.AVERAGE_GAME_TIME FROM BOARDGAMES WHERE BOARDGAMES.ID = {0}";
        private const String QRY_INSERT = "INSERT INTO BOARDGAMES(NAME, MINIMUM_PLAYER_NUMBER, MAXIMUM_PLAYER_NUMBER, MINIMUM_AGE, AVERAGE_GAME_TIME) VALUES('{0}', '{1}', '{2}', '{3}', '{4}')";
        private const String QRY_FULL_INSERT = "INSERT INTO BOARDGAMES(ID, NAME, MINIMUM_PLAYER_NUMBER, MAXIMUM_PLAYER_NUMBER, MINIMUM_AGE, AVERAGE_GAME_TIME) VALUES('{0}', '{1}', '{2}', '{3}', '{4}', '{5}')";
        private const String QRY_UPDATE = "UPDATE BOARDGAMES SET NAME = '{0}', MINIMUM_PLAYER_NUMBER = '{1}', MAXIMUM_PLAYER_NUMBER = '{2}', MINIMUM_AGE = '{3}', AVERAGE_GAME_TIME = '{4}' WHERE Id = '{5}'";
        private const String QRY_DELETE = "DELETE FROM BOARDGAMES WHERE ID = '{0}'";
        private const String QRY_LOCK = "LOCK TABLE BOARDGAMES IN EXCLUSIVE MODE";

        private BoardGame _mementoBoardGame;
        private Int32 _id;
        private String _name;
        private Int32 _minimumPlayerNumber;
        private Int32 _maximumPlayerNumber;
        private Int32 _minimumAge;
        private Int32 _averageGameTime;

        public BoardGame() {
        }

        public BoardGame(String name, Int32 minimumPlayerNUmber, Int32 maximumPlayerNumber, Int32 minimumAge, Int32 averageGameTime) {
            _name = name;
            _minimumPlayerNumber = minimumPlayerNUmber;
            _maximumPlayerNumber = maximumPlayerNumber;
            _minimumAge = minimumAge;
            _averageGameTime = averageGameTime;
        }

        public BoardGame(String name, Int32 minimumPlayerNumber, Int32 maximumPlayerNumber, Int32 minimumAge, Int32 averageGameTime, Int32 id)
            : this(name, minimumPlayerNumber, maximumPlayerNumber, minimumAge, averageGameTime) {
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

        public Int32 MinimumPlayerNumber {
            get { return _minimumPlayerNumber; }
            set { _minimumPlayerNumber = value; }
        }

        public Int32 MaximumPlayerNumber {
            get { return _maximumPlayerNumber; }
            set { _maximumPlayerNumber = value; }
        }

        public Int32 MinimumAge {
            get { return _minimumAge; }
            set { _minimumAge = value; }
        }

        public Int32 AverageGameTime {
            get { return _averageGameTime; }
            set { _averageGameTime = value; }
        }

        public BoardGame Memento {
            get {
                if (_mementoBoardGame == null) {
                    _mementoBoardGame = new BoardGame();
                }

                return _mementoBoardGame;
            }
        }

        public override void Insert(Database.DatabaseHelper dbHelper) {
            try {
                OracleCommand command = dbHelper.Connection.CreateCommand();
                command.CommandText = QRY_LOCK;
                command.ExecuteNonQuery();

                command.CommandText = String.Format(QRY_INSERT, Name, MinimumPlayerNumber, MaximumPlayerNumber, MinimumAge, AverageGameTime);
                command.ExecuteNonQuery();

                dbHelper.LogTransaction(LogActions.Undo, String.Format(QRY_DELETE, Id));
                dbHelper.LogTransaction(LogActions.Redo, String.Format(QRY_INSERT, Name, MinimumPlayerNumber, MaximumPlayerNumber, MinimumAge, AverageGameTime));

                dbHelper.Transaction.Commit();

                BoardGameCollection.Instance().BoardGames.Add(this);
            }
            catch (OracleException e) {
                throw e;
            }
        }

        public override void Update(Database.DatabaseHelper dbHelper) {
            try {
                OracleCommand command = dbHelper.Connection.CreateCommand();
                command.CommandText = String.Format(QRY_UPDATE, Name, MinimumPlayerNumber, MaximumPlayerNumber, MinimumAge, AverageGameTime, Id);
                command.ExecuteNonQuery();

                dbHelper.LogTransaction(LogActions.Undo, String.Format(QRY_UPDATE, Memento.Name, Memento.MinimumPlayerNumber, Memento.MaximumPlayerNumber, Memento.MinimumAge, Memento.AverageGameTime, Memento.Id));
                dbHelper.LogTransaction(LogActions.Redo, command.CommandText);

                dbHelper.Transaction.Commit();
            }
            catch (OracleException e) {
                Name = Memento.Name;
                MinimumPlayerNumber = Memento.MinimumPlayerNumber;
                MaximumPlayerNumber = Memento.MaximumPlayerNumber;
                MinimumAge = Memento.MinimumAge;
                AverageGameTime = Memento.AverageGameTime;
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

                dbHelper.LogTransaction(LogActions.Undo, String.Format(QRY_FULL_INSERT, Id, Name, MinimumPlayerNumber, MaximumPlayerNumber, MinimumAge, AverageGameTime));
                dbHelper.LogTransaction(LogActions.Redo, command.CommandText);

                dbHelper.Transaction.Commit();

                BoardGameCollection.Instance().BoardGames.Remove(this);
            }
            catch (OracleException e) {
                Name = Memento.Name;
                MinimumPlayerNumber = Memento.MinimumPlayerNumber;
                MaximumPlayerNumber = Memento.MaximumPlayerNumber;
                MinimumAge = Memento.MinimumAge;
                AverageGameTime = Memento.AverageGameTime;
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
                Memento.MinimumPlayerNumber = MinimumPlayerNumber;
                Memento.MaximumPlayerNumber = MaximumPlayerNumber;
                Memento.MinimumAge = MinimumAge;
                Memento.AverageGameTime = AverageGameTime;
            }
            catch (OracleException e) {
                throw e;
            }
        }
    }
}