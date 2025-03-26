using System.Windows.Forms;

namespace WFAMaasBordroProgrami.UI
{
    partial class MemurIslemleri
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            cmbMemurDerece = new Guna.UI2.WinForms.Guna2ComboBox();
            guna2HtmlLabel5 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            guna2HtmlLabel3 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            guna2HtmlLabel4 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            txtMemurAdSoyad = new Guna.UI2.WinForms.Guna2TextBox();
            txtMemurCalismaSaati = new Guna.UI2.WinForms.Guna2TextBox();
            btnSil = new Button();
            btnGuncelle = new Button();
            dgvMemurlar = new Guna.UI2.WinForms.Guna2DataGridView();
            guna2TextBox1 = new Guna.UI2.WinForms.Guna2TextBox();
            guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            btnMemurEkle = new Button();
            guna2HtmlLabel2 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            ((System.ComponentModel.ISupportInitialize)dgvMemurlar).BeginInit();
            SuspendLayout();
            // 
            // cmbMemurDerece
            // 
            cmbMemurDerece.BackColor = Color.Transparent;
            cmbMemurDerece.CustomizableEdges = customizableEdges1;
            cmbMemurDerece.DrawMode = DrawMode.OwnerDrawFixed;
            cmbMemurDerece.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMemurDerece.FocusedColor = Color.FromArgb(94, 148, 255);
            cmbMemurDerece.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            cmbMemurDerece.Font = new Font("Segoe UI", 10F);
            cmbMemurDerece.ForeColor = Color.FromArgb(68, 88, 112);
            cmbMemurDerece.ItemHeight = 30;
            cmbMemurDerece.Location = new Point(579, 231);
            cmbMemurDerece.Name = "cmbMemurDerece";
            cmbMemurDerece.ShadowDecoration.CustomizableEdges = customizableEdges2;
            cmbMemurDerece.Size = new Size(358, 36);
            cmbMemurDerece.TabIndex = 20;
            // 
            // guna2HtmlLabel5
            // 
            guna2HtmlLabel5.BackColor = Color.Transparent;
            guna2HtmlLabel5.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 162);
            guna2HtmlLabel5.ForeColor = Color.Black;
            guna2HtmlLabel5.Location = new Point(579, 199);
            guna2HtmlLabel5.Name = "guna2HtmlLabel5";
            guna2HtmlLabel5.Size = new Size(56, 25);
            guna2HtmlLabel5.TabIndex = 15;
            guna2HtmlLabel5.Text = "Derece";
            // 
            // guna2HtmlLabel3
            // 
            guna2HtmlLabel3.BackColor = Color.Transparent;
            guna2HtmlLabel3.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 162);
            guna2HtmlLabel3.ForeColor = Color.Black;
            guna2HtmlLabel3.Location = new Point(124, 104);
            guna2HtmlLabel3.Name = "guna2HtmlLabel3";
            guna2HtmlLabel3.Size = new Size(134, 25);
            guna2HtmlLabel3.TabIndex = 16;
            guna2HtmlLabel3.Text = "Çalışan Ad Soyad";
            // 
            // guna2HtmlLabel4
            // 
            guna2HtmlLabel4.BackColor = Color.Transparent;
            guna2HtmlLabel4.Font = new Font("Segoe UI", 10.2F);
            guna2HtmlLabel4.ForeColor = Color.Black;
            guna2HtmlLabel4.Location = new Point(124, 199);
            guna2HtmlLabel4.Name = "guna2HtmlLabel4";
            guna2HtmlLabel4.Size = new Size(166, 25);
            guna2HtmlLabel4.TabIndex = 17;
            guna2HtmlLabel4.Text = "Toplam Çalışma Saati";
            // 
            // txtMemurAdSoyad
            // 
            txtMemurAdSoyad.CustomizableEdges = customizableEdges3;
            txtMemurAdSoyad.DefaultText = "";
            txtMemurAdSoyad.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtMemurAdSoyad.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtMemurAdSoyad.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtMemurAdSoyad.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtMemurAdSoyad.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtMemurAdSoyad.Font = new Font("Microsoft Sans Serif", 10.2F);
            txtMemurAdSoyad.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtMemurAdSoyad.Location = new Point(124, 136);
            txtMemurAdSoyad.Margin = new Padding(4);
            txtMemurAdSoyad.Name = "txtMemurAdSoyad";
            txtMemurAdSoyad.PlaceholderText = "";
            txtMemurAdSoyad.SelectedText = "";
            txtMemurAdSoyad.ShadowDecoration.CustomizableEdges = customizableEdges4;
            txtMemurAdSoyad.Size = new Size(358, 36);
            txtMemurAdSoyad.TabIndex = 14;
            // 
            // txtMemurCalismaSaati
            // 
            txtMemurCalismaSaati.CustomizableEdges = customizableEdges5;
            txtMemurCalismaSaati.DefaultText = "";
            txtMemurCalismaSaati.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtMemurCalismaSaati.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtMemurCalismaSaati.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtMemurCalismaSaati.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtMemurCalismaSaati.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtMemurCalismaSaati.Font = new Font("Microsoft Sans Serif", 10.2F);
            txtMemurCalismaSaati.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtMemurCalismaSaati.Location = new Point(124, 231);
            txtMemurCalismaSaati.Margin = new Padding(4);
            txtMemurCalismaSaati.Name = "txtMemurCalismaSaati";
            txtMemurCalismaSaati.PlaceholderText = "";
            txtMemurCalismaSaati.SelectedText = "";
            txtMemurCalismaSaati.ShadowDecoration.CustomizableEdges = customizableEdges6;
            txtMemurCalismaSaati.Size = new Size(358, 36);
            txtMemurCalismaSaati.TabIndex = 14;
            // 
            // btnSil
            // 
            btnSil.BackColor = Color.FromArgb(220, 53, 69);
            btnSil.FlatAppearance.BorderColor = Color.FromArgb(200, 35, 51);
            btnSil.FlatAppearance.BorderSize = 2;
            btnSil.FlatStyle = FlatStyle.Flat;
            btnSil.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            btnSil.ForeColor = Color.White;
            btnSil.Location = new Point(1077, 219);
            btnSil.Name = "btnSil";
            btnSil.Size = new Size(129, 51);
            btnSil.TabIndex = 23;
            btnSil.Text = "Sil";
            btnSil.UseVisualStyleBackColor = false;
            btnSil.Click += btnSil_Click;
            // 
            // btnGuncelle
            // 
            btnGuncelle.BackColor = Color.FromArgb(42, 46, 55);
            btnGuncelle.FlatAppearance.BorderColor = Color.Black;
            btnGuncelle.FlatAppearance.BorderSize = 2;
            btnGuncelle.FlatStyle = FlatStyle.Flat;
            btnGuncelle.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            btnGuncelle.ForeColor = Color.White;
            btnGuncelle.Location = new Point(1077, 162);
            btnGuncelle.Name = "btnGuncelle";
            btnGuncelle.Size = new Size(129, 51);
            btnGuncelle.TabIndex = 23;
            btnGuncelle.Text = "Güncelle";
            btnGuncelle.UseVisualStyleBackColor = false;
            btnGuncelle.Click += btnGuncelle_Click;
            // 
            // dgvMemurlar
            // 
            dataGridViewCellStyle1.BackColor = Color.WhiteSmoke;
            dgvMemurlar.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(42, 46, 55);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 162);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(42, 46, 55);
            dataGridViewCellStyle2.SelectionForeColor = Color.FromArgb(42, 46, 55);
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvMemurlar.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvMemurlar.ColumnHeadersHeight = 40;
            dgvMemurlar.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 10F);
            dataGridViewCellStyle3.ForeColor = Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(155, 171, 222);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvMemurlar.DefaultCellStyle = dataGridViewCellStyle3;
            dgvMemurlar.GridColor = Color.FromArgb(225, 225, 225);
            dgvMemurlar.Location = new Point(76, 303);
            dgvMemurlar.MultiSelect = false;
            dgvMemurlar.Name = "dgvMemurlar";
            dgvMemurlar.RowHeadersVisible = false;
            dgvMemurlar.RowHeadersWidth = 51;
            dgvMemurlar.Size = new Size(1204, 199);
            dgvMemurlar.TabIndex = 22;
            dgvMemurlar.ThemeStyle.AlternatingRowsStyle.BackColor = Color.White;
            dgvMemurlar.ThemeStyle.AlternatingRowsStyle.Font = null;
            dgvMemurlar.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.Empty;
            dgvMemurlar.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty;
            dgvMemurlar.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty;
            dgvMemurlar.ThemeStyle.BackColor = Color.White;
            dgvMemurlar.ThemeStyle.GridColor = Color.FromArgb(225, 225, 225);
            dgvMemurlar.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(100, 88, 255);
            dgvMemurlar.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvMemurlar.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 12F);
            dgvMemurlar.ThemeStyle.HeaderStyle.ForeColor = Color.White;
            dgvMemurlar.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dgvMemurlar.ThemeStyle.HeaderStyle.Height = 40;
            dgvMemurlar.ThemeStyle.ReadOnly = false;
            dgvMemurlar.ThemeStyle.RowsStyle.BackColor = Color.White;
            dgvMemurlar.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvMemurlar.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 10F);
            dgvMemurlar.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(71, 69, 94);
            dgvMemurlar.ThemeStyle.RowsStyle.Height = 29;
            dgvMemurlar.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dgvMemurlar.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dgvMemurlar.CellClick += dgvMemurlar_CellClick;
            // 
            // guna2TextBox1
            // 
            guna2TextBox1.CustomizableEdges = customizableEdges7;
            guna2TextBox1.DefaultText = "Memur";
            guna2TextBox1.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            guna2TextBox1.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            guna2TextBox1.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            guna2TextBox1.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            guna2TextBox1.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            guna2TextBox1.Font = new Font("Microsoft Sans Serif", 10.2F);
            guna2TextBox1.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            guna2TextBox1.Location = new Point(579, 136);
            guna2TextBox1.Margin = new Padding(4);
            guna2TextBox1.Name = "guna2TextBox1";
            guna2TextBox1.PlaceholderText = "";
            guna2TextBox1.ReadOnly = true;
            guna2TextBox1.SelectedText = "";
            guna2TextBox1.ShadowDecoration.CustomizableEdges = customizableEdges8;
            guna2TextBox1.Size = new Size(358, 36);
            guna2TextBox1.TabIndex = 14;
            // 
            // guna2HtmlLabel1
            // 
            guna2HtmlLabel1.BackColor = Color.Transparent;
            guna2HtmlLabel1.Font = new Font("Segoe UI", 10.2F);
            guna2HtmlLabel1.ForeColor = Color.Black;
            guna2HtmlLabel1.Location = new Point(579, 104);
            guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            guna2HtmlLabel1.Size = new Size(48, 25);
            guna2HtmlLabel1.TabIndex = 17;
            guna2HtmlLabel1.Text = "Kadro";
            // 
            // btnMemurEkle
            // 
            btnMemurEkle.BackColor = Color.FromArgb(42, 46, 55);
            btnMemurEkle.FlatAppearance.BorderColor = Color.Black;
            btnMemurEkle.FlatAppearance.BorderSize = 2;
            btnMemurEkle.FlatStyle = FlatStyle.Flat;
            btnMemurEkle.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 162);
            btnMemurEkle.ForeColor = Color.White;
            btnMemurEkle.Location = new Point(1077, 104);
            btnMemurEkle.Name = "btnMemurEkle";
            btnMemurEkle.Size = new Size(129, 51);
            btnMemurEkle.TabIndex = 24;
            btnMemurEkle.Text = "Ekle";
            btnMemurEkle.UseVisualStyleBackColor = false;
            btnMemurEkle.Click += btnMemurEkle_Click;
            // 
            // guna2HtmlLabel2
            // 
            guna2HtmlLabel2.BackColor = Color.Transparent;
            guna2HtmlLabel2.Font = new Font("Arial Black", 18F, FontStyle.Bold);
            guna2HtmlLabel2.Location = new Point(549, 28);
            guna2HtmlLabel2.Name = "guna2HtmlLabel2";
            guna2HtmlLabel2.Size = new Size(267, 44);
            guna2HtmlLabel2.TabIndex = 25;
            guna2HtmlLabel2.Text = "Memur İşlemleri";
            guna2HtmlLabel2.TextAlignment = ContentAlignment.MiddleCenter;
            // 
            // MemurIslemleri
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1368, 532);
            Controls.Add(guna2HtmlLabel2);
            Controls.Add(btnMemurEkle);
            Controls.Add(dgvMemurlar);
            Controls.Add(btnGuncelle);
            Controls.Add(btnSil);
            Controls.Add(cmbMemurDerece);
            Controls.Add(guna2HtmlLabel5);
            Controls.Add(guna2HtmlLabel3);
            Controls.Add(guna2HtmlLabel1);
            Controls.Add(guna2HtmlLabel4);
            Controls.Add(guna2TextBox1);
            Controls.Add(txtMemurCalismaSaati);
            Controls.Add(txtMemurAdSoyad);
            FormBorderStyle = FormBorderStyle.None;
            Name = "MemurIslemleri";
            Text = "MemurIslemleri";
            Load += MemurIslemleri_Load;
            ((System.ComponentModel.ISupportInitialize)dgvMemurlar).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Guna.UI2.WinForms.Guna2ComboBox cmbMemurDerece;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel5;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel3;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel4;
        private Guna.UI2.WinForms.Guna2TextBox txtMemurAdSoyad;
        private Guna.UI2.WinForms.Guna2TextBox txtMemurCalismaSaati;
        private Button btnSil;
        private Button btnGuncelle;
        private Guna.UI2.WinForms.Guna2DataGridView dgvMemurlar;
        private Guna.UI2.WinForms.Guna2TextBox guna2TextBox1;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Button btnMemurEkle;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel2;
    }
}