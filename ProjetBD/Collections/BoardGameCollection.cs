using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OracleClient;
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

        public List<BoardGame> BoardGames {
            get {
                if (_boardGameList == null)
                    _boardGameList = new List<BoardGame>();

                return _boardGameList;
            }
        }

        public void LoadBoardGamesFromDatabase(OracleConnection connection) {
            try {
                OracleCommand command = connection.CreateCommand();
                command.CommandText = "SELECT BoardGames.Id, BoardGames.Name, BoardGames.MinimumPlayerNumber, BoardGames.MaximumPlayerNumber, BoardGames.MinimumAge, BoardGames.AverageGameTime FROM BoardGames";

                connection.Open();

                OracleDataReader reader = command.ExecuteReader();

                while (reader.Read()) {
                    BoardGame boardgame = new BoardGame(reader["Name"].ToString(), (Int32)reader["MinimumPlayerNumber"], (Int32)reader["MaximumPlayerNumber"], (Int32)reader["MinimumAge"], (Int32)reader["AverageGameTime"], (Int32)reader["Id"]);
                    BoardGames.Add(boardgame);
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
