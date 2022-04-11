﻿using AutoMapper;
using Manager.Core.Exceptions;
using Manager.Domain.Entities;
using Manager.Infra.Interfaces;
using Manager.Services.DTO;
using Manager.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Manager.Services.Services
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

        public async Task<UserDTO> CreateAsync(UserDTO userDTO)
        {
            var userExists = await _userRepository.GetByEmailAsync(userDTO.Email);

            if (userExists != null)
                throw new DomainException("E-mail is already in use.");  // verificar possibilidades

            var user = _mapper.Map<User>(userDTO);
            user.Validate();                                             // verificar necessidade

            var userCreated = await _userRepository.CreateAsync(user); 

            return _mapper.Map<UserDTO>(userCreated);                    // verificar uso de userdto
        }

        public async Task<UserDTO> GetAsync(long id)
        {
            var allUsers = await _userRepository.GetAsync(id);
            return _mapper.Map<UserDTO>(allUsers);
        }

        public async Task<List<UserDTO>> GetAllAsync()
        {
            var allUsers = await _userRepository.GetAllAsync();
            return _mapper.Map<List<UserDTO>>(allUsers);
        }

        public async Task<UserDTO> GetByEmailAsync(string email)
        {
            var user = await _userRepository.GetByEmailAsync(email);
            return _mapper.Map<UserDTO>(user);
        }

        public async Task RemoveAsync(long id)
        {
           await _userRepository.RemoveAsync(id);
        }

        public async Task<List<UserDTO>> SearchByEmailAsync(string email)
        {
            var allUsers = await _userRepository.SearchByEmailAsync(email);
            return _mapper.Map<List<UserDTO>>(allUsers);
        }

        public async Task<List<UserDTO>> SearchByNameAsync(string name)
        {
            var allUsers = await _userRepository.SearchByNameAsync(name);
            return _mapper.Map<List<UserDTO>>(allUsers);
        }

        public async Task<UserDTO> UpdateAsync(UserDTO userDTO)
        {
            var userExists = await _userRepository.GetAsync(userDTO.Id);
            if (userExists == null)
                throw new DomainException("the user doesn't exist.");

            var user = _mapper.Map<User>(userDTO);
            user.Validate();

            var userUpdated = await _userRepository.UpdateAsync(user);
            return _mapper.Map<UserDTO>(userUpdated); 
        }
    }
}