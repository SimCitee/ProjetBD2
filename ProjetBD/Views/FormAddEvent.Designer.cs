namespace ProjetBD.Views {
    partial class FormAddEvent {
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
            this.rtbNewEventDescription = new System.Windows.Forms.RichTextBox();
            this.tbNewEventName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpNewEventDate = new System.Windows.Forms.DateTimePicker();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnAccept = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nom:";
            // 
            // rtbNewEventDescription
            // 
            this.rtbNewEventDescription.Location = new System.Drawing.Point(81, 35);
            this.rtbNewEventDescription.MaxLength = 256;
            this.rtbNewEventDescription.Name = "rtbNewEventDescription";
            this.rtbNewEventDescription.Size = new System.Drawing.Size(338, 96);
            this.rtbNewEventDescription.TabIndex = 1;
            this.rtbNewEventDescription.Text = "";
            // 
            // tbNewEventName
            // 
            this.tbNewEventName.Location = new System.Drawing.Point(81, 6);
            this.tbNewEventName.MaxLength = 50;
            this.tbNewEventName.Name = "tbNewEventName";
            this.tbNewEventName.Size = new System.Drawing.Size(338, 20);
            this.tbNewEventName.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Description:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 143);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Date:";
            // 
            // dtpNewEventDate
            // 
            this.dtpNewEventDate.Location = new System.Drawing.Point(81, 137);
            this.dtpNewEventDate.Name = "dtpNewEventDate";
            this.dtpNewEventDate.Size = new System.Drawing.Size(200, 20);
            this.dtpNewEventDate.TabIndex = 5;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(344, 163);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "&Annuler";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnAccept
            // 
            this.btnAccept.Location = new System.Drawing.Point(263, 163);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(75, 23);
            this.btnAccept.TabIndex = 7;
            this.btnAccept.Text = "&Accepter";
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // FormAddEvent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(430, 196);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.dtpNewEventDate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbNewEventName);
            this.Controls.Add(this.rtbNewEventDescription);
            this.Controls.Add(this.label1);
            this.Name = "FormAddEvent";
            this.Text = "Nouvel événement";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox rtbNewEventDescription;
        private System.Windows.Forms.TextBox tbNewEventName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpNewEventDate;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnAccept;
    }
}