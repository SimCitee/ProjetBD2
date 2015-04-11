using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetBD.Models {
    class Player {
        private Int32 _id;
        private String _firstName;
        private String _lastName;

        public Player(String firstName, String lastName) {
            _firstName = firstName;
            _lastName = lastName;
        }

        public Player(Int32 id, String firstName, String lastName) {
            _id = id;
            _firstName = firstName;
            _lastName = lastName;
        }

        public Int32 Id {
            get { return _id; }
            set { _id = value; }
        }

        public String FirstName {
            get { return _firstName; }
            set { _firstName = value; }
        }

        public String LastName {
            get { return _lastName; }
            set { _lastName = value; }
        }
    }
}
