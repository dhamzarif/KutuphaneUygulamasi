using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KutuphaneUygulamasi.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Kategori adı boş geçilemez.")]
        [StringLength(50, ErrorMessage = "Kategori adı en fazla 50 karakter olabilir.")]
        public string Name { get; set; } = string.Empty;

        // Navigation Property: Bir kategorinin birden fazla kitabı olabilir
        public List<Book> Books { get; set; } = new List<Book>();
    }
}