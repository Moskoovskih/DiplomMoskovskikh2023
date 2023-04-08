using DiplomMoskovskikh2023.ApplicationData;
using Microsoft.Office.Interop.Excel;
using Microsoft.Win32;
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
    /// Логика взаимодействия для Student.xaml
    /// </summary>
    public partial class Student : System.Windows.Controls.Page
    {
        public Student()
        {
            InitializeComponent();
            students.ItemsSource = AppConnect.modelOdb.User.Where(x=>x.IdRole==2).ToList();
            var count_col = students.Items.Count; 
            ttb3.Text = count_col.ToString();

           
        }

        private void Dobavlenie_Click(object sender, RoutedEventArgs e)
        {
            ClassAddEdit.Id = 1;
            AppFrame.frmMain.Navigate(new AddStudent(null));
        }

        private void Ydalenie_Click(object sender, RoutedEventArgs e)
        {
            if (students.SelectedItems.Count > 0)
            {

                for (int i = 0; i < students.SelectedItems.Count; i++)
                {
                    User studentObj = students.SelectedItems[i] as User;
                    AppConnect.modelOdb.User.Remove(studentObj);
                }
                AppConnect.modelOdb.SaveChanges();
                MessageBox.Show("Ученик успешно удален!", "Уведмление", MessageBoxButton.OK, MessageBoxImage.Information);

            }
            else
            {
                MessageBox.Show("В таблице нет данных!", "Уведомдение", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

       
        public void Filtracia()
        {
            var SerachList = AppConnect.modelOdb.User.ToList();     
            if (nameStudent.Text != "")
            {
                SerachList = SerachList.Where(x => x.Name.ToLower().Contains(nameStudent.Text.ToLower())).ToList();
            }

            students.ItemsSource = SerachList.ToList();

        }

        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frmMain.Navigate(new Student());

            var count_col = students.Items.Count;
            ttb1.Text = count_col.ToString();//счетчик данных
        }

      

      
        private void btn2_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frmMain.Navigate(new MenuTeacher());
        }

        private void nameStudent_TextChanged(object sender, TextChangedEventArgs e)
        {
            var SerachList = AppConnect.modelOdb.User.ToList();

            if (nameStudent.Text != "")
            {
                SerachList = SerachList.Where(x => x.Name.ToLower().Contains(nameStudent.Text.ToLower())).ToList();
            }

            students.ItemsSource = SerachList.ToList();
            ttb1.Text = students.Items.Count.ToString(); 
        }

        private void RedYch_Click(object sender, RoutedEventArgs e)
        {
            ClassAddEdit.Id = 2;
            AppFrame.frmMain.Navigate(new AddStudent((sender as System.Windows.Controls.Button).DataContext as User));
        }

        private void Excel_Click(object sender, RoutedEventArgs e)
        {
           
                var Spisok = AppConnect.modelOdb.User.Where(x => x.IdRole == 2).ToList();
                var application = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook workbook = application.Workbooks.Add(Type.Missing);
            Microsoft.Office.Interop.Excel.Worksheet worksheet = application.Worksheets.Item[1];
                int RowIndex = 3;
            Microsoft.Office.Interop.Excel.Range header = worksheet.Range[worksheet.Cells[1, 1], worksheet.Cells[2, 3]];
                header.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                header.Font.Bold = true;
                worksheet.Cells[2][1] = "Ученики";
                worksheet.Cells[5][2] = "Дата и время отчета";
                worksheet.Cells[6][2] = DateTime.Now;
                worksheet.Cells[1][3] = "ФИО";
                worksheet.Cells[2][3] = "Логин";
                worksheet.Cells[3][3] = "Пароль";
                worksheet.Cells[4][3] = "Номер ученика";
                worksheet.Cells[5][3] = "Номер Родителя";
                
                for (int i = 0; i < Spisok.Count(); i++)
                {
                    RowIndex++;
                    worksheet.Cells[1][RowIndex] = Spisok[i].Name;
                    int g = Spisok[i].IdRole;
                                   
                    worksheet.Cells[2][RowIndex] = Spisok[i].Login;
                    worksheet.Cells[3][RowIndex] = Spisok[i].Password;
                    worksheet.Cells[4][RowIndex] = Spisok[i].Номер_ученика;
                    worksheet.Cells[5][RowIndex] = Spisok[i].Номер_родителей;
                    
                    application.Visible = true;
                }
            }

        private void Pechat_Click(object sender, RoutedEventArgs e)
        {
            PrintDialog printObj = new PrintDialog();
            if (printObj.ShowDialog() == true)
            {
                
                printObj.PrintVisual(students, "");
                

            }
            else
            {
                MessageBox.Show("Пользователь прервал печать! ");
            }
        }

        private void Import_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
               
                string a = openFileDialog.FileName;
                //Create COM Objects.
                Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();


                if (excelApp == null)
                {
                    Console.WriteLine("Excel is not installed!!");
                    return;
                }

                Workbook excelBook = excelApp.Workbooks.Open(a);
                _Worksheet excelSheet = excelBook.Sheets[1];
                Range excelRange = excelSheet.UsedRange;

                int rows = excelRange.Rows.Count;
                int cols = excelRange.Columns.Count;

                for (int i = 2; i <= rows; i++)
                {
                    //create new line
                   
                  

                        //write the console
                       
                            User user = new User()
                            {
                                Name = excelRange.Cells[i, 1].Value2.ToString(),
                                IdRole = 2,
                                Номер_ученика = excelRange.Cells[i, 2].Value2.ToString(),
                                Номер_родителей = excelRange.Cells[i, 3].Value2.ToString(),
                                Login = excelRange.Cells[i, 4].Value2.ToString(),
                                Password = excelRange.Cells[i, 5].Value2.ToString(),
                            };
                    AppConnect.modelOdb.User.Add(user);
                    AppConnect.modelOdb.SaveChanges();
                    students.ItemsSource = AppConnect.modelOdb.User.Where(x => x.IdRole == 2).ToList();



                }
                excelBook.Close();

            }
        }
    }
}
