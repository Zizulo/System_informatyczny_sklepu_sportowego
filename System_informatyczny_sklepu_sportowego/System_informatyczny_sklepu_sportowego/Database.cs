using MySql.Data.MySqlClient;
using System.Collections;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Net.Http.Headers;
using CommonLibrary;
using MaterialSkin;
using MaterialSkin.Controls;
using System_informatyczny_sklepu_sportowego_UX;

namespace System_informatyczny_sklepu_sportowego
{
    public partial class Database : MaterialForm
    {
        private bool checkBoxesVisible = false;

        private ListViewColumnSorter sorter;
        public Database()
        {
            InitializeComponent();
            sorter = new ListViewColumnSorter();
            listView1.ListViewItemSorter = sorter;
            listView1.ColumnClick += ListView1_ColumnClick;
            listView1_SelectedIndexChanged(listView1, EventArgs.Empty);

            ImageList imageList = new ImageList();
            imageList.Images.Add("asc", Image.FromFile("Properties/Arrows-Up-icon.png"));
            imageList.Images.Add("desc", Image.FromFile("Properties/Arrows-Down-icon.png"));

            // Przypisz obrazy do kontrolki listView1
            listView1.SmallImageList = imageList;
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Usuñ aktualne dane z ListView
            listView1.Items.Clear();

            // Ustaw wartoœæ checkBoxesVisible na false
            checkBoxesVisible = false;

            List<Product> products = new List<Product>();

            // Pobierz produkty z bazy danych
            string connectionString = "Server=localhost;Port=3306;Database=system_inf_skl_sport;Uid=root;Pwd=;";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand("SELECT Id, Nazwa, Opis, Cena, Sprzedane, Iloœæ, Kod FROM Produkty", connection);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int id = reader.GetInt16(0);
                    string nazwa = reader.GetString(1);
                    string opis = reader.GetString(2);
                    string cena = reader.GetString(3);
                    int sprzedane = reader.GetInt16(4);
                    int iloœæ = reader.GetInt16(5);
                    int kod = reader.GetInt16(6);
                    products.Add(new Product(id, nazwa, opis, cena, sprzedane, iloœæ, kod));
                }
                reader.Close();
            }

