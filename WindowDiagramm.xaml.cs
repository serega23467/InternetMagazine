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
    public partial class WindowDiagramm : Window
    {
        public enum DiagrammType
        {
            OrdersByStatus,
            MostPopularProducts,
            MostActivityClients,
            IncomeByMonths
        };
        public WindowDiagramm(DiagrammType diagrammType)
        {
            InitializeComponent();
            switch (diagrammType)
            {
                case DiagrammType.OrdersByStatus:
                    textBlockDiagrammName.Text = "Orders by status";
                    ShowOrdersByStatus();
                    break;
                case DiagrammType.MostPopularProducts:
                    textBlockDiagrammName.Text = "Popular products";
                    ShowMostPopularProducts();
                    break;
                case DiagrammType.MostActivityClients:
                    textBlockDiagrammName.Text = "Activity clients";
                    ShowMostActivityClients();
                    break;
                case DiagrammType.IncomeByMonths:
                    textBlockDiagrammName.Text = "Income by months";
                    ShowIncomeByMonths();
                    break;
            }
        }
        void ShowOrdersByStatus()
        {
            List<DataGridOrder> orders = new List<DataGridOrder>();
            foreach (Order order in DatabaseContext.GetDB().Orders.OrderBy(o=>o.StatusId))
            {
                MagazineUser courier = DatabaseContext.GetDB().Users.FirstOrDefault(u => u.Id == order.CourierId);
                MagazineUser client = DatabaseContext.GetDB().Users.FirstOrDefault(u => u.Id == order.UserId);
                StatusOrder status = DatabaseContext.GetDB().OrderStatuses.FirstOrDefault(s => s.Id == order.StatusId);
                Product product = DatabaseContext.GetDB().Products.FirstOrDefault(p => p.Id == order.ProductId);
                if (courier != null && client != null && status != null && product != null)
                {
                    string date = $"{order.OrderDate.Year}-{order.OrderDate.Month}-{order.OrderDate.Day}";
                    orders?.Add(new DataGridOrder() { Id = order.Id, ProductName = product.ProductName, Adress = order.Adress, CourierLogin = courier.UserLogin, StatusName = status.OrderStatus, UserLogin = client.UserLogin, DateString = date });
                }
            }
            listBoxOrders.ItemsSource = orders;
            listBoxOrders.Visibility = Visibility.Visible;
        }
        void ShowMostPopularProducts()
        {
            Dictionary<string, int> products = new Dictionary<string, int>();
            foreach (Order order in DatabaseContext.GetDB().Orders.OrderBy(o => o.StatusId))
            {
                Product product = DatabaseContext.GetDB().Products.FirstOrDefault(p => p.Id == order.ProductId);
                if (product != null)
                {
                    if(products.ContainsKey(product.ProductName))
                    {
                        products[product.ProductName]++;
                    }
                    else
                    {
                        products.Add(product.ProductName, 1);
                    }
                }
            }
            listBoxPopularProducts.ItemsSource = products.OrderByDescending(o => o.Value).ToList();
            listBoxPopularProducts.Visibility = Visibility.Visible;
        }
        void ShowMostActivityClients()
        {
            Dictionary<string, int> users = new Dictionary<string, int>();
            foreach (Order order in DatabaseContext.GetDB().Orders.OrderBy(o => o.StatusId))
            {
                MagazineUser user = DatabaseContext.GetDB().Users.FirstOrDefault(u => u.Id == order.UserId);
                if (user != null)
                {
                    if (users.ContainsKey(user.UserName))
                    {
                        users[user.UserName]++;
                    }
                    else
                    {
                        users.Add(user.UserName, 1);
                    }
                }
            }
            listBoxActivityClients.ItemsSource = users.OrderByDescending(o => o.Value).ToList();
            listBoxActivityClients.Visibility = Visibility.Visible;
        }
        void ShowIncomeByMonths()
        {
            Dictionary<string, double> monthsIncome = new Dictionary<string, double>();
            foreach (Order order in DatabaseContext.GetDB().Orders.OrderBy(o => o.StatusId))
            {
                Product product = DatabaseContext.GetDB().Products.FirstOrDefault(p => p.Id == order.ProductId);
                if (product != null)
                {
                    if (monthsIncome.ContainsKey(order.OrderDate.Month.ToString() + $".{order.OrderDate.Year}"))
                    {
                        monthsIncome[order.OrderDate.Month.ToString() + $".{order.OrderDate.Year}"] += product.ProductPrice;
                    }
                    else
                    {
                        monthsIncome.Add(order.OrderDate.Month.ToString() + $".{order.OrderDate.Year}", product.ProductPrice);
                    }
                }
            }
            listBoxIncomeByMonth.ItemsSource = monthsIncome;
            listBoxIncomeByMonth.Visibility = Visibility.Visible;
        }
    }
}
