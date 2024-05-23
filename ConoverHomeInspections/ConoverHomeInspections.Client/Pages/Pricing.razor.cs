using ConoverHomeInspections.Shared;
using Microsoft.AspNetCore.Components;

namespace ConoverHomeInspections.Client.Pages
{
    public partial class Pricing : ComponentBase, IDisposable
    {
        private List<ServiceGroupDTO>? _groups;
        private List<ServiceDTO>? _services;
        private PersistingComponentStateSubscription? _subscription;

        [Inject] private ILogger<Services> Logger { get; set; }
        [Inject] private PersistentComponentState PersistentComponentState { get; set; }
        [Inject] private IProductService ProductService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            _subscription = PersistentComponentState.RegisterOnPersisting(PersistData);
            if (!PersistentComponentState.TryTakeFromJson<List<ServiceGroupDTO>>(nameof(_groups), out _groups))
                _groups = await ProductService.GetGroupsAsync();
            if (!PersistentComponentState.TryTakeFromJson<List<ServiceDTO>>(nameof(_services), out _services))
                _services = await ProductService.GetServicesAsync();
        }

        private Task PersistData()
        {
            PersistentComponentState.PersistAsJson(nameof(_groups), _groups);
            PersistentComponentState.PersistAsJson(nameof(_services), _services);
            return Task.CompletedTask;
        }

        /// <inheritdoc />
        public void Dispose() => _subscription?.Dispose();
    }
}