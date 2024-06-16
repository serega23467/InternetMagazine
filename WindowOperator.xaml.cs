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
    public partial class WindowOperator : Window
    {
        MagazineUser thisUser;
        List<DataGridOrder> orders;
        public WindowOperator(MagazineUser user)
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
            orders = new List<DataGridOrder>();
            comboBoxOrderStatus.ItemsSource = new List<string>() { "waiting for payment", "paid", "in processing", "sent", "delivered" };
            comboBoxOrderStatus.SelectedIndex = 0;
            UpdateOrdersList();
        }
        void UpdateOrdersList()
        {
            dataGridOrders.ItemsSource = null;
            orders?.Clear();
            foreach (Order order in DatabaseContext.GetDB().Orders.Where(o=>o.CourierId == thisUser.Id || o.CourierId == null).ToList())
            {
                MagazineUser courier = DatabaseContext.GetDB().Users.FirstOrDefault(u => u.Id == order.CourierId);
                MagazineUser client = DatabaseContext.GetDB().Users.FirstOrDefault(u => u.Id == order.UserId);
                StatusOrder status = DatabaseContext.GetDB().OrderStatuses.FirstOrDefault(s => s.Id == order.StatusId);
                Product product = DatabaseContext.GetDB().Products.FirstOrDefault(p => p.Id == order.ProductId);
                if (client != null && status != null && product != null)
                {
                    string date = $"{order.OrderDate.Year}-{order.OrderDate.Month}-{order.OrderDate.Day}";
                    if(courier == null)
                    {
                        orders.Add(new DataGridOrder() { Id = order.Id, ProductName = product.ProductName, Adress = order.Adress, Comment = order.Comment, StatusName = status.OrderStatus, CourierLogin="no", UserLogin = client.UserLogin, DateString = date });
                    }
                    else
                    {
                        orders.Add(new DataGridOrder() { Id = order.Id, ProductName = product.ProductName, Adress = order.Adress, Comment = order.Comment, CourierLogin = courier.UserLogin, StatusName = status.OrderStatus, UserLogin = client.UserLogin, DateString = date });
                    }
                }
            }
            dataGridOrders.ItemsSource = orders;    
        }
        private void dataGridOrders_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGridOrder order = dataGridOrders.SelectedItem as DataGridOrder;
            if (order != null)
            {
                textBlockOrderId.Text = order.Id.ToString();
                textBoxOrderComment.Text = order.Comment;
                comboBoxOrderStatus.SelectedItem = order.StatusName;
            }
        }

        private void buttonAcceptOrder_Click(object sender, RoutedEventArgs e)
        {
            DataGridOrder order = dataGridOrders.SelectedItem as DataGridOrder;
            if (order != null)
            {
                Order orderToEdit = DatabaseContext.GetDB().Orders.FirstOrDefault(o => o.Id == order.Id);
                if (orderToEdit != null )
                {
                    if(orderToEdit.CourierId != null)
                    {
                        MessageBox.Show("Order already accepted");
                        return;
                    }
                    orderToEdit.CourierId = thisUser.Id;
                    DatabaseContext.GetDB().SaveChanges();
                    MessageBox.Show("Sucessfully");
                    UpdateOrdersList();
                }
            }
        }
        private void buttonAddComment_Click(object sender, RoutedEventArgs e)
        {
            DataGridOrder order = dataGridOrders.SelectedItem as DataGridOrder;
            if (order != null)
            {
                Order orderToEdit = DatabaseContext.GetDB().Orders.FirstOrDefault(o => o.Id == order.Id);
                if (orderToEdit != null)
                {
                    if (comboBoxOrderStatus.SelectedItem == null)
                    {
                        return;
                    }
                    if (orderToEdit.CourierId == null)
                    {
                        MessageBox.Show("Accept order for comment");
                    }
                    else if (orderToEdit.CourierId == thisUser.Id)
                    {
                        StatusOrder status = DatabaseContext.GetDB().OrderStatuses.FirstOrDefault(s => s.OrderStatus == comboBoxOrderStatus.SelectedItem.ToString());
                        if (status == null)
                        {
                            return;
                        }
                        if (textBoxOrderComment.Text == order.Comment && comboBoxOrderStatus.SelectedItem == order.StatusName)
                        {
                            MessageBox.Show("No changes");
                            return;
                        }
                        if (orderToEdit != null)
                        {
                            orderToEdit.Comment = textBoxOrderComment.Text;
                            orderToEdit.StatusId = status.Id;
                            DatabaseContext.GetDB().SaveChanges();
                            MessageBox.Show("Sucessfully");
                            UpdateOrdersList();
                        }
                    }
                }              
            }
            else
            {
                MessageBox.Show("Select order");
            }
        }

        private void buttonUpdateList_Click(object sender, RoutedEventArgs e)
        {
            UpdateOrdersList();
        }
    }
}
