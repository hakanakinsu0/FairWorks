using Project.CONF.Options;
using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.ContextClasses
{
    //MyContext sınıfı, Entity Framework ile veritabanı bağlantısını ve veri modeli yapılandırmalarını yöneten bir DbContext sınıfıdan miras alır. Veritabanı işlemleri (CRUD) için gerekli DbSet'leri ve yapılandırmaları içerir.
    public class MyContext:DbContext
    {
        //base ifadesi, DbContext sınıfının constructor'ına parametre geçmek için kullanılır. WindowsAuthConnection ifadesi DbContext sınıfına bağlantı dizesinin adını iletir ve Entity Framework bağlantıyı bu bilgiyle oluşturur. WindowsAuthConnection ifadesi ise WinFormUI katmanında App.config dosyası içerisinde XML olarak tanımlanan connectionStrings bağlantı dizesinin ismidir.
        public MyContext() : base("WindowsAuthConnection")
        {

        }

        //OnModelCreating metotu, Entity Framework'te model yapılandırmalarını özelleştirmek için kullanılır.Bu yöntemde, tüm entity konfigürasyon sınıfları modelBuilder.Configurations.Add() metodu ile modele eklenmiştir. Böylece her bir entity'nin yapılandırmaları merkezi bir şekilde uygulanır.
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.Add(new BuildingConfiguration());
            modelBuilder.Configurations.Add(new CustomBuildingRequestConfiguration());
            modelBuilder.Configurations.Add(new CustomerDetailConfiguration());
            modelBuilder.Configurations.Add(new EmployeeConfiguration());
            modelBuilder.Configurations.Add(new EmployeeProfileConfiguration());
            modelBuilder.Configurations.Add(new FairConfiguration());
            modelBuilder.Configurations.Add(new CustomerConfiguration());

            modelBuilder.Configurations.Add(new FairDelayConfiguration());
            modelBuilder.Configurations.Add(new FairEmployeeConfiguration());
            modelBuilder.Configurations.Add(new FairServiceConfiguration());
            modelBuilder.Configurations.Add(new FairServiceProviderConfiguration());

            modelBuilder.Configurations.Add(new LocationConfiguration());
            modelBuilder.Configurations.Add(new PaymentConfiguration());
            modelBuilder.Configurations.Add(new ServiceDescriptorConfiguration());

            modelBuilder.Configurations.Add(new ServiceProviderConfiguration());
            modelBuilder.Configurations.Add(new ServiceValueConfiguration());
            modelBuilder.Configurations.Add(new ServiceProviderServiceValueConfiguration());

        }


        //Veritabanı tablolarını temsil eden DbSet tanımlamalarıdır. Her bir DbSet, ilgili entity'nin veritabanındaki tabloya karşılık geldiğini belirtir. Bu sayede, Entity Framework kullanılarak ilgili tablolar üzerinde CRUD (Create, Read, Update, Delete) işlemleri yapılabilir.

        public DbSet<Building> Buildings { get; set; }
        public DbSet<CustomBuildingRequest> CustomBuildingRequests { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerDetail> CustomerDetails { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeProfile> EmployeeProfiles { get; set; }
        public DbSet<Fair> Fairs { get; set; }
        public DbSet<FairDelay> FairDelays { get; set; }
        public DbSet<FairEmployee> FairEmployees { get; set; }
        public DbSet<FairService> FairServices { get; set; }
        public DbSet<FairServiceProvider> FairServiceProviders { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<ServiceDescriptor> ServiceDescriptors { get; set; }
        public DbSet<ServiceProvider> ServiceProviders { get; set; }
        public DbSet<ServiceValue> ServiceValues { get; set; }
        public DbSet<ServiceProviderServiceValue> serviceProviderServiceValues { get; set; }
    }
}
