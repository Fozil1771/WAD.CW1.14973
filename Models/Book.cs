using System.ComponentModel.DataAnnotations;

namespace LibraryAPI.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public Genre? Genre { get;set; }
        public string? Publisher { get; set; }
        public double? Rating { get; set; }
        public DateTime? ReleaseDate { get; set; }

        // One-to-many relation with author
        public int? AuthorId { get; set; }
        public Author? Author { get; set; }
    }
}
