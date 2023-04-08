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
    /// Логика взаимодействия для MostPage.xaml
    /// </summary>
    public partial class MostPage : Page
    {
        public MostPage()
        {
            InitializeComponent();
        }

        private void Entrance_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Наука — это организованные знания, мудрость — это организованная жизнь","Умная мысль",MessageBoxButton.OK,MessageBoxImage.Information);
           
            AppFrame.frmMain.Navigate(new MenuStudentaPage());
        }
    }
}
