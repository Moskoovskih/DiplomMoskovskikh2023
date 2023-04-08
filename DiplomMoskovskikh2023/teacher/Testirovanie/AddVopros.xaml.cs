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

namespace DiplomMoskovskikh2023.teacher.Testirovanie
{
    /// <summary>
    /// Логика взаимодействия для AddVopros.xaml
    /// </summary>
    public partial class AddVopros : Page
    {
        
        public AddVopros()
        {
            InitializeComponent();
            cmb1.SelectedValuePath="ID_вопроса";
            cmb1.DisplayMemberPath = "Вопрос";
            cmb1.ItemsSource = AppConnect.modelOdb.Вопросы.ToList();

            cmb3.SelectedValuePath = "Id_ответа";
            cmb3.DisplayMemberPath = "Наименование";
            cmb3.ItemsSource = AppConnect.modelOdb.Правильные_неправильные_ответы.ToList();
           
        }

        private void btn3_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frmMain.Navigate(new Otvets());
        }

        private void btn2_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frmMain.GoBack();
        }

        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                Ответы orderObj = new Ответы()
                {
                    Ответ = txtbx.Text,
                    Вопросы = cmb1.SelectedItem as Вопросы,
                    Правильные_неправильные_ответы = cmb3.SelectedItem as Правильные_неправильные_ответы,
                    id_верных_ответов = 1,

                };
                AppConnect.modelOdb.Ответы.Add(orderObj);
                MessageBox.Show("Данные успешно добавлены!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);

                AppConnect.modelOdb.SaveChanges();  
                AppFrame.frmMain.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
