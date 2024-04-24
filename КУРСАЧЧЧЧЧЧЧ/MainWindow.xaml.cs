using Microsoft.EntityFrameworkCore;
using System.Text;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private readonly BankingDbContext _dbContext;
        public MainWindow()
        {
            InitializeComponent();

            _dbContext = new BankingDbContext();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Page1 page1 = new Page1();
            this.Content = page1;
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            // Получение логина и пароля из текстовых полей
            string login = loginTextBox.Text;
            string password = PasswordTextBox.Text;


            var client = _dbContext.Clients.FirstOrDefault(c => c.Login == login && c.Password == password);


            if (client != null)
            {

                Page1 page1 = new Page1();
                this.Content = page1;
                page1.Balance.Text = client.Balance.ToString();
                string formattedBalance = FormatBalance(client.Balance);
                page1.Balance.Text = formattedBalance;
            }
            else
            {

                MessageBox.Show("Неверный логин или пароль. Попробуйте еще раз.");
            }

        }
        private string FormatBalance(decimal balance)
        {
            // Получение тысяч, рублей и копеек
            int thousands = (int)(balance / 1000);
            int rubles = (int)(balance % 1000);
            int kopecks = (int)((balance - Math.Truncate(balance)) * 100);

            // Форматирование строки
            string formattedBalance = $"{thousands} {rubles},{kopecks}";
            return formattedBalance;


        }
    }

}
