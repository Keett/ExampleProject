using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceExample
{
    /* Loglama işlemleri Database, File ve Sms türlerinde implement edildiğinde farklı işlemler gerektirdiği için interface olarak ILogger yazıldı. 
   * Fakat Database ile File Logger aynı işlemler gerektirseydi sadece SMS de değişseydi o zaman virtual kullanılıp değişen yerleri override edilebilirdi.
   * Veya hepsinde aynı işlemler gerektiren ama değişebilecek türde fonksiyonlar da barındıran sistem olsaydı o zaman abstract kullanılmalıydı.
   */

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("******Interface Example**************");
            CustomerManager customerManager = new CustomerManager();
            customerManager.CustomerLogger = new SmsLogger();
            customerManager.Add();
            Console.WriteLine("******Interface Example**************");
            Console.ReadLine();
        }
    }
    class CustomerManager
    {
        public ILogger CustomerLogger { get; set; }        //Normalde bu işlem constructor ile yapılır. property ile değil.
        public void Add()
        {
            Console.WriteLine("Customer Added");
            CustomerLogger.Log();
        }
    }

    class DatabaseLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("Logged to database");
        }
    }

    class FileLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("Logged to file");
        }
    }

    class SmsLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("Logged to SMS");
        }
    }

    interface ILogger
    {
        void Log();
    }

  
}
