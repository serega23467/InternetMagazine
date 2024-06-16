using InternetMagazine.DBClasses;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Drawing;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.DirectoryServices.ActiveDirectory;

namespace InternetMagazine
{
    public partial class WindowAdmin : Window
    {
        List<DataGridUser> users;
        List<ProductCategory> categories;
        List<Product> products;
        byte[] ?imageBytes;
        public WindowAdmin(MagazineUser user)
        {
            InitializeComponent();
            users = new List<DataGridUser>();
            categories = new List<ProductCategory>();
            products = new List<Product>();

            UpdateUserStatuses();
            UpdateUsersList();
            UpdateCategoriesList();
            UpdateProductsList();

            textBlockUserLogin.Text = user.UserLogin;
            textBlockUserName.Text = user.UserName;
            UserStatus status = DatabaseContext.GetDB().UserStatuses.FirstOrDefault(s => s.Id == user.UserStatus);
            if (status != null)
            {
                textBlockUserStatus.Text = status.StatusName;
            }
            comboBoxHasInGarbage.ItemsSource = new List<string>() {"yes", "no" };
            comboBoxHasInGarbage.SelectedIndex = 0;
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
            dataGridAdminUsers.ItemsSource = null;
            users?.Clear();
            foreach(MagazineUser user in DatabaseContext.GetDB().Users)
            {
                UserStatus status = DatabaseContext.GetDB().UserStatuses.FirstOrDefault(s=>s.Id == user.UserStatus);
                if (status != null)
                {
                    users.Add(new DataGridUser() { Id=user.Id, UserName = user.UserName, UserLogin = user.UserLogin, UserPassword = user.UserPassword, PhoneNumber = user.PhoneNumber, StatusString = status.StatusName });
                }
            }
            dataGridAdminUsers.ItemsSource = users;
        }
        void UpdateCategoriesList()
        {
            dataGridCategories.ItemsSource = null;
            categories?.Clear();
            foreach(ProductCategory category in DatabaseContext.GetDB().ProductCategories)
            {
                categories.Add(new ProductCategory() { Id = category.Id, CategoryName = category.CategoryName });
            }
            dataGridCategories.ItemsSource= categories;
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
                ProductCategory category = DatabaseContext.GetDB().ProductCategories.FirstOrDefault(c=>c.Id == product.CategoryId);
                if(category != null)
                {
                    string hasInGarbage = "no";
                    if(product.HasInGarbage)
                    {
                        hasInGarbage = "yes";
                    }
                    BitmapImage bitmap = new BitmapImage();
                    bitmap.BeginInit();
                    bitmap.StreamSource = new MemoryStream(product.ProductImage);
                    bitmap.EndInit();
                    products.Add(new DataGridProduct() { Id = product.Id, ProductName = product.ProductName,ProductDescription = product.ProductDescription, ProductPrice = product.ProductPrice, Category = category.CategoryName, HasInGarbageString = hasInGarbage, ImageBitmap = bitmap});
                }
            }
            dataGridProducts.ItemsSource = products;
        }
        private void textBoxEditLogin_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!e.Text.All(c => char.IsLetterOrDigit(c) && c <= 127))
            {
                e.Handled = true;
            }
        }

        private void textBoxEditPhone_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!e.Text.All(c => char.IsDigit(c)))
            {
                e.Handled = true;
            }
        }
        private void dataGridAdminUsers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGridUser user = dataGridAdminUsers.SelectedItem as DataGridUser;
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
        private void buttonUpdateUsers_Click(object sender, RoutedEventArgs e)
        {
            UpdateUsersList();
        }
        private void buttonAddUser_Click(object sender, RoutedEventArgs e)
        {
            if (comboBoxEditStatus.SelectedItem == null)
            {
                MessageBox.Show("No selected status");
                return;
            }
            if (textBoxEditLogin.Text.Length < 6)
            {
                MessageBox.Show("Minimum 6 symbols in login");
                return;
            }
            if (textBoxEditName.Text.Length < 6)
            {
                MessageBox.Show("Minimum 6 symbols in name");
                return;
            }
            if (textBoxUserPass.Text.Length < 6)
            {
                MessageBox.Show("Minimum 6 symbols in password");
                return;
            }
            if (textBoxEditPhone.Text.Length < 9)
            {
                MessageBox.Show("Enter phone number");
                return;
            }
            if(DatabaseContext.GetDB().Users.FirstOrDefault(u => u.PhoneNumber == textBoxEditPhone.Text) != null)
            {
                MessageBox.Show("Phone is in use");
                return;
            }
            if (DatabaseContext.GetDB().Users.FirstOrDefault(u => u.UserLogin == textBoxEditLogin.Text) != null)
            {
                MessageBox.Show("Login is in use");
                return;
            }
            UserStatus status = DatabaseContext.GetDB().UserStatuses.FirstOrDefault(s => s.StatusName == comboBoxEditStatus.SelectedItem.ToString());
            if (status != null)
            {
                DatabaseContext.GetDB().Users.Add(new MagazineUser() { UserLogin = textBoxEditLogin.Text, UserName = textBoxEditName.Text, UserPassword = textBoxUserPass.Text, PhoneNumber = textBoxEditPhone.Text, UserStatus = status.Id });
                DatabaseContext.GetDB().SaveChanges();
                MessageBox.Show("Sucessfully");
                UpdateUsersList();
            }
        }

        private void buttonEditUser_Click(object sender, RoutedEventArgs e)
        {
            DataGridUser user = dataGridAdminUsers.SelectedItem as DataGridUser;
            if (user != null)
            {
                if (user.StatusString == "Admin")
                {
                    MessageBox.Show("Impossible to change a user with the admin role");
                }
                else if (user.StatusString == comboBoxEditStatus.SelectedItem.ToString() && user.UserLogin == textBoxEditLogin.Text && user.UserName == textBoxEditName.Text && user.PhoneNumber == textBoxEditPhone.Text && user.UserPassword == textBoxUserPass.Text)
                {
                    MessageBox.Show("No changes");
                }
                else
                {
                    UserStatus status = DatabaseContext.GetDB().UserStatuses.FirstOrDefault(s => s.StatusName == comboBoxEditStatus.SelectedItem.ToString());
                    if (textBoxEditName.Text.Length >= 6 && textBoxEditLogin.Text.Length >= 6 && textBoxUserPass.Text.Length >= 6 && textBoxEditPhone.Text.Length >= 9 && status != null)
                    {
                        MagazineUser userToEdit = DatabaseContext.GetDB().Users.FirstOrDefault(u => u.Id == user.Id);
                        if (userToEdit != null)
                        {
                            if(userToEdit.PhoneNumber != textBoxEditPhone.Text && DatabaseContext.GetDB().Users.FirstOrDefault(u => u.PhoneNumber == textBoxEditPhone.Text) != null)
                            {
                                MessageBox.Show("Phone is in use");
                                return;
                            }
                            if(userToEdit.UserLogin == textBoxEditLogin.Text)
                            {
                                userToEdit.UserName = textBoxEditName.Text;
                                userToEdit.PhoneNumber = textBoxEditPhone.Text;
                                userToEdit.UserStatus = status.Id;
                                userToEdit.UserPassword = textBoxUserPass.Text;

                                DatabaseContext.GetDB().SaveChanges();
                                MessageBox.Show("Successfully");
                                UpdateUsersList();

                            }
                            else if (DatabaseContext.GetDB().Users.FirstOrDefault(u => u.UserLogin == textBoxEditLogin.Text) != null)
                            {
                                MessageBox.Show("Login is in use");
                                return;
                            }
                            else
                            {
                                userToEdit.UserName = textBoxEditName.Text;
                                userToEdit.UserLogin = textBoxEditLogin.Text;
                                userToEdit.PhoneNumber = textBoxEditPhone.Text;
                                userToEdit.UserStatus = status.Id;
                                userToEdit.UserPassword = textBoxUserPass.Text;

                                DatabaseContext.GetDB().SaveChanges();
                                MessageBox.Show("Successfully");
                                UpdateUsersList();
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Login. name and password must be 6 symbols minimum, phone number 9");
                    }
                }
            }
            else
            {
                MessageBox.Show("Select a user");
            }
        }

        private void buttonDeleteUser_Click(object sender, RoutedEventArgs e)
        {
            DataGridUser user = dataGridAdminUsers.SelectedItem as DataGridUser;
            if (user != null)
            {
                if (user.StatusString == "Admin")
                {
                    MessageBox.Show("Impossible to delete a user with the admin role");
                    return;
                }
                int userId = user.Id;
                MagazineUser userToDelete = DatabaseContext.GetDB().Users.FirstOrDefault(u=>u.Id == userId);
                List<Order> ordersToDelete = DatabaseContext.GetDB().Orders.Where(o => o.UserId == userId || o.CourierId== userId).ToList();
                foreach (Order order in ordersToDelete)
                {
                    DatabaseContext.GetDB().Orders.Remove(order);
                }
                DatabaseContext.GetDB().SaveChanges();
                DatabaseContext.GetDB().Users.Remove(userToDelete);
                DatabaseContext.GetDB().SaveChanges();
                MessageBox.Show("Sucessfully");
                UpdateUsersList();
            }
        }
        private void buttonUpdateCategories_Click(object sender, RoutedEventArgs e)
        {
            UpdateCategoriesList();
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
        private void buttonAddCategory_Click(object sender, RoutedEventArgs e)
        {
            if (textBoxCategoryName.Text.Length < 6)
            {
                MessageBox.Show("Minimum 6 symbols in category");
                return;
            }
            if(DatabaseContext.GetDB().ProductCategories.FirstOrDefault(c=>c.CategoryName==textBoxCategoryName.Text) != null)
            {
                MessageBox.Show("Category is in use");
                return;
            }
            DatabaseContext.GetDB().ProductCategories.Add(new ProductCategory() { CategoryName = textBoxCategoryName.Text});
            DatabaseContext.GetDB().SaveChanges();
            MessageBox.Show("Sucessfully");
            UpdateCategoriesList();
        }

        private void buttonEditCategory_Click(object sender, RoutedEventArgs e)
        {
            ProductCategory category = dataGridCategories.SelectedItem as ProductCategory;
            if (category != null)
            {
                if (textBoxCategoryName.Text.Length < 6)
                {
                    MessageBox.Show("Minimum 6 symbols in category");
                    return;
                }
                if (textBoxCategoryName.Text == category.CategoryName)
                {
                    MessageBox.Show("No changes");
                    return;
                }
                if (DatabaseContext.GetDB().ProductCategories.FirstOrDefault(c => c.CategoryName == textBoxCategoryName.Text) != null)
                {
                    MessageBox.Show("Category is in use");
                    return;
                }
                ProductCategory categoryToEdit = DatabaseContext.GetDB().ProductCategories.FirstOrDefault(c=>c.Id == category.Id);
                if (categoryToEdit != null)
                {
                    categoryToEdit.CategoryName = textBoxCategoryName.Text;
                    DatabaseContext.GetDB().SaveChanges();
                    MessageBox.Show("Sucessfully");
                    UpdateCategoriesList();
                }
            }
            else
            {
                MessageBox.Show("Select a category");
            }
        }

        private void buttonDeleteCategory_Click(object sender, RoutedEventArgs e)
        {
            ProductCategory category = dataGridCategories.SelectedItem as ProductCategory;
            if (category != null)
            {
                ProductCategory categoryToDelete = DatabaseContext.GetDB().ProductCategories.FirstOrDefault(c => c.Id == category.Id);
                List<Product> productsToDelete = DatabaseContext.GetDB().Products.Where(p=>p.CategoryId == categoryToDelete.Id).ToList();
                if (categoryToDelete != null)
                {
                    foreach (Product product in productsToDelete)
                    {
                        DatabaseContext.GetDB().Products.Remove(product);
                    }
                    DatabaseContext.GetDB().SaveChanges();
                    DatabaseContext.GetDB().ProductCategories.Remove(categoryToDelete);
                    DatabaseContext.GetDB().SaveChanges();
                    MessageBox.Show("Sucessfully");
                    UpdateCategoriesList();
                }
            }
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
        private void buttonUpdateProducts_Click(object sender, RoutedEventArgs e)
        {
            UpdateProductsList();
        }

        private void buttonAddImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            if (openFileDialog.ShowDialog() == true)
            {
                string imagePath = openFileDialog.FileName;
                byte[] imageData;
                using (FileStream stream = new FileStream(imagePath, FileMode.Open, FileAccess.Read))
                {
                    imageData = new byte[stream.Length];
                    stream.Read(imageData, 0, (int)stream.Length);
                }
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.StreamSource = new MemoryStream(imageData);
                bitmap.EndInit();
                imageProduct.Source = bitmap;
                imageBytes = imageData;
            }
        }

        private void buttonAddProduct_Click(object sender, RoutedEventArgs e)
        {
            if(comboBoxEditCategory.SelectedItem == null)
            {
                MessageBox.Show("Add category");
                return;
            }
            if(textBoxEditProductName.Text.Length < 6)
            {
                MessageBox.Show("Minimum 6 symbols in product name");
                return;
            }
            if (textBoxEditProductDescription.Text.Length < 15)
            {
                MessageBox.Show("Minimum 15 symbols in product description");
                return;
            }
            if (DatabaseContext.GetDB().Products.FirstOrDefault(p => p.ProductName == textBoxEditProductName.Text) != null)
            {
                MessageBox.Show("Product name is in use");
                return;
            }
            if (imageProduct.Source == null && imageBytes == null)
            {
                MessageBox.Show("No image");
                return;
            }
            if (!int.TryParse(textBoxEditPrice.Text, out int price))
            {
                MessageBox.Show("Enter price");
                return;
            }
            ProductCategory category = DatabaseContext.GetDB().ProductCategories.FirstOrDefault(c => c.CategoryName == comboBoxEditCategory.SelectedItem.ToString());
            Product product = new Product();
            product.ProductName = textBoxEditProductName.Text;
            product.ProductPrice = price;
            product.ProductDescription = textBoxEditProductDescription.Text;
            bool hasProduct = false;
            if(comboBoxHasInGarbage.SelectedItem.ToString() == "yes")
            {
                hasProduct = true;
            }
            product.HasInGarbage = hasProduct;
            product.CategoryId = category.Id;
            product.ProductImage = imageBytes;

            DatabaseContext.GetDB().Products.Add(product);
            DatabaseContext.GetDB().SaveChanges();
            MessageBox.Show("Sucessfully");
            imageBytes = null;
            UpdateProductsList();

        }

        private void buttonEditProduct_Click(object sender, RoutedEventArgs e)
        {
            DataGridProduct product = dataGridProducts.SelectedItem as DataGridProduct;
            if (product != null)
            {
                Product productToEdit = DatabaseContext.GetDB().Products.FirstOrDefault(p => p.Id == product.Id);
                if(productToEdit != null)
                {
                    if (textBoxEditProductName.Text.Length < 6)
                    {
                        MessageBox.Show("Minimum 6 symbols in product name");
                        return;
                    }
                    if (textBoxEditProductDescription.Text.Length < 15)
                    {
                        MessageBox.Show("Minimum 15 symbols in product description");
                        return;
                    }
                    if (imageProduct.Source == null && imageBytes == null)
                    {
                        MessageBox.Show("No image");
                        return;
                    }
                    if (!double.TryParse(textBoxEditPrice.Text, out double price))
                    {
                        MessageBox.Show("Enter price");
                        return;
                    }
                    ProductCategory category = DatabaseContext.GetDB().ProductCategories.FirstOrDefault(c => c.CategoryName == comboBoxEditCategory.SelectedItem.ToString());
                    if (category == null)
                    {
                        MessageBox.Show("Add category");
                        return;
                    }
                    if (product.ProductName == textBoxEditProductName.Text && product.ProductDescription == textBoxEditProductDescription.Text && product.ProductPrice == price && product.HasInGarbageString == comboBoxHasInGarbage.SelectedItem.ToString() && productToEdit.ProductImage == imageBytes && product.Category == category.CategoryName)
                    {
                        MessageBox.Show("No changes");
                        return;
                    }
                    if (product.ProductName == textBoxEditProductName.Text)
                    {
                        productToEdit.ProductPrice = price;
                        productToEdit.ProductDescription = textBoxEditProductDescription.Text;
                        bool hasProduct = false;
                        if (comboBoxHasInGarbage.SelectedItem.ToString() == "yes")
                        {
                            hasProduct = true;
                        }
                        productToEdit.HasInGarbage = hasProduct;
                        productToEdit.ProductImage = imageBytes;
                        productToEdit.CategoryId = category.Id;

                        DatabaseContext.GetDB().SaveChanges();
                        MessageBox.Show("Successfully");
                        UpdateProductsList();

                    }
                    else if (product.ProductName != textBoxEditProductName.Text && DatabaseContext.GetDB().Products.FirstOrDefault(p => p.ProductName == textBoxEditProductName.Text) != null)
                    {
                        MessageBox.Show("Product name is in use");
                        return;
                    }
                    else
                    {
                        productToEdit.ProductName = textBoxEditProductName.Text;
                        productToEdit.ProductPrice = price;
                        productToEdit.ProductDescription = textBoxEditProductDescription.Text;
                        bool hasProduct = false;
                        if (comboBoxHasInGarbage.SelectedItem.ToString() == "yes")
                        {
                            hasProduct = true;
                        }
                        productToEdit.HasInGarbage = hasProduct;
                        productToEdit.ProductImage = imageBytes;
                        productToEdit.CategoryId = category.Id;

                        DatabaseContext.GetDB().SaveChanges();
                        MessageBox.Show("Successfully");
                        UpdateProductsList();
                    }
                }         

            }
            else
            {
                MessageBox.Show("Select a product");
            }
        }

        private void buttonDeleteProduct_Click(object sender, RoutedEventArgs e)
        {
            DataGridProduct product = dataGridProducts.SelectedItem as DataGridProduct;
            if (product != null)
            {
                Product productToDelete = DatabaseContext.GetDB().Products.FirstOrDefault(p => p.Id == product.Id);
                if (productToDelete != null)
                {
                    List<Order> ordersToDelete = DatabaseContext.GetDB().Orders.Where(o => o.ProductId == product.Id).ToList();
                    foreach (Order order in ordersToDelete)
                    {
                        DatabaseContext.GetDB().Orders.Remove(order);
                    }
                    DatabaseContext.GetDB().SaveChanges();
                    DatabaseContext.GetDB().Products.Remove(productToDelete);
                    DatabaseContext.GetDB().SaveChanges();
                    MessageBox.Show("Sucessfully");
                    UpdateProductsList();
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
