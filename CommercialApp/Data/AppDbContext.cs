using CommercialApp.Models;
using Microsoft.EntityFrameworkCore;

namespace CommercialApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Bilgisayar" },
                new Category { Id = 2, Name = "Telefon" },
                new Category { Id = 3, Name = "Mobilya" },
                new Category { Id = 4, Name = "Beyaz Eşya" },
                new Category { Id = 5, Name = "Mutfak" }
            );

            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, 
                    Name = "Asus UltraBook", 
                    Brand = "Asus", 
                    BuyingPrice = 1000, 
                    SellingPrice = 1500, 
                    CategoryId = 1, 
                    Image = "img", 
                    Stock = 100, 
                    State = true },

                new Product
                {
                    Id = 2,
                    Name = "Iphone 13",
                    Brand = "Apple",
                    BuyingPrice = 10030,
                    SellingPrice = 12500,
                    CategoryId = 2,
                    Image = "img",
                    Stock = 100,
                    State = true
                },

                new Product
                {
                    Id = 3,
                    Name = "Salon Takımı",
                    Brand = "IKEA",
                    BuyingPrice = 500,
                    SellingPrice = 700,
                    CategoryId = 3,
                    Image = "img",
                    Stock = 100,
                    State = true
                },
                new Product
                {
                    Id = 4,
                    Name = "Kombi",
                    Brand = "Alarko",
                    BuyingPrice = 1000,
                    SellingPrice = 2500,
                    CategoryId = 4,
                    Image = "img",
                    Stock = 100,
                    State = true
                },
                new Product
                {
                    Id = 5,
                    Name = "Çırpıcı",
                    Brand = "Siemens",
                    BuyingPrice = 10000,
                    SellingPrice = 15000,
                    CategoryId = 5,
                    Image = "img",
                    Stock = 100,
                    State = true
                }
                );

            modelBuilder.Entity<Department>().HasData(
                new Department {
                    Id = 1,
                    Name = "Yönetim",
                    State = true },
                new Department
                {
                    Id = 2,
                    Name = "Muhasebe",
                    State = true
                },
                new Department
                {
                    Id = 3,
                    Name = "Reklam",
                    State = true
                },
                new Department
                {
                    Id = 4,
                    Name = "Ticaret",
                    State = true
                }
                );

            modelBuilder.Entity<Employee>().HasData(
                new Employee
                {
                    Id = 1,
                    Name = "Emre",
                    Surname = "Alpay",
                    Image = "img",
                    DepartmentId = 1,
                },
                new Employee
                {
                    Id = 2,
                    Name = "Elif",
                    Surname = "Su",
                    Image = "img",
                    DepartmentId = 2,
                },
                new Employee
                {
                    Id = 3,
                    Name = "Cenk",
                    Surname = "Cem",
                    Image = "img",
                    DepartmentId = 3,
                },
                new Employee
                {
                    Id = 4,
                    Name = "Buse",
                    Surname = "Gül",
                    Image = "img",
                    DepartmentId = 4,
                }
                );

            modelBuilder.Entity<CustomerAccount>().HasData(
                new CustomerAccount
                {
                    Id = 1,
                    Name = "Merve",
                    Surname = "Sönmez",
                    City = "Amasya",
                    Email = "mail"
                },
                new CustomerAccount
                {
                    Id = 2,
                    Name = "Tuğba",
                    Surname = "Erman",
                    City = "Kütahya",
                    Email = "mail"
                },
                new CustomerAccount
                {
                    Id = 3,
                    Name = "Erkan",
                    Surname = "Cenk",
                    City = "Ankara",
                    Email = "mail"
                }
                );

        }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CustomerAccount> CustomerAccounts { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceItem> InvoiceItems { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<SaleTransaction> SaleTransactions { get; set; }
        
    }
}
