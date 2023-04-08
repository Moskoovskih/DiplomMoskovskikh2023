using DiplomMoskovskikh2023.ApplicationData;
using DiplomMoskovskikh2023.teacher.Testirovanie;
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
    /// Логика взаимодействия для ItgTest.xaml
    /// </summary>
    public partial class ItgTest : Page

    {
        public int k;
        public ItgTest()
        {
            InitializeComponent();
            var TestAdd = AppConnect.modelOdb.User.FirstOrDefault(x => x.Id == HelpClass.Id);
            if (TestAdd.IdRole == 1)
            {
                Teacher.Visibility = Visibility.Visible;
                btn1.Visibility = Visibility.Hidden;
                sp3.Visibility = Visibility.Hidden;
            }

            if (TestAdd.IdRole == 2)
            {
                Teacher.Visibility = Visibility.Hidden;
                btn1.Visibility = Visibility.Visible;
                sp3.Visibility = Visibility.Visible;
            }



            var timer = new System.Timers.Timer();
            timer.Interval = 1000;
            timer.Elapsed += OnTimerElapsed;
            timer.Start();
        }
        private void OnTimerElapsed(object sender, ElapsedEventArgs e)
        {

            var timer = new System.Timers.Timer();
            MainWindow.counter++;
            lbl3.Dispatcher.Invoke(() =>
            {
                lbl3.Content = "" + MainWindow.counter + " сек";
            });
        }
        private void Dobavlenie_Click(object sender, RoutedEventArgs e)
        {
            var TestAdd = AppConnect.modelOdb.User.FirstOrDefault(x => x.Id == HelpClass.Id);
            if (TestAdd.IdRole == 1)
            {
                txb1.IsEnabled = true;
                txt2.IsEnabled = true;
                txt3.IsEnabled = true;
                txt4.IsEnabled = true;
                txt5.IsEnabled = true;
                txt6.IsEnabled = true;
                txt7.IsEnabled = true;
                txt8.IsEnabled = true;
                txt9.IsEnabled = true;
                txt10.IsEnabled = true;
                txt11.IsEnabled = true;
                txt12.IsEnabled = true;
                txt13.IsEnabled = true;
                txt14.IsEnabled = true;
                txt15.IsEnabled = true;
                txt16.IsEnabled = true;
                txt17.IsEnabled = true;
                txt18.IsEnabled = true;
                txt19.IsEnabled = true;
                txt20.IsEnabled = true;
                txt21.IsEnabled = true;
                txt22.IsEnabled = true;
                txt23.IsEnabled = true;
                txt24.IsEnabled = true;
                txt25.IsEnabled = true;
                txt26.IsEnabled = true;
                txt27.IsEnabled = true;
                txt28.IsEnabled = true;
                txt29.IsEnabled = true;
                txt30.IsEnabled = true;
                txt31.IsEnabled = true;
                txt32.IsEnabled = true;
                txt33.IsEnabled = true;
                txt34.IsEnabled = true;
                txt36.IsEnabled = true;
                txt37.IsEnabled = true;
                txt38.IsEnabled = true;
                txt39.IsEnabled = true;
                txt40.IsEnabled = true;
                txt41.IsEnabled = true;
                txt42.IsEnabled = true;
                txt43.IsEnabled = true;
                txt44.IsEnabled = true;
                txt45.IsEnabled = true;
                txt46.IsEnabled = true;
                txt47.IsEnabled = true;
                txt48.IsEnabled = true;
                txt49.IsEnabled = true;
                txt50.IsEnabled = true;
                txt51.IsEnabled = true;
                txt52.IsEnabled = true;


                txb33.IsEnabled = true;
                txb34.IsEnabled = true;
                txb35.IsEnabled = true;
                txb36.IsEnabled = true;
                txb37.IsEnabled = true;
                txb38.IsEnabled = true;
                txb39.IsEnabled = true;
                txb40.IsEnabled = true;
                txb41.IsEnabled = true;
                txb42.IsEnabled = true;
                txb43.IsEnabled = true;
                txb44.IsEnabled = true;

            }
        }

        private void Pechat_Click(object sender, RoutedEventArgs e)
        {
            PrintDialog printObj = new PrintDialog();
            if (printObj.ShowDialog() == true)
            {
                Teacher.Visibility = Visibility.Hidden;
                btn1.Visibility = Visibility.Hidden;
                sp3.Visibility = Visibility.Hidden;
                printObj.PrintVisual(stackpechat, "");


            }
            else
            {
                MessageBox.Show("Пользователь прервал печать! ");
            }
        }

        private void Otvet1_TextChanged(object sender, TextChangedEventArgs e)
        {



            var emply = AppConnect.modelOdb.Ответы.FirstOrDefault(x => x.id_верных_ответов == 1 && x.id_вопроса == 1);
            if (emply.Ответ == Otvet1.Text)
            {
                k++;

            }
            else
            {

                MainWindow.error += 1;
            }


        }

        private void Otvet2_TextChanged(object sender, TextChangedEventArgs e)
        {
            var emply = AppConnect.modelOdb.Ответы.FirstOrDefault(x => x.id_верных_ответов == 1 && x.id_вопроса == 3);
            if (emply.Ответ == Otvet2.Text)
            {
                k++;

            }
            else
            {

                MainWindow.error += 1;
            }
        }

        private void Otvet_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frmMain.Navigate(new AddVopros());
        }

        private void Otvet3_TextChanged(object sender, TextChangedEventArgs e)
        {
            var emply = AppConnect.modelOdb.Ответы.FirstOrDefault(x => x.id_верных_ответов == 1 && x.id_вопроса == 19);
            if (emply.Ответ == Otvet3.Text)
            {
                k++;

            }
            else
            {

                MainWindow.error += 1;
            }
        }

        private void Otvet4_TextChanged(object sender, TextChangedEventArgs e)
        {
            var emply = AppConnect.modelOdb.Ответы.FirstOrDefault(x => x.id_верных_ответов == 1 && x.id_вопроса == 20);
            if (emply.Ответ == Otvet4.Text)
            {
                k++;

            }
            else
            {

                MainWindow.error += 1;
            }
        }

        private void Otvet5_TextChanged(object sender, TextChangedEventArgs e)
        {
            var emply = AppConnect.modelOdb.Ответы.FirstOrDefault(x => x.id_верных_ответов == 1 && x.id_вопроса == 21);
            if (emply.Ответ == Otvet5.Text)
            {
                k++;

            }
            else
            {

                MainWindow.error += 1;
            }
        }

        private void Otvet6_TextChanged(object sender, TextChangedEventArgs e)
        {
            var emply = AppConnect.modelOdb.Ответы.FirstOrDefault(x => x.id_верных_ответов == 1 && x.id_вопроса == 23);
            if (emply.Ответ == Otvet6.Text)
            {
                k++;

            }
            else
            {

                MainWindow.error += 1;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            StringBuilder errors = new StringBuilder();

            if (string.IsNullOrWhiteSpace(Otvet1.Text))
            {

                errors.Append("Заполните задание 1 ");
            }
            if (string.IsNullOrWhiteSpace(Otvet2.Text))
            {

                errors.Append("Заполните задание 2 ");
            }
            if (string.IsNullOrWhiteSpace(Otvet3.Text))
            {

                errors.Append("Заполните задание 3  ");
            }
            if (string.IsNullOrWhiteSpace(Otvet4.Text))
            {

                errors.Append("Заполните задание 4  ");
            }
            if (string.IsNullOrWhiteSpace(Otvet5.Text))
            {

                errors.Append("Заполните задание 5  ");
            }
            if (string.IsNullOrWhiteSpace(Otvet6.Text))
            {

                errors.Append("Заполните задание 6  ");
            }

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            try
            {
                AppFrame.frmMain.Navigate(new PageRezItogovTest());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }



        }

        private void Otvet1_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {


            if (!Char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
            }

        }

        private void Otvet2_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
            }
        }

        private void Otvet3_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
            }
        }

        private void Otvet4_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
            }
        }

        private void Otvet5_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
            }
        }

        private void Otvet6_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
            }
        }
    }
}
