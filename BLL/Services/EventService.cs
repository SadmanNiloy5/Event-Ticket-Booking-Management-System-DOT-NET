using AutoMapper;
using BLL.DTOs;
using DAL.EF.Tables;
using DAL.Repos;

namespace BLL.Services
{
    public class EventService
    {
        EventRepo repo;
        Mapper mapper;

        public EventService(EventRepo repo)
        {
            this.repo = repo;

            mapper = MapperConfig.GetMapper();
        }

        public List<EventDTO> Get()
        {
            var data = repo.Get();

            var res = mapper.Map<List<EventDTO>>(data);

            return res;
        }

        public EventDTO Get(int id)
        {
            var data = repo.Get(id);

            var res = mapper.Map<EventDTO>(data);

            return res;
        }

        public bool Create(EventDTO e)
        {
            var converted = mapper.Map<Event>(e);

            return repo.Create(converted);
        }

        public bool Update(EventDTO e)
        {
            var converted = mapper.Map<Event>(e);

            return repo.Update(converted);
        }

        public bool Delete(int id)
        {
            return repo.Delete(id);
        }

        public List<EventDTO> Search(string txt)
        {
            var data = repo.Search(txt);

            var res = mapper.Map<List<EventDTO>>(data);

            return res;
        }
    }
}