using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.DataAccess.Client;
using ProjetBD.Database;
using ProjetBD.Collections;
using ProjetBD.Views;
using ProjetBD.Models;

namespace ProjetBD
{
    public partial class MainWindow : Form
    {
        private DateTimePicker _dateTimePicker;
        private const String DBCONFIG = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=NEPTUNE.UQTR.CA)(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SID=COURSBD))); User Id=SMI1002_39;Password=53uzct45;";
        DatabaseHelper dbHelper;


        public MainWindow()
        {
            InitializeComponent();

            dbHelper = new DatabaseHelper(DBCONFIG);

            BoardGameEventCollection.Instance().LoadBoardEventsFromDatabase(dbHelper.Connection);
            BoardGameCollection.Instance().LoadBoardGamesFromDatabase(dbHelper.Connection);
            PlayerCollection.Instance().LoadPlayersFromDatabase(dbHelper.Connection);
        }

        private void MainWindow_Load(object sender, EventArgs e) {
            eventsDataGridView.Width = eventsTabPage.Width - eventsDataGridView.Location.X;
            eventsDataGridView.Height = eventsTabPage.Height - 80;
            playersDataGridView.Width = playersTabPage.Width - playersDataGridView.Location.X;
            playersDataGridView.Height = playersTabPage.Height - 80;
            boardGamesDataGridView.Width = boardGamesTabPage.Width - boardGamesDataGridView.Location.X;
            boardGamesDataGridView.Height = boardGamesTabPage.Height - 80;

           /* cCoursDepartement.DataSource = dataStore.Departements;
            cCoursDepartement.DisplayMember = "Nom";
            cCoursDepartement.ValueMember = "Self";
            cCoursEnseignant.DataSource = dataStore.Enseignants;
            cCoursEnseignant.DisplayMember = "NomComplet";
            cCoursEnseignant.ValueMember = "Self";

            cInscriptionCours.DataSource = dataStore.LesCours;
            cInscriptionCours.DisplayMember = "Sigle";
            cInscriptionCours.ValueMember = "Self";
            cInscriptionEtudiant.DataSource = dataStore.Etudiants;
            cInscriptionEtudiant.DisplayMember = "NomComplet";
            cInscriptionEtudiant.ValueMember = "Self";*/

            eventsDataGridView.AutoGenerateColumns = false;
            boardGamesDataGridView.AutoGenerateColumns = false;
            playersDataGridView.AutoGenerateColumns = false;

            eventsDataGridView.DataSource = BoardGameEventCollection.Instance().BoardgameEvents;
            boardGamesDataGridView.DataSource = BoardGameCollection.Instance().BoardGames;
            playersDataGridView.DataSource = PlayerCollection.Instance().Players;
        }

        private void btnAddEvent_Click(object sender, EventArgs e) {
            BoardGameEvent boardGameEvent = new BoardGameEvent();
            FormAddEvent form = new FormAddEvent(boardGameEvent);

            if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                dbHelper.Insert(boardGameEvent);
                RefreshEventsGrid();
            }
        }

        private void btnDeleteEvent_Click(object sender, EventArgs e) {
            if (eventsDataGridView.SelectedRows.Count == 1) {
                ModelBase model = (ModelBase)eventsDataGridView.SelectedRows[0].DataBoundItem;
                dbHelper.Delete(model);
                RefreshEventsGrid();
            }
        }

        private void eventsDataGridView_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e) {
            if (e.RowIndex >= 0) {
                BoardGameEvent model = (BoardGameEvent)eventsDataGridView.Rows[e.RowIndex].DataBoundItem;

                if (e.ColumnIndex == 3) {
                    _dateTimePicker = new DateTimePicker();
                    _dateTimePicker.Value = model.Datestart;
                    eventsDataGridView.Controls.Add(_dateTimePicker);
                    _dateTimePicker.Format = DateTimePickerFormat.Short;
                    Rectangle rectangle = eventsDataGridView.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                    _dateTimePicker.Size = new Size(rectangle.Width, rectangle.Height);
                    _dateTimePicker.Location = new Point(rectangle.X, rectangle.Y);
                    _dateTimePicker.CloseUp += new EventHandler(_dateTimePicker_CloseUp);
                    _dateTimePicker.TextChanged += new EventHandler(_dateTimePicker_OnTextChange);
                    _dateTimePicker.Format = DateTimePickerFormat.Custom;
                    _dateTimePicker.CustomFormat = "dd MMMM yyyy";
                    _dateTimePicker.Visible = true;
                }
                
                try {
                    dbHelper.LockBeforeUpdate(model);
                }
                catch (OracleException ex) {
                    dbHelper.CancelUpdate();
                }
            }
        }

        private void eventsDataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e) {
            if (e.RowIndex > -1) {
                try {
                    ModelBase model = (ModelBase)eventsDataGridView.Rows[e.RowIndex].DataBoundItem;
                    dbHelper.PushUpdate(model);
                }
                catch (OracleException ex) {
                    dbHelper.CancelUpdate();
                }
            }
        }

        private void btnAddPlayer_Click(object sender, EventArgs e) {
            Player player = new Player();
            FormAddPlayer form = new FormAddPlayer(player);

            if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                dbHelper.Insert(player);
            }
        }

        private void button1_Click(object sender, EventArgs e) {
            BoardGame boardGame = new BoardGame();
            FormAddBoardgame form = new FormAddBoardgame(boardGame);

            if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                dbHelper.Insert(boardGame);
            }
        }

        private void RefreshEventsGrid() {
            eventsDataGridView.DataSource = null;
            eventsDataGridView.DataSource = BoardGameEventCollection.Instance().BoardgameEvents;
        }

        private void eventsDataGridView_CellClick(object sender, DataGridViewCellEventArgs e) {
            
        }

        private void _dateTimePicker_CloseUp(object sender, EventArgs e) {
            _dateTimePicker.Visible = false;
        } 

        private void _dateTimePicker_OnTextChange(object sender, EventArgs e) {
            eventsDataGridView.CurrentCell.Value = _dateTimePicker.Text.ToString();
        }

        private void eventsDataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e) {
            _dateTimePicker.Visible = false;
        } 
    }
}
