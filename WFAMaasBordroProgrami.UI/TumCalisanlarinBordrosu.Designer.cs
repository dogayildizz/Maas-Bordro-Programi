﻿namespace WFAMaasBordroProgrami.UI
{
    partial class TumCalisanlarinBordrosu
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
            lvTumCalisanlarinBordrosu = new ListView();
            btnPdfOlustur = new Guna.UI2.WinForms.Guna2Button();
            btnExcelOlustur = new Guna.UI2.WinForms.Guna2Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // lvTumCalisanlarinBordrosu
            // 
            lvTumCalisanlarinBordrosu.Location = new Point(120, 39);
            lvTumCalisanlarinBordrosu.Name = "lvTumCalisanlarinBordrosu";
            lvTumCalisanlarinBordrosu.Size = new Size(1126, 342);
            lvTumCalisanlarinBordrosu.TabIndex = 10;
            lvTumCalisanlarinBordrosu.UseCompatibleStateImageBehavior = false;
            // 
            // btnPdfOlustur
            // 
            btnPdfOlustur.BackColor = Color.FromArgb(66, 84, 94);
            btnPdfOlustur.CustomizableEdges = customizableEdges1;
            btnPdfOlustur.DisabledState.BorderColor = Color.DarkGray;
            btnPdfOlustur.DisabledState.CustomBorderColor = Color.DarkGray;
            btnPdfOlustur.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnPdfOlustur.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnPdfOlustur.FillColor = Color.FromArgb(66, 84, 94);
            btnPdfOlustur.Font = new Font("Segoe UI", 9F);
            btnPdfOlustur.ForeColor = Color.White;
            btnPdfOlustur.Location = new Point(771, 426);
            btnPdfOlustur.Name = "btnPdfOlustur";
            btnPdfOlustur.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnPdfOlustur.Size = new Size(225, 56);
            btnPdfOlustur.TabIndex = 7;
            btnPdfOlustur.Text = "PDF Oluştur";
            btnPdfOlustur.Click += btnPdfOlustur_Click;
            // 
            // btnExcelOlustur
            // 
            btnExcelOlustur.BackColor = Color.FromArgb(66, 84, 94);
            btnExcelOlustur.CustomizableEdges = customizableEdges3;
            btnExcelOlustur.DisabledState.BorderColor = Color.DarkGray;
            btnExcelOlustur.DisabledState.CustomBorderColor = Color.DarkGray;
            btnExcelOlustur.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnExcelOlustur.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnExcelOlustur.FillColor = Color.FromArgb(66, 84, 94);
            btnExcelOlustur.Font = new Font("Segoe UI", 9F);
            btnExcelOlustur.ForeColor = Color.White;
            btnExcelOlustur.Location = new Point(1021, 426);
            btnExcelOlustur.Name = "btnExcelOlustur";
            btnExcelOlustur.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btnExcelOlustur.Size = new Size(225, 56);
            btnExcelOlustur.TabIndex = 9;
            btnExcelOlustur.Text = "Excel Oluştur";
            btnExcelOlustur.Click += btnExcelOlustur_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(120, 384);
            label1.Name = "label1";
            label1.Size = new Size(407, 20);
            label1.TabIndex = 11;
            label1.Text = "150 saatten az çalışan personeller mavi renk ile belirtilmiştir!";
            // 
            // TumCalisanlarinBordrosu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1368, 532);
            Controls.Add(label1);
            Controls.Add(lvTumCalisanlarinBordrosu);
            Controls.Add(btnPdfOlustur);
            Controls.Add(btnExcelOlustur);
            FormBorderStyle = FormBorderStyle.None;
            Name = "TumCalisanlarinBordrosu";
            Text = "TumCalisanlarinBordrosu";
            Load += TumCalisanlarinBordrosu_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListView lvTumCalisanlarinBordrosu;
        private Guna.UI2.WinForms.Guna2Button btnPdfOlustur;
        private Guna.UI2.WinForms.Guna2Button btnExcelOlustur;
        private Label label1;
    }
}