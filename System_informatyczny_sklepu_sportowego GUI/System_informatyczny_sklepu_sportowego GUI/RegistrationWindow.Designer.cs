namespace System_informatyczny_sklepu_sportowego_GUI
{
    partial class RegistrationWindow
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
            textBoxNazwa = new MaterialSkin.Controls.MaterialTextBox();
            button2 = new MaterialSkin.Controls.MaterialButton();
            button1 = new MaterialSkin.Controls.MaterialButton();
            textBoxHaslo = new MaterialSkin.Controls.MaterialTextBox();
            textBoxHaslo2 = new MaterialSkin.Controls.MaterialTextBox();
            label1 = new MaterialSkin.Controls.MaterialLabel();
            label2 = new MaterialSkin.Controls.MaterialLabel();
            label3 = new MaterialSkin.Controls.MaterialLabel();
            SuspendLayout();
            // 
            // textBoxNazwa
            // 
            textBoxNazwa.AnimateReadOnly = false;
            textBoxNazwa.BorderStyle = BorderStyle.None;
            textBoxNazwa.Depth = 0;
            textBoxNazwa.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            textBoxNazwa.LeadingIcon = null;
            textBoxNazwa.Location = new Point(275, 140);
            textBoxNazwa.MaxLength = 50;
            textBoxNazwa.MouseState = MaterialSkin.MouseState.OUT;
            textBoxNazwa.Multiline = false;
            textBoxNazwa.Name = "textBoxNazwa";
            textBoxNazwa.Size = new Size(175, 50);
            textBoxNazwa.TabIndex = 8;
            textBoxNazwa.Text = "";
            textBoxNazwa.TrailingIcon = null;
            // 
            // button2
            // 
            button2.AutoSize = false;
            button2.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            button2.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            button2.Depth = 0;
            button2.HighEmphasis = true;
            button2.Icon = null;
            button2.Location = new Point(10, 475);
            button2.Margin = new Padding(4, 6, 4, 6);
            button2.MouseState = MaterialSkin.MouseState.HOVER;
            button2.Name = "button2";
            button2.NoAccentTextColor = Color.Empty;
            button2.Size = new Size(530, 40);
            button2.TabIndex = 9;
            button2.Text = "Anuluj";
            button2.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            button2.UseAccentColor = false;
            button2.UseVisualStyleBackColor = true;
            button2.Click += this.button2Anuluj_Click;
            // 
            // button1
            // 
            button1.AutoSize = false;
            button1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            button1.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            button1.Depth = 0;
            button1.HighEmphasis = true;
            button1.Icon = null;
            button1.Location = new Point(10, 425);
            button1.Margin = new Padding(4, 6, 4, 6);
            button1.MouseState = MaterialSkin.MouseState.HOVER;
            button1.Name = "button1";
            button1.NoAccentTextColor = Color.Empty;
            button1.Size = new Size(530, 40);
            button1.TabIndex = 10;
            button1.Text = "Zarejestruj się";
            button1.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            button1.UseAccentColor = false;
            button1.UseVisualStyleBackColor = true;
            button1.Click += this.button1Zarejestruj_Click;
            // 
            // textBoxHaslo
            // 
            textBoxHaslo.AnimateReadOnly = false;
            textBoxHaslo.BorderStyle = BorderStyle.None;
            textBoxHaslo.Depth = 0;
            textBoxHaslo.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            textBoxHaslo.LeadingIcon = null;
            textBoxHaslo.Location = new Point(275, 220);
            textBoxHaslo.MaxLength = 50;
            textBoxHaslo.MouseState = MaterialSkin.MouseState.OUT;
            textBoxHaslo.Multiline = false;
            textBoxHaslo.Name = "textBoxHaslo";
            textBoxHaslo.Size = new Size(175, 50);
            textBoxHaslo.TabIndex = 11;
            textBoxHaslo.Text = "";
            textBoxHaslo.TrailingIcon = null;
            // 
            // textBoxHaslo2
            // 
            textBoxHaslo2.AnimateReadOnly = false;
            textBoxHaslo2.BorderStyle = BorderStyle.None;
            textBoxHaslo2.Depth = 0;
            textBoxHaslo2.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            textBoxHaslo2.LeadingIcon = null;
            textBoxHaslo2.Location = new Point(275, 300);
            textBoxHaslo2.MaxLength = 50;
            textBoxHaslo2.MouseState = MaterialSkin.MouseState.OUT;
            textBoxHaslo2.Multiline = false;
            textBoxHaslo2.Name = "textBoxHaslo2";
            textBoxHaslo2.Size = new Size(175, 50);
            textBoxHaslo2.TabIndex = 12;
            textBoxHaslo2.Text = "";
            textBoxHaslo2.TrailingIcon = null;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Depth = 0;
            label1.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            label1.Location = new Point(116, 150);
            label1.MouseState = MaterialSkin.MouseState.HOVER;
            label1.Name = "label1";
            label1.Size = new Size(148, 19);
            label1.TabIndex = 13;
            label1.Text = "Nazwa Użytkownika:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Depth = 0;
            label2.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            label2.Location = new Point(218, 230);
            label2.MouseState = MaterialSkin.MouseState.HOVER;
            label2.Name = "label2";
            label2.Size = new Size(46, 19);
            label2.TabIndex = 14;
            label2.Text = "Hasło:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Depth = 0;
            label3.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            label3.Location = new Point(156, 310);
            label3.MouseState = MaterialSkin.MouseState.HOVER;
            label3.Name = "label3";
            label3.Size = new Size(108, 19);
            label3.TabIndex = 15;
            label3.Text = "Powtórz Hasło:";
            // 
            // RegistrationWindow
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClientSize = new Size(550, 525);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBoxHaslo2);
            Controls.Add(textBoxHaslo);
            Controls.Add(button1);
            Controls.Add(button2);
            Controls.Add(textBoxNazwa);
            MaximizeBox = false;
            Name = "RegistrationWindow";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Okno rejestracji";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MaterialSkin.Controls.MaterialTextBox textBoxNazwa;
        private MaterialSkin.Controls.MaterialButton button2;
        private MaterialSkin.Controls.MaterialButton button1;
        private MaterialSkin.Controls.MaterialTextBox textBoxHaslo;
        private MaterialSkin.Controls.MaterialTextBox textBoxHaslo2;
        private MaterialSkin.Controls.MaterialLabel label1;
        private MaterialSkin.Controls.MaterialLabel label2;
        private MaterialSkin.Controls.MaterialLabel label3;
    }
}