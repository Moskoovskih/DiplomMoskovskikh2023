using DiplomMoskovskikh2023.ApplicationData;
using GemBox.Document;
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
using System.Windows.Xps.Packaging;

namespace DiplomMoskovskikh2023.teacher
{
    /// <summary>
    /// Логика взаимодействия для RedSoderzh.xaml
    /// </summary>
    public partial class RedSoderzh : Page
    {
        private XpsDocument xpsDocument;
        string filename;
        public RedSoderzh()
        {
            InitializeComponent();
        }
        private void btn1_Click(object sender, RoutedEventArgs e)
        {

            var dialog = new Microsoft.Win32.OpenFileDialog();
            dialog.FileName = "Document"; // Default file name
            dialog.DefaultExt = ".Doc"; // Default file extension
            dialog.Filter = "Text documents (.Doc)|*.doc"; // Filter files by extension

            // Show open file dialog box
            bool? result = dialog.ShowDialog();

            // Process open file dialog box results
            if (result == true)
            {
                // Open document
                filename = dialog.FileName;
                Filenametext.Text = filename;
                ComponentInfo.SetLicense("FREE-LIMITED-KEY");
                string path = (filename);
                this.SetDocumentViewer(path);
            }

        }

        private void SetDocumentViewer(string path)
        {

            var document = DocumentModel.Load(path);
            this.xpsDocument = document.ConvertToXpsDocument(GemBox.Document.SaveOptions.XpsDefault);
            this.documentViewer1.Document = this.xpsDocument.GetFixedDocumentSequence();
        }


        public byte[] FileToByteArray(string _FileName)
        {
            byte[] buffer = null;
            try
            {
                // Open file for reading
                System.IO.FileStream _FileStream = new System.IO.FileStream(_FileName, System.IO.FileMode.Open, System.IO.FileAccess.Read);
                // attach filestream to binary reader
                System.IO.BinaryReader _BinaryReader = new System.IO.BinaryReader(_FileStream);
                // get total byte length of the file
                long _TotalBytes = new System.IO.FileInfo(_FileName).Length;
                // read entire file into buffer
                buffer = _BinaryReader.ReadBytes((Int32)_TotalBytes);
                // close file reader
                _FileStream.Close();
                _FileStream.Dispose();
                _BinaryReader.Close();
            }
            catch (Exception _Exception)
            {
                // Error
                Console.WriteLine("Exception caught in process: {0}", _Exception.ToString());
            }
            return buffer;
        }
        private void btn2_Click(object sender, RoutedEventArgs e)
        {
            Soderzhanie themes = new Soderzhanie()
            {
                Name = Filenametext.Text,
                Text = FileToByteArray(filename)

            };
            AppConnect.modelOdb.Soderzhanie.Add(themes);
            MessageBox.Show("Данные успешно добавлены!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
            AppConnect.modelOdb.SaveChanges();
            
        }

        
        private void btn3_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frmMain.GoBack();
        }
    }
}
