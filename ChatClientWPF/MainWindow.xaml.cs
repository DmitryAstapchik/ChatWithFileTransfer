using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using ChatClientWPF.ServiceReference1;
using ChatClientWPF.ServiceReference2;
using System.ServiceModel;
using Microsoft.Win32;
using System.IO;

namespace ChatClientWPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IChatCallback
    {
        static InstanceContext context;
        static ChatClient proxy1;
        static readonly FileTransferClient proxy2 = new FileTransferClient();
        string name;
        Stream stream;
        public MainWindow()
        {
            InitializeComponent();
            context = new InstanceContext(this);
            proxy1 = new ChatClient(context);
        }

        public void Add(string name, bool showMessage)
        {
            ListBoxNames.Items.Add(name);
            if (showMessage)
            {
                TextBoxChat.Text += string.Format("<К нам присоединился {0}>\n", name);
            }
        }

        public void Remove(string name, bool showMessage)
        {
            ListBoxNames.Items.Remove(name);
            if (showMessage)
            {
                TextBoxChat.Text += string.Format("<Нас покинул {0}>\n", name);
            }
        }

        public void PrintMessage(string from, string message, bool isPrivate)
        {
            if (isPrivate)
            {
                TextBoxChat.Text += string.Format("<{0}>(личное): {1}\n", from, message);
            }
            else
            {
                TextBoxChat.Text += string.Format("<{0}>: {1}\n", from, message);
            }
            TextBoxMessage.Focus();
            TextBoxMessage.ScrollToEnd();
        }

        private void ButtonEnter_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(TextBoxName.Text))
            {
                if (!proxy1.GetNames().Contains(TextBoxName.Text))
                {
                    proxy1.Join(name = TextBoxName.Text);
                    ButtonEnter.IsEnabled = false;
                    ButtonLeave.IsEnabled = true;
                    ButtonSend.IsEnabled = true;
                    ButtonSendPrivate.IsEnabled = true;
                    ButtonSendFile.IsEnabled = true;
                    Title += ": " + name;
                    TextBoxName.IsReadOnly = true;
                    TextBoxMessage.Focus();
                    TextBoxMessage.ScrollToEnd();
                }
                else
                {
                    MessageBox.Show(this, "Такой никнейм уже существует.");
                    TextBoxName.Focus();
                    TextBoxName.ScrollToEnd();
                }
            }
            else
            {
                MessageBox.Show(this, "Пустой никнейм не допускается.");
            }
        }

        private void ButtonLeave_Click(object sender, RoutedEventArgs e)
        {
            proxy1.Leave(name);
            ButtonLeave.IsEnabled = false;
            ButtonEnter.IsEnabled = true;
            ButtonSend.IsEnabled = false;
            ButtonSendPrivate.IsEnabled = false;
            ButtonSendFile.IsEnabled = false;
            TextBoxChat.Clear();
            ListBoxNames.Items.Clear();
            Title = Title.Remove(3);
            TextBoxName.IsReadOnly = false;
        }

        private void ButtonSend_Click(object sender, RoutedEventArgs e)
        {
            proxy1.SendMessage(name, TextBoxMessage.Text);
            TextBoxMessage.Clear();
            TextBoxMessage.Focus();
            TextBoxMessage.ScrollToEnd();
        }

        private void ButtonSendPrivate_Click(object sender, RoutedEventArgs e)
        {
            if (ListBoxNames.SelectedItem != null)
            {
                proxy1.SendPrivateMessage(name, TextBoxMessage.Text, ListBoxNames.SelectedItem.ToString());
                TextBoxMessage.Clear();
            }
            else
            {
                MessageBox.Show(this, "Не выбран получатель.");
            }
            TextBoxMessage.Focus();
            TextBoxMessage.ScrollToEnd();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            if (name != null && ButtonLeave.IsEnabled)
            {
                proxy1.Leave(name);
            }
        }

        private void TextBoxChat_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBoxChat.ScrollToEnd();
        }

        private void ListBoxNames_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TextBoxMessage.Focus();
            TextBoxMessage.ScrollToEnd();
        }

        private void ButtonSendFile_Click(object sender, RoutedEventArgs e)
        {
            var openFileDialog = new OpenFileDialog();
            if (ListBoxNames.SelectedItem != null)
            {
                proxy1.BlockFileSending();
                if (openFileDialog.ShowDialog(this) == true)
                {
                    stream = new FileStream(openFileDialog.FileName, FileMode.Open, FileAccess.Read);
                    proxy2.ReceiveStream(stream);
                    proxy1.ReceiveNames(name, ListBoxNames.SelectedItem.ToString());
                }
            }
            else
            {
                MessageBox.Show(this, "Не выбран получатель.");
            }
        }

        public void ReceiveStream()
        {
            var saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog(this) == true)
            {
                using (var stream = new FileStream(saveFileDialog.FileName, FileMode.Create, FileAccess.Write))
                {
                    proxy2.SendStream().CopyTo(stream);
                }
                proxy1.SendAccepted();
                MessageBox.Show(this, "Скопировано.");
            }
            else
            {
                proxy1.SendRejected();
            }
            proxy1.UnblockFileSending();
        }

        public void ReceiveAccepted()
        {
            MessageBox.Show(this, "Файл доставлен.");
        }

        public void ReceiveRejected()
        {
            MessageBox.Show(this, "Собеседник не принял файл.");
        }

        public void Block()
        {
            ButtonSendFile.IsEnabled = false;
        }

        public void Unblock()
        {
            ButtonSendFile.IsEnabled = true;
        }
    }
}
