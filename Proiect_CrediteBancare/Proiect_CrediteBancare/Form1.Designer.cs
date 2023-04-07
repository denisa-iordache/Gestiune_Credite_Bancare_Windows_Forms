namespace Proiect_CrediteBancare
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.listViewAngajati = new System.Windows.Forms.ListView();
            this.columnHeaderNumeA = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderPrenumeA = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderTelefonA = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderEmailA = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listViewClienti = new System.Windows.Forms.ListView();
            this.columnHeaderNumeC = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderPrenumeC = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderDataN = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderCNP = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderTelefonC = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderEmailC = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderVarsta = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderVenit = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderStCiv = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderSex = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.angajatiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.adaugaAngajatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modificaAngajatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stergeAngajatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clientiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.adaugaClientToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modificaClientToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stergeClientToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.creareContractToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.columnNume = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPrenume = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnTelefon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prenumeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.telefonDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.emailDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.angajatiBancaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this._DB_1053DataSet1 = new Proiect_CrediteBancare._DB_1053DataSet1();
            this.angajati_BancaTableAdapter = new Proiect_CrediteBancare._DB_1053DataSet1TableAdapters.Angajati_BancaTableAdapter();
            this.userControl21 = new Proiect_CrediteBancare.UserControl2();
            this.userControl11 = new Proiect_CrediteBancare.UserControl1();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.angajatiBancaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._DB_1053DataSet1)).BeginInit();
            this.SuspendLayout();
            // 
            // listViewAngajati
            // 
            this.listViewAngajati.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderNumeA,
            this.columnHeaderPrenumeA,
            this.columnHeaderTelefonA,
            this.columnHeaderEmailA});
            this.listViewAngajati.FullRowSelect = true;
            this.listViewAngajati.GridLines = true;
            this.listViewAngajati.HideSelection = false;
            this.listViewAngajati.Location = new System.Drawing.Point(275, 12);
            this.listViewAngajati.Name = "listViewAngajati";
            this.listViewAngajati.Size = new System.Drawing.Size(403, 180);
            this.listViewAngajati.TabIndex = 0;
            this.listViewAngajati.UseCompatibleStateImageBehavior = false;
            this.listViewAngajati.View = System.Windows.Forms.View.Details;
            this.listViewAngajati.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listViewAngajati_MouseDown);
            // 
            // columnHeaderNumeA
            // 
            this.columnHeaderNumeA.Text = "Nume Angajat";
            this.columnHeaderNumeA.Width = 100;
            // 
            // columnHeaderPrenumeA
            // 
            this.columnHeaderPrenumeA.Text = "Prenume Angajat";
            this.columnHeaderPrenumeA.Width = 100;
            // 
            // columnHeaderTelefonA
            // 
            this.columnHeaderTelefonA.Text = "Telefon Angajat";
            this.columnHeaderTelefonA.Width = 100;
            // 
            // columnHeaderEmailA
            // 
            this.columnHeaderEmailA.Text = "Email Angajat";
            this.columnHeaderEmailA.Width = 120;
            // 
            // listViewClienti
            // 
            this.listViewClienti.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderNumeC,
            this.columnHeaderPrenumeC,
            this.columnHeaderDataN,
            this.columnHeaderCNP,
            this.columnHeaderTelefonC,
            this.columnHeaderEmailC,
            this.columnHeaderVarsta,
            this.columnHeaderVenit,
            this.columnHeaderStCiv,
            this.columnHeaderSex});
            this.listViewClienti.FullRowSelect = true;
            this.listViewClienti.GridLines = true;
            this.listViewClienti.HideSelection = false;
            this.listViewClienti.Location = new System.Drawing.Point(12, 199);
            this.listViewClienti.Name = "listViewClienti";
            this.listViewClienti.Size = new System.Drawing.Size(1005, 200);
            this.listViewClienti.TabIndex = 1;
            this.listViewClienti.UseCompatibleStateImageBehavior = false;
            this.listViewClienti.View = System.Windows.Forms.View.Details;
            this.listViewClienti.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listViewClienti_MouseDown);
            // 
            // columnHeaderNumeC
            // 
            this.columnHeaderNumeC.Text = "Nume Client";
            this.columnHeaderNumeC.Width = 100;
            // 
            // columnHeaderPrenumeC
            // 
            this.columnHeaderPrenumeC.Text = "Prenume Client";
            this.columnHeaderPrenumeC.Width = 100;
            // 
            // columnHeaderDataN
            // 
            this.columnHeaderDataN.Text = "Data Nasterii";
            this.columnHeaderDataN.Width = 100;
            // 
            // columnHeaderCNP
            // 
            this.columnHeaderCNP.Text = "CNP";
            this.columnHeaderCNP.Width = 100;
            // 
            // columnHeaderTelefonC
            // 
            this.columnHeaderTelefonC.Text = "Telefon Client";
            this.columnHeaderTelefonC.Width = 100;
            // 
            // columnHeaderEmailC
            // 
            this.columnHeaderEmailC.Text = "Email Client";
            this.columnHeaderEmailC.Width = 120;
            // 
            // columnHeaderVarsta
            // 
            this.columnHeaderVarsta.Text = "Varsta";
            this.columnHeaderVarsta.Width = 100;
            // 
            // columnHeaderVenit
            // 
            this.columnHeaderVenit.Text = "Venit Net";
            this.columnHeaderVenit.Width = 100;
            // 
            // columnHeaderStCiv
            // 
            this.columnHeaderStCiv.Text = "Stare Civila";
            this.columnHeaderStCiv.Width = 100;
            // 
            // columnHeaderSex
            // 
            this.columnHeaderSex.Text = "Sex";
            this.columnHeaderSex.Width = 100;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.angajatiToolStripMenuItem,
            this.clientiToolStripMenuItem,
            this.creareContractToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1029, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(12, 20);
            // 
            // angajatiToolStripMenuItem
            // 
            this.angajatiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.adaugaAngajatToolStripMenuItem,
            this.modificaAngajatToolStripMenuItem,
            this.stergeAngajatToolStripMenuItem});
            this.angajatiToolStripMenuItem.Name = "angajatiToolStripMenuItem";
            this.angajatiToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
            this.angajatiToolStripMenuItem.Text = "Angajati";
            // 
            // adaugaAngajatToolStripMenuItem
            // 
            this.adaugaAngajatToolStripMenuItem.Name = "adaugaAngajatToolStripMenuItem";
            this.adaugaAngajatToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.adaugaAngajatToolStripMenuItem.Text = "Adauga angajat";
            this.adaugaAngajatToolStripMenuItem.Click += new System.EventHandler(this.adaugaAngajatToolStripMenuItem_Click);
            // 
            // modificaAngajatToolStripMenuItem
            // 
            this.modificaAngajatToolStripMenuItem.Name = "modificaAngajatToolStripMenuItem";
            this.modificaAngajatToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.modificaAngajatToolStripMenuItem.Text = "Modifica angajat";
            this.modificaAngajatToolStripMenuItem.Click += new System.EventHandler(this.modificaAngajatToolStripMenuItem_Click);
            // 
            // stergeAngajatToolStripMenuItem
            // 
            this.stergeAngajatToolStripMenuItem.Name = "stergeAngajatToolStripMenuItem";
            this.stergeAngajatToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.stergeAngajatToolStripMenuItem.Text = "Sterge angajat";
            this.stergeAngajatToolStripMenuItem.Click += new System.EventHandler(this.stergeAngajatToolStripMenuItem_Click);
            // 
            // clientiToolStripMenuItem
            // 
            this.clientiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.adaugaClientToolStripMenuItem,
            this.modificaClientToolStripMenuItem,
            this.stergeClientToolStripMenuItem});
            this.clientiToolStripMenuItem.Name = "clientiToolStripMenuItem";
            this.clientiToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.clientiToolStripMenuItem.Text = "Clienti";
            // 
            // adaugaClientToolStripMenuItem
            // 
            this.adaugaClientToolStripMenuItem.Name = "adaugaClientToolStripMenuItem";
            this.adaugaClientToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.adaugaClientToolStripMenuItem.Text = "Adauga client";
            this.adaugaClientToolStripMenuItem.Click += new System.EventHandler(this.adaugaClientToolStripMenuItem_Click);
            // 
            // modificaClientToolStripMenuItem
            // 
            this.modificaClientToolStripMenuItem.Name = "modificaClientToolStripMenuItem";
            this.modificaClientToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.modificaClientToolStripMenuItem.Text = "Modifica client";
            this.modificaClientToolStripMenuItem.Click += new System.EventHandler(this.modificaClientToolStripMenuItem_Click);
            // 
            // stergeClientToolStripMenuItem
            // 
            this.stergeClientToolStripMenuItem.Name = "stergeClientToolStripMenuItem";
            this.stergeClientToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.stergeClientToolStripMenuItem.Text = "Sterge client";
            this.stergeClientToolStripMenuItem.Click += new System.EventHandler(this.stergeClientToolStripMenuItem_Click);
            // 
            // creareContractToolStripMenuItem
            // 
            this.creareContractToolStripMenuItem.Name = "creareContractToolStripMenuItem";
            this.creareContractToolStripMenuItem.Size = new System.Drawing.Size(100, 20);
            this.creareContractToolStripMenuItem.Text = "Creare contract";
            this.creareContractToolStripMenuItem.Click += new System.EventHandler(this.creareContractToolStripMenuItem_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.columnNume,
            this.ColumnPrenume,
            this.ColumnTelefon,
            this.ColumnEmail,
            this.idDataGridViewTextBoxColumn,
            this.numeDataGridViewTextBoxColumn,
            this.prenumeDataGridViewTextBoxColumn,
            this.telefonDataGridViewTextBoxColumn,
            this.emailDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.angajatiBancaBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(723, 27);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(240, 150);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.Visible = false;
            // 
            // columnNume
            // 
            this.columnNume.DataPropertyName = "Nume";
            this.columnNume.HeaderText = "Nume angajat";
            this.columnNume.Name = "columnNume";
            // 
            // ColumnPrenume
            // 
            this.ColumnPrenume.DataPropertyName = "Prenume";
            this.ColumnPrenume.HeaderText = "Prenume angajat";
            this.ColumnPrenume.Name = "ColumnPrenume";
            // 
            // ColumnTelefon
            // 
            this.ColumnTelefon.DataPropertyName = "Telefon";
            this.ColumnTelefon.HeaderText = "Telefon angajat";
            this.ColumnTelefon.Name = "ColumnTelefon";
            // 
            // ColumnEmail
            // 
            this.ColumnEmail.DataPropertyName = "Email";
            this.ColumnEmail.HeaderText = "Email angajat";
            this.ColumnEmail.Name = "ColumnEmail";
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // numeDataGridViewTextBoxColumn
            // 
            this.numeDataGridViewTextBoxColumn.DataPropertyName = "Nume";
            this.numeDataGridViewTextBoxColumn.HeaderText = "Nume";
            this.numeDataGridViewTextBoxColumn.Name = "numeDataGridViewTextBoxColumn";
            // 
            // prenumeDataGridViewTextBoxColumn
            // 
            this.prenumeDataGridViewTextBoxColumn.DataPropertyName = "Prenume";
            this.prenumeDataGridViewTextBoxColumn.HeaderText = "Prenume";
            this.prenumeDataGridViewTextBoxColumn.Name = "prenumeDataGridViewTextBoxColumn";
            // 
            // telefonDataGridViewTextBoxColumn
            // 
            this.telefonDataGridViewTextBoxColumn.DataPropertyName = "Telefon";
            this.telefonDataGridViewTextBoxColumn.HeaderText = "Telefon";
            this.telefonDataGridViewTextBoxColumn.Name = "telefonDataGridViewTextBoxColumn";
            // 
            // emailDataGridViewTextBoxColumn
            // 
            this.emailDataGridViewTextBoxColumn.DataPropertyName = "Email";
            this.emailDataGridViewTextBoxColumn.HeaderText = "Email";
            this.emailDataGridViewTextBoxColumn.Name = "emailDataGridViewTextBoxColumn";
            // 
            // angajatiBancaBindingSource
            // 
            this.angajatiBancaBindingSource.DataMember = "Angajati_Banca";
            this.angajatiBancaBindingSource.DataSource = this._DB_1053DataSet1;
            // 
            // _DB_1053DataSet1
            // 
            this._DB_1053DataSet1.DataSetName = "_DB_1053DataSet1";
            this._DB_1053DataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // angajati_BancaTableAdapter
            // 
            this.angajati_BancaTableAdapter.ClearBeforeFill = true;
            // 
            // userControl21
            // 
            this.userControl21.Location = new System.Drawing.Point(0, 403);
            this.userControl21.Name = "userControl21";
            this.userControl21.Size = new System.Drawing.Size(228, 38);
            this.userControl21.TabIndex = 4;
            // 
            // userControl11
            // 
            this.userControl11.Location = new System.Drawing.Point(935, 403);
            this.userControl11.Name = "userControl11";
            this.userControl11.Size = new System.Drawing.Size(94, 36);
            this.userControl11.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1029, 435);
            this.Controls.Add(this.userControl21);
            this.Controls.Add(this.userControl11);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.listViewClienti);
            this.Controls.Add(this.listViewAngajati);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.angajatiBancaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._DB_1053DataSet1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ListView listViewAngajati;
        private System.Windows.Forms.ColumnHeader columnHeaderNumeA;
        private System.Windows.Forms.ColumnHeader columnHeaderPrenumeA;
        private System.Windows.Forms.ColumnHeader columnHeaderTelefonA;
        private System.Windows.Forms.ColumnHeader columnHeaderEmailA;
        public System.Windows.Forms.ListView listViewClienti;
        private System.Windows.Forms.ColumnHeader columnHeaderNumeC;
        private System.Windows.Forms.ColumnHeader columnHeaderPrenumeC;
        private System.Windows.Forms.ColumnHeader columnHeaderDataN;
        private System.Windows.Forms.ColumnHeader columnHeaderCNP;
        private System.Windows.Forms.ColumnHeader columnHeaderTelefonC;
        private System.Windows.Forms.ColumnHeader columnHeaderEmailC;
        private System.Windows.Forms.ColumnHeader columnHeaderVarsta;
        private System.Windows.Forms.ColumnHeader columnHeaderVenit;
        private System.Windows.Forms.ColumnHeader columnHeaderStCiv;
        private System.Windows.Forms.ColumnHeader columnHeaderSex;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem angajatiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem adaugaAngajatToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modificaAngajatToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stergeAngajatToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clientiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem adaugaClientToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modificaClientToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stergeClientToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem creareContractToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridView1;
        public _DB_1053DataSet1 _DB_1053DataSet1;
        public System.Windows.Forms.BindingSource angajatiBancaBindingSource;
        public _DB_1053DataSet1TableAdapters.Angajati_BancaTableAdapter angajati_BancaTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnNume;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPrenume;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTelefon;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnEmail;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn numeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn prenumeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn telefonDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn emailDataGridViewTextBoxColumn;
        private UserControl1 userControl11;
        private UserControl2 userControl21;
    }
}

