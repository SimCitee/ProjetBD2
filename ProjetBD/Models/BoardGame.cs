﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetBD.Models {
    class BoardGame {
        private Int32 _id;
        private String _name;
        private Int32 _minimumPlayerNumber;
        private Int32 _maximumPlayerNumber;
        private Int32 _minimumAge;
        private Int32 _averageGameTime;

        public BoardGame(String name, Int32 minimumPlayerNUmber, Int32 maximumPlayerNumber, Int32 minimumAge, Int32 averageGameTime) {
            _name = name;
            _minimumPlayerNumber = minimumPlayerNUmber;
            _maximumPlayerNumber = maximumPlayerNumber;
            _minimumAge = minimumAge;
            _averageGameTime = averageGameTime;
        }

        public BoardGame(Int32 id, String name, Int32 minimumPlayerNUmber, Int32 maximumPlayerNumber, Int32 minimumAge, Int32 averageGameTime) {
            _id = id;
            _name = name;
            _minimumPlayerNumber = minimumPlayerNUmber;
            _maximumPlayerNumber = maximumPlayerNumber;
            _minimumAge = minimumAge;
            _averageGameTime = averageGameTime;
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
    }
}