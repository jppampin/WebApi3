
using FluentValidation.TestHelper;
using WebApi.Dtos;
using WebApi.Models.Validations;
using Xunit;

namespace WebApiTests
{
    public class OrderRequestValidatorTest
    {
        private OrderRequestValidator testObject;

        public OrderRequestValidatorTest()
        {
            testObject = new OrderRequestValidator();
        }

        [Fact]
        public void validator_should_fail_with_emtpy_currency()
        {
            var orderRequest = new OrderRequest();
            
            testObject.ShouldHaveValidationErrorFor(o => o.Currency, orderRequest);
        }


        [Fact]
        public void validator_should_fail_with_emtpy_ids()
        {
            var orderRequest = new OrderRequest();
            
            testObject.ShouldHaveValidationErrorFor(o => o.ItemsIds, orderRequest);
        }

        [Fact]
        public void validator_should_fail_with_currency_not_equal_to_3_characters()
        {
            var orderRequest = new OrderRequest
            {
                Currency = "AR"
            };
            
            testObject.ShouldHaveValidationErrorFor(o => o.Currency, orderRequest);
        }
    }
}