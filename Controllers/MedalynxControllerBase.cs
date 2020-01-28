using Microsoft.AspNetCore.Mvc;

namespace MedalynxAPI.Controllers
{
    [ApiController]
    [AddHeader("Access-Control-Allow-Origin", "true")]
    public class MedalynxControllerBase : ControllerBase
    {
    }
}
