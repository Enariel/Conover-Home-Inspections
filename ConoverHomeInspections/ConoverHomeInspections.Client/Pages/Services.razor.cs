using ConoverHomeInspections.Shared;
using Microsoft.AspNetCore.Components;
using System.Text.Json;

namespace ConoverHomeInspections.Client.Pages
{
    /// <summary>
    /// A component that displays the services offered by the company.
    /// </summary>
    [StreamRendering]
    public partial class Services : ComponentBase, IDisposable
    {
        private List<ServiceGroupDTO> _productGroups;
        private PersistingComponentStateSubscription? _subscription;

        [Inject] private ILogger<Services> Logger { get; set; }
        [Inject] private PersistentComponentState PersistentComponentState { get; set; }
        [Inject] private IProductService ProductService { get; set; }

        /// <inheritdoc />
        protected override async Task OnInitializedAsync()
        {
            _subscription = PersistentComponentState.RegisterOnPersisting(PersistData);
            if (!PersistentComponentState.TryTakeFromJson<List<ServiceGroupDTO>>(nameof(_productGroups), out _productGroups))
                _productGroups = await ProductService.GetGroupsAsync();
        }

        private Task PersistData()
        {
            PersistentComponentState.PersistAsJson(nameof(_productGroups), _productGroups);
            return Task.CompletedTask;
        }

        void IDisposable.Dispose() => _subscription?.Dispose();
    }
}