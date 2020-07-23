using System.Collections.Generic;
using AutoMapper;
using WebApi.Dtos;
using WebApi.Models;
using System;

namespace WebApi.Mappers
{
    public class OrderMapper 
    {
        private IMapper mapper;
        public OrderMapper()
        {
            var config = new MapperConfiguration( c => 
                {
                    c.CreateMap<Order, OrderResponse>()
                        .ForMember(d => d.ItemIds,
                                   s => s.MapFrom(src => String.Join(", ",
                                                                     src.ItemsIds)));
                }
            );

            this.mapper = config.CreateMapper();
        }
        public OrderResponse Map(Order order)
        {
            return mapper.Map<OrderResponse>(order);            
        }

        public IEnumerable<OrderResponse> Map(IEnumerable<Order> orders)
        {
            return mapper.Map<IEnumerable<OrderResponse>>(orders);
        }
    }
}