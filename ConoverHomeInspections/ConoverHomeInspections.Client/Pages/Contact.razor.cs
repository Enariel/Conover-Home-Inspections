using ConoverHomeInspections.Shared;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;
using DateRange=MudBlazor.DateRange;

namespace ConoverHomeInspections.Client.Pages
{
    public partial class Contact : ComponentBase
    {
        private ClientContactDTO _model = new ClientContactDTO();
        private DateRange _dateRange = new DateRange();
        private DateTime _minDate = DateTime.Now.Date;
        private DateTime _maxDate = DateTime.Now.Date.AddMonths(1);
        private string DateHelperText => $"{_dateRange.Start:M} to {_dateRange.End:M}";

        private Dictionary<string, string> _stateDict = new Dictionary<string, string>()
                                                        {
                                                            { "Alabama", "AL" }, { "Alaska", "AK" }, { "Arizona", "AZ" }, { "Arkansas", "AR" }, { "American Samoa", "AS" }, { "California", "CA" }, { "Colorado", "CO" }, { "Connecticut", "CT" }, { "Delaware", "DE" }, { "District of Columbia", "DC" }, { "Florida", "FL" }, { "Georgia", "GA" }, { "Guam", "GU" }, { "Hawaii", "HI" }, { "Idaho", "ID" }, { "Illinois", "IL" }, { "Indiana", "IN" }, { "Iowa", "IA" }, { "Kansas", "KS" }, { "Kentucky", "KY" }, { "Louisiana", "LA" }, { "Maine", "ME" }, { "Maryland", "MD" }, { "Massachusetts", "MA" }, { "Michigan", "MI" }, { "Minnesota", "MN" }, { "Mississippi", "MS" }, { "Missouri", "MO" }, { "Montana", "MT" }, { "Nebraska", "NE" }, { "Nevada", "NV" }, { "New Hampshire", "NH" }, { "New Jersey", "NJ" }, { "New Mexico", "NM" }, { "New York", "NY" }, { "North Carolina", "NC" }, { "North Dakota", "ND" }, { "Northern Mariana Islands", "MP" }, { "Ohio", "OH" }, { "Oklahoma", "OK" }, { "Oregon", "OR" }, { "Pennsylvania", "PA" }, { "Puerto Rico", "PR" }, { "Rhode Island", "RI" }, { "South Carolina", "SC" }, { "South Dakota", "SD" }, { "Tennessee", "TN" }, { "Texas", "TX" }, { "Trust Territories", "TT" }, { "Utah", "UT" }, { "Vermont", "VT" }, { "Virginia", "VA" }, { "Virgin Islands", "VI" }, { "Washington", "WA" }, { "West Virginia", "WV" }, { "Wisconsin", "WI" }, { "Wyoming", "WY" }
                                                        };

        private bool _isSuccess = false;
        private bool _isSubmitting = false;

        [Inject] private ILogger<Contact> Logger { get; set; }
        [Inject] private IContactService ContactService { get; set; }

        /// <inheritdoc />
        protected override async Task OnParametersSetAsync()
        {
            if (GroupId.HasValue)
                _model.GroupId = GroupId;
            if (ServiceId.HasValue)
                _model.ServiceId = ServiceId;
            await base.OnParametersSetAsync();
        }

        /// <inheritdoc />
        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            _model.InspectionDateRange.Start = DateTime.Now;
            _model.InspectionDateRange.End = DateTime.Now.AddDays(1);
        }

        // Update the model with the new date information
        private async Task OnRangeChanged(DateRange dateRange)
        {
            _dateRange = dateRange;
            _model.InspectionDateRange.Start = _dateRange.Start ?? DateTime.Now;
            _model.InspectionDateRange.End = _dateRange.End ?? DateTime.Now.AddDays(1);
            await Task.CompletedTask;
        }

        public async Task OnFormSubmitAsync(EditContext ctx)
        {
            _isSubmitting = true;
            _isSuccess = false;

            // Pass data annotation validations
            if (!ctx.Validate())
            {
                _isSubmitting = false;
                _isSuccess = false;
                StateHasChanged();
                Logger.LogWarning("Form did not pass data validations...");
                return;
            }

            // Then pass custom validations
            // Address validations
            // Realtor validations

            Logger.LogInformation("Form being sent to server...");
            await ContactService.ProcessContactFormAsync(_model);
            _isSuccess = true;
            _isSubmitting = false;
            await Task.CompletedTask;
        }
    }
}