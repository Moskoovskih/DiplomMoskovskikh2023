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
    /// Логика взаимодействия для AddDnenik.xaml
    /// </summary>
    public partial class AddDnenik : Page
    {
        private Дневник_Учителя дневник_Учителя1 = new Дневник_Учителя();
        public AddDnenik(Дневник_Учителя дневник_Учителя)
        {
            InitializeComponent();
            if (дневник_Учителя != null)
                дневник_Учителя1 = дневник_Учителя;

            DataContext = дневник_Учителя1;

            txbSeans.Text = DateTime.Today.ToString();
        }

        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            try     
            {
                if (ClassAddEdit.Id == 1)

                {
                    Дневник_Учителя listview = new Дневник_Учителя()
                    {
                        Дата = Convert.ToDateTime(txbSeans.SelectedDate),
                        Событие = FIO.Text,
                        
                    };

                    AppConnect.modelOdb.Дневник_Учителя.Add(listview);
                    AppConnect.modelOdb.SaveChanges();
                    MessageBox.Show("Событие успешно добавлено! ", "Уведомление ", MessageBoxButton.OK, MessageBoxImage.Information);
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
