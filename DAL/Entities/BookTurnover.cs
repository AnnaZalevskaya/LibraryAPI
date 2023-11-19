namespace DAL.Entities
{
    public class BookTurnover
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int BookId { get; set; }
        public Book? Book { get; set; }
        public DateTime TakenTime { get; set; }
        public DateTime ReturnedTime { get; set; }
        public Boolean IsTaken { get; set; }
    }
}
