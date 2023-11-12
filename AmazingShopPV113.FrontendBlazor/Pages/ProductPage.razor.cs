using AmazingShopPV113.Backend.Data;
using Microsoft.AspNetCore.Components;

namespace AmazingShopPV113.FrontendBlazor.Pages
{
    public partial class ProductPage
    {
        [Parameter]
        public Guid ProductId { get; set; }

        private Product _product { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            _product = new Product()
            {
                Id = ProductId,
                Name = "Товар " + ProductId
            };
        }
    }
}
