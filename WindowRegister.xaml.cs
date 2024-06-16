using InternetMagazine.DBClasses;
using System;
using System.Collections.Generic;
using System.Data;
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
    public partial class WindowRegister : Window
    {
        public WindowRegister()
        {
            InitializeComponent();
            UpdateUserStatuses();
        }
        void UpdateUserStatuses()
        {
            List<string> statuses = new List<string>();
            foreach (UserStatus status in DatabaseContext.GetDB().UserStatuses)
            {
                statuses.Add(status.StatusName);
            }
            comboBoxStatus.ItemsSource = statuses;
            comboBoxStatus.SelectedIndex = 0;
        }
        private void textBoxLogin_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!e.Text.All(c => char.IsLetterOrDigit(c) && c <= 127))
            {
                e.Handled = true;
            }
        }

        private void textBoxPhoneNumber_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!e.Text.All(c => char.IsDigit(c)))
            {
                e.Handled = true;
            }
        }

        private void buttonRegistration_Click(object sender, RoutedEventArgs e)
        {
            if (comboBoxStatus.SelectedItem == null)
            {
                MessageBox.Show("No selected status");
                return;
            }
            if (textBoxLogin.Text.Length < 6)
            {
                MessageBox.Show("Minimum 6 symbols in login");
                return;
            }
            if (textBoxName.Text.Length < 6)
            {
                MessageBox.Show("Minimum 6 symbols in name");
                return;
            }
            if (passwordBoxPass.Password.Length < 6)
            {
                MessageBox.Show("Minimum 6 symbols in password");
                return;
            }
            if (textBoxPhoneNumber.Text.Length < 9)
            {
                MessageBox.Show("Enter phone number");
                return;
            }
            if (passwordBoxPass.Password != passwordBoxRepeatPass.Password)
            {
                MessageBox.Show("Password does not match");
                return;
            }
            if (DatabaseContext.GetDB().Users.FirstOrDefault(u => u.UserLogin == textBoxLogin.Text) != null)
            {
                MessageBox.Show("Login is in use");
                return;
            }
            UserStatus status = DatabaseContext.GetDB().UserStatuses.FirstOrDefault(s => s.StatusName == comboBoxStatus.SelectedItem.ToString());
            if (status != null)
            {
                DatabaseContext.GetDB().Users.Add(new MagazineUser() { UserLogin = textBoxLogin.Text, UserName = textBoxName.Text, UserPassword = passwordBoxRepeatPass.Password, PhoneNumber = textBoxPhoneNumber.Text, UserStatus = status.Id });
                DatabaseContext.GetDB().SaveChanges();
                Close();
            }
        }

    }
}
