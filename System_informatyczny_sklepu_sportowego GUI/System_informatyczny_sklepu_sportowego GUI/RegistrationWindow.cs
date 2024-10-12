using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaterialSkin;
using MaterialSkin.Controls;

namespace System_informatyczny_sklepu_sportowego_GUI
{
    public partial class RegistrationWindow : MaterialForm
    {
        private const string connectionString = "Server=localhost;Port=3306;Database=system_inf_skl_sport;Uid=root;Pwd=;";
        public RegistrationWindow()
        {
            InitializeComponent();
        }
        private void button1Zarejestruj_Click(object sender, EventArgs e)
        {
            string nazwa = textBoxNazwa.Text;
            string haslo = textBoxHaslo.Text;
            string potwierdzenieHasla = textBoxHaslo2.Text;

            if (haslo != potwierdzenieHasla)
            {
                MessageBox.Show("Hasło i potwierdzenie hasła nie są identyczne!");
                return;
            }

            if (CzyUzytkownikIstnieje(nazwa))
            {
                MessageBox.Show("Użytkownik o podanej nazwie już istnieje!");
                return;
            }

            DodajUzytkownikaDoBazy(nazwa, haslo);
            MessageBox.Show("Rejestracja udana!");

            this.Close();
        }

        private bool CzyUzytkownikIstnieje(string nazwa)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM uzytkownicy WHERE Nazwa_Uzytkownika=@Nazwa_Uzytkownika";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@Nazwa_Uzytkownika", nazwa);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    return reader.HasRows;
                }
            }
        }

        private void DodajUzytkownikaDoBazy(string nazwa, string haslo)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = "INSERT INTO uzytkownicy (Nazwa_Uzytkownika, Haslo) VALUES (@Nazwa_Uzytkownika, @Haslo)";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@Nazwa_Uzytkownika", nazwa);
                cmd.Parameters.AddWithValue("@Haslo", haslo);

                cmd.ExecuteNonQuery();
            }
        }

        private void button2Anuluj_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
