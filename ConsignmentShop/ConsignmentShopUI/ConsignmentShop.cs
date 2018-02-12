using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ConsignmentShopLibrary;
using System.IO;

namespace ConsignmentShopUI
{
    public partial class ConsignmentForm : Form
    {
        private Store store = new Store();
        BindingSource itemsBinding = new BindingSource();
        BindingSource cartBinding = new BindingSource();
        BindingSource vendorBinding = new BindingSource();
        private List<Item> shoppingCart = new List<Item>();
        private decimal storeProfit = 0;

        public ConsignmentForm()
        {
            InitializeComponent();
            SetupData();

            itemsBinding.DataSource = store.Items.Where(x=> x.Sold == false).ToList();
            itemListBox.DataSource = itemsBinding;

            itemListBox.DisplayMember = "Display";
            itemListBox.ValueMember = "Display";

            cartBinding.DataSource = shoppingCart;
            shoppingCartListBox.DataSource = cartBinding;

            shoppingCartListBox.DisplayMember = "Display";
            shoppingCartListBox.DisplayMember = "Display";

            vendorBinding.DataSource = store.Vendors;
            vendorListBox.DataSource = vendorBinding;

            vendorListBox.DisplayMember = "Display";
            vendorListBox.DisplayMember = "Display";

        }

        public void SetupData()
        {
            List<string> owners = new List<string>();
            string fullPath = Path.Combine(Environment.CurrentDirectory, "VendorList.txt");
            using (StreamReader sr = new StreamReader(fullPath))
            {
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine().Trim();
                    string[] lineArray = line.Split(' ');
                    Vendor tempVendor = new Vendor();
                    tempVendor.FirstName = lineArray[0];
                    tempVendor.LastName = lineArray[1];
                    owners.Add(lineArray[0] + lineArray[1]);
                    if (lineArray.Length > 2)
                    {
                        double commission = double.Parse(lineArray[2]);
                        tempVendor.Commission = commission;
                    }
                    store.Vendors.Add(tempVendor);
                }

            }
            string itemPath = Path.Combine(Environment.CurrentDirectory, "ItemList.txt");
            using (StreamReader sr = new StreamReader(itemPath))
            {
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine().Trim();
                    string[] lineArray = line.Split(',');
                    Item tempItem = new Item();
                    tempItem.Title = lineArray[0];
                    tempItem.Description = lineArray[1];
                    decimal price = decimal.Parse(lineArray[2]);
                    tempItem.Price = price;
                    store.Items.Add(tempItem);

                }
            }
            int count = 0;
            foreach (Item item in store.Items)
            {
                item.Owner = store.Vendors[count];
                count++;
            }
        }

        private void ConsignmentForm_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void addToCart_Click(object sender, EventArgs e)
        {
            Item selectedItem = (Item)itemListBox.SelectedItem;
            shoppingCart.Add(selectedItem);
            cartBinding.ResetBindings(false);

        }

        private void makePurchase_Click(object sender, EventArgs e)
        {
            foreach (Item item in shoppingCart)
            {
                item.Sold = true;
                item.Owner.PaymentDue += (decimal)item.Owner.Commission * item.Price;
                storeProfit += (1-(decimal)item.Owner.Commission) * item.Price;
            }
            shoppingCart.Clear();
            itemsBinding.DataSource = store.Items.Where(x => x.Sold == false).ToList();
            storeProfitAmount.Text = "$"+storeProfit.ToString();
            cartBinding.ResetBindings(false);
            itemsBinding.ResetBindings(false);
            vendorBinding.ResetBindings(false);
        }
    }
}
