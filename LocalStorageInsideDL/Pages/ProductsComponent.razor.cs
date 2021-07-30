using System.Collections.Generic;
using System.Threading.Tasks;
using LocalStorageInsideDL.Services;
using Microsoft.AspNetCore.Components;

namespace LocalStorageInsideDL.Pages
{
    public partial class ProductsComponent
    {
        [Inject]
        private TestProductService TestLoginService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            List<ProductModel> productModels = await TestLoginService.GetListAsync();
        }
    }
}
