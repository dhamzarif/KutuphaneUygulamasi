using Microsoft.EntityFrameworkCore;

namespace KutuphaneUygulamasi.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        // Mevcut Kitaplar Tablosu
        public DbSet<Book> Books { get; set; }

        // 9. HAFTA Yeni Kategoriler Tablosu
        public DbSet<Category> Categories { get; set; }

        // Veritabanı ilk oluşurken içine varsayılan verileri eklediğimiz metot
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Kategori tablosuna varsayılan 3 kaydın eklenmesi
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Roman" },
                new Category { Id = 2, Name = "Bilim" },
                new Category { Id = 3, Name = "Tarih" }
            );
        }
    }
}