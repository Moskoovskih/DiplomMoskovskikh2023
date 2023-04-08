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

namespace DiplomMoskovskikh2023.student
{
    /// <summary>
    /// Логика взаимодействия для Ryrikovich.xaml
    /// </summary>
    public partial class Ryrikovich : Page
    {
        public Ryrikovich()
        {
            InitializeComponent();
            Date1.ItemsSource = AppConnect.modelOdb.Даты.ToList();
            Termins.ItemsSource = AppConnect.modelOdb.Термины.ToList();


            //var TestAdd = AppConnect.modelOdb.User.FirstOrDefault(x => x.Id == HelpClass.Id);
            //if (TestAdd.IdRole == 2)
            //{
            //    Teacher.Visibility = Visibility.Visible;
               
            //}

            //if (TestAdd.IdRole == 2)
            //{
            //    Teacher.Visibility = Visibility.Hidden;
                
            //}
        }

        private void Nazad_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frmMain.GoBack();
        }

        private void Date_Click(object sender, RoutedEventArgs e)
        {
            sp2.Visibility = Visibility.Hidden;
            sp1.Visibility = Visibility.Visible;
            Date1.ItemsSource = AppConnect.modelOdb.Даты.Where(x => x.id_модули == 2).ToList();

        }

        private void nameProduct_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void lichnosti_Click(object sender, RoutedEventArgs e)
        {
            Date1.Visibility = Visibility.Visible;
           
        }

        private void Terminy_Click(object sender, RoutedEventArgs e)
        {
            sp1.Visibility = Visibility.Hidden;
            sp2.Visibility = Visibility.Visible;
            
            Termins.ItemsSource = AppConnect.modelOdb.Термины.Where(x => x.ID_Модуля == 2).ToList();
        }

        private void Karty_Click(object sender, RoutedEventArgs e)
        {
            sp1.Visibility = Visibility.Hidden;
            sp2.Visibility = Visibility.Hidden;
            AppFrame.frmMain.Navigate(new kart1());
        }

        private void Kyltyra_Click(object sender, RoutedEventArgs e)
        {
            sp1.Visibility = Visibility.Hidden;
            sp2.Visibility = Visibility.Hidden;
            AppFrame.frmMain.Navigate(new kart1());
        }

        private void Citaty_Click(object sender, RoutedEventArgs e)
        {
            sp1.Visibility = Visibility.Hidden;
            sp2.Visibility = Visibility.Hidden;
            AppFrame.frmMain.Navigate(new kart1());
        }

        private void Argyments_Click(object sender, RoutedEventArgs e)
        {
            sp1.Visibility = Visibility.Hidden;
            sp2.Visibility = Visibility.Hidden;
            AppFrame.frmMain.Navigate(new kart1());
        }

        private void Karty_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void RedSoder_Click(object sender, RoutedEventArgs e)
        {

        }

        private void PechatSoder_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Del_Click(object sender, RoutedEventArgs e)
        {

        }

        private void dobav_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Kyltyra_Click_1(object sender, RoutedEventArgs e)
        {
            AppFrame.frmMain.Navigate(new kart1());
        }
    }
}
