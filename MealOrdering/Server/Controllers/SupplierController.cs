using AutoMapper;
using MealOrdering.Server.Data.Models;
using MealOrdering.Server.Services.Infrastrucuture;
using MealOrdering.Server.Services.Services;
using MealOrdering.Shared.DTOs;
using MealOrdering.Shared.ResponseModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MealOrdering.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        private ISupplierService _supplierService;
        IMapper _mapper;

        public SupplierController(ISupplierService supplierService, IMapper mapper)
        {
            _supplierService = supplierService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ServiceResponse<List<SupplierDTO>>> Get()
        {
            return new ServiceResponse<List<SupplierDTO>>()
            {
                IsSuccess = true,
                Message = "succesfull",
                Value = _mapper.Map<List<SupplierDTO>>(await _supplierService.GetAll())
            };
        }
        [HttpGet("[action]/{Id}")]
        public async Task<ServiceResponse<SupplierDTO>> GetById(Guid Id)
        {
            return new ServiceResponse<SupplierDTO>()
            {
                IsSuccess = true,
                Message = "succesfull",
                Value = _mapper.Map<SupplierDTO>(await _supplierService.GetById(Id))
            };
        }

        [HttpPost("[action]")]
        public async Task<ServiceResponse<SupplierDTO>> Create([FromBody] SupplierDTO supplierDTO)
        {
            Suppliers suppliers = await _supplierService.Create(_mapper.Map<Suppliers>(supplierDTO));
            return new ServiceResponse<SupplierDTO>()
            {
                IsSuccess = true,
                Message = "succesfull",
                Value = _mapper.Map<SupplierDTO>(suppliers)
            };
        }
        [HttpPost("[action]/{Id}")]
        public async Task<ServiceResponse<SupplierDTO>> Update(Guid Id, [FromBody] SupplierDTO supplierDTO)
        {
            //Suppliers suppliers = await _supplierService.Update(_mapper.Map<Suppliers>(supplierDTO));
            return new ServiceResponse<SupplierDTO>()
            {
                IsSuccess = true,
                Message = "succesfull",
                Value = _mapper.Map<SupplierDTO>(await _supplierService.Update(_mapper.Map<Suppliers>(supplierDTO)))
            };
        }
    }
}
