using System.ComponentModel.DataAnnotations;

namespace BLL.DTOs
{
    public class EventDTO
    {
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        public string? Location { get; set; }

        [Required]
        public DateTime EventDate { get; set; }

        [Required]
        [Range(1, 100000)]
        public double TicketPrice { get; set; }

        [Required]
        [Range(1, 100000)]
        public int TotalSeats { get; set; }

        [Required]
        [Range(0, 100000)]
        public int AvailableSeats { get; set; }

        [Required]
        public string? Status { get; set; }

        public string? Description { get; set; }
    }
}