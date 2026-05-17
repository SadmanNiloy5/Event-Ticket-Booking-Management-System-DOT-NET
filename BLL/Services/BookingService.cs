using AutoMapper;
using BLL.DTOs;
using DAL.EF.Tables;
using DAL.Repos;

namespace BLL.Services
{
    public class BookingService
    {
        BookingRepo bookingRepo;
        EventRepo eventRepo;

        Mapper mapper;

        public BookingService(BookingRepo bookingRepo, EventRepo eventRepo)
        {
            this.bookingRepo = bookingRepo;

            this.eventRepo = eventRepo;

            mapper = MapperConfig.GetMapper();
        }

        public List<BookingDTO> Get()
        {
            var data = bookingRepo.Get();

            var res = mapper.Map<List<BookingDTO>>(data);

            return res;
        }

        public BookingDTO Get(int id)
        {
            var data = bookingRepo.Get(id);

            var res = mapper.Map<BookingDTO>(data);

            return res;
        }

        public bool Create(BookingDTO b)
        {
            var eventData = eventRepo.Get(b.EventId);

            if (eventData.AvailableSeats < b.SeatCount)
            {
                return false;
            }

            b.TotalAmount = b.SeatCount * eventData.TicketPrice;

            b.BookingDate = DateTime.Now;

            b.Status = "Confirmed";

            eventData.AvailableSeats -= b.SeatCount;

            if (eventData.AvailableSeats == 0)
            {
                eventData.Status = "Sold Out";
            }

            eventRepo.Update(eventData);

            var converted = mapper.Map<Booking>(b);

            return bookingRepo.Create(converted);
        }

        public bool Delete(int id)
        {
            return bookingRepo.Delete(id);
        }
    }
}