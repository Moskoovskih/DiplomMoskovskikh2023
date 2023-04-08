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
    /// Логика взаимодействия для MenuTeacher.xaml
    /// </summary>
    public partial class MenuTeacher : Page
    {
        public MenuTeacher()
        {
            InitializeComponent();
        }

        private void student_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frmMain.Navigate(new Student());
        }

        private void test9_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frmMain.Navigate(new ItogovoeTest());
        }

        private void dnevnik_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frmMain.Navigate(new Dnevnik()); 
        }

        private void Rezylt_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frmMain.Navigate(new Rezylt());
        }

        private void Soderzhanie_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frmMain.Navigate(new soderzh());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
