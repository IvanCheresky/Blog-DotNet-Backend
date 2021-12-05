using AutoMapper;
using DotNet_Backend.Data;
using DotNet_Backend.Data.Contracts.DTO;
using DotNet_Backend.Data.Contracts.Interfaces;
using DotNet_Backend.Data.Contracts.Requests;
using DotNet_Backend.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using DotNet_Backend.Model;
using DotNet_Backend.Utils;

namespace DotNet_Backend.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly IPasswordService _passwordService;

        public UserService(IMapper mapper, IUserRepository userRepository, IPasswordService passwordService)
        {
            _mapper = mapper;
            _userRepository = userRepository;
            _passwordService = passwordService;
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
            if (!StringValidators.IsValidEmail(ur.Email))
            {
                throw new Exception("The email has an incorrect format");
            }

            ValidateUser(ur);

            var u = new User()
            {
                CreationDate = DateTime.UtcNow,
                LastLogin = DateTime.UtcNow,
                Password = _passwordService.Hash(ur.Password),
                Username = ur.Username,
                Email = ur.Email
            };

            var user = _userRepository.Add(u);
            var userDto = _mapper.Map<UserDTO>(user);

            return userDto;
        }

        public void ValidateUser(UserRequest ur)
        {
            if (string.IsNullOrEmpty(ur.Password) || string.IsNullOrEmpty(ur.Email) ||
                string.IsNullOrEmpty(ur.Username))
            {
                throw new Exception("No field can be empty");
            }
        }

        public UserDTO UpdateUser(UserRequest ur)
        {
            var u = new User()
            {
                Id = ur.Id,
                Password = ur.Password,
                Username = ur.Username,
                Email = ur.Email
            };

            var user = _userRepository.Update(u);
            var userDto = _mapper.Map<UserDTO>(user);

            return userDto;
        }

        public void DeleteUser(int id)
        {
            _userRepository.Delete(id);
        }

        public UserDTO Login(LoginRequest lr)
        {
            // get user assuming the input is the username
            var userByUsername = _userRepository.GetUserByUsername(lr.EmailOrUsername);

            // if a username was found, check if the password matches
            if (userByUsername != null)
            {
                if (_passwordService.Check(userByUsername.Password, lr.Password))
                {
                    var userDto = _mapper.Map<UserDTO>(userByUsername);
                    return userDto;
                }
            }

            // now check if it has an email format
            if (!StringValidators.IsValidEmail(lr.EmailOrUsername))
            {
                throw new Exception("Wrong login information");
            }

            // if it is an email, get the corresponding user and check if the password matches
            var userByEmail = _userRepository.GetUserByEmail(lr.EmailOrUsername);

            if (userByEmail != null)
            {
                if (_passwordService.Check(userByEmail.Password, lr.Password))
                {
                    var userDto = _mapper.Map<UserDTO>(userByEmail);
                    return userDto;
                }
            }

            throw new Exception("Wrong login information");
        }
    }
}