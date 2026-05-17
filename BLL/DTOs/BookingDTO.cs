using System.ComponentModel.DataAnnotations;

namespace BLL.DTOs
{
    public class BookingDTO
    {
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public int EventId { get; set; }

        [Required]
        [Range(1, 10)]
        public int SeatCount { get; set; }

        public double TotalAmount { get; set; }

        public DateTime BookingDate { get; set; }

        public string? Status { get; set; }
    }
}