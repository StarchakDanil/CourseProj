using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace КУРСАЧЧЧЧЧЧЧ
{
    public class CREATE_TABLE
    {
        public class Client
        {
            [Key]
            public int ClientId { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Patronymic { get; set; }
            public DateTime DateOfBirth { get; set; }
            public string Login { get; set; }
            public string Password { get; set; }
            public decimal Balance { get; set; }
            public List<Transaction> Transactions { get; set; } // Список транзакций клиента
            public List<ServiceResult> ServiceResults { get; set; } // Список результатов обслуживания клиента
        }

        // Класс представляющий таблицу Транзакция
        public class Transaction
        {
            [Key]
            public int TransactionId { get; set; }
            public DateTime TransactionDate { get; set; }
            public string TransactionDescription { get; set; }
            public decimal TransactionAmount { get; set; }

            [ForeignKey("Client")]
            public int ClientId { get; set; }
            public virtual Client Client { get; set; }

        }

      
     

        // Класс представляющий таблицу Результаты Клиентского обслуживания
        public class ServiceResult
        {
            [Key]
            public int ServiceResultId { get; set; }
            public DateTime ServiceDate { get; set; }
            public string Results { get; set; }
            public string Remarks { get; set; }

            [ForeignKey("Client")]
            public int ClientId { get; set; }
            public virtual Client Client { get; set; }
        }

        // Класс представляющий таблицу История обращения
        public class ServiceRequest
        {
            [Key]
            public int ServiceRequestId { get; set; }
            public DateTime RequestDate { get; set; }
            public string RequestSubject { get; set; }
            public string RequestDescription { get; set; }
            public string RequestStatus { get; set; }
        }
    }
}
