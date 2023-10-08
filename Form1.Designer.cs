namespace TaskFormUtenteGenerico
{
    partial class Form1
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbl_Nome = new System.Windows.Forms.Label();
            this.lbl_Cognome = new System.Windows.Forms.Label();
            this.lbl_IndirizzoEmail = new System.Windows.Forms.Label();
            this.lbl_Età = new System.Windows.Forms.Label();
            this.lbl_CodiceFiscale = new System.Windows.Forms.Label();
            this.lbl_title = new System.Windows.Forms.Label();
            this.txtBox_TutteLePersone = new System.Windows.Forms.TextBox();
            this.txtBox_Nome = new System.Windows.Forms.TextBox();
            this.txtBox_Cognome = new System.Windows.Forms.TextBox();
            this.txtBox_IndirizzoEmail = new System.Windows.Forms.TextBox();
            this.txtBox_Eta = new System.Windows.Forms.TextBox();
            this.txtBox_CodiceFiscale = new System.Windows.Forms.TextBox();
            this.btn_Partecipa = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_Modifica = new System.Windows.Forms.Button();
            this.btn_Elimina = new System.Windows.Forms.Button();
            this.listBox_TutteLePersone = new System.Windows.Forms.ListBox();
            this.dgw = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgw)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_Nome
            // 
            this.lbl_Nome.AutoSize = true;
            this.lbl_Nome.Font = new System.Drawing.Font("Monotype Corsiva", 24F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Nome.Location = new System.Drawing.Point(24, 111);
            this.lbl_Nome.Name = "lbl_Nome";
            this.lbl_Nome.Size = new System.Drawing.Size(98, 39);
            this.lbl_Nome.TabIndex = 0;
            this.lbl_Nome.Text = "Nome: ";
            // 
            // lbl_Cognome
            // 
            this.lbl_Cognome.AutoSize = true;
            this.lbl_Cognome.Font = new System.Drawing.Font("Monotype Corsiva", 24F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Cognome.Location = new System.Drawing.Point(24, 158);
            this.lbl_Cognome.Name = "lbl_Cognome";
            this.lbl_Cognome.Size = new System.Drawing.Size(134, 39);
            this.lbl_Cognome.TabIndex = 1;
            this.lbl_Cognome.Text = "Cognome: ";
            // 
            // lbl_IndirizzoEmail
            // 
            this.lbl_IndirizzoEmail.AutoSize = true;
            this.lbl_IndirizzoEmail.Font = new System.Drawing.Font("Monotype Corsiva", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_IndirizzoEmail.Location = new System.Drawing.Point(26, 213);
            this.lbl_IndirizzoEmail.Name = "lbl_IndirizzoEmail";
            this.lbl_IndirizzoEmail.Size = new System.Drawing.Size(150, 25);
            this.lbl_IndirizzoEmail.TabIndex = 2;
            this.lbl_IndirizzoEmail.Text = "*Indirizzo Email: ";
            // 
            // lbl_Età
            // 
            this.lbl_Età.AutoSize = true;
            this.lbl_Età.Font = new System.Drawing.Font("Monotype Corsiva", 24F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Età.Location = new System.Drawing.Point(24, 248);
            this.lbl_Età.Name = "lbl_Età";
            this.lbl_Età.Size = new System.Drawing.Size(75, 39);
            this.lbl_Età.TabIndex = 3;
            this.lbl_Età.Text = "Età: ";
            // 
            // lbl_CodiceFiscale
            // 
            this.lbl_CodiceFiscale.AutoSize = true;
            this.lbl_CodiceFiscale.Font = new System.Drawing.Font("Monotype Corsiva", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_CodiceFiscale.Location = new System.Drawing.Point(26, 303);
            this.lbl_CodiceFiscale.Name = "lbl_CodiceFiscale";
            this.lbl_CodiceFiscale.Size = new System.Drawing.Size(126, 25);
            this.lbl_CodiceFiscale.TabIndex = 4;
            this.lbl_CodiceFiscale.Text = "Codice Fiscale: ";
            // 
            // lbl_title
            // 
            this.lbl_title.AllowDrop = true;
            this.lbl_title.AutoEllipsis = true;
            this.lbl_title.AutoSize = true;
            this.lbl_title.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lbl_title.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_title.Font = new System.Drawing.Font("Monotype Corsiva", 27.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_title.Location = new System.Drawing.Point(31, 47);
            this.lbl_title.Name = "lbl_title";
            this.lbl_title.Size = new System.Drawing.Size(294, 47);
            this.lbl_title.TabIndex = 5;
            this.lbl_title.Text = "Partecipa alla Lista!";
            // 
            // txtBox_TutteLePersone
            // 
            this.txtBox_TutteLePersone.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBox_TutteLePersone.Location = new System.Drawing.Point(31, 399);
            this.txtBox_TutteLePersone.Multiline = true;
            this.txtBox_TutteLePersone.Name = "txtBox_TutteLePersone";
            this.txtBox_TutteLePersone.ReadOnly = true;
            this.txtBox_TutteLePersone.Size = new System.Drawing.Size(375, 342);
            this.txtBox_TutteLePersone.TabIndex = 6;
            this.txtBox_TutteLePersone.TextChanged += new System.EventHandler(this.txtBox_TutteLePersone_TextChanged);
            // 
            // txtBox_Nome
            // 
            this.txtBox_Nome.Location = new System.Drawing.Point(175, 119);
            this.txtBox_Nome.Name = "txtBox_Nome";
            this.txtBox_Nome.Size = new System.Drawing.Size(213, 31);
            this.txtBox_Nome.TabIndex = 7;
            // 
            // txtBox_Cognome
            // 
            this.txtBox_Cognome.Location = new System.Drawing.Point(175, 166);
            this.txtBox_Cognome.Name = "txtBox_Cognome";
            this.txtBox_Cognome.Size = new System.Drawing.Size(213, 31);
            this.txtBox_Cognome.TabIndex = 8;
            // 
            // txtBox_IndirizzoEmail
            // 
            this.txtBox_IndirizzoEmail.Location = new System.Drawing.Point(175, 213);
            this.txtBox_IndirizzoEmail.Name = "txtBox_IndirizzoEmail";
            this.txtBox_IndirizzoEmail.Size = new System.Drawing.Size(213, 31);
            this.txtBox_IndirizzoEmail.TabIndex = 9;
            // 
            // txtBox_Eta
            // 
            this.txtBox_Eta.Location = new System.Drawing.Point(175, 256);
            this.txtBox_Eta.Name = "txtBox_Eta";
            this.txtBox_Eta.Size = new System.Drawing.Size(213, 31);
            this.txtBox_Eta.TabIndex = 10;
            // 
            // txtBox_CodiceFiscale
            // 
            this.txtBox_CodiceFiscale.Location = new System.Drawing.Point(175, 297);
            this.txtBox_CodiceFiscale.Name = "txtBox_CodiceFiscale";
            this.txtBox_CodiceFiscale.Size = new System.Drawing.Size(213, 31);
            this.txtBox_CodiceFiscale.TabIndex = 11;
            // 
            // btn_Partecipa
            // 
            this.btn_Partecipa.Font = new System.Drawing.Font("Monotype Corsiva", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Partecipa.Location = new System.Drawing.Point(164, 351);
            this.btn_Partecipa.Name = "btn_Partecipa";
            this.btn_Partecipa.Size = new System.Drawing.Size(101, 42);
            this.btn_Partecipa.TabIndex = 12;
            this.btn_Partecipa.Text = "Inserisci";
            this.btn_Partecipa.UseVisualStyleBackColor = true;
            this.btn_Partecipa.Click += new System.EventHandler(this.btn_Inserisci_Click);
            // 
            // label1
            // 
            this.label1.AllowDrop = true;
            this.label1.AutoEllipsis = true;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Font = new System.Drawing.Font("Monotype Corsiva", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(428, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(306, 30);
            this.label1.TabIndex = 13;
            this.label1.Text = "Nome, Cognome, Email, Età, C.F. ";
            // 
            // btn_Modifica
            // 
            this.btn_Modifica.Font = new System.Drawing.Font("Monotype Corsiva", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Modifica.Location = new System.Drawing.Point(31, 351);
            this.btn_Modifica.Name = "btn_Modifica";
            this.btn_Modifica.Size = new System.Drawing.Size(102, 43);
            this.btn_Modifica.TabIndex = 15;
            this.btn_Modifica.Text = "Modifica";
            this.btn_Modifica.UseVisualStyleBackColor = true;
            this.btn_Modifica.Click += new System.EventHandler(this.btn_Modifica_Click);
            // 
            // btn_Elimina
            // 
            this.btn_Elimina.Font = new System.Drawing.Font("Monotype Corsiva", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Elimina.Location = new System.Drawing.Point(295, 351);
            this.btn_Elimina.Name = "btn_Elimina";
            this.btn_Elimina.Size = new System.Drawing.Size(93, 42);
            this.btn_Elimina.TabIndex = 16;
            this.btn_Elimina.Text = "Elimina";
            this.btn_Elimina.UseVisualStyleBackColor = true;
            this.btn_Elimina.Click += new System.EventHandler(this.btn_Elimina_Click);
            // 
            // listBox_TutteLePersone
            // 
            this.listBox_TutteLePersone.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox_TutteLePersone.FormattingEnabled = true;
            this.listBox_TutteLePersone.ItemHeight = 15;
            this.listBox_TutteLePersone.Location = new System.Drawing.Point(428, 587);
            this.listBox_TutteLePersone.Name = "listBox_TutteLePersone";
            this.listBox_TutteLePersone.Size = new System.Drawing.Size(745, 154);
            this.listBox_TutteLePersone.TabIndex = 18;
            this.listBox_TutteLePersone.SelectedIndexChanged += new System.EventHandler(this.listBox_TutteLePersone_SelectedIndexChanged);
            // 
            // dgw
            // 
            this.dgw.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgw.Location = new System.Drawing.Point(428, 94);
            this.dgw.Name = "dgw";
            this.dgw.Size = new System.Drawing.Size(745, 474);
            this.dgw.TabIndex = 19;
            this.dgw.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgw_CellContentClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1211, 771);
            this.Controls.Add(this.dgw);
            this.Controls.Add(this.listBox_TutteLePersone);
            this.Controls.Add(this.btn_Elimina);
            this.Controls.Add(this.btn_Modifica);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_Partecipa);
            this.Controls.Add(this.txtBox_CodiceFiscale);
            this.Controls.Add(this.txtBox_Eta);
            this.Controls.Add(this.txtBox_IndirizzoEmail);
            this.Controls.Add(this.txtBox_Cognome);
            this.Controls.Add(this.txtBox_Nome);
            this.Controls.Add(this.txtBox_TutteLePersone);
            this.Controls.Add(this.lbl_title);
            this.Controls.Add(this.lbl_CodiceFiscale);
            this.Controls.Add(this.lbl_Età);
            this.Controls.Add(this.lbl_IndirizzoEmail);
            this.Controls.Add(this.lbl_Cognome);
            this.Controls.Add(this.lbl_Nome);
            this.Font = new System.Drawing.Font("Monotype Corsiva", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormUtenteGenerico";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgw)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_Nome;
        private System.Windows.Forms.Label lbl_Cognome;
        private System.Windows.Forms.Label lbl_IndirizzoEmail;
        private System.Windows.Forms.Label lbl_Età;
        private System.Windows.Forms.Label lbl_CodiceFiscale;
        public System.Windows.Forms.Label lbl_title;
        private System.Windows.Forms.TextBox txtBox_TutteLePersone;
        private System.Windows.Forms.TextBox txtBox_Nome;
        private System.Windows.Forms.TextBox txtBox_Cognome;
        private System.Windows.Forms.TextBox txtBox_IndirizzoEmail;
        private System.Windows.Forms.TextBox txtBox_Eta;
        private System.Windows.Forms.TextBox txtBox_CodiceFiscale;
        private System.Windows.Forms.Button btn_Partecipa;
        public System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_Modifica;
        private System.Windows.Forms.Button btn_Elimina;
        private System.Windows.Forms.ListBox listBox_TutteLePersone;
        private System.Windows.Forms.DataGridView dgw;
    }
}

