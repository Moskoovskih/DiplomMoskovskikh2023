using DiplomMoskovskikh2023.ApplicationData;
using DiplomMoskovskikh2023.teacher;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DiplomMoskovskikh2023.student.Тестирование
{
    /// <summary>
    /// Логика взаимодействия для Avtorizaciya.xaml
    /// </summary>
    public partial class Avtorizaciya : Page
    {
        public Avtorizaciya()
        {
            InitializeComponent();
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                var userObj = AppConnect.modelOdb.User.FirstOrDefault(x =>
                x.Login == txbLogin.Text && x.Password == bPassword.Password);
                if (userObj == null)
                {
                    MessageBox.Show("Такого пользователя нет!", "Ошибка при авторизации!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else                    
                {
                    HelpClass.Id = userObj.Id;
                    switch (userObj.IdRole)
                    {
                        case 1:
                            MessageBox.Show("Добро пожаловать, " + userObj.Name + "!",
                            "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                            AppFrame.frmMain.Navigate(new VhodnoeTestir(null));
                            break;
                        case 2:
                            MessageBox.Show("Добро пожаловать, " + userObj.Name + "!",
                            "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                            AppFrame.frmMain.Navigate(new VhodnoeTestir(null));
                            break;

                        default:
                            MessageBox.Show("Данные не обнаружены!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning);
                            break;
                    }
                }
            }


            catch (Exception Ex)
            {
                MessageBox.Show("Ошибка " + Ex.Message.ToString() + "Критическая работа приложения!", "Уведомление",
                MessageBoxButton.OK, MessageBoxImage.Warning);
            }

        }
        private void IconPasswordN1_MouseDown(object sender, MouseButtonEventArgs e)
        {
            IconPasswordN1.Visibility = Visibility.Hidden;
            IconPasswordN2.Visibility = Visibility.Visible;
            PasswordTextBox.Text = bPassword.Password;
            bPassword.Visibility = Visibility.Hidden;
            PasswordTextBox.Visibility = Visibility.Visible;
        }

        private void IconPasswordN2_MouseLeave(object sender, MouseEventArgs e)
        {
            IconPasswordN2.Visibility = Visibility.Hidden;
            IconPasswordN1.Visibility = Visibility.Visible;
            bPassword.Visibility = Visibility.Visible;
            PasswordTextBox.Visibility = Visibility.Hidden;
        }

        private void IconPasswordN2_MouseDown(object sender, MouseButtonEventArgs e)
        {
            IconPasswordN2.Visibility = Visibility.Hidden;
            IconPasswordN1.Visibility = Visibility.Visible;
            bPassword.Visibility = Visibility.Visible;
            PasswordTextBox.Visibility = Visibility.Hidden;
        }
    }
}
