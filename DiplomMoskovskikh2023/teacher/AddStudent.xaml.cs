using DiplomMoskovskikh2023.ApplicationData;
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

namespace DiplomMoskovskikh2023.teacher
{
    /// <summary>
    /// Логика взаимодействия для AddStudent.xaml
    /// </summary>
    public partial class AddStudent : Page
    {
        private User user1 = new User();
        public AddStudent(User user)
        {
            InitializeComponent();
            role.SelectedValuePath = "id";
            role.DisplayMemberPath = "Name";
            role.ItemsSource = AppConnect.modelOdb.Role.ToList();
            if (user != null)
                user1 = user;

            DataContext = user1;
        }
        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (ClassAddEdit.Id == 1)

                {
                    User listview = new User()
                    {
                        Login = Login.Text,
                        Password = Password.Text,
                        Role = role.SelectedItem as Role,
                        Name = FIO.Text,
                        Номер_ученика = Namber_student.Text,
                        Номер_родителей = Namber_parent.Text,
                    };

                    AppConnect.modelOdb.User.Add(listview);
                    AppConnect.modelOdb.SaveChanges();
                    MessageBox.Show("Ученик успешно добавлен! ", "Уведомление ", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                AppConnect.modelOdb.SaveChanges();
                AppFrame.frmMain.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка " + ex.Message.ToString(), "Критическая ошибка! ", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void btn2_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frmMain.GoBack();
        }
    }
}
