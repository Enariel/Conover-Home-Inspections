using ConoverHomeInspections.Shared;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;
using DateRange=MudBlazor.DateRange;

namespace ConoverHomeInspections.Client.Pages
{
    [StreamRendering]
    public partial class Contact : ComponentBase, IDisposable
    {
        private List<ServiceGroupDTO>? _groups;
        private List<ServiceDTO>? _services;
        private ServiceGroupDTO? _selectedGroup;
        private ServiceDTO? _selectedService;
        private PersistingComponentStateSubscription? _subscription;
        private ClientContactDTO _model = new ClientContactDTO();
        private DateRange _dateRange = new DateRange();
        private DateTime _minDate = DateTime.Now.Date;
        private DateTime _maxDate = DateTime.Now.Date.AddMonths(1);
        private string DateHelperText => $"{_dateRange.Start:M} to {_dateRange.End:M}";
        private Dictionary<string, string> _stateDict = new Dictionary<string, string>()
                                                        {
                                                            { "Alabama", "AL" }
                                                            , { "Alaska", "AK" }
                                                            , { "Arizona", "AZ" }
                                                            , { "Arkansas", "AR" }
                                                            , { "American Samoa", "AS" }
                                                            , { "California", "CA" }
                                                            , { "Colorado", "CO" }
                                                            , { "Connecticut", "CT" }
                                                            , { "Delaware", "DE" }
                                                            , { "District of Columbia", "DC" }
                                                            , { "Florida", "FL" }
                                                            , { "Georgia", "GA" }
                                                            , { "Guam", "GU" }
                                                            , { "Hawaii", "HI" }
                                                            , { "Idaho", "ID" }
                                                            , { "Illinois", "IL" }
                                                            , { "Indiana", "IN" }
                                                            , { "Iowa", "IA" }
                                                            , { "Kansas", "KS" }
                                                            , { "Kentucky", "KY" }
                                                            , { "Louisiana", "LA" }
                                                            , { "Maine", "ME" }
                                                            , { "Maryland", "MD" }
                                                            , { "Massachusetts", "MA" }
                                                            , { "Michigan", "MI" }
                                                            , { "Minnesota", "MN" }
                                                            , { "Mississippi", "MS" }
                                                            , { "Missouri", "MO" }
                                                            , { "Montana", "MT" }
                                                            , { "Nebraska", "NE" }
                                                            , { "Nevada", "NV" }
                                                            , { "New Hampshire", "NH" }
                                                            , { "New Jersey", "NJ" }
                                                            , { "New Mexico", "NM" }
                                                            , { "New York", "NY" }
                                                            , { "North Carolina", "NC" }
                                                            , { "North Dakota", "ND" }
                                                            , { "Northern Mariana Islands", "MP" }
                                                            , { "Ohio", "OH" }
                                                            , { "Oklahoma", "OK" }
                                                            , { "Oregon", "OR" }
                                                            , { "Pennsylvania", "PA" }
                                                            , { "Puerto Rico", "PR" }
                                                            , { "Rhode Island", "RI" }
                                                            , { "South Carolina", "SC" }
                                                            , { "South Dakota", "SD" }
                                                            , { "Tennessee", "TN" }
                                                            , { "Texas", "TX" }
                                                            , { "Trust Territories", "TT" }
                                                            , { "Utah", "UT" }
                                                            , { "Vermont", "VT" }
                                                            , { "Virginia", "VA" }
                                                            , { "Virgin Islands", "VI" }
                                                            , { "Washington", "WA" }
                                                            , { "West Virginia", "WV" }
                                                            , { "Wisconsin", "WI" }
                                                            , { "Wyoming", "WY" }
                                                        };
        private string[] _errors = Array.Empty<string>();
        private bool _isSuccess = false;
        private bool _isSubmitting = false;

        [Inject] private ILogger<Contact> Logger { get; set; }
        [Inject] private IProductService ProductService { get; set; }
        [Inject] private IContactService ContactService { get; set; }
        [Inject] private PersistentComponentState PersistentComponentState { get; set; }

        /// <inheritdoc />
        protected override async Task OnInitializedAsync()
        {
            _subscription = PersistentComponentState.RegisterOnPersisting(PersistData);
            if (!PersistentComponentState.TryTakeFromJson<List<ServiceGroupDTO>>(nameof(_groups), out _groups))
                _groups = await ProductService.GetGroupsAsync();
            if (!PersistentComponentState.TryTakeFromJson<List<ServiceDTO>>(nameof(_services), out _services))
                _services = await ProductService.GetServicesAsync();
            await base.OnInitializedAsync();
        }

        /// <inheritdoc />
        protected override async Task OnParametersSetAsync()
        {
            await base.OnParametersSetAsync();
            if (GroupId.HasValue)
                _selectedGroup = _groups?.FirstOrDefault(g => g.GroupId == GroupId);
            if (ServiceId.HasValue)
                _selectedService = _services?.FirstOrDefault(s => s.ServiceId == ServiceId);
        }

        private Task PersistData()
        {
            PersistentComponentState.PersistAsJson(nameof(_groups), _groups);
            PersistentComponentState.PersistAsJson(nameof(_services), _services);
            return Task.CompletedTask;
        }

        // Update the model with the new date information
		private async Task OnRangeChanged(DateRange dateRange)
		{
			_dateRange = dateRange;
			_model.InspectionDateRange.Start = _dateRange.Start ?? DateTime.Now;
			_model.InspectionDateRange.End = _dateRange.End ?? DateTime.Now.AddDays(1);
			await Task.CompletedTask;
		}

		private async Task OnValidFormSubmit(EditContext ctx)
        {
            _isSubmitting = true;
            _isSuccess = false;
            await Task.Delay(1000);
            _isSuccess = true;
            _isSubmitting = false;
            await Task.CompletedTask;
        }

        public async Task OnInvalidFormSubmitAsync(EditContext ctx)
        {
            _isSubmitting = true;
            _isSuccess = false;
            await Task.Delay(1000);
            _isSuccess = true;
            _isSubmitting = false;
            await Task.CompletedTask;
        }

		/// <inheritdoc />
		public void Dispose() => _subscription?.Dispose();
    }
}