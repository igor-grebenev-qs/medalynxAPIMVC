using Microsoft.AspNetCore.Mvc;

namespace MedalynxAPI.Controllers
{
    [ApiController]
    [AddHeader("Access-Control-Allow-Origin", "*")]
    public class MedalynxControllerBase : ControllerBase
    {
    }
}
