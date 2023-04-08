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

namespace DiplomMoskovskikh2023
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static double counter = 0;
        public static int error = 0;
        public MainWindow()
        {
            InitializeComponent();
            AppFrame.frmMain = FrmMain;
            AppConnect.modelOdb = new Диплом_Катя1();
            FrmMain.Navigate(new PageGlavnaya());
        }
    }
}
