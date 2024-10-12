using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaterialSkin;
using MaterialSkin.Controls;
using static System_informatyczny_sklepu_sportowego.Database;

namespace System_informatyczny_sklepu_sportowego
{
    public class EditProductForm : MaterialForm
    {
        private DataGridView dataGridView1;
        private MaterialButton saveButton;
        private MaterialButton cancelButton;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private DataGridViewTextBoxColumn sprzedaneColumn;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private List<Product> productList; // Lista przechowująca dane produktów

        public int ProductId { get; private set; }
        public string ProductName { get; private set; }
        public string ProductDescription { get; private set; }
        public string ProductPrice { get; private set; }
        public int ProductQuantity { get; private set; }
        public int ProductCode { get; private set; }
        public ListViewItem SelectedProductItem { get; private set; }

        // Nowa właściwość do pobierania zedytowanych produktów
        public List<Product> EditedProducts { get; private set; }

        public event EventHandler ProductEdited;

        public EditProductForm(ListView.ListViewItemCollection items)
        {
            InitializeComponent();
            productList = new List<Product>();

            foreach (ListViewItem item in items)
            {
                int id = Convert.ToInt16(item.SubItems[0].Text);
                string nazwa = item.SubItems[1].Text;
                string opis = item.SubItems[2].Text;
                string cena = item.SubItems[3].Text;
                int sprzedane = Convert.ToInt32(item.SubItems[4].Text);
                int ilosc = Convert.ToInt32(item.SubItems[5].Text);
                int kod = Convert.ToInt32(item.SubItems[6].Text);

                productList.Add(new Product(id, nazwa, opis, cena, sprzedane, ilosc, kod));
            }

            dataGridView1.Rows.Clear();
            foreach (Product product in productList)
            {
                dataGridView1.Rows.Add(product.Id, product.Nazwa, product.Opis, product.Cena, product.Sprzedane, product.Ilość, product.Kod);
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            ListView listView = ((Database)Application.OpenForms["Database"]).GetListView();

            listView.Items.Clear();

            EditedProducts = new List<Product>();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (!row.IsNewRow)
                {
                    int id = Convert.ToInt16(row.Cells[0].Value);
                    string nazwa = row.Cells[1].Value.ToString();
                    string opis = row.Cells[2].Value.ToString();
                    string cena = row.Cells[3].Value.ToString();
                    int sprzedane = Convert.ToInt32(row.Cells[4].Value);
                    int ilosc = Convert.ToInt32(row.Cells[5].Value);
                    int kod = Convert.ToInt32(row.Cells[6].Value);

                    EditedProducts.Add(new Product(id, nazwa, opis, cena, sprzedane, ilosc, kod));
                }
            }

            ProductEdited?.Invoke(this, EventArgs.Empty);

            Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void InitializeComponent()
        {
            dataGridView1 = new DataGridView();
            saveButton = new MaterialButton();
            cancelButton = new MaterialButton();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn4 = new DataGridViewTextBoxColumn();
            sprzedaneColumn = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn5 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn6 = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnHeadersHeight = 29;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn1, dataGridViewTextBoxColumn2, dataGridViewTextBoxColumn3, dataGridViewTextBoxColumn4, sprzedaneColumn, dataGridViewTextBoxColumn5, dataGridViewTextBoxColumn6 });
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.EditMode = DataGridViewEditMode.EditOnEnter;
            dataGridView1.Location = new Point(3, 64);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(544, 458);
            dataGridView1.TabIndex = 2;
            // 
            // saveButton
            // 
            saveButton.AutoSize = false;
            saveButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            saveButton.Density = MaterialButton.MaterialButtonDensity.Default;
            saveButton.Depth = 0;
            saveButton.HighEmphasis = true;
            saveButton.Icon = null;
            saveButton.Location = new Point(10, 426);
            saveButton.Margin = new Padding(4, 6, 4, 6);
            saveButton.MouseState = MouseState.HOVER;
            saveButton.Name = "saveButton";
            saveButton.NoAccentTextColor = Color.Empty;
            saveButton.Size = new Size(530, 40);
            saveButton.TabIndex = 3;
            saveButton.Text = "Zapisz";
            saveButton.Type = MaterialButton.MaterialButtonType.Contained;
            saveButton.UseAccentColor = false;
            saveButton.UseVisualStyleBackColor = true;
            saveButton.Click += SaveButton_Click;
            // 
            // cancelButton
            // 
            cancelButton.AutoSize = false;
            cancelButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            cancelButton.Density = MaterialButton.MaterialButtonDensity.Default;
            cancelButton.Depth = 0;
            cancelButton.HighEmphasis = true;
            cancelButton.Icon = null;
            cancelButton.Location = new Point(10, 476);
            cancelButton.Margin = new Padding(4, 6, 4, 6);
            cancelButton.MouseState = MouseState.HOVER;
            cancelButton.Name = "cancelButton";
            cancelButton.NoAccentTextColor = Color.Empty;
            cancelButton.Size = new Size(530, 40);
            cancelButton.TabIndex = 4;
            cancelButton.Text = "Anuluj";
            cancelButton.Type = MaterialButton.MaterialButtonType.Contained;
            cancelButton.UseAccentColor = false;
            cancelButton.UseVisualStyleBackColor = true;
            cancelButton.Click += CancelButton_Click;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.HeaderText = "Id";
            dataGridViewTextBoxColumn1.MinimumWidth = 6;
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewTextBoxColumn2.HeaderText = "Nazwa";
            dataGridViewTextBoxColumn2.MinimumWidth = 6;
            dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewTextBoxColumn3.HeaderText = "Opis";
            dataGridViewTextBoxColumn3.MinimumWidth = 6;
            dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            dataGridViewTextBoxColumn4.HeaderText = "Cena";
            dataGridViewTextBoxColumn4.MinimumWidth = 6;
            dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // sprzedaneColumn
            // 
            sprzedaneColumn.HeaderText = "Sprzedane";
            sprzedaneColumn.MinimumWidth = 6;
            sprzedaneColumn.Name = "sprzedaneColumn";
            // 
            // dataGridViewTextBoxColumn5
            // 
            dataGridViewTextBoxColumn5.HeaderText = "Ilość";
            dataGridViewTextBoxColumn5.MinimumWidth = 6;
            dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // dataGridViewTextBoxColumn6
            // 
            dataGridViewTextBoxColumn6.HeaderText = "Kod";
            dataGridViewTextBoxColumn6.MinimumWidth = 6;
            dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            // 
            // EditProductForm
            // 
            ClientSize = new Size(550, 525);
            Controls.Add(cancelButton);
            Controls.Add(saveButton);
            Controls.Add(dataGridView1);
            MaximizeBox = false;
            Name = "EditProductForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Edytuj produkt";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }
    }
}