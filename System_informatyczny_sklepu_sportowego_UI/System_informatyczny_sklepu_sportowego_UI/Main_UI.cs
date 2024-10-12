using System;
using System.Data;
using MySql.Data.MySqlClient;
using System.Drawing;
using System.Drawing.Text;
using System.DirectoryServices.ActiveDirectory;
using CommonLibrary;
using MaterialSkin;
using MaterialSkin.Controls;

namespace System_informatyczny_sklepu_sportowego_UI
{
    public enum ControlState
    {
        Towary,
        StanKasy,
        HistoriaSprzedazy,
        Kod,
        KoniecTransakcji
    }
    public partial class Main_UI : MaterialForm
    {
        private MaterialTextBox textBox = new MaterialTextBox();
        private MaterialButton okButton = new MaterialButton();
        private DataGridView dataGridView1 = new DataGridView();
        private DataGridView dataGridView2 = new DataGridView();
        private DataGridView dataGridView3 = new DataGridView();
        private decimal sumaCen = 0.0m;
        private decimal sumaCenowa = 0.0m;
        private bool kolumnyStanuKasyDodane = false;
        private bool kolumnyTowary = false;
        private bool kolumnyHistoriaSprzedazy = false;
        private int aktualnyParagonId = -1;


        private ControlState CurrentState { get; set; }
        public Main_UI()
        {
            InitializeComponent();
            UstawTekstLabel1();
            CurrentState = ControlState.Towary;
            ToggleControlsVisibility();
            anulujButton.Visible = false;
            platnoscButton.Visible = false;

            for (int i = 0; i <= 9; i++)
            {
                Button digitButton = Controls.Find($"button{i}", true).FirstOrDefault() as Button;

                if (digitButton != null)
                {
                    digitButton.Click += DigitButton_Click;
                }
            }

            Button commaButton = Controls.Find("buttonP", true).FirstOrDefault() as Button;
            if (commaButton != null)
            {
                commaButton.Click += CommaButton_Click;
            }


        }
        private void CommaButton_Click(object sender, EventArgs e)
        {
            if (CurrentState == ControlState.Kod)
            {
                textBox.Text += ",";
            }
        }

        private void DigitButton_Click(object sender, EventArgs e)
        {
            if (CurrentState == ControlState.Kod)
            {
                Button digitButton = sender as Button;

                if (digitButton != null)
                {
                    textBox.Text += digitButton.Text;
                }
            }
        }

        private void UstawTekstLabel1()
        {
            if (string.IsNullOrEmpty(label1.Text))
            {
                label1.Font = new Font("Arial", 28); 
                label1.Text = "SUMA £¥CZNIE" + " " + "0.00 z³" + Environment.NewLine + "Paragon jest pusty...";
            }
        }

        private void UsunTekstParagonu()
        {
            string tekstDoUsuniecia = "SUMA £¥CZNIE" + " " + "0.00 z³" + Environment.NewLine + "Paragon jest pusty...";

            if (label1.Text.Contains(tekstDoUsuniecia))
            {
                label1.Text = label1.Text.Replace(tekstDoUsuniecia, "");
            }
        }

        private void UsunTransakcje()
        {
            string tekstDoUsuniecia = "SUMA £¥CZNIE: " + sumaCen.ToString("F2") + " z³";

            if (label1.Text.Contains(tekstDoUsuniecia))
            {
                label1.Text = label1.Text.Replace(tekstDoUsuniecia, "");
            }
            sumaCen = 0.0m;
        }

