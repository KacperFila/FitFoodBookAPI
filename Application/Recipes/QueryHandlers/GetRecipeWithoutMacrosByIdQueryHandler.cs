using Application.Abstractions;
using Application.Recipes.Dtos;
using Application.Recipes.Queries;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Recipes.QueryHandlers;

public class GetRecipeWithoutMacrosByIdQueryHandler : IRequestHandler<GetRecipeWithoutMacrosByIdQuery, GetRecipeWithoutMacrosDto>
{
    private readonly IRecipeRepository _recipeRepository;
    private readonly IMapper _mapper;

    public GetRecipeWithoutMacrosByIdQueryHandler(IRecipeRepository recipeRepository, IMapper mapper)
    {
        _recipeRepository = recipeRepository;
        _mapper = mapper;
    }

    public async Task<GetRecipeWithoutMacrosDto> Handle(GetRecipeWithoutMacrosByIdQuery request, CancellationToken cancellationToken)
    {
        return _mapper.Map<GetRecipeWithoutMacrosDto>(await _recipeRepository.GetRecipeById(request.Id));
    }
}