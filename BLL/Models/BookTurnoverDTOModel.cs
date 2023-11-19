using System.ComponentModel.DataAnnotations;

namespace BLL.Models
{
    public class BookTurnoverDTOModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public BookDTOModel Book { get; set; } = null!;
        [DataType(DataType.Date)]
        public DateTime TakenTime { get; set; }
        [DataType(DataType.Date)]
        public DateTime ReturnedTime { get; set; }
        public Boolean IsTaken { get; set; }
    }
}
