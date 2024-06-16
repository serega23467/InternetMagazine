using InternetMagazine.DBClasses;
using System;
using System.Collections.Generic;
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
    public partial class WindowOrder : Window
    {
        MagazineUser orderUser;
        Product orderProduct;
        public WindowOrder(MagazineUser user, Product product)
        {
            InitializeComponent();
            orderUser = user;
            orderProduct = product;
            textBlockProductName.Text = product.ProductName;
        }

        private void buttonOrder_Click(object sender, RoutedEventArgs e)
        {
            if (textBoxAdress.Text.Length < 15)
            {
                MessageBox.Show("Enter full adress");
                return;
            }
            if (textBoxProductCount.Text == "0" && textBoxProductCount.Text == string.Empty)
            {
                MessageBox.Show("Minimum 1 product");
                return;
            }
            if (int.TryParse(textBoxProductCount.Text, out int count))
            {
                StatusOrder status = DatabaseContext.GetDB().OrderStatuses.FirstOrDefault(s => s.OrderStatus == "waiting for payment");
                if(status != null)
                {
                    for (int i = 0; i < count; i++)
                    {
                        DatabaseContext.GetDB().Orders.Add(new Order() { UserId = orderUser.Id, ProductId = orderProduct.Id, Comment="",  Adress = textBoxAdress.Text, OrderDate = DateTime.Now, StatusId = status.Id });
                    }
                    DatabaseContext.GetDB().SaveChanges();
                    MessageBox.Show("Successfully");
                    this.Close();
                }
            }
        }

        private void textBoxProductCount_TextInput(object sender, TextCompositionEventArgs e)
        {
            if (!e.Text.All(c => char.IsDigit(c)))
            {
                e.Handled = true;
            }
        }
    }
}
