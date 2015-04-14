using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProjetBD.Database;
using ProjetBD.Collections;
using ProjetBD.Views;
using ProjetBD.Models;

namespace ProjetBD
{
    public partial class MainWindow : Form
    {
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
    }
}
