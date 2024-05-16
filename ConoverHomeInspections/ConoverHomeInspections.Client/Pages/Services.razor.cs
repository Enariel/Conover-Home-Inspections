using ConoverHomeInspections.Shared;
using Microsoft.AspNetCore.Components;

namespace ConoverHomeInspections.Client.Pages
{
    [StreamRendering]
    public partial class Services : ComponentBase, IDisposable
    {
        [Inject] public PersistentComponentState PersistentComponentState { get; set; }
        [Inject] public IProductService ProductService { get; set; }

        private ServiceProduct[]? _services;
        private PersistingComponentStateSubscription? _subscription;

        /// <inheritdoc />
        protected override async Task OnInitializedAsync()
        {
            _subscription = PersistentComponentState.RegisterOnPersisting(PersistData);
            if (!PersistentComponentState.TryTakeFromJson<ServiceProduct[]>(nameof(_services), out _services))
            {
                _services = await ProductService.GetServicesAsync();
            }
        }

        private Task PersistData()
        {
            PersistentComponentState.PersistAsJson(nameof(_services), _services);
            return Task.CompletedTask;
        }

        void IDisposable.Dispose()
        {
            _subscription?.Dispose();
        }
    }
}