            // Dodaj produkty do ListView
            foreach (Product product in products)
            {
                ListViewItem item = new ListViewItem(product.Id.ToString());
                item.SubItems.Add(product.Nazwa);
                item.SubItems.Add(product.Opis);
                item.SubItems.Add(product.Cena); // formatowanie ceny jako waluty
                item.SubItems.Add(product.Sprzedane.ToString());
                item.SubItems.Add(product.Iloœæ.ToString());
                item.SubItems.Add(product.Kod.ToString());

                int bestSales = GetBestSales(products);
                MarkProducts(product, item, bestSales);

                if (checkBoxesVisible) // Dodaj checkboxy, jeœli checkBoxesVisible == true
                {
                    item.Checked = false; // Mo¿esz ustawiæ tutaj pocz¹tkow¹ wartoœæ zaznaczenia checkboxa
                }


                listView1.Items.Add(item);
            }

        }

        public static void MarkProducts(Product product, ListViewItem item, int bestSales)
        {

            if (product.Sprzedane <= 5)
            {
                item.UseItemStyleForSubItems = false;
                item.SubItems[1].ForeColor = Color.Red;
                item.SubItems[4].ForeColor = Color.Red;

            }
            else if (product.Sprzedane == bestSales)
            {
                item.UseItemStyleForSubItems = false;
                item.SubItems[1].ForeColor = Color.Green;
                item.SubItems[4].ForeColor = Color.Green;
            }

            if (product.Iloœæ <= 5)
            {
                item.UseItemStyleForSubItems = false;
                item.SubItems[1].ForeColor = Color.Red;
                item.SubItems[5].ForeColor = Color.Red;
            }

        }
        public static int GetBestSales(List<Product> products)
        {
            int maxSales = 0;

            foreach (Product product in products)
            {
                if (product.Sprzedane > maxSales)
                {
                    maxSales = product.Sprzedane;
                }
            }

            return maxSales;

        }
        private void ListView1_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == sorter.SortColumn)
            {
                sorter.Order = sorter.Order == SortOrder.Ascending ? SortOrder.Descending : SortOrder.Ascending;
            }
            else
            {
                sorter.SortColumn = e.Column;
                sorter.Order = SortOrder.Ascending;
            }

            listView1.Sort();

            // Wyœwietl ikonê sortowania w nag³ówkach kolumn
            foreach (ColumnHeader columnHeader in listView1.Columns)
            {
                columnHeader.ImageKey = null;

                if (columnHeader.DisplayIndex == e.Column)  // Porównaj DisplayIndex
                {
                    if (columnHeader.Tag.ToString() == "Words") // Sortowanie dla kolumny z wyrazami
                    {
                        if (sorter.Order == SortOrder.Ascending)
                        {
                            columnHeader.ImageKey = "asc";
                        }
                        else
                        {
                            columnHeader.ImageKey = "desc";
                        }
                    }
                    else if (columnHeader.Tag.ToString() == "Numbers") // Sortowanie dla kolumny z liczbami
                    {
                        if (sorter.Order == SortOrder.Ascending)
                        {
                            columnHeader.ImageKey = "desc";
                        }
                        else
                        {
                            columnHeader.ImageKey = "asc";
                        }
                    }
                }

            }
        }

        private void zapiszPlikToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Pliki CSV (*.csv)|*.csv";
            saveFileDialog.Title = "Zapisz jako plik CSV";
            saveFileDialog.FileName = "dane_produkty";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (StreamWriter sw = new StreamWriter(saveFileDialog.FileName))
                    {
                        // Zapisz nag³ówki kolumn do pliku CSV
                        string headers = "Id;Nazwa;Opis;Cena;Sprzedane;Iloœæ";
                        sw.WriteLine(headers);

                        // Zapisz dane produktów do pliku CSV
                        foreach (ListViewItem item in listView1.Items)
                        {
                            string id = item.SubItems[0].Text;
                            string nazwa = item.SubItems[1].Text;
                            string opis = item.SubItems[2].Text;
                            string cena = item.SubItems[3].Text;
                            string sprzedane = item.SubItems[4].Text;
                            string ilosc = item.SubItems[5].Text;
                            string kod = item.SubItems[6].Text;

                            string line = $"{id};{nazwa};{opis};{cena};{sprzedane};{ilosc};{kod}";
                            sw.WriteLine(line);
                        }
                    }

                    MessageBox.Show("Dane zosta³y zapisane do pliku CSV.", "Zapisano", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Wyst¹pi³ b³¹d podczas zapisywania pliku: {ex.Message}", "B³¹d", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void produktToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            // Otwórz nowe okno dodawania produktu
            AddProductForm addProductForm = new AddProductForm();
            addProductForm.ProductAdded += AddProductForm_ProductAdded;
            addProductForm.ShowDialog(); // Wyœwietl formularz dodawania produktu
        }

        private void AddProductForm_ProductAdded(object sender, EventArgs e)
        {
            int id = ((AddProductForm)sender).ProductId;
            string nazwa = ((AddProductForm)sender).ProductName;
            string opis = ((AddProductForm)sender).ProductDescription;
            string cena = ((AddProductForm)sender).ProductPrice;
            int sprzedane = 0;
            int ilosc = ((AddProductForm)sender).ProductQuantity;
            int kod = ((AddProductForm)sender).ProductCode;

            int maxId;
            string connectionString = "Server=localhost;Port=3306;Database=system_inf_skl_sport;Uid=root;Pwd=;";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                MySqlCommand getMaxIdCommand = new MySqlCommand("SELECT MAX(Id) FROM Produkty", connection);
                maxId = (int)getMaxIdCommand.ExecuteScalar();
            }

            int newProductId = maxId + 1;

            Product nowyProdukt = new Product(newProductId, nazwa, opis, cena, sprzedane, ilosc, kod);

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand("INSERT INTO Produkty (Id, Nazwa, Opis, Cena, Sprzedane, Iloœæ, Kod) " +
                    "VALUES (@Id, @Nazwa, @Opis, @Cena, @Sprzedane, @Iloœæ, @Kod)", connection);
                command.Parameters.AddWithValue("@Id", nowyProdukt.Id);
                command.Parameters.AddWithValue("@Nazwa", nowyProdukt.Nazwa);
                command.Parameters.AddWithValue("@Opis", nowyProdukt.Opis);
                command.Parameters.AddWithValue("@Cena", nowyProdukt.Cena);
                command.Parameters.AddWithValue("@Sprzedane", nowyProdukt.Sprzedane);
                command.Parameters.AddWithValue("@Iloœæ", nowyProdukt.Iloœæ);
                command.Parameters.AddWithValue("@Kod", nowyProdukt.Kod);
                command.ExecuteNonQuery();
            }

            // Dodaj produkt do ListView
            ListViewItem item = new ListViewItem(nazwa);
            item.SubItems.Add(opis);
            item.SubItems.Add(cena); // formatowanie ceny jako waluty
            item.SubItems.Add("0"); // nowy produkt, wiêc pocz¹tkowo sprzedane = 0
            item.SubItems.Add(ilosc.ToString());
            item.SubItems.Add(kod.ToString());

            listView1.Items.Add(item);

            // Odœwie¿ listê produktów
            listView1_SelectedIndexChanged(sender, e);

        }

        private void produktToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            // Otwórz nowe okno zawieraj¹ce ListView z produktami do usuniêcia
            DeleteProductForm deleteProductForm = new DeleteProductForm(listView1.Items);
            if (deleteProductForm.ShowDialog() == DialogResult.OK)
            {
                // Usuñ zaznaczone produkty z bazy danych
                string connectionString = "Server=localhost;Port=3306;Database=system_inf_skl_sport;Uid=root;Pwd=;";
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    MySqlCommand command = new MySqlCommand("DELETE FROM Produkty WHERE Id = @Id AND Nazwa = @Nazwa AND Opis = @Opis AND Cena = @Cena AND Sprzedane = @Sprzedane AND Iloœæ = @Iloœæ AND Kod = @Kod", connection);

                    // Usuwanie zaznaczonych produktów
                    foreach (ListViewItem item in deleteProductForm.SelectedItems)
                    {
                        command.Parameters.Clear();
                        command.Parameters.AddWithValue("@Id", item.SubItems[0].Text);
                        command.Parameters.AddWithValue("@Nazwa", item.SubItems[1].Text);
                        command.Parameters.AddWithValue("@Opis", item.SubItems[2].Text);
                        command.Parameters.AddWithValue("@Cena", item.SubItems[3].Text);
                        command.Parameters.AddWithValue("@Sprzedane", int.Parse(item.SubItems[4].Text));
                        command.Parameters.AddWithValue("@Iloœæ", int.Parse(item.SubItems[5].Text));
                        command.Parameters.AddWithValue("@Kod", int.Parse(item.SubItems[6].Text));
                        command.ExecuteNonQuery();
                    }
                }

                // Odœwie¿ listê produktów
                listView1_SelectedIndexChanged(sender, e);

                MessageBox.Show("Produkty zosta³y usuniête.", "Usuniêto produkty", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void edytujToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Otwórz nowe okno zawieraj¹ce ListView z produktami do wyboru
            EditProductForm editProductForm = new EditProductForm(listView1.Items);
            editProductForm.ProductEdited += EditProductForm_ProductEdited;
            editProductForm.FormClosed += EditProductForm_FormClosed;
            editProductForm.ShowDialog();
        }
        private void EditProductForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Odœwie¿ ListView po zamkniêciu okna edycji
            RefreshListView();
        }
        private void RefreshListView()
        {
            // Usuñ aktualne dane z ListView
            listView1.Items.Clear();

            List<Product> products = new List<Product>();

            // Pobierz produkty z bazy danych
            string connectionString = "Server=localhost;Port=3306;Database=system_inf_skl_sport;Uid=root;Pwd=;";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand("SELECT Id, Nazwa, Opis, Cena, Sprzedane, Iloœæ, Kod FROM Produkty", connection);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int id = reader.GetInt16(0);
                    string nazwa = reader.GetString(1);
                    string opis = reader.GetString(2);
                    string cena = reader.GetString(3);
                    int sprzedane = reader.GetInt32(4);
                    int iloœæ = reader.GetInt32(5);
                    int kod = reader.GetInt32(6);
                    products.Add(new Product(id, nazwa, opis, cena, sprzedane, iloœæ, kod));
                }
                reader.Close();
            }

            // Dodaj produkty do ListView
            foreach (Product product in products)
            {
                ListViewItem item = new ListViewItem(product.Id.ToString());
                item.SubItems.Add(product.Nazwa);
                item.SubItems.Add(product.Opis);
                item.SubItems.Add(product.Cena); // formatowanie ceny jako waluty
                item.SubItems.Add(product.Sprzedane.ToString());
                item.SubItems.Add(product.Iloœæ.ToString());
                item.SubItems.Add(product.Kod.ToString());

                int bestSales = GetBestSales(products);
                MarkProducts(product, item, bestSales);

                if (checkBoxesVisible) // Dodaj checkboxy, jeœli checkBoxesVisible == true
                {
                    item.Checked = false; // Mo¿esz ustawiæ tutaj pocz¹tkow¹ wartoœæ zaznaczenia checkboxa
                }

                listView1.Items.Add(item);
            }
        }
        private void EditProductForm_ProductEdited(object sender, EventArgs e)
        {
            // Pobierz zaktualizowane produkty po zamkniêciu okna edycji
            List<Product> editedProducts = ((EditProductForm)sender).EditedProducts;

            // Aktualizuj dane produktów w listView1 i bazie danych
            foreach (Product editedProduct in editedProducts)
            {
                // ZnajdŸ indeks produktu w listView1 po Id
                int itemIndex = listView1.Items.IndexOfKey(editedProduct.Id.ToString());

                if (itemIndex >= 0)
                {
                    // ZnajdŸ produkt w listView1
                    ListViewItem itemToUpdate = listView1.Items[itemIndex];

                    // Aktualizuj dane produktu w listView1
                    itemToUpdate.SubItems[1].Text = editedProduct.Nazwa;
                    itemToUpdate.SubItems[2].Text = editedProduct.Opis;
                    itemToUpdate.SubItems[3].Text = editedProduct.Cena;
                    itemToUpdate.SubItems[4].Text = editedProduct.Sprzedane.ToString();
                    itemToUpdate.SubItems[5].Text = editedProduct.Iloœæ.ToString();
                    itemToUpdate.SubItems[6].Text = editedProduct.Kod.ToString();
                }

                // Aktualizuj dane produktu w bazie danych
                UpdateProductsInDatabase(editedProduct);
            }

            // Odœwie¿ ListView po zakoñczeniu edycji
            RefreshListView();

            MessageBox.Show("Produkty zosta³y zaktualizowane.", "Edytowano produkty", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void UpdateProductsInDatabase(Product editedProduct)
        {
            string connectionString = "Server=localhost;Port=3306;Database=system_inf_skl_sport;Uid=root;Pwd=;";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand("UPDATE Produkty SET Nazwa=@Nazwa, Opis=@Opis, Cena=@Cena, Iloœæ=@Iloœæ, Kod=@Kod WHERE Id=@Id", connection);
                command.Parameters.AddWithValue("@Opis", editedProduct.Opis);
                command.Parameters.AddWithValue("@Cena", editedProduct.Cena);
                command.Parameters.AddWithValue("@Iloœæ", editedProduct.Iloœæ);
                command.Parameters.AddWithValue("@Kod", editedProduct.Kod);
                command.Parameters.AddWithValue("@Nazwa", editedProduct.Nazwa);
                command.Parameters.AddWithValue("@Id", editedProduct.Id);
                command.ExecuteNonQuery();
            }
        }

        public ListView GetListView()
        {
            return listView1;
        }

        public class ListViewColumnSorter : IComparer
        {
            private int columnToSort;
            private SortOrder orderOfSort;

            public ListViewColumnSorter()
            {
                columnToSort = 0;
                orderOfSort = SortOrder.None;
            }

            public int Compare(object x, object y)
            {
                int compareResult;
                ListViewItem listViewItemX = (ListViewItem)x;
                ListViewItem listViewItemY = (ListViewItem)y;

                // Compare the sub-items based on the column clicked
                if (columnToSort == 2) // Kolumna "Opis"
                {
                    compareResult = String.Compare(listViewItemX.SubItems[columnToSort].Text, listViewItemY.SubItems[columnToSort].Text);
                }
                else if (columnToSort == 3 || columnToSort == 4)
                {
                    // Reszta kodu bez zmian
                    if (decimal.TryParse(listViewItemX.SubItems[columnToSort].Text, out decimal decimalX) &&
                        decimal.TryParse(listViewItemY.SubItems[columnToSort].Text, out decimal decimalY))
                    {
                        compareResult = decimalX.CompareTo(decimalY);
                    }
                    else
                    {
                        compareResult = 0;
                    }
                }
                else
                {
                    // Reszta kodu bez zmian
                    compareResult = String.Compare(listViewItemX.SubItems[columnToSort].Text, listViewItemY.SubItems[columnToSort].Text);
                }

                // Calculate correct return value based on object comparison
                if (orderOfSort == SortOrder.Ascending)
                {
                    return compareResult;
                }
                else if (orderOfSort == SortOrder.Descending)
                {
                    return -compareResult;
                }
                else
                {
                    return 0;
                }
            }

            public int SortColumn
            {
                set => columnToSort = value;
                get => columnToSort;
            }

            public SortOrder Order
            {
                set => orderOfSort = value;
                get => orderOfSort;
            }
        }

        public class Product
        {
            public int Id { get; set; }
            public string Nazwa { get; set; }
            public string Opis { get; set; }
            public string Cena { get; set; }
            public int Sprzedane { get; set; }
            public int Iloœæ { get; set; }
            public int Kod { get; set; }

            public Product(int id, string nazwa, string opis, string cena, int sprzedane, int iloœæ, int kod)
            {
                Id = id;
                Nazwa = nazwa;
                Opis = opis;
                Cena = cena;
                Sprzedane = sprzedane;
                Iloœæ = iloœæ;
                Kod = kod;
            }
        }

        private void drukujToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrintDocument printDoc = new PrintDocument();
            printDoc.PrintPage += new PrintPageEventHandler(PrintListViewContents);

            PrintDialog printDialog = new PrintDialog();
            printDialog.Document = printDoc;

            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                printDoc.Print();
            }
        }

        private void PrintListViewContents(object sender, PrintPageEventArgs e)
        {
            Graphics graphics = e.Graphics;
            Font font = new Font("Arial", 10);

            float currentY = 0;
            int itemHeight = listView1.Font.Height + 5;

            foreach (ListViewItem item in listView1.Items)
            {
                string text = "";
                foreach (ListViewItem.ListViewSubItem subItem in item.SubItems)
                {
                    text += subItem.Text + "\t";
                }

                graphics.DrawString(text, font, Brushes.Black, 0, currentY);
                currentY += itemHeight;
            }
        }

        private void wyœwietlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DisplayDataForm displayForm = new DisplayDataForm();

            // Assuming you want to pass the data to the new form
            foreach (ListViewItem item in listView1.Items)
            {
                string[] rowData = new string[item.SubItems.Count];
                for (int i = 0; i < item.SubItems.Count; i++)
                {
                    rowData[i] = item.SubItems[i].Text;
                }
                displayForm.AddRow(rowData);
            }

            displayForm.Show();
        }

        private void aktualizuj_baze_danych_Click(object sender, EventArgs e)
        {
            listView1_SelectedIndexChanged(sender, e);
        }
        public void SetLabel1Text()
        {
            label1.Text = "Witaj, " + CurrentUser.Instance.NazwaUzytkownika + "!";
        }
    }
}