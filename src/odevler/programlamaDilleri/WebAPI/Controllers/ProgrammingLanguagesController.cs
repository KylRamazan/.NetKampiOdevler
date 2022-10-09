using Application.Features.ProgramLanguages.Commands.CreateProgramLanguage;
using Application.Features.ProgramLanguages.Dtos;
using Application.Features.ProgrammingLanguages.Commands.UpdateProgrammingLanguage;
using Application.Features.ProgrammingLanguages.Dtos;
using Application.Features.ProgrammingLanguages.Models;
using Application.Features.ProgrammingLanguages.Queries.GetByIdProgrammingLanguage;
using Application.Features.ProgrammingLanguages.Queries.GetListProgrammingLanguage;
using Core.Application.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ProgrammingLanguagesController : BaseController
  {
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateProgrammingLanguageCommand createProgramLanguageCommand)
    {
      CreatedProgrammingLanguageDto result = await Mediator.Send(createProgramLanguageCommand);
      return Created("",result);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
      GetListProgrammingLanguageQuery getListProgrammingLanguageQuery = new() {PageRequest = pageRequest};
      ProgrammingLanguageListModel result = await Mediator.Send(getListProgrammingLanguageQuery);
      return Ok(result);
    }

    [HttpGet("{Id}")]
    public async Task<IActionResult> GetById([FromRoute] GetByIdProgrammingLanguageQuery getByIdProgrammingLanguageQuery)
    {
      ProgrammingLanguageGetByIdDto programmingLanguageGetByIdDto  = await Mediator.Send(getByIdProgrammingLanguageQuery);
      return Ok(programmingLanguageGetByIdDto);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateProgrammingLanguageCommand updateProgramLanguageCommand)
    {
      UpdatedProgrammingLanguageDto result = await Mediator.Send(updateProgramLanguageCommand);
      return Ok(result);
    }

    [HttpDelete("Id")]
    public async Task<IActionResult> Delete([FromQuery] UpdateProgrammingLanguageCommand updateProgramLanguageCommand)
    {
      UpdatedProgrammingLanguageDto result = await Mediator.Send(updateProgramLanguageCommand);
      return Ok(result);
    }
  }
}
