namespace Artisashop.Common;

using Microsoft.AspNetCore.Mvc;

[ApiController]
public class ArtisashopBaseController<TController> : ControllerBase
{
    public ILogger<TController> Type { get; set; }
}