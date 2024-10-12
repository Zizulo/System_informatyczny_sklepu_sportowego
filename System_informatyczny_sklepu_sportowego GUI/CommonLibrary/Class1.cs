// W projekcie CommonLibrary
namespace CommonLibrary
{
    public class CurrentUser
    {
        private static CurrentUser _instance;
        private string _nazwaUzytkownika;

        private CurrentUser()
        {
            // Prywatny konstruktor, aby uniemożliwić bezpośrednie utworzenie instancji
        }

        public static CurrentUser Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new CurrentUser();
                }
                return _instance;
            }
        }

        public string NazwaUzytkownika
        {
            get { return _nazwaUzytkownika; }
            set { _nazwaUzytkownika = value; }
        }
    }
}
