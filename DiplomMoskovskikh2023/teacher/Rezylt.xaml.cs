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
    /// Логика взаимодействия для Rezylt.xaml
    /// </summary>
    public partial class Rezylt : Page
    {
        public Rezylt()
        {
            InitializeComponent();
            rez.ItemsSource = AppConnect.modelOdb.РезультатыТеста.ToList();

            CMB_test.SelectedValuePath = "ID_темы";
            CMB_test.DisplayMemberPath = "Наименование";
            CMB_test.ItemsSource = AppConnect.modelOdb.Виды_Контроля.ToList();
            var count_col = rez.Items.Count;
            ttb3.Text = count_col.ToString();
        }

        private void Nazad_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frmMain.Navigate(new MenuTeacher());
        }

        private void Redrez_Click(object sender, RoutedEventArgs e)
        {
            ClassAddEdit.Id = 2;
            AppFrame.frmMain.Navigate(new RedactorRez((sender as Button).DataContext as РезультатыТеста));
        }

        private void Pechat_Click(object sender, RoutedEventArgs e)
        {
            PrintDialog printObj = new PrintDialog();
            if (printObj.ShowDialog() == true)
            {
                
                printObj.PrintVisual(rez, "");


            }
            else
            {
                MessageBox.Show("Пользователь прервал печать! ");
            }
        }

        public void Filtracia()
        {
            var SerachList = AppConnect.modelOdb.РезультатыТеста.ToList();
            if (nameStudent.Text != "")
            {
                SerachList = SerachList.Where(x => x.User.Name.ToLower().Contains(nameStudent.Text.ToLower())).ToList();
            }

            rez.ItemsSource = SerachList.ToList();

        }
        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frmMain.Navigate(new Rezylt());

            var count_col = rez.Items.Count;
            ttb1.Text = count_col.ToString();//счетчик данных
        }

        private void CMB_test_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int number = Convert.ToInt32(CMB_test.SelectedValue);
            Filtracia();


            var count_col = rez.Items.Count;
            ttb1.Text = count_col.ToString();
        }
        private void nameStudent_TextChanged(object sender, TextChangedEventArgs e)
        {
            var SerachList = AppConnect.modelOdb.РезультатыТеста.ToList();

            if (nameStudent.Text != "")
            {
                SerachList = SerachList.Where(x => x.User.Name.ToLower().Contains(nameStudent.Text.ToLower())).ToList();
            }

            rez.ItemsSource = SerachList.ToList();
            ttb1.Text = rez.Items.Count.ToString();
        }

        private void Excel_Click(object sender, RoutedEventArgs e)
        {
            var Spisok = AppConnect.modelOdb.РезультатыТеста.ToList();
            var application = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook workbook = application.Workbooks.Add(Type.Missing);
            Microsoft.Office.Interop.Excel.Worksheet worksheet = application.Worksheets.Item[1];
            int RowIndex = 3;
            Microsoft.Office.Interop.Excel.Range header = worksheet.Range[worksheet.Cells[1, 1], worksheet.Cells[2, 3]];
            header.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            header.Font.Bold = true;
            worksheet.Cells[2][1] = "Результаты тестирования";
            worksheet.Cells[5][2] = "Дата и время отчета";
            worksheet.Cells[6][2] = DateTime.Now;
            worksheet.Cells[1][3] = "ФИО";
            worksheet.Cells[2][3] = "Тема";
            worksheet.Cells[3][3] = "Количество неверных";
            worksheet.Cells[4][3] = "Количество всего вопросов";
            worksheet.Cells[5][3] = "Дата";

            for (int i = 0; i < Spisok.Count(); i++)
            {
                RowIndex++;
                worksheet.Cells[1][RowIndex] = Spisok[i].User.Name;
               

                worksheet.Cells[2][RowIndex] = Spisok[i].Виды_Контроля.Наименование;
                worksheet.Cells[3][RowIndex] = Spisok[i].КоличествоНеверных;
                worksheet.Cells[4][RowIndex] = Spisok[i].КоличествоВсехВопросов;
                worksheet.Cells[5][RowIndex] = Spisok[i].Дата;

                application.Visible = true;
            }
        }
    }
}
