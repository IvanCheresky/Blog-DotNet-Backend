using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using DotNet_Backend.Data;
using DotNet_Backend.Data.Contracts.DTO;
using DotNet_Backend.Data.Contracts.Interfaces;
using DotNet_Backend.Data.Contracts.Requests;
using DotNet_Backend.Services.Interfaces;

namespace DotNet_Backend.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public UserService(IMapper mapper, IUserRepository userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public List<UserDTO> GetAll()
        {
            var users = _userRepository.GetAll();
            var usersDto = _mapper.Map<List<UserDTO>>(users.ToList());

            return usersDto;
        }

        public UserDTO GetUser(int id)
        {
            var user = _userRepository.Get(id);
            var userDto = _mapper.Map<UserDTO>(user);

            return userDto;
        }

        public UserDTO RegisterUser(UserRequest ur)
        {
            var u = new User()
            {
                CreationDate = DateTime.UtcNow,
                LastLogin = DateTime.UtcNow,
                Password = ur.Password,
                Username = ur.Username
            };

            var user = _userRepository.Add(u);
            var userDto = _mapper.Map<UserDTO>(user);

            return userDto;
        }

        public UserDTO UpdateUser(UserRequest ur)
        {
            var u = new User()
            {
                Id = ur.Id,
                Password = ur.Password,
                Username = ur.Username
            };

            var user = _userRepository.Update(u);
            var userDto = _mapper.Map<UserDTO>(user);

            return userDto;
        }

        public void DeleteUser(int id)
        {
            _userRepository.Delete(id);
        }
    }
}