namespace APOTEKA
{
    partial class Apoteka
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
            this.bezPDV = new System.Windows.Forms.ListBox();
            this.ECTS = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.latinski_naziv = new System.Windows.Forms.ListBox();
            this.naziv = new System.Windows.Forms.ListBox();
            this.sadrzano = new System.Windows.Forms.RadioButton();
            this.tacno = new System.Windows.Forms.RadioButton();
            this.searchBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.dodajLijekButton = new System.Windows.Forms.Button();
            this.pretraga = new System.Windows.Forms.Button();
            this.saPDV = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.nazivCheck = new System.Windows.Forms.CheckBox();
            this.latinskiCheck = new System.Windows.Forms.CheckBox();
            this.izmjeniPodatkeButton = new System.Windows.Forms.Button();
            this.ukloniLijekButton = new System.Windows.Forms.Button();
            this.About = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // bezPDV
            // 
            this.bezPDV.FormattingEnabled = true;
            this.bezPDV.Location = new System.Drawing.Point(340, 86);
            this.bezPDV.Name = "bezPDV";
            this.bezPDV.Size = new System.Drawing.Size(85, 225);
            this.bezPDV.TabIndex = 26;
            this.bezPDV.SelectedIndexChanged += new System.EventHandler(this.bezPDV_SelectedIndexChanged);
            // 
            // ECTS
            // 
            this.ECTS.AutoSize = true;
            this.ECTS.Location = new System.Drawing.Point(335, 70);
            this.ECTS.Name = "ECTS";
            this.ECTS.Size = new System.Drawing.Size(90, 13);
            this.ECTS.TabIndex = 25;
            this.ECTS.Text = "Cijena bez PDV-a";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(233, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 13);
            this.label3.TabIndex = 24;
            this.label3.Text = "Latinski naziv";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 23;
            this.label2.Text = "Naziv lijeka";
            // 
            // latinski_naziv
            // 
            this.latinski_naziv.FormattingEnabled = true;
            this.latinski_naziv.Location = new System.Drawing.Point(222, 86);
            this.latinski_naziv.Name = "latinski_naziv";
            this.latinski_naziv.Size = new System.Drawing.Size(112, 225);
            this.latinski_naziv.TabIndex = 21;
            this.latinski_naziv.SelectedIndexChanged += new System.EventHandler(this.latinski_naziv_SelectedIndexChanged);
            // 
            // naziv
            // 
            this.naziv.FormattingEnabled = true;
            this.naziv.Location = new System.Drawing.Point(16, 86);
            this.naziv.Name = "naziv";
            this.naziv.Size = new System.Drawing.Size(200, 225);
            this.naziv.TabIndex = 19;
            this.naziv.SelectedIndexChanged += new System.EventHandler(this.naziv_SelectedIndexChanged);
            // 
            // sadrzano
            // 
            this.sadrzano.AutoSize = true;
            this.sadrzano.Location = new System.Drawing.Point(132, 35);
            this.sadrzano.Name = "sadrzano";
            this.sadrzano.Size = new System.Drawing.Size(113, 17);
            this.sadrzano.TabIndex = 30;
            this.sadrzano.Text = "Sadražno u nazivu";
            this.sadrzano.UseVisualStyleBackColor = true;
            // 
            // tacno
            // 
            this.tacno.AutoSize = true;
            this.tacno.Checked = true;
            this.tacno.Location = new System.Drawing.Point(132, 12);
            this.tacno.Name = "tacno";
            this.tacno.Size = new System.Drawing.Size(84, 17);
            this.tacno.TabIndex = 29;
            this.tacno.TabStop = true;
            this.tacno.Text = "Tačan naziv";
            this.tacno.UseVisualStyleBackColor = true;
            // 
            // searchBox
            // 
            this.searchBox.Location = new System.Drawing.Point(15, 25);
            this.searchBox.Name = "searchBox";
            this.searchBox.Size = new System.Drawing.Size(100, 20);
            this.searchBox.TabIndex = 28;
            this.searchBox.TextChanged += new System.EventHandler(this.searchBox_TextChanged);
            this.searchBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.searchBox_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(51, 13);
            this.label7.TabIndex = 27;
            this.label7.Text = "Traži lijek";
            // 
            // dodajLijekButton
            // 
            this.dodajLijekButton.Location = new System.Drawing.Point(532, 14);
            this.dodajLijekButton.Name = "dodajLijekButton";
            this.dodajLijekButton.Size = new System.Drawing.Size(74, 77);
            this.dodajLijekButton.TabIndex = 32;
            this.dodajLijekButton.Text = "Dodaj lijekove";
            this.dodajLijekButton.UseVisualStyleBackColor = true;
            this.dodajLijekButton.Click += new System.EventHandler(this.dodajLijekButton_Click);
            // 
            // pretraga
            // 
            this.pretraga.Location = new System.Drawing.Point(350, 14);
            this.pretraga.Name = "pretraga";
            this.pretraga.Size = new System.Drawing.Size(176, 40);
            this.pretraga.TabIndex = 31;
            this.pretraga.Text = "Pretraži";
            this.pretraga.UseVisualStyleBackColor = true;
            this.pretraga.Click += new System.EventHandler(this.pretraga_Click);
            // 
            // saPDV
            // 
            this.saPDV.FormattingEnabled = true;
            this.saPDV.Location = new System.Drawing.Point(431, 86);
            this.saPDV.Name = "saPDV";
            this.saPDV.Size = new System.Drawing.Size(95, 225);
            this.saPDV.TabIndex = 34;
            this.saPDV.SelectedIndexChanged += new System.EventHandler(this.saPDV_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(434, 70);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 13);
            this.label4.TabIndex = 33;
            this.label4.Text = "Cijena sa PDV-om";
            // 
            // nazivCheck
            // 
            this.nazivCheck.AutoSize = true;
            this.nazivCheck.Location = new System.Drawing.Point(254, 12);
            this.nazivCheck.Name = "nazivCheck";
            this.nazivCheck.Size = new System.Drawing.Size(80, 17);
            this.nazivCheck.TabIndex = 37;
            this.nazivCheck.Text = "Naziv lijeka";
            this.nazivCheck.UseVisualStyleBackColor = true;
            // 
            // latinskiCheck
            // 
            this.latinskiCheck.AutoSize = true;
            this.latinskiCheck.Location = new System.Drawing.Point(254, 35);
            this.latinskiCheck.Name = "latinskiCheck";
            this.latinskiCheck.Size = new System.Drawing.Size(90, 17);
            this.latinskiCheck.TabIndex = 38;
            this.latinskiCheck.Text = "Latinski naziv";
            this.latinskiCheck.UseVisualStyleBackColor = true;
            // 
            // izmjeniPodatkeButton
            // 
            this.izmjeniPodatkeButton.Location = new System.Drawing.Point(532, 97);
            this.izmjeniPodatkeButton.Name = "izmjeniPodatkeButton";
            this.izmjeniPodatkeButton.Size = new System.Drawing.Size(74, 86);
            this.izmjeniPodatkeButton.TabIndex = 39;
            this.izmjeniPodatkeButton.Text = "Izmijeni podatke lijeka";
            this.izmjeniPodatkeButton.UseVisualStyleBackColor = true;
            this.izmjeniPodatkeButton.Click += new System.EventHandler(this.izmjeniPodatkeButton_Click);
            // 
            // ukloniLijekButton
            // 
            this.ukloniLijekButton.Location = new System.Drawing.Point(532, 189);
            this.ukloniLijekButton.Name = "ukloniLijekButton";
            this.ukloniLijekButton.Size = new System.Drawing.Size(74, 94);
            this.ukloniLijekButton.TabIndex = 40;
            this.ukloniLijekButton.Text = "Ukloni lijek";
            this.ukloniLijekButton.UseVisualStyleBackColor = true;
            this.ukloniLijekButton.Click += new System.EventHandler(this.ukloniLijekButton_Click);
            // 
            // About
            // 
            this.About.AutoSize = true;
            this.About.Location = new System.Drawing.Point(551, 294);
            this.About.Name = "About";
            this.About.Size = new System.Drawing.Size(35, 13);
            this.About.TabIndex = 41;
            this.About.TabStop = true;
            this.About.Text = "About";
            this.About.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.About_LinkClicked);
            // 
            // Apoteka
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(618, 316);
            this.Controls.Add(this.About);
            this.Controls.Add(this.ukloniLijekButton);
            this.Controls.Add(this.izmjeniPodatkeButton);
            this.Controls.Add(this.latinskiCheck);
            this.Controls.Add(this.nazivCheck);
            this.Controls.Add(this.saPDV);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dodajLijekButton);
            this.Controls.Add(this.pretraga);
            this.Controls.Add(this.sadrzano);
            this.Controls.Add(this.tacno);
            this.Controls.Add(this.searchBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.bezPDV);
            this.Controls.Add(this.ECTS);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.latinski_naziv);
            this.Controls.Add(this.naziv);
            this.MaximizeBox = false;
            this.Name = "Apoteka";
            this.Text = "Lista lijekova";
            this.Activated += new System.EventHandler(this.Apoteka_Activated);
            this.Deactivate += new System.EventHandler(this.Apoteka_Deactivate);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Apoteka_FormClosing);
            this.Load += new System.EventHandler(this.Apoteka_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox bezPDV;
        private System.Windows.Forms.Label ECTS;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox latinski_naziv;
        private System.Windows.Forms.ListBox naziv;
        private System.Windows.Forms.RadioButton sadrzano;
        private System.Windows.Forms.RadioButton tacno;
        private System.Windows.Forms.TextBox searchBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button dodajLijekButton;
        private System.Windows.Forms.Button pretraga;
        private System.Windows.Forms.ListBox saPDV;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox nazivCheck;
        private System.Windows.Forms.CheckBox latinskiCheck;
        private System.Windows.Forms.Button izmjeniPodatkeButton;
        private System.Windows.Forms.Button ukloniLijekButton;
        private System.Windows.Forms.LinkLabel About;

    }
}

