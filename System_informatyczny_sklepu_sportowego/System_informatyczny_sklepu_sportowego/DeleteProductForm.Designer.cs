namespace System_informatyczny_sklepu_sportowego_UX
{
    partial class DeleteProductForm
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
            materialButton1 = new MaterialSkin.Controls.MaterialButton();
            listView1 = new ListView();
            Id = new ColumnHeader();
            Nazwa = new ColumnHeader();
            Opis = new ColumnHeader();
            Cena = new ColumnHeader();
            Sprzedane = new ColumnHeader();
            Ilość = new ColumnHeader();
            SuspendLayout();
            // 
            // materialButton1
            // 
            materialButton1.AutoSize = false;
            materialButton1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            materialButton1.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            materialButton1.Depth = 0;
            materialButton1.HighEmphasis = true;
            materialButton1.Icon = null;
            materialButton1.Location = new Point(10, 475);
            materialButton1.Margin = new Padding(4, 6, 4, 6);
            materialButton1.MouseState = MaterialSkin.MouseState.HOVER;
            materialButton1.Name = "materialButton1";
            materialButton1.NoAccentTextColor = Color.Empty;
            materialButton1.Size = new Size(530, 40);
            materialButton1.TabIndex = 0;
            materialButton1.Text = "Usuń";
            materialButton1.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            materialButton1.UseAccentColor = false;
            materialButton1.UseVisualStyleBackColor = true;
            materialButton1.Click += BtnDelete_Click;
            // 
            // listView1
            // 
            listView1.CheckBoxes = true;
            listView1.Columns.AddRange(new ColumnHeader[] { Id, Nazwa, Opis, Cena, Sprzedane, Ilość });
            listView1.Location = new Point(10, 74);
            listView1.Name = "listView1";
            listView1.Size = new Size(530, 392);
            listView1.TabIndex = 1;
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
            Nazwa.Width = 130;
            // 
            // Opis
            // 
            Opis.Tag = "Opis";
            Opis.Text = "Opis";
            Opis.TextAlign = HorizontalAlignment.Center;
            Opis.Width = 130;
            // 
            // Cena
            // 
            Cena.Tag = "Cena";
            Cena.Text = "Cena";
            Cena.TextAlign = HorizontalAlignment.Center;
            // 
            // Sprzedane
            // 
            Sprzedane.Tag = "Sprzedane";
            Sprzedane.Text = "Sprzedane";
            Sprzedane.TextAlign = HorizontalAlignment.Center;
            Sprzedane.Width = 90;
            // 
            // Ilość
            // 
            Ilość.Tag = "Ilość";
            Ilość.Text = "Ilość";
            Ilość.TextAlign = HorizontalAlignment.Center;
            // 
            // DeleteProductForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(550, 525);
            Controls.Add(listView1);
            Controls.Add(materialButton1);
            MaximizeBox = false;
            Name = "DeleteProductForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Usuń produkt";
            ResumeLayout(false);
        }

        #endregion

        private MaterialSkin.Controls.MaterialButton materialButton1;
        private ListView listView1;
        private ColumnHeader Id;
        private ColumnHeader Nazwa;
        private ColumnHeader Opis;
        private ColumnHeader Cena;
        private ColumnHeader Sprzedane;
        private ColumnHeader Ilość;
    }
}