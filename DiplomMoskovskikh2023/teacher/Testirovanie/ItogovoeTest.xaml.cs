using DiplomMoskovskikh2023.ApplicationData;
using DiplomMoskovskikh2023.student.Тестирование;
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

namespace DiplomMoskovskikh2023.teacher.Testirovanie
{
    /// <summary>
    /// Логика взаимодействия для ItogovoeTest.xaml
    /// </summary>
    public partial class ItogovoeTest : Page
    {
        public ItogovoeTest()
        {
            InitializeComponent();
        }

        private void Itogovoe_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frmMain.Navigate(new ItgTest());
        }

        private void Nazad_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frmMain.GoBack();
        }

        private void Vhodnoe_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frmMain.Navigate(new VhodnoeTestir());
        }
    }
}
