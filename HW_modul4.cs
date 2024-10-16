using System;
using System.Linq;

namespace modul4
{
    public class HW_modul4
    {
        public class Order
        {
            public string ProductName { get; set; }
            public int Quantity { get; set; }
            public double Price { get; set; }

            public double CalculateTotalPrice()
            {
                return Quantity * Price * 0.9;
            }

            public void ProcessPayment(string paymentDetails)
            {
                Console.WriteLine("Payment processed using: " + paymentDetails);
            }

            public void SendConfirmationEmail(string email)
            {
                Console.WriteLine("Confirmation email sent to: " + email);
            }
        }

        public class Employee
        {
            public string Name { get; set; }
            public double BaseSalary { get; set; }
            public string EmployeeType { get; set; } // "Permanent", "Contract", "Intern"
        }

        public class EmployeeSalaryCalculator
        {
            public double CalculateSalary(Employee employee)
            {
                if (employee.EmployeeType == "Permanent")
                {
                    return employee.BaseSalary * 1.2; // Permanent employee gets 20% bonus
                }
                else if (employee.EmployeeType == "Contract")
                {
                    return employee.BaseSalary * 1.1; // Contract employee gets 10% bonus
                }
                else if (employee.EmployeeType == "Intern")
                {
                    return employee.BaseSalary * 0.8; // Intern gets 80% of the base salary
                }
                else
                {
                    throw new NotSupportedException("Employee type not supported");
                }
            }
        }

        public interface IPrinter
        {
            void Print(string content);
            void Scan(string content);
            void Fax(string content);
        }

        public class AllInOnePrinter : IPrinter
        {
            public void Print(string content)
            {
                Console.WriteLine("Printing: " + content);
            }

            public void Scan(string content)
            {
                Console.WriteLine("Scanning: " + content);
            }

            public void Fax(string content)
            {
                Console.WriteLine("Faxing: " + content);
            }
        }

        public class BasicPrinter : IPrinter
        {
            public void Print(string content)
            {
                Console.WriteLine("Printing: " + content);
            }

            public void Scan(string content)
            {
                throw new NotImplementedException();
            }

            public void Fax(string content)
            {
                throw new NotImplementedException();
            }
        }

        public class EmailSender
        {
            public void SendEmail(string message)
            {
                Console.WriteLine("Email sent: " + message);
            }
        }

        public class SmsSender
        {
            public void SendSms(string message)
            {
                Console.WriteLine("SMS sent: " + message);
            }
        }

        public class NotificationService
        {
            private EmailSender emailSender = new EmailSender();
            private SmsSender smsSender = new SmsSender();

            public void SendNotification(string message)
            {
                emailSender.SendEmail(message);
                smsSender.SendSms(message);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Program has started.");
        }
    }
}

