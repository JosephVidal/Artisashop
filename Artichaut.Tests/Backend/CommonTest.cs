using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace Artichaut.Tests.Backend
{
    public class CommonTest
    {
        public static void Control(Mock[] _mocks, IActionResult result, object resultContent, string returnType)
        {
            switch (returnType)
            {
                case "Redirect":
                    Assert.IsAssignableFrom<RedirectToActionResult>(result);
                    Assert.Equal(resultContent, ((RedirectToActionResult)result).GetType());
                    break;
                case "Unauthorized":
                    Assert.IsAssignableFrom<UnauthorizedObjectResult>(result);
                    Assert.Equal(resultContent, ((UnauthorizedObjectResult)result).Value!.GetType());
                    break;
                case "BadRequest":
                    Assert.IsAssignableFrom<BadRequestObjectResult>(result);
                    Assert.Equal(resultContent, ((BadRequestObjectResult)result).Value!.GetType());
                    break;
                case "Ok":
                    Assert.IsAssignableFrom<OkObjectResult>(result);
                    Assert.Equal(resultContent, ((OkObjectResult)result).Value!.GetType());
                    break;
                case "NotFound":
                    Assert.IsAssignableFrom<NotFoundObjectResult>(result);
                    Assert.Equal(resultContent, ((NotFoundObjectResult)result).Value!.GetType());
                    break;
                default:
                    throw new KeyNotFoundException("Return type exception");
            };
            Mock.VerifyAll(_mocks);
        }
    }
}
