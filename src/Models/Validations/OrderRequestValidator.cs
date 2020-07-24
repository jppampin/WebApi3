using FluentValidation;
using WebApi.Dtos;

namespace WebApi.Models.Validations
{
    public class OrderRequestValidator: AbstractValidator<OrderRequest>
    {
        public OrderRequestValidator()
        {
            RuleFor( o => o.Currency ).NotEmpty().WithMessage("Debe cargar una moneda");
            RuleFor( o => o.Currency ).Length(3).WithMessage("La moneda debe tener 3 posiciones");
            RuleFor( o => o.ItemsIds ).NotEmpty().WithMessage("Deben cargar lista de Ids");
        }
    }
}