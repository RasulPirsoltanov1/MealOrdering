using AutoMapper;
using MealOrdering.Server.Services.Infrastrucuture;
using MealOrdering.Shared.DTOs;
using MealOrdering.Shared.ResponseModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MealOrdering.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private IOrderService _orderService;
        IMapper _mapper;
        public OrderController(IOrderService orderService, IMapper mapper)
        {
            _orderService = orderService;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<ServiceResponse<List<OrderDTO>>> Get()
        {
            return new ServiceResponse<List<OrderDTO>> {
                Value =_mapper.Map<List<OrderDTO>>(await _orderService.GetAll()),
                IsSuccess=true,
                Message="successfull"
            };
        }
        [HttpGet("{Id}")]
        public async Task<ServiceResponse<List<OrderDTO>>> Get(Guid Id)
        {
            return new ServiceResponse<List<OrderDTO>>
            {
                Value = _mapper.Map<List<OrderDTO>>(await _orderService.GetById(Id)),
                IsSuccess = true,
                Message = "successfull"
            };
        }
    }
}
