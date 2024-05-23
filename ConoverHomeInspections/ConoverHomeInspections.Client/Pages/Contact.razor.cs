using ConoverHomeInspections.Shared;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;

namespace ConoverHomeInspections.Client.Pages
{
    public partial class Contact : ComponentBase, IDisposable
    {
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
                                                            , { "Minnesota", "MN" }, { "Mississippi", "MS" }, { "Missouri", "MO" }, { "Montana", "MT" }, { "Nebraska", "NE" }, { "Nevada", "NV" }, { "New Hampshire", "NH" }, { "New Jersey", "NJ" }, { "New Mexico", "NM" }, { "New York", "NY" }, { "North Carolina", "NC" }, { "North Dakota", "ND" }, { "Northern Mariana Islands", "MP" }, { "Ohio", "OH" }, { "Oklahoma", "OK" }, { "Oregon", "OR" }, { "Pennsylvania", "PA" }, { "Puerto Rico", "PR" }, { "Rhode Island", "RI" }, { "South Carolina", "SC" }, { "South Dakota", "SD" }, { "Tennessee", "TN" }, { "Texas", "TX" }, { "Trust Territories", "TT" }, { "Utah", "UT" }, { "Vermont", "VT" }, { "Virginia", "VA" }, { "Virgin Islands", "VI" }, { "Washington", "WA" }, { "West Virginia", "WV" }, { "Wisconsin", "WI" }, { "Wyoming", "WY" }
                                                        };

        private ClientContactDTO _model = new ClientContactDTO();
        private string[] _errors = Array.Empty<string>();
        private bool _isSuccess = false;
        private bool _isSubmitting = false;

        [Inject] private ILogger<Contact> Logger { get; set; }

        /// <inheritdoc />
        public void Dispose()
        {

        }

        private async Task OnContactSubmit(EditContext editContext)
        {
            await Task.CompletedTask;
        }
    }
}