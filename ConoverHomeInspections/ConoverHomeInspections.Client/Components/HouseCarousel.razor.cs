using ConoverHomeInspections.Client.Services;
using ConoverHomeInspections.Shared;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace ConoverHomeInspections.Client.Components
{
    public partial class HouseCarousel : ComponentBase
    {
        private Random _random = new Random();
        private List<ImageData> _houseImages = ClientSettings.HouseImgList;

        /// <inheritdoc />
        protected override void OnInitialized()
        {
            _houseImages = _houseImages.OrderBy(x => _random.Next(0, _houseImages.Count - 1)).ToList();
            base.OnInitialized();
        }
    }
}