        private void ToggleControlsVisibility()
        {
            switch (CurrentState)
            {
                case ControlState.Towary:
                    dataGridView1.Visible = true;
                    dataGridView2.Visible = false;
                    dataGridView3.Visible = false;
                    textBox.Visible = false;
                    okButton.Visible = false;
                    break;
                case ControlState.StanKasy:
                    dataGridView1.Visible = false;
                    dataGridView2.Visible = true;
                    dataGridView3.Visible = false;
                    textBox.Visible = false;
                    okButton.Visible = false;
                    break;
                case ControlState.HistoriaSprzedazy:
                    dataGridView1.Visible = false;
                    dataGridView2.Visible = false;
                    dataGridView3.Visible = true;
                    textBox.Visible = false;
                    okButton.Visible = false;
                    break;
                case ControlState.Kod:
                    dataGridView1.Visible = false;
                    dataGridView2.Visible = false;
                    dataGridView3.Visible = false;
                    textBox.Visible = true;
                    okButton.Visible = true;
                    break;
                case ControlState.KoniecTransakcji:
                    dataGridView1.Visible = false;
                    dataGridView2.Visible = false;
                    dataGridView3.Visible = false;
                    textBox.Visible = false;
                    okButton.Visible = false;
                    break;
                default:
                    break;
            }
        }
        private void towary_Click(object sender, EventArgs e)
        {
            CurrentState = ControlState.Towary;
            ToggleControlsVisibility();
            UsunTekstParagonu();

            if (!kolumnyTowary)
            {
                dataGridView1.Location = new System.Drawing.Point(631, 123);
                dataGridView1.Size = new System.Drawing.Size(545, 358);
                dataGridView1.ReadOnly = true;

                dataGridView1.AutoGenerateColumns = false;
                dataGridView1.Columns.Add("Nazwa", "Nazwa");
                dataGridView1.Columns.Add("Opis", "Opis");
                dataGridView1.Columns.Add("Cena", "Cena");

                dataGridView1.CellFormatting += DataGridView1_CellFormatting;
                PobierzTowaryZBazyDanych();

                dataGridView1.CellClick += DataGridView1_CellClick;
                this.Controls.Add(dataGridView1);

                kolumnyTowary = true;
            }
        }
        private void DataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                int szerokoscKolumny = 130;
                dataGridView1.Columns[e.ColumnIndex].Width = szerokoscKolumny;
            }
            if (e.ColumnIndex == 2) 
            {
                int szerokoscKolumny = 60;
                dataGridView1.Columns[e.ColumnIndex].Width = szerokoscKolumny;
            }
        }
        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                string cenaStr = row.Cells["Cena"].Value.ToString();
                if (decimal.TryParse(cenaStr, out decimal cenaProduktu))
                {
                    sumaCen += cenaProduktu;

                    string wybranyTowar = row.Cells["Nazwa"].Value.ToString();
                    label1.Text += Environment.NewLine + wybranyTowar + " - " + cenaProduktu.ToString("F2") + " z³";
                }
            }
        }

        private void PobierzTowaryZBazyDanych()
        {
            string connStr = "Server=localhost;Port=3306;Database=system_inf_skl_sport;Uid=root;Pwd=;";
            using (MySqlConnection connection = new MySqlConnection(connStr))
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand("SELECT Nazwa, Opis, Cena FROM Produkty", connection);
                MySqlDataReader reader = command.ExecuteReader();

                dataGridView1.Rows.Clear();

                while (reader.Read())
                {
                    dataGridView1.Rows.Add(reader["Nazwa"].ToString(), reader["Opis"].ToString(), reader["Cena"].ToString());
                }

                reader.Close();
            }
        }
        private void ResetujPoTransakcji()
        {
            label1.Text = "SUMA £¥CZNIE" + " " + "0.00 z³" + Environment.NewLine + "Paragon jest pusty...";
            textBox.Clear();

            aktualnyParagonId = -1;

            platnoscButton.Visible = false;
            anulujButton.Visible = false;

            sumaCen = 0.0m;
        }
        private void razem_Click(object sender, EventArgs e)
        {
            if (aktualnyParagonId == -1)
            {
                aktualnyParagonId = ZapiszHistorieSprzedazy();
            }

            ZapiszProduktyNaParagonie(aktualnyParagonId);

            label1.Text = "SUMA £¥CZNIE: " + sumaCen.ToString("F2") + " z³";

            sumaCenowa += sumaCen;

            platnoscButton.Visible = true;
            platnoscButton.BringToFront();

            anulujButton.Visible = true;
            anulujButton.BringToFront();
        }

        private void AnulujButton_Click(object sender, EventArgs e)
        {
            UsunTransakcje();

            platnoscButton.Visible = false;
            anulujButton.Visible = false;
        }

        private void PlatnoscButton_Click(object sender, EventArgs e)
        {
            Form platnoscForm = new Form();
            platnoscForm.Text = "Wybór p³atnoœci";

            Button gotowkaButton = new Button();
            gotowkaButton.Text = "Gotówka";
            gotowkaButton.Location = new System.Drawing.Point(20, 20);
            gotowkaButton.Size = new System.Drawing.Size(100, 30);
            gotowkaButton.Click += GotowkaButton_Click;

            Button przelewButton = new Button();
            przelewButton.Text = "Przelew";
            przelewButton.Location = new System.Drawing.Point(160, 20);
            przelewButton.Size = new System.Drawing.Size(100, 30);
            przelewButton.Click += PrzelewButton_Click;

            platnoscForm.Controls.Add(gotowkaButton);
            platnoscForm.Controls.Add(przelewButton);

            platnoscForm.ShowDialog();
        }

        private void GotowkaButton_Click(object sender, EventArgs e)
        {
            CurrentState = ControlState.KoniecTransakcji;

            ToggleControlsVisibility(); 
            ZapiszProduktyNaParagonie(aktualnyParagonId);

            AktualizujLiczbeSprzedanychProduktowZParagonu(aktualnyParagonId);

            ResetujPoTransakcji();

            MessageBox.Show("Zap³acono gotówk¹. Paragon dostêpny do druku.", "Potwierdzenie p³atnoœci", MessageBoxButtons.OK, MessageBoxIcon.Information);

            DrukujParagon();
        }

        private void PrzelewButton_Click(object sender, EventArgs e)
        {
            CurrentState = ControlState.KoniecTransakcji;

            ToggleControlsVisibility();
            ZapiszProduktyNaParagonie(aktualnyParagonId);

            AktualizujLiczbeSprzedanychProduktowZParagonu(aktualnyParagonId);

            ResetujPoTransakcji();

            MessageBox.Show("Zap³acono przelewem. Paragon dostêpny do druku.", "Potwierdzenie p³atnoœci", MessageBoxButtons.OK, MessageBoxIcon.Information);

            DrukujParagon();
        }

        private void AktualizujLiczbeSprzedanychProduktowZParagonu(int paragonId)
        {
            string connStr = "Server=localhost;Port=3306;Database=system_inf_skl_sport;Uid=root;Pwd=;";

            List<(string NazwaProduktu, int Ilosc)> daneProduktow = new List<(string, int)>();

            using (MySqlConnection connection = new MySqlConnection(connStr))
            {
                connection.Open();

                string selectQuery = "SELECT Nazwa_Produktu, Iloœæ FROM produkty_na_paragonie WHERE Paragon_Id = @Paragon_Id";
                MySqlCommand selectCommand = new MySqlCommand(selectQuery, connection);
                selectCommand.Parameters.AddWithValue("@Paragon_Id", paragonId);

                using (MySqlDataReader reader = selectCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string nazwaProduktu = reader["Nazwa_Produktu"].ToString();
                        int ilosc = Convert.ToInt32(reader["Iloœæ"]);

                        daneProduktow.Add((nazwaProduktu, ilosc));
                    }
                }

                foreach (var daneProduktu in daneProduktow)
                {
                    string updateQuery = "UPDATE Produkty SET Sprzedane = Sprzedane + @Iloœæ, Iloœæ = Iloœæ - @Iloœæ WHERE Nazwa = @Nazwa";
                    MySqlCommand updateCommand = new MySqlCommand(updateQuery, connection);
                    updateCommand.Parameters.AddWithValue("@Iloœæ", daneProduktu.Ilosc);
                    updateCommand.Parameters.AddWithValue("@Nazwa", daneProduktu.NazwaProduktu);

                    updateCommand.ExecuteNonQuery();
                }

                daneProduktow.Clear();
            }
        }

        private void DrukujParagon()
        {
            // https://docs.microsoft.com/en-us/dotnet/api/system.drawing.printing.printdocument?view=net-7.0
        }
        private int ZapiszHistorieSprzedazy()
        {
            int paragonId = -1;

            string connStr = "Server=localhost;Port=3306;Database=system_inf_skl_sport;Uid=root;Pwd=;";
            using (MySqlConnection connection = new MySqlConnection(connStr))
            {
                connection.Open();

                string insertQuery = "INSERT INTO historia_sprzedazy (Data) VALUES (@Data)";
                MySqlCommand insertCommand = new MySqlCommand(insertQuery, connection);
                insertCommand.Parameters.AddWithValue("@Data", DateTime.Now);
                insertCommand.ExecuteNonQuery();

                string selectIdQuery = "SELECT LAST_INSERT_ID()";
                MySqlCommand selectIdCommand = new MySqlCommand(selectIdQuery, connection);
                paragonId = Convert.ToInt32(selectIdCommand.ExecuteScalar());
            }

            return paragonId;
        }

        private void ZapiszProduktyNaParagonie(int paragonId)
        {
            string connStr = "Server=localhost;Port=3306;Database=system_inf_skl_sport;Uid=root;Pwd=;";
            using (MySqlConnection connection = new MySqlConnection(connStr))
            {
                connection.Open();

                string[] lines = label1.Text.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

                foreach (string line in lines)
                {
                    string[] parts = line.Split('-');

                    if (parts.Length == 2)
                    {
                        string nazwaProduktu = parts[0].Trim();
                        string cenaStr = parts[1].Replace("z³", "").Trim();

                        if (decimal.TryParse(cenaStr, out decimal cenaProduktu))
                        {
                            int ilosc = 1; 

                            string insertQuery = "INSERT INTO produkty_na_paragonie (Paragon_Id, Nazwa_Produktu, Cena, Iloœæ) VALUES (@Paragon_Id, @Nazwa_Produktu, @Cena, @Iloœæ)";
                            MySqlCommand insertCommand = new MySqlCommand(insertQuery, connection);
                            insertCommand.Parameters.AddWithValue("@Paragon_Id", paragonId);
                            insertCommand.Parameters.AddWithValue("@Nazwa_Produktu", nazwaProduktu);
                            insertCommand.Parameters.AddWithValue("@Cena", cenaProduktu);
                            insertCommand.Parameters.AddWithValue("@Iloœæ", ilosc);
                            insertCommand.ExecuteNonQuery();
                        }
                    }
                }
            }
        }

        private void clear_Click(object sender, EventArgs e)
        {
            label1.Text = "";
            sumaCen = 0.0m;
            textBox.Clear();
        }

        private void backspace_Click(object sender, EventArgs e)
        {
            CofnijOstatniProdukt();
        }
        private void CofnijOstatniProdukt()
        {
            string aktualnyTekst = label1.Text;
            string[] linie = aktualnyTekst.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            if (linie.Length > 0)
            {
                string ostatniaLinia = linie[linie.Length - 1];
                string[] informacje = ostatniaLinia.Split('-');

                if (informacje.Length == 2)
                {
                    string nazwaProduktu = informacje[0].Trim();
                    string cenaProduktuStr = informacje[1].Replace("z³", "").Trim();

                    if (decimal.TryParse(cenaProduktuStr, out decimal cenaProduktu))
                    {
                        sumaCen -= cenaProduktu;
                        label1.Text = string.Join(Environment.NewLine, linie.Take(linie.Length - 1));
                    }
                }
            }
        }

        private void stan_kasy_Click(object sender, EventArgs e)
        {
            CurrentState = ControlState.StanKasy;
            ToggleControlsVisibility();

            if (!kolumnyStanuKasyDodane)
            {
                dataGridView2.AutoGenerateColumns = false;
                dataGridView2.Location = new System.Drawing.Point(631, 123);
                dataGridView2.Size = new System.Drawing.Size(545, 358);
                dataGridView2.ReadOnly = true;

                dataGridView2.Columns.Add("Bud¿et", "Budzet");
                dataGridView2.Columns.Add("Zysk", "Zysk");

                kolumnyStanuKasyDodane = true; 
            }

            string nowaKwota = PobierzStanKasy(dataGridView2);

            this.Controls.Add(dataGridView2); 

            AktualizujBudzet(nowaKwota);

            sumaCenowa = 0.0m;
        }

        private string PobierzStanKasy(DataGridView gridStanKasy)
        {
            string connStr = "Server=localhost;Port=3306;Database=system_inf_skl_sport;Uid=root;Pwd=;";
            decimal suma = 0.0m;
            string Act_kwota = suma.ToString();

            using (MySqlConnection connection = new MySqlConnection(connStr))
            {
                connection.Open();

                string query = "SELECT Kasa_sklepowa FROM stan_kasy";
                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataReader reader = command.ExecuteReader();

                gridStanKasy.Rows.Clear();

                while (reader.Read())
                {
                    string budzet = reader["Kasa_sklepowa"].ToString();
                    suma = decimal.Parse(budzet) + sumaCenowa;
                    string kwota = suma.ToString();
                    Act_kwota = suma.ToString();

                    dataGridView2.Rows.Add(budzet, kwota + " z³");
                }

                reader.Close();
            }

            return Act_kwota;
        }

        private void AktualizujBudzet(string nowaKwota)
        {
            string connStr = "Server=localhost;Port=3306;Database=system_inf_skl_sport;Uid=root;Pwd=;";

            using (MySqlConnection connection = new MySqlConnection(connStr))
            {
                connection.Open();

                string updateQuery = "UPDATE stan_kasy SET Kasa_sklepowa = @kwota";
                MySqlCommand updateCommand = new MySqlCommand(updateQuery, connection);
                updateCommand.Parameters.AddWithValue("@kwota", nowaKwota);
                updateCommand.ExecuteNonQuery();
            }
        }

        private void historia_sprzeda¿y_Click(object sender, EventArgs e)
        {
            CurrentState = ControlState.HistoriaSprzedazy;
            ToggleControlsVisibility();

            if (!kolumnyHistoriaSprzedazy)
            {
                dataGridView3.Location = new System.Drawing.Point(631, 123);
                dataGridView3.Size = new System.Drawing.Size(545, 358);
                dataGridView3.ReadOnly = true;

                dataGridView3.Columns.Add("Data", "Data");
                dataGridView3.Columns.Add("Nazwa_Produktu", "Nazwa Produktu");
                dataGridView3.Columns.Add("Cena", "Cena");
                dataGridView3.Columns.Add("Iloœæ", "Iloœæ");

                PobierzHistorieSprzedazy(dataGridView3);

                this.Controls.Add(dataGridView3); 

                kolumnyHistoriaSprzedazy = true;
            }
        }

        private void PobierzHistorieSprzedazy(DataGridView gridHistoriaSprzedazy)
        {
            string connStr = "Server=localhost;Port=3306;Database=system_inf_skl_sport;Uid=root;Pwd=;";

            using (MySqlConnection connection = new MySqlConnection(connStr))
            {
                connection.Open();

                string query = "SELECT hs.Data, pnp.Nazwa_Produktu, pnp.Cena, pnp.Iloœæ FROM historia_sprzedazy hs " +
                               "JOIN produkty_na_paragonie pnp ON hs.Id = pnp.Paragon_Id";
                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataReader reader = command.ExecuteReader();

                gridHistoriaSprzedazy.Rows.Clear();

                while (reader.Read())
                {
                    string data = reader["Data"].ToString();
                    string nazwaProduktu = reader["Nazwa_Produktu"].ToString();
                    string cena = reader["Cena"].ToString();
                    string ilosc = reader["Iloœæ"].ToString();

                    dataGridView3.Rows.Add(data, nazwaProduktu, cena, ilosc);
                }

                reader.Close();
            }
        }

        private void code_Click(object sender, EventArgs e)
        {
            CurrentState = ControlState.Kod;
            ToggleControlsVisibility();
            UsunTekstParagonu();

            if (aktualnyParagonId == -1)
            {
                aktualnyParagonId = ZapiszHistorieSprzedazy();
            }

            textBox.Location = new System.Drawing.Point(631, 123);
            textBox.Size = new System.Drawing.Size(250, 100);

            okButton.Text = "OK";
            okButton.Location = new System.Drawing.Point(881, 123);
            okButton.Size = new System.Drawing.Size(50, 50);
            okButton.AutoSize = false;

            okButton.Click -= OkButton_Click;

            okButton.Click += OkButton_Click;

            this.Controls.Add(textBox);
            this.Controls.Add(okButton);
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            string enteredCode = textBox.Text;
            string productName = PobierzNazweProduktu(enteredCode);

            if (!string.IsNullOrEmpty(productName))
            {
                label1.Text += Environment.NewLine + productName + " - " + PobierzCeneProduktu(enteredCode).ToString("F2") + " z³";
                sumaCen += PobierzCeneProduktu(enteredCode);
            }
            else
            {
                MessageBox.Show("Produkt o podanym kodzie nie istnieje.", "B³¹d", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string PobierzNazweProduktu(string kodProduktu)
        {
            string nazwaProduktu = string.Empty;

            string connStr = "Server=localhost;Port=3306;Database=system_inf_skl_sport;Uid=root;Pwd=;";

            using (MySqlConnection connection = new MySqlConnection(connStr))
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand("SELECT Nazwa FROM Produkty WHERE Kod = @Kod", connection);
                command.Parameters.AddWithValue("@Kod", kodProduktu);
                object result = command.ExecuteScalar();

                if (result != null)
                {
                    nazwaProduktu = result.ToString();
                }
            }

            return nazwaProduktu;
        }

        private decimal PobierzCeneProduktu(string kodProduktu)
        {
            decimal cenaProduktu = 0.0m;

            string connStr = "Server=localhost;Port=3306;Database=system_inf_skl_sport;Uid=root;Pwd=;";

            using (MySqlConnection connection = new MySqlConnection(connStr))
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand("SELECT Cena FROM Produkty WHERE Kod = @Kod", connection);
                command.Parameters.AddWithValue("@Kod", kodProduktu);
                object result = command.ExecuteScalar();

                if (result != null)
                {
                    cenaProduktu = Convert.ToDecimal(result);
                }
            }

            return cenaProduktu;
        }
        public void SetLabel2Text()
        {
            label2.Text = "Witaj, " + CurrentUser.Instance.NazwaUzytkownika + "!";
        }
    }
}