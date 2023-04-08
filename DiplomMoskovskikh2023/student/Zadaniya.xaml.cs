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
    /// Логика взаимодействия для Zadaniya.xaml
    /// </summary>
    public partial class Zadaniya : Page
    {
        public int k;
        Ответы ВопросMain;
        public Zadaniya()
        
        {
            InitializeComponent();
            cmb1.SelectedValuePath = "ID_модуля";
            cmb1.DisplayMemberPath = "Наименование";
            cmb1.ItemsSource = AppConnect.modelOdb.Модули.ToList();



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

            ВопросMain = AppConnect.modelOdb.Ответы.Where(x => x.id_модуля == tez && x.Вопросы.id_теста == 1).ToArray()[new Random().Next(0, AppConnect.modelOdb.Ответы.Where(x => x.id_модуля == tez && x.Вопросы.id_теста == 1).ToList().Count)];


            tb1.Text = ВопросMain.Вопросы.Вопрос.ToString();


            foreach (Ответы item in AppConnect.modelOdb.Ответы.Where(x => x.id_вопроса == ВопросMain.Вопросы.ID_вопроса).ToList())
            {
                RadioButton rb = new RadioButton();
                rb.Content = item.Ответ;
                sp2.Children.Add(rb);
            }
        }

        private void mm_Click(object sender, RoutedEventArgs e)
        {


            for (int i = 0; i < sp2.Children.Count; i++)
            {

                if ((sp2.Children[i] as RadioButton).IsChecked == true)
                {
                    string strCheck = (sp2.Children[i] as RadioButton).Content.ToString();

                    int check = AppConnect.modelOdb.Ответы.Where(x => x.id_вопроса == ВопросMain.Вопросы.ID_вопроса && x.Ответ.Contains(strCheck) && x.id_верных_ответов == 1).ToList().Count;
                    if (check != 0)
                    {
                        MessageBox.Show( "Молодец! Так держать!");
                        k++;
                    }
                    else
                    {
                        MessageBox.Show( "Ошибка, попробуй еще раз!");
                        
                    }
                }

            }

        }

        private void zaversh_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frmMain.Navigate(new PageContent());
        }

    }
}
