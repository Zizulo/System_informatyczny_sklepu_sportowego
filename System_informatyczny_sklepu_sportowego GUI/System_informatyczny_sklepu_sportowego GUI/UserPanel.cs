using System;
using System.Reflection;
using System_informatyczny_sklepu_sportowego_UI;
using System_informatyczny_sklepu_sportowego;
using System.Threading;
using MaterialSkin;
using MaterialSkin.Controls;

namespace System_informatyczny_sklepu_sportowego_GUI
{
    public partial class UserPanel : MaterialForm
    {
        Thread th;
        private string nazwaUzytkownika;
        private LoginWindow lw;
        private Database db;
        private Main_UI mUI;

        public UserPanel(string nazwaUzytkownika)
        {
            InitializeComponent();
            this.nazwaUzytkownika = nazwaUzytkownika;
        }
        public void SetLabel2Text()
        {
            if (label2.InvokeRequired)
            {
                label2.Invoke(new MethodInvoker(delegate { label2.Text = "Witaj, " + nazwaUzytkownika + "!"; }));
            }
            else
            {
                label2.Text = "Witaj, " + nazwaUzytkownika + "!";
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (!IsFormOpen("Baza danych"))
            {
                /*th = new Thread(opennewform1);
                th.SetApartmentState(ApartmentState.STA);
                th.Start();*/
                OpenDatabase();
            }

        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (!IsFormOpen("Panel"))
            {
                OpenMainUI();
            }

        }
        private void button3_Click(object sender, EventArgs e)
        {
            th = new Thread(opennewform);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
            Application.Exit();
        }
        private bool IsFormOpen(string formName)
        {
            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == formName)
                {
                    return true;
                }
            }
            return false;
        }
        private void OpenMainUI()
        {
            if (mUI == null || mUI.IsDisposed)
            {
                mUI = new Main_UI();
                mUI.SetLabel2Text();
            }

            mUI.Show();
        }
        private void OpenDatabase()
        {
            if (db == null || db.IsDisposed)
            {
                db = new Database();
                db.SetLabel1Text();
            }
            db.Show();
        }

        private void opennewform(object obj)
        {
            lw = new LoginWindow();

            if (lw.InvokeRequired)
            {
                lw.Invoke(new MethodInvoker(delegate { lw.ShowDialog(); }));
            }
            else
            {
                lw.ShowDialog();
            }

        }

        private void UserPanel_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
