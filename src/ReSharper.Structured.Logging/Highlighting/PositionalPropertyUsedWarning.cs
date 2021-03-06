using JetBrains.DocumentModel;
using JetBrains.ReSharper.Feature.Services.Daemon;
using JetBrains.ReSharper.Psi.CSharp;

using ReSharper.Structured.Logging.Models;
using ReSharper.Structured.Logging.Settings;

namespace ReSharper.Structured.Logging.Highlighting
{
    [RegisterConfigurableSeverity(
        SeverityId,
        null,
        StructuredLoggingGroup.Id,
        Message,
        Message,
        Severity.WARNING)]
    [ConfigurableSeverityHighlighting(
        SeverityId,
        CSharpLanguage.Name,
        OverlapResolve = OverlapResolveKind.WARNING,
        ToolTipFormatString = Message)]
    public class PositionalPropertyUsedWarning : IHighlighting
    {
        private readonly MessageTemplateTokenInformation _tokenInformation;

        private const string Message = "Prefer named properties instead of positional ones";

        public const string SeverityId = "PositionalPropertyUsedProblem";

        public PositionalPropertyUsedWarning(MessageTemplateTokenInformation tokenInformation)
        {
            _tokenInformation = tokenInformation;
        }

        public string ErrorStripeToolTip => ToolTip;

        public string ToolTip => Message;

        public DocumentRange CalculateRange()
        {
            return _tokenInformation.DocumentRange;
        }

        public bool IsValid()
        {
            return _tokenInformation.DocumentRange.IsValid();
        }
    }
}
