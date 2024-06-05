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
        private DateTime _minDate = DateTime.Now.Date;
        private DateTime _maxDate = DateTime.Now.Date.AddMonths(1);
        private DateRange _dateRange = new DateRange
                                       {
                                           Start = DateTime.Now.AddDays(1),
                                           End = DateTime.Now.AddDays(2)
                                       };
        private string DateHelperText => $"{_dateRange.Start:M} to {_dateRange.End:M}";
        private Dictionary<string, string> _stateDict = new Dictionary<string, string>()
                                                        {
                                                            { "Alabama", "AL" }, { "Alaska", "AK" }, { "Arizona", "AZ" }, { "Arkansas", "AR" }, { "American Samoa", "AS" }, { "California", "CA" }, { "Colorado", "CO" }, { "Connecticut", "CT" }, { "Delaware", "DE" }, { "District of Columbia", "DC" }, { "Florida", "FL" }, { "Georgia", "GA" }, { "Guam", "GU" }, { "Hawaii", "HI" }, { "Idaho", "ID" }, { "Illinois", "IL" }, { "Indiana", "IN" }, { "Iowa", "IA" }, { "Kansas", "KS" }, { "Kentucky", "KY" }, { "Louisiana", "LA" }, { "Maine", "ME" }, { "Maryland", "MD" }, { "Massachusetts", "MA" }, { "Michigan", "MI" }, { "Minnesota", "MN" }, { "Mississippi", "MS" }, { "Missouri", "MO" }, { "Montana", "MT" }, { "Nebraska", "NE" }, { "Nevada", "NV" }, { "New Hampshire", "NH" }, { "New Jersey", "NJ" }, { "New Mexico", "NM" }, { "New York", "NY" }, { "North Carolina", "NC" }, { "North Dakota", "ND" }, { "Northern Mariana Islands", "MP" }, { "Ohio", "OH" }, { "Oklahoma", "OK" }, { "Oregon", "OR" }, { "Pennsylvania", "PA" }, { "Puerto Rico", "PR" }, { "Rhode Island", "RI" }, { "South Carolina", "SC" }, { "South Dakota", "SD" }, { "Tennessee", "TN" }, { "Texas", "TX" }, { "Trust Territories", "TT" }, { "Utah", "UT" }, { "Vermont", "VT" }, { "Virginia", "VA" }, { "Virgin Islands", "VI" }, { "Washington", "WA" }, { "West Virginia", "WV" }, { "Wisconsin", "WI" }, { "Wyoming", "WY" }
                                                        };

        private bool _isSuccess = false;
        private bool _isSubmitting = false;
        private string[] _errors;
        private MudForm _form;

        [Inject] private ILogger<Contact> Logger { get; set; }
        [Inject] private IContactService ContactService { get; set; }

        /// <inheritdoc />
        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            await OnRangeChanged(_dateRange);
        }

        /// <inheritdoc />
        protected override async Task OnParametersSetAsync()
        {
            if (GroupId.HasValue)
                _model.GroupId = GroupId;
            if (ServiceId.HasValue)
                _model.ServiceId = ServiceId;
            await base.OnParametersSetAsync();
        }

        // Update the model with the new date information
        private async Task OnRangeChanged(DateRange dateRange)
        {
            _dateRange = dateRange;
            _model.InspectionDateRange.Start = _dateRange.Start ?? DateTime.Now.AddDays(1);
            _model.InspectionDateRange.End = _dateRange.End ?? DateTime.Now.AddDays(2);
            await Task.CompletedTask;
        }

        public async Task OnFormSubmitAsync()
        {
            _isSubmitting = true;

            await _form.Validate();
            _isSuccess = _form.IsValid;
            // Pass data annotation validations
            if (!_isSuccess)
            {
                _isSubmitting = false;
                return;
            }

            Logger.LogInformation("Form being sent to server...");
            await ContactService.ProcessContactFormAsync(_model);

            _isSuccess = true;
            _isSubmitting = false;
        }
    }
}