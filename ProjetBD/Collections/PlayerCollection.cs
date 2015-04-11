using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetBD.Models;

namespace ProjetBD.Collections {
    class PlayerCollection {
        private static PlayerCollection _instance;
        private List<Player> _playerList;

        private PlayerCollection() { }

        public static PlayerCollection Instance() {
            if (_instance == null)
                _instance = new PlayerCollection();

            return _instance;
        }

        public List<Player> PlayerList {
            get {
                if (_playerList == null)
                    _playerList = new List<Player>();

                return _playerList;
            }
        }
    }
}
