using Fina.Api.Common.Api;
using Fina.Api.Endpoints.Categories;
using Fina.Api.Endpoints.Transactions;

namespace Fina.Api.Endpoints
{
    public static class Endpoint
    {
        public static void MapEndpoints(this WebApplication app)
        {
            var endpoints = app.MapGroup("");

            endpoints.MapGroup("/")
                .WithTags("Health Check")
                .MapGet("/", () => new { message = "OK" });

            //mapeando os endpoints das categorias
            endpoints.MapGroup("v1/categories")
                .WithTags("Categories")
                //.RequireAuthorization()
                .MapEndpoint<CreateCategoryEndpoint>()
                .MapEndpoint<UpdateCategoryEndpoint>()
                .MapEndpoint<DeleteCategoryEndpoint>()
                .MapEndpoint<GetCategoryByIdEndpoint>()
                .MapEndpoint<GetAllCategoriesEndpoint>();

            endpoints.MapGroup("v1/transactions")
                .WithTags("Transactions")
                //.RequireAuthorization()
                .MapEndpoint<CreateTransactionEndpoint>()
                .MapEndpoint<UpdateTransactionEndpoint>()
                .MapEndpoint<DeleteTransactionEndpoint>()
                .MapEndpoint<GetTransactionByIdEndpoint>()
                .MapEndpoint<GetTransactionsByPeriodEndpoint>();
        }

        private static IEndpointRouteBuilder MapEndpoint<TEndpoit>(this IEndpointRouteBuilder builder)  where TEndpoit : IEndpoint
        {
            TEndpoit.Map(builder);
            return builder;
        }
    }
}
