
namespace ElabDBMazzi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.labelAccesso = new System.Windows.Forms.Label();
            this.boxAccesso = new System.Windows.Forms.ComboBox();
            this.labelCF = new System.Windows.Forms.Label();
            this.boxCF = new System.Windows.Forms.TextBox();
            this.boxID = new System.Windows.Forms.TextBox();
            this.labelCodice = new System.Windows.Forms.Label();
            this.buttonConnect = new System.Windows.Forms.Button();
            this.checkAccesso = new System.Windows.Forms.Label();
            this.checkCF = new System.Windows.Forms.Label();
            this.checkID = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonRegistrati = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // labelAccesso
            // 
            this.labelAccesso.AutoSize = true;
            this.labelAccesso.Font = new System.Drawing.Font("Microsoft JhengHei", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAccesso.Location = new System.Drawing.Point(89, 343);
            this.labelAccesso.Name = "labelAccesso";
            this.labelAccesso.Size = new System.Drawing.Size(233, 24);
            this.labelAccesso.TabIndex = 1;
            this.labelAccesso.Text = "Scegliere tipo di accesso:";
            // 
            // boxAccesso
            // 
            this.boxAccesso.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.boxAccesso.Font = new System.Drawing.Font("Microsoft JhengHei", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.boxAccesso.FormattingEnabled = true;
            this.boxAccesso.Items.AddRange(new object[] {
            "Studente",
            "Locatore",
            "Intermediario"});
            this.boxAccesso.Location = new System.Drawing.Point(365, 340);
            this.boxAccesso.Name = "boxAccesso";
            this.boxAccesso.Size = new System.Drawing.Size(393, 32);
            this.boxAccesso.TabIndex = 3;
            this.boxAccesso.SelectedIndexChanged += new System.EventHandler(this.boxAccesso_SelectedIndexChanged);
            // 
            // labelCF
            // 
            this.labelCF.AutoSize = true;
            this.labelCF.Font = new System.Drawing.Font("Microsoft JhengHei", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCF.Location = new System.Drawing.Point(182, 406);
            this.labelCF.Name = "labelCF";
            this.labelCF.Size = new System.Drawing.Size(140, 24);
            this.labelCF.TabIndex = 4;
            this.labelCF.Text = "Codice Fiscale:";
            // 
            // boxCF
            // 
            this.boxCF.Enabled = false;
            this.boxCF.Font = new System.Drawing.Font("Microsoft JhengHei", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.boxCF.Location = new System.Drawing.Point(365, 397);
            this.boxCF.MaxLength = 16;
            this.boxCF.Name = "boxCF";
            this.boxCF.Size = new System.Drawing.Size(393, 33);
            this.boxCF.TabIndex = 5;
            this.boxCF.TextChanged += new System.EventHandler(this.boxCF_TextChanged);
            // 
            // boxID
            // 
            this.boxID.Enabled = false;
            this.boxID.Font = new System.Drawing.Font("Microsoft JhengHei", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.boxID.Location = new System.Drawing.Point(365, 457);
            this.boxID.Name = "boxID";
            this.boxID.Size = new System.Drawing.Size(393, 33);
            this.boxID.TabIndex = 7;
            this.boxID.TextChanged += new System.EventHandler(this.boxID_TextChanged);
            // 
            // labelCodice
            // 
            this.labelCodice.AutoSize = true;
            this.labelCodice.Font = new System.Drawing.Font("Microsoft JhengHei", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCodice.Location = new System.Drawing.Point(222, 457);
            this.labelCodice.Name = "labelCodice";
            this.labelCodice.Size = new System.Drawing.Size(100, 24);
            this.labelCodice.TabIndex = 6;
            this.labelCodice.Text = "Codice ID:";
            // 
            // buttonConnect
            // 
            this.buttonConnect.Enabled = false;
            this.buttonConnect.Font = new System.Drawing.Font("Microsoft YaHei", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonConnect.Location = new System.Drawing.Point(824, 536);
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.Size = new System.Drawing.Size(130, 35);
            this.buttonConnect.TabIndex = 9;
            this.buttonConnect.Text = "Connettiti";
            this.buttonConnect.UseVisualStyleBackColor = true;
            this.buttonConnect.Click += new System.EventHandler(this.buttonConnect_Click);
            // 
            // checkAccesso
            // 
            this.checkAccesso.AutoSize = true;
            this.checkAccesso.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkAccesso.ForeColor = System.Drawing.Color.Lime;
            this.checkAccesso.Location = new System.Drawing.Point(755, 343);
            this.checkAccesso.Name = "checkAccesso";
            this.checkAccesso.Size = new System.Drawing.Size(36, 37);
            this.checkAccesso.TabIndex = 10;
            this.checkAccesso.Text = "✓";
            this.checkAccesso.Visible = false;
            // 
            // checkCF
            // 
            this.checkCF.AutoSize = true;
            this.checkCF.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkCF.ForeColor = System.Drawing.Color.Lime;
            this.checkCF.Location = new System.Drawing.Point(755, 400);
            this.checkCF.Name = "checkCF";
            this.checkCF.Size = new System.Drawing.Size(36, 37);
            this.checkCF.TabIndex = 11;
            this.checkCF.Text = "✓";
            this.checkCF.Visible = false;
            // 
            // checkID
            // 
            this.checkID.AutoSize = true;
            this.checkID.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkID.ForeColor = System.Drawing.Color.Lime;
            this.checkID.Location = new System.Drawing.Point(755, 460);
            this.checkID.Name = "checkID";
            this.checkID.Size = new System.Drawing.Size(36, 37);
            this.checkID.TabIndex = 12;
            this.checkID.Text = "✓";
            this.checkID.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 557);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(245, 17);
            this.label1.TabIndex = 13;
            this.label1.Text = "Nuovo utente? Clicca qui per registrarti:";
            // 
            // buttonRegistrati
            // 
            this.buttonRegistrati.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRegistrati.Location = new System.Drawing.Point(263, 549);
            this.buttonRegistrati.Name = "buttonRegistrati";
            this.buttonRegistrati.Size = new System.Drawing.Size(91, 30);
            this.buttonRegistrati.TabIndex = 14;
            this.buttonRegistrati.Text = "Registrati";
            this.buttonRegistrati.UseVisualStyleBackColor = true;
            this.buttonRegistrati.Click += new System.EventHandler(this.buttonRegistrati_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::ElabDBMazzi.Properties.Resources.logo21;
            this.pictureBox1.Location = new System.Drawing.Point(113, -2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(738, 329);
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(966, 583);
            this.Controls.Add(this.buttonRegistrati);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkID);
            this.Controls.Add(this.checkCF);
            this.Controls.Add(this.checkAccesso);
            this.Controls.Add(this.buttonConnect);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.boxID);
            this.Controls.Add(this.labelCodice);
            this.Controls.Add(this.boxCF);
            this.Controls.Add(this.labelCF);
            this.Controls.Add(this.boxAccesso);
            this.Controls.Add(this.labelAccesso);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "ERASMUS+ Traineeship";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labelAccesso;
        private System.Windows.Forms.ComboBox boxAccesso;
        private System.Windows.Forms.Label labelCF;
        private System.Windows.Forms.TextBox boxCF;
        private System.Windows.Forms.TextBox boxID;
        private System.Windows.Forms.Label labelCodice;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button buttonConnect;
        private System.Windows.Forms.Label checkAccesso;
        private System.Windows.Forms.Label checkCF;
        private System.Windows.Forms.Label checkID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonRegistrati;
    }
}

