using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;


namespace КУРСАЧЧЧЧЧЧЧ
{
    public partial class Page1 : Page
    {
        private readonly BankingDbContext _dbContext;
        private readonly string _login;
        private readonly string _password;

        public Page1(string login, string password)
        {
            InitializeComponent();
            _dbContext = new BankingDbContext();
            _login = login;
            _password = password;
        }

        private void CloseApplication_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AccountButton_Click(object sender, RoutedEventArgs e)
        {
            Account accountPage = new Account();
            NavigationService.Navigate(accountPage);
        }

        private void TransferButton_Click(object sender, RoutedEventArgs e)
        {
            decimal transferAmount;
            if (!decimal.TryParse(Summ.Text, out transferAmount))
            {
                MessageBox.Show("Пожалуйста, введите корректную сумму перевода.");
                return;
            }

            string recipientLogin = LoginPoluch.Text;

            // Поиск получателя по логину
            var recipient = _dbContext.Clients.FirstOrDefault(c => c.Login == recipientLogin);
            if (recipient == null)
            {
                MessageBox.Show("Получатель не найден.");
                return;
            }

            // Получение информации о текущем пользователе
            var currentUser = _dbContext.Clients.FirstOrDefault(c => c.Login == _login && c.Password == _password);
            if (currentUser == null)
            {
                MessageBox.Show("Ошибка при получении информации об отправителе.");
                return;
            }

            // Проверка наличия достаточного баланса у отправителя
            if (currentUser.Balance < transferAmount)
            {
                MessageBox.Show("Недостаточно средств для перевода.");
                return;
            }

            // Инициализация списка транзакций для текущего пользователя и получателя, если он не инициализирован
            if (currentUser.Transactions == null)
                currentUser.Transactions = new List<CREATE_TABLE.Transaction>();

            if (recipient.Transactions == null)
                recipient.Transactions = new List<CREATE_TABLE.Transaction>();

            // Выполнение перевода
            currentUser.Balance -= transferAmount;
            recipient.Balance += transferAmount;

            // Создание записи о транзакции у отправителя
            currentUser.Transactions.Add(new CREATE_TABLE.Transaction
            {
                TransactionDate = DateTime.Now,
                TransactionDescription = $"Перевод {transferAmount} пользователю {recipient.FirstName} {recipient.LastName}",
                TransactionAmount = -transferAmount // Указываем отрицательное значение для списания средств
            });

            // Создание записи о транзакции у получателя
            recipient.Transactions.Add(new CREATE_TABLE.Transaction
            {
                TransactionDate = DateTime.Now,
                TransactionDescription = $"Получение перевода {transferAmount} от пользователя {currentUser.FirstName} {currentUser.LastName}",
                TransactionAmount = transferAmount
            });

            // Сохранение изменений в базе данных
            _dbContext.SaveChanges();

            MessageBox.Show("Перевод выполнен успешно.");
        }
    }
}
