using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetBD.Models {
    class Player : ModelBase {
        private Int32 _id;
        private String _firstName;
        private String _lastName;

        public Player(String firstName, String lastName) {
            _firstName = firstName;
            _lastName = lastName;
        }

        public Player(String firstName, String lastName, Int32 id)
            : this(firstName, lastName) {
            _id = id;
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
