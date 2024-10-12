using MaterialSkin.Controls;
using MaterialSkin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Relational;
using static System.ComponentModel.Design.ObjectSelectorEditor;

namespace System_informatyczny_sklepu_sportowego_UX
{
    public partial class DeleteProductForm : MaterialForm
    {
        public List<ListViewItem> SelectedItems { get; private set; }
        private Dictionary<ListViewItem, bool> selectedItemsState = new Dictionary<ListViewItem, bool>();

        public DeleteProductForm(ListView.ListViewItemCollection items)
        {
            InitializeComponent();

            SelectedItems = new List<ListViewItem>();

            foreach (ListViewItem item in items)
            {
                ListViewItem newItem = new ListViewItem(item.SubItems[0].Text);
                newItem.SubItems.Add(item.SubItems[1].Text);
                newItem.SubItems.Add(item.SubItems[2].Text);
                newItem.SubItems.Add(item.SubItems[3].Text);
                newItem.SubItems.Add(item.SubItems[4].Text);
                newItem.SubItems.Add(item.SubItems[5].Text);
                newItem.SubItems.Add(item.SubItems[6].Text);
                listView1.Items.Add(newItem);
                selectedItemsState[newItem] = false;
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {

            SelectedItems.Clear();

            foreach (ListViewItem item in listView1.CheckedItems.Cast<ListViewItem>().ToList())
            {
                SelectedItems.Add(item);
            }

            DeleteSelectedProducts();

            foreach (ListViewItem item in SelectedItems)
            {
                listView1.Items.Remove(item);
            }
        }

        private void DeleteSelectedProducts()
        {
            string connectionString = "Server=localhost;Port=3306;Database=system_inf_skl_sport;Uid=root;Pwd=;";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                foreach (ListViewItem selectedItem in SelectedItems)
                {
                    int productId = int.Parse(selectedItem.SubItems[0].Text);

                    MySqlCommand deleteCommand = new MySqlCommand("DELETE FROM Produkty WHERE Id = @Id", connection);
                    deleteCommand.Parameters.AddWithValue("@Id", productId);

                    deleteCommand.ExecuteNonQuery();
                }
            }
        }
    }
}