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


namespace DiplomMoskovskikh2023.student 
{
    /// <summary>
    /// Логика взаимодействия для MenuStudentaPage.xaml
    /// </summary>
    public partial class MenuStudentaPage : Page 
    {
        public MenuStudentaPage()
        {
            InitializeComponent();
        }

        private void content_Click(object sender, RoutedEventArgs e)//содержание
        {
            
            AppFrame.frmMain.Navigate(new PageContent());
        }

        private void knowledgecheck_Click(object sender, RoutedEventArgs e)//проверка знаний
        {
            AppFrame.frmMain.Navigate(new Avtorizaciya());

        }

        private void entrancetesting_Click(object sender, RoutedEventArgs e)//входное тестирование
        {
            AppFrame.frmMain.Navigate(new AvtorizaciaVhodnoe()); 
        }
       
    }

}

