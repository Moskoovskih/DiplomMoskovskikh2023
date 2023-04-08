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
    /// Логика взаимодействия для RedactorRez.xaml
    /// </summary>
    public partial class RedactorRez : Page
    {
        private РезультатыТеста rezult1 = new РезультатыТеста();
        public RedactorRez(РезультатыТеста rez)
        {
            InitializeComponent();
            Studet.SelectedValuePath = "Id";
            Studet.DisplayMemberPath = "Name";
            Studet.ItemsSource = AppConnect.modelOdb.User.Where(x => x.IdRole == 2).ToList();
            Tests.SelectedValuePath = "Id_темы";
            Tests.DisplayMemberPath = "Наименование";
            Tests.ItemsSource = AppConnect.modelOdb.Виды_Контроля.ToList();

            if (rez != null)
                rezult1 = rez;

            DataContext = rezult1;
        }

        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (ClassAddEdit.Id == 2)

                {
                    РезультатыТеста res = new РезультатыТеста()
                    {
                        User = Studet.SelectedItem as User,
                        Виды_Контроля = Tests.SelectedItem as Виды_Контроля,
                        КоличествоНеверных = Convert.ToInt32( FIO.Text),
                        КоличествоВсехВопросов = Convert.ToInt32(Namber_student.Text),
                        

                    };

                    AppConnect.modelOdb.РезультатыТеста.Add(res);
                    AppConnect.modelOdb.SaveChanges();
                    MessageBox.Show("Результат успешно обновлен! ", "Уведомление ", MessageBoxButton.OK, MessageBoxImage.Information);
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
