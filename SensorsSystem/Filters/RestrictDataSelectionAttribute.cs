using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Options;
using SensorsSystem.Options;
using System;

namespace SensorsSystem.Filters
{
    public class RestrictDataSelectionAttribute : ActionFilterAttribute
    {
        private readonly IOptions<DataRestrictionOptions> _options;
        public RestrictDataSelectionAttribute(IOptions<DataRestrictionOptions> options)
        {
            if (options?.Value == null)
            {
                throw new ArgumentNullException();
            }

            _options = options;
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            var accessibleFrom = _options.Value.AccessibleFrom;
            var accessibleTill = _options.Value.AccessibleTill;
            var currentHour = DateTime.Now.Hour;
            if (currentHour < accessibleFrom || currentHour > accessibleTill)
            {
                context.Result = new ContentResult
                {
                    Content = "Data cannot be retrieved now",
                    StatusCode = StatusCodes.Status400BadRequest
                };
            }
        }
    }
}
