using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OracleClient;
using ProjetBD.Models;

namespace ProjetBD.Collections {
    class BoardGameEventCollection {
        private static BoardGameEventCollection _instance;
        private List<BoardGameEvent> _eventList;

        private BoardGameEventCollection() { }

        public static BoardGameEventCollection Instance() {
            if (_instance == null)
                _instance = new BoardGameEventCollection();

            return _instance;
        }

        public List<BoardGameEvent> BoardgameEvents {
            get {
                if (_eventList == null)
                    _eventList = new List<BoardGameEvent>();

                return _eventList;
            }
        }

        public void LoadBoardEventsFromDatabase(OracleConnection connection) {
            try {
                OracleCommand command = connection.CreateCommand();
                command.CommandText = "SELECT Events.Id, Events.Name, Events.Description, Events.Date FROM Events";

                connection.Open();

                OracleDataReader reader = command.ExecuteReader();

                while (reader.Read()) {
                    BoardGameEvent boardgameEvent = new BoardGameEvent(reader["Name"].ToString(), reader["Description"].ToString(), (DateTime)reader["Date"], (Int32)reader["Id"]);
                    BoardgameEvents.Add(boardgameEvent);
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
