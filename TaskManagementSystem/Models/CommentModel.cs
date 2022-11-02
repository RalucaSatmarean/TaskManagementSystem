using System.ComponentModel.DataAnnotations;

namespace TaskManagementSystem.Models
{
    public class CommentModel
    {
        public Guid CommentId { get; set; }
        public string Comments { get; set; } = null!;

        [DisplayFormat(DataFormatString = "{0:d}")]
        [DataType(DataType.Date)]
        public DateTime? Date { get; set; }
        public Guid TaskId { get; set; }
        public Guid UserId { get; set; }
    }
}
