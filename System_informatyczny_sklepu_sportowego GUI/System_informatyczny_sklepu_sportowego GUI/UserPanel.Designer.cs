namespace System_informatyczny_sklepu_sportowego_GUI
{
    partial class UserPanel
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
            button2 = new MaterialSkin.Controls.MaterialButton();
            button1 = new MaterialSkin.Controls.MaterialButton();
            button3 = new MaterialSkin.Controls.MaterialButton();
            label2 = new MaterialSkin.Controls.MaterialLabel();
            SuspendLayout();
            // 
            // button2
            // 
            button2.AutoSize = false;
            button2.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            button2.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            button2.Depth = 0;
            button2.HighEmphasis = true;
            button2.Icon = null;
            button2.Location = new Point(295, 282);
            button2.Margin = new Padding(4, 6, 4, 6);
            button2.MouseState = MaterialSkin.MouseState.HOVER;
            button2.Name = "button2";
            button2.NoAccentTextColor = Color.Empty;
            button2.Size = new Size(175, 45);
            button2.TabIndex = 5;
            button2.Text = "Panel";
            button2.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            button2.UseAccentColor = false;
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.AutoSize = false;
            button1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            button1.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            button1.Depth = 0;
            button1.HighEmphasis = true;
            button1.Icon = null;
            button1.Location = new Point(80, 282);
            button1.Margin = new Padding(4, 6, 4, 6);
            button1.MouseState = MaterialSkin.MouseState.HOVER;
            button1.Name = "button1";
            button1.NoAccentTextColor = Color.Empty;
            button1.Size = new Size(175, 45);
            button1.TabIndex = 6;
            button1.Text = "Baza Danych";
            button1.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            button1.UseAccentColor = false;
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button3
            // 
            button3.AutoSize = false;
            button3.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            button3.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            button3.Depth = 0;
            button3.HighEmphasis = true;
            button3.Icon = null;
            button3.Location = new Point(365, 74);
            button3.Margin = new Padding(4, 6, 4, 6);
            button3.MouseState = MaterialSkin.MouseState.HOVER;
            button3.Name = "button3";
            button3.NoAccentTextColor = Color.Empty;
            button3.Size = new Size(175, 40);
            button3.TabIndex = 7;
            button3.Text = "Wyloguj";
            button3.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            button3.UseAccentColor = false;
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Depth = 0;
            label2.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            label2.Location = new Point(216, 222);
            label2.MouseState = MaterialSkin.MouseState.HOVER;
            label2.Name = "label2";
            label2.Size = new Size(38, 19);
            label2.TabIndex = 8;
            label2.Text = "None";
            // 
            // UserPanel
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClientSize = new Size(550, 525);
            Controls.Add(label2);
            Controls.Add(button3);
            Controls.Add(button1);
            Controls.Add(button2);
            MaximizeBox = false;
            Name = "UserPanel";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Panel Użytkownika";
            FormClosing += UserPanel_FormClosing;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MaterialSkin.Controls.MaterialButton button2;
        private MaterialSkin.Controls.MaterialButton button1;
        private MaterialSkin.Controls.MaterialButton button3;
        private MaterialSkin.Controls.MaterialLabel label2;
    }
}