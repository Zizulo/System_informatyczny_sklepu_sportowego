using System;
using System.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Threading;
using System_informatyczny_sklepu_sportowego_UI;
using CommonLibrary;
using MaterialSkin;
using MaterialSkin.Controls;

namespace System_informatyczny_sklepu_sportowego_GUI
{
    public partial class LoginWindow : MaterialForm
    {
        private const string connectionString = "Server=localhost;Port=3306;Database=system_inf_skl_sport;Uid=root;Pwd=;";

        Thread th;

        public LoginWindow()
        {
            InitializeComponent();
        }

        private void logowanie_Click(object sender, EventArgs e)
        {
            string nazwa = textBoxNazwa.Text;
            string haslo = textBoxHaslo.Text;

            try
            {
                if (CzyUzytkownikIstnieje(nazwa, haslo))
                {
                    CurrentUser.Instance.NazwaUzytkownika = nazwa;
                    this.Close();
                    th = new Thread(() => opennewform(nazwa));
                    th.SetApartmentState(ApartmentState.STA);
                    th.Start();
                }
                else
                {
                    MessageBox.Show("B³êdna nazwa u¿ytkownika lub has³o!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Wyst¹pi³ b³¹d podczas ³¹czenia z baz¹ danych: {ex.Message}", "B³¹d po³¹czenia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void opennewform(object obj)
        {
            UserPanel form3 = new UserPanel((string)obj);
            form3.SetLabel2Text();

            if (form3.InvokeRequired)
            {
                form3.Invoke(new MethodInvoker(delegate { form3.Show(); }));
            }
            else
            {
                form3.Show();
            }

            Application.Run();
        }

        private void rejestracja_Click(object sender, EventArgs e)
        {
            RegistrationWindow formRejestracja = new RegistrationWindow();
            formRejestracja.ShowDialog();
        }

        private bool CzyUzytkownikIstnieje(string nazwa, string haslo)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM uzytkownicy WHERE Nazwa_Uzytkownika=@Nazwa_Uzytkownika AND Haslo=@Haslo";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@Nazwa_Uzytkownika", nazwa);
                cmd.Parameters.AddWithValue("@Haslo", haslo);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    return reader.HasRows;
                }
            }
        }
    }
}
