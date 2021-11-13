using System.ComponentModel.DataAnnotations;

namespace BookStoreApi.Models
{
    public class BookModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please add title property")]
        [MinLength(3)]
        public string Title { get; set; }
        public string Description { get; set; }
    }
}