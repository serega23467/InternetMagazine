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
    public partial class WindowManager : Window
    {
        List<DataGridUser> users;
        List<ProductCategory> categories;
        List<Product> products;
        List<DataGridOrder> orders;
        byte[]? imageBytes;
        public WindowManager(MagazineUser user)
        {
            InitializeComponent();
            users = new List<DataGridUser>();
            categories = new List<ProductCategory>();
            products = new List<Product>();
            orders = new List<DataGridOrder>();

            UpdateUserStatuses();
            UpdateUsersList();
            UpdateCategoriesList();
            UpdateProductsList();
            UpdateOrdersList();

            textBlockUserLogin.Text = user.UserLogin;
            textBlockUserName.Text = user.UserName;
            UserStatus status = DatabaseContext.GetDB().UserStatuses.FirstOrDefault(s => s.Id == user.UserStatus);
            if (status != null)
            {
                textBlockUserStatus.Text = status.StatusName;
            }
            comboBoxHasInGarbage.ItemsSource = new List<string>() { "yes", "no" };
            comboBoxHasInGarbage.SelectedIndex = 0;

            comboBoxOrderStatus.ItemsSource = new List<string>() { "waiting for payment", "paid", "in processing", "sent", "delivered" };
            comboBoxOrderStatus.SelectedIndex = 0;
        }
        void UpdateUserStatuses()
        {
            List<string> statuses = new List<string>();
            foreach (UserStatus status in DatabaseContext.GetDB().UserStatuses)
            {
                statuses.Add(status.StatusName);
            }
            comboBoxEditStatus.ItemsSource = statuses;
            comboBoxEditStatus.SelectedIndex = 0;
        }
        void UpdateUsersList()
        {
            dataGridUsers.ItemsSource = null;
            users?.Clear();
            foreach (MagazineUser user in DatabaseContext.GetDB().Users)
            {
                UserStatus status = DatabaseContext.GetDB().UserStatuses.FirstOrDefault(s => s.Id == user.UserStatus);
                if (status != null)
                {
                    users.Add(new DataGridUser() { Id = user.Id, UserName = user.UserName, UserLogin = user.UserLogin, UserPassword = user.UserPassword, PhoneNumber = user.PhoneNumber, StatusString = status.StatusName });
                }
            }
            dataGridUsers.ItemsSource = users;
        }
        void UpdateCategoriesList()
        {
            dataGridCategories.ItemsSource = null;
            categories?.Clear();
            foreach (ProductCategory category in DatabaseContext.GetDB().ProductCategories)
            {
                categories.Add(new ProductCategory() { Id = category.Id, CategoryName = category.CategoryName });
            }
            dataGridCategories.ItemsSource = categories;
            UpdateProductsList();
        }
        void UpdateProductsList()
        {
            List<string> categories = new List<string>();
            foreach (ProductCategory category in DatabaseContext.GetDB().ProductCategories)
            {
                categories.Add(category.CategoryName);
            }
            comboBoxEditCategory.ItemsSource = categories;

            dataGridProducts.ItemsSource = null;
            products?.Clear();
            foreach (Product product in DatabaseContext.GetDB().Products)
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
            foreach (Order order in DatabaseContext.GetDB().Orders)
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
        private void buttonUpdateUsers_Click(object sender, RoutedEventArgs e)
        {
            UpdateUsersList();
        }

        private void buttonUpdateCategories_Click(object sender, RoutedEventArgs e)
        {
            UpdateCategoriesList();
        }

        private void buttonUpdateProducts_Click(object sender, RoutedEventArgs e)
        {
            UpdateProductsList();
        }

        private void dataGridProducts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGridProduct product = dataGridProducts.SelectedItem as DataGridProduct;
            if (product != null)
            {
                textBlockProductId.Text = product.Id.ToString();
                imageProduct.Source = product.ImageBitmap;
                Product selectedProduct = DatabaseContext.GetDB().Products.FirstOrDefault(p => p.Id == product.Id);
                if (selectedProduct != null)
                {
                    imageBytes = selectedProduct.ProductImage;
                }
                textBoxEditProductName.Text = product.ProductName;
                textBoxEditProductDescription.Text = product.ProductDescription;
                textBoxEditPrice.Text = product.ProductPrice.ToString();
                comboBoxHasInGarbage.SelectedItem = product.HasInGarbageString;
                comboBoxEditCategory.SelectedItem = product.Category;
            }
        }

        private void dataGridCategories_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ProductCategory category = dataGridCategories.SelectedItem as ProductCategory;
            if (category != null)
            {
                textBlockCategoryId.Text = category.Id.ToString();
                textBoxCategoryName.Text = category.CategoryName;
            }
        }

        private void dataGridUsers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGridUser user = dataGridUsers.SelectedItem as DataGridUser;
            if (user != null)
            {
                textBlockUserId.Text = user.Id.ToString();
                textBoxEditLogin.Text = user.UserLogin;
                textBoxEditName.Text = user.UserName;
                textBoxEditPhone.Text = user.PhoneNumber;
                comboBoxEditStatus.SelectedValue = user.StatusString;
                if (user.StatusString != "Admin")
                {
                    textBoxUserPass.Text = user.UserPassword;
                }
                else
                {
                    textBoxUserPass.Text = string.Empty;
                }
            }
        }

        private void dataGridOrders_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGridOrder order = dataGridOrders.SelectedItem as DataGridOrder;
            if (order != null)
            {
                textBlockOrderId.Text = order.Id.ToString();
                comboBoxOrderStatus.SelectedItem = order.StatusName;
            }
        }

        private void buttonEditOrderStatus_Click(object sender, RoutedEventArgs e)
        {
            if(comboBoxOrderStatus.SelectedItem == null)
            {
                MessageBox.Show("No statuses");
                return;
            }
            DataGridOrder order = dataGridOrders.SelectedItem as DataGridOrder;
            if (order != null)
            {
                if (comboBoxOrderStatus.SelectedItem.ToString() == order.StatusName)
                {
                    MessageBox.Show("No changes");
                    return;
                }
                Order orderToEdit = DatabaseContext.GetDB().Orders.FirstOrDefault(o=>o.Id == order.Id);
                StatusOrder status = DatabaseContext.GetDB().OrderStatuses.FirstOrDefault(s=>s.OrderStatus == comboBoxOrderStatus.SelectedItem.ToString());
                if (orderToEdit != null && status != null)
                {
                    orderToEdit.StatusId = status.Id;
                    DatabaseContext.GetDB().SaveChanges();
                    MessageBox.Show("Sucessfully");
                    UpdateOrdersList();
                }
            }
        }

        private void buttonListOrdersByStatus_Click(object sender, RoutedEventArgs e)
        {
            WindowDiagramm window = new WindowDiagramm(WindowDiagramm.DiagrammType.OrdersByStatus);
            window.ShowDialog();
        }

        private void buttonListMostPopularProducts_Click(object sender, RoutedEventArgs e)
        {
            WindowDiagramm window = new WindowDiagramm(WindowDiagramm.DiagrammType.MostPopularProducts);
            window.ShowDialog();
        }

        private void buttonListActivityClients_Click(object sender, RoutedEventArgs e)
        {
            WindowDiagramm window = new WindowDiagramm(WindowDiagramm.DiagrammType.MostActivityClients);
            window.ShowDialog();
        }

        private void buttonListIncomeByMonths_Click(object sender, RoutedEventArgs e)
        {
            WindowDiagramm window = new WindowDiagramm(WindowDiagramm.DiagrammType.IncomeByMonths);
            window.ShowDialog();
        }
    }
}
