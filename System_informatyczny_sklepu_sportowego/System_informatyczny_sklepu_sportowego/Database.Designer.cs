namespace System_informatyczny_sklepu_sportowego
{
    partial class Database
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            menuStrip1 = new MenuStrip();
            plikToolStripMenuItem = new ToolStripMenuItem();
            zapiszPlikToolStripMenuItem = new ToolStripMenuItem();
            drukujToolStripMenuItem = new ToolStripMenuItem();
            wyświetlToolStripMenuItem = new ToolStripMenuItem();
            produktToolStripMenuItem = new ToolStripMenuItem();
            dodajToolStripMenuItem = new ToolStripMenuItem();
            produktToolStripMenuItem1 = new ToolStripMenuItem();
            usuńToolStripMenuItem = new ToolStripMenuItem();
            produktToolStripMenuItem2 = new ToolStripMenuItem();
            edytujToolStripMenuItem = new ToolStripMenuItem();
            productBindingSource = new BindingSource(components);
            aktualizuj_baze_danych = new MaterialSkin.Controls.MaterialButton();
            label1 = new MaterialSkin.Controls.MaterialLabel();
            listView1 = new ListView();
            Id = new ColumnHeader();
            Nazwa = new ColumnHeader();
            Opis = new ColumnHeader();
            Cena = new ColumnHeader();
            Sprzedane = new ColumnHeader();
            Ilość = new ColumnHeader();
            Kod = new ColumnHeader();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)productBindingSource).BeginInit();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { plikToolStripMenuItem, produktToolStripMenuItem });
            menuStrip1.Location = new Point(3, 64);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1179, 28);
            menuStrip1.TabIndex = 21;
            menuStrip1.Text = "menuStrip1";
            // 
            // plikToolStripMenuItem
            // 
            plikToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { zapiszPlikToolStripMenuItem, drukujToolStripMenuItem, wyświetlToolStripMenuItem });
            plikToolStripMenuItem.Name = "plikToolStripMenuItem";
            plikToolStripMenuItem.Size = new Size(46, 24);
            plikToolStripMenuItem.Text = "Plik";
            // 
            // zapiszPlikToolStripMenuItem
            // 
            zapiszPlikToolStripMenuItem.Name = "zapiszPlikToolStripMenuItem";
            zapiszPlikToolStripMenuItem.Size = new Size(224, 26);
            zapiszPlikToolStripMenuItem.Text = "Zapisz plik";
            zapiszPlikToolStripMenuItem.Click += zapiszPlikToolStripMenuItem_Click;
            // 
            // drukujToolStripMenuItem
            // 
            drukujToolStripMenuItem.Name = "drukujToolStripMenuItem";
            drukujToolStripMenuItem.Size = new Size(224, 26);
            drukujToolStripMenuItem.Text = "Drukuj";
            drukujToolStripMenuItem.Click += drukujToolStripMenuItem_Click;
            // 
            // wyświetlToolStripMenuItem
            // 
            wyświetlToolStripMenuItem.Name = "wyświetlToolStripMenuItem";
            wyświetlToolStripMenuItem.Size = new Size(224, 26);
            wyświetlToolStripMenuItem.Text = "Wyświetl";
            wyświetlToolStripMenuItem.Click += wyświetlToolStripMenuItem_Click;
            // 
            // produktToolStripMenuItem
            // 
            produktToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { dodajToolStripMenuItem, usuńToolStripMenuItem, edytujToolStripMenuItem });
            produktToolStripMenuItem.Name = "produktToolStripMenuItem";
            produktToolStripMenuItem.Size = new Size(74, 24);
            produktToolStripMenuItem.Text = "Produkt";
            // 
            // dodajToolStripMenuItem
            // 
            dodajToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { produktToolStripMenuItem1 });
            dodajToolStripMenuItem.Name = "dodajToolStripMenuItem";
            dodajToolStripMenuItem.Size = new Size(224, 26);
            dodajToolStripMenuItem.Text = "Dodaj";
            // 
            // produktToolStripMenuItem1
            // 
            produktToolStripMenuItem1.Name = "produktToolStripMenuItem1";
            produktToolStripMenuItem1.Size = new Size(143, 26);
            produktToolStripMenuItem1.Text = "Produkt";
            produktToolStripMenuItem1.Click += produktToolStripMenuItem1_Click;
            // 
            // usuńToolStripMenuItem
            // 
            usuńToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { produktToolStripMenuItem2 });
            usuńToolStripMenuItem.Name = "usuńToolStripMenuItem";
            usuńToolStripMenuItem.Size = new Size(224, 26);
            usuńToolStripMenuItem.Text = "Usuń";
            // 
            // produktToolStripMenuItem2
            // 
            produktToolStripMenuItem2.Name = "produktToolStripMenuItem2";
            produktToolStripMenuItem2.Size = new Size(143, 26);
            produktToolStripMenuItem2.Text = "Produkt";
            produktToolStripMenuItem2.Click += produktToolStripMenuItem2_Click;
            // 
            // edytujToolStripMenuItem
            // 
            edytujToolStripMenuItem.Name = "edytujToolStripMenuItem";
            edytujToolStripMenuItem.Size = new Size(224, 26);
            edytujToolStripMenuItem.Text = "Edytuj";
            edytujToolStripMenuItem.Click += edytujToolStripMenuItem_Click;
            // 
            // productBindingSource
            // 
            productBindingSource.DataSource = typeof(Product);
            // 
            // aktualizuj_baze_danych
            // 
            aktualizuj_baze_danych.AutoSize = false;
            aktualizuj_baze_danych.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            aktualizuj_baze_danych.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            aktualizuj_baze_danych.Depth = 0;
            aktualizuj_baze_danych.HighEmphasis = true;
            aktualizuj_baze_danych.Icon = null;
            aktualizuj_baze_danych.Location = new Point(728, 98);
            aktualizuj_baze_danych.Margin = new Padding(4, 6, 4, 6);
            aktualizuj_baze_danych.MouseState = MaterialSkin.MouseState.HOVER;
            aktualizuj_baze_danych.Name = "aktualizuj_baze_danych";
            aktualizuj_baze_danych.NoAccentTextColor = Color.Empty;
            aktualizuj_baze_danych.Size = new Size(175, 40);
            aktualizuj_baze_danych.TabIndex = 25;
            aktualizuj_baze_danych.Text = "Aktualizuj";
            aktualizuj_baze_danych.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            aktualizuj_baze_danych.UseAccentColor = false;
            aktualizuj_baze_danych.UseVisualStyleBackColor = true;
            aktualizuj_baze_danych.Click += aktualizuj_baze_danych_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Depth = 0;
            label1.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            label1.Location = new Point(991, 109);
            label1.MouseState = MaterialSkin.MouseState.HOVER;
            label1.Name = "label1";
            label1.Size = new Size(38, 19);
            label1.TabIndex = 26;
            label1.Text = "None";
            // 
            // listView1
            // 
            listView1.Columns.AddRange(new ColumnHeader[] { Id, Nazwa, Opis, Cena, Sprzedane, Ilość, Kod });
            listView1.Location = new Point(15, 143);
            listView1.Name = "listView1";
            listView1.Size = new Size(1155, 606);
            listView1.TabIndex = 27;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.Details;
            // 
            // Id
            // 
            Id.Tag = "Id";
            Id.Text = "Id";
            // 
            // Nazwa
            // 
            Nazwa.Tag = "Nazwa";
            Nazwa.Text = "Nazwa";
            Nazwa.TextAlign = HorizontalAlignment.Center;
            Nazwa.Width = 277;
            // 
            // Opis
            // 
            Opis.Tag = "Opis";
            Opis.Text = "Opis";
            Opis.TextAlign = HorizontalAlignment.Center;
            Opis.Width = 278;
            // 
            // Cena
            // 
            Cena.Tag = "Cena";
            Cena.Text = "Cena";
            Cena.TextAlign = HorizontalAlignment.Center;
            Cena.Width = 150;
            // 
            // Sprzedane
            // 
            Sprzedane.Tag = "Sprzedane";
            Sprzedane.Text = "Sprzedane";
            Sprzedane.TextAlign = HorizontalAlignment.Center;
            Sprzedane.Width = 150;
            // 
            // Ilość
            // 
            Ilość.Tag = "Ilość";
            Ilość.Text = "Ilość";
            Ilość.TextAlign = HorizontalAlignment.Center;
            Ilość.Width = 150;
            // 
            // Kod
            // 
            Kod.Tag = "Kod";
            Kod.Text = "Kod";
            Kod.TextAlign = HorizontalAlignment.Center;
            Kod.Width = 90;
            // 
            // Database
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1185, 765);
            Controls.Add(listView1);
            Controls.Add(label1);
            Controls.Add(aktualizuj_baze_danych);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            MaximizeBox = false;
            Name = "Database";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Baza danych";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)productBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private MenuStrip menuStrip1;
        private ToolStripMenuItem plikToolStripMenuItem;
        private ToolStripMenuItem zapiszPlikToolStripMenuItem;
        private ToolStripMenuItem drukujToolStripMenuItem;
        private ToolStripMenuItem wyświetlToolStripMenuItem;
        private ToolStripMenuItem produktToolStripMenuItem;
        private ToolStripMenuItem dodajToolStripMenuItem;
        private ToolStripMenuItem produktToolStripMenuItem1;
        private ToolStripMenuItem usuńToolStripMenuItem;
        private ToolStripMenuItem produktToolStripMenuItem2;
        private BindingSource productBindingSource;
        private ToolStripMenuItem edytujToolStripMenuItem;
        private MaterialSkin.Controls.MaterialButton aktualizuj_baze_danych;
        private MaterialSkin.Controls.MaterialLabel label1;
        private ListView listView1;
        private ColumnHeader Id;
        private ColumnHeader Nazwa;
        private ColumnHeader Opis;
        private ColumnHeader Cena;
        private ColumnHeader Sprzedane;
        private ColumnHeader Ilość;
        private ColumnHeader Kod;
    }
}