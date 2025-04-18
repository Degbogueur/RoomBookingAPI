namespace RoomBookingAPI.Models;

public class Booking
{
    public int Id { get; set; }
    public int RoomId { get; set; }
    public int UserId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

    public virtual User? User { get; set; }
    public virtual Room? Room { get; set; }
}
