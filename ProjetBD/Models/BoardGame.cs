using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetBD.Models {
    public class BoardGame : ModelBase {
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