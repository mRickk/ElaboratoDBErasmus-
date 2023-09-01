
namespace ElabDBMazzi
{
    partial class FormRegistrazione
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormRegistrazione));
            this.boxRuolo = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.numericNumCivico = new System.Windows.Forms.NumericUpDown();
            this.boxVia = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.boxCodPostale = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.boxCitta = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.boxStato = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dateNascita = new System.Windows.Forms.DateTimePicker();
            this.boxTelefono = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.boxMail = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.boxCognome = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.boxNome = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.boxCF = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.numericMatricola = new System.Windows.Forms.NumericUpDown();
            this.boxCorso = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.dateImmatricolazione = new System.Windows.Forms.DateTimePicker();
            this.boxUniversita = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.buttonRegistrati = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericNumCivico)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericMatricola)).BeginInit();
            this.SuspendLayout();
            // 
            // boxRuolo
            // 
            this.boxRuolo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.boxRuolo.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.boxRuolo.FormattingEnabled = true;
            this.boxRuolo.Items.AddRange(new object[] {
            "Studente",
            "Locatore",
            "Intermediario"});
            this.boxRuolo.Location = new System.Drawing.Point(75, 28);
            this.boxRuolo.Name = "boxRuolo";
            this.boxRuolo.Size = new System.Drawing.Size(220, 25);
            this.boxRuolo.TabIndex = 4;
            this.boxRuolo.SelectedIndexChanged += new System.EventHandler(this.boxAccesso_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.numericNumCivico);
            this.groupBox1.Controls.Add(this.boxVia);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.boxCodPostale);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.boxCitta);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.boxStato);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.dateNascita);
            this.groupBox1.Controls.Add(this.boxTelefono);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.boxMail);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.boxCognome);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.boxNome);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.boxCF);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(898, 175);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Persona";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(504, 135);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(97, 19);
            this.label11.TabIndex = 26;
            this.label11.Text = "Num. Civico: *";
            // 
            // numericNumCivico
            // 
            this.numericNumCivico.Enabled = false;
            this.numericNumCivico.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericNumCivico.Location = new System.Drawing.Point(607, 133);
            this.numericNumCivico.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numericNumCivico.Name = "numericNumCivico";
            this.numericNumCivico.ReadOnly = true;
            this.numericNumCivico.Size = new System.Drawing.Size(144, 25);
            this.numericNumCivico.TabIndex = 25;
            // 
            // boxVia
            // 
            this.boxVia.Enabled = false;
            this.boxVia.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.boxVia.Location = new System.Drawing.Point(54, 134);
            this.boxVia.Name = "boxVia";
            this.boxVia.Size = new System.Drawing.Size(444, 25);
            this.boxVia.TabIndex = 24;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(7, 135);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 19);
            this.label10.TabIndex = 23;
            this.label10.Text = "Via: *";
            // 
            // boxCodPostale
            // 
            this.boxCodPostale.Enabled = false;
            this.boxCodPostale.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.boxCodPostale.Location = new System.Drawing.Point(656, 96);
            this.boxCodPostale.Name = "boxCodPostale";
            this.boxCodPostale.Size = new System.Drawing.Size(196, 25);
            this.boxCodPostale.TabIndex = 22;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(538, 97);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(112, 19);
            this.label9.TabIndex = 21;
            this.label9.Text = "Codice Postale: *";
            // 
            // boxCitta
            // 
            this.boxCitta.Enabled = false;
            this.boxCitta.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.boxCitta.Location = new System.Drawing.Point(190, 96);
            this.boxCitta.Name = "boxCitta";
            this.boxCitta.Size = new System.Drawing.Size(342, 25);
            this.boxCitta.TabIndex = 20;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(133, 97);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(51, 19);
            this.label8.TabIndex = 19;
            this.label8.Text = "Citta: *";
            // 
            // boxStato
            // 
            this.boxStato.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.boxStato.Enabled = false;
            this.boxStato.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.boxStato.FormattingEnabled = true;
            this.boxStato.Items.AddRange(new object[] {
            "AT",
            "BE",
            "BG",
            "HR",
            "CY",
            "CZ",
            "DK",
            "EE",
            "FI",
            "FR",
            "DE",
            "GR",
            "HU",
            "IE",
            "IT",
            "LV",
            "LT",
            "LU",
            "MT",
            "NL",
            "PL",
            "PT",
            "RO",
            "SK",
            "SI",
            "ES",
            "SE",
            "GB"});
            this.boxStato.Location = new System.Drawing.Point(68, 94);
            this.boxStato.Name = "boxStato";
            this.boxStato.Size = new System.Drawing.Size(59, 27);
            this.boxStato.TabIndex = 18;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(7, 97);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 19);
            this.label7.TabIndex = 17;
            this.label7.Text = "Stato: *";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(543, 63);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(113, 19);
            this.label6.TabIndex = 16;
            this.label6.Text = "Data di nascita: *";
            // 
            // dateNascita
            // 
            this.dateNascita.Enabled = false;
            this.dateNascita.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateNascita.Location = new System.Drawing.Point(662, 59);
            this.dateNascita.Name = "dateNascita";
            this.dateNascita.Size = new System.Drawing.Size(229, 25);
            this.dateNascita.TabIndex = 15;
            // 
            // boxTelefono
            // 
            this.boxTelefono.Enabled = false;
            this.boxTelefono.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.boxTelefono.Location = new System.Drawing.Point(382, 62);
            this.boxTelefono.Name = "boxTelefono";
            this.boxTelefono.Size = new System.Drawing.Size(157, 25);
            this.boxTelefono.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(301, 63);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 19);
            this.label5.TabIndex = 13;
            this.label5.Text = "Telefono: *";
            // 
            // boxMail
            // 
            this.boxMail.Enabled = false;
            this.boxMail.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.boxMail.Location = new System.Drawing.Point(61, 63);
            this.boxMail.Name = "boxMail";
            this.boxMail.Size = new System.Drawing.Size(234, 25);
            this.boxMail.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(7, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 19);
            this.label4.TabIndex = 11;
            this.label4.Text = "Mail: *";
            // 
            // boxCognome
            // 
            this.boxCognome.Enabled = false;
            this.boxCognome.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.boxCognome.Location = new System.Drawing.Point(695, 28);
            this.boxCognome.Name = "boxCognome";
            this.boxCognome.Size = new System.Drawing.Size(196, 25);
            this.boxCognome.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(607, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 19);
            this.label3.TabIndex = 9;
            this.label3.Text = "Cognome: *";
            // 
            // boxNome
            // 
            this.boxNome.Enabled = false;
            this.boxNome.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.boxNome.Location = new System.Drawing.Point(405, 28);
            this.boxNome.Name = "boxNome";
            this.boxNome.Size = new System.Drawing.Size(196, 25);
            this.boxNome.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(339, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 19);
            this.label2.TabIndex = 7;
            this.label2.Text = "Nome: *";
            // 
            // boxCF
            // 
            this.boxCF.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.boxCF.Location = new System.Drawing.Point(130, 28);
            this.boxCF.MaxLength = 16;
            this.boxCF.Name = "boxCF";
            this.boxCF.Size = new System.Drawing.Size(203, 25);
            this.boxCF.TabIndex = 6;
            this.boxCF.TextChanged += new System.EventHandler(this.boxCF_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(7, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Codice Fiscale: *";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(656, 339);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(268, 13);
            this.label25.TabIndex = 6;
            this.label25.Text = "(*) i campi contrassegnati con asterisco sono obbligatori";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.numericMatricola);
            this.groupBox2.Controls.Add(this.boxRuolo);
            this.groupBox2.Controls.Add(this.boxCorso);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.label18);
            this.groupBox2.Controls.Add(this.dateImmatricolazione);
            this.groupBox2.Controls.Add(this.boxUniversita);
            this.groupBox2.Controls.Add(this.label19);
            this.groupBox2.Controls.Add(this.label20);
            this.groupBox2.Controls.Add(this.label23);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(12, 188);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(898, 104);
            this.groupBox2.TabIndex = 27;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Ruolo";
            // 
            // numericMatricola
            // 
            this.numericMatricola.Enabled = false;
            this.numericMatricola.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericMatricola.Location = new System.Drawing.Point(736, 63);
            this.numericMatricola.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numericMatricola.Name = "numericMatricola";
            this.numericMatricola.ReadOnly = true;
            this.numericMatricola.Size = new System.Drawing.Size(144, 25);
            this.numericMatricola.TabIndex = 25;
            // 
            // boxCorso
            // 
            this.boxCorso.Enabled = false;
            this.boxCorso.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.boxCorso.Location = new System.Drawing.Point(125, 64);
            this.boxCorso.Name = "boxCorso";
            this.boxCorso.Size = new System.Drawing.Size(146, 25);
            this.boxCorso.TabIndex = 22;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(7, 65);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(104, 19);
            this.label15.TabIndex = 21;
            this.label15.Text = "Codice Corso: *";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(277, 65);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(203, 19);
            this.label18.TabIndex = 16;
            this.label18.Text = "Anno Immatricolazione (data): *";
            // 
            // dateImmatricolazione
            // 
            this.dateImmatricolazione.Enabled = false;
            this.dateImmatricolazione.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateImmatricolazione.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateImmatricolazione.Location = new System.Drawing.Point(486, 60);
            this.dateImmatricolazione.Name = "dateImmatricolazione";
            this.dateImmatricolazione.Size = new System.Drawing.Size(120, 25);
            this.dateImmatricolazione.TabIndex = 15;
            // 
            // boxUniversita
            // 
            this.boxUniversita.Enabled = false;
            this.boxUniversita.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.boxUniversita.Location = new System.Drawing.Point(390, 27);
            this.boxUniversita.Name = "boxUniversita";
            this.boxUniversita.Size = new System.Drawing.Size(490, 25);
            this.boxUniversita.TabIndex = 14;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(301, 29);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(83, 19);
            this.label19.TabIndex = 13;
            this.label19.Text = "Università: *";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(612, 65);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(118, 19);
            this.label20.TabIndex = 11;
            this.label20.Text = "Num. Matricola: *";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.Location = new System.Drawing.Point(7, 29);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(62, 19);
            this.label23.TabIndex = 0;
            this.label23.Text = "Ruolo: *";
            // 
            // buttonRegistrati
            // 
            this.buttonRegistrati.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRegistrati.Location = new System.Drawing.Point(422, 299);
            this.buttonRegistrati.Name = "buttonRegistrati";
            this.buttonRegistrati.Size = new System.Drawing.Size(122, 42);
            this.buttonRegistrati.TabIndex = 28;
            this.buttonRegistrati.Text = "Registrati";
            this.buttonRegistrati.UseVisualStyleBackColor = true;
            this.buttonRegistrati.Click += new System.EventHandler(this.buttonRegistrati_Click);
            // 
            // FormRegistrazione
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(922, 353);
            this.Controls.Add(this.buttonRegistrati);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label25);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormRegistrazione";
            this.Text = "ERASMUS+ Traineeship - Registrazione nuovo utente";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericNumCivico)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericMatricola)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox boxRuolo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.TextBox boxTelefono;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox boxMail;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox boxCognome;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox boxNome;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox boxCF;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dateNascita;
        private System.Windows.Forms.TextBox boxVia;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox boxCodPostale;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox boxCitta;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox boxStato;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.NumericUpDown numericNumCivico;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.NumericUpDown numericMatricola;
        private System.Windows.Forms.TextBox boxCorso;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox boxUniversita;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.DateTimePicker dateImmatricolazione;
        private System.Windows.Forms.Button buttonRegistrati;
    }
}