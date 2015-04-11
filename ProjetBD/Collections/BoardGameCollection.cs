using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetBD.Models;

namespace ProjetBD.Collections {
    class BoardGameCollection {
        private static BoardGameCollection _instance;
        private List<BoardGame> _boardGameList;

        private BoardGameCollection() {}

        public static BoardGameCollection Instance() {
            if (_instance == null)
                _instance = new BoardGameCollection();

            return _instance;
        }

        public List<BoardGame> BoardGameList {
            get {
                if (_boardGameList == null)
                    _boardGameList = new List<BoardGame>();

                return _boardGameList;
            }
        }
    }
}
