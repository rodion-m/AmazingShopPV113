using AmazingShopPV113.Backend.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AmazingShopPV113.Backend.Extensions
{
    public static class IApplicationBuilderExtensions
    {
        // https://anthonygiretti.com/2023/03/16/asp-net-core7-use-endpoint-groups-to-manage-minimal-apis-versioning/
        public static IEndpointRouteBuilder MapProductEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapGet("/api/products", (AppDbContext dbContext) =>
            {

                return dbContext.Products.ToListAsync();
            });

            app.MapPost("/api/products/add", async (
                [FromServices] AppDbContext dbContext, [FromBody] Product product) =>
            {
                await dbContext.Products.AddAsync(product);
                await dbContext.SaveChangesAsync();
            });

            return app;
        }
    }
}
