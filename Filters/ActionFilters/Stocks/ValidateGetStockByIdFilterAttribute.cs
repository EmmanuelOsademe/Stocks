using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using api.Interfaces;

namespace api.Filters.ActionFilters.Stocks
{
    public class ValidateGetStockByIdFilterAttribute : ActionFilterAttribute
    {
        // private readonly IStockRepository _stockRepo;
        // public ValidateGetStockByIdFilterAttribute(IStockRepository stockRepo)
        // {
        //     _stockRepo = stockRepo;
        // }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            var stockId = context.ActionArguments["id"] as int?;
            if(stockId.HasValue)
            {
                if(stockId.Value <= 0){
                    context.ModelState.AddModelError("Id", "StockId is invalid");
                    var problemDetails = new ValidationProblemDetails(context.ModelState){ Status = StatusCodes.Status400BadRequest};
                    context.Result = new BadRequestObjectResult(problemDetails);
                }
                // else if(!_stockRepo.StockExists(stockId.Value)){
                //     context.ModelState.AddModelError("Id", "Stock does not exist");
                //     var problemDetails = new ValidationProblemDetails(context.ModelState) {Status = StatusCodes.Status404NotFound };
                //     context.Result = new NotFoundObjectResult(problemDetails);
                // }
            }
        }
    }
}