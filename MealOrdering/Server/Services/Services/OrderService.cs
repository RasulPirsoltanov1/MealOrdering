﻿using AutoMapper;
using MealOrdering.Server.Data.Context;
using MealOrdering.Server.Services.Infrastrucuture;
using MealOrdering.Shared.DTOs;

namespace MealOrdering.Server.Services.Services
{
    public class OrderService : GenericService<OrderDTO>, IOrderService
    {
        public OrderService(IMapper mapper, MealOrderingDbContext context) : base(mapper, context)
        {
        }
    }

}
