using Application.Abstractions;
using Application.Recipes.Dtos;
using Application.Recipes.Queries;
using AutoMapper;
using MediatR;

namespace Application.Recipes.QueryHandlers;

public class GetRecipeByIdQueryHandler : IRequestHandler<GetRecipeByIdQuery, GetRecipeDto>
{
    private readonly IRecipeRepository _recipeRepository;
    private readonly IMapper _mapper;

    public GetRecipeByIdQueryHandler(IRecipeRepository recipeRepository, IMapper mapper)
    {
        _recipeRepository = recipeRepository;
        _mapper = mapper;
    }

    public async Task<GetRecipeDto> Handle(GetRecipeByIdQuery request, CancellationToken cancellationToken)
    {
        return _mapper.Map<GetRecipeDto>(await _recipeRepository.GetRecipeById(request.Id));
    }
}