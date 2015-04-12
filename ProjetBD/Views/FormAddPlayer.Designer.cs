namespace ProjetBD.Views {
    partial class FormAddPlayer {
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
            this.tbNewPlayerFirstName = new System.Windows.Forms.TextBox();
            this.tbNewPlayerLastName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnAccept = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Prénom:";
            // 
            // tbNewPlayerFirstName
            // 
            this.tbNewPlayerFirstName.Location = new System.Drawing.Point(101, 10);
            this.tbNewPlayerFirstName.Name = "tbNewPlayerFirstName";
            this.tbNewPlayerFirstName.Size = new System.Drawing.Size(317, 20);
            this.tbNewPlayerFirstName.TabIndex = 1;
            // 
            // tbNewPlayerLastName
            // 
            this.tbNewPlayerLastName.Location = new System.Drawing.Point(101, 36);
            this.tbNewPlayerLastName.Name = "tbNewPlayerLastName";
            this.tbNewPlayerLastName.Size = new System.Drawing.Size(317, 20);
            this.tbNewPlayerLastName.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Nom de famille:";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(343, 62);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "&Annuler";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnAccept
            // 
            this.btnAccept.Location = new System.Drawing.Point(262, 62);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(75, 23);
            this.btnAccept.TabIndex = 5;
            this.btnAccept.Text = "&Accepter";
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // FormAddPlayer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(430, 98);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbNewPlayerLastName);
            this.Controls.Add(this.tbNewPlayerFirstName);
            this.Controls.Add(this.label1);
            this.Name = "FormAddPlayer";
            this.Text = "Nouveau joueur";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbNewPlayerFirstName;
        private System.Windows.Forms.TextBox tbNewPlayerLastName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnAccept;
    }
}