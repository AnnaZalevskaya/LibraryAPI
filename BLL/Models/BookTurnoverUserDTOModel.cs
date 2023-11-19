namespace BLL.Models
{
    public class BookTurnoverUserDTOModel
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public int? BookId { get; set; }
        public Boolean IsTaken { get; set; }
    }
}
