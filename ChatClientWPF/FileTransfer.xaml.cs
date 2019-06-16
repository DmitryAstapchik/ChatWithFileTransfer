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
using System.Windows.Shapes;

namespace ChatClientWPF
{
    /// <summary>
    /// Логика взаимодействия для FileTransfer.xaml
    /// </summary>
    public partial class FileTransfer : Window
    {
        Stream stream;
        long length;
        public FileTransfer(Stream stream)
        {
            InitializeComponent();
            this.stream = stream;
            //length = stream.Length;
            Label_1.Content = string.Format("Вы получили файл от {0}.", "anonymous");
            Label_2.Content = string.Format("Размер файла {0} байт.", length);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() == true)
            {
                var fs1 = stream;
                var fs2 = new FileStream(saveFileDialog.FileName, FileMode.Create, FileAccess.Write);
                byte[] buffer = new byte[4096];
                ProgressBar_1.Maximum = length / 4096;
                Label_1.Content = "Идёт передача файла...";
                Label_2.Content = "";
                //while (fs1.Read(buffer, 0, buffer.Length) > 0)
                //{
                //    fs2.Write(buffer, 0, buffer.Length);
                //    ProgressBar_1.Value++;
                //}
                fs1.CopyTo(fs2);
                ProgressBar_1.Value = 0;
                Label_1.Content = "Скопировано.";
            }
        }
    }
}
