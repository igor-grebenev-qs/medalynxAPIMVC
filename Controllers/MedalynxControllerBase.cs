using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MedalynxAPI.Models;

namespace MedalynxAPI.Controllers
{
    [ApiController]
    [AddHeader("Access-Control-Allow-Origin", "*")]
    public class MedalynxControllerBase : ControllerBase
    {

    }
}
