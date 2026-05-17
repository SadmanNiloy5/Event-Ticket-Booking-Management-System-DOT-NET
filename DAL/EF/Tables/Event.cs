using System;
using System.Collections.Generic;

namespace DAL.EF.Tables;

public partial class Event
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Location { get; set; } = null!;

    public DateTime EventDate { get; set; }

    public double TicketPrice { get; set; }

    public int TotalSeats { get; set; }

    public int AvailableSeats { get; set; }

    public string Status { get; set; } = null!;

    public string? Description { get; set; }

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();
}
