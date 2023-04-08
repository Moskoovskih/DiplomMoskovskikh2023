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
    /// Логика взаимодействия для soderzh.xaml
    /// </summary>
    public partial class soderzh : Page
    {
        public soderzh()
        {
            InitializeComponent();
        }

        private void textdox_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frmMain.Navigate(new RedSoderzh());
        }
    }
}
