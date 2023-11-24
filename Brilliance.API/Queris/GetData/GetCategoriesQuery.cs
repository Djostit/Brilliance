namespace Brilliance.API.Queris.GetData
{
    internal record GetCategoriesQuery() : IRequest<List<CategoryDTO>>;
    internal class GetCategoriesQueryHandler : IRequestHandler<GetCategoriesQuery, List<CategoryDTO>>
    {
        private readonly ICategoryService _service;
        public GetCategoriesQueryHandler(ICategoryService service)
        {
            _service = service;
        }
        public async Task<List<CategoryDTO>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
        {
            return await _service.GetCategories(cancellationToken);
        }
    }
}
