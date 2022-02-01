using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstract_Virtual_Example
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("******AbstractVirtual Example**************");
            // Database database = new Database();  YANLIŞ KULLANIM çünkü abstract ve interface olarak tanımlanan sınıflardan instance üretilemez.
            Database database = new SqlServer();
            database.Information();
            database.Add();
            database.Logger();

            Database database1 = new Oracle();
            database1.Information();
            database1.Add();
            database1.Logger();
            Console.WriteLine("******AbstractVirtual Example**************");
            Console.ReadLine();
        }
    }
    abstract class Database     //içeriğinde hem tamamlanmış hemde tamamlanmamış metot barındırabilir.
    {
        public void Information()
        {
            Console.WriteLine("Abstract example code, information by default");
            //Bilgilendirme mesajının her yerde genel bir bilgi olması durumu için yazılmıştır. Override edilemez, içeriği değiştirilemez.
        }

        public virtual void Logger()        //virtual ile içerik implement edilen classlarda aynen veya override edilerek içeriği değiştirilmiş şekilde kullanılabilir.
        {
            Console.WriteLine("Logger by default");
        }

        public abstract void Add();     //her database türü için içeriği değişebilir bir fonksiyon olduğu için abstract olarak yazıldı. Implement edilen sınıflarda override edilecek.
    }

    class SqlServer : Database
    {
        public override void Add()
        {
            Console.WriteLine("Sql Server added");
        }

        public override void Logger()       //override edilerek içerik classa uygun şekilde yapılandırıldı.
        {
            Console.WriteLine("Logger by Sql Server Database");
        }
    }

    class Oracle : Database
    {
        public override void Add()
        {
            Console.WriteLine("Oracle added");
        }

        public override void Logger()       //override edildi fakat içerik ana class daki metot değiştirilmeden kullanıldı. Override edilmeyebilinirdi sonuç aynı olurdu yani override edilme zorunluluğu yoktur.
        {
            base.Logger();
        }
    }

    /* Interface'lerde içi dolu bir fonksiyon (tamamlanmış fonksiyon) yazılamıyor. - Absractlar class ibaresi alabilir ve tamamlanmış veya tamamlanmamış fonksiyon içerebilir.
     * Abstract classlar implement edildiğinde sadece abstract fonksiyon implement edilen sınıfta kullanılabilir ve o fonksiyon override edilir. Information() override edilemez  
     * Database classında Information methodu abstract, override veya virtual ibaresi alsaydı diğer implement edilen sınıflarda override ile kullanılabilirdi.
     */
}
