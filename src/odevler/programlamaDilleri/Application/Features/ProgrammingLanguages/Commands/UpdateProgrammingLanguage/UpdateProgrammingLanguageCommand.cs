using Application.Features.ProgramLanguages.Commands.CreateProgramLanguage;
using Application.Features.ProgramLanguages.Dtos;
using Application.Features.ProgramLanguages.Rules;
using Application.Features.ProgrammingLanguages.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgrammingLanguages.Commands.UpdateProgrammingLanguage
{
  public class UpdateProgrammingLanguageCommand : IRequest<UpdatedProgrammingLanguageDto>
  {
    public int Id { get; set; }
    public string Name { get; set; }

    public class UpdateProgrammingLanguageCommandHandler : IRequestHandler<UpdateProgrammingLanguageCommand, UpdatedProgrammingLanguageDto>
    {
      private readonly IProgrammingLanguageRepository _programLanguageRepository;
      private readonly IMapper _mapper;

      public UpdateProgrammingLanguageCommandHandler(IProgrammingLanguageRepository programLanguageRepository, IMapper mapper)
      {
        _programLanguageRepository = programLanguageRepository;
        _mapper = mapper;
      }

      public async Task<UpdatedProgrammingLanguageDto> Handle(UpdateProgrammingLanguageCommand request, CancellationToken cancellationToken)
      {

        ProgrammingLanguage mappedProgramLanguage = _mapper.Map<ProgrammingLanguage>(request);
        ProgrammingLanguage createdProgramLanguage = await _programLanguageRepository.UpdateAsync(mappedProgramLanguage);
        UpdatedProgrammingLanguageDto updatedProgramLanguageDto = _mapper.Map<UpdatedProgrammingLanguageDto>(createdProgramLanguage);

        return updatedProgramLanguageDto;
      }
    }
  }
}
