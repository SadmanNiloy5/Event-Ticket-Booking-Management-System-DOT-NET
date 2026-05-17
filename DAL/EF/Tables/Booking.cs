using System;
using System.Collections.Generic;

namespace DAL.EF.Tables;

public partial class Booking
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int EventId { get; set; }

    public int SeatCount { get; set; }

    public double TotalAmount { get; set; }

    public DateTime BookingDate { get; set; }

    public string Status { get; set; } = null!;

    public virtual Event Event { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
