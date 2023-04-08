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
    /// Логика взаимодействия для Dnevnik.xaml
    /// </summary>
    public partial class Dnevnik : Page
    {
        
        public Dnevnik()
        {
            InitializeComponent();
            dnevnik.ItemsSource = AppConnect.modelOdb.Дневник_Учителя.ToList();
        }

        private void Nazad_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frmMain.GoBack();
        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            if (dnevnik.SelectedItems.Count > 0)
            {

                for (int i = 0; i < dnevnik.SelectedItems.Count; i++)
                {
                   Дневник_Учителя studentObj = dnevnik.SelectedItems[i] as Дневник_Учителя;
                    AppConnect.modelOdb.Дневник_Учителя.Remove(studentObj);
                }
                AppConnect.modelOdb.SaveChanges();
                MessageBox.Show("Событие успешно удалено!", "Уведмление", MessageBoxButton.OK, MessageBoxImage.Information);

            }
            else
            {
                MessageBox.Show("В таблице нет данных!", "Уведомдение", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Dobavlenie_Click(object sender, RoutedEventArgs e)
        {
            ClassAddEdit.Id = 1;
            AppFrame.frmMain.Navigate(new AddDnenik(null));
        }

        private void RedDnevnik_Click(object sender, RoutedEventArgs e)
        {
            ClassAddEdit.Id = 2;
            AppFrame.frmMain.Navigate(new AddDnenik((sender as Button).DataContext as Дневник_Учителя));
        }

        private void Pechat_Click(object sender, RoutedEventArgs e)
        {
            PrintDialog printObj = new PrintDialog();
            if (printObj.ShowDialog() == true)
            {

                printObj.PrintVisual(dnevnik, "");


            }
            else
            {
                MessageBox.Show("Пользователь прервал печать! ");
            }
        }
    }
}
