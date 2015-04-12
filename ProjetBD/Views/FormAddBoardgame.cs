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
    public partial class FormAddBoardgame : Form {
        private BoardGame _boardGame;

        public FormAddBoardgame(BoardGame boardGame) {
            InitializeComponent();
            _boardGame = boardGame;
        }

        private void btnCancel_Click(object sender, EventArgs e) {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void btnAccept_Click(object sender, EventArgs e) {
            if (!String.IsNullOrEmpty(tbNewBGName.Text)) {
                _boardGame.Name = tbNewBGName.Text;
                _boardGame.MinimumPlayerNumber = (Int32)nudNewBGNbPlayerMin.Value;
                _boardGame.MaximumPlayerNumber = (Int32)nudNewBGNbPlayerMax.Value;
                _boardGame.MinimumAge = (Int32)nudNewBGAgeMin.Value;
                _boardGame.AverageGameTime = (Int32)nudNewBGTimeAvg.Value;

                DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
        }
    }
}
