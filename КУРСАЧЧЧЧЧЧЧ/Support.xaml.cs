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

namespace КУРСАЧЧЧЧЧЧЧ
{
    /// <summary>
    /// Логика взаимодействия для Support.xaml
    /// </summary>
    public partial class Support : Page
    {
        public Support()
        {
            InitializeComponent();
        }

        private void Jope_Click(object sender, RoutedEventArgs e)
        {
            string messageText = MSB.Text; // Получаем текст из TextBox

            ContentControl bubble = new ContentControl
            {
                Content = new TextBlock { Text = messageText },  // Создаем TextBlock с текстом сообщения
                Style = (Style)Resources["BubbleRightStyle"] // Используем стиль для правого пузырька
            };

            ChatMessages.Children.Add(bubble); // Добавляем пузырек с сообщением в чат
        }
    }
}
