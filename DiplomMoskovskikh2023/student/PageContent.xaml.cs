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
    /// Логика взаимодействия для PageContent.xaml
    /// </summary>
    public partial class PageContent : Page
    {
        public PageContent()
        {
            InitializeComponent();
        }

       

        private void Ryrikov_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frmMain.Navigate(new Ryrikovich());
        }

        private void Nazad_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frmMain.GoBack();
        }

        private void Zadanie_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frmMain.Navigate(new Zadaniya());
        }
    }
}
