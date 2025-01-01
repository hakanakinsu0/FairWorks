using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.DesignPatterns.GenericRepository.IntRep
{
    // IRepository arayüzü, generic bir repository tasarımı sağlar ve CRUD işlemlerini tanımlar. T parametresi, yalnızca BaseEntity'den türeyen sınıflar için kullanılabilir.
    public interface IRepository<T> where T : BaseEntity
    {
        // ************* List Commands (Listeleme Komutları) *************
        List<T> GetAll();       // Tüm verileri döndürür.
        List<T> GetActives();   // Durumu "Active" (Aktif) olan kayıtları döndürür.
        List<T> GetPassives();  // Durumu "Passive" (Pasif) olan kayıtları döndürür.
        List<T> GetModifieds(); // Durumu "Modified" (Güncellenmiş) olan kayıtları döndürür.

        T GetById(int id);      // Verilen ID'ye sahip olan tek bir kaydı döndürür.

        // ************* Modifications (Değişiklik İşlemleri) *************
        void Add(T entity);         // Yeni bir varlık ekler.
        void Update(T entity);      // Mevcut bir varlığı günceller.
        void Delete(T entity);      // Mevcut bir varlığı pasif duruma getirir (silinmiş olarak işaretler).
        string Destroy(T entity);   // Varlığı fiziksel olarak veri tabanından siler ve işlem sonucunda bir mesaj döndürür.


        // ************* Expressions (Dinamik Sorgulamalar) *************
        List<T> Where(Expression<Func<T, bool>> exp);       // Belirtilen şarta (Expression) uyan tüm kayıtları döndürür.
        bool Any(Expression<Func<T, bool>> exp);            // Belirtilen şarta uyan en az bir kayıt olup olmadığını kontrol eder.
        T FirstOrDefault(Expression<Func<T, bool>> exp);    // Belirtilen şarta uyan ilk kaydı döndürür, bulunamazsa null döner.
        object Select(Expression<Func<T, dynamic>> exp);    // Dinamik bir sorgu ile belirtilen alanların seçilmesini sağlar ve bir nesne döndürür.
        List<X> Select<X>(Expression<Func<T, X>> exp);      // Dinamik bir sorgu ile belirtilen alanların seçilmesini sağlar ve bir liste döndürür.

    }
}
