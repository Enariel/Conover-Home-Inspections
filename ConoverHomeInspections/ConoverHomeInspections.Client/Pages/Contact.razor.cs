using ConoverHomeInspections.Shared;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;

namespace ConoverHomeInspections.Client.Pages
{
    public partial class Contact : ComponentBase, IDisposable
    {
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