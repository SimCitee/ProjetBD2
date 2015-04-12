namespace ProjetBD.Views {
    partial class FormAddBoardgame {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.label1 = new System.Windows.Forms.Label();
            this.tbNewBGName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.nudNewBGNbPlayerMin = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.nudNewBGNbPlayerMax = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.nudNewBGAgeMin = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.nudNewBGTimeAvg = new System.Windows.Forms.NumericUpDown();
            this.btnAccept = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudNewBGNbPlayerMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudNewBGNbPlayerMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudNewBGAgeMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudNewBGTimeAvg)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nom:";
            // 
            // tbNewBGName
            // 
            this.tbNewBGName.Location = new System.Drawing.Point(50, 10);
            this.tbNewBGName.Name = "tbNewBGName";
            this.tbNewBGName.Size = new System.Drawing.Size(368, 20);
            this.tbNewBGName.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Nombre de joueur minimum:";
            // 
            // nudNewBGNbPlayerMin
            // 
            this.nudNewBGNbPlayerMin.Location = new System.Drawing.Point(155, 36);
            this.nudNewBGNbPlayerMin.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.nudNewBGNbPlayerMin.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudNewBGNbPlayerMin.Name = "nudNewBGNbPlayerMin";
            this.nudNewBGNbPlayerMin.Size = new System.Drawing.Size(56, 20);
            this.nudNewBGNbPlayerMin.TabIndex = 3;
            this.nudNewBGNbPlayerMin.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(217, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(140, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Nombre de joueur maximum:";
            // 
            // nudNewBGNbPlayerMax
            // 
            this.nudNewBGNbPlayerMax.Location = new System.Drawing.Point(363, 36);
            this.nudNewBGNbPlayerMax.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.nudNewBGNbPlayerMax.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudNewBGNbPlayerMax.Name = "nudNewBGNbPlayerMax";
            this.nudNewBGNbPlayerMax.Size = new System.Drawing.Size(55, 20);
            this.nudNewBGNbPlayerMax.TabIndex = 5;
            this.nudNewBGNbPlayerMax.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Âge minimum:";
            // 
            // nudNewBGAgeMin
            // 
            this.nudNewBGAgeMin.Location = new System.Drawing.Point(155, 62);
            this.nudNewBGAgeMin.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.nudNewBGAgeMin.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudNewBGAgeMin.Name = "nudNewBGAgeMin";
            this.nudNewBGAgeMin.Size = new System.Drawing.Size(56, 20);
            this.nudNewBGAgeMin.TabIndex = 7;
            this.nudNewBGAgeMin.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(217, 64);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(130, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Durée moyenne (minutes):";
            // 
            // nudNewBGTimeAvg
            // 
            this.nudNewBGTimeAvg.Location = new System.Drawing.Point(363, 62);
            this.nudNewBGTimeAvg.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.nudNewBGTimeAvg.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudNewBGTimeAvg.Name = "nudNewBGTimeAvg";
            this.nudNewBGTimeAvg.Size = new System.Drawing.Size(55, 20);
            this.nudNewBGTimeAvg.TabIndex = 9;
            this.nudNewBGTimeAvg.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnAccept
            // 
            this.btnAccept.Location = new System.Drawing.Point(262, 89);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(75, 23);
            this.btnAccept.TabIndex = 11;
            this.btnAccept.Text = "&Accepter";
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(343, 89);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 12;
            this.btnCancel.Text = "&Annuler";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // FormAddBoardgame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(430, 124);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.nudNewBGTimeAvg);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.nudNewBGAgeMin);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.nudNewBGNbPlayerMax);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.nudNewBGNbPlayerMin);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbNewBGName);
            this.Controls.Add(this.label1);
            this.Name = "FormAddBoardgame";
            this.Text = "Nouveau jeu de table";
            ((System.ComponentModel.ISupportInitialize)(this.nudNewBGNbPlayerMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudNewBGNbPlayerMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudNewBGAgeMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudNewBGTimeAvg)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbNewBGName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nudNewBGNbPlayerMin;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nudNewBGNbPlayerMax;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown nudNewBGAgeMin;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown nudNewBGTimeAvg;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Button btnCancel;

    }
}