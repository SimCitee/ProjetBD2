using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.DataAccess.Client;
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

        public List<Player> Players {
            get {
                if (_playerList == null) {
                    _playerList = new List<Player>();
                }

                return _playerList;
            }
        }

        public void LoadPlayersFromDatabase(OracleConnection connection) {
            try {
                OracleCommand command = connection.CreateCommand();
                command.CommandText = "SELECT Players.Id, Players.Firstname, Players.Lastname FROM Players";
                
                connection.Open();

                OracleDataReader reader = command.ExecuteReader();

                while (reader.Read()) {
                    Player player = new Player(reader["Firstname"].ToString(), reader["Lastname"].ToString(), Int32.Parse(reader["Id"].ToString()));
                    Players.Add(player);
                }
            }
            catch (OracleException e) {
                throw e;
            }
            catch (Exception e) {
                throw e;
            }
            finally {
                if (connection != null) {
                    connection.Close();
                }
            }
        }
    }
}
