using DiplomMoskovskikh2023.ApplicationData;
using DiplomMoskovskikh2023.teacher.Testirovanie;
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
    /// Логика взаимодействия для VhodnoeTestir.xaml
    /// </summary>
    public partial class VhodnoeTestir : Page
    {
        public VhodnoeTestir()
        {
            InitializeComponent();
        }

        private void dobav_Click(object sender, RoutedEventArgs e)
        {
            
                         
           
            AppFrame.frmMain.Navigate(new AddVopros());
        }

        private void Nazad_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frmMain.GoBack();
        }

        private void Ydal_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frmMain.Navigate(new VoprosOtvet());
        }
    }
}
