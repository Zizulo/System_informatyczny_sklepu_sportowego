namespace System_informatyczny_sklepu_sportowego_GUI
{
    partial class LoginWindow
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
            rejestracja = new MaterialSkin.Controls.MaterialButton();
            logowanie = new MaterialSkin.Controls.MaterialButton();
            textBoxNazwa = new MaterialSkin.Controls.MaterialTextBox();
            textBoxHaslo = new MaterialSkin.Controls.MaterialTextBox();
            materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            SuspendLayout();
            // 
            // rejestracja
            // 
            rejestracja.AutoSize = false;
            rejestracja.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            rejestracja.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            rejestracja.Depth = 0;
            rejestracja.HighEmphasis = true;
            rejestracja.Icon = null;
            rejestracja.Location = new Point(10, 475);
            rejestracja.Margin = new Padding(4, 6, 4, 6);
            rejestracja.MouseState = MaterialSkin.MouseState.HOVER;
            rejestracja.Name = "rejestracja";
            rejestracja.NoAccentTextColor = Color.Empty;
            rejestracja.Size = new Size(530, 40);
            rejestracja.TabIndex = 6;
            rejestracja.Text = "Zarejestruj się";
            rejestracja.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            rejestracja.UseAccentColor = false;
            rejestracja.UseVisualStyleBackColor = true;
            rejestracja.Click += rejestracja_Click;
            // 
            // logowanie
            // 
            logowanie.AutoSize = false;
            logowanie.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            logowanie.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            logowanie.Depth = 0;
            logowanie.HighEmphasis = true;
            logowanie.Icon = null;
            logowanie.Location = new Point(10, 425);
            logowanie.Margin = new Padding(4, 6, 4, 6);
            logowanie.MouseState = MaterialSkin.MouseState.HOVER;
            logowanie.Name = "logowanie";
            logowanie.NoAccentTextColor = Color.Empty;
            logowanie.Size = new Size(530, 40);
            logowanie.TabIndex = 7;
            logowanie.Text = "Zaloguj się";
            logowanie.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            logowanie.UseAccentColor = false;
            logowanie.UseVisualStyleBackColor = true;
            logowanie.Click += logowanie_Click;
            // 
            // textBoxNazwa
            // 
            textBoxNazwa.AnimateReadOnly = false;
            textBoxNazwa.BorderStyle = BorderStyle.None;
            textBoxNazwa.Depth = 0;
            textBoxNazwa.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            textBoxNazwa.LeadingIcon = null;
            textBoxNazwa.Location = new Point(233, 178);
            textBoxNazwa.MaxLength = 50;
            textBoxNazwa.MouseState = MaterialSkin.MouseState.OUT;
            textBoxNazwa.Multiline = false;
            textBoxNazwa.Name = "textBoxNazwa";
            textBoxNazwa.Size = new Size(250, 50);
            textBoxNazwa.TabIndex = 8;
            textBoxNazwa.Text = "";
            textBoxNazwa.TrailingIcon = null;
            // 
            // textBoxHaslo
            // 
            textBoxHaslo.AnimateReadOnly = false;
            textBoxHaslo.BorderStyle = BorderStyle.None;
            textBoxHaslo.Depth = 0;
            textBoxHaslo.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            textBoxHaslo.LeadingIcon = null;
            textBoxHaslo.Location = new Point(233, 241);
            textBoxHaslo.MaxLength = 50;
            textBoxHaslo.MouseState = MaterialSkin.MouseState.OUT;
            textBoxHaslo.Multiline = false;
            textBoxHaslo.Name = "textBoxHaslo";
            textBoxHaslo.Size = new Size(250, 50);
            textBoxHaslo.TabIndex = 9;
            textBoxHaslo.Text = "";
            textBoxHaslo.TrailingIcon = null;
            // 
            // materialLabel1
            // 
            materialLabel1.AutoSize = true;
            materialLabel1.Depth = 0;
            materialLabel1.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel1.Location = new Point(65, 192);
            materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel1.Name = "materialLabel1";
            materialLabel1.Size = new Size(148, 19);
            materialLabel1.TabIndex = 10;
            materialLabel1.Text = "Nazwa Użytkownika:";
            // 
            // materialLabel2
            // 
            materialLabel2.AutoSize = true;
            materialLabel2.Depth = 0;
            materialLabel2.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel2.Location = new Point(167, 254);
            materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel2.Name = "materialLabel2";
            materialLabel2.Size = new Size(46, 19);
            materialLabel2.TabIndex = 11;
            materialLabel2.Text = "Hasło:";
            // 
            // LoginWindow
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClientSize = new Size(550, 525);
            Controls.Add(materialLabel2);
            Controls.Add(materialLabel1);
            Controls.Add(textBoxHaslo);
            Controls.Add(textBoxNazwa);
            Controls.Add(logowanie);
            Controls.Add(rejestracja);
            MaximizeBox = false;
            Name = "LoginWindow";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Okno logowania";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private MaterialSkin.Controls.MaterialButton rejestracja;
        private MaterialSkin.Controls.MaterialButton logowanie;
        private MaterialSkin.Controls.MaterialTextBox textBoxNazwa;
        private MaterialSkin.Controls.MaterialTextBox textBoxHaslo;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
    }
}