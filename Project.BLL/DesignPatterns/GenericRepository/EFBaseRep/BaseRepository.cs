using Project.BLL.DesignPatterns.GenericRepository.IntRep;
using Project.BLL.DesignPatterns.SingletonPattern;
using Project.DAL.ContextClasses;
using Project.ENTITIES.Enums;
using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.DesignPatterns.GenericRepository.EFBaseRep
{
    //Görevi : Bu sınıf, Entity Framework (EF) ile generic repository desenini uygulamaktadır. Bu yapı sayesinde, her bir entity için CRUD (Create, Read, Update, Delete) işlemleri tekrar tekrar yazılmak yerine ortak bir altyapı ile yönetilmektedir.

    //T tipi, BaseEntity sınıfından türeyen bir sınıf olmalıdır. (where T : BaseEntity) Bu sınıf, IRepository<T> arayüzünü uygular ve standart CRUD işlemlerini sağlar.
    public abstract class BaseRepository<T> : IRepository<T> where T : BaseEntity // T tipi, BaseEntity sınıfından türeyen bir sınıf olmalıdır.
    {
        MyContext _db; // Entity Framework veritabanı sınıfından oluşturulan field.

        public BaseRepository()
        {
            _db = DbTool.DbInstace; // Singleton tasarım deseni ile tek bir MyContext örneği alınır.
        }

        public void Add(T entity)
        {
            _db.Set<T>().Add(entity); // EF kullanarak yeni bir kayıt eklenir.
            Save(); // Değişiklikler veritabanına kaydedilir.
        }

        private void Save()
        {
            _db.SaveChanges(); // EF'nin değişiklikleri veritabanına işlemesi sağlanır.
        }

        public bool Any(Expression<Func<T, bool>> exp)
        {
            return _db.Set<T>().Any(exp); // Verilen şartı sağlayan herhangi bir kayıt olup olmadığını kontrol eder.
        }

        public void Delete(T entity)
        {
            entity.DeletedDate = DateTime.Now; // Silinen kayıt için silinme tarihi atanır.
            entity.Status = DataStatus.Deleted; // Kayıt durumu silindi (Deleted) olarak güncellenir.
            Save(); // Değişiklikler kaydedilir.
        }

        public string Destroy(T entity)
        {
            if (entity.Status != DataStatus.Deleted) return "Öncelikle yok etmek istediğiniz veriyi pasife çekiniz."; // Fiziksel silme işlemi, kayıt pasife çekilmeden yapılamaz.
            _db.Set<T>().Remove(entity);    // EF kullanılarak kayıt fiziksel olarak silinir.
            Save();                         // Değişiklikler kaydedilir.
            return "Veri yok edilmiştir.";  // Silme işlemi başarılı bir şekilde tamamlanır.
        }

        public T FirstOrDefault(Expression<Func<T, bool>> exp)
        {
            return _db.Set<T>().FirstOrDefault(exp); // Verilen şartı sağlayan ilk kaydı döndürür. Yoksa null döner.
        }

        public List<T> GetActives()
        {
            return Where(x => x.Status != DataStatus.Deleted); // Silinmemiş (aktif) kayıtları getirir.
        }

        public List<T> GetAll()
        {
            return _db.Set<T>().ToList(); // Tablodaki tüm kayıtları liste olarak döndürür.
        }

        public T GetById(int id)
        {
            return _db.Set<T>().Find(id); // Belirtilen ID'ye sahip kaydı döndürür.
        }

        public List<T> GetModifieds()
        {
            return Where(x => x.Status == DataStatus.Updated); // Durumu "Güncellenmiş" (Updated) olan kayıtları döndürür.
        }

        public List<T> GetPassives()
        {
            return Where(x => x.Status == DataStatus.Deleted); // Durumu "Silinmiş" (Deleted) olan kayıtları döndürür.
        }

        public object Select(Expression<Func<T, dynamic>> exp)
        {
            return _db.Set<T>().Select(exp); // Dinamik bir şartla belirtilen alanları seçer ve bir nesne döndürür.
        }

        public List<X> Select<X>(Expression<Func<T, X>> exp)
        {
            return _db.Set<T>().Select(exp).ToList(); // Dinamik bir şartla belirtilen alanlardan bir liste döndürür.
        }

        public void Update(T entity)
        {
            T originalEntity = GetById(entity.Id);  // Güncellenecek kaydı ID üzerinden bulur.
            entity.ModifiedDate = DateTime.Now;     // Güncelleme tarihi atanır.
            entity.Status = DataStatus.Updated;     // Kayıt durumu "Güncellenmiş" (Updated) olarak ayarlanır.

            _db.Entry(originalEntity).CurrentValues.SetValues(entity); // Güncellenen entity'nin yeni değerleri, mevcut kayıt üzerine yazılır.
            Save(); // Değişiklikler kaydedilir.
        }

        public List<T> Where(Expression<Func<T, bool>> exp)
        {
            return _db.Set<T>().Where(exp).ToList(); // Verilen şartı sağlayan kayıtları döndürür.
        }

    }
}
