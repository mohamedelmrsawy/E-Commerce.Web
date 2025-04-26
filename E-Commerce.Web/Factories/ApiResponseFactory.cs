using Microsoft.AspNetCore.Mvc;
using Shared.ErrorModels;

namespace E_Commerce.Web.Factories
{
    public static class ApiResponseFactory
    {
        public static IActionResult GenerateApiValidationErrorRespnse(ActionContext context)
        {
            var Error = context.ModelState.Where(m => m.Value.Errors.Any())
                                          .Select(m => new ValidationError()
                                          {
                                              Field = m.Key,
                                              Error = m.Value.Errors.Select(e=>e.ErrorMessage)
                                          });
            var response = new ValidationErrorToReturn()
            {
                ValidationError = Error
            };
            return new BadRequestObjectResult(response);
        }
    }
}
