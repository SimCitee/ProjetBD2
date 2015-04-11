using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetBD.Models;

namespace ProjetBD.Collections {
    class EventCollection {
        private static EventCollection _instance;
        private List<Event> _eventList;

        private EventCollection() { }

        public static EventCollection Instance() {
            if (_instance == null)
                _instance = new EventCollection();

            return _instance;
        }

        public List<Event> EventList {
            get {
                if (_eventList == null)
                    _eventList = new List<Event>();

                return _eventList;
            }
        }
    }
}
