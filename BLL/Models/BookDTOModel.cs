namespace BLL.Models
{
    public class BookDTOModel
    {
        public int Id { get; set; }
        public string? ISBN { get; set; }
        public string? Title { get; set; }
        public GenreDTOModel? Genre { get; set; }
        public string? Description { get; set; } 
        public AuthorDTOModel? Author { get; set; } 
    }
}
