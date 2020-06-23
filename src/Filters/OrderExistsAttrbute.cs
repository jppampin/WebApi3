using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using WebApi.Repositories;

namespace WebApi.Filters
{
    public class OrderExistsAttribute: TypeFilterAttribute
    {
        public OrderExistsAttribute():base(typeof(OrderExistsFilter))
        {}

        private class OrderExistsFilter : IAsyncActionFilter
        {
            private IOrderRepository repository;

            public OrderExistsFilter(IOrderRepository repository)
            {
                this.repository = repository;
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

                var order = await repository.GetAsync(id);

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