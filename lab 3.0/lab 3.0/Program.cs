using System;
using System.Linq;

namespace lab_3._0
{
    class Customer
    {
       
        public Customer(string name) { Name = name; }
        public Customer(string n, string m) { Name = n; LastName = m; MiddleName = "Петрович";  Address = m; CardNumber = 5896341; Balance = 31; }
        public Customer(string n, string m, int c) { Name = n; Address = m; CardNumber = c; Balance = 1; }

        public string Name
        {
            get; private set;
        }

        public string LastName
        {
            get;  set;
        }

        public string MiddleName
        {
            get;  set;
        }

        public string Address
        {
            get; set;
        }

        public int CardNumber
        {
            get; set;
        }

        public int Balance
        {
            get; set;
        }

        public override string ToString()
        {
            return string.Format("{0} {1} {2} Адрес: {3} Номер карты:{4} Баланс: {5}",
                Name, LastName, MiddleName, Address, CardNumber, Balance);
        }
    }

    class Balancesum
    {

        private static decimal minSum = 1; // минимальная допустимая сумма для всех счетов
        public static decimal MinSum
        {
            get { return minSum; }
            set { if (value > 0) minSum = value; }
        }

        public decimal Sum { get; private set; }    // сумма на счете

        // подсчет суммы на счете через определенный период по определенной ставке
        public static decimal GetSum(decimal sum, int period)
        {
            decimal result = sum;
            const decimal q = 0.3M;
            for (int i = 1; i <= period; i++)
                result = result + (result * q);
            return result;
        }
        public static decimal GetMin(decimal min, int n)
        {
            decimal res = min;
            const decimal q = 0.3M;
            for (int i = 1; i <= 1000; i++)
                res = min - (n * q);
            return res;
        }
    }
    public partial class Cust
    {
        partial void Read();
        public void DoSomething()
        {
            Read();
        }
    }
    public partial class Cust
    {
        partial void Read()
        {
            Console.WriteLine("3 Пользователь получил зачисление на счет");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Customer[] customers = new Customer[3];
           
            customers[0] = new Customer("Алксандра", "Александрович") {  MiddleName = "Александровна", Address = "ул. Александровича 51", CardNumber = 5896341, Balance = 31 };
            customers[1] = new Customer("Марк", "Марков", 1289) {LastName= "Марков", MiddleName = "Маркович",Address = "ул. Марка Шагала 81",/* CardNumber =1289,*/ Balance = 1 };
            customers[2] = new Customer("Петр") { LastName = "Петров", MiddleName = "Петрович", Address = "ул. Петровича 41", CardNumber = 5896341, Balance = 561};
           
            Console.WriteLine("База данных покупателей: ");
            foreach (Customer customer in customers)
            {
                Console.WriteLine(customer.ToString());
            }
            Cust third = new Cust(); 
            third.DoSomething();
            decimal result = Balancesum.GetSum(561, 1);
            Console.WriteLine("Обновленный баланс 3 покупателя:" + result);
            decimal res = Balancesum.GetMin(31, 30);
            Console.WriteLine("Обновленный баланс 1 покупателя:" + res);
            Console.WriteLine();
            Console.WriteLine("Пациенты с диагнозом 50000: ");
            var intNumber = customers.Where(x => x.CardNumber < 50000);
            foreach (Customer customer in intNumber)
            {
                Console.WriteLine(customer.ToString());

            }

            Console.WriteLine();
            Console.WriteLine();

            
        }
    }

    

}
