using InternetMagazine.DBClasses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace InternetMagazine
{
    public partial class WindowClient : Window
    {
        MagazineUser thisUser;
        List<Product> products;
        List<DataGridOrder> orders;
        public WindowClient(MagazineUser user)
        {
            InitializeComponent();
            textBlockUserLogin.Text = user.UserLogin;
            textBlockUserName.Text = user.UserName;
            UserStatus status = DatabaseContext.GetDB().UserStatuses.FirstOrDefault(s => s.Id == user.UserStatus);
            if (status != null)
            {
                textBlockUserStatus.Text = status.StatusName;
            }
            thisUser = user;
            products = new List<Product>();
            orders = new List<DataGridOrder>();
            UpdateProductsList(DatabaseContext.GetDB().Products.ToList());
            UpdateOrdersList();
        }
        void UpdateProductsList(List<Product> productsSearch)
        {
            dataGridProducts.ItemsSource = null;
            products?.Clear();
            foreach (Product product in productsSearch)
            {
                ProductCategory category = DatabaseContext.GetDB().ProductCategories.FirstOrDefault(c => c.Id == product.CategoryId);
                if (category != null)
                {
                    string hasInGarbage = "no";
                    if (product.HasInGarbage)
                    {
                        hasInGarbage = "yes";
                    }
                    BitmapImage bitmap = new BitmapImage();
                    bitmap.BeginInit();
                    bitmap.StreamSource = new MemoryStream(product.ProductImage);
                    bitmap.EndInit();
                    products.Add(new DataGridProduct() { Id = product.Id, ProductName = product.ProductName, ProductDescription = product.ProductDescription, ProductPrice = product.ProductPrice, Category = category.CategoryName, HasInGarbageString = hasInGarbage, ImageBitmap = bitmap });
                }
            }
            dataGridProducts.ItemsSource = products;
        }
        void UpdateOrdersList()
        {
            dataGridOrders.ItemsSource = null;
            orders?.Clear();
            foreach (Order order in DatabaseContext.GetDB().Orders.Where(o=>o.UserId == thisUser.Id && o.CourierId != null).ToList())
            {
                MagazineUser courier = DatabaseContext.GetDB().Users.FirstOrDefault(u => u.Id == order.CourierId);
                MagazineUser client = DatabaseContext.GetDB().Users.FirstOrDefault(u => u.Id == order.UserId);
                StatusOrder status = DatabaseContext.GetDB().OrderStatuses.FirstOrDefault(s => s.Id == order.StatusId);
                Product product = DatabaseContext.GetDB().Products.FirstOrDefault(p => p.Id == order.ProductId);
                if (courier != null && client != null && status != null && product != null)
                {
                    string date = $"{order.OrderDate.Year}-{order.OrderDate.Month}-{order.OrderDate.Day}";
                    orders?.Add(new DataGridOrder() { Id = order.Id, ProductName = product.ProductName, Adress = order.Adress, Comment = order.Comment, CourierLogin = courier.UserLogin, StatusName = status.OrderStatus, UserLogin = client.UserLogin, DateString = date });
                }
                dataGridOrders.ItemsSource = orders;
            }
        }
        private void textBoxSearchProduct_TextChanged(object sender, TextChangedEventArgs e)
        {
            string sText = textBoxSearchProduct.Text;
            List<int> productCategories = DatabaseContext.GetDB().ProductCategories.Where(c=>c.CategoryName.Contains(sText)).Select(c=>c.Id).ToList();
            List<Product> productsToSearch = DatabaseContext.GetDB().Products.Where(p=>p.ProductName.Contains(sText) || p.ProductDescription.Contains(sText) ||p.ProductPrice.ToString().Contains(sText) || productCategories.Contains(p.CategoryId) || p.ProductName.Contains(sText)).ToList();
            UpdateProductsList(productsToSearch);
        }

        private void buttonOrder_Click(object sender, RoutedEventArgs e)
        {
            DataGridProduct dataGridProduct = dataGridProducts.SelectedItem as DataGridProduct;
            if(dataGridProduct != null )
            {
                if(dataGridProduct.HasInGarbageString == "no")
                {
                    MessageBox.Show("No product in garbage");
                    return;
                }
                Product product = DatabaseContext.GetDB().Products.FirstOrDefault(p=>p.Id == dataGridProduct.Id);
                if (product != null)
                {
                    WindowOrder windowOrder = new WindowOrder(thisUser, product);
                    windowOrder.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("Select a product");
            }
        }

        private void buttonUpdateList_Click(object sender, RoutedEventArgs e)
        {
            UpdateProductsList(DatabaseContext.GetDB().Products.ToList());
            UpdateOrdersList();
        }
    }
}
