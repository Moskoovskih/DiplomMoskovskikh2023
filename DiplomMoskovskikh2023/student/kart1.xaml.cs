using DiplomMoskovskikh2023.ApplicationData;
using GemBox.Document;

using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace DiplomMoskovskikh2023.student
{
    /// <summary>
    /// Логика взаимодействия для kart1.xaml
    /// </summary>
    public partial class kart1 : Page
    {
        private XpsDocument xpsDocument;
        
        public kart1()
        {
            InitializeComponent();
            listview.ItemsSource = AppConnect.modelOdb.Soderzhanie.ToList(); 
        }

        private void StackPanel_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            byte[] fileBytes = ((sender as StackPanel).DataContext as Soderzhanie ).Text;

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Файл Word (* .doc) | * .doc";

            string saveFileName = "Test.doc";
            int arraysize = new int();
            arraysize = fileBytes.GetUpperBound(0);
            FileStream fs = new FileStream(saveFileName, FileMode.OpenOrCreate, FileAccess.Write);

            fs.Write(fileBytes, 0, arraysize);
            fs.Close();
            ComponentInfo.SetLicense("FREE-LIMITED-KEY");
            string path = (saveFileName);
            this.SetDocumentViewer(path);
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

        private void Nazad_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frmMain.GoBack();
        }
    }
    }

