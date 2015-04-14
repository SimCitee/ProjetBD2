namespace ProjetBD
{
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.eventsTabPage = new System.Windows.Forms.TabPage();
            this.btnAddEvent = new System.Windows.Forms.Button();
            this.btnDeleteEvent = new System.Windows.Forms.Button();
            this.eventsDataGridView = new System.Windows.Forms.DataGridView();
            this.playersTabPage = new System.Windows.Forms.TabPage();
            this.btnAddPlayer = new System.Windows.Forms.Button();
            this.btnDeletePlayer = new System.Windows.Forms.Button();
            this.playersDataGridView = new System.Windows.Forms.DataGridView();
            this.boardGamesTabPage = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.boardGamesDataGridView = new System.Windows.Forms.DataGridView();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.eventPlayersDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.eventPlayerFirstname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.eventPlayerLastname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.firstname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lastname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.boardgame_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.minimumPlayerNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.maximumPlayerNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.minimumAge = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.averageGameTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl.SuspendLayout();
            this.eventsTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.eventsDataGridView)).BeginInit();
            this.playersTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.playersDataGridView)).BeginInit();
            this.boardGamesTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.boardGamesDataGridView)).BeginInit();
            this.tabPage5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.eventPlayersDataGridView)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.eventsTabPage);
            this.tabControl.Controls.Add(this.playersTabPage);
            this.tabControl.Controls.Add(this.boardGamesTabPage);
            this.tabControl.Controls.Add(this.tabPage5);
            this.tabControl.Controls.Add(this.tabPage4);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(936, 550);
            this.tabControl.TabIndex = 0;
            // 
            // eventsTabPage
            // 
            this.eventsTabPage.Controls.Add(this.btnAddEvent);
            this.eventsTabPage.Controls.Add(this.btnDeleteEvent);
            this.eventsTabPage.Controls.Add(this.eventsDataGridView);
            this.eventsTabPage.Location = new System.Drawing.Point(4, 22);
            this.eventsTabPage.Name = "eventsTabPage";
            this.eventsTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.eventsTabPage.Size = new System.Drawing.Size(928, 524);
            this.eventsTabPage.TabIndex = 0;
            this.eventsTabPage.Text = "Événements";
            this.eventsTabPage.UseVisualStyleBackColor = true;
            // 
            // btnAddEvent
            // 
            this.btnAddEvent.Location = new System.Drawing.Point(766, 480);
            this.btnAddEvent.Name = "btnAddEvent";
            this.btnAddEvent.Size = new System.Drawing.Size(75, 23);
            this.btnAddEvent.TabIndex = 2;
            this.btnAddEvent.Text = "&Ajouter";
            this.btnAddEvent.UseVisualStyleBackColor = true;
            this.btnAddEvent.Click += new System.EventHandler(this.btnAddEvent_Click);
            // 
            // btnDeleteEvent
            // 
            this.btnDeleteEvent.Location = new System.Drawing.Point(847, 480);
            this.btnDeleteEvent.Name = "btnDeleteEvent";
            this.btnDeleteEvent.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteEvent.TabIndex = 1;
            this.btnDeleteEvent.Text = "&Supprimer";
            this.btnDeleteEvent.UseVisualStyleBackColor = true;
            // 
            // eventsDataGridView
            // 
            this.eventsDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.eventsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.eventsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.name,
            this.description,
            this.date});
            this.eventsDataGridView.Location = new System.Drawing.Point(6, 6);
            this.eventsDataGridView.Name = "eventsDataGridView";
            this.eventsDataGridView.Size = new System.Drawing.Size(497, 221);
            this.eventsDataGridView.TabIndex = 0;
            // 
            // playersTabPage
            // 
            this.playersTabPage.Controls.Add(this.btnAddPlayer);
            this.playersTabPage.Controls.Add(this.btnDeletePlayer);
            this.playersTabPage.Controls.Add(this.playersDataGridView);
            this.playersTabPage.Location = new System.Drawing.Point(4, 22);
            this.playersTabPage.Name = "playersTabPage";
            this.playersTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.playersTabPage.Size = new System.Drawing.Size(928, 524);
            this.playersTabPage.TabIndex = 1;
            this.playersTabPage.Text = "Joueurs";
            this.playersTabPage.UseVisualStyleBackColor = true;
            // 
            // btnAddPlayer
            // 
            this.btnAddPlayer.Location = new System.Drawing.Point(766, 480);
            this.btnAddPlayer.Name = "btnAddPlayer";
            this.btnAddPlayer.Size = new System.Drawing.Size(75, 23);
            this.btnAddPlayer.TabIndex = 4;
            this.btnAddPlayer.Text = "&Ajouter";
            this.btnAddPlayer.UseVisualStyleBackColor = true;
            this.btnAddPlayer.Click += new System.EventHandler(this.btnAddPlayer_Click);
            // 
            // btnDeletePlayer
            // 
            this.btnDeletePlayer.Location = new System.Drawing.Point(847, 480);
            this.btnDeletePlayer.Name = "btnDeletePlayer";
            this.btnDeletePlayer.Size = new System.Drawing.Size(75, 23);
            this.btnDeletePlayer.TabIndex = 3;
            this.btnDeletePlayer.Text = "&Supprimer";
            this.btnDeletePlayer.UseVisualStyleBackColor = true;
            // 
            // playersDataGridView
            // 
            this.playersDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.playersDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.playersDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.firstname,
            this.lastname});
            this.playersDataGridView.Location = new System.Drawing.Point(6, 6);
            this.playersDataGridView.Name = "playersDataGridView";
            this.playersDataGridView.Size = new System.Drawing.Size(497, 221);
            this.playersDataGridView.TabIndex = 1;
            // 
            // boardGamesTabPage
            // 
            this.boardGamesTabPage.Controls.Add(this.button1);
            this.boardGamesTabPage.Controls.Add(this.button2);
            this.boardGamesTabPage.Controls.Add(this.boardGamesDataGridView);
            this.boardGamesTabPage.Location = new System.Drawing.Point(4, 22);
            this.boardGamesTabPage.Name = "boardGamesTabPage";
            this.boardGamesTabPage.Size = new System.Drawing.Size(928, 524);
            this.boardGamesTabPage.TabIndex = 2;
            this.boardGamesTabPage.Text = "Jeux";
            this.boardGamesTabPage.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(766, 480);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "&Ajouter";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(847, 480);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "&Supprimer";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // boardGamesDataGridView
            // 
            this.boardGamesDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.boardGamesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.boardGamesDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn2,
            this.boardgame_name,
            this.minimumPlayerNumber,
            this.maximumPlayerNumber,
            this.minimumAge,
            this.averageGameTime});
            this.boardGamesDataGridView.Location = new System.Drawing.Point(6, 6);
            this.boardGamesDataGridView.Name = "boardGamesDataGridView";
            this.boardGamesDataGridView.Size = new System.Drawing.Size(671, 221);
            this.boardGamesDataGridView.TabIndex = 2;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.dataGridView1);
            this.tabPage5.Controls.Add(this.eventPlayersDataGridView);
            this.tabPage5.Controls.Add(this.label1);
            this.tabPage5.Controls.Add(this.comboBox1);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(928, 524);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Organisation d\'un événement";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6});
            this.dataGridView1.Location = new System.Drawing.Point(11, 282);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(497, 221);
            this.dataGridView1.TabIndex = 7;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "Identifiant";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Visible = false;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "Prénom";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "Nom de famille";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            // 
            // eventPlayersDataGridView
            // 
            this.eventPlayersDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.eventPlayersDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn3,
            this.eventPlayerFirstname,
            this.eventPlayerLastname});
            this.eventPlayersDataGridView.Location = new System.Drawing.Point(11, 39);
            this.eventPlayersDataGridView.Name = "eventPlayersDataGridView";
            this.eventPlayersDataGridView.Size = new System.Drawing.Size(497, 181);
            this.eventPlayersDataGridView.TabIndex = 6;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Identifiant";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Visible = false;
            // 
            // eventPlayerFirstname
            // 
            this.eventPlayerFirstname.HeaderText = "Prénom";
            this.eventPlayerFirstname.Name = "eventPlayerFirstname";
            // 
            // eventPlayerLastname
            // 
            this.eventPlayerLastname.HeaderText = "Nom de famille";
            this.eventPlayerLastname.Name = "eventPlayerLastname";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Événement:";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(78, 12);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(237, 21);
            this.comboBox1.TabIndex = 4;
            // 
            // tabPage4
            // 
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(928, 524);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Rapports";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 528);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(936, 22);
            this.statusStrip1.TabIndex = 1;
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(84, 17);
            this.toolStripStatusLabel1.Text = "EtatConnexion";
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Id";
            this.dataGridViewTextBoxColumn1.HeaderText = "Identifiant";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // firstname
            // 
            this.firstname.DataPropertyName = "Firstname";
            this.firstname.HeaderText = "Prénom";
            this.firstname.Name = "firstname";
            // 
            // lastname
            // 
            this.lastname.DataPropertyName = "Lastname";
            this.lastname.HeaderText = "Nom de famille";
            this.lastname.Name = "lastname";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Id";
            this.dataGridViewTextBoxColumn2.HeaderText = "Identifiant";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Visible = false;
            // 
            // boardgame_name
            // 
            this.boardgame_name.DataPropertyName = "Name";
            this.boardgame_name.HeaderText = "Nom";
            this.boardgame_name.Name = "boardgame_name";
            // 
            // minimumPlayerNumber
            // 
            this.minimumPlayerNumber.DataPropertyName = "MinimumPlayerNumber";
            this.minimumPlayerNumber.HeaderText = "Nombre minimum de joueurs";
            this.minimumPlayerNumber.Name = "minimumPlayerNumber";
            // 
            // maximumPlayerNumber
            // 
            this.maximumPlayerNumber.DataPropertyName = "MaximumPlayerNumber";
            this.maximumPlayerNumber.HeaderText = "Nombre maximum de joueurs";
            this.maximumPlayerNumber.Name = "maximumPlayerNumber";
            // 
            // minimumAge
            // 
            this.minimumAge.DataPropertyName = "MinimumAge";
            this.minimumAge.HeaderText = "Âge minimum";
            this.minimumAge.Name = "minimumAge";
            // 
            // averageGameTime
            // 
            this.averageGameTime.DataPropertyName = "AverageGameTime";
            this.averageGameTime.HeaderText = "Durée moyenne (minutes)";
            this.averageGameTime.Name = "averageGameTime";
            // 
            // id
            // 
            this.id.DataPropertyName = "Id";
            this.id.HeaderText = "Identifiant";
            this.id.Name = "id";
            this.id.Visible = false;
            // 
            // name
            // 
            this.name.DataPropertyName = "Name";
            this.name.HeaderText = "Nom";
            this.name.Name = "name";
            // 
            // description
            // 
            this.description.DataPropertyName = "Description";
            this.description.HeaderText = "Description";
            this.description.Name = "description";
            // 
            // date
            // 
            this.date.DataPropertyName = "Datestart";
            dataGridViewCellStyle1.Format = "D";
            dataGridViewCellStyle1.NullValue = null;
            this.date.DefaultCellStyle = dataGridViewCellStyle1;
            this.date.HeaderText = "Date";
            this.date.Name = "date";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(936, 550);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tabControl);
            this.Name = "MainWindow";
            this.Text = "FourDice";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.tabControl.ResumeLayout(false);
            this.eventsTabPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.eventsDataGridView)).EndInit();
            this.playersTabPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.playersDataGridView)).EndInit();
            this.boardGamesTabPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.boardGamesDataGridView)).EndInit();
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.eventPlayersDataGridView)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage eventsTabPage;
        private System.Windows.Forms.TabPage playersTabPage;
        private System.Windows.Forms.TabPage boardGamesTabPage;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Button btnAddEvent;
        private System.Windows.Forms.Button btnDeleteEvent;
        private System.Windows.Forms.DataGridView eventsDataGridView;
        private System.Windows.Forms.DataGridView playersDataGridView;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Button btnAddPlayer;
        private System.Windows.Forms.Button btnDeletePlayer;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridView boardGamesDataGridView;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridView eventPlayersDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn eventPlayerFirstname;
        private System.Windows.Forms.DataGridViewTextBoxColumn eventPlayerLastname;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn firstname;
        private System.Windows.Forms.DataGridViewTextBoxColumn lastname;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn boardgame_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn minimumPlayerNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn maximumPlayerNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn minimumAge;
        private System.Windows.Forms.DataGridViewTextBoxColumn averageGameTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn description;
        private System.Windows.Forms.DataGridViewTextBoxColumn date;

    }
}

