using System;
using System.Collections.Generic;

namespace modul4lab
{
    public class lab_modul4
    {
        public class Item
        {
            public string Name { get; set; }
            public double Price { get; set; }
        }

        public class Invoice
        {
            public int Id { get; set; }
            public List<Item> Items { get; set; }
            public double TaxRate { get; set; }

            public double CalculateTotal()
            {
                double subTotal = 0;
                foreach (var item in Items)
                {
                    subTotal += item.Price;
                }
                return subTotal + (subTotal * TaxRate);
            }

            public void SaveToDatabase()
            {
                // Логика для сохранения счета-фактуры в базу данных
            }
        }

        public enum CustomerType
        {
            Regular,
            Silver,
            Gold
        }

        public class DiscountCalculator
        {
            public double CalculateDiscount(CustomerType customerType, double amount)
            {
                if (customerType == CustomerType.Regular)
                {
                    return amount;
                }
                else if (customerType == CustomerType.Silver)
                {
                    return amount * 0.9; // 10% скидка
                }
                else if (customerType == CustomerType.Gold)
                {
                    return amount * 0.8; // 20% скидка
                }
                else
                {
                    throw new ArgumentException("Неизвестный тип клиента");
                }
            }
        }

        public interface IWorker
        {
            void Work();
            void Eat();
            void Sleep();
        }

        public class HumanWorker : IWorker
        {
            public void Work()
            {
                // Логика работы
            }

            public void Eat()
            {
                // Логика питания
            }

            public void Sleep()
            {
                // Логика сна
            }
        }

        public class RobotWorker : IWorker
        {
            public void Work()
            {
                // Логика работы
            }

            public void Eat()
            {
                // Робот не ест, но вынужден реализовать метод
                throw new NotImplementedException();
            }

            public void Sleep()
            {
                // Робот не спит, но вынужден реализовать метод
                throw new NotImplementedException();
            }
        }

        public class EmailService
        {
            public void SendEmail(string message)
            {
                Console.WriteLine($"Отправка Email: {message}");
            }
        }

        public class Notification
        {
            private EmailService _emailService;

            public Notification()
            {
                _emailService = new EmailService();
            }

            public void Send(string message)
            {
                _emailService.SendEmail(message);
            }
        }

        public class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine("Program has started.");
            }
        }
    }
}

