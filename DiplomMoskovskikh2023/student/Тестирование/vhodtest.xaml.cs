using DiplomMoskovskikh2023.ApplicationData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
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
    /// Логика взаимодействия для vhodtest.xaml
    /// </summary>
    public partial class vhodtest : Page
    {
        public int k;
        Ответы ВопросMain;
        public vhodtest()
        {
            InitializeComponent();
            cmb1.SelectedValuePath = "ID_модуля";
            cmb1.DisplayMemberPath = "Наименование";
            cmb1.ItemsSource = AppConnect.modelOdb.Модули.ToList();

            cmb2.SelectedValuePath = "Id_ответа";
            cmb2.DisplayMemberPath = "Ответ";

            //var timer = new System.Timers.Timer();
            //timer.Interval = 1000;
            //timer.Elapsed += OnTimerElapsed;
            //timer.Start();

        }
        //private void OnTimerElapsed(object sender, ElapsedEventArgs e)
        //{

        //    var timer = new System.Timers.Timer();
        //    MainWindow.counter++;
        //    lbl3.Dispatcher.Invoke(() =>
        //    {
        //        lbl3.Content = "" + MainWindow.counter + " сек";
        //    });
        //}

        private void cmb1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            sp2.Children.Clear();
            int tez = Convert.ToInt32(cmb1.SelectedValue);
           
            ВопросMain = AppConnect.modelOdb.Ответы.Where(x => x.id_модуля == tez && x.Вопросы.id_теста==1).ToArray()[new Random().Next(0, AppConnect.modelOdb.Ответы.Where(x => x.id_модуля == tez && x.Вопросы.id_теста == 1).ToList().Count)];
           
            
            tb1.Text = ВопросMain.Вопросы.Вопрос.ToString();

            cmb2.ItemsSource = AppConnect.modelOdb.Ответы.Where(x=>x.id_вопроса == ВопросMain.Вопросы.ID_вопроса).ToList();
            
        }

        private void mm_Click(object sender, RoutedEventArgs e)
        {
          var emply = AppConnect.modelOdb.Ответы.FirstOrDefault(x => x.id_верных_ответов == 1);
            
            if (emply.Ответ == cmb2.Text)
            {
                k++;
                
            }
            else
            {

                MainWindow.counter += 1;
            }

          
          
        }

        private void zaversh_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frmMain.Navigate(new RezVhodTest());
        }
    }
}
