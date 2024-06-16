using InternetMagazine.DBClasses;
using System.Data;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace InternetMagazine
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void buttonLogin_Click(object sender, RoutedEventArgs e)
        {
            string login = textBoxLogin.Text;
            string password = passwordBoxPass.Password;
            MagazineUser user = DatabaseContext.GetDB().Users.FirstOrDefault(u => u.UserLogin== login && u.UserPassword== password);
            if (user != null)
            {
                UserStatus status = DatabaseContext.GetDB().UserStatuses.FirstOrDefault(s => s.Id == user.UserStatus);
                if (status != null)
                {
                    switch (status.StatusName)
                    {
                        case "Admin":
                            WindowAdmin windowAdmin = new WindowAdmin(user);
                            windowAdmin.ShowDialog();
                            break;
                        case "Manager":
                            WindowManager windowManager = new WindowManager(user);
                            windowManager.ShowDialog();
                            break;
                        case "Operator":
                            WindowOperator windowOperator = new WindowOperator(user);
                            windowOperator.ShowDialog();
                            break;
                        case "User":
                            WindowClient windowClient = new WindowClient(user);
                            windowClient.ShowDialog();
                            break;
                    }
                }
            }
            else
            {
                MessageBox.Show("Wrong login or password");
            }
        }

        private void buttonRegister_Click(object sender, RoutedEventArgs e)
        {
            WindowRegister window = new WindowRegister();
            window.ShowDialog();
        }
    }
}