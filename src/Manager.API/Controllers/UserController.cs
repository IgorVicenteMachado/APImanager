using AutoMapper;
using Manager.API.Utilities;
using Manager.API.ViewModels;
using Manager.Core.Exceptions;
using Manager.Services.DTO;
using Manager.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Manager.API.Controllers
{
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUserService _userService;

        public UserController(IMapper mapper, IUserService userService)
        {
            _mapper = mapper;
            _userService = userService;
        }

        [HttpPost]
        [Authorize]
        [Route("/api/v1/users/create")]
        public async Task<IActionResult> CreateAsync([FromBody] CreateUserViewModel userViewModel)
        {
            try
            {
                var userDTO = _mapper.Map<UserDTO>(userViewModel);
                var userCreated = await _userService.CreateAsync(userDTO);

                return Ok(new ResultViewModel
                {
                    Message = "User created successfully",
                    Success = true,
                    Data = userCreated
                });
            }
            catch (DomainException ex)
            {
                return BadRequest(Responses.DomainErrorMessage(ex.Message, ex.Errors));
            }
            catch (Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMassage());
            }
        }

        [HttpPut]
        [Authorize]
        [Route("/api/v1/users/update")]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateUserViewModel userViewModel)
        {
            try
            {
                var userDTO = _mapper.Map<UserDTO>(userViewModel);
                var userUpdated = await _userService.UpdateAsync(userDTO);

                return Ok(new ResultViewModel
                {
                    Message = "User updated successfully",
                    Success = true,
                    Data = userUpdated
                });
            }
            catch (DomainException ex)
            {
                return BadRequest(Responses.DomainErrorMessage(ex.Message, ex.Errors));
            }
            catch (Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMassage());
            }
        }

        [Authorize]
        [HttpDelete]
        [Route("api/v1/users/remove/{id}")]
        public async Task<IActionResult> RemoveAsync(long id)
        {
            try
            {
                await _userService.RemoveAsync(id);

                return Ok(new ResultViewModel
                {
                    Message = "User removed successfully",
                    Success = true,
                    Data = null
                });
            }
            catch (DomainException ex)
            {
                return BadRequest(Responses.DomainErrorMessage(ex.Message, ex.Errors));
            }
            catch (Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMassage());
            }
        }  
        [Authorize]
        [HttpGet]
        [Route("api/v1/users/get/{id}")]
        public async Task<IActionResult> GetAsync(long id)
        {
            try
            {
               var user = await _userService.GetAsync(id);

                if (user == null)
                {
                    return Ok(new ResultViewModel
                    {
                        Message = "User wasn't found.",
                        Success = true,
                        Data = user
                    });

                }
                return Ok(new ResultViewModel
                {
                    Message = "User was found successfully.",
                    Success = true,
                    Data = user
                });
            }
            catch (DomainException ex)
            {
                return BadRequest(Responses.DomainErrorMessage(ex.Message, ex.Errors));
            }
            catch (Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMassage());
            }
        } 
        [Authorize]
        [HttpGet]
        [Route("api/v1/users/get-all")]
        public async Task<IActionResult> GetAsync()
        {
            try
            {
               var allUsers = await _userService.GetAllAsync();

                return Ok(new ResultViewModel
                {
                    Message = "User(s) was found successfully.",
                    Success = true,
                    Data = allUsers
                });
            }
            catch (DomainException ex)
            {
                return BadRequest(Responses.DomainErrorMessage(ex.Message, ex.Errors));
            }
            catch (Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMassage());
            }
        }
        [Authorize]
        [HttpGet]
        [Route("api/v1/users/get-by-email")]
        public async Task<IActionResult> GetByEmailAsync(string email)
        {
            try
            {
                var user = await _userService.GetByEmailAsync(email);

                if (user == null)
                {
                    return Ok(new ResultViewModel
                    {
                        Message = "No user with the given email was found.",
                        Success = true,
                        Data = user
                    });

                }
                return Ok(new ResultViewModel
                {
                    Message = "User was found successfully.",
                    Success = true,
                    Data = user
                });
            }
            catch (DomainException ex)
            {
                return BadRequest(Responses.DomainErrorMessage(ex.Message, ex.Errors));
            }
            catch (Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMassage());
            }
        }   
        [Authorize]
        [HttpGet]
        [Route("api/v1/users/search-by-name")]
        public async Task<IActionResult> SearchByNameAsync(string name)
        {
            try
            {
                var allUsers = await _userService.SearchByNameAsync(name);

                if (allUsers.Count == 0)
                {
                    return Ok(new ResultViewModel
                    {
                        Message = "No user with the given name was found.",
                        Success = true,
                        Data = null
                    });

                }
                return Ok(new ResultViewModel
                {
                    Message = "User(s) found successfully.",
                    Success = true,
                    Data = allUsers
                });
            }
            catch (DomainException ex)
            {
                return BadRequest(Responses.DomainErrorMessage(ex.Message, ex.Errors));
            }
            catch (Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMassage());
            }
        } 
        [Authorize]
        [HttpGet]
        [Route("api/v1/users/search-by-email")]
        public async Task<IActionResult> SearchByEmailAsync(string email)
        {
            try
            {
                var allUsers = await _userService.SearchByEmailAsync(email);

                if (allUsers.Count == 0)
                {
                    return Ok(new ResultViewModel
                    {
                        Message = "No user with the given e-mail was found.",
                        Success = true,
                        Data = null
                    });
                }
                return Ok(new ResultViewModel
                {
                    Message = "User found successfully.",
                    Success = true,
                    Data = allUsers
                });
            }
            catch (DomainException ex)
            {
                return BadRequest(Responses.DomainErrorMessage(ex.Message, ex.Errors));
            }
            catch (Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMassage());
            }
        }
    }
}
