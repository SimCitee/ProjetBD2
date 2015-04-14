using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.DataAccess.Client;
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
                command.CommandText = "SELECT EVENTS.ID, EVENTS.NAME, EVENTS.DESCRIPTION, TO_CHAR(EVENTS.DATESTART, 'DD-MM-YYYY') AS DATESTART FROM EVENTS";

                connection.Open();

                OracleDataReader reader = command.ExecuteReader();

                while (reader.Read()) {
                    DateTime dateStart = DateTime.ParseExact(reader["DATESTART"].ToString(), "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture);

                    BoardGameEvent boardgameEvent = new BoardGameEvent(reader["NAME"].ToString(), reader["DESCRIPTION"].ToString(), dateStart, (Int32.Parse(reader["ID"].ToString())));
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
