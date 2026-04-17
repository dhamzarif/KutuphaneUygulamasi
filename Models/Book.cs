using System.ComponentModel.DataAnnotations;

namespace KutuphaneUygulamasi.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Başlık alanı boş geçilemez.")]
        [StringLength(100, ErrorMessage = "Başlık en fazla 100 karakter olabilir.")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Yazar alanı boş geçilemez.")]
        [StringLength(50, ErrorMessage = "Yazar adı en fazla 50 karakter olabilir.")]
        public string Author { get; set; } = string.Empty;

        [Required(ErrorMessage = "Fiyat alanı boş geçilemez.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Fiyat 0'dan büyük olmalıdır.")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Stok alanı boş geçilemez.")]
        [Range(0, int.MaxValue, ErrorMessage = "Stok 0 veya daha büyük olmalıdır.")]
        public int Stock { get; set; }
    }
}