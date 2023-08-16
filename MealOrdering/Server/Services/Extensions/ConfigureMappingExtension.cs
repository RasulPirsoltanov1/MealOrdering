using AutoMapper;
using MealOrdering.Server.Data.Models;
using MealOrdering.Shared.DTOs;

namespace MealOrdering.Server.Services.Extensions
{
    public class ConfigureMappingExtension:Profile
    {
        public ConfigureMappingExtension()
        {
            CreateMap<Users, UserDTO>().ReverseMap();
            CreateMap<Suppliers, SupplierDTO>().ReverseMap();
            CreateMap<Orders, OrderDTO>().ForMember(o=>o.CreatedUserFullName,y=>y.MapFrom(o=>o.User.FirstName+ " " + o.User.LastName)).ForMember(o=>o.SupplierName,o=>o.MapFrom(y=>y.Supplier.Name)).ReverseMap();
            CreateMap<OrderItems, OrderItemDTO>().ForMember(o=>o.CreatedUserFullName,y=>y.MapFrom(o=>o.User.FirstName+ " " + o.User.LastName)).ForMember(o=>o.OrderName,o=>o.MapFrom(y=>y.Order.Name??"")).ReverseMap();
        }
    }
}
