using Application.Abstractions;
using Application.Recipes.Dtos;
using Application.Recipes.Queries;
using AutoMapper;
using MediatR;

namespace Application.Recipes.QueryHandlers;

public class GetAllRecipesQueryHandler : IRequestHandler<GetAllRecipesQuery, List<GetRecipeDto>>
{
    private readonly IRecipeRepository _recipeRepository;
    private readonly IMapper _mapper;

    public GetAllRecipesQueryHandler(IRecipeRepository recipeRepository, IMapper mapper)
    {
        _recipeRepository = recipeRepository;
        _mapper = mapper;
    }

    public async Task<List<GetRecipeDto>> Handle(GetAllRecipesQuery request, CancellationToken cancellationToken)
    {
        return _mapper.Map<List<GetRecipeDto>>(await _recipeRepository.GetRecipes());
    }
}