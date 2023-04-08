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

namespace DiplomMoskovskikh2023.student.Тестирование
{
    /// <summary>
    /// Логика взаимодействия для RezVhodTest.xaml
    /// </summary>
    public partial class RezVhodTest : Page
    {
        public RezVhodTest()
        {
            InitializeComponent();
            text1.Text = "" + MainWindow.counter;
            text2.Text = "" + MainWindow.error;
        }
        private void Vbd_Click(object sender, RoutedEventArgs e)
        {
            РезультатыТеста rez = new РезультатыТеста()
            {
                Id_Ученика = HelpClass.Id,
                id_темы = 1,
                КоличествоНеверных = Convert.ToInt32(text2.Text),
                КоличествоВсехВопросов = 4,
                Дата = DateTime.Now,

            };

            AppConnect.modelOdb.РезультатыТеста.Add(rez);
            AppConnect.modelOdb.SaveChanges();
            AppFrame.frmMain.Navigate(new MenuStudentaPage());

        }
    }
}
