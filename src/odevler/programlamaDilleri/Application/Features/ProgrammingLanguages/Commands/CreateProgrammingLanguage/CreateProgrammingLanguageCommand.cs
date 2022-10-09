using Application.Features.ProgramLanguages.Dtos;
using Application.Features.ProgramLanguages.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgramLanguages.Commands.CreateProgramLanguage
{
  public class CreateProgrammingLanguageCommand : IRequest<CreatedProgrammingLanguageDto>
  {
    public string Name { get; set; }

    public class CreateProgrammingLanguageCommandHandler : IRequestHandler<CreateProgrammingLanguageCommand, CreatedProgrammingLanguageDto>
    {
      private readonly IProgrammingLanguageRepository _programLanguageRepository;
      private readonly IMapper _mapper;
      private readonly ProgrammingLanguageBusinessRules _programLanguageBusinessRules;

      public CreateProgrammingLanguageCommandHandler(IProgrammingLanguageRepository programLanguageRepository, IMapper mapper, ProgrammingLanguageBusinessRules programLanguageBusinessRules)
      {
        _programLanguageRepository = programLanguageRepository;
        _mapper = mapper;
        _programLanguageBusinessRules = programLanguageBusinessRules;
      }

      public async Task<CreatedProgrammingLanguageDto> Handle(CreateProgrammingLanguageCommand request, CancellationToken cancellationToken)
      {
        await _programLanguageBusinessRules.ProgramLanguageNameCanNotBeDuplicatedWhenInserted(request.Name);

        ProgrammingLanguage mappedProgramLanguage = _mapper.Map<ProgrammingLanguage>(request);
        ProgrammingLanguage createdProgramLanguage = await _programLanguageRepository.AddAsync(mappedProgramLanguage);
        CreatedProgrammingLanguageDto createdProgramLanguageDto = _mapper.Map<CreatedProgrammingLanguageDto>(createdProgramLanguage);

        return createdProgramLanguageDto;
      }
    }
  }
}
