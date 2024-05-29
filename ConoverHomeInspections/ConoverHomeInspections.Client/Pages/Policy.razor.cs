using ConoverHomeInspections.Shared;
using Microsoft.AspNetCore.Components;

namespace ConoverHomeInspections.Client.Pages
{
    public partial class Policy : ComponentBase
    {
        private List<ConfigurationSetting> _settings = new List<ConfigurationSetting>()
                                                       {
                                                           new ConfigurationSetting
                                                           {
                                                               Name = "Policy",
                                                               Value = "Inspection reports will be released to the client within 24 to 48 hours after the completion of the inspection, depending on the complexity of the property.",
                                                               For = "Inspection Report Release Timing",
                                                               Field = 1
                                                           },
                                                           new ConfigurationSetting
                                                           {
                                                               Name = "Policy",
                                                               Value = "Inspection reports are confidential documents and will only be released to the client who commissioned the inspection, unless otherwise instructed by the client or required by law.",
                                                               For = "Confidentiality",
                                                               Field = 2
                                                           },
                                                           new ConfigurationSetting
                                                           {
                                                               Name = "Policy",
                                                               Value = "Inspection reports will be delivered electronically, typically via email, unless other arrangements are made with the client.",
                                                               For = "Delivery Method",
                                                               Field = 3
                                                           },
                                                           new ConfigurationSetting
                                                           {
                                                               Name = "Policy",
                                                               Value = "The inspection report will include a detailed assessment of the property's condition, including any defects or issues found during the inspection, as well as recommendations for repairs or further evaluation by specialists if necessary.",
                                                               For = "Content of the Report",
                                                               Field = 4
                                                           },
                                                           new ConfigurationSetting
                                                           {
                                                               Name = "Policy",
                                                               Value = "Clients will have access to their inspection reports for a minimum of one year following the inspection date. After that period, clients may request additional copies of the report for a fee.",
                                                               For = "Client Access",
                                                               Field = 4
                                                           },
                                                           new ConfigurationSetting
                                                           {
                                                               Name = "Policy",
                                                               Value = "The release of inspection reports to any third party requires the written consent of the client.",
                                                               For = "Client Consent",
                                                               Field = 5
                                                           },
                                                           new ConfigurationSetting
                                                           {
                                                               Name = "Policy",
                                                               Value = "Copies of all inspection reports will be kept on file by the home inspector for a minimum of five years following the inspection date, in accordance with Florida state regulations.",
                                                               For = "Record Keeping",
                                                               Field = 6
                                                           },
                                                           new ConfigurationSetting
                                                           {
                                                               Name = "Policy",
                                                               Value = "In the event that additional information becomes available or corrections are needed to the inspection report after its initial release, clients will be promptly notified and provided with updated documentation as necessary.",
                                                               For = "Updates",
                                                               Field = 7
                                                           },
                                                           new ConfigurationSetting
                                                           {
                                                               Name = "Policy",
                                                               Value = "The release policy will comply with all relevant laws, regulations, and industry standards governing home inspections in the state of Florida.",
                                                               For = "Compliance",
                                                               Field = 8
                                                           },
                                                           new ConfigurationSetting
                                                           {
                                                               Name = "Policy",
                                                               Value = "Clients will be informed of the release policy at the time of booking the inspection, and any questions or concerns regarding the policy will be addressed by the home inspector prior to the inspection taking place.",
                                                               For = "Client Communication",
                                                               Field = 9
                                                           },
                                                       };
    }
}