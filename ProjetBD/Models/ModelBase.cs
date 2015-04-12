using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetBD.Database;

namespace ProjetBD.Models {
    public abstract class ModelBase {
        public abstract void Insert(DatabaseHelper dbHelper);
        public abstract void Update(DatabaseHelper dbHelper);
        public abstract void Delete(DatabaseHelper dbHelper);
        public abstract void Lock(DatabaseHelper dbHelper);
    }
}
