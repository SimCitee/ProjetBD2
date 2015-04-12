using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProjetBD.Models;

namespace ProjetBD.Views {
    public partial class FormAddPlayer : Form {
        Player _player;

        public FormAddPlayer(Player player) {
            InitializeComponent();
            _player = player;
        }

        private void btnCancel_Click(object sender, EventArgs e) {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void btnAccept_Click(object sender, EventArgs e) {
            if (!String.IsNullOrEmpty(tbNewPlayerFirstName.Text) && !String.IsNullOrEmpty(tbNewPlayerLastName.Text)) {
                _player.FirstName = tbNewPlayerFirstName.Text;
                _player.LastName = tbNewPlayerLastName.Text;

                DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
        }
    }
}
