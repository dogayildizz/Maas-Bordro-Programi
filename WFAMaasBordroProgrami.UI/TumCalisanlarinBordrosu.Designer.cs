namespace WFAMaasBordroProgrami.UI
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            listView1 = new ListView();
            btnPdfOlustur = new Guna.UI2.WinForms.Guna2Button();
            btnMailGonder = new Guna.UI2.WinForms.Guna2Button();
            btnExcelOlustur = new Guna.UI2.WinForms.Guna2Button();
            SuspendLayout();
            // 
            // listView1
            // 
            listView1.Location = new Point(120, 39);
            listView1.Name = "listView1";
            listView1.Size = new Size(1126, 369);
            listView1.TabIndex = 10;
            listView1.UseCompatibleStateImageBehavior = false;
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
            btnPdfOlustur.Location = new Point(242, 426);
            btnPdfOlustur.Name = "btnPdfOlustur";
            btnPdfOlustur.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnPdfOlustur.Size = new Size(225, 56);
            btnPdfOlustur.TabIndex = 7;
            btnPdfOlustur.Text = "PDF Oluştur";
            // 
            // btnMailGonder
            // 
            btnMailGonder.BackColor = Color.FromArgb(66, 84, 94);
            btnMailGonder.CustomizableEdges = customizableEdges3;
            btnMailGonder.DisabledState.BorderColor = Color.DarkGray;
            btnMailGonder.DisabledState.CustomBorderColor = Color.DarkGray;
            btnMailGonder.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnMailGonder.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnMailGonder.FillColor = Color.FromArgb(66, 84, 94);
            btnMailGonder.Font = new Font("Segoe UI", 9F);
            btnMailGonder.ForeColor = Color.White;
            btnMailGonder.Location = new Point(861, 426);
            btnMailGonder.Name = "btnMailGonder";
            btnMailGonder.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btnMailGonder.Size = new Size(225, 56);
            btnMailGonder.TabIndex = 8;
            btnMailGonder.Text = "Mail Gönder";
            // 
            // btnExcelOlustur
            // 
            btnExcelOlustur.BackColor = Color.FromArgb(66, 84, 94);
            btnExcelOlustur.CustomizableEdges = customizableEdges5;
            btnExcelOlustur.DisabledState.BorderColor = Color.DarkGray;
            btnExcelOlustur.DisabledState.CustomBorderColor = Color.DarkGray;
            btnExcelOlustur.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnExcelOlustur.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnExcelOlustur.FillColor = Color.FromArgb(66, 84, 94);
            btnExcelOlustur.Font = new Font("Segoe UI", 9F);
            btnExcelOlustur.ForeColor = Color.White;
            btnExcelOlustur.Location = new Point(541, 426);
            btnExcelOlustur.Name = "btnExcelOlustur";
            btnExcelOlustur.ShadowDecoration.CustomizableEdges = customizableEdges6;
            btnExcelOlustur.Size = new Size(225, 56);
            btnExcelOlustur.TabIndex = 9;
            btnExcelOlustur.Text = "Excel Oluştur";
            // 
            // TumCalisanlarinBordrosu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1368, 532);
            Controls.Add(listView1);
            Controls.Add(btnPdfOlustur);
            Controls.Add(btnMailGonder);
            Controls.Add(btnExcelOlustur);
            FormBorderStyle = FormBorderStyle.None;
            Name = "TumCalisanlarinBordrosu";
            Text = "TumCalisanlarinBordrosu";
            ResumeLayout(false);
        }

        #endregion

        private ListView listView1;
        private Guna.UI2.WinForms.Guna2Button btnPdfOlustur;
        private Guna.UI2.WinForms.Guna2Button btnMailGonder;
        private Guna.UI2.WinForms.Guna2Button btnExcelOlustur;
    }
}