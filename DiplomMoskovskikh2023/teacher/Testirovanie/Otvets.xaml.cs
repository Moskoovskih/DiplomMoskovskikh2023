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
    /// Логика взаимодействия для Otvets.xaml
    /// </summary>
    public partial class Otvets : Page
    {
        public Otvets()
        {
            InitializeComponent();
            cmb1.SelectedValuePath = "Id_темы";
            cmb1.DisplayMemberPath = "Наименование";
            cmb1.ItemsSource = AppConnect.modelOdb.Виды_Контроля.ToList();

            cmb2.SelectedValuePath = "Id_модуля";
            cmb2.DisplayMemberPath = "Наименование";
            cmb2.ItemsSource = AppConnect.modelOdb.Модули.ToList();
        }

        private void btn2_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frmMain.GoBack();
        }

        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                Вопросы orderObj = new Вопросы()
                {
                    Вопрос = txtbx.Text,
                    Виды_Контроля = cmb1.SelectedItem as Виды_Контроля,
                    Модули = cmb2.SelectedItem as Модули,
                   

                };
                AppConnect.modelOdb.Вопросы.Add(orderObj);
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

