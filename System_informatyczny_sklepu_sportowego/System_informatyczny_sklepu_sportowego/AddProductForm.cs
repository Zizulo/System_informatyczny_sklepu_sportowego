using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;


namespace System_informatyczny_sklepu_sportowego
{
    public partial class AddProductForm : MaterialForm
    {
        public bool IsProductAdded { get; private set; }

        public int ProductId { get; private set; }
        public string ProductName { get; private set; }
        public string ProductDescription { get; private set; }
        public string ProductPrice { get; private set; }
        public int ProductQuantity { get; private set; }
        public int ProductCode { get; private set; }

        public event EventHandler ProductAdded;
        public AddProductForm()
        {
            InitializeComponent();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            ProductName = textBox1.Text;
            ProductDescription = textBox2.Text;
            ProductPrice = textBox3.Text;
            ProductQuantity = Convert.ToInt32(textBox4.Text);
            ProductCode = Convert.ToInt32(textbox5.Text);

            if (string.IsNullOrWhiteSpace(ProductName) || string.IsNullOrWhiteSpace(ProductPrice))
            {
                MessageBox.Show("Wprowadź nazwę i prawidłową cenę produktu.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ProductAdded?.Invoke(this, EventArgs.Empty);

            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textbox5.Text = "";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            // Zamknij okno z rezultatem DialogResult.Cancel
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void InitializeComponent()
        {
            button1 = new MaterialButton();
            btnClose = new MaterialButton();
            label1 = new MaterialLabel();
            label2 = new MaterialLabel();
            label3 = new MaterialLabel();
            label4 = new MaterialLabel();
            textBox1 = new MaterialTextBox2();
            textBox2 = new MaterialTextBox2();
            textBox3 = new MaterialTextBox2();
            textBox4 = new MaterialTextBox2();
            textbox5 = new MaterialTextBox();
            materialLabel1 = new MaterialLabel();
            SuspendLayout();
            // 
            // button1
            // 
            button1.AutoSize = false;
            button1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            button1.Density = MaterialButton.MaterialButtonDensity.Default;
            button1.Depth = 0;
            button1.HighEmphasis = true;
            button1.Icon = null;
            button1.Location = new Point(10, 425);
            button1.Margin = new Padding(4, 6, 4, 6);
            button1.MouseState = MouseState.HOVER;
            button1.Name = "button1";
            button1.NoAccentTextColor = Color.Empty;
            button1.Size = new Size(530, 40);
            button1.TabIndex = 9;
            button1.Text = "Dodaj produkt";
            button1.Type = MaterialButton.MaterialButtonType.Contained;
            button1.UseAccentColor = false;
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click_1;
            // 
            // btnClose
            // 
            btnClose.AutoSize = false;
            btnClose.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnClose.Density = MaterialButton.MaterialButtonDensity.Default;
            btnClose.Depth = 0;
            btnClose.HighEmphasis = true;
            btnClose.Icon = null;
            btnClose.Location = new Point(10, 475);
            btnClose.Margin = new Padding(4, 6, 4, 6);
            btnClose.MouseState = MouseState.HOVER;
            btnClose.Name = "btnClose";
            btnClose.NoAccentTextColor = Color.Empty;
            btnClose.Size = new Size(530, 40);
            btnClose.TabIndex = 10;
            btnClose.Text = "Zamknij";
            btnClose.Type = MaterialButton.MaterialButtonType.Contained;
            btnClose.UseAccentColor = false;
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Depth = 0;
            label1.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            label1.Location = new Point(118, 114);
            label1.MouseState = MouseState.HOVER;
            label1.Name = "label1";
            label1.Size = new Size(50, 19);
            label1.TabIndex = 12;
            label1.Text = "Nazwa";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Depth = 0;
            label2.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            label2.Location = new Point(135, 180);
            label2.MouseState = MouseState.HOVER;
            label2.Name = "label2";
            label2.Size = new Size(33, 19);
            label2.TabIndex = 13;
            label2.Text = "Opis";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Depth = 0;
            label3.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            label3.Location = new Point(131, 246);
            label3.MouseState = MouseState.HOVER;
            label3.Name = "label3";
            label3.Size = new Size(37, 19);
            label3.TabIndex = 14;
            label3.Text = "Cena";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Depth = 0;
            label4.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            label4.Location = new Point(134, 312);
            label4.MouseState = MouseState.HOVER;
            label4.Name = "label4";
            label4.Size = new Size(34, 19);
            label4.TabIndex = 15;
            label4.Text = "Ilość";
            // 
            // textBox1
            // 
            textBox1.AnimateReadOnly = false;
            textBox1.BackgroundImageLayout = ImageLayout.None;
            textBox1.CharacterCasing = CharacterCasing.Normal;
            textBox1.Depth = 0;
            textBox1.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            textBox1.HideSelection = true;
            textBox1.LeadingIcon = null;
            textBox1.Location = new Point(184, 105);
            textBox1.MaxLength = 32767;
            textBox1.MouseState = MouseState.OUT;
            textBox1.Name = "textBox1";
            textBox1.PasswordChar = '\0';
            textBox1.PrefixSuffixText = null;
            textBox1.ReadOnly = false;
            textBox1.RightToLeft = RightToLeft.No;
            textBox1.SelectedText = "";
            textBox1.SelectionLength = 0;
            textBox1.SelectionStart = 0;
            textBox1.ShortcutsEnabled = true;
            textBox1.Size = new Size(250, 36);
            textBox1.TabIndex = 16;
            textBox1.TabStop = false;
            textBox1.TextAlign = HorizontalAlignment.Left;
            textBox1.TrailingIcon = null;
            textBox1.UseSystemPasswordChar = false;
            textBox1.UseTallSize = false;
            // 
            // textBox2
            // 
            textBox2.AnimateReadOnly = false;
            textBox2.BackgroundImageLayout = ImageLayout.None;
            textBox2.CharacterCasing = CharacterCasing.Normal;
            textBox2.Depth = 0;
            textBox2.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            textBox2.HideSelection = true;
            textBox2.LeadingIcon = null;
            textBox2.Location = new Point(184, 171);
            textBox2.MaxLength = 32767;
            textBox2.MouseState = MouseState.OUT;
            textBox2.Name = "textBox2";
            textBox2.PasswordChar = '\0';
            textBox2.PrefixSuffixText = null;
            textBox2.ReadOnly = false;
            textBox2.RightToLeft = RightToLeft.No;
            textBox2.SelectedText = "";
            textBox2.SelectionLength = 0;
            textBox2.SelectionStart = 0;
            textBox2.ShortcutsEnabled = true;
            textBox2.Size = new Size(250, 36);
            textBox2.TabIndex = 17;
            textBox2.TabStop = false;
            textBox2.TextAlign = HorizontalAlignment.Left;
            textBox2.TrailingIcon = null;
            textBox2.UseSystemPasswordChar = false;
            textBox2.UseTallSize = false;
            // 
            // textBox3
            // 
            textBox3.AnimateReadOnly = false;
            textBox3.BackgroundImageLayout = ImageLayout.None;
            textBox3.CharacterCasing = CharacterCasing.Normal;
            textBox3.Depth = 0;
            textBox3.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            textBox3.HideSelection = true;
            textBox3.LeadingIcon = null;
            textBox3.Location = new Point(184, 237);
            textBox3.MaxLength = 32767;
            textBox3.MouseState = MouseState.OUT;
            textBox3.Name = "textBox3";
            textBox3.PasswordChar = '\0';
            textBox3.PrefixSuffixText = null;
            textBox3.ReadOnly = false;
            textBox3.RightToLeft = RightToLeft.No;
            textBox3.SelectedText = "";
            textBox3.SelectionLength = 0;
            textBox3.SelectionStart = 0;
            textBox3.ShortcutsEnabled = true;
            textBox3.Size = new Size(250, 36);
            textBox3.TabIndex = 18;
            textBox3.TabStop = false;
            textBox3.TextAlign = HorizontalAlignment.Left;
            textBox3.TrailingIcon = null;
            textBox3.UseSystemPasswordChar = false;
            textBox3.UseTallSize = false;
            // 
            // textBox4
            // 
            textBox4.AnimateReadOnly = false;
            textBox4.BackgroundImageLayout = ImageLayout.None;
            textBox4.CharacterCasing = CharacterCasing.Normal;
            textBox4.Depth = 0;
            textBox4.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            textBox4.HideSelection = true;
            textBox4.LeadingIcon = null;
            textBox4.Location = new Point(184, 303);
            textBox4.MaxLength = 32767;
            textBox4.MouseState = MouseState.OUT;
            textBox4.Name = "textBox4";
            textBox4.PasswordChar = '\0';
            textBox4.PrefixSuffixText = null;
            textBox4.ReadOnly = false;
            textBox4.RightToLeft = RightToLeft.No;
            textBox4.SelectedText = "";
            textBox4.SelectionLength = 0;
            textBox4.SelectionStart = 0;
            textBox4.ShortcutsEnabled = true;
            textBox4.Size = new Size(250, 36);
            textBox4.TabIndex = 19;
            textBox4.TabStop = false;
            textBox4.TextAlign = HorizontalAlignment.Left;
            textBox4.TrailingIcon = null;
            textBox4.UseSystemPasswordChar = false;
            textBox4.UseTallSize = false;
            // 
            // textbox5
            // 
            textbox5.AnimateReadOnly = false;
            textbox5.BorderStyle = BorderStyle.None;
            textbox5.Depth = 0;
            textbox5.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            textbox5.LeadingIcon = null;
            textbox5.Location = new Point(184, 369);
            textbox5.MaxLength = 50;
            textbox5.MouseState = MouseState.OUT;
            textbox5.Multiline = false;
            textbox5.Name = "textbox5";
            textbox5.Size = new Size(250, 36);
            textbox5.TabIndex = 20;
            textbox5.Text = "";
            textbox5.TrailingIcon = null;
            textbox5.UseTallSize = false;
            // 
            // materialLabel1
            // 
            materialLabel1.AutoSize = true;
            materialLabel1.Depth = 0;
            materialLabel1.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel1.Location = new Point(139, 378);
            materialLabel1.MouseState = MouseState.HOVER;
            materialLabel1.Name = "materialLabel1";
            materialLabel1.Size = new Size(29, 19);
            materialLabel1.TabIndex = 21;
            materialLabel1.Text = "Kod";
            // 
            // AddProductForm
            // 
            ClientSize = new Size(550, 525);
            Controls.Add(materialLabel1);
            Controls.Add(textbox5);
            Controls.Add(textBox4);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnClose);
            Controls.Add(button1);
            MaximizeBox = false;
            Name = "AddProductForm";
            Padding = new Padding(10, 64, 10, 10);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Dodaj produkt";
            ResumeLayout(false);
            PerformLayout();
        }

        private MaterialButton button1;
        private MaterialButton btnClose;
        private MaterialLabel label1;
        private MaterialLabel label2;
        private MaterialLabel label3;
        private MaterialLabel label4;
        private MaterialTextBox2 textBox1;
        private MaterialTextBox2 textBox2;
        private MaterialTextBox2 textBox3;
        private MaterialTextBox textbox5;
        private MaterialLabel materialLabel1;
        private MaterialTextBox2 textBox4;
    }
}