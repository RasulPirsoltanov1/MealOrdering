using AutoMapper;
using MealOrdering.Server.Data.Models;
using MealOrdering.Server.Services.Infrastrucuture;
using MealOrdering.Shared.DTOs;
using MealOrdering.Shared.ResponseModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MealOrdering.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        IUserService _userService;
        IMapper _mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }


        [HttpPost("[action]")]
        [AllowAnonymous]
        public async Task<ServiceResponse<UserLoginResponseDTO>> Login([FromBody] UserLoginRequestDTO userLoginRequestDTO)
        {
            return new ServiceResponse<UserLoginResponseDTO>()
            {
                Value = await _userService.Login(userLoginRequestDTO.Email, userLoginRequestDTO.Password)
            };

        }


        [HttpGet]
        public async Task<ServiceResponse<List<UserDTO>>> Get()
        {
            ServiceResponse<List<UserDTO>> Response = new ServiceResponse<List<UserDTO>>();
            Response.IsSuccess = true;
            Response.Value = _mapper.Map<List<UserDTO>>(await _userService.GetAll());
            Response.Message = "successfull";
            return Response;
        }
        [HttpPost("[action]")]
        public async Task<ServiceResponse<UserDTO>> Create([FromBody] UserDTO userDTO)
        {
            ServiceResponse<UserDTO> Response = new ServiceResponse<UserDTO>();
            Response.IsSuccess = true;
            userDTO.Id = Guid.NewGuid();
            userDTO.CreateDate=DateTime.Now;
            var user = _mapper.Map<Users>(userDTO);
            Response.Value = _mapper.Map<UserDTO>(await _userService.Create(user));
            Response.Message = "successfull";
            return Response;
        }

        [HttpPost("[action]")]
        public async Task<ServiceResponse<UserDTO>> Update([FromBody] UserDTO userDTO)
        {
            ServiceResponse<UserDTO> Response = new ServiceResponse<UserDTO>();
            Response.IsSuccess = true;
            var user = _mapper.Map<Users>(userDTO);
            Response.Value = _mapper.Map<UserDTO>(await _userService.Update(user));
            Response.Message = "successfull";
            return Response;
        }
        [HttpGet("[action]/{Id}")]
        public async Task<ServiceResponse<UserDTO>> GetById(Guid Id)
        {
            ServiceResponse<UserDTO> Response = new ServiceResponse<UserDTO>();
            Response.IsSuccess = true;
            Response.Value =  _mapper.Map<UserDTO>(await _userService.GetById(Id));
            Response.Message = "successfull";
            return Response;
        }
        [HttpGet("[action]/{Id}")]
        public async Task<ServiceResponse<UserDTO>> Delete(string Id)
        {
            ServiceResponse<UserDTO> Response = new ServiceResponse<UserDTO>();
            Response.IsSuccess = true;
            Response.Value =  _mapper.Map<UserDTO>(await _userService.Delete(Guid.Parse(Id)));
            Response.Message = "successfull";
            return Response;
        }
    }
}
