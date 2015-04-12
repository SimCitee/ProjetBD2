using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetBD.Models {
    public class BoardGameEvent : ModelBase {
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

        public String Desription {
            get { return _description; }
            set { _description = value; }
        }

        public DateTime Date {
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

        public override void Insert(Database.DatabaseHelper dbHelper) {
            throw new NotImplementedException();
        }

        public override void Update(Database.DatabaseHelper dbHelper) {
            throw new NotImplementedException();
        }

        public override void Delete(Database.DatabaseHelper dbHelper) {
            throw new NotImplementedException();
        }

        public override void Lock(Database.DatabaseHelper dbHelper) {
            throw new NotImplementedException();
        }
    }
}