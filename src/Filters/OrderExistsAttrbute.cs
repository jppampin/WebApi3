using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using WebApi.Models;
using WebApi.Repositories;
using WebApi.Repositories.Generic;

namespace WebApi.Filters
{
    public class OrderExistsAttribute: TypeFilterAttribute
    {
        public OrderExistsAttribute():base(typeof(OrderExistsFilter))
        {}

        private class OrderExistsFilter : IAsyncActionFilter
        {
            private Repositories.Generic.IUnitOfWork unitOfWork;

            private IRepository<Order> Repository => unitOfWork.OrderRepository; 

            public OrderExistsFilter(WebApi.Repositories.Generic.IUnitOfWork unitOfWork)
            {
                this.unitOfWork = unitOfWork;
            }

            public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
            {
                if(!context.ActionArguments.ContainsKey("id"))
                {
                    context.Result = new BadRequestResult();
                    return;
                }

                if(!(context.ActionArguments["id"] is Guid id))
                {
                    context.Result = new BadRequestResult();
                    return;
                }

                var order = await Repository.GetByIdAsync(id);

                if(order == null)
                {
                    context.Result = new NotFoundObjectResult(
                        new {
                         Message = $"No se encontro Orden {id}"
                        });
                    
                    return;
                }

                await next();
            }
        }
    }
}