using Project.DAL.ContextClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.DesignPatterns.SingletonPattern
{
    public class DbTool
    {
        // Gorev : DbTool sınıfı, uygulama genelinde kullanılan bir singleton tasarım deseni örneğidir. Bu sınıf, MyContext sınıfının bir örneğini oluşturur ve bu örneğin yalnızca bir kez oluşturulmasını garanti eder.

        DbTool() { } // Sınıfın dışarıdan yeni bir örneğinin oluşturulmasını engellemek için private bir kurucu metot tanımlanmıştır.

        static MyContext _dbInstace; // Singleton olarak kullanılacak MyContext örneği için bir private static değişken tanımlanmıştır.

        public static MyContext DbInstace // Singleton örneğine erişim sağlayan public bir static özellik tanımlanmıştır.
        {
            get
            {
                if (_dbInstace == null) _dbInstace = new MyContext(); // Eğer MyContext örneği henüz oluşturulmamışsa, yeni bir örnek oluşturulup atanır.
                return _dbInstace; // Her durumda mevcut MyContext örneği döndürülür.
            }
        }
    }
}
