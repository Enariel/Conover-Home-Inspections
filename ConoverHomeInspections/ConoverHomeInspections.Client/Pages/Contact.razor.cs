using ConoverHomeInspections.Shared;
using Microsoft.AspNetCore.Components;

namespace ConoverHomeInspections.Client.Pages
{
    public partial class Contact : ComponentBase, IDisposable
    {
        private ClientContactDTO _model = new ClientContactDTO();
        private Dictionary<string, List<string>> _errors = new Dictionary<string, List<string>>();
        private bool _isSubmitting = false;
        private bool _isSuccess = false;

        [Inject] private ILogger<Contact> Logger { get; set; }

        /// <inheritdoc />
        public void Dispose()
        {

        }
    }
}