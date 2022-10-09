using Application.Features.ProgrammingLanguages.Queries.GetListProgrammingLanguage;
using Application.Features.Technologies.Models;
using Application.Features.Technologies.Queries.GetListTechnology;
using Application.Features.Technologies.Queries.GetListTechnologyByDynamic;
using Core.Application.Requests;
using Core.Persistence.Dynamic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class TechnologiesController : BaseController
  {
    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
      GetListTechnologyQuery getListTechnologyQuery = new() { PageRequest = pageRequest };
      TechnologyListModel result = await Mediator.Send(getListTechnologyQuery);
      return Ok(result);
    }

    [HttpPost("GetList/ByDynamic")]
    public async Task<IActionResult> GetListByDynamic([FromQuery] PageRequest pageRequest,[FromBody] Dynamic dynamic)
    {
      GetListTechnologyByDynamicQuery getListTechnologyByDynamicQuery = new() { PageRequest = pageRequest , Dynamic = dynamic};
      TechnologyListModel result = await Mediator.Send(getListTechnologyByDynamicQuery);
      return Ok(result);
    }
  }
}
