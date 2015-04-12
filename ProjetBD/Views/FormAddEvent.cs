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
    public partial class FormAddEvent : Form {
        BoardGameEvent _boardGameEvent;

        public FormAddEvent(BoardGameEvent boardGameEvent) {
            InitializeComponent();
            _boardGameEvent = boardGameEvent;
            dtpNewEventDate.Value = DateTime.Now;
        }

        private void btnAccept_Click(object sender, EventArgs e) {
            if (!String.IsNullOrEmpty(tbNewEventName.Text) && !String.IsNullOrEmpty(rtbNewEventDescription.Text)) {
                _boardGameEvent.Name = tbNewEventName.Text;
                _boardGameEvent.Desription = rtbNewEventDescription.Text;
                _boardGameEvent.Date = dtpNewEventDate.Value;

                DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e) {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }
    }
}
