using MealOrdering.Server.Services.Infrastrucuture;
using MealOrdering.Shared.DTOs;
using MealOrdering.Shared.NewFolder.ResponseModels;
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

        [HttpGet]
        public async Task<ServiceResponse<List<UserDTO>>> Get()
        {
            ServiceResponse<List<UserDTO>> Response = new ServiceResponse<List<UserDTO>>();
            Response.IsSuccess = true;
            Response.Value = await _userService.GetAll();
            Response.Message = "successfull";
            return Response;
        }
    }
}
