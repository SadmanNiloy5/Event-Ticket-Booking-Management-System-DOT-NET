using AutoMapper;
using BLL.DTOs;
using DAL.EF.Tables;

namespace BLL
{
    public class MapperConfig
    {
        public static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Event, EventDTO>().ReverseMap();

                cfg.CreateMap<Booking, BookingDTO>().ReverseMap();

                cfg.CreateMap<User, UserDTO>().ReverseMap();

                cfg.CreateMap<User, RegisterDTO>().ReverseMap();
            });

            return new Mapper(config);
        }
    }
}