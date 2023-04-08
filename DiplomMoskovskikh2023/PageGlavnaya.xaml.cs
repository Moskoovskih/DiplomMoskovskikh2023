using DiplomMoskovskikh2023.ApplicationData;
using DiplomMoskovskikh2023.student;
using DiplomMoskovskikh2023.teacher;
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

namespace DiplomMoskovskikh2023
{
    /// <summary>
    /// Логика взаимодействия для PageGlavnaya.xaml
    /// </summary>
    public partial class PageGlavnaya : Page
    {
        public PageGlavnaya()
        {
            InitializeComponent();
            //student.Visible = false;
            //student.FlatAppearance.MouseDownBackColor = Color.Transparent;
            
        }

        private void student_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frmMain.Navigate(new MostPage());
           
        }
        
private void student_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            //int x = e.X / (student.Width / 8);
        }

        private void teacher_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frmMain.Navigate(new Avtorizacia());
        }
    }
}
