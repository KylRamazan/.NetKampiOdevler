using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgramLanguages.Rules
{
  public class ProgrammingLanguageBusinessRules
  {
    private readonly IProgrammingLanguageRepository _programLanguageRepository;

    public ProgrammingLanguageBusinessRules(IProgrammingLanguageRepository programLanguageRepository)
    {
      _programLanguageRepository = programLanguageRepository;
    }

    public async Task ProgramLanguageNameCanNotBeDuplicatedWhenInserted(string name)
    {
      IPaginate<ProgrammingLanguage> result = await _programLanguageRepository.GetListAsync(x => x.Name == name);
      if (result.Items.Any()) throw new BusinessException("Program Language name exists.");
    }

    public void ProgramLanguageShouldExistWhenRequested(ProgrammingLanguage programmingLanguage)
    {
      if (programmingLanguage == null) throw new BusinessException("Requested program Language does not exists.");
    }
  }
}
