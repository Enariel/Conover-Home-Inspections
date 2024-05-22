using ConoverHomeInspections.Shared;
using Microsoft.AspNetCore.Components;

namespace ConoverHomeInspections.Client.Components
{
    public partial class PriceCard : ComponentBase
    {
        private bool _expanded = false;
        [Parameter] public ServiceDTO Service { get; set; }

        private void OnExpandCollapseClick() {
            _expanded = !_expanded;
        }
    }
}