using MealOrdering.Server.Services.Infrastrucuture;
using MealOrdering.Shared.DTOs;
using MealOrdering.Shared.ResponseModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MealOrdering.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }


        [HttpGet("[action]")]
        public async Task<ServiceResponse<string>> Login(string email, string password)
        {
            return new ServiceResponse<string>
            {
                Value = await _userService.Login(email, password)
            };
        }


        [HttpGet]
        public async Task<ServiceResponse<List<UserDTO>>> Get()
        {
            ServiceResponse<List<UserDTO>> Response = new ServiceResponse<List<UserDTO>>();
            Response.IsSuccess = true;
            Response.Value = await _userService.GetAll();
            Response.Message = "successfull";
            return Response;
        }
        [HttpPost]
        public async Task<ServiceResponse<UserDTO>> Create([FromBody] UserDTO userDTO)
        {
            ServiceResponse<UserDTO> Response = new ServiceResponse<UserDTO>();
            Response.IsSuccess = true;
            Response.Value = await _userService.Create(userDTO);
            Response.Message = "successfull";
            return Response;
        }

        [HttpPost]
        public async Task<ServiceResponse<UserDTO>> Update([FromBody] UserDTO userDTO)
        {
            ServiceResponse<UserDTO> Response = new ServiceResponse<UserDTO>();
            Response.IsSuccess = true;
            Response.Value = await _userService.Update(userDTO);
            Response.Message = "successfull";
            return Response;
        }
        [HttpGet("[action]")]
        public async Task<ServiceResponse<UserDTO>> GetById(string Id)
        {
            ServiceResponse<UserDTO> Response = new ServiceResponse<UserDTO>();
            Response.IsSuccess = true;
            Response.Value = await _userService.GetById(Guid.Parse(Id));
            Response.Message = "successfull";
            return Response;
        }
        [HttpGet("[action]")]
        public async Task<ServiceResponse<UserDTO>> Delete(string Id)
        {
            ServiceResponse<UserDTO> Response = new ServiceResponse<UserDTO>();
            Response.IsSuccess = true;
            Response.Value = await _userService.Delete(Guid.Parse(Id));
            Response.Message = "successfull";
            return Response;
        }
    }
}
