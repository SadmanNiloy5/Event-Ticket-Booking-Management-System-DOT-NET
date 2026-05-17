using AutoMapper;
using BLL.DTOs;
using DAL.EF.Tables;
using DAL.Repos;

namespace BLL.Services
{
    public class UserService
    {
        UserRepo repo;

        Mapper mapper;

        public UserService(UserRepo repo)
        {
            this.repo = repo;

            mapper = MapperConfig.GetMapper();
        }

        public bool Register(RegisterDTO u)
        {
            var converted = mapper.Map<User>(u);

            converted.Role = "User";

            return repo.Create(converted);
        }

        public UserDTO Login(LoginDTO u)
        {
            var data = repo.Authenticate(u.Email, u.Password);

            var res = mapper.Map<UserDTO>(data);

            return res;
        }

        public List<UserDTO> Get()
        {
            var data = repo.Get();

            var res = mapper.Map<List<UserDTO>>(data);

            return res;
        }
    }
}